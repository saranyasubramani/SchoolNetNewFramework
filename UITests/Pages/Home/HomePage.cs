using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Views;
using Core.Tools.WebDriver;
using UITests.Pages;
using UITests.Pages.Home.Components;

namespace UITests.Pages.Home
{
    /// <summary>
    /// home page
    /// </summary>
    public class HomePage : SNWebPage
    {
        /// <summary>
        /// constructor
        /// </summary>
        public HomePage() : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            this.ExpectedUrl = "/myschoolnet/";
            this.VerifyCurrentUrl();
            InitElements();
        }
        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            this.Detail = new HomeDetail();
            this.Detail.Parent = this;
        }
        /// <summary>
        /// the detail
        /// </summary>
        public new HomeDetail Detail { get; private set; }

        /// <summary>
        /// go to the home page
        /// </summary>
        public void GoHome()
        {
            //initially wait for the page to load, so a previous post will not fail
            this.DriverCommands.WaitAndMeasurePageLoadTime();
            string baseUrl = "";
            //is this a mock driver for debugging?
            if (this.Driver.GetType() == typeof(DummyDriver))
            {
                //stub the URL
                baseUrl = this.Driver.Url;
            }
            if (this.Driver.GetType() == typeof(DriverWrapper))
            {
                baseUrl = this.Driver.Url;
            }
            string expectedUrl = "/myschoolnet";
            this.PrintName();
            Report.Write("Loading a new page at URL: " + baseUrl + expectedUrl);
            Driver.Navigate().GoToUrl(baseUrl + expectedUrl);
            this.DriverCommands.WaitAndMeasurePageLoadTime();
            string actualUrl = this.Driver.Url;
            Report.Write("Verifying the actual URL: '" + actualUrl + "' contains the expected URL: '" + expectedUrl + "'.");
            //perform verification test
            Assert.IsTrue(actualUrl.ToLower().Contains(expectedUrl.ToLower()),
                    "The actual page URL: '" + actualUrl + "' does not contain the expected page URL: '" + expectedUrl + "'.");
            Report.Write("Verified the actual URL: '" + actualUrl + "' contains the expected URL: '" + expectedUrl + "'.");
        }

        /// <summary>
        /// log out
        /// </summary>
        public void Logout()
        {
            GoHome();
            this.Header.Logout();
        }
    }
}
