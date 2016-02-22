using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Core.Tools.WebDriver;
using Core.Views.Grids;

namespace UITests.Pages.Admin.GeneralSettings.StudentProfile
{
    /// <summary>
    /// represents the AttendanceGroup Grid Row on the Student Profile Page
    /// </summary>
    public class AttendanceGroupRow : SNGridRow
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
        public AttendanceGroupRow( string gridCssSelector, IWebElement webElement, int index, GridRowType type, List<SNGridColumn> columns, string overrideControlPrefix = null)
            : base( gridCssSelector, webElement, index, type, columns, overrideControlPrefix)
        {
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            Report.Write("Row text: " + Element.Text);
            AttendanceGroupNameText = new WebElementWrapper( ByAttendanceGroupNameText);
            Color = new WebElementWrapper( ByColor);
            Range = new WebElementWrapper( ByRange);
            MinRangeLabel = new WebElementWrapper( ByMinRangeLabel);
            MaxRangeText = new WebElementWrapper( ByMaxRangeText);

            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                //set the fake text for the row
                this.FakeText = this.Element.Text;
                this.FakeAttributeValue = this.Element.GetAttribute("value");
                this.FakeAttributeName = this.Element.GetAttribute("name");
            }
        }

        private By ByAttendanceGroupNameText { get { return GetColumnTextBoxLocator(AttendanceGroupColumnNames.AttendanceGroupName); } }
        private WebElementWrapper AttendanceGroupNameText { get; set; }
        private By ByColor { get { return GetColumnLocator(AttendanceGroupColumnNames.Color); } }
        private WebElementWrapper Color { get; set; }
        private By ByRange { get { return GetColumnLocator(AttendanceGroupColumnNames.Range); } }
        private WebElementWrapper Range { get; set; }
        private By ByMinRangeLabel { get { return GetColumnSpanLocator(AttendanceGroupColumnNames.Range); } }
        private WebElementWrapper MinRangeLabel { get; set; }
        private By ByMaxRangeText { get { return GetColumnTextBoxLocator(AttendanceGroupColumnNames.Range); } }
        private WebElementWrapper MaxRangeText { get; set; }

        protected override By GetColumnTextBoxLocator(string columnName)
        {
            By by = null;
            foreach (var column in Columns)
            {
                if (column.Name.Equals(columnName))
                {
                    string tag = "td";
                    by = By.CssSelector(gridCssSelector + " tr:nth-of-type(" + (Index + 1) + ") > " + tag + ":nth-of-type(" + (column.Index + 1) + ") input[type='text']");
                    break;
                }
            }
            return by;
        }

        //document.querySelectorAll("#ctl00_MainContent_ctl00_AdminControl_ctrlConfigureStudAttendanceGrp_DataGridMastery tr:nth-of-type(2) > td:nth-of-type(3) span.smallBox");
        private By GetColumnSpanLocator(string columnName)
        {
            By by = null;
            foreach (var column in Columns)
            {
                if (column.Name.Equals(columnName))
                {
                    string tag = "td";
                    by = By.CssSelector(gridCssSelector + " tr:nth-of-type(" + (Index + 1) + ") > " + tag + ":nth-of-type(" + (column.Index + 1) + ") span.smallBox");
                    break;
                }
            }
            return by;
        }

        /// <summary>
        /// Gets the attendance group name
        /// </summary>
        /// <returns>text</returns>
        public string GetAttendanceGroupName()
        {
            AttendanceGroupNameText.Wait(5);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                AttendanceGroupNameText.FakeAttributeValue = FakeAttributeValue;
            }
            return AttendanceGroupNameText.GetAttribute("value").Trim();
        }

        /// <summary>
        /// Sets the attendance group name
        /// </summary>
        /// <param name="name">the name</param>
        public void SetAttendanceGroupName(string name)
        {
            AttendanceGroupNameText.Wait(5).Clear();
            AttendanceGroupNameText.Wait(5).SendKeys(name);
        }

        /// <summary>
        /// Gets the color
        /// </summary>
        /// <returns>text</returns>
        public string GetColor()
        {
            Color.Wait(5);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                Color.Text = FakeText;
            }
            return Color.Text.Trim();
        }

        /// <summary>
        /// Gets the range
        /// </summary>
        /// <returns>text</returns>
        public string GetRange()
        {
            Range.Wait(5);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                Range.Text = FakeText;
            }
            return Range.Text.Trim();
        }

        /// <summary>
        /// Gets the min range
        /// </summary>
        /// <returns>text</returns>
        public string GetMinRange()
        {
            MinRangeLabel.Wait(5);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                MinRangeLabel.Text = FakeText;
            }
            return MinRangeLabel.Text.Trim();
        }

        /// <summary>
        /// Gets the max range
        /// </summary>
        /// <returns>text</returns>
        public string GetMaxRange()
        {
            MaxRangeText.Wait(5);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                MaxRangeText.FakeAttributeValue = FakeAttributeName;
            }
            return MaxRangeText.GetAttribute("value").Trim();
        }

        /// <summary>
        /// Sets the max range
        /// </summary>
        /// <param name="name">the maxRange</param>
        public void SetMaxRange(int maxRange)
        {
            MaxRangeText.Wait(5).Clear();
            MaxRangeText.Wait(5).SendKeys(Convert.ToString(maxRange));
        }
    }
}
