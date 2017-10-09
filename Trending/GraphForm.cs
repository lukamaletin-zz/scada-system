using System;
using System.ServiceModel;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using SCADACommon;
using SCADACommon.Model;
using SCADACommon.Service;

namespace Trending
{
    [CallbackBehavior(UseSynchronizationContext = false)]
    public partial class GraphForm : Form, IGuiCallback
    {
        private readonly ITrending _proxy;
        private readonly Tag _tag;
        private int _xCoord;
        private const string Series = "Graph";

        public GraphForm(Tag tag)
        {
            InitializeComponent();
            var address = new Uri(ScadaConstants.TrendingUri);
            var binding = new NetTcpBinding {Security = {Mode = SecurityMode.None}};
            var factory = new DuplexChannelFactory<ITrending>(this, binding, new EndpointAddress(address));
            _proxy = factory.CreateChannel();

            _proxy.SubscribeToTags();

            _tag = tag;
            chart.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chart.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            chart.Series[Series].ChartType = SeriesChartType.FastLine;
            chart.Series[Series].Points.AddXY(_xCoord++, tag.GetValue());
        }

        public void OnAddTag(Tag tag)
        {
        }

        public void OnRemoveTag(Tag tag)
        {
        }

        public void OnUpdateTag(Tag tag)
        {
            if (chart.InvokeRequired)
            {
                var handler = new MainThreadHandler(OnUpdateTag);
                BeginInvoke(handler, tag);
                return;
            }

            if (tag.Id == _tag.Id)
            {
                chart.Series[Series].Points.AddXY(_xCoord++, tag.GetValue());
            }
        }

        private void GraphForm_FormClosing(object sender, EventArgs e)
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