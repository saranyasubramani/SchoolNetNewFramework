using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using UITests.Pages;
using Core.Tools.WebDriver;
using OpenQA.Selenium;

namespace UITests.Pages.UserManagement.RolesHome
{
    /// <summary>
    /// RolesHome detail
    /// </summary>
    public class RolesHomeDetail : SNDetail
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public RolesHomeDetail(string overrideControlPrefix = null)
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
            /* no longer needed - replaced by Grid code
            EmployeeEditRole = new WebElementWrapper(Driver, ByEmployeeEditRole);
            GuestEditRole = new WebElementWrapper(Driver, ByGuestEditRole);
            LeadershipEditRole = new WebElementWrapper(Driver, ByLeadershipEditRole);
            TeacherEditRole = new WebElementWrapper(Driver, ByTeacherEditRole);
            */
            Grid = new RolesHomeGrid(gridCssSelector, true, this.ControlPrefix);
        }

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
            }
        }

        private string gridCssSelector { get { return "#" + ControlPrefix + "RoleManagerControl_DataGridRoles"; } }
        /// <summary>
        /// the grid
        /// </summary>
        public RolesHomeGrid Grid { get; private set; }

        /* no longer needed - replaced by Grid code
        private By ByEmployeeEditRole { get { return By.Id(ControlPrefix + "RoleManagerControl_DataGridRoles_ctl02_HyperLink1"); } }
        private WebElementWrapper EmployeeEditRole { get; set; }
        private By ByGuestEditRole { get { return By.Id(ControlPrefix + "RoleManagerControl_DataGridRoles_ctl03_HyperLink1"); } }
        private WebElementWrapper GuestEditRole { get; set; }
        private By ByLeadershipEditRole { get { return By.Id(ControlPrefix + "RoleManagerControl_DataGridRoles_ctl04_HyperLink1"); } }
        private WebElementWrapper LeadershipEditRole { get; set; }
        private By ByTeacherEditRole { get { return By.Id(ControlPrefix + "RoleManagerControl_DataGridRoles_ctl09_HyperLink1"); } }
        private WebElementWrapper TeacherEditRole { get; set; }
        */

        /// <summary>
        /// find grid row by role name
        /// </summary>
        /// <returns>RolesHomeRow</returns>
        public RolesHomeRow FindRowByRoleName()
        {
            return this.Grid.GetsFirstRowContainingTextToFindFromList(RolesHomeColumnnNames.RoleName, Data.RoleName);
        }
        /// <summary>
        /// find grid row by role description
        /// </summary>
        /// <returns>RolesHomeRow</returns>
        public RolesHomeRow FindRowByRoleDescription()
        {
            return this.Grid.GetsFirstRowContainingTextToFindFromList(RolesHomeColumnnNames.Description, Data.Description);
        }
        /// <summary>
        /// find grid row by role operation
        /// </summary>
        /// <returns>RolesHomeRow</returns>
        public RolesHomeRow FindRowByRoleOperationTemplates()
        {
            return this.Grid.GetsFirstRowContainingTextToFindFromList(RolesHomeColumnnNames.OperationTemplates, Data.OperationTemplate);
        }

        /// <summary>
        /// verify role description exists by role name
        /// </summary>
        public void VerifyDescriptionExistsByRoleName()
        {
            RolesHomeRow rolesHomeRow = FindRowByRoleName();
            string description = rolesHomeRow.GetDescription();
            Assert.IsTrue(description.Trim().Contains(Data.Description),
                "The expected description: '" + Data.Description + "' is missing from the actual description: '" + description + "'.");
        }
        /// <summary>
        /// verify role operation exists by role name
        /// </summary>
        public void VerifyOperationExistsByRoleName()
        {
            RolesHomeRow rolesHomeRow = FindRowByRoleName();
            string operations = rolesHomeRow.GetOperationTemplates();
            Assert.IsTrue(operations.Trim().Contains(Data.OperationTemplate),
                "The expected operation: '" + Data.OperationTemplate + "' is missing from the actual operations: '" + operations + "'.");
        }

        /// <summary>
        /// verify role description does not exist or was removed by role name
        /// </summary>
        public void VerifyDescriptionRemovedByRoleName()
        {
            RolesHomeRow rolesHomeRow = FindRowByRoleName();
            string description = rolesHomeRow.GetDescription();
            Assert.IsFalse(description.Trim().Contains(Data.Description),
                "The expected description: '" + Data.Description + "' is displayed in the actual description: '" + description + "'.");
        }
        /// <summary>
        /// verify role operation does not exist or was removed by role name
        /// </summary>
        public void VerifyOperationRemovedByRoleName()
        {
            RolesHomeRow rolesHomeRow = FindRowByRoleName();
            string operations = rolesHomeRow.GetOperationTemplates();
            Assert.IsFalse(operations.Trim().Contains(Data.OperationTemplate),
                "The expected operation: '" + Data.OperationTemplate + "' is displayed is the actual operations: '" + operations + "'.");
        }

        /// <summary>
        /// edit role by role name
        /// </summary>
        /// <returns>EditRolePage</returns>
        public EditRolePage EditRoleRowByRoleName()
        {
            RolesHomeRow rolesHomeRow = FindRowByRoleName();
            EditRolePage editRolePage = rolesHomeRow.SelectEditRole();
            return editRolePage;
        }
        /// <summary>
        /// edit role by role description
        /// </summary>
        /// <returns>EditRolePage</returns>
        public EditRolePage EditRoleRowByRoleDescription()
        {
            RolesHomeRow rolesHomeRow = FindRowByRoleDescription();
            EditRolePage editRolePage = rolesHomeRow.SelectEditRole();
            return editRolePage;
        }
        /// <summary>
        /// edit role by role operation
        /// </summary>
        /// <returns>EditRolePage</returns>
        public EditRolePage EditRoleRowByOperationTemplates()
        {
            RolesHomeRow rolesHomeRow = FindRowByRoleOperationTemplates();
            EditRolePage editRolePage = rolesHomeRow.SelectEditRole();
            return editRolePage;
        }

        /// <summary>
        /// edit role membership by role name
        /// </summary>
        /// <returns>EditRoleMembershipPage</returns>
        public EditRoleMembershipPage EditRoleMembershipRowByRoleName()
        {
            RolesHomeRow rolesHomeRow = FindRowByRoleName();
            EditRoleMembershipPage editRoleMembershipPage = rolesHomeRow.SelectEditRoleMembership();
            return editRoleMembershipPage;
        }
        /// <summary>
        /// edit role membership by role description
        /// </summary>
        /// <returns>EditRoleMembershipPage</returns>
        public EditRoleMembershipPage EditRoleMembershipRowByRoleDescription()
        {
            RolesHomeRow rolesHomeRow = FindRowByRoleDescription();
            EditRoleMembershipPage editRoleMembershipPage = rolesHomeRow.SelectEditRoleMembership();
            return editRoleMembershipPage;
        }
        /// <summary>
        /// edit role membership by role operation
        /// </summary>
        /// <returns>EditRoleMembershipPage</returns>
        public EditRoleMembershipPage EditRoleMembershipRowByOperationTemplates()
        {
            RolesHomeRow rolesHomeRow = FindRowByRoleOperationTemplates();
            EditRoleMembershipPage editRoleMembershipPage = rolesHomeRow.SelectEditRoleMembership();
            return editRoleMembershipPage;
        }

        /// <summary>
        /// select edit role for employee
        /// </summary>
        public void SelectEmployeeEditRole()
        {
            Data.RoleName = "Employee";
            EditRoleRowByRoleName();
        }
        /// <summary>
        /// select edit role for guest
        /// </summary>
        public void SelectGuestEditRole()
        {
            Data.RoleName = "Guest";
            EditRoleRowByRoleName();
        }
        /// <summary>
        /// select edit role for leadership
        /// </summary>
        public void SelectLeadershipEditRole()
        {
            Data.RoleName = "Leadership";
            EditRoleRowByRoleName();
        }
        /// <summary>
        /// select edit role for leadership
        /// </summary>
        public void SelectTeacherEditRole()
        {
            Data.RoleName = "Teacher";
            EditRoleRowByRoleName();
        }
    }
}
