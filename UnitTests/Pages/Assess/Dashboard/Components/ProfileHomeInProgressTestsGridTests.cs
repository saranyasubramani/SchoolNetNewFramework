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
using Core.Views.Grids;
using UITests.Pages;
using UITests.Pages.Components;
using UITests.Pages.Assess.Dashboard;
using UITests.Pages.Assess.Dashboard.ProfileHome;
using UITests.Pages.Assess.Dashboard.ProfileHome.InProgressTests;

namespace UnitTests.Pages.Assess.Dashboard.Components
{
    [TestFixture]
    [Parallelizable(ParallelScope.Children)]
    public class ProfileHomeInProgressTestsGridTests : TestRunner
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
        public void ProfileHomeInProgressTestsGridTest()
        {
            this.SchoolNet().LoadWebPage();

            try
            {
                string gridCssSelector = "ProfileControl_InProgressTestResults_ctl00_gridResults";
                ProfileHomeInProgressTestsGrid ProfileHomeInProgressTestsGrid = new ProfileHomeInProgressTestsGrid(gridCssSelector, true);

                int expectedNumber = 0;
                int actualNumber = 0;
                string expected = null;
                string actual = null;

                expectedNumber = 4;
                actualNumber = ProfileHomeInProgressTestsGrid.GetColumnList().Count();
                Assert.AreEqual(expectedNumber, actualNumber, "Assess Dashboard In-Progress Tests Grid does not have the correct number of columns.");

                expectedNumber = 6;
                actualNumber = ProfileHomeInProgressTestsGrid.GetRowList().Count();
                Assert.AreEqual(expectedNumber, actualNumber, "Assess Dashboard In-Progress Tests Grid does not have the correct number of Rows.");

                expected = "Test Name";
                actual = ProfileHomeInProgressTestsGrid.GetColumnFromList(0).Name;
                Assert.AreEqual(expected, actual, "First Column Name in the Assess Dashboard In-Progress Tests Grid is not as expected.");

                expected = "End Date";
                actual = ProfileHomeInProgressTestsGrid.GetColumnFromList(1).Name;
                Assert.AreEqual(expected, actual, "Second Column Name in the Assess Dashboard In-Progress Tests Grid is not as expected.");

                expected = "Scores Due Date";
                actual = ProfileHomeInProgressTestsGrid.GetColumnFromList(2).Name;
                Assert.AreEqual(expected, actual, "Third Column Name in the Assess Dashboard In-Progress Tests Grid is not as expected.");

                expected = "Collection Status";
                actual = ProfileHomeInProgressTestsGrid.GetColumnFromList(3).Name;
                Assert.AreEqual(expected, actual, "Fourth Column Name in the Assess Dashboard In-Progress Tests Grid is not as expected.");

                expected = "Automated Test 1";
                actual = ProfileHomeInProgressTestsGrid.GetsFirstRowContainingTextToFindFromList(ProfileHomeInProgressTestsGrid.GetColumnFromList(0).Name, expected).GetTestName();
                Assert.AreEqual(expected, actual, "First Column Data in the First Data Row of the Assess Dashboard In-Progress Tests Grid is incorrect");

                expected = "Automated Test 2";
                actual = ProfileHomeInProgressTestsGrid.GetsFirstRowContainingTextToFindFromList(ProfileHomeInProgressTestsGrid.GetColumnFromList(0).Name, expected).GetTestName();
                Assert.AreEqual(expected, actual, "First Column Data in the Second Data Row of the Assess Dashboard In-Progress Tests Grid is incorrect");

                expected = "Automated Test 3";
                actual = ProfileHomeInProgressTestsGrid.GetsFirstRowContainingTextToFindFromList(ProfileHomeInProgressTestsGrid.GetColumnFromList(0).Name, expected).GetTestName();
                Assert.AreEqual(expected, actual, "First Column Data in the Third Data Row of the Assess Dashboard In-Progress Tests Grid is incorrect");

                expected = "Automated Test 4";
                actual = ProfileHomeInProgressTestsGrid.GetsFirstRowContainingTextToFindFromList(ProfileHomeInProgressTestsGrid.GetColumnFromList(0).Name, expected).GetTestName();
                Assert.AreEqual(expected, actual, "First Column Data in the Fourth Data Row of the Assess Dashboard In-Progress Tests Grid is incorrect");

                expected = "Automated Test 5";
                actual = ProfileHomeInProgressTestsGrid.GetsFirstRowContainingTextToFindFromList(ProfileHomeInProgressTestsGrid.GetColumnFromList(0).Name, expected).GetTestName();
                Assert.AreEqual(expected, actual, "First Column Data in the Fifth Data Row of the Assess Dashboard In-Progress Tests Grid is incorrect");
            }

            catch (Exception e)
            {
                TestContext.WriteLine("" + e.GetBaseException());
                throw new Exception("\nMessage:\n" + e.Message
                    + "\nInnerException:\n" + e.InnerException
                    + "\nStackTrace:\n" + e.StackTrace + "\n", e);
            }
        }

        [Test]
        public void GetDummyElementsColumnsTest()
        {
            this.SchoolNet().LoadWebPage();

            try
            {
                string gridCssSelector = "ProfileControl_InProgressTestResults_ctl00_gridResults";
                ProfileHomeInProgressTestsGrid ProfileHomeInProgressTestsGrid = new ProfileHomeInProgressTestsGrid(gridCssSelector, true);

                int expectedNumber = 0;
                int actualNumber = 0;
                string expected = null;
                string actual = null;

                expectedNumber = 4;
                actualNumber = ProfileHomeInProgressTestsGrid.GetDummyElementsColumns().Count();
                Assert.AreEqual(expectedNumber, actualNumber, "Assess Dashboard In-Progress Tests Grid Dummy Column List does not have the correct number of columns.");

                expected = "Test Name";
                actual = ProfileHomeInProgressTestsGrid.GetDummyElementsColumns()[0].Text;
                Assert.AreEqual(expected, actual, "Incorrect Column Name for the first column in the Assess Dashboard In-Progress Tests Grid Dummy Column List.");

                expected = "End Date";
                actual = ProfileHomeInProgressTestsGrid.GetDummyElementsColumns()[1].Text;
                Assert.AreEqual(expected, actual, "Incorrect Column Name for the second column in the Assess Dashboard In-Progress Tests Grid Dummy Column List.");

                expected = "Scores Due Date";
                actual = ProfileHomeInProgressTestsGrid.GetDummyElementsColumns()[2].Text;
                Assert.AreEqual(expected, actual, "Incorrect Column Name for the third column in the Assess Dashboard In-Progress Tests Grid Dummy Column List.");

                expected = "Collection Status";
                actual = ProfileHomeInProgressTestsGrid.GetDummyElementsColumns()[3].Text;
                Assert.AreEqual(expected, actual, "Incorrect Column Name for the fourth column in the Assess Dashboard In-Progress Tests Grid Dummy Column List.");
            }

            catch (Exception e)
            {
                TestContext.WriteLine("" + e.GetBaseException());
                throw new Exception("\nMessage:\n" + e.Message
                    + "\nInnerException:\n" + e.InnerException
                    + "\nStackTrace:\n" + e.StackTrace + "\n", e);
            }
        }

        [Test]
        public void GetDummyElementsPaginationRowsTest()
        {
            this.SchoolNet().LoadWebPage();

            try
            {
                string gridCssSelector = "ProfileControl_InProgressTestResults_ctl00_gridResults";
                ProfileHomeInProgressTestsGrid ProfileHomeInProgressTestsGrid = new ProfileHomeInProgressTestsGrid(gridCssSelector, true);

                Assert.IsNull(ProfileHomeInProgressTestsGrid.GetDummyElementsPaginationRows(), "Assess Dashboard In-Progress Tests Grid Dummy Pagination Rows Count is not zero.");
            }

            catch (Exception e)
            {
                TestContext.WriteLine("" + e.GetBaseException());
                throw new Exception("\nMessage:\n" + e.Message
                    + "\nInnerException:\n" + e.InnerException
                    + "\nStackTrace:\n" + e.StackTrace + "\n", e);
            }
        }

        [Test]
        public void GetDummyElementsHeaderRowsTest()
        {
            this.SchoolNet().LoadWebPage();

            try
            {
                string gridCssSelector = "ProfileControl_InProgressTestResults_ctl00_gridResults";
                ProfileHomeInProgressTestsGrid ProfileHomeInProgressTestsGrid = new ProfileHomeInProgressTestsGrid(gridCssSelector, true);

                int expectedNumber = 0;
                int actualNumber = 0;
                string expected = null;
                string actual = null;

                expectedNumber = 1;
                actualNumber = ProfileHomeInProgressTestsGrid.GetDummyElementsHeaderRows().Count();
                Assert.AreEqual(expectedNumber, actualNumber, "Assess Dashboard In-Progress Tests Grid Dummy Header Rows List does not have the correct number of Header Rows.");

                expected = "<th>Test Name</th><th>End Date</th><th>Scores Due Date</th><th>Collection Status</th>";
                actual = ProfileHomeInProgressTestsGrid.GetDummyElementsHeaderRows()[0].Text;
                Assert.AreEqual(expected, actual, "First Row in the Assess Dashboard In-Progress Tests Grid Dummy Header Rows List does not have the correct text.");
            }

            catch (Exception e)
            {
                TestContext.WriteLine("" + e.GetBaseException());
                throw new Exception("\nMessage:\n" + e.Message
                    + "\nInnerException:\n" + e.InnerException
                    + "\nStackTrace:\n" + e.StackTrace + "\n", e);
            }
        }

        [Test]
        public void GetDummyElementsDataRowsTest()
        {
            this.SchoolNet().LoadWebPage();

            try
            {
                string gridCssSelector = "ProfileControl_InProgressTestResults_ctl00_gridResults";
                ProfileHomeInProgressTestsGrid ProfileHomeInProgressTestsGrid = new ProfileHomeInProgressTestsGrid(gridCssSelector, true);

                int expectedNumber = 0;
                int actualNumber = 0;
                string expected = null;
                string actual = null;

                expectedNumber = 5;
                actualNumber = ProfileHomeInProgressTestsGrid.GetDummyElementsDataRows().Count();
                Assert.AreEqual(expectedNumber, actualNumber, "Assess Dashboard In-Progress Tests Grid Dummy Data Rows List does not have the correct number of Data Rows.");

                expected = "Automated Test 1";
                actual = ProfileHomeInProgressTestsGrid.GetDummyElementsDataRows()[0].Text;
                Assert.AreEqual(expected, actual, "First Column Data in the First Data Row of the Assess Dashboard In-Progress Tests Grid Dummy Data Rows List is incorrect");

                expected = "Automated Test 2";
                actual = ProfileHomeInProgressTestsGrid.GetDummyElementsDataRows()[1].Text;
                Assert.AreEqual(expected, actual, "First Column Data in the Second Data Row of the Assess Dashboard In-Progress Tests Grid Dummy Data Rows List is incorrect");

                expected = "Automated Test 3";
                actual = ProfileHomeInProgressTestsGrid.GetDummyElementsDataRows()[2].Text;
                Assert.AreEqual(expected, actual, "First Column Data in the Third Data Row of the Assess Dashboard In-Progress Tests Grid Dummy Data Rows List is incorrect");

                expected = "Automated Test 4";
                actual = ProfileHomeInProgressTestsGrid.GetDummyElementsDataRows()[3].Text;
                Assert.AreEqual(expected, actual, "First Column Data in the Fourth Data Row of the Assess Dashboard In-Progress Tests Grid Dummy Data Rows List is incorrect");

                expected = "Automated Test 5";
                actual = ProfileHomeInProgressTestsGrid.GetDummyElementsDataRows()[4].Text;
                Assert.AreEqual(expected, actual, "First Column Data in the Fifth Data Row of the Assess Dashboard In-Progress Tests Grid Dummy Data Rows List is incorrect");
            }

            catch (Exception e)
            {
                TestContext.WriteLine("" + e.GetBaseException());
                throw new Exception("\nMessage:\n" + e.Message
                    + "\nInnerException:\n" + e.InnerException
                    + "\nStackTrace:\n" + e.StackTrace + "\n", e);
            }
        }

        [Test]
        public void SetColumnListsTest()
        {
            this.SchoolNet().LoadWebPage();

            try
            {
                string gridCssSelector = "ProfileControl_InProgressTestResults_ctl00_gridResults";
                ProfileHomeInProgressTestsGrid ProfileHomeInProgressTestsGrid = new ProfileHomeInProgressTestsGrid(gridCssSelector, false);

                int expectedNumber = 0;
                int actualNumber = 0;
                string expected = null;
                string actual = null;

                ProfileHomeInProgressTestsGrid.SetColumnLists();

                expectedNumber = 4;
                actualNumber = ProfileHomeInProgressTestsGrid.GetColumnList().Count();
                Assert.AreEqual(expectedNumber, actualNumber, "Assess Dashboard In-Progress Tests Grid does not have the correct number of columns.");

                expected = "Test Name";
                actual = ProfileHomeInProgressTestsGrid.GetColumnFromList(0).Name;
                Assert.AreEqual(expected, actual, "First Column Name in the Assess Dashboard In-Progress Tests Grid is not as expected.");

                expected = "End Date";
                actual = ProfileHomeInProgressTestsGrid.GetColumnFromList(1).Name;
                Assert.AreEqual(expected, actual, "Second Column Name in the Assess Dashboard In-Progress Tests Grid is not as expected.");

                expected = "Scores Due Date";
                actual = ProfileHomeInProgressTestsGrid.GetColumnFromList(2).Name;
                Assert.AreEqual(expected, actual, "Third Column Name in the Assess Dashboard In-Progress Tests Grid is not as expected.");

                expected = "Collection Status";
                actual = ProfileHomeInProgressTestsGrid.GetColumnFromList(3).Name;
                Assert.AreEqual(expected, actual, "Fourth Column Name in the Assess Dashboard In-Progress Tests Grid is not as expected.");
            }

            catch (Exception e)
            {
                TestContext.WriteLine("" + e.GetBaseException());
                throw new Exception("\nMessage:\n" + e.Message
                    + "\nInnerException:\n" + e.InnerException
                    + "\nStackTrace:\n" + e.StackTrace + "\n", e);
            }
        }

        [Test]
        public void SetRowListsTest()
        {
            this.SchoolNet().LoadWebPage();

            try
            {
                string gridCssSelector = "ProfileControl_InProgressTestResults_ctl00_gridResults";
                ProfileHomeInProgressTestsGrid ProfileHomeInProgressTestsGrid = new ProfileHomeInProgressTestsGrid(gridCssSelector, false);

                int expectedNumber = 0;
                int actualNumber = 0;
                string expected = null;
                string actual = null;

                ProfileHomeInProgressTestsGrid.SetColumnLists();
                ProfileHomeInProgressTestsGrid.SetRowLists();

                expectedNumber = 6;
                actualNumber = ProfileHomeInProgressTestsGrid.GetRowList().Count();
                Assert.AreEqual(expectedNumber, actualNumber, "Assess Dashboard In-Progress Tests Grid does not have the correct number of Rows.");

                expected = "Automated Test 1";
                actual = ((ProfileHomeInProgressTestsRow)ProfileHomeInProgressTestsGrid.GetRowFromList(1)).GetTestName();
                Assert.AreEqual(expected, actual, "First Column Data in the First Data Row of the Assess Dashboard In-Progress Tests Grid is incorrect");

                expected = "Automated Test 2";
                actual = ((ProfileHomeInProgressTestsRow)ProfileHomeInProgressTestsGrid.GetRowFromList(2)).GetTestName();
                Assert.AreEqual(expected, actual, "First Column Data in the Second Data Row of the Assess Dashboard In-Progress Tests Grid is incorrect");

                expected = "Automated Test 3";
                actual = ((ProfileHomeInProgressTestsRow)ProfileHomeInProgressTestsGrid.GetRowFromList(3)).GetTestName();
                Assert.AreEqual(expected, actual, "First Column Data in the Third Data Row of the Assess Dashboard In-Progress Tests Grid is incorrect");

                expected = "Automated Test 4";
                actual = ((ProfileHomeInProgressTestsRow)ProfileHomeInProgressTestsGrid.GetRowFromList(4)).GetTestName();
                Assert.AreEqual(expected, actual, "First Column Data in the Fourth Data Row of the Assess Dashboard In-Progress Tests Grid is incorrect");

                expected = "Automated Test 5";
                actual = ((ProfileHomeInProgressTestsRow)ProfileHomeInProgressTestsGrid.GetRowFromList(5)).GetTestName();
                Assert.AreEqual(expected, actual, "First Column Data in the Fifth Data Row of the Assess Dashboard In-Progress Tests Grid is incorrect");
            }

            catch (Exception e)
            {
                TestContext.WriteLine("" + e.GetBaseException());
                throw new Exception("\nMessage:\n" + e.Message
                    + "\nInnerException:\n" + e.InnerException
                    + "\nStackTrace:\n" + e.StackTrace + "\n", e);
            }
        }

        [Test]
        public void GetGridRowTypeTest()
        {
            this.SchoolNet().LoadWebPage();

            try
            {
                string gridCssSelector = "ProfileControl_InProgressTestResults_ctl00_gridResults";
                ProfileHomeInProgressTestsGrid ProfileHomeInProgressTestsGrid = new ProfileHomeInProgressTestsGrid(gridCssSelector, true);

                GridRowType expected;
                GridRowType actual;

                List<SNGridRow> ProfileHomeInProgressTestsGridRowList = ProfileHomeInProgressTestsGrid.GetRowList();

                foreach (SNGridRow ProfileHomeInProgressTestsGridRow in ProfileHomeInProgressTestsGridRowList)
                {
                    if (ProfileHomeInProgressTestsGridRow.Index == 0)
                    {
                        expected = GridRowType.Header;
                        actual = ProfileHomeInProgressTestsGrid.GetGridRowType(ProfileHomeInProgressTestsGridRow.Index);
                        Assert.AreEqual(expected, actual, "First Row of the Assess Dashboard In-Progress Tests Grid is not a Header Row");
                    }

                    else
                    {
                        expected = GridRowType.Data;
                        actual = ProfileHomeInProgressTestsGrid.GetGridRowType(ProfileHomeInProgressTestsGridRow.Index);
                        Assert.AreEqual(expected, actual,
                            string.Format("Row  with Index '{0}' of the Assess Dashboard In-Progress Tests Grid is not a Data Row", ProfileHomeInProgressTestsGridRow.Index.ToString()));
                    }
                }
            }

            catch (Exception e)
            {
                TestContext.WriteLine("" + e.GetBaseException());
                throw new Exception("\nMessage:\n" + e.Message
                    + "\nInnerException:\n" + e.InnerException
                    + "\nStackTrace:\n" + e.StackTrace + "\n", e);
            }
        }

        [Test]
        public void GetsFirstRowContainingTextToFindFromListTest()
        {
            this.SchoolNet().LoadWebPage();

            try
            {
                string gridCssSelector = "ProfileControl_InProgressTestResults_ctl00_gridResults";
                ProfileHomeInProgressTestsGrid ProfileHomeInProgressTestsGrid = new ProfileHomeInProgressTestsGrid(gridCssSelector, true);

                string expected = null;
                string actual = null;

                expected = "Automated Test 1";
                actual = ProfileHomeInProgressTestsGrid.GetsFirstRowContainingTextToFindFromList(ProfileHomeInProgressTestsGrid.GetColumnFromList(0).Name, expected).GetTestName();
                Assert.AreEqual(expected, actual, "First Column Data in the First Data Row of the Assess Dashboard In-Progress Tests Grid is incorrect");

                expected = "Automated Test 2";
                actual = ProfileHomeInProgressTestsGrid.GetsFirstRowContainingTextToFindFromList(ProfileHomeInProgressTestsGrid.GetColumnFromList(0).Name, expected).GetTestName();
                Assert.AreEqual(expected, actual, "First Column Data in the Second Data Row of the Assess Dashboard In-Progress Tests Grid is incorrect");

                expected = "Automated Test 3";
                actual = ProfileHomeInProgressTestsGrid.GetsFirstRowContainingTextToFindFromList(ProfileHomeInProgressTestsGrid.GetColumnFromList(0).Name, expected).GetTestName();
                Assert.AreEqual(expected, actual, "First Column Data in the Third Data Row of the Assess Dashboard In-Progress Tests Grid is incorrect");

                expected = "Automated Test 4";
                actual = ProfileHomeInProgressTestsGrid.GetsFirstRowContainingTextToFindFromList(ProfileHomeInProgressTestsGrid.GetColumnFromList(0).Name, expected).GetTestName();
                Assert.AreEqual(expected, actual, "First Column Data in the Fourth Data Row of the Assess Dashboard In-Progress Tests Grid is incorrect");

                expected = "Automated Test 5";
                actual = ProfileHomeInProgressTestsGrid.GetsFirstRowContainingTextToFindFromList(ProfileHomeInProgressTestsGrid.GetColumnFromList(0).Name, expected).GetTestName();
                Assert.AreEqual(expected, actual, "First Column Data in the Fifth Data Row of the Assess Dashboard In-Progress Tests Grid is incorrect");
            }

            catch (Exception e)
            {
                TestContext.WriteLine("" + e.GetBaseException());
                throw new Exception("\nMessage:\n" + e.Message
                    + "\nInnerException:\n" + e.InnerException
                    + "\nStackTrace:\n" + e.StackTrace + "\n", e);
            }
        }

        [Test]
        public void GetsRowsContainingTextToFindFromListTest()
        {
            this.SchoolNet().LoadWebPage();

            try
            {
                string gridCssSelector = "ProfileControl_InProgressTestResults_ctl00_gridResults";
                ProfileHomeInProgressTestsGrid ProfileHomeInProgressTestsGrid = new ProfileHomeInProgressTestsGrid(gridCssSelector, true);

                int expectedNumber = 0;
                int actualNumber = 0;
                string testName = null;

                testName = "Automated Test 1";
                expectedNumber = 1;
                actualNumber =
                    ProfileHomeInProgressTestsGrid.GetsRowsContainingTextToFindFromList(
                        ProfileHomeInProgressTestsGrid.GetColumnFromList(0).Name, testName).Count();
                Assert.AreEqual(expectedNumber, actualNumber,
                    string.Format("Incorrect number of rows returned for the Test Name '{0}' from the Assess Dashboard In-Progress Tests Grid", testName));

                testName = "Automated Test 2";
                expectedNumber = 1;
                actualNumber =
                    ProfileHomeInProgressTestsGrid.GetsRowsContainingTextToFindFromList(
                        ProfileHomeInProgressTestsGrid.GetColumnFromList(0).Name, testName).Count();
                Assert.AreEqual(expectedNumber, actualNumber,
                    string.Format("Incorrect number of rows returned for the Test Name '{0}' from the Assess Dashboard In-Progress Tests Grid", testName));

                testName = "Automated Test 3";
                expectedNumber = 1;
                actualNumber =
                    ProfileHomeInProgressTestsGrid.GetsRowsContainingTextToFindFromList(
                        ProfileHomeInProgressTestsGrid.GetColumnFromList(0).Name, testName).Count();
                Assert.AreEqual(expectedNumber, actualNumber,
                    string.Format("Incorrect number of rows returned for the Test Name '{0}' from the Assess Dashboard In-Progress Tests Grid", testName));

                testName = "Automated Test 4";
                expectedNumber = 1;
                actualNumber =
                    ProfileHomeInProgressTestsGrid.GetsRowsContainingTextToFindFromList(
                        ProfileHomeInProgressTestsGrid.GetColumnFromList(0).Name, testName).Count();
                Assert.AreEqual(expectedNumber, actualNumber,
                    string.Format("Incorrect number of rows returned for the Test Name '{0}' from the Assess Dashboard In-Progress Tests Grid", testName));

                testName = "Automated Test 5";
                expectedNumber = 1;
                actualNumber =
                    ProfileHomeInProgressTestsGrid.GetsRowsContainingTextToFindFromList(
                        ProfileHomeInProgressTestsGrid.GetColumnFromList(0).Name, testName).Count();
                Assert.AreEqual(expectedNumber, actualNumber,
                    string.Format("Incorrect number of rows returned for the Test Name '{0}' from the Assess Dashboard In-Progress Tests Grid", testName));

            }

            catch (Exception e)
            {
                TestContext.WriteLine("" + e.GetBaseException());
                throw new Exception("\nMessage:\n" + e.Message
                    + "\nInnerException:\n" + e.InnerException
                    + "\nStackTrace:\n" + e.StackTrace + "\n", e);
            }
        }
    }
}
