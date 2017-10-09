using System;
using System.Collections.Generic;
using System.Globalization;
using System.ServiceModel;
using System.Windows.Forms;
using DatabaseManager.Properties;
using SCADACommon;
using SCADACommon.Model;
using SCADACommon.Service;

namespace DatabaseManager
{
    public enum Operation
    {
        Add,
        Update
    }

    [CallbackBehavior(UseSynchronizationContext = false)]
    public partial class TagForm : Form, IGuiCallback
    {
        private readonly Operation _operation;
        private readonly IDatabaseManager _proxy;
        private readonly Tag _clickedTag;


        public TagForm(Operation operation, ListViewItem clickedItem)
        {
            InitializeComponent();
            var address = new Uri(ScadaConstants.DatabaseManagerUri);
            var binding = new NetTcpBinding {Security = {Mode = SecurityMode.None}};
            var factory = new DuplexChannelFactory<IDatabaseManager>(this, binding, new EndpointAddress(address));
            _proxy = factory.CreateChannel();

            _operation = operation;
            if (operation == Operation.Add)
            {
                ToggleInputsEnabled(false);
                labelValue.Hide();
                textBoxValue.Hide();
            }
            else if (operation == Operation.Update)
            {
                _clickedTag = (Tag) clickedItem.Tag;
                SetInputsByTag(_clickedTag);
                PopulateInputsByTag(_clickedTag);
                if (_clickedTag is InputTag)
                {
                    labelValue.Hide();
                    textBoxValue.Hide();
                }
                if (_clickedTag.GetType() != typeof(AnalogInputTag))
                {
                    labelFunction.Hide();
                    comboBoxFunction.Hide();
                }
            }
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            if (_operation == Operation.Add)
            {
                DoneClickAddOperation();
            }
            else if (_operation == Operation.Update)
            {
                DoneClickUpdateOperation();
            }
        }

        private void DoneClickAddOperation()
        {
            if (!InputsFilledCorrectly())
            {
                return;
            }

            var newTag = CreateTagFromInputs();
            if (!_proxy.AddTag(newTag))
            {
                ShowErrorMessage("You must enter a unique ID and I/O address!");
            }
            else
            {
                Close();
            }
        }


        private void DoneClickUpdateOperation()
        {
            if (!InputsFilledCorrectly())
            {
                return;
            }

            var updatedTag = CreateTagFromInputs();
            if (!string.IsNullOrEmpty(textBoxValue.Text))
            {
                updatedTag.Driver = new SimulationDriver();
                updatedTag.SetValue(Convert.ToDouble(textBoxValue.Text));
            }

            if (!_proxy.UpdateTag(updatedTag))
            {
                ShowErrorMessage("Error updating tag!");
            }
            else
            {
                Close();
            }
        }

        private Tag CreateTagFromInputs()
        {
            switch (comboBoxTagType.SelectedItem.ToString())
            {
                case "Analog Input":
                    return new AnalogInputTag(textBoxId.Text, textBoxDescription.Text, null, textBoxAddress.Text,
                        Convert.ToInt32(textBoxScanTime.Text), new List<Alarm>(), checkBoxOnScan.Checked,
                        checkBoxAutoMode.Checked,
                        (FunctionType) Enum.Parse(typeof(FunctionType), comboBoxFunction.SelectedItem.ToString()),
                        Convert.ToDouble(textBoxLowLimit.Text), Convert.ToDouble(textBoxHighLimit.Text),
                        textBoxUnits.Text
                    );
                case "Analog Output":
                    return new AnalogOutputTag(textBoxId.Text, textBoxDescription.Text, null, textBoxAddress.Text,
                        Convert.ToDouble(textBoxInitialValue.Text), Convert.ToDouble(textBoxLowLimit.Text),
                        Convert.ToDouble(textBoxHighLimit.Text), textBoxUnits.Text
                    );

                case "Digital Input":
                    return new DigitalInputTag(textBoxId.Text, textBoxDescription.Text, null, textBoxAddress.Text,
                        Convert.ToInt32(textBoxScanTime.Text), new List<Alarm>(), checkBoxOnScan.Checked,
                        checkBoxAutoMode.Checked, FunctionType.Digital);
                case "Digital Output":
                    return new DigitalOutputTag(textBoxId.Text, textBoxDescription.Text, null, textBoxAddress.Text,
                        Convert.ToDouble(textBoxInitialValue.Text));
                default:
                    return new Tag();
            }
        }

        private static void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, Resources.TagForm_ShowErrorMessage_Error_, MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        private void comboBoxTagType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToggleInputsEnabled(true);
            switch (comboBoxTagType.SelectedItem.ToString())
            {
                case "Analog Input":
                    textBoxInitialValue.Enabled = false;
                    textBoxValue.Enabled = false;
                    break;
                case "Analog Output":
                    textBoxScanTime.Enabled = false;
                    checkBoxOnScan.Enabled = false;
                    checkBoxAutoMode.Enabled = false;
                    comboBoxFunction.Enabled = false;
                    break;
                case "Digital Input":
                    textBoxInitialValue.Enabled = false;
                    textBoxLowLimit.Enabled = false;
                    textBoxHighLimit.Enabled = false;
                    textBoxUnits.Enabled = false;
                    textBoxValue.Enabled = false;
                    comboBoxFunction.Enabled = false;
                    break;
                case "Digital Output":
                    textBoxScanTime.Enabled = false;
                    textBoxLowLimit.Enabled = false;
                    textBoxHighLimit.Enabled = false;
                    textBoxUnits.Enabled = false;
                    checkBoxOnScan.Enabled = false;
                    checkBoxAutoMode.Enabled = false;
                    comboBoxFunction.Enabled = false;
                    break;
            }
        }

        private void ToggleInputsEnabled(bool enabled)
        {
            textBoxId.Enabled = enabled;
            textBoxDescription.Enabled = enabled;
            textBoxAddress.Enabled = enabled;
            textBoxInitialValue.Enabled = enabled;
            textBoxScanTime.Enabled = enabled;
            textBoxLowLimit.Enabled = enabled;
            textBoxHighLimit.Enabled = enabled;
            textBoxUnits.Enabled = enabled;
            checkBoxOnScan.Enabled = enabled;
            checkBoxAutoMode.Enabled = enabled;
            comboBoxFunction.Enabled = enabled;
            textBoxValue.Enabled = enabled;
        }

        private void SetInputsByTag(Tag tag)
        {
            ToggleInputsEnabled(true);

            if (tag.GetType() == typeof(AnalogInputTag))
            {
                comboBoxTagType.SelectedIndex = 0;
            }
            else if (tag.GetType() == typeof(AnalogOutputTag))
            {
                comboBoxTagType.SelectedIndex = 1;
            }
            else if (tag.GetType() == typeof(DigitalInputTag))
            {
                comboBoxTagType.SelectedIndex = 2;
            }
            else if (tag.GetType() == typeof(DigitalOutputTag))
            {
                comboBoxTagType.SelectedIndex = 3;
            }

            if (tag is OutputTag || tag is InputTag && ((InputTag) tag).AutoMode)
            {
                textBoxInitialValue.Enabled = false;
            }

            comboBoxTagType.Enabled = false;
            textBoxId.Enabled = false;
            textBoxAddress.Enabled = false;
        }

        private void PopulateInputsByTag(Tag tag)
        {
            textBoxId.Text = tag.Id;
            textBoxDescription.Text = tag.Description;
            textBoxAddress.Text = tag.Address;

            if (tag.GetType() == typeof(AnalogInputTag))
            {
                textBoxScanTime.Text = ((AnalogInputTag) tag).ScanTime.ToString();
                checkBoxOnScan.Checked = ((AnalogInputTag) tag).OnScan;
                checkBoxAutoMode.Checked = ((AnalogInputTag) tag).AutoMode;
                textBoxLowLimit.Text = ((AnalogInputTag) tag).LowLimit.ToString(CultureInfo.CurrentCulture);
                textBoxHighLimit.Text = ((AnalogInputTag) tag).HighLimit.ToString(CultureInfo.CurrentCulture);
                textBoxUnits.Text = ((AnalogInputTag) tag).Units;
                comboBoxFunction.Text = ((AnalogInputTag) tag).FunctionType.ToString();
            }
            else if (tag.GetType() == typeof(AnalogOutputTag))
            {
                textBoxInitialValue.Text = ((AnalogOutputTag) tag).InitialValue.ToString(CultureInfo.CurrentCulture);
                textBoxLowLimit.Text = ((AnalogOutputTag) tag).LowLimit.ToString(CultureInfo.CurrentCulture);
                textBoxHighLimit.Text = ((AnalogOutputTag) tag).HighLimit.ToString(CultureInfo.CurrentCulture);
                textBoxUnits.Text = ((AnalogOutputTag) tag).Units;
                textBoxValue.Text = ((AnalogOutputTag) tag).GetValue().ToString(CultureInfo.CurrentCulture);
            }
            else if (tag.GetType() == typeof(DigitalInputTag))
            {
                textBoxScanTime.Text = ((DigitalInputTag) tag).ScanTime.ToString();
                checkBoxOnScan.Checked = ((DigitalInputTag) tag).OnScan;
                checkBoxAutoMode.Checked = ((DigitalInputTag) tag).AutoMode;
            }
            else if (tag.GetType() == typeof(DigitalOutputTag))
            {
                textBoxInitialValue.Text = ((DigitalOutputTag) tag).InitialValue.ToString(CultureInfo.CurrentCulture);
                textBoxValue.Text = ((DigitalOutputTag) tag).GetValue().ToString(CultureInfo.CurrentCulture);
            }
        }

        private bool InputsFilledCorrectly()
        {
            double num;
            if (string.IsNullOrEmpty(comboBoxTagType.Text))
            {
                ShowErrorMessage("You must choose a tag type!");
                return false;
            }
            if (string.IsNullOrEmpty(textBoxId.Text))
            {
                ShowErrorMessage("You must enter an ID!");
                return false;
            }
            if (string.IsNullOrEmpty(textBoxDescription.Text))
            {
                ShowErrorMessage("You must enter a description!");
                return false;
            }
            if (string.IsNullOrEmpty(textBoxAddress.Text))
            {
                ShowErrorMessage("You must enter an I/O address!");
                return false;
            }
            if (textBoxInitialValue.Enabled && string.IsNullOrEmpty(textBoxInitialValue.Text))
            {
                ShowErrorMessage("You must enter an initial value!");
                return false;
            }
            if (textBoxInitialValue.Enabled && !double.TryParse(textBoxInitialValue.Text, out num))
            {
                ShowErrorMessage("Initial value must be a number!");
                return false;
            }
            if (comboBoxTagType.SelectedItem.ToString() == "Digital Output" &&
                double.TryParse(textBoxInitialValue.Text, out num) && num != 0 && num != 1)
            {
                ShowErrorMessage("Initial value for digital output tag must be 0 or 1");
                return false;
            }
            if (textBoxScanTime.Enabled && string.IsNullOrEmpty(textBoxScanTime.Text))
            {
                ShowErrorMessage("You must enter a scan time!");
                return false;
            }
            if (textBoxScanTime.Enabled && !double.TryParse(textBoxScanTime.Text, out num))
            {
                ShowErrorMessage("Scan time must be a number!");
                return false;
            }
            if (textBoxScanTime.Enabled && double.TryParse(textBoxScanTime.Text, out num) && num <= 0)
            {
                ShowErrorMessage("Scan time must be positive!");
                return false;
            }
            if (textBoxLowLimit.Enabled && string.IsNullOrEmpty(textBoxLowLimit.Text))
            {
                ShowErrorMessage("You must enter a low limit!");
                return false;
            }
            if (textBoxLowLimit.Enabled && !double.TryParse(textBoxLowLimit.Text, out num))
            {
                ShowErrorMessage("Low limit must be a number!");
                return false;
            }
            if (textBoxHighLimit.Enabled && string.IsNullOrEmpty(textBoxHighLimit.Text))
            {
                ShowErrorMessage("You must enter a high limnit!");
                return false;
            }
            if (textBoxHighLimit.Enabled && !double.TryParse(textBoxHighLimit.Text, out num))
            {
                ShowErrorMessage("High limit must be a number!");
                return false;
            }
            if (textBoxUnits.Enabled && string.IsNullOrEmpty(textBoxUnits.Text))
            {
                ShowErrorMessage("You must enter a unit type!");
                return false;
            }
            if (comboBoxTagType.SelectedItem.ToString() == "Digital Input" &&
                double.TryParse(textBoxValue.Text, out num) && num != 0 && num != 1)
            {
                ShowErrorMessage("Value for digital input tag must be 0 or 1");
                return false;
            }
            if (comboBoxFunction.Enabled && string.IsNullOrEmpty(comboBoxFunction.Text))
            {
                ShowErrorMessage("You must choose a function type!");
                return false;
            }
            return true;
        }

        public void OnAddTag(Tag tag)
        {
        }

        public void OnRemoveTag(Tag tag)
        {
        }

        public void OnUpdateTag(Tag tag)
        {
        }

        private void checkBoxAutoMode_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxAutoMode.Checked && _clickedTag is OutputTag)
            {
                labelValue.Show();
                textBoxValue.Show();
                textBoxValue.Enabled = true;
            }
            else
            {
                labelValue.Hide();
                textBoxValue.Hide();
            }
        }

        private void TagForm_FormClosing(object sender, EventArgs e)
        {
            try
            {
                _proxy.UnsubscribeFromTags();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
    }
}