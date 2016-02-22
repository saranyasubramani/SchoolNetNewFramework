using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Core.Tools.WebDriver;
using UITests.Pages.Components;

namespace UITests.Pages.UserManagement.RolesHome
{
    /// <summary>
    /// represents the RolesHome Grid Column
    /// </summary>
    public class RolesHomeColumn : SNGridColumn
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="gridCssSelector">the grid CSS Selector</param>
        /// <param name="webElement">IWebElement</param>
        /// <param name="index">the index</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public RolesHomeColumn(string gridCssSelector, IWebElement webElement, int index, string overrideControlPrefix = null)
            : base(gridCssSelector, webElement, index, overrideControlPrefix)
        {
        }

        /// <summary>
        /// Sets the Column Name
        /// </summary>
        protected override void SetColumnName()
        {
            string content = Element.Text;
            Report.Write("Column text: " + content);

            if (content.Contains("Role Name"))
            {
                Name = RolesHomeColumnnNames.RoleName;
            }
            else if (content.Contains("Description"))
            {
                Name = RolesHomeColumnnNames.Description;
            }
            else if (content.Contains("Operation Templates"))
            {
                Name = RolesHomeColumnnNames.OperationTemplates;
            }
            else if (content.Equals(""))
            {
                Name = RolesHomeColumnnNames.EditRole;
            }
            else
            {
                throw new Exception("The column was not found within the column content: '" + content + "'.");
            }
        }
    }
}
