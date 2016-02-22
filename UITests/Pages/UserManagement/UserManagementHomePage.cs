using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Views;
using UITests.Pages.UserManagement.UserManagementHome;

namespace UITests.Pages.UserManagement
{
    /// <summary>
    /// User Management Home page
    /// </summary>
    public class UserManagementHomePage : SNWebPage
    {
        /// <summary>
        /// constructor
        /// </summary>
        public UserManagementHomePage()
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            this.ExpectedUrl = "/Directory/Home.aspx";
            this.VerifyCurrentUrl();
            InitElements();
        }
        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            Form = new UserManagementHomeForm();
            this.Form.Parent = this;
            Detail = new UserManagementHomeDetail();
            this.Detail.Parent = this;
        }
        /// <summary>
        /// the form
        /// </summary>
        public new UserManagementHomeForm Form { get; set; }
        /// <summary>
        /// the detail
        /// </summary>
        public new UserManagementHomeDetail Detail { get; set; }

        /// <summary>
        /// the data
        /// </summary>
        public new UserManagementHomeData Data
        {
            get
            {
                return (UserManagementHomeData)base.Data;
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
        public UserManagementHomeData InitData()
        {
            base.InitData(new UserManagementHomeData());
            return (UserManagementHomeData)base.Data;
        }
        /// <summary>
        /// initializes the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>object data</returns>
        public UserManagementHomeData InitData(object data)
        {
            base.InitData(data);
            return (UserManagementHomeData)base.Data;
        }
    }
}
