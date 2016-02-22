using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Views;
using UITests.Pages.Admin.AssessAdminSettings.TestProperties;

namespace UITests.Pages.Admin.AssessAdminSettings
{
    /// <summary>
    /// counts page
    /// </summary>
    public class TestPropertiesPage : SNWebPage
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public TestPropertiesPage()
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            //https://team-automation-st.sndev.net/admin/?&admin_current_app_tab_id=5e10edea-eb8b-4000-b8cd-91a9ec533c89&admin_current_control_src=~/Assess/AdminControls/ManageTestCategories.ascx&snidx=5#ctl00_MainContent_ctl00_AdminControl_valNoOfTestItems
            this.ExpectedUrl = "/admin/";
            this.VerifyCurrentUrl();
            this.VerifyCurrentUrlQueryStringParameters("/Assess/AdminControls/ManageTestCategories.ascx");
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            this.Form = new TestPropertiesForm();
            this.Form.Parent = this;
        }
        /// <summary>
        /// the form
        /// </summary>
        public new TestPropertiesForm Form { get; set; }

        /// <summary>
        /// the data
        /// </summary>
        public new TestPropertiesData Data
        {
            get
            {
                return (TestPropertiesData)base.Data;
            }
            set
            {
                base.Data = value;
                this.Form.Data = value;
            }
        }
        /// <summary>
        /// intializes the data
        /// </summary>
        /// <returns>object data</returns>
        public new TestPropertiesData InitData()
        {
            base.InitData(new TestPropertiesData());
            return (TestPropertiesData)base.Data;
        }
        /// <summary>
        /// initializes the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>object data</returns>
        public TestPropertiesData InitData(object data)
        {
            base.InitData(data);
            return (TestPropertiesData)base.Data;
        }
    }
}
