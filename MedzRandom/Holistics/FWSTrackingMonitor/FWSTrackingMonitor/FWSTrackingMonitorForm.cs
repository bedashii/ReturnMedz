using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThirdPartyProcessingGenLib.Lists;

namespace FWSTrackingMonitor
{
    public partial class FWSTrackingMonitorForm : Form
    {
        public FWSTrackingMonitorForm()
        {
            InitializeComponent();
        }

        private ThirdPartyProcessingGenLib.Lists.FWSTrackingList fwsTrackingList;

        private void Form1_Load(object sender, EventArgs e)
        {
            ThirdPartyProcessingGenLib.Data.DataProcessHelper.SetConnection("Data Source=192.168.150.10;Initial Catalog=ThirdpartyProcessing;User=Operator;Password=Operator;Persist Security Info=True;Application Name=FWSTracking Monitor");

            fwsTrackingList = new FWSTrackingList();
            fwsTrackingList.GetByIDGreaterThan(0);

            fWSTrackingListBindingSource.DataSource = fwsTrackingList.OrderByDescending(x => x.ID);
            fWSTrackingListBindingSource.ResetBindings(false);
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            RefreshTracking();
        }

        private void RefreshTracking()
        {
            int maxId = 0;
            fwsTrackingList.ForEach(x =>
                {
                    if (maxId < x.ID)
                        maxId = x.ID;
                });

            ThirdPartyProcessingGenLib.Lists.FWSTrackingList fws = new FWSTrackingList();
            fws.GetByIDGreaterThan(maxId);

            fwsTrackingList.AddRange(fws);

            fWSTrackingListBindingSource.DataSource = fwsTrackingList.OrderByDescending(x => x.ID);
            fWSTrackingListBindingSource.ResetBindings(false);
        }

        private void timerAutoRefreshTimer_Tick(object sender, EventArgs e)
        {
            RefreshTracking();
        }

        private void checkBoxAutoRefresh_CheckedChanged(object sender, EventArgs e)
        {
            timerAutoRefreshTimer.Enabled = checkBoxAutoRefresh.Checked;
        }
    }
}
