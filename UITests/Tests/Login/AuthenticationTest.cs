using System;
//using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using TestContext = NUnit.Framework.TestContext;
using TestConfiguration = Core.Config.TestConfiguration;
using ApplicationType = Core.Framework.ApplicationType;
using TestGridType = Core.Framework.TestGridType;
using TestToolType = Core.Framework.TestToolType;
using ApplicationName = UITests.Framework.ApplicationName;
using TestRunner = UITests.Framework.TestRunner;
using DriverCommands = Core.Tools.WebDriver.DriverCommands;
using UITests.Pages.Login;
using UITests.Pages.Login.Components;
using UITests.Pages.Home;

namespace UITests.Tests.Login
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]//Parallelizable(ParallelScope.Children) not working yet...
    [Category("UITest"), Category("Assess"), Category("Authentication")]
    public class AuthenticationTest : TestRunner
    {
        public AuthenticationTest()
        {
            TestContext.WriteLine("AuthenticationTest");
        }

        [SetUp]
        public void SetUp()
        {
            TestConfiguration testConfiguration = new TestConfiguration();
            testConfiguration.TestName = TestContext.CurrentContext.Test.FullName;
            testConfiguration.TextWriter = TestContext.Out;
            /*
            testConfiguration.Language = "en";
            testConfiguration.Country = "US";
            testConfiguration.TestTool = TestToolType.DUMMY;
            testConfiguration.TestGrid = TestGridType.SAUCE_LABS;
            testConfiguration.ApplicationName = ApplicationName.schoolnetsingletenant;
            testConfiguration.ApplicationType = ApplicationType.WINDOWS_WEB_EDGE;
            testConfiguration.OperatingSystemVersion = "";
            testConfiguration.BrowserVersion = "20";
            testConfiguration.EnvironmentName = "automation";
            testConfiguration.DeviceOrientation = "landscape";
            testConfiguration.ReleaseVersion = "17";
            */
            this.ReadEnvironmentVariables(testConfiguration);
            this.SetUpBeforeMethodNUnit(testConfiguration);
        }

        /// <summary>
        /// Valid authentication test
        /// </summary>
        /// <remarks>Test Case #</remarks>
        [Test(Author = "Santosh", Description = "Valid authentication test")]
        public void testAuthenticationInputAndSubmitForm()
        {
            try
            {
                this.SchoolNet().LoadWebPage();
                AuthenticationPage authenticationPage = new AuthenticationPage();
                AuthenticationData authenticationData = authenticationPage.InitData();
                authenticationData.GetTestDataFromResxResource("UITests.Data.Login.AuthenticationResource",
                    "valid_" + this.SchoolNet().TestConfiguration.ApplicationName, 0);
                //authenticationData.DistrictName = "National";
                //authenticationData.Username = "sn_qa";
                //authenticationData.Password = "sch00lnet";
                authenticationPage.Data = authenticationData;
                HomePage homePage = (HomePage)authenticationPage.Form.InputAndSubmitForm();
            }
            catch (Exception e)
            {
                TestContext.WriteLine("\nInnerException:\n" + e.InnerException + "\nStackTrace:\n" + e.StackTrace);
                new DriverCommands().GetScreenshotAndPageSource();
                throw new Exception("\nInnerException:\n" + e.InnerException + "\nStackTrace:\n" + e.StackTrace, e);
            }
        }
    }
}
