using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Views;
using UITests.Pages.Admin.AssessAdminSettings.OnlineTesting;

namespace UITests.Pages.Admin.AssessAdminSettings
{
    /// <summary>
    /// Online Testing page
    /// </summary>
    public class OnlineTestingPage : SNWebPage
    {
        /// <summary>
        /// constructor
        /// </summary>
        public OnlineTestingPage()
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            //https://team-automation-st.sndev.net/admin/?&admin_current_app_tab_id=5e10edea-eb8b-4000-b8cd-91a9ec533c89&admin_current_control_src=~/Assess/AdminControls/EditOnlineTestSettings.ascx&snidx=5
            this.ExpectedUrl = "/admin/";
            this.VerifyCurrentUrl();
            this.VerifyCurrentUrlQueryStringParameters("/Assess/AdminControls/EditOnlineTestSettings.ascx");
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            this.Form = new OnlineTestingForm( ControlPrefix);
            this.Form.Parent = this;
            IPFilteringForm = new IPFilteringForm( ControlPrefix);
            IPFilteringForm.Parent = this;
        }

        /// <summary>
        /// the form
        /// </summary>
        public new OnlineTestingForm Form { get; private set; }
        /// <summary>
        /// IP Filtering form
        /// </summary>
        public IPFilteringForm IPFilteringForm { get; private set; }

        /// <summary>
        /// the data
        /// </summary>
        public new OnlineTestingData Data
        {
            get
            {
                return (OnlineTestingData)base.Data;
            }
            set
            {
                base.Data = value;
                this.Form.Data = value;
                this.IPFilteringForm.Data = value;
            }
        }
        /// <summary>
        /// intializes the data
        /// </summary>
        /// <returns>object data</returns>
        public new OnlineTestingData InitData()
        {
            base.InitData(new OnlineTestingData());
            return (OnlineTestingData)base.Data;
        }
        /// <summary>
        /// initializes the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>object data</returns>
        public OnlineTestingData InitData(object data)
        {
            base.InitData(data);
            return (OnlineTestingData)base.Data;
        }
    }
}
