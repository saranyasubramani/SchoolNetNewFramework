using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Views;
using UITests.Pages.Admin.GeneralSettings.StudentProfile;

namespace UITests.Pages.Admin.GeneralSettings
{
    /// <summary>
    /// StudentProfile page
    /// </summary>
    public class StudentProfilePage : SNWebPage
    {
        /// <summary>
        /// constructor
        /// </summary>
        public StudentProfilePage()
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            //https://team-automation-st.sndev.net/admin/?&admin_current_app_tab_id=b4031e36-ac70-434d-b26b-f74fcbe5db78&admin_current_control_src=~/Admin/Controls/StudentProfileControl.ascx&snidx=1
            this.ExpectedUrl = "/admin/";
            this.VerifyCurrentUrl();
            this.VerifyCurrentUrlQueryStringParameters("/Admin/Controls/StudentProfileControl.ascx");
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            this.Form = new StudentProfileForm();
            this.Form.Parent = this;
        }
        /// <summary>
        /// the form
        /// </summary>
        public new StudentProfileForm Form { get; set; }

        /// <summary>
        /// the data
        /// </summary>
        public new StudentProfileData Data
        {
            get
            {
                return (StudentProfileData)base.Data;
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
        public new StudentProfileData InitData()
        {
            base.InitData(new StudentProfileData());
            return (StudentProfileData)base.Data;
        }
        /// <summary>
        /// initializes the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>object data</returns>
        public StudentProfileData InitData(object data)
        {
            base.InitData(data);
            return (StudentProfileData)base.Data;
        }

    }
}
