using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
using UITests.Data.Assess.Standards;
using UITests.Pages.Login;
using UITests.Pages.Login.Components;
using UITests.Pages.Home;
using UITests.Pages.Components;
using UITests.Pages.Assess.ItemCreateEdit.v01.Components;
using UITests.Pages.Assess.Passage;
using UITests.Pages.Assess.Passage.EditPassage;
using UITests.Workflow;

namespace UITests.Tests.DataSetup
{
    /// <summary>
    /// Data setup script to create passages.
    /// </summary>
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]//Parallelizable(ParallelScope.Children) not working yet...
    [Category("UITest"), Category("Assess"), Category("DataSetup"), Category("CreatePassages")]
    public class CreatePassagesTest : TestRunner
    {
        public CreatePassagesTest()
        {
            TestContext.WriteLine("CreatePassagesTest");
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
            testConfiguration.TestTool = TestToolType.WEBDRIVER;
            testConfiguration.TestGrid = TestGridType.SAUCE_LABS;
            testConfiguration.ApplicationName = ApplicationName.schoolnetsingletenant;
            testConfiguration.ApplicationType = ApplicationType.WINDOWS_WEB_FIREFOX;
            testConfiguration.OperatingSystemVersion = "8";
            testConfiguration.BrowserVersion = "32";
            testConfiguration.EnvironmentName = "automation";
            testConfiguration.DeviceOrientation = "landscape";
            testConfiguration.ReleaseVersion = "17";
            */
            this.ReadEnvironmentVariables(testConfiguration);
            this.SetUpBeforeMethodNUnit(testConfiguration);
        }

        /// <summary>
        /// Create passage with publisher
        /// </summary>
        [Test(Author = "Santosh", Description = "data setup script")]
        public void Create_Passage_With_Publisher()
        {
            try
            {
                this.SchoolNet().LoadWebPage();

                Workflows workflows = new Workflows();
                workflows.SignInAsDistrictAdmin();

                TestContext.WriteLine("\n--- Create a passage ---");
                workflows.AssessWorkflows.PassageWorkflows
                    .NavigateToCreatePassagePage();

                //set up data for EditPassage.aspx
                EditPassageData editPassageData = workflows.AssessWorkflows.EditPassagePage.InitData();
                editPassageData.GetTestDataFromResxResource(
                    "UITests.Data.Assess.Passage.PassageResource",
                    "default_" + this.SchoolNet().TestConfiguration.ApplicationName, 0);
                editPassageData.Title = "OriginalAutomationPassage";
                editPassageData.Publisher = "OriginalAutomationPassage_Publisher";
                workflows.AssessWorkflows.EditPassagePage.Data = editPassageData;

                workflows.AssessWorkflows.PassageWorkflows
                    .CreatePassagePageInputFormFields();

                workflows.SignOut();
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

