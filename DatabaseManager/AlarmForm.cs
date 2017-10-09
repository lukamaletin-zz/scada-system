using System;
using System.ServiceModel;
using System.Windows.Forms;
using DatabaseManager.Properties;
using SCADACommon;
using SCADACommon.Model;
using SCADACommon.Service;

namespace DatabaseManager
{
    [CallbackBehavior(UseSynchronizationContext = false)]
    public partial class AlarmForm : Form, IGuiCallback
    {
        private readonly IDatabaseManager _proxy;
        private readonly Tag clickedTag;

        public AlarmForm(ListViewItem clickedItem)
        {
            InitializeComponent();
            var address = new Uri(ScadaConstants.DatabaseManagerUri);
            var binding = new NetTcpBinding {Security = {Mode = SecurityMode.None}};
            var factory = new DuplexChannelFactory<IDatabaseManager>(this, binding, new EndpointAddress(address));
            _proxy = factory.CreateChannel();

            clickedTag = (Tag) clickedItem.Tag;
            if (clickedTag.GetType() == typeof(DigitalInputTag) || clickedTag.GetType() == typeof(DigitalOutputTag))
            {
                textBoxLowLimit.Hide();
                textBoxHighLimit.Hide();
                radioButtonZero.Checked = true;
            }
            else
            {
                radioButtonZero.Hide();
                radioButtonOne.Hide();
            }
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxId.Text))
            {
                ShowErrorMessage("You must enter an ID!");
            }
            else if (textBoxLowLimit.Visible && string.IsNullOrEmpty(textBoxLowLimit.Text))
            {
                ShowErrorMessage("You must enter a low limit!");
            }
            else if (textBoxHighLimit.Visible && string.IsNullOrEmpty(textBoxHighLimit.Text))
            {
                ShowErrorMessage("You must enter a high limit!");
            }
            else
            {
                Alarm alarm;
                if (clickedTag.GetType() == typeof(AnalogInputTag))
                {
                    alarm = new Alarm(textBoxId.Text, Convert.ToDouble(textBoxLowLimit.Text),
                        Convert.ToDouble(textBoxHighLimit.Text));
                }
                else
                {
                    alarm = new Alarm {Id = textBoxId.Text};
                    if (radioButtonZero.Checked)
                    {
                        alarm.LowLimit = -1;
                        alarm.HighLimit = 1;
                    }
                    else
                    {
                        alarm.LowLimit = 0;
                        alarm.HighLimit = 2;
                    }
                }

                if (!_proxy.AddInputTagAlarm(clickedTag.Id, alarm))
                {
                    ShowErrorMessage("You must enter a unique alarm ID!");
                }
                else
                {
                    Close();
                }
            }
        }

        private static void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, Resources.TagForm_ShowErrorMessage_Error_, MessageBoxButtons.OK,
                MessageBoxIcon.Error);
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

        private void AlarmForm_FormClosing(object sender, EventArgs e)
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