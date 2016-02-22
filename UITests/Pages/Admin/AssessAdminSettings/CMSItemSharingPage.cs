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
    /// CMS item sharing page
    /// </summary>
    public class CMSItemSharingPage : SNWebPage
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public CMSItemSharingPage()
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            //https://team-automation-st.sndev.net/admin/?&admin_current_app_tab_id=5e10edea-eb8b-4000-b8cd-91a9ec533c89&admin_current_control_src=~/Assess/AdminControls/EditCMSItemSharing.ascx&snidx=5
            this.ExpectedUrl = "/admin/";
            this.VerifyCurrentUrl();
            this.VerifyCurrentUrlQueryStringParameters("/Assess/AdminControls/EditCMSItemSharing.ascx");
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
