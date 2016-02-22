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
    [TestFixture]
    [Parallelizable(ParallelScope.Children)]
    public class AnswerLineItemTests : TestRunner
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
        public void AnswerLineItemTest()
        {
            this.SchoolNet().LoadWebPage();
            AnswerLineItem answerLineItem = new AnswerLineItem(0, "ctl01", ItemType.TrueFalse);
            Assert.AreEqual(0, answerLineItem.Index);
            Assert.AreEqual("ctl01", answerLineItem.UniqueId);
        }

        [Test()]
        public void ByPointsPossibleTest()
        {
            this.SchoolNet().LoadWebPage();
            int index = 0;
            string uniqueId = "ctl01";
            AnswerLineItem form = new AnswerLineItem(index, uniqueId, ItemType.Matching);
            Assert.AreEqual("By.Id: ctl00_MainContent_EditTestItemControl_pairsRepeator_" + uniqueId + "_txtPointsPossible",
                form.ByPointsPossible().ToString(), "ByPointsPossible locator matches");

            form = new AnswerLineItem(index, uniqueId, ItemType.MultipleChoice);
            Assert.AreEqual("By.Id: ctl00_MainContent_EditTestItemControl_RepeaterAnswers_" + uniqueId + "_txtAnswerPoints",
                form.ByPointsPossible().ToString(), "ByPointsPossible locator matches");

            form = new AnswerLineItem(index, uniqueId, ItemType.TrueFalse);
            Assert.AreEqual("By.Id: ctl00_MainContent_EditTestItemControl_RepeaterAnswers_" + uniqueId + "_txtAnswerPoints",
                form.ByPointsPossible().ToString(), "ByPointsPossible locator matches");

            form = new AnswerLineItem(index, uniqueId, ItemType.InlineResponse);
            Assert.AreEqual("By.Id: ctl00_MainContent_EditTestItemControl_RepeaterClozeStemAnswers_" + uniqueId + "_txtAnswerPoints",
                form.ByPointsPossible().ToString(), "ByPointsPossible locator matches");

            form = new AnswerLineItem(index, uniqueId, ItemType.DragAndDrop);
            Assert.AreEqual("By.CssSelector: .tab-pane.ng-scope.active .listChoices li[data-ng-repeat='tabChoice in tab.AllChoices']:nth-of-type(" + index + ") .AnswerPoints",
                form.ByPointsPossible().ToString(), "ByPointsPossible locator matches");

            form = new AnswerLineItem(index, uniqueId, ItemType.HotSpotSingleSelection);
            Assert.AreEqual("By.CssSelector: #tblAnswers tbody[ng-repeat='answer in TestItem.Answers']:nth-of-type(" + index + ") .AnswerPoints",
                form.ByPointsPossible().ToString(), "ByPointsPossible locator matches");
        }

        [Test()]
        public void ByIsCorrectResponseTest()
        {
            this.SchoolNet().LoadWebPage();
            int index = 0;
            string uniqueId = "ctl01";
            AnswerLineItem form = new AnswerLineItem(index, uniqueId, ItemType.Matching);
            Assert.AreEqual("By.Id: ctl00_MainContent_EditTestItemControl_pairsRepeator_" + uniqueId + "_chkIsCorrect",
                form.ByIsCorrectResponse().ToString(), "ByIsCorrectResponse locator matches");

            form = new AnswerLineItem(index, uniqueId, ItemType.MultipleChoice);
            Assert.AreEqual("By.Id: ctl00_MainContent_EditTestItemControl_RepeaterAnswers_" + uniqueId + "_CheckBoxCorrect",
                form.ByIsCorrectResponse().ToString(), "ByIsCorrectResponse locator matches");

            form = new AnswerLineItem(index, uniqueId, ItemType.TrueFalse);
            Assert.AreEqual("By.Id: ctl00_MainContent_EditTestItemControl_RepeaterAnswers_" + uniqueId + "_CheckBoxCorrect",
                form.ByIsCorrectResponse().ToString(), "ByIsCorrectResponse locator matches");

            form = new AnswerLineItem(index, uniqueId, ItemType.InlineResponse);
            Assert.AreEqual("By.Id: ctl00_MainContent_EditTestItemControl_RepeaterClozeStemAnswers_" + uniqueId + "_CheckBoxCorrect",
                form.ByIsCorrectResponse().ToString(), "ByIsCorrectResponse locator matches");

            form = new AnswerLineItem(index, uniqueId, ItemType.DragAndDrop);
            Assert.AreEqual("By.CssSelector: .tab-pane.ng-scope.active .listChoices li[data-ng-repeat='tabChoice in tab.AllChoices']:nth-of-type(" + index + ") .checkbox > input",
                form.ByIsCorrectResponse().ToString(), "ByIsCorrectResponse locator matches");

            form = new AnswerLineItem(index, uniqueId, ItemType.HotSpotSingleSelection);
            Assert.AreEqual("By.CssSelector: #tblAnswers tbody[ng-repeat='answer in TestItem.Answers']:nth-of-type(" + index + ") .checkbox > input",
                form.ByIsCorrectResponse().ToString(), "ByIsCorrectResponse locator matches");
        }

        [Test()]
        public void ByRemoveLineTest()
        {
            this.SchoolNet().LoadWebPage();
            int index = 0;
            string uniqueId = "ctl01";
            AnswerLineItem form = new AnswerLineItem(index, uniqueId, ItemType.Matching);
            Assert.AreEqual("By.Id: ctl00_MainContent_EditTestItemControl_choicesRepeator_" + uniqueId + "_lnkDeleteChoice",
                form.ByRemoveLine().ToString(), "ByRemoveLine locator matches");

            form = new AnswerLineItem(index, uniqueId, ItemType.MultipleChoice);
            Assert.AreEqual("By.Id: ctl00_MainContent_EditTestItemControl_RepeaterAnswers_" + uniqueId + "_LinkButton1",
                form.ByRemoveLine().ToString(), "ByRemoveLine locator matches");

            form = new AnswerLineItem(index, uniqueId, ItemType.TrueFalse);
            Assert.AreEqual("By.Id: ",
                form.ByRemoveLine().ToString(), "ByRemoveLine locator matches");

            form = new AnswerLineItem(index, uniqueId, ItemType.InlineResponse);
            Assert.AreEqual("By.Id: ctl00_MainContent_EditTestItemControl_RepeaterClozeStemAnswers_" + uniqueId + "_DelClozeChoice",
                form.ByRemoveLine().ToString(), "ByRemoveLine locator matches");

            form = new AnswerLineItem(index, uniqueId, ItemType.DragAndDrop);
            Assert.AreEqual("By.CssSelector: ",
                form.ByRemoveLine().ToString(), "ByRemoveLine locator matches");

            form = new AnswerLineItem(index, uniqueId, ItemType.HotSpotSingleSelection);
            Assert.AreEqual("By.CssSelector: #tblAnswers tbody[ng-repeat='answer in TestItem.Answers']:nth-of-type(" + index + ") .pull-right > a",
                form.ByRemoveLine().ToString(), "ByRemoveLine locator matches");
        }
    }
}
