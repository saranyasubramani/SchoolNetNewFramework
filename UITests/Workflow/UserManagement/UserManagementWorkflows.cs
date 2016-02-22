using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITests.Pages;
using UITests.Pages.Home;
using UITests.Pages.UserManagement;
using UITests.Workflow;

namespace UITests.Workflow.UserManagement
{
    /// <summary>
    /// the UserManagementment workflows
    /// </summary>
    public class UserManagementWorkflows : SNComponent
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="workflows">workflows</param>
        public UserManagementWorkflows(Workflows workflows)
            : base()
        {
            this.Workflows = workflows;
            RolesWorkflows = new RolesWorkflows(this);
        }
        //workflows
        /// <summary>
        /// Workflows
        /// </summary>
        public Workflows Workflows { get; set; }
        /// <summary>
        /// RolesWorkflows
        /// </summary>
        public RolesWorkflows RolesWorkflows { get; set; }

        //pages
        /// <summary>
        /// UserManagementHomePage
        /// </summary>
        public UserManagementHomePage UserManagementHomePage { get; set; }
        /// <summary>
        /// RolesHomePage
        /// </summary>
        public RolesHomePage RolesHomePage { get; set; }
        /// <summary>
        /// EditRolePage
        /// </summary>
        public EditRolePage EditRolePage { get; set; }

        /// <summary>
        /// navigate to the UserManagement Home page: /Directory/Home.aspx
        /// </summary>
        /// <returns>Workflows</returns>
        public UserManagementWorkflows NavigateToUserManagementPage()
        {
            if (Workflows.HomePage == null)
            {
                throw new Exception("The HomePage is null, please initialize it before trying to use it in a workflow.");
            }
            Workflows.HomePage.Header.UserManagementLink.Click();
            UserManagementHomePage = new UserManagementHomePage();
            return this;
        }

        /// <summary>
        /// At Directory/Home.aspx, click on Roles link
        /// </summary>
        /// <returns>Workflows</returns>
        public UserManagementWorkflows UserManagementPageSelectRoles()
        {
            if (Workflows.HomePage == null)
            {
                throw new Exception("The HomePage is null, please initialize it before trying to use it in a workflow.");
            }
            UserManagementHomePage.Detail.ClickRolesLink();
            RolesHomePage = new RolesHomePage();
            return this;
        }
    }
}
