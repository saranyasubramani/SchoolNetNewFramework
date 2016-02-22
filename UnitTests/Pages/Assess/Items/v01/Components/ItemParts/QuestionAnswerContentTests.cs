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
    public class QuestionAnswerContentTests : TestRunner
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
        public void QuestionAnswerContentTest()
        {
            this.SchoolNet().LoadWebPage();
            QuestionAnswerContent questionAnswerContent = new QuestionAnswerContent("T", 0, "ctl01", ContentType.AnswerChoice, ItemType.TrueFalse);
            Assert.AreEqual("T", questionAnswerContent.Label);
            Assert.AreEqual(0, questionAnswerContent.Index);
            Assert.AreEqual("ctl01", questionAnswerContent.UniqueId);
        }

        [Test()]
        public void ByContentLabelTest()
        {
            this.SchoolNet().LoadWebPage();
            int index = 0;
            string uniqueId = "ctl01";
            QuestionAnswerContent form = new QuestionAnswerContent("T", index, uniqueId, ContentType.AnswerChoice, ItemType.MultipleChoice);
            Assert.AreEqual("By.Id: ctl00_MainContent_EditTestItemControl_RepeaterAnswers_" + uniqueId + "_txtAnswerLabel",
                form.ByContentLabel().ToString(), "ByContentLabel locator matches");

            form = new QuestionAnswerContent("T", index, uniqueId, ContentType.AnswerChoice, ItemType.TrueFalse);
            Assert.AreEqual("By.Id: ctl00_MainContent_EditTestItemControl_RepeaterAnswers_" + uniqueId + "_txtAnswerLabel",
                form.ByContentLabel().ToString(), "ByContentLabel locator matches");

            form = new QuestionAnswerContent("T", index, uniqueId, ContentType.AnswerChoice, ItemType.InlineResponse);
            Assert.AreEqual("By.Id: ctl00_MainContent_EditTestItemControl_RepeaterClozeStemAnswers_" + uniqueId + "_txtAnswerLabel",
                form.ByContentLabel().ToString(), "ByContentLabel locator matches");

            form = new QuestionAnswerContent("T", index, uniqueId, ContentType.AnswerChoice, ItemType.DragAndDrop);
            Assert.AreEqual("By.CssSelector: .tab-pane.ng-scope.active .listChoices li[data-ng-repeat='tabChoice in tab.AllChoices']:nth-of-type(" + index + ") .AnswerLabel",
                form.ByContentLabel().ToString(), "ByContentLabel locator matches");

            form = new QuestionAnswerContent("T", index, uniqueId, ContentType.AnswerChoice, ItemType.HotSpotSingleSelection);
            Assert.AreEqual("By.CssSelector: #tblAnswers tbody[ng-repeat='answer in TestItem.Answers']:nth-of-type(" + index + ") .AnswerLabel",
                form.ByContentLabel().ToString(), "ByContentLabel locator matches");


            form = new QuestionAnswerContent("T", index, uniqueId, ContentType.AvailableChoice, ItemType.Matching);
            Assert.AreEqual("By.Id: ctl00_MainContent_EditTestItemControl_choicesRepeator_" + uniqueId + "_txtChoiceLabel",
                form.ByContentLabel().ToString(), "ByContentLabel locator matches");

            form = new QuestionAnswerContent("T", index, uniqueId, ContentType.AvailableChoice, ItemType.DragAndDrop);
            Assert.AreEqual("By.CssSelector: .listChoices li[data-ng-repeat='choice in TestItem.Choices']:nth-of-type(" + index + ") .AnswerLabel",
                form.ByContentLabel().ToString(), "ByContentLabel locator matches");


            form = new QuestionAnswerContent("T", index, uniqueId, ContentType.QuestionStem, ItemType.TrueFalse);
            Assert.AreEqual("By.Id: ctl00_MainContent_EditTestItemControl_stemRepeator_" + uniqueId + "_txtStemLabel",
                form.ByContentLabel().ToString(), "ByContentLabel locator matches");


            form = new QuestionAnswerContent("T", index, uniqueId, ContentType.TargetContainer, ItemType.TrueFalse);
            Assert.AreEqual("By.CssSelector: .listChoices li[data-ng-repeat='container in TestItem.Containers']:nth-of-type(" + index + ") .AnswerLabel",
                form.ByContentLabel().ToString(), "ByContentLabel locator matches");
        }

        [Test()]
        public void ByContentAddTest()
        {
            this.SchoolNet().LoadWebPage();
            int index = 0;
            string uniqueId = "ctl01";
            QuestionAnswerContent form = new QuestionAnswerContent("T", index, uniqueId, ContentType.AnswerChoice, ItemType.MultipleChoice);
            Assert.AreEqual("By.Id: divNoAnswerContent" + index,
                form.ByContentAdd().ToString(), "ByContentAdd locator matches");

            form = new QuestionAnswerContent("T", index, uniqueId, ContentType.AnswerChoice, ItemType.TrueFalse);
            Assert.AreEqual("By.Id: divNoAnswerContent" + index,
                form.ByContentAdd().ToString(), "ByContentAdd locator matches");

            form = new QuestionAnswerContent("T", index, uniqueId, ContentType.AnswerChoice, ItemType.InlineResponse);
            Assert.AreEqual("By.Id: ctl00_MainContent_EditTestItemControl_RepeaterClozeStemAnswers_" + uniqueId + "_txtAnswerContent",
                form.ByContentAdd().ToString(), "ByContentAdd locator matches");

            form = new QuestionAnswerContent("T", index, uniqueId, ContentType.AnswerChoice, ItemType.DragAndDrop);
            Assert.AreEqual("By.CssSelector: .tab-pane.ng-scope.active .listChoices li[data-ng-repeat='tabChoice in tab.AllChoices']:nth-of-type(" + index + ") div[data-ng-bind-html-unsafe]",
                form.ByContentAdd().ToString(), "ByContentAdd locator matches");

            form = new QuestionAnswerContent("T", index, uniqueId, ContentType.AnswerChoice, ItemType.HotSpotSingleSelection);
            Assert.AreEqual("By.CssSelector: #tblAnswers tbody[ng-repeat='answer in TestItem.Answers']:nth-of-type(" + index + ") ..itemContent > #divNoanswer0A",
                form.ByContentAdd().ToString(), "ByContentAdd locator matches");


            form = new QuestionAnswerContent("T", index, uniqueId, ContentType.AvailableChoice, ItemType.Matching);
            Assert.AreEqual("By.Id: divNoMatchChoiceContent" + index,
                form.ByContentAdd().ToString(), "ByContentAdd locator matches");

            form = new QuestionAnswerContent("T", index, uniqueId, ContentType.AvailableChoice, ItemType.DragAndDrop);
            Assert.AreEqual("By.CssSelector: .listChoices li[data-ng-repeat='choice in TestItem.Choices']:nth-of-type(" + index + ") .itemContent",
                form.ByContentAdd().ToString(), "ByContentAdd locator matches");


            form = new QuestionAnswerContent("T", index, uniqueId, ContentType.QuestionStem, ItemType.TrueFalse);
            Assert.AreEqual("By.Id: divNoMatchStemContent" + index,
                form.ByContentAdd().ToString(), "ByContentAdd locator matches");


            form = new QuestionAnswerContent("T", index, uniqueId, ContentType.TargetContainer, ItemType.TrueFalse);
            Assert.AreEqual("By.CssSelector: .listChoices li[data-ng-repeat='container in TestItem.Containers']:nth-of-type(" + index + ") .itemContent",
                form.ByContentAdd().ToString(), "ByContentAdd locator matches");
        }

        [Test()]
        public void ByContentEditTest()
        {
            this.SchoolNet().LoadWebPage();
            int index = 0;
            string uniqueId = "ctl01";
            QuestionAnswerContent form = new QuestionAnswerContent("T", index, uniqueId, ContentType.AnswerChoice, ItemType.MultipleChoice);
            Assert.AreEqual("By.Id: divAnswerContent" + index,
                form.ByContentEdit().ToString(), "ByContentEdit locator matches");

            form = new QuestionAnswerContent("T", index, uniqueId, ContentType.AnswerChoice, ItemType.TrueFalse);
            Assert.AreEqual("By.Id: divAnswerContent" + index,
                form.ByContentEdit().ToString(), "ByContentEdit locator matches");

            form = new QuestionAnswerContent("T", index, uniqueId, ContentType.AnswerChoice, ItemType.InlineResponse);
            Assert.AreEqual("By.Id: ctl00_MainContent_EditTestItemControl_RepeaterClozeStemAnswers_" + uniqueId + "_txtAnswerContent",
                form.ByContentEdit().ToString(), "ByContentEdit locator matches");

            form = new QuestionAnswerContent("T", index, uniqueId, ContentType.AnswerChoice, ItemType.DragAndDrop);
            Assert.AreEqual("By.CssSelector: .tab-pane.ng-scope.active .listChoices li[data-ng-repeat='tabChoice in tab.AllChoices']:nth-of-type(" + index + ") div[data-ng-bind-html]",
                form.ByContentEdit().ToString(), "ByContentEdit locator matches");

            form = new QuestionAnswerContent("T", index, uniqueId, ContentType.AnswerChoice, ItemType.HotSpotSingleSelection);
            Assert.AreEqual("By.CssSelector: #tblAnswers tbody[ng-repeat='answer in TestItem.Answers']:nth-of-type(" + index + ") ..itemContent > #divanswer0A",
                form.ByContentEdit().ToString(), "ByContentEdit locator matches");


            form = new QuestionAnswerContent("T", index, uniqueId, ContentType.AvailableChoice, ItemType.Matching);
            Assert.AreEqual("By.Id: divMatchChoiceContent" + index,
                form.ByContentEdit().ToString(), "ByContentEdit locator matches");

            form = new QuestionAnswerContent("T", index, uniqueId, ContentType.AvailableChoice, ItemType.DragAndDrop);
            Assert.AreEqual("By.CssSelector: .listChoices li[data-ng-repeat='choice in TestItem.Choices']:nth-of-type(" + index + ") .itemContent",
                form.ByContentEdit().ToString(), "ByContentEdit locator matches");


            form = new QuestionAnswerContent("T", index, uniqueId, ContentType.QuestionStem, ItemType.TrueFalse);
            Assert.AreEqual("By.Id: divMatchStemContent" + index,
                form.ByContentEdit().ToString(), "ByContentEdit locator matches");


            form = new QuestionAnswerContent("T", index, uniqueId, ContentType.TargetContainer, ItemType.TrueFalse);
            Assert.AreEqual("By.CssSelector: .listChoices li[data-ng-repeat='container in TestItem.Containers']:nth-of-type(" + index + ") .itemContent",
                form.ByContentEdit().ToString(), "ByContentEdit locator matches");
        }

        [Test()]
        public void ByContentRemoveTest()
        {
            this.SchoolNet().LoadWebPage();
            int index = 0;
            string uniqueId = "ctl01";
            QuestionAnswerContent form = new QuestionAnswerContent("T", index, uniqueId, ContentType.AnswerChoice, ItemType.MultipleChoice);
            Assert.AreEqual("By.Id: ctl00_MainContent_EditTestItemControl_RepeaterAnswers_" + uniqueId + "_LinkButton1",
                form.ByContentRemove().ToString(), "ByContentRemove locator matches");

            form = new QuestionAnswerContent("T", index, uniqueId, ContentType.AnswerChoice, ItemType.TrueFalse);
            Assert.AreEqual("By.Id: ctl00_MainContent_EditTestItemControl_RepeaterAnswers_" + uniqueId + "_LinkButton1",
                form.ByContentRemove().ToString(), "ByContentRemove locator matches");

            form = new QuestionAnswerContent("T", index, uniqueId, ContentType.AnswerChoice, ItemType.InlineResponse);
            Assert.AreEqual("By.Id: ctl00_MainContent_EditTestItemControl_RepeaterClozeStemAnswers_" + uniqueId + "_DelClozeChoice",
                form.ByContentRemove().ToString(), "ByContentRemove locator matches");

            form = new QuestionAnswerContent("T", index, uniqueId, ContentType.AnswerChoice, ItemType.DragAndDrop);
            Assert.AreEqual("By.CssSelector: ",
                form.ByContentRemove().ToString(), "ByContentRemove locator matches");

            form = new QuestionAnswerContent("T", index, uniqueId, ContentType.AnswerChoice, ItemType.HotSpotSingleSelection);
            Assert.AreEqual("By.CssSelector: #tblAnswers tbody[ng-repeat='answer in TestItem.Answers']:nth-of-type(" + index + ") .pull-right > a",
                form.ByContentRemove().ToString(), "ByContentRemove locator matches");


            form = new QuestionAnswerContent("T", index, uniqueId, ContentType.AvailableChoice, ItemType.Matching);
            Assert.AreEqual("By.Id: ctl00_MainContent_EditTestItemControl_choicesRepeator_" + uniqueId + "_lnkDeleteChoice",
                form.ByContentRemove().ToString(), "ByContentRemove locator matches");

            form = new QuestionAnswerContent("T", index, uniqueId, ContentType.AvailableChoice, ItemType.DragAndDrop);
            Assert.AreEqual("By.CssSelector: .listChoices li[data-ng-repeat='choice in TestItem.Choices']:nth-of-type(" + index + ") a",
                form.ByContentRemove().ToString(), "ByContentRemove locator matches");


            form = new QuestionAnswerContent("T", index, uniqueId, ContentType.QuestionStem, ItemType.TrueFalse);
            Assert.AreEqual("By.Id: ctl00_MainContent_EditTestItemControl_stemRepeator_" + uniqueId + "_lnkDeleteStem",
                form.ByContentRemove().ToString(), "ByContentRemove locator matches");


            form = new QuestionAnswerContent("T", index, uniqueId, ContentType.TargetContainer, ItemType.TrueFalse);
            Assert.AreEqual("By.CssSelector: .listChoices li[data-ng-repeat='container in TestItem.Containers']:nth-of-type(" + index + ") a",
                form.ByContentRemove().ToString(), "ByContentRemove locator matches");
        }

        [Test()]
        public void ByChoiceCanBeUsedSelectTest()
        {
            this.SchoolNet().LoadWebPage();
            int index = 0;
            string uniqueId = "ctl01";
            QuestionAnswerContent form = new QuestionAnswerContent("T", index, uniqueId, ContentType.AvailableChoice, ItemType.DragAndDrop);
            Assert.AreEqual("By.CssSelector: .listChoices li[data-ng-repeat='choice in TestItem.Choices']:nth-of-type(" + index + ") select",
                form.ByChoiceCanBeUsedSelect().ToString(), "ByChoiceCanBeUsedSelect locator matches");
        }
    }
}
