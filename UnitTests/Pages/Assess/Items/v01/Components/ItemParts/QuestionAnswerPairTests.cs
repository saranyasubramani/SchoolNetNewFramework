using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITests.Pages.Assess.ItemCreateEdit.v01.ItemParts;
using NUnit.Framework;
using TestContext = NUnit.Framework.TestContext;
using TestConfiguration = Core.Config.TestConfiguration;
using ApplicationType = Core.Framework.ApplicationType;
using TestGridType = Core.Framework.TestGridType;
using TestToolType = Core.Framework.TestToolType;
using ApplicationName = UITests.Framework.ApplicationName;
using TestRunner = UITests.Framework.TestRunner;
using DriverCommands = Core.Tools.WebDriver.DriverCommands;
using UITests.Pages.Components;

namespace UITests.Pages.Assess.Items.v01.Components.ItemParts.Tests
{
    [TestFixture()]
    [Parallelizable(ParallelScope.Children)]
    public class QuestionAnswerPairTests :TestRunner
    {
        [SetUp]
        public void SetUp()
        {
            TestConfiguration testConfiguration = new TestConfiguration();
            testConfiguration.Language = "en";
            testConfiguration.Country = "US";
            testConfiguration.TestTool = TestToolType.DUMMY;
            testConfiguration.TestGrid = TestGridType.LOCAL;
            testConfiguration.ApplicationName = ApplicationName.schoolnetsingletenant;
            testConfiguration.ApplicationType = ApplicationType.WINDOWS_WEB_CHROME;
            testConfiguration.OperatingSystemVersion = "8";
            testConfiguration.BrowserVersion = "32";
            testConfiguration.EnvironmentName = "automation";
            testConfiguration.DeviceOrientation = "landscape";
            testConfiguration.ReleaseVersion = "17";
            testConfiguration.TestName = TestContext.CurrentContext.Test.FullName;
            testConfiguration.TextWriter = TestContext.Out;
            this.SetUpBeforeMethodNUnit(testConfiguration);
        }

        [Test()]
        public void QuestionAnswerPairTest()
        {
            this.SchoolNet().LoadWebPage();
            QuestionAnswerPair questionAnswerPair = new QuestionAnswerPair("ctl01", ItemType.Matching);
            Assert.AreEqual("ctl01", questionAnswerPair.UniqueId);
        }

        [Test()]
        public void ByChoiceTest()
        {
            this.SchoolNet().LoadWebPage();
            string uniqueId = "ctl01";
            QuestionAnswerPair form = new QuestionAnswerPair(uniqueId, ItemType.Matching);
            Assert.AreEqual("By.Id: ctl00_MainContent_EditTestItemControl_pairsRepeator_" + uniqueId + "_ddlChoices", 
                form.ByChoice.ToString(), "ByChoice locator matches");
        }

        [Test()]
        public void ByStemTest()
        {
            this.SchoolNet().LoadWebPage();
            string uniqueId = "ctl01";
            QuestionAnswerPair form = new QuestionAnswerPair(uniqueId, ItemType.Matching);
            Assert.AreEqual("By.Id: ctl00_MainContent_EditTestItemControl_pairsRepeator_" + uniqueId + "_ddlStems", 
                form.ByStem.ToString(), "ByStem locator matches");
        }
    }
}
