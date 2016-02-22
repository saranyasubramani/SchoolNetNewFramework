using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Views;
using UITests.Pages.Admin.GeneralSettings.Config;

namespace UITests.Pages.Admin.GeneralSettings
{
    /// <summary>
    /// Config page
    /// </summary>
    public class ConfigPage : SNWebPage
    {
        /// <summary>
        /// constructor
        /// </summary>
        public ConfigPage()
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            //https://team-automation-st.sndev.net/admin/?&admin_current_app_tab_id=b4031e36-ac70-434d-b26b-f74fcbe5db78&admin_current_control_src=~/Admin/Controls/ConfigEditorControl.ascx&snidx=1
            this.ExpectedUrl = "/admin/";
            this.VerifyCurrentUrl();
            this.VerifyCurrentUrlQueryStringParameters("/Admin/Controls/ConfigEditorControl.ascx");
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            this.Form = new ConfigForm();
            this.Form.Parent = this;
        }
        /// <summary>
        /// the form
        /// </summary>
        public new ConfigForm Form { get; set; }

        /// <summary>
        /// the data
        /// </summary>
        public new ConfigData Data
        {
            get
            {
                return (ConfigData)base.Data;
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
        public new ConfigData InitData()
        {
            base.InitData(new ConfigData());
            return (ConfigData)base.Data;
        }
        /// <summary>
        /// initializes the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>object data</returns>
        public ConfigData InitData(object data)
        {
            base.InitData(data);
            return (ConfigData)base.Data;
        }
    }
}
