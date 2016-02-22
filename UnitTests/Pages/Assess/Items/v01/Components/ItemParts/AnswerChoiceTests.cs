using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITests.Pages.Assess.ItemCreateEdit.v01.ItemParts;
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
using UITests.Pages.Components;

namespace UITests.Pages.Assess.Items.v01.Components.ItemParts.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Children)]
    public class AnswerChoiceTests : TestRunner
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

        [Test]
        public void AnswerChoiceTest()
        {
            this.SchoolNet().LoadWebPage();
            AnswerChoice answerChoice = new AnswerChoice(ItemType.TrueFalse, "T", 0, "ctl01");
            Assert.AreEqual(ItemType.TrueFalse, answerChoice.ItemType);
            Assert.AreEqual("T", answerChoice.Label);
            Assert.AreEqual(0, answerChoice.Index);
            Assert.AreEqual("ctl01", answerChoice.UniqueId);
        }

        [Test]
        public void SelectLabelTest()
        {
            this.SchoolNet().LoadWebPage();
            AnswerChoice answerChoice = new AnswerChoice(ItemType.TrueFalse, "T", 0, "ctl01");
            answerChoice.SelectLabel();
        }

        [Test]
        public void EditLabelTest()
        {
            this.SchoolNet().LoadWebPage();
            AnswerChoice answerChoice = new AnswerChoice(ItemType.MultipleChoice, "A", 0, "ctl01");
            answerChoice.EditLabel("B");
        }

        [Test]
        public void SelectContentAddTest()
        {
            this.SchoolNet().LoadWebPage();
            AnswerChoice answerChoice = new AnswerChoice(ItemType.TrueFalse, "A", 0, "ctl01");
            answerChoice.SelectContentAdd();
        }

        [Test]
        public void SelectContentEditTest()
        {
            this.SchoolNet().LoadWebPage();
            AnswerChoice answerChoice = new AnswerChoice(ItemType.MultipleChoice, "A", 0, "ctl01");
            answerChoice.SelectContentEdit();
        }

        [Test]
        public void EditContentTest()
        {
            this.SchoolNet().LoadWebPage();
            AnswerChoice answerChoice = new AnswerChoice(ItemType.MultipleChoice, "A", 0, "ctl01");
            string expected = "my test";
            answerChoice.EditContent(expected);
        }

        [Test]
        public void GetContentTest()
        {
            this.SchoolNet().LoadWebPage();
            AnswerChoice answerChoice = new AnswerChoice(ItemType.MultipleChoice, "A", 0, "ctl01");
            string expected = "my test";
            string actual = answerChoice.GetContent(expected);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void EditPointsPossibleTest()
        {
            this.SchoolNet().LoadWebPage();
            AnswerChoice answerChoice = new AnswerChoice(ItemType.TrueFalse, "T", 0, "ctl01");
            answerChoice.EditPointsPossible("1");
            Assert.AreEqual(1, answerChoice.PointValue);
            answerChoice.EditPointsPossible(2);
            Assert.AreEqual(2, answerChoice.PointValue);
        }

        [Test]
        public void GetPointsPossibleTest()
        {
            this.SchoolNet().LoadWebPage();
            AnswerChoice answerChoice = new AnswerChoice(ItemType.TrueFalse, "T", 0, "ctl01");
            string expected = "1";
            string actual = answerChoice.GetPointsPossible(expected);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SelectIsCorrectResponseTest()
        {
            this.SchoolNet().LoadWebPage();
            AnswerChoice answerChoice = new AnswerChoice(ItemType.TrueFalse, "T", 0, "ctl01");
            answerChoice.SelectIsCorrectResponse();
            Assert.AreEqual(false, answerChoice.AnswerLineItem.IsCorrectResponse.Selected);
            Assert.AreEqual(true, answerChoice.IsCorrectAnswer);
        }

        [Test]
        public void CheckIsCorrectResponseTest()
        {
            this.SchoolNet().LoadWebPage();
            AnswerChoice answerChoice = new AnswerChoice(ItemType.TrueFalse, "T", 0, "ctl01");
            answerChoice.CheckIsCorrectResponse();
            Assert.AreEqual(false, answerChoice.AnswerLineItem.IsCorrectResponse.Selected);
            Assert.AreEqual(true, answerChoice.IsCorrectAnswer);
        }

        [Test]
        public void UnCheckIsCorrectResponseTest()
        {
            this.SchoolNet().LoadWebPage();
            AnswerChoice answerChoice = new AnswerChoice(ItemType.TrueFalse, "T", 0, "ctl01");
            answerChoice.UnCheckIsCorrectResponse();
            Assert.AreEqual(true, answerChoice.AnswerLineItem.IsCorrectResponse.Selected);
            Assert.AreEqual(false, answerChoice.IsCorrectAnswer);
        }

        [Test]
        public void RemoveLineTest()
        {
            this.SchoolNet().LoadWebPage();
            AnswerChoice answerChoice = new AnswerChoice(ItemType.TrueFalse, "T", 0, "ctl01");
            answerChoice.RemoveLine();
        }

        [Test]
        public void SelectTeacherExplanationTest()
        {
            this.SchoolNet().LoadWebPage();
            AnswerChoice answerChoice = new AnswerChoice(ItemType.TrueFalse, "T", 0, "ctl01");
            answerChoice.SelectTeacherExplanation();
        }

        [Test]
        public void SelectEditTeacherExplanationTest()
        {
            this.SchoolNet().LoadWebPage();
            AnswerChoice answerChoice = new AnswerChoice(ItemType.TrueFalse, "T", 0, "ctl01");
            answerChoice.SelectEditTeacherExplanation();
        }

        [Test]
        public void SelectStudentExplanationTest()
        {
            this.SchoolNet().LoadWebPage();
            AnswerChoice answerChoice = new AnswerChoice(ItemType.TrueFalse, "T", 0, "ctl01");
            answerChoice.SelectStudentExplanation();
        }

        [Test]
        public void SelectEditStudentExplanationTest()
        {
            this.SchoolNet().LoadWebPage();
            AnswerChoice answerChoice = new AnswerChoice(ItemType.TrueFalse, "T", 0, "ctl01");
            answerChoice.SelectEditStudentExplanation();
        }

        [Test]
        public void SelectHotSpotTest()
        {
            this.SchoolNet().LoadWebPage();
            AnswerChoice answerChoice = new AnswerChoice(ItemType.HotSpotSingleSelection, "A", 0, "ctl01");
            answerChoice.SelectHotSpot();
        }

        [Test()]
        public void ByHotSpotTest()
        {
            this.SchoolNet().LoadWebPage();
            int index = 0;
            string uniqueId = "ctl01";
            AnswerChoice form = new AnswerChoice(ItemType.HotSpotSingleSelection, "A", index, uniqueId);
            Assert.AreEqual("By.CssSelector: #tblAnswers tbody[ng-repeat='answer in TestItem.Answers']:nth-of-type(" + index + ") button.btn",
                form.ByHotSpot().ToString(), "ByHotSpotTest locator matches");
        }
    }
}
