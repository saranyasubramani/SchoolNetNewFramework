using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Views;
using UITests.Pages.Login.Components;

namespace UITests.Pages.UserManagement
{
    /// <summary>
    /// Edit Role Membership page
    /// </summary>
    public class EditRoleMembershipPage : SNWebPage
    {
        /// <summary>
        /// constructor
        /// </summary>
        public EditRoleMembershipPage()
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            this.ExpectedUrl = "/Directory/EditRoleMembership.aspx";
            this.VerifyCurrentUrl();
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
