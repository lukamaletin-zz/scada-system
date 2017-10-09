using System;
using System.Globalization;
using System.ServiceModel;
using System.Windows.Forms;
using SCADACommon;
using SCADACommon.Model;
using SCADACommon.Service;

namespace DatabaseManager
{
    public delegate void MainThreadHandler(Tag tag);

    [CallbackBehavior(UseSynchronizationContext = false)]
    public partial class DbForm : Form, IGuiCallback
    {
        private readonly IDatabaseManager _proxy;

        public DbForm()
        {
            InitializeComponent();
            var address = new Uri(ScadaConstants.DatabaseManagerUri);
            var binding = new NetTcpBinding {Security = {Mode = SecurityMode.None}};
            var factory = new DuplexChannelFactory<IDatabaseManager>(this, binding, new EndpointAddress(address));
            _proxy = factory.CreateChannel();

            _proxy.SubscribeToTags();
        }

        public void OnAddTag(Tag tag)
        {
            if (listViewTags.InvokeRequired)
            {
                var handler = new MainThreadHandler(OnAddTag);
                BeginInvoke(handler, tag);
                return;
            }

            if (listViewTags.FindItemWithText(tag.Id) != null)
            {
                return;
            }

            var newItem = new ListViewItem(tag.Id) {Tag = tag};
            newItem.SubItems.Add(tag.Description);
            newItem.SubItems.Add(tag.Address);
            listViewTags.Items.Add(newItem);
        }

        public void OnRemoveTag(Tag tag)
        {
            if (listViewTags.InvokeRequired)
            {
                var handler = new MainThreadHandler(OnRemoveTag);
                BeginInvoke(handler, tag);
                return;
            }

            var item = listViewTags.FindItemWithText(tag.Id);
            if (item != null)
            {
                listViewTags.Items.Remove(item);
            }
        }

        public void OnUpdateTag(Tag tag)
        {
            if (listViewTags.InvokeRequired)
            {
                var handler = new MainThreadHandler(OnUpdateTag);
                BeginInvoke(handler, tag);
                return;
            }

            var item = listViewTags.FindItemWithText(tag.Id);
            item.Tag = tag;
            item.SubItems[1].Text = tag.Description;
            item.SubItems[2].Text = tag.Address;
        }

        private void buttonAddTag_Click(object sender, EventArgs e)
        {
            var tagForm = new TagForm(Operation.Add, null);
            tagForm.ShowDialog();
        }

        private void buttonRemoveTag_Click(object sender, EventArgs e)
        {
            if (listViewTags.SelectedItems.Count > 0)
            {
                var item = listViewTags.SelectedItems[0];
                var tagId = item.Text;
                listViewTags.Items.Remove(item);
                _proxy.RemoveTag(tagId);
            }
        }

        private void buttonUpdateTag_Click(object sender, EventArgs e)
        {
            if (listViewTags.SelectedItems.Count > 0)
            {
                var item = listViewTags.SelectedItems[0];
                var tagForm = new TagForm(Operation.Update, item);
                tagForm.ShowDialog();
            }
        }

        private void buttonAddAlarm_Click(object sender, EventArgs e)
        {
            if (listViewTags.SelectedItems.Count > 0)
            {
                var item = listViewTags.SelectedItems[0];
                if ((Tag) item.Tag is InputTag)
                {
                    var alarmForm = new AlarmForm(item);
                    alarmForm.ShowDialog();
                    PopulateAlarms((InputTag) item.Tag);
                }
            }
        }

        private void buttonRemoveAlarm_Click(object sender, EventArgs e)
        {
            if (listViewTags.SelectedItems.Count <= 0 || listViewAlarms.SelectedItems.Count <= 0)
            {
                return;
            }

            var tagItem = listViewTags.SelectedItems[0];
            var alarmItem = listViewAlarms.SelectedItems[0];

            var tag = (Tag) tagItem.Tag;
            var alarm = (Alarm) alarmItem.Tag;
            if (_proxy.RemoveInputTagAlarm(tag.Id, alarm.Id))
            {
                listViewAlarms.Items.Remove(alarmItem);
            }
        }

        private void listViewTags_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewTags.SelectedItems.Count > 0)
            {
                var item = listViewTags.SelectedItems[0];
                var tag = (Tag) item.Tag;

                if (tag is InputTag)
                {
                    PopulateAlarms((InputTag) tag);
                }
                else
                {
                    listViewAlarms.Items.Clear();
                }
            }
        }

        private void PopulateAlarms(InputTag tag)
        {
            listViewAlarms.Items.Clear();
            foreach (var alarm in tag.Alarms)
            {
                var newItem = new ListViewItem(alarm.Id) {Tag = alarm};
                newItem.SubItems.Add(alarm.LowLimit.ToString(CultureInfo.CurrentCulture));
                newItem.SubItems.Add(alarm.HighLimit.ToString(CultureInfo.CurrentCulture));
                listViewAlarms.Items.Add(newItem);
            }
        }

        private void DbForm_FormClosing(object sender, EventArgs e)
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