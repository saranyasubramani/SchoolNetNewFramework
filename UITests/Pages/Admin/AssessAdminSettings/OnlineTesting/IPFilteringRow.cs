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
    /// represents the IPFiltering Grid Row
    /// </summary>
    public class IPFilteringRow : SNGridRow
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="driver">IWebDriver</param>
        /// <param name="gridCssSelector">the grid CSS Selector</param>
        /// <param name="webElement">IWebElement</param>
        /// <param name="index">the index</param>
        /// <param name="type">type of the Row</param>
        /// <param name="columns">the list of columns</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public IPFilteringRow( string gridCssSelector, IWebElement webElement, int index, GridRowType type, List<SNGridColumn> columns, string overrideControlPrefix = null)
            : base( gridCssSelector, webElement, index, type, columns, overrideControlPrefix)
        {
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            Report.Write("Row value: " + Element.GetAttribute("value"));
            NameText = new WebElementWrapper( ByNameText);
            AddressText = new WebElementWrapper( ByAddressText);
            EnabledCheck = new WebElementWrapper( ByEnabledCheck);
            RemoveImage = new WebElementWrapper( ByRemoveImage);

            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                //set the fake text for the row
                //this.FakeText = this.Element.Text;
                this.FakeText = this.Element.GetAttribute("value");
            }
        }

        private By ByNameText { get { return GetColumnTextBoxLocator(IPFilteringColumnNames.Name); } }
        private WebElementWrapper NameText { get; set; }
        private By ByAddressText { get { return GetColumnTextBoxLocator(IPFilteringColumnNames.Address); } }
        private WebElementWrapper AddressText { get; set; }
        private By ByEnabledCheck { get { return GetColumnCheckBoxLocator(IPFilteringColumnNames.Enabled); } }
        private WebElementWrapper EnabledCheck { get; set; }
        private By ByRemoveImage { get { return GetColumnImageInputLocator(IPFilteringColumnNames.Remove); } }
        private WebElementWrapper RemoveImage { get; set; }

        protected override By GetColumnTextBoxLocator(string columnName)
        {
            By by = null;
            foreach (var column in Columns)
            {
                if (column.Name.Equals(columnName))
                {
                    string tag = "td";
                    by = By.CssSelector(gridCssSelector + " tr:nth-of-type(" + Index + ") > " + tag + ":nth-of-type(" + (column.Index + 1) + ") input[type='text']");
                    break;
                }
            }
            return by;
        }
        protected override By GetColumnCheckBoxLocator(string columnName)
        {
            By by = null;
            foreach (var column in Columns)
            {
                if (column.Name.Equals(columnName))
                {
                    string tag = "td";
                    by = By.CssSelector(gridCssSelector + " tr:nth-of-type(" + Index + ") > " + tag + ":nth-of-type(" + (column.Index + 1) + ") input[type='checkbox']");
                    break;
                }
            }
            return by;
        }
        protected override By GetColumnImageInputLocator(string columnName)
        {
            By by = null;
            foreach (var column in Columns)
            {
                if (column.Name.Equals(columnName))
                {
                    string tag = "td";
                    by = By.CssSelector(gridCssSelector + " tr:nth-of-type(" + Index + ") > " + tag + ":nth-of-type(" + (column.Index + 1) + ") input[type='image']");
                    break;
                }
            }
            return by;
        }

        /// <summary>
        /// Gets the Name
        /// </summary>
        /// <returns>name</returns>
        public string GetName()
        {
            NameText.Wait(2);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                NameText.Text = FakeText;
            }
            return NameText.Text.Trim();
        }
        /// <summary>
        /// Gets the Name
        /// </summary>
        /// <returns>name</returns>
        public string GetNameAttributeValue()
        {
            NameText.Wait(2);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                NameText.FakeAttributeValue = FakeText;
            }
            return NameText.GetAttribute("value").Trim();
        }

        /// <summary>
        /// Sets the Name
        /// </summary>
        /// <param name="name">the name</param>
        public void SetName(string name)
        {
            NameText.Wait(2).Clear();
            NameText.Wait(2).SendKeys(name);
        }

        /// <summary>
        /// Gets the Address
        /// </summary>
        /// <returns>address</returns>
        public string GetAddress()
        {
            AddressText.Wait(2);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                AddressText.Text = FakeText;
            }
            return AddressText.Text.Trim();
        }
        /// <summary>
        /// Gets the Address
        /// </summary>
        /// <returns>address</returns>
        public string GetAddressAttributeValue()
        {
            AddressText.Wait(2);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                AddressText.FakeAttributeValue = FakeText;
            }
            return AddressText.GetAttribute("value").Trim();
        }

        /// <summary>
        /// Sets the Address
        /// </summary>
        /// <param name="address">the address</param>
        public void SetAddress(string address)
        {
            AddressText.Wait(2).Clear();
            AddressText.Wait(2).SendKeys(address);
        }

        /// <summary>
        /// Select the Enabled check box
        /// </summary>
        public void SelectEnable()
        {
            EnabledCheck.Wait(3).Check();
        }

        /// <summary>
        /// Deselect the Enabled check box
        /// </summary>
        public void SelectDisable()
        {
            EnabledCheck.Wait(3).UnCheck();
        }

        /// <summary>
        /// Select the remove icon
        /// </summary>
        public void SelectRemove()
        {
            RemoveImage.Wait(3).Click();
        }
    }
}
