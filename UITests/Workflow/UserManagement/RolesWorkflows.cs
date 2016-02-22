using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages;
using UITests.Pages.Home;
using UITests.Pages.UserManagement;
using UITests.Pages.UserManagement.EditRole;
using UITests.Pages.UserManagement.RolesHome;
using UITests.Workflow;

namespace UITests.Workflow.UserManagement
{
    /// <summary>
    /// the Roles workflows
    /// </summary>
    public class RolesWorkflows : SNComponent
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="workflows">workflows</param>
        public RolesWorkflows(UserManagementWorkflows workflows)
            : base()
        {
            UserManagementWorkflows = workflows;
        }

        //workflows
        public UserManagementWorkflows UserManagementWorkflows { get; set; }

        /// <summary>
        /// At /Directory/RolesHome.aspx, click on edit role by role name
        /// </summary>
        /// <returns>Workflows</returns>
        public RolesWorkflows RolesHomePageEditRoleByRoleName()
        {
            if (UserManagementWorkflows.RolesHomePage == null)
            {
                throw new Exception("The RolesHomePage is null, please initialize it before trying to use it in a workflow.");
            }
            if (((RolesHomeData)UserManagementWorkflows.RolesHomePage.Data).RoleName == null)
            {
                throw new Exception("The RolesHomePage.DataObject.RoleName is null, please initialize it before trying to use it in a workflow.");
            }
            UserManagementWorkflows.EditRolePage = UserManagementWorkflows.RolesHomePage.Detail.EditRoleRowByRoleName();
            return this;
        }

        /// <summary>
        /// At /Directory/RolesHome.aspx, click on edit role for leadership
        /// </summary>
        /// <returns>Workflows</returns>
        public RolesWorkflows RolesHomePageEditRoleLeadership()
        {
            if (UserManagementWorkflows.RolesHomePage == null)
            {
                throw new Exception("The RolesHomePage is null, please initialize it before trying to use it in a workflow.");
            }
            UserManagementWorkflows.RolesHomePage.InitData();
            UserManagementWorkflows.RolesHomePage.Data.RoleName = "Leadership";
            RolesHomePageEditRoleByRoleName();
            return this;
        }

        /// <summary>
        /// At /Directory/RolesHome.aspx, click on edit role for teacher
        /// </summary>
        /// <returns>Workflows</returns>
        public RolesWorkflows RolesHomePageEditRoleTeacher()
        {
            if (UserManagementWorkflows.RolesHomePage == null)
            {
                throw new Exception("The RolesHomePage is null, please initialize it before trying to use it in a workflow.");
            }
            UserManagementWorkflows.RolesHomePage.InitData();
            UserManagementWorkflows.RolesHomePage.Data.RoleName = "Teacher";
            RolesHomePageEditRoleByRoleName();
            return this;
        }

        /// <summary>
        /// At /Directory/EditRole.aspx, add an operation to the role
        /// </summary>
        /// <returns>Workflows</returns>
        public RolesWorkflows EditRolePageAddOperation(string operation)
        {
            if (UserManagementWorkflows.EditRolePage == null)
            {
                throw new Exception("The EditRolePage is null, please initialize it before trying to use it in a workflow.");
            }
            UserManagementWorkflows.EditRolePage.InitData();
            UserManagementWorkflows.EditRolePage.Data.OperationToAdd = operation;

            UserManagementWorkflows.EditRolePage.Form.AddOperation();
            //reinitialize the form internally
            //UserManagementWorkflows.EditRolePage = new EditRolePage(Driver);
            return this;
        }

        /// <summary>
        /// At /Directory/EditRole.aspx, remove an operation from the role
        /// </summary>
        /// <returns>Workflows</returns>
        public RolesWorkflows EditRolePageRemoveOperation(string operation)
        {
            if (UserManagementWorkflows.EditRolePage == null)
            {
                throw new Exception("The EditRolePage is null, please initialize it before trying to use it in a workflow.");
            }
            UserManagementWorkflows.EditRolePage.InitData();
            UserManagementWorkflows.EditRolePage.Data.OperationToRemove = operation;

            UserManagementWorkflows.EditRolePage.Form.RemoveOperation();
            //reinitialize the form internally
            //UserManagementWorkflows.EditRolePage = new EditRolePage(Driver);
            return this;
        }

        /// <summary>
        /// At /Directory/EditRole.aspx, add an operation to the role
        /// </summary>
        /// <returns>Workflows</returns>
        public RolesWorkflows EditRolePageAddOperation()
        {
            if (UserManagementWorkflows.EditRolePage == null)
            {
                throw new Exception("The EditRolePage is null, please initialize it before trying to use it in a workflow.");
            }
            if (((EditRoleData)UserManagementWorkflows.EditRolePage.Data).OperationToAdd == null)
            {
                throw new Exception("The EditRolePage.DataObject.OperationToAdd is null, please initialize it before trying to use it in a workflow.");
            }
            UserManagementWorkflows.EditRolePage.Form.AddOperation();
            return this;
        }

        /// <summary>
        /// At /Directory/EditRole.aspx, remove an operation from the role
        /// </summary>
        /// <returns>Workflows</returns>
        public RolesWorkflows EditRolePageRemoveOperation()
        {
            if (UserManagementWorkflows.EditRolePage == null)
            {
                throw new Exception("The EditRolePage is null, please initialize it before trying to use it in a workflow.");
            }
            if (((EditRoleData)UserManagementWorkflows.EditRolePage.Data).OperationToRemove == null)
            {
                throw new Exception("The EditRolePage.DataObject.OperationToRemove is null, please initialize it before trying to use it in a workflow.");
            }
            UserManagementWorkflows.EditRolePage.Form.RemoveOperation();
            return this;
        }

        /// <summary>
        /// At /Directory/EditRole.aspx, click save button
        /// </summary>
        /// <returns>Workflows</returns>
        public RolesWorkflows EditRolePageSubmitForm()
        {
            if (UserManagementWorkflows.EditRolePage == null)
            {
                throw new Exception("The EditRolePage is null, please initialize it before trying to use it in a workflow.");
            }
            UserManagementWorkflows.EditRolePage.Form.SubmitForm();
            UserManagementWorkflows.RolesHomePage = new RolesHomePage();
            return this;
        }

        /// <summary>
        /// At /Directory/EditRole.aspx, verify the operation is included to the role
        /// </summary>
        /// <returns>Workflows</returns>
        public RolesWorkflows EditRolePageVerifyOperationIncluded()
        {
            if (UserManagementWorkflows.EditRolePage == null)
            {
                throw new Exception("The EditRolePage is null, please initialize it before trying to use it in a workflow.");
            }
            if (((EditRoleData)UserManagementWorkflows.EditRolePage.Data).OperationToAdd == null)
            {
                throw new Exception("The EditRolePage.DataObject.OperationToAdd is null, please initialize it before trying to use it in a workflow.");
            }
            UserManagementWorkflows.EditRolePage.Form.VerifyOperationIncluded();
            return this;
        }

        /// <summary>
        /// At /Directory/EditRole.aspx, verify the operation is available to the role
        /// </summary>
        /// <returns>Workflows</returns>
        public RolesWorkflows EditRolePageVerifyOperationAvailable()
        {
            if (UserManagementWorkflows.EditRolePage == null)
            {
                throw new Exception("The EditRolePage is null, please initialize it before trying to use it in a workflow.");
            }
            if (((EditRoleData)UserManagementWorkflows.EditRolePage.Data).OperationToAdd == null)
            {
                throw new Exception("The EditRolePage.DataObject.OperationToAdd is null, please initialize it before trying to use it in a workflow.");
            }
            UserManagementWorkflows.EditRolePage.Form.VerifyOperationAvailable();
            return this;
        }

        /// <summary>
        /// RolesHomePage verify operation exists by role name
        /// </summary>
        /// <returns>Workflows</returns>
        public RolesWorkflows RolesHomePageVerifyOperationExistsByRoleName()
        {
            if (UserManagementWorkflows.RolesHomePage == null)
            {
                throw new Exception("The RolesHomePage is null, please initialize it before trying to use it in a workflow.");
            }
            if (((RolesHomeData)UserManagementWorkflows.RolesHomePage.Data).RoleName == null)
            {
                throw new Exception("The RolesHomePage.DataObject.RoleName is null, please initialize it before trying to use it in a workflow.");
            }
            UserManagementWorkflows.RolesHomePage.Detail.VerifyOperationExistsByRoleName();
            return this;
        }

        /// <summary>
        /// RolesHomePage verify operation exists by role name
        /// </summary>
        /// <returns>Workflows</returns>
        public RolesWorkflows RolesHomePageVerifyOperationRemovedByRoleName()
        {
            if (UserManagementWorkflows.RolesHomePage == null)
            {
                throw new Exception("The RolesHomePage is null, please initialize it before trying to use it in a workflow.");
            }
            if (((RolesHomeData)UserManagementWorkflows.RolesHomePage.Data).RoleName == null)
            {
                throw new Exception("The RolesHomePage.DataObject.RoleName is null, please initialize it before trying to use it in a workflow.");
            }
            UserManagementWorkflows.RolesHomePage.Detail.VerifyOperationRemovedByRoleName();
            return this;
        }
    }
}
