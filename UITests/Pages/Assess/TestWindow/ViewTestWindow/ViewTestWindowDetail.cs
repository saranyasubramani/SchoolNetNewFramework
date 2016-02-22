using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;

namespace UITests.Pages.Assess.TestWindow.ViewTestWindow
{
    /// <summary>
    /// the view test window detail
    /// </summary>
    public class ViewTestWindowDetail : SNDetail
    {
        /// <summary>
        /// the view test window constructor
        /// </summary>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public ViewTestWindowDetail(string overrideControlPrefix = null)
            : base()
        {
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            EditTestWindow = new WebElementWrapper(ByEditTestWindow);
            DeleteTestWindow = new WebElementWrapper(ByDeleteTestWindow);
            CreateTestWindow = new WebElementWrapper(ByCreateTestWindow);
            TestWindowNameLabel = new WebElementWrapper(ByTestWindowNameLabel);
            StartDateLabel = new WebElementWrapper(ByStartDateLabel);
            EndDateLabel = new WebElementWrapper(ByEndDateLabel);
            DescriptionLabel = new WebElementWrapper(ByDescriptionLabel);
            SubjectLabel = new WebElementWrapper(BySubjectLabel);
            GradeLevelLabel = new WebElementWrapper(ByGradeLevelLabel);
            ViewDetailsLink = new WebElementWrapper(ByViewDetailsLink);
            UnlinkButton = new WebElementWrapper(ByUnlinkButton);
            PreviousPage = new WebElementWrapper(ByPreviousPage);
            Grid = new ViewTestWindowGrid(GridLocator);
        }

        /// <summary>
        /// the data
        /// </summary>
        public new ViewTestWindowData Data
        {
            get
            {
                return (ViewTestWindowData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        /// <summary>
        /// fake text
        /// </summary>
        public string FakeText { get; set; }
        //ctl00_MainContent_TestSearchResults1_TestFinderResults1_gridResults
        private string GridLocator { get { return "#" + ControlPrefix + "TestSearchResults1_TestFinderResults1_gridResults"; } }
        public ViewTestWindowGrid Grid { get; set; }
        //ctl00_MainContent_ButtonEdit
        private By ByEditTestWindow { get { return By.Id(ControlPrefix + "ButtonEdit"); } }
        private WebElementWrapper EditTestWindow { get; set; }
        //ctl00_MainContent_ButtonDelete
        private By ByDeleteTestWindow { get { return By.Id(ControlPrefix + "ButtonDelete"); } }
        private WebElementWrapper DeleteTestWindow { get; set; }
        //ctl00_MainContent_TestSearchResults1_TestFinderSearch1_ButtonCreateTest
        private By ByCreateTestWindow { get { return By.Id(ControlPrefix + "TestSearchResults1_TestFinderSearch1_ButtonCreateTest"); } }
        private WebElementWrapper CreateTestWindow { get; set; }
        //ctl00_MainContent_LabelTestWindowName
        private By ByTestWindowNameLabel { get { return By.Id(ControlPrefix + "LabelTestWindowName"); } }
        private WebElementWrapper TestWindowNameLabel { get; set; }
        //ctl00_MainContent_LabelStartDate
        private By ByStartDateLabel { get { return By.Id(ControlPrefix + "LabelStartDate"); } }
        private WebElementWrapper StartDateLabel { get; set; }
        //ctl00_MainContent_LabelEndDate
        private By ByEndDateLabel { get { return By.Id(ControlPrefix + "LabelEndDate"); } }
        private WebElementWrapper EndDateLabel { get; set; }
        //ctl00_MainContent_LabelDescription
        private By ByDescriptionLabel { get { return By.Id(ControlPrefix + "LabelDescription"); } }
        private WebElementWrapper DescriptionLabel { get; set; }
        //ctl00_MainContent_LabelSubject
        private By BySubjectLabel { get { return By.Id(ControlPrefix + "LabelSubject"); } }
        private WebElementWrapper SubjectLabel { get; set; }
        //ctl00_MainContent_LabelGradeLevel
        private By ByGradeLevelLabel { get { return By.Id(ControlPrefix + "LabelGradeLevel"); } }
        private WebElementWrapper GradeLevelLabel { get; set; }
        //ctl00_MainContent_SelectedTestDisplayControl_HyperLinkViewDetails
        private By ByViewDetailsLink { get { return By.Id(ControlPrefix + "SelectedTestDisplayControl_HyperLinkViewDetails"); } }
        private WebElementWrapper ViewDetailsLink { get; set; }
        //".CommandButton[value='Unlink']"
        private By ByUnlinkButton { get { return By.CssSelector(".CommandButton[value='Unlink']"); } }
        private WebElementWrapper UnlinkButton { get; set; }
        //ctl00_MainContent_BackToPreviousPageControl_HyperLinkBackText
        private By ByPreviousPage { get { return By.Id(ControlPrefix + "BackToPreviousPageControl_HyperLinkBackText"); } }
        private WebElementWrapper PreviousPage { get; set; }

        #region Grid

        /// <summary>
        /// click on select link 
        /// Index begin at 1, 2, 3...
        /// </summary>
        public void SelectTestUsingSelectLink(int index)
        {
            Grid.SetGridLists();

            ViewTestWindowRow testFound = Grid.GetDataRow(index);

            if (testFound != null)
            {
                Report.Write("Found test: " + testFound + ". Attempting to click on select link.");
                testFound.SelectSelectLink();
            }
        }

        /// <summary>
        /// click on test name link 
        /// Index begin at 1, 2, 3...
        /// </summary>
        public void SelectTestByTestname(string testname)
        {
            Grid.SetGridLists();

            List<ViewTestWindowRow> testFound =
                Grid.GetsRowsContainingTextToFindFromList(ViewTestWindowColumnNames.TestName, testname);

            if (testFound != null)
            {
                Report.Write("Found test: " + testname + ". Attempting to click on test name link.");
                testFound[0].SelectTestName();
            }
        }

        #endregion

        /// <summary>
        /// get the test window name text
        /// </summary>
        /// <returns>text</returns>
        public string GetTestWindowName()
        {
            TestWindowNameLabel.Wait(2);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                TestWindowNameLabel.Text = FakeText;
            }
            return TestWindowNameLabel.Text;
        }
        /// <summary>
        /// get the start date text
        /// </summary>
        /// <returns>text</returns>
        public string GetStartDate()
        {
            StartDateLabel.Wait(2);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                StartDateLabel.Text = FakeText;
            }
            return StartDateLabel.Text;
        }
        /// <summary>
        /// get the end date text
        /// </summary>
        /// <returns>text</returns>
        public string GetEndDate()
        {
            EndDateLabel.Wait(2);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                EndDateLabel.Text = FakeText;
            }
            return EndDateLabel.Text;
        }
        /// <summary>
        /// get the description text
        /// </summary>
        /// <returns>text</returns>
        public string GetDescription()
        {
            DescriptionLabel.Wait(2);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                DescriptionLabel.Text = FakeText;
            }
            return DescriptionLabel.Text;
        }
        /// <summary>
        /// get the subject text
        /// </summary>
        /// <returns>text</returns>
        public string GetSubject()
        {
            SubjectLabel.Wait(2);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                SubjectLabel.Text = FakeText;
            }
            return SubjectLabel.Text;
        }
        /// <summary>
        /// get the grade text
        /// </summary>
        /// <returns>text</returns>
        public string GetGrade()
        {
            GradeLevelLabel.Wait(2);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                GradeLevelLabel.Text = FakeText;
            }
            return GradeLevelLabel.Text;
        }
        /// <summary>
        /// click on edit test window
        /// </summary>
        public void SelectEditTestWindow()
        {
            EditTestWindow.Wait(3).Click();
        }
        /// <summary>
        /// click on delete test window
        /// </summary>
        public void SelectDeleteTestWindow()
        {
            DeleteTestWindow.Wait(3).Click();
        }
        /// <summary>
        /// click on create test window
        /// </summary>
        public void SelectCreateTestWindow()
        {
            CreateTestWindow.Wait(3).Click();
        }
        /// <summary>
        /// click on view details
        /// </summary>
        public void SelectViewDetails()
        {
            ViewDetailsLink.Wait(3).Click();
        }
        /// <summary>
        /// click on unlink button
        /// </summary>
        public void SelectUnlink()
        {
            UnlinkButton.Wait(3).Click();
        }
        /// <summary>
        /// click on back to previous page
        /// </summary>
        public void SelectBackToPreviousPage()
        {
            PreviousPage.Wait(3).Click();
        }

        //implemented methods
        public void VerifyContentExists(List<ViewTestWindowFields> verifiedFields)
        {
            string actualText = "";
            foreach (var field in verifiedFields)
            {
                if (field.Equals(ViewTestWindowFields.TestWindowNameLabel))
                {
                    if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
                    {
                        FakeText = Data.TestWindowName;
                    }
                    actualText = GetTestWindowName();
                    Assert.IsTrue(actualText.Contains(Data.TestWindowName), "The expected test window name '"
                        + Data.TestWindowName + "' was not found in actual test window label '"
                        + actualText + "'.");
                }
                if (field.Equals(ViewTestWindowFields.StartDateLabel))
                {
                    if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
                    {
                        FakeText = Data.DateFrom;
                    }
                    actualText = GetStartDate();
                    Assert.IsTrue(actualText.Contains(Data.DateFrom), "The expected start date '"
                        + Data.DateFrom + "' was not found in actual start date label '"
                        + actualText + "'.");
                }
                if (field.Equals(ViewTestWindowFields.EndDateLabel))
                {
                    if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
                    {
                        FakeText = Data.DateTo;
                    }
                    actualText = GetEndDate();
                    Assert.IsTrue(actualText.Contains(Data.DateTo), "The expected end date '"
                        + Data.DateTo + "' was not found in actual end date label '"
                        + actualText + "'.");
                }
                if (field.Equals(ViewTestWindowFields.DescriptionLabel))
                {
                    if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
                    {
                        FakeText = Data.Description;
                    }
                    actualText = GetDescription();
                    Assert.IsTrue(actualText.Contains(Data.Description), "The expected description '"
                        + Data.Description + "' was not found in actual description label '"
                        + actualText + "'.");
                }
                if (field.Equals(ViewTestWindowFields.SubjectLabel))
                {
                    if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
                    {
                        FakeText = Data.Subject;
                    }
                    actualText = GetSubject();
                    Assert.IsTrue(actualText.Contains(Data.Subject), "The expected subject '"
                        + Data.Subject + "' was not found in actual subject label '"
                        + actualText + "'.");
                }
                if (field.Equals(ViewTestWindowFields.GradeLevelLabel))
                {
                    if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
                    {
                        FakeText = Data.GradeLow + " - " + Data.GradeHigh;
                    }
                    actualText = GetGrade();
                    bool foundGradesRange = actualText.Contains(Data.GradeLow) &&
                                            actualText.Contains(Data.GradeHigh);
                    Assert.IsTrue(foundGradesRange, "The expected grade '"
                        + Data.GradeLow + " - " + Data.GradeHigh + "' was not found in actual grade label '"
                        + actualText + "'.");
                }
            }
        }
    }
}
