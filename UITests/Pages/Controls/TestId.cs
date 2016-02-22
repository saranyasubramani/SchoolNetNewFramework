using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Tools.WebDriver;
using OpenQA.Selenium;
using UITests.Pages.Components;

namespace UITests.Pages.Controls
{
    /// <summary>
    /// Test ID
    /// </summary>
    public class TestId : SNComponent
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="pageName">page names</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public TestId(PageNames pageName, string overrideControlPrefix = null)
            : base()
        {
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }
            switch (pageName)
            {
                case PageNames.AssessDashboard:
                    //ctl00_MainContent_ProfileControl_TestFinderSearchCompressed1_TextBoxTestName
                    name = ControlPrefix + "ProfileControl_TestFinderSearchCompressed1_TextBoxTestName";
                    break;
                case PageNames.CreateTest:
                    //ctl00_MainContent_TextBoxName
                    name = ControlPrefix + "TextBoxName";
                    break;
                case PageNames.CreateTestBySelectingStandardsPage:
                    //ctl00_MainContent_TxtTestName
                    name = ControlPrefix + "TxtTestName";
                    break;
            }
            Name = new WebElementWrapper(ByName);
        }

        private string name { get; set; }
        /// <summary>
        /// name by
        /// </summary>
        public By ByName { get { return By.Id(name); } }
        /// <summary>
        /// name
        /// </summary>
        public WebElementWrapper Name { get; private set; }
        /// <summary>
        /// edit name by
        /// </summary>
        public By ByEditName { get { return By.Id("toggleTestName"); } }
        /// <summary>
        /// edit name
        /// </summary>
        public WebElementWrapper EditName { get; private set; }
        /// <summary>
        /// save name by
        /// </summary>
        public By BySaveName { get { return By.Id("toggleTestName"); } }
        /// <summary>
        /// save name
        /// </summary>
        public WebElementWrapper SaveName { get; private set; }
    }
}
