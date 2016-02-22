using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Core.Tools.WebDriver;
using Core.Views.Grids;

namespace UITests.Pages.Admin.AssessAdminSettings.OnlineTesting
{
    /// <summary>
    /// represents the IPFiltering Grid Column
    /// </summary>
    public class IPFilteringColumn : SNGridColumn
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="gridCssSelector">the grid CSS Selector</param>
        /// <param name="webElement">IWebElement</param>
        /// <param name="index">the index</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public IPFilteringColumn(  string gridCssSelector, IWebElement webElement, int index, string overrideControlPrefix = null)
            : base( gridCssSelector, webElement, index, overrideControlPrefix)
        {
        }

        /// <summary>
        /// Sets the Column Name
        /// </summary>
        protected override void SetColumnName()
        {
            string content = Element.Text;
            Report.Write("Column text: " + content);

            if (content.Contains("Name"))
            {
                Name = IPFilteringColumnNames.Name;
            }
            else if (content.Contains("Address"))
            {
                Name = IPFilteringColumnNames.Address;
            }
            else if (content.Equals("Enabled"))
            {
                Name = IPFilteringColumnNames.Enabled;
            }
            else if (content.Equals("Remove"))
            {
                Name = IPFilteringColumnNames.Remove;
            }
            else
            {
                throw new Exception("The column was not found within the column content: '" + content + "'.");
            }
        }
    }
}
