using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages.Controls;

namespace UITests.Pages.Assess.TestWindow.PlanHome
{
    /// <summary>
    /// the plan home detail
    /// </summary>
    public class PlanHomeDetail : SNDetail
    {
        /// <summary>
        /// the plan home constructor
        /// </summary>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public PlanHomeDetail(string overrideControlPrefix = null)
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
            CreateNewTestWindow = new WebElementWrapper(ByCreateNewTestWindow);
            PreviousPageBottomLink = new PreviousPageBottomLink(PageNames.TestWindowPlanHome, ControlPrefix);
            PlanTitleLabel = new WebElementWrapper(ByPlanTitleLabel);
        }

        /// <summary>
        /// the data
        /// </summary>
        public new PlanHomeData Data
        {
            get
            {
                return (PlanHomeData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        //#ctl00_AppTitle_NewRowToolContainer input.btn
        private By ByCreateNewTestWindow { get { return By.CssSelector("#ctl00_AppTitle_NewRowToolContainer input.btn"); } }
        private WebElementWrapper CreateNewTestWindow { get; set; }
        private By ByPlanTitleLabel { get { return By.Id("ctl00_AppTitle_HeaderTitle"); } }
        private WebElementWrapper PlanTitleLabel { get; set; }
        private PreviousPageBottomLink PreviousPageBottomLink { get; set; }

        /// <summary>
        /// create new test window
        /// </summary>
        /// <returns>CreateEditTestWindowPage</returns>
        public CreateEditTestWindowPage SelectCreateNewTestWindow()
        {
            //Test run sometimes stuck at assessment pop up menu. Click on title to get rid of menu.
            PlanTitleLabel.Click();

            CreateNewTestWindow.Wait(3).Click();
            return new CreateEditTestWindowPage();
        }

        /// <summary>
        /// back to previous page
        /// </summary>
        public void BackToPreviousPage()
        {
            PreviousPageBottomLink.Control.Wait(3).Click();
        }
    }
}
