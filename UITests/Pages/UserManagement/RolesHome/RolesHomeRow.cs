using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Core.Tools.WebDriver;
using Core.Views.Grids;
using UITests.Pages.Components;

namespace UITests.Pages.UserManagement.RolesHome
{
    /// <summary>
    /// represents the RolesHome Grid Row
    /// </summary>
    public class RolesHomeRow : SNGridRow
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="gridCssSelector">the grid CSS Selector</param>
        /// <param name="webElement">IWebElement</param>
        /// <param name="index">the index</param>
        /// <param name="type">type of the Row</param>
        /// <param name="columns">the list of columns</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public RolesHomeRow(string gridCssSelector, IWebElement webElement, int index, GridRowType type, List<SNGridColumn> columns, string overrideControlPrefix = null)
            : base(gridCssSelector, webElement, index, type, columns, overrideControlPrefix)
        {
        }

        public override void InitElements()
        {
            Report.Write("Row text: " + Element.Text);
            AddNewRoleLink = new WebElementWrapper(ByAddNewRoleLink);
            RoleName = new WebElementWrapper(ByRoleName);
            Description = new WebElementWrapper(ByDescription);
            OperationTemplates = new WebElementWrapper(ByOperationTemplates);
            EditRoleLink = new WebElementWrapper(ByEditRoleLink);
            EditRoleMembershipLink = new WebElementWrapper(ByEditRoleMembershipLink);

            if (Driver.GetType() == typeof(DummyDriver))
            {
                //set the fake text for the row
                this.FakeText = this.Element.Text;
            }
        }

        private By ByAddNewRoleLink { get { return GetColumnLinkLocator(RolesHomeColumnnNames.EditRole); } }
        private WebElementWrapper AddNewRoleLink { get; set; }
        private By ByRoleName { get { return GetColumnLocator(RolesHomeColumnnNames.RoleName); } }
        private WebElementWrapper RoleName { get; set; }
        private By ByDescription { get { return GetColumnLocator(RolesHomeColumnnNames.Description); } }
        private WebElementWrapper Description { get; set; }
        private By ByOperationTemplates { get { return GetColumnLocator(RolesHomeColumnnNames.OperationTemplates); } }
        private WebElementWrapper OperationTemplates { get; set; }
        //document.querySelectorAll("#ctl00_MainContent_RoleManagerControl_DataGridRoles tr:nth-of-type(2) > td:nth-of-type(1) a:nth-of-type(1)");
        private By ByEditRoleLink { get { return By.CssSelector(gridCssSelector + " tr:nth-of-type(" + (Index + 1) + ") > td:nth-of-type(1) a:nth-of-type(1)"); } }
        private WebElementWrapper EditRoleLink { get; set; }
        //document.querySelectorAll("#ctl00_MainContent_RoleManagerControl_DataGridRoles tr:nth-of-type(2) > td:nth-of-type(1) a:nth-of-type(2)");
        private By ByEditRoleMembershipLink { get { return By.CssSelector(gridCssSelector + " tr:nth-of-type(" + (Index + 1) + ") > td:nth-of-type(1) a:nth-of-type(2)"); } }
        private WebElementWrapper EditRoleMembershipLink { get; set; }

        /// <summary>
        /// Select the Add New Role link
        /// </summary>
        /// <returns>EditRolePage</returns>
        public EditRolePage SelectAddNewRole()
        {
            AddNewRoleLink.Wait(3).Click();
            return new EditRolePage();
        }

        /// <summary>
        /// Gets the RoleName
        /// </summary>
        /// <returns>text</returns>
        public string GetRoleName()
        {
            RoleName.Wait(2);
            if (Driver.GetType() == typeof(DummyDriver))
            {
                RoleName.Text = FakeText;
            }
            return RoleName.Text.Trim();
        }

        /// <summary>
        /// Gets the Description
        /// </summary>
        /// <returns>text</returns>
        public string GetDescription()
        {
            Description.Wait(2);
            if (Driver.GetType() == typeof(DummyDriver))
            {
                Description.Text = FakeText;
            }
            return Description.Text.Trim();
        }

        /// <summary>
        /// Gets the OperationTemplate
        /// </summary>
        /// <returns>text</returns>
        public string GetOperationTemplates()
        {
            OperationTemplates.Wait(2);
            if (Driver.GetType() == typeof(DummyDriver))
            {
                OperationTemplates.Text = FakeText;
            }
            return OperationTemplates.Text.Trim();
        }

        /// <summary>
        /// Select the EditRole link
        /// </summary>
        /// <returns>EditRolePage</returns>
        public EditRolePage SelectEditRole()
        {
            EditRoleLink.Wait(3).Click();
            return new EditRolePage();
        }

        /// <summary>
        /// Select the EditRoleMembership link
        /// </summary>
        /// <returns>EditRoleMembershipPage</returns>
        public EditRoleMembershipPage SelectEditRoleMembership()
        {
            EditRoleMembershipLink.Wait(3).Click();
            return new EditRoleMembershipPage();
        }
    }
}
