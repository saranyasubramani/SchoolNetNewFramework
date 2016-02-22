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
using UITests.Pages.Assess.Dashboard.ProfileHome.MyTests;

namespace UnitTests.Pages.Assess.Dashboard.Components
{
    [TestFixture]
    [Parallelizable(ParallelScope.Children)]
    public class ProfileHomeMyTestsGridTests: TestRunner
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
        public void AssessDashboardMyTestsGridTest()
        {
            this.SchoolNet().LoadWebPage();

            try
            {
                string gridCssSelector = "ProfileControl_MyTestResults_ctl00_gridResults";
                ProfileHomeMyTestsGrid assessDashboardMyTestsGrid = new ProfileHomeMyTestsGrid(gridCssSelector, true);

                int expectedNumber = 0;
                int actualNumber = 0;
                string expected = null;
                string actual = null;

                expectedNumber = 4;
                actualNumber = assessDashboardMyTestsGrid.GetColumnList().Count();
                Assert.AreEqual(expectedNumber, actualNumber, "Assess Dashboard My Tests Grid does not have the correct number of columns.");

                expectedNumber = 6;
                actualNumber = assessDashboardMyTestsGrid.GetRowList().Count();
                Assert.AreEqual(expectedNumber, actualNumber, "Assess Dashboard My Tests Grid does not have the correct number of Rows.");

                expected = "Test Name";
                actual = assessDashboardMyTestsGrid.GetColumnFromList(0).Name;
                Assert.AreEqual(expected, actual, "First Column Name in the Assess Dashboard My Tests Grid is not as expected.");

                expected = "# of Items";
                actual = assessDashboardMyTestsGrid.GetColumnFromList(1).Name;
                Assert.AreEqual(expected, actual, "Second Column Name in the Assess Dashboard My Tests Grid is not as expected.");

                expected = "Test Stage";
                actual = assessDashboardMyTestsGrid.GetColumnFromList(2).Name;
                Assert.AreEqual(expected, actual, "Third Column Name in the Assess Dashboard My Tests Grid is not as expected.");

                expected = "Modified Date";
                actual = assessDashboardMyTestsGrid.GetColumnFromList(3).Name;
                Assert.AreEqual(expected, actual, "Fourth Column Name in the Assess Dashboard My Tests Grid is not as expected.");

                expected = "Automated Test 1";
                actual = assessDashboardMyTestsGrid.GetsFirstRowContainingTextToFindFromList(assessDashboardMyTestsGrid.GetColumnFromList(0).Name, expected).GetTestName();
                Assert.AreEqual(expected, actual, "First Column Data in the First Data Row of the Assess Dashboard My Tests Grid is incorrect");

                expected = "Automated Test 2";
                actual = assessDashboardMyTestsGrid.GetsFirstRowContainingTextToFindFromList(assessDashboardMyTestsGrid.GetColumnFromList(0).Name, expected).GetTestName();
                Assert.AreEqual(expected, actual, "First Column Data in the Second Data Row of the Assess Dashboard My Tests Grid is incorrect");

                expected = "Automated Test 3";
                actual = assessDashboardMyTestsGrid.GetsFirstRowContainingTextToFindFromList(assessDashboardMyTestsGrid.GetColumnFromList(0).Name, expected).GetTestName();
                Assert.AreEqual(expected, actual, "First Column Data in the Third Data Row of the Assess Dashboard My Tests Grid is incorrect");

                expected = "Automated Test 4";
                actual = assessDashboardMyTestsGrid.GetsFirstRowContainingTextToFindFromList(assessDashboardMyTestsGrid.GetColumnFromList(0).Name, expected).GetTestName();
                Assert.AreEqual(expected, actual, "First Column Data in the Fourth Data Row of the Assess Dashboard My Tests Grid is incorrect");

                expected = "Automated Test 5";
                actual = assessDashboardMyTestsGrid.GetsFirstRowContainingTextToFindFromList(assessDashboardMyTestsGrid.GetColumnFromList(0).Name, expected).GetTestName();
                Assert.AreEqual(expected, actual, "First Column Data in the Fifth Data Row of the Assess Dashboard My Tests Grid is incorrect");
            }

            catch (Exception e)
            {
                throw new Exception("" + e.GetBaseException());
            }
        }

        [Test]
        public void GetDummyElementsColumnsTest()
        {
            this.SchoolNet().LoadWebPage();

            try
            {
                string gridCssSelector = "ProfileControl_MyTestResults_ctl00_gridResults";
                ProfileHomeMyTestsGrid assessDashboardMyTestsGrid = new ProfileHomeMyTestsGrid(gridCssSelector, true);

                int expectedNumber = 0;
                int actualNumber = 0;
                string expected = null;
                string actual = null;

                expectedNumber = 4;
                actualNumber = assessDashboardMyTestsGrid.GetDummyElementsColumns().Count();
                Assert.AreEqual(expectedNumber, actualNumber, "Assess Dashboard My Tests Grid Dummy Column List does not have the correct number of columns.");

                expected = "Test Name";
                actual = assessDashboardMyTestsGrid.GetDummyElementsColumns()[0].Text;
                Assert.AreEqual(expected, actual, "Incorrect Column Name for the first column in the Assess Dashboard My Tests Grid Dummy Column List.");

                expected = "# of Items";
                actual = assessDashboardMyTestsGrid.GetDummyElementsColumns()[1].Text;
                Assert.AreEqual(expected, actual, "Incorrect Column Name for the second column in the Assess Dashboard My Tests Grid Dummy Column List.");

                expected = "Test Stage";
                actual = assessDashboardMyTestsGrid.GetDummyElementsColumns()[2].Text;
                Assert.AreEqual(expected, actual, "Incorrect Column Name for the third column in the Assess Dashboard My Tests Grid Dummy Column List.");

                expected = "Modified Date";
                actual = assessDashboardMyTestsGrid.GetDummyElementsColumns()[3].Text;
                Assert.AreEqual(expected, actual, "Incorrect Column Name for the fourth column in the Assess Dashboard My Tests Grid Dummy Column List.");
            }

            catch (Exception e)
            {
                throw new Exception("" + e.GetBaseException());
            }
        }

        [Test]
        public void GetDummyElementsPaginationRowsTest()
        {
            this.SchoolNet().LoadWebPage();

            try
            {
                string gridCssSelector = "ProfileControl_MyTestResults_ctl00_gridResults";
                ProfileHomeMyTestsGrid assessDashboardMyTestsGrid = new ProfileHomeMyTestsGrid(gridCssSelector, true);

                Assert.IsNull(assessDashboardMyTestsGrid.GetDummyElementsPaginationRows(), "Assess Dashboard My Tests Grid Dummy Pagination Rows Count is not zero.");
            }

            catch (Exception e)
            {
                throw new Exception("" + e.GetBaseException());
            }
        }

        [Test]
        public void GetDummyElementsHeaderRowsTest()
        {
            this.SchoolNet().LoadWebPage();

            try
            {
                string gridCssSelector = "ProfileControl_MyTestResults_ctl00_gridResults";
                ProfileHomeMyTestsGrid assessDashboardMyTestsGrid = new ProfileHomeMyTestsGrid(gridCssSelector, true);

                int expectedNumber = 0;
                int actualNumber = 0;
                string expected = null;
                string actual = null;

                expectedNumber = 1;
                actualNumber = assessDashboardMyTestsGrid.GetDummyElementsHeaderRows().Count();
                Assert.AreEqual(expectedNumber, actualNumber, "Assess Dashboard My Tests Grid Dummy Header Rows List does not have the correct number of Header Rows.");

                expected = "<th>Test Name</th><th># of Items</th><th>Test Stage</th><th>Modified Date</th>";
                actual = assessDashboardMyTestsGrid.GetDummyElementsHeaderRows()[0].Text;
                Assert.AreEqual(expected, actual, "First Row in the Assess Dashboard My Tests Grid Dummy Header Rows List does not have the correct text.");
            }

            catch (Exception e)
            {
                throw new Exception("" + e.GetBaseException());
            }
        }

        [Test]
        public void GetDummyElementsDataRowsTest()
        {
            this.SchoolNet().LoadWebPage();

            try
            {
                string gridCssSelector = "ProfileControl_MyTestResults_ctl00_gridResults";
                ProfileHomeMyTestsGrid assessDashboardMyTestsGrid = new ProfileHomeMyTestsGrid(gridCssSelector, true);

                int expectedNumber = 0;
                int actualNumber = 0;
                string expected = null;
                string actual = null;

                expectedNumber = 5;
                actualNumber = assessDashboardMyTestsGrid.GetDummyElementsDataRows().Count();
                Assert.AreEqual(expectedNumber, actualNumber, "Assess Dashboard My Tests Grid Dummy Data Rows List does not have the correct number of Data Rows.");

                expected = "Automated Test 1";
                actual = assessDashboardMyTestsGrid.GetDummyElementsDataRows()[0].Text;
                Assert.AreEqual(expected, actual, "First Column Data in the First Data Row of the Assess Dashboard My Tests Grid Dummy Data Rows List is incorrect");

                expected = "Automated Test 2";
                actual = assessDashboardMyTestsGrid.GetDummyElementsDataRows()[1].Text;
                Assert.AreEqual(expected, actual, "First Column Data in the Second Data Row of the Assess Dashboard My Tests Grid Dummy Data Rows List is incorrect");

                expected = "Automated Test 3";
                actual = assessDashboardMyTestsGrid.GetDummyElementsDataRows()[2].Text;
                Assert.AreEqual(expected, actual, "First Column Data in the Third Data Row of the Assess Dashboard My Tests Grid Dummy Data Rows List is incorrect");

                expected = "Automated Test 4";
                actual = assessDashboardMyTestsGrid.GetDummyElementsDataRows()[3].Text;
                Assert.AreEqual(expected, actual, "First Column Data in the Fourth Data Row of the Assess Dashboard My Tests Grid Dummy Data Rows List is incorrect");

                expected = "Automated Test 5";
                actual = assessDashboardMyTestsGrid.GetDummyElementsDataRows()[4].Text;
                Assert.AreEqual(expected, actual, "First Column Data in the Fifth Data Row of the Assess Dashboard My Tests Grid Dummy Data Rows List is incorrect");
            }

            catch (Exception e)
            {
                throw new Exception("" + e.GetBaseException());
            }
        }

        [Test]
        public void SetColumnListsTest()
        {
            this.SchoolNet().LoadWebPage();

            try
            {
                string gridCssSelector = "ProfileControl_MyTestResults_ctl00_gridResults";
                ProfileHomeMyTestsGrid assessDashboardMyTestsGrid = new ProfileHomeMyTestsGrid(gridCssSelector, false);

                int expectedNumber = 0;
                int actualNumber = 0;
                string expected = null;
                string actual = null;

                assessDashboardMyTestsGrid.SetColumnLists();

                expectedNumber = 4;
                actualNumber = assessDashboardMyTestsGrid.GetColumnList().Count();
                Assert.AreEqual(expectedNumber, actualNumber, "Assess Dashboard My Tests Grid does not have the correct number of columns.");

                expected = "Test Name";
                actual = assessDashboardMyTestsGrid.GetColumnFromList(0).Name;
                Assert.AreEqual(expected, actual, "First Column Name in the Assess Dashboard My Tests Grid is not as expected.");

                expected = "# of Items";
                actual = assessDashboardMyTestsGrid.GetColumnFromList(1).Name;
                Assert.AreEqual(expected, actual, "Second Column Name in the Assess Dashboard My Tests Grid is not as expected.");

                expected = "Test Stage";
                actual = assessDashboardMyTestsGrid.GetColumnFromList(2).Name;
                Assert.AreEqual(expected, actual, "Third Column Name in the Assess Dashboard My Tests Grid is not as expected.");

                expected = "Modified Date";
                actual = assessDashboardMyTestsGrid.GetColumnFromList(3).Name;
                Assert.AreEqual(expected, actual, "Fourth Column Name in the Assess Dashboard My Tests Grid is not as expected.");
            }

            catch (Exception e)
            {
                throw new Exception("" + e.GetBaseException());
            }
        }

        [Test]
        public void SetRowListsTest()
        {
            this.SchoolNet().LoadWebPage();

            try
            {
                string gridCssSelector = "ProfileControl_MyTestResults_ctl00_gridResults";
                ProfileHomeMyTestsGrid assessDashboardMyTestsGrid = new ProfileHomeMyTestsGrid(gridCssSelector, false);

                int expectedNumber = 0;
                int actualNumber = 0;
                string expected = null;
                string actual = null;

                assessDashboardMyTestsGrid.SetColumnLists();
                assessDashboardMyTestsGrid.SetRowLists();

                expectedNumber = 6;
                actualNumber = assessDashboardMyTestsGrid.GetRowList().Count();
                Assert.AreEqual(expectedNumber, actualNumber, "Assess Dashboard My Tests Grid does not have the correct number of Rows.");

                expected = "Automated Test 1";
                actual = ((ProfileHomeMyTestsRow)assessDashboardMyTestsGrid.GetRowFromList(1)).GetTestName();
                Assert.AreEqual(expected, actual, "First Column Data in the First Data Row of the Assess Dashboard My Tests Grid is incorrect");

                expected = "Automated Test 2";
                actual = ((ProfileHomeMyTestsRow)assessDashboardMyTestsGrid.GetRowFromList(2)).GetTestName();
                Assert.AreEqual(expected, actual, "First Column Data in the Second Data Row of the Assess Dashboard My Tests Grid is incorrect");

                expected = "Automated Test 3";
                actual = ((ProfileHomeMyTestsRow)assessDashboardMyTestsGrid.GetRowFromList(3)).GetTestName();
                Assert.AreEqual(expected, actual, "First Column Data in the Third Data Row of the Assess Dashboard My Tests Grid is incorrect");

                expected = "Automated Test 4";
                actual = ((ProfileHomeMyTestsRow)assessDashboardMyTestsGrid.GetRowFromList(4)).GetTestName();
                Assert.AreEqual(expected, actual, "First Column Data in the Fourth Data Row of the Assess Dashboard My Tests Grid is incorrect");

                expected = "Automated Test 5";
                actual = ((ProfileHomeMyTestsRow)assessDashboardMyTestsGrid.GetRowFromList(5)).GetTestName();
                Assert.AreEqual(expected, actual, "First Column Data in the Fifth Data Row of the Assess Dashboard My Tests Grid is incorrect");
            }

            catch (Exception e)
            {
                throw new Exception("" + e.GetBaseException());
            }
        }

        [Test]
        public void GetGridRowTypeTest()
        {
            this.SchoolNet().LoadWebPage();

            try
            {
                string gridCssSelector = "ProfileControl_MyTestResults_ctl00_gridResults";
                ProfileHomeMyTestsGrid assessDashboardMyTestsGrid = new ProfileHomeMyTestsGrid(gridCssSelector, true);

                GridRowType expected;
                GridRowType actual;

                List<SNGridRow> assessDashboardMyTestsGridRowList = assessDashboardMyTestsGrid.GetRowList();

                foreach (SNGridRow assessDashboardMyTestsGridRow in assessDashboardMyTestsGridRowList)
                {
                    if (assessDashboardMyTestsGridRow.Index == 0)
                    {
                        expected = GridRowType.Header;
                        actual = assessDashboardMyTestsGrid.GetGridRowType(assessDashboardMyTestsGridRow.Index);
                        Assert.AreEqual(expected, actual, "First Row of the Assess Dashboard My Tests Grid is not a Header Row");
                    }

                    else
                    {
                        expected = GridRowType.Data;
                        actual = assessDashboardMyTestsGrid.GetGridRowType(assessDashboardMyTestsGridRow.Index);
                        Assert.AreEqual(expected, actual,
                            string.Format("Row  with Index '{0}' of the Assess Dashboard My Tests Grid is not a Data Row", assessDashboardMyTestsGridRow.Index.ToString()));
                    }
                }
            }

            catch (Exception e)
            {
                throw new Exception("" + e.GetBaseException());
            }
        }

        [Test]
        public void GetsFirstRowContainingTextToFindFromListTest()
        {
            this.SchoolNet().LoadWebPage();

            try
            {
                string gridCssSelector = "ProfileControl_MyTestResults_ctl00_gridResults";
                ProfileHomeMyTestsGrid assessDashboardMyTestsGrid = new ProfileHomeMyTestsGrid(gridCssSelector, true);

                string expected = null;
                string actual = null;

                expected = "Automated Test 1";
                actual = assessDashboardMyTestsGrid.GetsFirstRowContainingTextToFindFromList(assessDashboardMyTestsGrid.GetColumnFromList(0).Name, expected).GetTestName();
                Assert.AreEqual(expected, actual, "First Column Data in the First Data Row of the Assess Dashboard My Tests Grid is incorrect");

                expected = "Automated Test 2";
                actual = assessDashboardMyTestsGrid.GetsFirstRowContainingTextToFindFromList(assessDashboardMyTestsGrid.GetColumnFromList(0).Name, expected).GetTestName();
                Assert.AreEqual(expected, actual, "First Column Data in the Second Data Row of the Assess Dashboard My Tests Grid is incorrect");

                expected = "Automated Test 3";
                actual = assessDashboardMyTestsGrid.GetsFirstRowContainingTextToFindFromList(assessDashboardMyTestsGrid.GetColumnFromList(0).Name, expected).GetTestName();
                Assert.AreEqual(expected, actual, "First Column Data in the Third Data Row of the Assess Dashboard My Tests Grid is incorrect");

                expected = "Automated Test 4";
                actual = assessDashboardMyTestsGrid.GetsFirstRowContainingTextToFindFromList(assessDashboardMyTestsGrid.GetColumnFromList(0).Name, expected).GetTestName();
                Assert.AreEqual(expected, actual, "First Column Data in the Fourth Data Row of the Assess Dashboard My Tests Grid is incorrect");

                expected = "Automated Test 5";
                actual = assessDashboardMyTestsGrid.GetsFirstRowContainingTextToFindFromList(assessDashboardMyTestsGrid.GetColumnFromList(0).Name, expected).GetTestName();
                Assert.AreEqual(expected, actual, "First Column Data in the Fifth Data Row of the Assess Dashboard My Tests Grid is incorrect");
            }

            catch (Exception e)
            {
                throw new Exception("" + e.GetBaseException());
            }
        }

        [Test]
        public void GetsRowsContainingTextToFindFromListTest()
        {
            this.SchoolNet().LoadWebPage();

            try
            {
                string gridCssSelector = "ProfileControl_MyTestResults_ctl00_gridResults";
                ProfileHomeMyTestsGrid assessDashboardMyTestsGrid = new ProfileHomeMyTestsGrid(gridCssSelector, true);

                int expectedNumber = 0;
                int actualNumber = 0;
                string testName = null;

                testName = "Automated Test 1";
                expectedNumber = 1;
                actualNumber =
                    assessDashboardMyTestsGrid.GetsRowsContainingTextToFindFromList(
                        assessDashboardMyTestsGrid.GetColumnFromList(0).Name, testName).Count();
                Assert.AreEqual(expectedNumber, actualNumber,
                    string.Format("Incorrect number of rows returned for the Test Name '{0}' from the Assess Dashboard My Tests Grid", testName));

                testName = "Automated Test 2";
                expectedNumber = 1;
                actualNumber =
                    assessDashboardMyTestsGrid.GetsRowsContainingTextToFindFromList(
                        assessDashboardMyTestsGrid.GetColumnFromList(0).Name, testName).Count();
                Assert.AreEqual(expectedNumber, actualNumber,
                    string.Format("Incorrect number of rows returned for the Test Name '{0}' from the Assess Dashboard My Tests Grid", testName));

                testName = "Automated Test 3";
                expectedNumber = 1;
                actualNumber =
                    assessDashboardMyTestsGrid.GetsRowsContainingTextToFindFromList(
                        assessDashboardMyTestsGrid.GetColumnFromList(0).Name, testName).Count();
                Assert.AreEqual(expectedNumber, actualNumber,
                    string.Format("Incorrect number of rows returned for the Test Name '{0}' from the Assess Dashboard My Tests Grid", testName));

                testName = "Automated Test 4";
                expectedNumber = 1;
                actualNumber =
                    assessDashboardMyTestsGrid.GetsRowsContainingTextToFindFromList(
                        assessDashboardMyTestsGrid.GetColumnFromList(0).Name, testName).Count();
                Assert.AreEqual(expectedNumber, actualNumber,
                    string.Format("Incorrect number of rows returned for the Test Name '{0}' from the Assess Dashboard My Tests Grid", testName));

                testName = "Automated Test 5";
                expectedNumber = 1;
                actualNumber =
                    assessDashboardMyTestsGrid.GetsRowsContainingTextToFindFromList(
                        assessDashboardMyTestsGrid.GetColumnFromList(0).Name, testName).Count();
                Assert.AreEqual(expectedNumber, actualNumber,
                    string.Format("Incorrect number of rows returned for the Test Name '{0}' from the Assess Dashboard My Tests Grid", testName));

            }

            catch (Exception e)
            {
                throw new Exception("" + e.GetBaseException());
            }
        }
    }
}
