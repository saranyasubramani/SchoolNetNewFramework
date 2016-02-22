using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Views;
using UITests.Pages.Login.Components;
using UITests.Pages.UserManagement.RolesHome;

namespace UITests.Pages.UserManagement
{
    /// <summary>
    /// RolesHome page
    /// </summary>
    public class RolesHomePage : SNWebPage
    {
        /// <summary>
        /// constructor
        /// </summary>
        public RolesHomePage()
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            this.ExpectedUrl = "/Directory/RolesHome.aspx";
            this.VerifyCurrentUrl();
            InitElements();
        }
        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            this.Detail = new RolesHomeDetail(this.ControlPrefix);
            this.Detail.Parent = this;
        }
        /// <summary>
        /// the detail
        /// </summary>
        public new RolesHomeDetail Detail { get; private set; }

        /// <summary>
        /// the data
        /// </summary>
        public new RolesHomeData Data
        {
            get
            {
                return (RolesHomeData)base.Data;
            }
            set
            {
                base.Data = value;
                this.Detail.Data = value;
            }
        }
        /// <summary>
        /// intializes the data
        /// </summary>
        /// <returns>object data</returns>
        public new RolesHomeData InitData()
        {
            base.InitData(new RolesHomeData());
            return (RolesHomeData)base.Data;
        }
        /// <summary>
        /// initializes the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>object data</returns>
        public RolesHomeData InitData(object data)
        {
            base.InitData(data);
            return (RolesHomeData)base.Data;
        }
    }
}
