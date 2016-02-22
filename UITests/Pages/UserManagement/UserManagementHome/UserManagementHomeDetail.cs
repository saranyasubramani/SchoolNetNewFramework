using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using UITests.Pages;
using Core.Tools.WebDriver;
using OpenQA.Selenium;

namespace UITests.Pages.UserManagement.UserManagementHome
{
    /// <summary>
    /// user management home detail
    /// </summary>
    public class UserManagementHomeDetail : SNDetail
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public UserManagementHomeDetail(string overrideControlPrefix = null)
            : base()
        {
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }
            InitElements();
        }
        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            ManageUsers_link = new WebElementWrapper(ByManageUsers_link);
            UserAccoundDistribution_link = new WebElementWrapper(ByUserAccoundDistribution_link);
            BulkUploadUsers_link = new WebElementWrapper(ByBulkUploadUsers_link);
            ApprovePendingUsers_link = new WebElementWrapper(ByApprovePendingUsers_link);
            Roles_link = new WebElementWrapper(ByRoles_link);
            Operations_link = new WebElementWrapper(ByOperations_link);
            SectionAssignmentRequests_link = new WebElementWrapper(BySectionAssignmentRequests_link);
        }

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
            }
        }

        public By ByManageUsers_link { get { return By.Id(ControlPrefix + "HomeControl_UsersLink"); } }
        public WebElementWrapper ManageUsers_link { get; private set; }
        public By ByUserAccoundDistribution_link { get { return By.Id(ControlPrefix + "HomeControl_UserAccountLink"); } }
        public WebElementWrapper UserAccoundDistribution_link { get; private set; }
        public By ByBulkUploadUsers_link { get { return By.Id(ControlPrefix + "HomeControl_BulkUploadLink"); } }
        public WebElementWrapper BulkUploadUsers_link { get; private set; }
        public By ByApprovePendingUsers_link { get { return By.Id(ControlPrefix + "HomeControl_PendingUserLink"); } }
        public WebElementWrapper ApprovePendingUsers_link { get; private set; }
        public By ByRoles_link { get { return By.Id(ControlPrefix + "HomeControl_RolesLink"); } }
        public WebElementWrapper Roles_link { get; private set; }
        public By ByOperations_link { get { return By.Id(ControlPrefix + "HomeControl_OperationsLink"); } }
        public WebElementWrapper Operations_link { get; private set; }
        public By BySectionAssignmentRequests_link { get { return By.Id(ControlPrefix + "HomeControl_SectionApprovalLink"); } }
        public WebElementWrapper SectionAssignmentRequests_link { get; private set; }

        /// <summary>
        /// click roles link
        /// </summary>
        public void ClickRolesLink()
        {
            Roles_link.Click();
        }
        /// <summary>
        /// click user account distribution link
        /// </summary>
        public void ClickUserAccoundDistributionLink()
        {
            UserAccoundDistribution_link.Click();
        }
        /// <summary>
        /// click manage users link
        /// </summary>
        public void ClickManageUsersLink()
        {
            ManageUsers_link.Click();
        }
        /// <summary>
        /// click bulk upload users link
        /// </summary>
        public void ClickBulkUploadUsersLink()
        {
            BulkUploadUsers_link.Click();
        }
        /// <summary>
        /// click approve pending users link
        /// </summary>
        public void ClickApprovePendingUsersLink()
        {
            ApprovePendingUsers_link.Click();
        }
        /// <summary>
        /// click operations link
        /// </summary>
        public void ClickOperationsLink()
        {
            Operations_link.Click();
        }
        /// <summary>
        /// click section assignment requests link
        /// </summary>
        public void ClickSectionAssignmentRequestsLink()
        {
            SectionAssignmentRequests_link.Click();
        }
    }
}
