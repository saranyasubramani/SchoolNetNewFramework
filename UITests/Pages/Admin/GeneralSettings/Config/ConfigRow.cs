using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Core.Tools.WebDriver;
using Core.Views.Grids;

namespace UITests.Pages.Admin.GeneralSettings.Config
{
    /// <summary>
    /// represents the Config Grid Row
    /// </summary>
    public class ConfigRow : SNGridRow
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
        public ConfigRow( string gridCssSelector, IWebElement webElement, int index, GridRowType type, List<SNGridColumn> columns, string overrideControlPrefix = null)
            : base( gridCssSelector, webElement, index, type, columns, overrideControlPrefix)
        {
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            Report.Write("Row text: " + Element.Text);
            AddEditElementLink = new WebElementWrapper( ByAddEditElementLink);
            Name = new WebElementWrapper( ByName);
            Value = new WebElementWrapper( ByValue);
            UpdateLink = new WebElementWrapper( ByUpdateLink);
            CancelLink = new WebElementWrapper( ByCancelLink);
            DeleteLink = new WebElementWrapper( ByDeleteLink);

            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                //set the fake text for the row
                this.FakeText = this.Element.Text;
            }
        }

        private By ByAddEditElementLink { get { return GetColumnLinkLocator(ConfigColumnnNames.AddEditElement); } }
        private WebElementWrapper AddEditElementLink { get; set; }
        private By ByName { get { return GetColumnLocator(ConfigColumnnNames.Name); } }
        private WebElementWrapper Name { get; set; }
        private By ByValue { get { return GetColumnTextBoxLocator(ConfigColumnnNames.Value); } }
        private WebElementWrapper Value { get; set; }
        //document.querySelectorAll("tr:nth-of-type(19) > td:nth-of-type(1) a.CommandButton:nth-of-type(1)");
        private By ByUpdateLink { get { return By.CssSelector(gridCssSelector + " tr:nth-of-type(" + (Index + 1) + ") > td:nth-of-type(1) a.CommandButton:nth-of-type(1)"); } }
        private WebElementWrapper UpdateLink { get; set; }
        private By ByCancelLink { get { return By.CssSelector(gridCssSelector + " tr:nth-of-type(" + (Index + 1) + ") > td:nth-of-type(1) a.CommandButton:nth-of-type(2)"); } }
        private WebElementWrapper CancelLink { get; set; }
        private By ByDeleteLink { get { return By.CssSelector(gridCssSelector + " tr:nth-of-type(" + (Index + 1) + ") > td:nth-of-type(1) a.CommandButton:nth-of-type(3)"); } }
        private WebElementWrapper DeleteLink { get; set; }

        /// <summary>
        /// Select the Add New Element or Edit link
        /// </summary>
        public void SelectAddEditElement()
        {
            AddEditElementLink.Wait(3).Click();
        }

        /// <summary>
        /// Gets the Name
        /// </summary>
        /// <returns>text</returns>
        public string GetName()
        {
            Name.Wait(2);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                Name.Text = FakeText;
            }
            return Name.Text.Trim();
        }

        /// <summary>
        /// Gets the Value
        /// </summary>
        /// <returns>text</returns>
        public string GetValue()
        {
            Value.Wait(2);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                Value.Text = FakeText;
            }
            return Value.Text.Trim();
        }

        /// <summary>
        /// Sets the Value
        /// </summary>
        /// <param name="value">the value</param>
        public void SetValue(string value)
        {
            Value.Wait(2).Clear();
            Value.Wait(2).SendKeys(value);
        }

        /// <summary>
        /// Select the update link
        /// </summary>
        public void SelectUpdate()
        {
            UpdateLink.Wait(3).Click();
        }

        /// <summary>
        /// Select the cancel link
        /// </summary>
        public void SelectCancel()
        {
            CancelLink.Wait(3).Click();
        }

        /// <summary>
        /// Select the update link
        /// </summary>
        public void SelectDelete()
        {
            DeleteLink.Wait(3).Click();
        }
    }
}
