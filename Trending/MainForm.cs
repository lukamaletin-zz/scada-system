using System;
using System.Globalization;
using System.ServiceModel;
using System.Windows.Forms;
using SCADACommon;
using SCADACommon.Model;
using SCADACommon.Service;

namespace Trending
{
    public delegate void MainThreadHandler(Tag tag);

    [CallbackBehavior(UseSynchronizationContext = false)]
    public partial class MainForm : Form, IGuiCallback
    {
        private readonly ITrending _proxy;

        public MainForm()
        {
            InitializeComponent();
            var address = new Uri(ScadaConstants.TrendingUri);
            var binding = new NetTcpBinding {Security = {Mode = SecurityMode.None}};
            var factory = new DuplexChannelFactory<ITrending>(this, binding, new EndpointAddress(address));
            _proxy = factory.CreateChannel();

            _proxy.SubscribeToTags();
        }

        public void OnAddTag(Tag tag)
        {
            if (tag.GetType() == typeof(AnalogInputTag))
            {
                if (listViewAI.InvokeRequired)
                {
                    var handler = new MainThreadHandler(OnAddTag);
                    BeginInvoke(handler, tag);
                    return;
                }
                AddAnalogInputTag((AnalogInputTag) tag);
            }
            else if (tag.GetType() == typeof(AnalogOutputTag))
            {
                if (listViewAO.InvokeRequired)
                {
                    var handler = new MainThreadHandler(OnAddTag);
                    BeginInvoke(handler, tag);
                    return;
                }
                AddAnalogOutputTag((AnalogOutputTag) tag);
            }
            else if (tag.GetType() == typeof(DigitalInputTag))
            {
                if (listViewDI.InvokeRequired)
                {
                    var handler = new MainThreadHandler(OnAddTag);
                    BeginInvoke(handler, tag);
                    return;
                }
                AddDigitalInputTag((DigitalInputTag) tag);
            }
            else
            {
                if (listViewDO.InvokeRequired)
                {
                    var handler = new MainThreadHandler(OnAddTag);
                    BeginInvoke(handler, tag);
                    return;
                }
                AddDigitalOutputTag((DigitalOutputTag) tag);
            }
        }

        public void OnRemoveTag(Tag tag)
        {
            if (tag.GetType() == typeof(AnalogInputTag))
            {
                if (listViewAI.InvokeRequired)
                {
                    var handler = new MainThreadHandler(OnRemoveTag);
                    BeginInvoke(handler, tag);
                    return;
                }
                RemoveTagFromListView(listViewAI, tag);
            }
            else if (tag.GetType() == typeof(AnalogOutputTag))
            {
                if (listViewAO.InvokeRequired)
                {
                    var handler = new MainThreadHandler(OnRemoveTag);
                    BeginInvoke(handler, tag);
                    return;
                }
                RemoveTagFromListView(listViewAO, tag);
            }
            else if (tag.GetType() == typeof(DigitalInputTag))
            {
                if (listViewDI.InvokeRequired)
                {
                    var handler = new MainThreadHandler(OnRemoveTag);
                    BeginInvoke(handler, tag);
                    return;
                }
                RemoveTagFromListView(listViewDI, tag);
            }
            else
            {
                if (listViewDO.InvokeRequired)
                {
                    var handler = new MainThreadHandler(OnRemoveTag);
                    BeginInvoke(handler, tag);
                    return;
                }
                RemoveTagFromListView(listViewDO, tag);
            }
        }

        public void OnUpdateTag(Tag tag)
        {
            if (tag.GetType() == typeof(AnalogInputTag))
            {
                if (listViewAI.InvokeRequired)
                {
                    var handler = new MainThreadHandler(OnUpdateTag);
                    BeginInvoke(handler, tag);
                    return;
                }
                UpdateAnalogInputTag((AnalogInputTag) tag);
            }
            else if (tag.GetType() == typeof(AnalogOutputTag))
            {
                if (listViewAO.InvokeRequired)
                {
                    var handler = new MainThreadHandler(OnUpdateTag);
                    BeginInvoke(handler, tag);
                    return;
                }
                UpdateAnalogOutputTag((AnalogOutputTag) tag);
            }
            else if (tag.GetType() == typeof(DigitalInputTag))
            {
                if (listViewDI.InvokeRequired)
                {
                    var handler = new MainThreadHandler(OnUpdateTag);
                    BeginInvoke(handler, tag);
                    return;
                }
                UpdateDigitalInputTag((DigitalInputTag) tag);
            }
            else
            {
                if (listViewDO.InvokeRequired)
                {
                    var handler = new MainThreadHandler(OnUpdateTag);
                    BeginInvoke(handler, tag);
                    return;
                }
                UpdateDigitalOutputTag((DigitalOutputTag) tag);
            }
        }

        private void AddAnalogInputTag(AnalogInputTag tag)
        {
            if (listViewAI.FindItemWithText(tag.Id) != null)
            {
                return;
            }
            var item = new ListViewItem(tag.Id) {Tag = tag};
            item.SubItems.Add(tag.Description);
            item.SubItems.Add(tag.Address);
            item.SubItems.Add(tag.LowLimit.ToString(CultureInfo.CurrentCulture));
            item.SubItems.Add(tag.HighLimit.ToString(CultureInfo.CurrentCulture));
            item.SubItems.Add(tag.Units);
            item.SubItems.Add(tag.GetValue().ToString(CultureInfo.CurrentCulture));
            listViewAI.Items.Add(item);
        }

        public void AddAnalogOutputTag(AnalogOutputTag tag)
        {
            if (listViewAO.FindItemWithText(tag.Id) != null)
            {
                return;
            }
            var item = new ListViewItem(tag.Id) {Tag = tag};
            item.SubItems.Add(tag.Description);
            item.SubItems.Add(tag.Address);
            item.SubItems.Add(tag.LowLimit.ToString(CultureInfo.CurrentCulture));
            item.SubItems.Add(tag.HighLimit.ToString(CultureInfo.CurrentCulture));
            item.SubItems.Add(tag.Units);
            item.SubItems.Add(tag.GetValue().ToString(CultureInfo.CurrentCulture));
            listViewAO.Items.Add(item);
        }

        public void AddDigitalInputTag(DigitalInputTag tag)
        {
            if (listViewDI.FindItemWithText(tag.Id) != null)
            {
                return;
            }
            var item = new ListViewItem(tag.Id) {Tag = tag};
            item.SubItems.Add(tag.Description);
            item.SubItems.Add(tag.Address);
            item.SubItems.Add(tag.GetValue().ToString(CultureInfo.CurrentCulture));
            listViewDI.Items.Add(item);
        }

        public void AddDigitalOutputTag(DigitalOutputTag tag)
        {
            if (listViewDO.FindItemWithText(tag.Id) != null)
            {
                return;
            }
            var item = new ListViewItem(tag.Id) {Tag = tag};
            item.SubItems.Add(tag.Description);
            item.SubItems.Add(tag.Address);
            item.SubItems.Add(tag.GetValue().ToString(CultureInfo.CurrentCulture));
            listViewDO.Items.Add(item);
        }

        public void RemoveTagFromListView(ListView listView, Tag tag)
        {
            var item = listView.FindItemWithText(tag.Id);
            if (item != null)
            {
                listView.Items.Remove(item);
            }
        }

        private void UpdateAnalogInputTag(AnalogInputTag tag)
        {
            var item = listViewAI.FindItemWithText(tag.Id);
            if (item == null && tag.OnScan)
            {
                AddAnalogInputTag(tag);
                return;
            }
            if (!tag.OnScan)
            {
                RemoveTagFromListView(listViewAI, tag);
                return;
            }

            if (item != null)
            {
                item.Tag = tag;
                item.SubItems[1].Text = tag.Description;
                item.SubItems[2].Text = tag.Address;
                item.SubItems[3].Text = tag.LowLimit.ToString(CultureInfo.CurrentCulture);
                item.SubItems[4].Text = tag.HighLimit.ToString(CultureInfo.CurrentCulture);
                item.SubItems[5].Text = tag.Units;
                item.SubItems[6].Text = tag.GetValue().ToString(CultureInfo.CurrentCulture);
            }
        }

        public void UpdateAnalogOutputTag(AnalogOutputTag tag)
        {
            var item = listViewAO.FindItemWithText(tag.Id);
            item.Tag = tag;
            item.SubItems[1].Text = tag.Description;
            item.SubItems[2].Text = tag.Address;
            item.SubItems[3].Text = tag.LowLimit.ToString(CultureInfo.CurrentCulture);
            item.SubItems[4].Text = tag.HighLimit.ToString(CultureInfo.CurrentCulture);
            item.SubItems[5].Text = tag.Units;
            item.SubItems[6].Text = tag.GetValue().ToString(CultureInfo.CurrentCulture);
        }

        public void UpdateDigitalInputTag(DigitalInputTag tag)
        {
            var item = listViewDI.FindItemWithText(tag.Id);
            if (item == null && tag.OnScan)
            {
                AddDigitalInputTag(tag);
                return;
            }
            if (!tag.OnScan)
            {
                RemoveTagFromListView(listViewDI, tag);
                return;
            }

            if (item != null)
            {
                item.Tag = tag;
                item.SubItems[1].Text = tag.Description;
                item.SubItems[2].Text = tag.Address;
                item.SubItems[3].Text = tag.GetValue().ToString(CultureInfo.CurrentCulture);
            }
        }

        public void UpdateDigitalOutputTag(DigitalOutputTag tag)
        {
            var item = listViewDO.FindItemWithText(tag.Id);
            item.Tag = tag;
            item.SubItems[1].Text = tag.Description;
            item.SubItems[2].Text = tag.Address;
            item.SubItems[3].Text = tag.GetValue().ToString(CultureInfo.CurrentCulture);
        }

        private void listViewDI_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewDI.SelectedItems.Count <= 0)
            {
                return;
            }

            var tag = (Tag) listViewDI.SelectedItems[0].Tag;
            if (tag == null)
            {
                return;
            }

            var graphForm = new GraphForm(tag) {Text = tag.Description};
            graphForm.Show();
        }

        private void listViewAI_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewAI.SelectedItems.Count <= 0)
            {
                return;
            }

            var tag = (Tag) listViewAI.SelectedItems[0].Tag;
            if (tag == null)
            {
                return;
            }

            var graphForm = new GraphForm(tag) {Text = tag.Description};
            graphForm.Show();
        }

        private void MainForm_FormClosing(object sender, EventArgs e)
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