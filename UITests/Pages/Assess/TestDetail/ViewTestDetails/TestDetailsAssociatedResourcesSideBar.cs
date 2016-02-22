using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;

namespace UITests.Pages.Assess.TestDetail.ViewTestDetails
{
    /// <summary>
    /// the test details: associated resources side bar component
    /// </summary>
    public class TestDetailsAssociatedResourcesSideBar : TestDetailsSideBar
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="driver">IWebDriver</param>
        public TestDetailsAssociatedResourcesSideBar( )
            : base()
        {
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            AssociatedResourcesLink = new WebElementWrapper(ByAssociatedResourcesLink);
            AddNewResourceLink = new WebElementWrapper(ByAddNewResourceLink);
        }

        //the '2h' keeps changing based on conditions, we really need a unique ID added to the page
        //private By ByAssociatedResourcesLink { get { return By.CssSelector(".well .AccordianHeader[headerindex='2h']"); } }
        private By ByAssociatedResourcesLink { get { return By.CssSelector("//div[@class='well']/div[@class='PlainBox']/h5/div[@headerindex][contains(text(),'Associated Resources')]"); } }
        private WebElementWrapper AssociatedResourcesLink { get; set; }
        private By ByAddNewResourceLink { get { return By.Id(ControlPrefix + "TestInfoSidebar1_AddFile"); } }
        private WebElementWrapper AddNewResourceLink { get; set; }


        /// <summary>
        /// expand associated resources
        /// </summary>
        public override void ExpandLink()
        {
            AssociatedResourcesLink.Wait(2);
            AssociatedResourcesLink.FakeAttributeClass = "AccordianClosed";
            if (AssociatedResourcesLink.GetAttribute("class").Trim().ToLower().Contains("accordianclosed"))
            {
                AssociatedResourcesLink.Click();
            }
        }

        /// <summary>
        /// collapse associated resources
        /// </summary>
        public override void CollapseLink()
        {
            AssociatedResourcesLink.Wait(2);
            AssociatedResourcesLink.FakeAttributeClass = "AccordianOpen";
            if (AssociatedResourcesLink.GetAttribute("class").Trim().ToLower().Contains("accordianopen"))
            {
                AssociatedResourcesLink.Click();
            }
        }

        /// <summary>
        /// add new resource
        /// </summary>
        public void AddNewResource()
        {
            AddNewResourceLink.Wait(2).Click();
            //TODO: return AddOnlineResourceFile.aspx
        }
    }
}
