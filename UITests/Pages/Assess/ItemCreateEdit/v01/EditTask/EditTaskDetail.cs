using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages.Assess.ItemCreateEdit.v01.Components;
using UITests.Pages.Assess.ItemCreateEdit.v01.ItemForms;

namespace UITests.Pages.Assess.ItemCreateEdit.v01.EditTask
{
    public class EditTaskDetail : SNDetail
    {
        /// <summary>
        /// the edit question form constructor
        /// </summary>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public EditTaskDetail(string overrideControlPrefix = null)
            : base()
        {
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }
            InitElements();
        }
        public override void InitElements()
        {
            DeleteActivityButton = new WebElementWrapper(ByDeleteActivityButton);
        }

        /// <summary>
        /// the data
        /// </summary>
        public new EditPageData Data
        {
            get
            {
                return (EditPageData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        /// <summary>
        /// list of item form types
        /// </summary>
        public List<ItemTypeForm> ItemList { get; set; }

        private By ByDeleteActivityButton { get { return By.Id(ControlPrefix + "ButtonDelete"); } }
        private WebElementWrapper DeleteActivityButton { get; set; }

        /// <summary>
        /// delete item
        /// </summary>
        public void DeleteItem()
        {
            ((SNWebPage)this.Parent).CurrentWindowHandle = Driver.CurrentWindowHandle;
            Report.Write("The current window is: '" + ((SNWebPage)this.Parent).CurrentWindowHandle + "'.");

            DeleteActivityButton.Wait(5).Click();
            IAlert alert = Driver.SwitchTo().Alert();
            string expected = "Are you sure you wish to delete this item?";
            if (Driver.GetType() == typeof(DummyDriver))
            {
                ((DummyIAlert)alert).Text = expected;
            }
            string actual = alert.Text;
            Report.Write("The alert text: '" + actual + "'.");
            Assert.IsTrue(actual.Contains(expected), "The delete confirmation pop-up does not contain the expected text: '" + expected + "'; actual text: '" + actual + "'.");
            alert.Accept();

            //switch to window
            DriverCommands.WaitToSwitchWindow(((SNWebPage)this.Parent).CurrentWindowHandle, 5);
            DriverCommands.WaitAndMeasurePageLoadTime();
            ((EditQuestionCreateNewItemPage)Parent).SetRibbonBarItems();
        }
    }
}
