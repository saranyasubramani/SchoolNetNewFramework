using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Framework;
using Core.Views;
using Core.Tools.WebDriver;
using OpenQA.Selenium;

namespace UITests.Pages
{
    public class SNComponent : BaseApplication
    {
        public SNComponent()
            : base()
        {
            DriverCommands = new SNDriverCommands();
            Utilities = new SNGlobalUtilities();
        }

        protected SNDriverCommands DriverCommands { get; set; }
        protected SNGlobalUtilities Utilities { get; set; }
        public string ControlPrefix = "ctl00_MainContent_";
    }
}
