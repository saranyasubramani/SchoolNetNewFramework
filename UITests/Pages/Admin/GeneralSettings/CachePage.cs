using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Views;
using UITests.Pages.Admin.GeneralSettings.Cache;

namespace UITests.Pages.Admin.GeneralSettings
{
    /// <summary>
    /// cache page
    /// </summary>
    public class CachePage : SNWebPage
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public CachePage()
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            //https://team-automation-st.sndev.net/admin/?&admin_current_app_tab_id=b4031e36-ac70-434d-b26b-f74fcbe5db78&admin_current_control_src=~/Admin/Controls/CacheManager.ascx&snidx=1
            this.ExpectedUrl = "/admin/";
            this.VerifyCurrentUrl();
            this.VerifyCurrentUrlQueryStringParameters("/Admin/Controls/CacheManager.ascx");
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            this.Form = new CacheForm();
            this.Form.Parent = this;
        }
        /// <summary>
        /// the form
        /// </summary>
        public new CacheForm Form { get; set; }

        /// <summary>
        /// the data
        /// </summary>
        public new CacheData Data
        {
            get
            {
                return (CacheData)base.Data;
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
        public new CacheData InitData()
        {
            base.InitData(new CacheData());
            return (CacheData)base.Data;
        }
        /// <summary>
        /// initializes the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>object data</returns>
        public CacheData InitData(object data)
        {
            base.InitData(data);
            return (CacheData)base.Data;
        }
    }
}
