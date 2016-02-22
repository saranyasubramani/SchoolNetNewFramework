using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Views;

namespace UITests.Pages.Admin.AssessAdminSettings
{
    /// <summary>
    /// design page
    /// </summary>
    public class DesignPage : SNWebPage
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public DesignPage()
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            //https://team-automation-st.sndev.net/admin/?&admin_current_app_tab_id=b4031e36-ac70-434d-b26b-f74fcbe5db78&admin_current_control_src=~/Admin/Controls/DesignManagerControl.ascx&snidx=1
            this.ExpectedUrl = "/admin/";
            this.VerifyCurrentUrl();
            this.VerifyCurrentUrlQueryStringParameters("/Admin/Controls/DesignManagerControl.ascx");
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
        }
    }
}