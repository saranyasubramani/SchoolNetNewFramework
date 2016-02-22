using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Framework;
using Core.Views;
using Core.Tools.WebDriver;
using OpenQA.Selenium;
using UITests.Pages.Components;

namespace UITests.Pages.Assess.Components
{
    /// <summary>
    /// Answer Choice Layout component.
    /// Especially useful for Multiple Choice Items. 
    /// Determines the display inside the Test Tunnel.
    /// </summary>
    public class AnswerChoiceLayout : SNComponent
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="pageName"></param>
        /// <param name="overrideControlPrefix"></param>
        public AnswerChoiceLayout(PageNames pageName, string overrideControlPrefix = null)
            : base()
        {
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }
            PageName = pageName;
            UserItemSettings = new WebElementWrapper(ByUserItemSettings());
            OneColumn = new WebElementWrapper(ByOneColumn());
            TwoColumnsAcross = new WebElementWrapper(ByTwoColumnsAcross());
            TwoColumnsDown = new WebElementWrapper(ByTwoColumnsDown());
        }

        private PageNames PageName;
        public WebElementWrapper UserItemSettings { get; private set; }
        public WebElementWrapper OneColumn { get; private set; }
        public WebElementWrapper TwoColumnsAcross { get; private set; }
        public WebElementWrapper TwoColumnsDown { get; private set; }

        private By ByUserItemSettings()
        {
            By by = null;
            switch (PageName)
            {
                case PageNames.CreateTest:
                    by = By.Id(ControlPrefix + "RadioButtonListMCOrientation_0");
                    break;
                case PageNames.CreateNewItem:
                    by = By.Id(ControlPrefix + "RadioButtonListMCOrientation_0");
                    break;
                case PageNames.ViewTestDetailsTestProperties:
                    by = By.Id(ControlPrefix + "TestInfoSidebar1_RadioMCOrientation_0");
                    break;
            }
            return by;
        }
        private By ByOneColumn()
        {
            By by = null;
            switch (PageName)
            {
                case PageNames.CreateTest:
                    by = By.Id(ControlPrefix + "RadioButtonListMCOrientation_1");
                    break;
                case PageNames.CreateNewItem:
                    by = By.Id("radioOneColumn");
                    break;
                case PageNames.ViewTestDetailsTestProperties:
                    by = By.Id(ControlPrefix + "TestInfoSidebar1_RadioMCOrientation_1");
                    break;
            }
            return by;
        }
        private By ByTwoColumnsAcross()
        {
            By by = null;
            switch (PageName)
            {
                case PageNames.CreateTest:
                    by = By.Id(ControlPrefix + "RadioButtonListMCOrientation_2");
                    break;
                case PageNames.CreateNewItem:
                    by = By.Id("radioAcross");
                    break;
                case PageNames.ViewTestDetailsTestProperties:
                    by = By.Id(ControlPrefix + "TestInfoSidebar1_RadioMCOrientation_2");
                    break;
            }
            return by;
        }
        private By ByTwoColumnsDown()
        {
            By by = null;
            switch (PageName)
            {
                case PageNames.CreateTest:
                    by = By.Id(ControlPrefix + "RadioButtonListMCOrientation_3");
                    break;
                case PageNames.CreateNewItem:
                    by = By.Id("radioDown");
                    break;
                case PageNames.ViewTestDetailsTestProperties:
                    by = By.Id(ControlPrefix + "TestInfoSidebar1_RadioMCOrientation_3");
                    break;
            }
            return by;
        }
    }
}
