using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITests.Pages.Components;
using NUnit.Framework;
using TestContext = NUnit.Framework.TestContext;
using TestConfiguration = Core.Config.TestConfiguration;
using ApplicationType = Core.Framework.ApplicationType;
using TestGridType = Core.Framework.TestGridType;
using TestToolType = Core.Framework.TestToolType;
using ApplicationName = UITests.Framework.ApplicationName;
using TestRunner = UITests.Framework.TestRunner;
using DriverCommands = Core.Tools.WebDriver.DriverCommands;


namespace UITests.Pages.Components.Tests
{
    [TestFixture()]
    [Parallelizable(ParallelScope.Children)]
    public class QuestionAnswerDataTests : TestRunner
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
        public void QuestionAnswerDataTest()
        {
            this.SchoolNet().LoadWebPage();
            try
            {
                QuestionAnswerData questionAnswerData = new QuestionAnswerData();
                Assert.IsNotNull(questionAnswerData, "QuestionAnswerData is null.");
            }
            catch (Exception e)
            {
                throw new Exception("" + e.GetBaseException());
            }
        }

        [Test()]
        public void GetTestDataFromResxResourceTest()
        {
            this.SchoolNet().LoadWebPage();
            try
            {
                QuestionAnswerData questionAnswerData = new QuestionAnswerData();
                questionAnswerData.GetTestDataFromResxResource("UITests.Data.Assess.ItemCreateEdit.MultipleChoiceItemResource",
                    "default_" + this.SchoolNet().TestConfiguration.ApplicationName, 0);

                Assert.AreEqual(ItemType.MultipleChoice, questionAnswerData.ItemType, "The item type is incorrect.");
                Assert.AreEqual(MultipleChoiceLayout.OneColumn, questionAnswerData.AnswerChoiceLayoutOption, "The answer choice layout is incorrect.");
                Assert.IsTrue(questionAnswerData.PointValuePair.ContainsKey("blue"), "The point value key is incorrect.");
                Assert.IsTrue(questionAnswerData.PointValuePair.ContainsValue("5"), "The point value is incorrect.");

                List<string> list = new List<string>();
                list.Add("blue");
                int i = 0;
                foreach (var item in questionAnswerData.CorrectAnswerList)
                {
                    Assert.AreEqual(item, list[i], "The correct answer list is incorrect.");
                    i++;
                }

                list.Add("purple");
                list.Add("yellow");
                list.Add("orange");
                i = 0;
                foreach (var item in questionAnswerData.AnswerList)
                {
                    Assert.AreEqual(item, list[i], "The answer list is incorrect.");
                    i++;
                }

                list.Remove("blue");
                list.Remove("purple");
                list.Remove("yellow");
                list.Remove("orange");
                list.Add("teacher's explanation");
                i = 0;
                foreach (var item in questionAnswerData.TeacherExplanationList)
                {
                    Assert.AreEqual(item, list[i], "The teacher explanation list is incorrect.");
                    i++;
                }

                list.Remove("teacher's explanation");
                list.Add("student's explanation");
                i = 0;
                foreach (var item in questionAnswerData.StudentExplanationList)
                {
                    Assert.AreEqual(item, list[i], "The teacher explanation list is incorrect.");
                    i++;
                }
            }
            catch (Exception e)
            {
                TestContext.WriteLine("\nInnerException:\n" + e.InnerException + "\nStackTrace:\n" + e.StackTrace, e);
                throw new Exception("\nInnerException:\n" + e.InnerException + "\nStackTrace:\n" + e.StackTrace, e);
            }
        }
    }
}
