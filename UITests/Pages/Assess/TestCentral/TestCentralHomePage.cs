using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using OpenQA.Selenium.Firefox;
using Core.Views;
using UITests.Pages.Components;
using UITests.Pages.Assess.TestDetail.Components;
using UITests.Pages.Assess.TestCentral.TestCentralHome;

namespace UITests.Pages.Assess.TestCentral
{
    /// <summary>
    /// the test central home page
    /// </summary>
    public class TestCentralHomePage : SNWebPage
    {
        /// <summary>
        /// constructor
        /// </summary>
        public TestCentralHomePage()
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            this.ExpectedUrl = "/Assess/TestCentralHome.aspx";
            this.VerifyCurrentUrl();
            VerifyPageIsActuallyLoad(); 
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            this.Form = new TestCentralHomeForm();
            this.Form.Parent = this;
            this.Detail = new TestCentralHomeDetail();
            this.Detail.Parent = this;
        }
        /// <summary>
        /// the form
        /// </summary>
        public new TestCentralHomeForm Form { get; set; }
        /// <summary>
        /// the form
        /// </summary>
        public new TestCentralHomeDetail Detail { get; set; }

        /// <summary>
        /// the data
        /// </summary>
        public new TestCentralHomeData Data
        {
            get
            {
                return (TestCentralHomeData)base.Data;
            }
            set
            {
                base.Data = value;
                this.Form.Data = value;
                this.Detail.Data = value;
            }
        }
        /// <summary>
        /// intializes the data
        /// </summary>
        /// <returns>object data</returns>
        public new TestCentralHomeData InitData()
        {
            base.InitData(new TestCentralHomeData());
            return (TestCentralHomeData)base.Data;
        }
        /// <summary>
        /// initializes the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>object data</returns>
        public TestCentralHomeData InitData(object data)
        {
            base.InitData(data);
            return (TestCentralHomeData)base.Data;
        }

        private void VerifyPageIsActuallyLoad()
        {
            // tc 24186, bug 87479
            // Sometimes network is slow and gateway return a blank page. This page will need to be refresh
            try
            {
                Report.Write("Attempting to verified page content is actually loaded. Checking if site title exist.");
                //SiteTitleLabel = new WebElementWrapper(Driver, BySiteTitleLabel);
                //SiteTitleLabel.FindElement(); 
                //Make sure page is actually loaded by clicking on welcome message
                this.Utilities.FocusOnMainContentArea();//Header.SelectWelcomeMessage();
                Report.Write("Page content is loaded successfully. Got Site title.");
            }
            catch (Exception e)
            {
                if (Driver.WrappedDriver.GetType() == typeof(FirefoxDriver))
                {
                    this.CurrentWindowHandle = Driver.CurrentWindowHandle;

                    Report.Write("Page content was not loaded. Attempting to refresh the page again.");
                    Driver.Navigate().Refresh();

                    AlertHandler alert = new AlertHandler();
                    alert.VerifyText("Are you sure you wish to delete this item?");
                    alert.Accept();

                    //switch to window
                    DriverCommands.WaitToSwitchWindow(this.CurrentWindowHandle, 5);
                }//exception was not being thrown for other browsers
                else
                {
                    throw new Exception("\nInnerException:\n" + e.InnerException + "\nStackTrace:\n" + e.StackTrace, e);
                }
            }
        }
    }
}
