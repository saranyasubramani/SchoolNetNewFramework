using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Core.Views.Grids;
using Core.Framework;
using Core.Tools.WebDriver;

namespace UITests.Pages
{
    /// <summary>
    /// The grid row component
    /// </summary>
    public class SNGridRow : GridRow
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="gridCssSelector">the grid CSS Selector</param>
        /// <param name="webElement">IWebElement</param>
        /// <param name="index">the index</param>
        /// <param name="columns">the list of columns</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public SNGridRow(string gridCssSelector, IWebElement webElement, int index, GridRowType type, List<SNGridColumn> columns, string overrideControlPrefix = null)
            : base()
        {
            DriverCommands = new SNDriverCommands();
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }
            this.gridCssSelector = gridCssSelector;
            Element = webElement;
            Index = index;
            Type = type;
            Columns = columns;
            Report.Write("GridRow Index: " + Index + ", Type: " + Type);
            InitElements();
        }

        public override void InitElements()
        {
            TestNameElement = new WebElementWrapper(ByTestNameElement);
            ActionsButton = new WebElementWrapper(ByActionsButton);
        }

        protected new SNDriverCommands DriverCommands { get; set; }

        protected string gridCssSelector { get; set; }
        /// <summary>
        /// IWebElement
        /// </summary>
        public IWebElement Element { get; private set; }
        /// <summary>
        /// the row's index
        /// </summary>
        public int Index { get; private set; }
        /// <summary>
        /// the row's type
        /// </summary>
        public GridRowType Type { get; private set; }
        /// <summary>
        /// the list of columns
        /// </summary>
        public List<SNGridColumn> Columns { get; set; }
        /// <summary>
        /// fake text
        /// </summary>
        public string FakeText { get; set; }
        /// <summary>
        /// fake attribute value
        /// </summary>
        public string FakeAttributeValue { get; set; }
        /// <summary>
        /// fake attribute name
        /// </summary>
        public string FakeAttributeName { get; set; }

        private By ByTestNameElement { get { return GetColumnLinkLocator(SNGridColumnNames.TestName); } }
        private WebElementWrapper TestNameElement { get; set; }

        private By ByActionsButton { get { return GetColumnLocator(SNGridColumnNames.Actions); } }
        private WebElementWrapper ActionsButton { get; set; }

        public void SelectColumn(string columnName)
        {
            By by = GetColumnLinkLocator(columnName);
            WebElementWrapper column = new WebElementWrapper(by);
            column.Wait(3).Click();
            this.DriverCommands.WaitAndMeasurePageLoadTime();
        }
        protected virtual By GetColumnLocator(string columnName)
        {
            By by = null;
            foreach (var column in Columns)
            {
                if (column.Name.Equals(columnName))
                {
                    string tag = "td";
                    if (Type.Equals(GridRowType.Header))
                    {
                        tag = "th";
                    }
                    by = By.CssSelector(gridCssSelector + " tr:nth-of-type(" + (Index + 1) + ") > " + tag + ":nth-of-type(" + (column.Index + 1) + ")");
                    break;
                }
            }
            return by;
        }
        protected virtual By GetColumnLinkLocator(string columnName)
        {
            By by = null;
            foreach (var column in Columns)
            {
                if (column.Name.Equals(columnName))
                {
                    string tag = "td";
                    if (Type.Equals(GridRowType.Header))
                    {
                        tag = "th";
                    }
                    by = By.CssSelector(gridCssSelector + " tr:nth-of-type(" + (Index + 1) + ") > " + tag + ":nth-of-type(" + (column.Index + 1) + ") a");
                    break;
                }
            }
            return by;
        }
        protected virtual By GetColumnImageLocator(string columnName)
        {
            By by = null;
            foreach (var column in Columns)
            {
                if (column.Name.Equals(columnName))
                {
                    string tag = "td";
                    if (Type.Equals(GridRowType.Header))
                    {
                        tag = "th";
                    }
                    by = By.CssSelector(gridCssSelector + " tr:nth-of-type(" + (Index + 1) + ") > " + tag + ":nth-of-type(" + (column.Index + 1) + ") img");
                    break;
                }
            }
            return by;
        }
        protected virtual By GetColumnCheckBoxLocator(string columnName)
        {
            By by = null;
            foreach (var column in Columns)
            {
                if (column.Name.Equals(columnName))
                {
                    string tag = "td";
                    if (Type.Equals(GridRowType.Header))
                    {
                        tag = "th";
                    }
                    by = By.CssSelector(gridCssSelector + " tr:nth-of-type(" + (Index + 1) + ") > " + tag + ":nth-of-type(" + (column.Index + 1) + ") input[type='checkbox']");
                    break;
                }
            }
            return by;
        }
        protected virtual By GetColumnRadioLocator(string columnName)
        {
            By by = null;
            foreach (var column in Columns)
            {
                if (column.Name.Equals(columnName))
                {
                    string tag = "td";
                    if (Type.Equals(GridRowType.Header))
                    {
                        tag = "th";
                    }
                    by = By.CssSelector(gridCssSelector + " tr:nth-of-type(" + (Index + 1) + ") > " + tag + ":nth-of-type(" + (column.Index + 1) + ") input[type='radio']");
                    break;
                }
            }
            return by;
        }
        protected virtual By GetColumnTextBoxLocator(string columnName)
        {
            By by = null;
            foreach (var column in Columns)
            {
                if (column.Name.Equals(columnName))
                {
                    string tag = "td";
                    if (Type.Equals(GridRowType.Header))
                    {
                        tag = "th";
                    }
                    by = By.CssSelector(gridCssSelector + " tr:nth-of-type(" + (Index + 1) + ") > " + tag + ":nth-of-type(" + (column.Index + 1) + ") input[type='text']");
                    break;
                }
            }
            return by;
        }
        protected virtual By GetColumnImageInputLocator(string columnName)
        {
            By by = null;
            foreach (var column in Columns)
            {
                if (column.Name.Equals(columnName))
                {
                    string tag = "td";
                    if (Type.Equals(GridRowType.Header))
                    {
                        tag = "th";
                    }
                    by = By.CssSelector(gridCssSelector + " tr:nth-of-type(" + (Index + 1) + ") > " + tag + ":nth-of-type(" + (column.Index + 1) + ") input[type='image']");
                    break;
                }
            }
            return by;
        }

        /// <summary>
        /// select the test name
        /// </summary>
        public void SelectTestName()
        {
            TestNameElement.Wait(3).Click();
        }
        /// <summary>
        /// get the test name text
        /// </summary>
        /// <returns>text</returns>
        public string GetTestName()
        {
            TestNameElement.Wait(2);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                TestNameElement.Text = FakeText;
            }
            return TestNameElement.Text;
        }

        /// <summary>
        /// select the Actions
        /// </summary>
        public void SelectActions()
        {
            ActionsButton.Wait(3).Click();
            //pause the script for a second to let the pop-up display
            System.Threading.Thread.Sleep(1000);
        }
        /// <summary>
        /// get the Actions text
        /// </summary>
        /// <returns>text</returns>
        public string GetActions()
        {
            ActionsButton.Wait(2);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                ActionsButton.Text = FakeText;
            }
            return ActionsButton.Text;
        }
    }
}
