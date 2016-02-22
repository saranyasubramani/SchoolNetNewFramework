using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITests.Pages.Admin.AssessAdminSettings.ItemProperties;
using System.Reflection;
using Core.Views;

namespace UITests.Pages.Admin.AssessAdminSettings
{
    /// <summary>
    /// item properties page
    /// </summary>
    public class ItemPropertiesPage : SNWebPage
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public ItemPropertiesPage()
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            //https://team-automation-st.sndev.net/admin/?&admin_current_app_tab_id=5e10edea-eb8b-4000-b8cd-91a9ec533c89&admin_current_control_src=~/Assess/AdminControls/ManageItemCategories.ascx&snidx=5
            this.ExpectedUrl = "/admin/";
            this.VerifyCurrentUrl();
            this.VerifyCurrentUrlQueryStringParameters("/Assess/AdminControls/ManageItemCategories.ascx");
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            this.Form = new ItemPropertiesForm();
            this.Form.Parent = this;
        }
        /// <summary>
        /// the form
        /// </summary>
        public new ItemPropertiesForm Form { get; set; }
    }
}
