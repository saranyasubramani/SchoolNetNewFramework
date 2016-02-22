using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Views;
using Core.Tools.WebDriver;
using OpenQA.Selenium;
using UITests.Pages.Components;

namespace UITests.Pages
{
    public abstract class SNWebPage : WebPage
    {
        public SNWebPage()
            : base()
        {
            DriverCommands = new SNDriverCommands();
            Utilities = new SNGlobalUtilities();
            Header = new SNHeader();
        }

        protected new SNDriverCommands DriverCommands { get; set; }
        protected SNGlobalUtilities Utilities { get; set; }

        public new SNWebPage Parent { get; set; }

        public new SNHeader Header { get; set; }

        

        public new void WaitForPageToLoad()
        {
            DriverCommands.WaitAndMeasurePageLoadTime(this.TestConfiguration.PageLoadTimeOut, 30);
        }

        public void WaitForSpinnersToVanish()
        {
            DriverCommands.WaitForSpinnersToVanish(30);
        }

    }
}
