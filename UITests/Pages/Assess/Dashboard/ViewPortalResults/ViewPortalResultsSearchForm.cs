using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages;
using UITests.Pages.Home;
using UITests.Pages.Controls;
using UITests.Pages.Assess.TestDetail;

namespace UITests.Pages.Assess.Dashboard.ViewPortalResults
{
    /// <summary>
    /// view portal results search form
    /// </summary>
    public class ViewPortalResultsSearchForm : SNForm
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="gridName"></param>
        /// <param name="overrideControlPrefix"></param>
        public ViewPortalResultsSearchForm(ViewPortalResultsGridNames gridName, string overrideControlPrefix = null)
            : base()
        {
            GridName = gridName;
            isAdvancedSearchExpanded = false;

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
            TestNameId = new WebElementWrapper(ByTestNameId);
            SubjectElement subject = new SubjectElement(PageNames.ViewPortalResults);
            SubjectSelect = subject.SelectElement;
            GradeLevelElement gradeLevel = new GradeLevelElement(PageNames.ViewPortalResults);
            GradeFromSelect = gradeLevel.FromSelectElement;
            GradeToSelect = gradeLevel.ToSelectElement;

            AdminDateRangeFrom = new WebElementWrapper(ByAdminDateRangeFrom);
            AdminDateRangeTo = new WebElementWrapper(ByAdminDateRangeTo);

            switch (GridName)
            {
                case ViewPortalResultsGridNames.MyTests:
                    if (isAdvancedSearchExpanded)
                    {
                        BasicSearchLink = new WebElementWrapper(ByBasicSearchLink);
                        DataCollectionStatus = new SelectElementWrapper(new WebElementWrapper(ByDataCollectionStatus));
                        TestContent = new WebElementWrapper(ByTestContent);
                        StandardSet = new SelectElementWrapper(new WebElementWrapper(ByStandardSet));
                        AdaptiveTests = new SelectElementWrapper(new WebElementWrapper(ByAdaptiveTests));
                    }
                    else
                    {
                        AdvancedSearchLink = new WebElementWrapper(ByAdvancedSearchLink);
                    }
                    break;
                case ViewPortalResultsGridNames.InProgressTests:
                    if (isAdvancedSearchExpanded)
                    {
                        BasicSearchLink = new WebElementWrapper(ByBasicSearchLink);
                        TestContent = new WebElementWrapper(ByTestContent);
                        TestCreatorFirstName = new WebElementWrapper(ByTestCreatorFirstName);
                        TestCreatorLastName = new WebElementWrapper(ByTestCreatorLastName);
                        StandardSet = new SelectElementWrapper(new WebElementWrapper(ByStandardSet));
                        AdaptiveTests = new SelectElementWrapper(new WebElementWrapper(ByAdaptiveTests));
                    }
                    else
                    {
                        AdvancedSearchLink = new WebElementWrapper(ByAdvancedSearchLink);
                        DataCollectionStatus = new SelectElementWrapper(new WebElementWrapper(ByDataCollectionStatus));
                    }
                    break;
                case ViewPortalResultsGridNames.ScheduledTests:
                    if (isAdvancedSearchExpanded)
                    {
                        BasicSearchLink = new WebElementWrapper(ByBasicSearchLink);
                        DataCollectionStatus = new SelectElementWrapper(new WebElementWrapper(ByDataCollectionStatus));
                        TestContent = new WebElementWrapper(ByTestContent);
                        TestCreatorFirstName = new WebElementWrapper(ByTestCreatorFirstName);
                        TestCreatorLastName = new WebElementWrapper(ByTestCreatorLastName);
                        StandardSet = new SelectElementWrapper(new WebElementWrapper(ByStandardSet));
                        AdaptiveTests = new SelectElementWrapper(new WebElementWrapper(ByAdaptiveTests));
                    }
                    else
                    {
                        AdvancedSearchLink = new WebElementWrapper(ByAdvancedSearchLink);
                    }
                    break;
                case ViewPortalResultsGridNames.RecommendedTests:
                    if (isAdvancedSearchExpanded)
                    {
                        BasicSearchLink = new WebElementWrapper(ByBasicSearchLink);
                        TestContent = new WebElementWrapper(ByTestContent);
                        TestCreatorFirstName = new WebElementWrapper(ByTestCreatorFirstName);
                        TestCreatorLastName = new WebElementWrapper(ByTestCreatorLastName);
                        StandardSet = new SelectElementWrapper(new WebElementWrapper(ByStandardSet));
                        TestCategory = new SelectElementWrapper(new WebElementWrapper(ByTestCategory));
                        AdaptiveTests = new SelectElementWrapper(new WebElementWrapper(ByAdaptiveTests));
                    }
                    else
                    {
                        AdvancedSearchLink = new WebElementWrapper(ByAdvancedSearchLink);
                        TestCategory = new SelectElementWrapper(new WebElementWrapper(ByTestCategory));
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// the data
        /// </summary>
        public ViewPortalResultsData Data
        {
            get
            {
                return (ViewPortalResultsData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        /// <summary>
        /// View Portal Results Grid Name
        /// </summary>
        public ViewPortalResultsGridNames GridName { get; set; }
        /// <summary>
        /// is advanced search expanded?
        /// </summary>
        public bool isAdvancedSearchExpanded;

        //Generic Search Fields for all Grids on ViewP Portal Results Page
        public By ByTestNameId { get { return By.Id(ControlPrefix + "TestSearchResults1_TestFinderSearch1_TextBoxTestName"); } }
        public WebElementWrapper TestNameId { get; private set; }

        public SelectElementWrapper SubjectSelect { get; private set; }
        public SelectElementWrapper GradeFromSelect { get; private set; }
        public SelectElementWrapper GradeToSelect { get; private set; }

        public By ByAdvancedSearchLink { get { return By.Id(ControlPrefix + "TestSearchResults1_TestFinderSearch1_LinkFindType"); } }
        public WebElementWrapper AdvancedSearchLink { get; private set; }

        public By ByBasicSearchLink { get { return By.Id(ControlPrefix + "TestSearchResults1_TestFinderSearch1_LinkFindType"); } }
        public WebElementWrapper BasicSearchLink { get; private set; }

        public override By BySubmit { get { return By.Id(ControlPrefix + "TestSearchResults1_TestFinderSearch1_ButtonGo"); } }

        //More Saerch Fields 
        public By ByAdminDateRangeFrom { get { return By.Id(ControlPrefix + "TestSearchResults1_TestFinderSearch1_TextBoxAdminStartDate"); } }
        public WebElementWrapper AdminDateRangeFrom { get; private set; }

        public By ByAdminDateRangeTo { get { return By.Id(ControlPrefix + "TestSearchResults1_TestFinderSearch1_TextBoxAdminEndDate"); } }
        public WebElementWrapper AdminDateRangeTo { get; private set; }

        public By ByDataCollectionStatus { get { return By.Id(ControlPrefix + "TestSearchResults1_TestFinderSearch1_TestCollectionStatusSelector1_DropDownListStatus"); } }
        public SelectElementWrapper DataCollectionStatus { get; private set; }

        public By ByTestCategory { get { return By.Id(ControlPrefix + "TestSearchResults1_TestFinderSearch1_TestCategorySelector1_DropDownListCategory"); } }
        public SelectElementWrapper TestCategory { get; private set; }

        public By ByTestContent { get { return By.Id(ControlPrefix + "TestSearchResults1_TestFinderSearch1_TextBoxKeyword"); } }
        public WebElementWrapper TestContent { get; set; }

        public By ByTestCreatorFirstName { get { return By.Id(ControlPrefix + "TestSearchResults1_TestFinderSearch1_TextBoxTestCreatorFName"); } }
        public WebElementWrapper TestCreatorFirstName { get; set; }

        public By ByTestCreatorLastName { get { return By.Id(ControlPrefix + "TestSearchResults1_TestFinderSearch1_TextBoxTestCreatorLName"); } }
        public WebElementWrapper TestCreatorLastName { get; set; }

        public By ByStandardSet { get { return By.Id(ControlPrefix + "TestSearchResults1_TestFinderSearch1_DropDownListStandardSet"); } }
        public SelectElementWrapper StandardSet { get; set; }

        public By ByAdaptiveTests { get { return By.Id(ControlPrefix + "TestSearchResults1_TestFinderSearch1_CATInclusionOption"); } }
        public SelectElementWrapper AdaptiveTests { get; set; }

        /// <summary>
        /// Clicks on the Advanced Search Link
        /// </summary>
        public void SelectAdvancedSearch()
        {
            AdvancedSearchLink.Click();
            isAdvancedSearchExpanded = true;
            DriverCommands.WaitAndMeasurePageLoadTime(60, 30);
            InitElements();
            //Do we need to refresh the data object as well here?
        }

        /// <summary>
        /// Clicks on the Basic Search Link
        /// </summary>
        public void SelectBaiscSearch()
        {
            BasicSearchLink.Click();
            isAdvancedSearchExpanded = false;
            DriverCommands.WaitAndMeasurePageLoadTime(60, 30);
            InitElements();
            //Do we need to refresh the data object as well here?
        }

        //implemented methods
        public override void InputFormFields()
        {
            if (Data.TestNameId != null)
            {
                TestNameId.Clear();
                TestNameId.SendKeys(Data.TestNameId);
            }
            if (Data.Subject != null)
            {
                SubjectSelect.Wait().SelectByText(Data.Subject);
            }
            if (Data.GradeLevelFrom != null)
            {
                GradeFromSelect.Wait().SelectByText(Data.GradeLevelFrom);
            }
            if (Data.GradeLevelTo != null)
            {
                GradeToSelect.Wait().SelectByText(Data.GradeLevelTo);
            }
            if (Data.AdminDateRangeFrom != null)
            {
                AdminDateRangeFrom.Clear();
                AdminDateRangeFrom.SendKeys(Data.AdminDateRangeFrom);
            }
            if (Data.AdminDateRangeTo != null)
            {
                AdminDateRangeTo.Clear();
                AdminDateRangeTo.SendKeys(Data.AdminDateRangeTo);
            }

            switch (GridName)
            {
                case ViewPortalResultsGridNames.MyTests:
                    if (isAdvancedSearchExpanded)
                    {
                        if (Data.DataCollectionStatus != null)
                        {
                            DataCollectionStatus.SelectByText(Data.DataCollectionStatus);
                        }

                        if (Data.TestContent != null)
                        {
                            TestContent.Clear();
                            TestContent.SendKeys(Data.TestContent);
                        }

                        if (Data.StandardSet != null)
                        {
                            StandardSet.SelectByText(Data.StandardSet);
                        }

                        if (Data.AdaptiveTests != null)
                        {
                            AdaptiveTests.SelectByText(Data.AdaptiveTests);
                        }
                    }
                    break;
                case ViewPortalResultsGridNames.InProgressTests:
                    if (isAdvancedSearchExpanded)
                    {
                        if (Data.TestContent != null)
                        {
                            TestContent.Clear();
                            TestContent.SendKeys(Data.TestContent);
                        }

                        if (Data.TestCreatorFirstName != null)
                        {
                            TestCreatorFirstName.Clear();
                            TestCreatorFirstName.SendKeys(Data.TestCreatorFirstName);
                        }

                        if (Data.TestCreatorLastName != null)
                        {
                            TestCreatorLastName.Clear();
                            TestCreatorLastName.SendKeys(Data.TestCreatorLastName);
                        }

                        if (Data.StandardSet != null)
                        {
                            StandardSet.SelectByText(Data.StandardSet);
                        }

                        if (Data.AdaptiveTests != null)
                        {
                            AdaptiveTests.SelectByText(Data.AdaptiveTests);
                        }
                    }
                    else
                    {
                        if (Data.DataCollectionStatus != null)
                        {
                            DataCollectionStatus.SelectByText(Data.DataCollectionStatus);
                        }
                    }
                    break;
                case ViewPortalResultsGridNames.ScheduledTests:
                    if (isAdvancedSearchExpanded)
                    {
                        if (Data.DataCollectionStatus != null)
                        {
                            DataCollectionStatus.SelectByText(Data.DataCollectionStatus);
                        }

                        if (Data.TestContent != null)
                        {
                            TestContent.Clear();
                            TestContent.SendKeys(Data.TestContent);
                        }

                        if (Data.TestCreatorFirstName != null)
                        {
                            TestCreatorFirstName.Clear();
                            TestCreatorFirstName.SendKeys(Data.TestCreatorFirstName);
                        }

                        if (Data.TestCreatorLastName != null)
                        {
                            TestCreatorLastName.Clear();
                            TestCreatorLastName.SendKeys(Data.TestCreatorLastName);
                        }

                        if (Data.StandardSet != null)
                        {
                            StandardSet.SelectByText(Data.StandardSet);
                        }

                        if (Data.AdaptiveTests != null)
                        {
                            AdaptiveTests.SelectByText(Data.AdaptiveTests);
                        }
                    }
                    break;
                case ViewPortalResultsGridNames.RecommendedTests:
                    if (isAdvancedSearchExpanded)
                    {
                        if (Data.TestContent != null)
                        {
                            TestContent.Clear();
                            TestContent.SendKeys(Data.TestContent);
                        }

                        if (Data.TestCreatorFirstName != null)
                        {
                            TestCreatorFirstName.Clear();
                            TestCreatorFirstName.SendKeys(Data.TestCreatorFirstName);
                        }

                        if (Data.TestCreatorLastName != null)
                        {
                            TestCreatorLastName.Clear();
                            TestCreatorLastName.SendKeys(Data.TestCreatorLastName);
                        }

                        if (Data.StandardSet != null)
                        {
                            StandardSet.SelectByText(Data.StandardSet);
                        }

                        if (Data.AdaptiveTests != null)
                        {
                            AdaptiveTests.SelectByText(Data.AdaptiveTests);
                        }
                    }
                    else
                    {
                        if (Data.TestCategory != null)
                        {
                            TestCategory.SelectByText(Data.TestCategory);
                        }
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override IBaseScreenView ReturnSubmitPage()
        {
            //wait for post back
            this.DriverCommands.WaitAndMeasurePageLoadTime();
            //reload the page
            Parent.InitElements();
            return null;
        }
        public override IBaseScreenView ReturnCancelPage()
        {
            return null;
        }

        public void VerifyFieldsExist(List<ViewPortalResultsSearchFields> requiredFields)
        {
            //input the required fields
            foreach (var requiredField in requiredFields)
            {
                //wait for the fields. To check if the field is visible. 
                //If field is visible, the field exist

                if (requiredField.Equals(ViewPortalResultsSearchFields.TestNameId))
                {
                    TestNameId.Wait(3);
                }

                if (requiredField.Equals(ViewPortalResultsSearchFields.Subject))
                {
                    this.SubjectSelect.Wait(3);
                }

                if (requiredField.Equals(ViewPortalResultsSearchFields.GradeLevelFrom))
                {
                    this.GradeFromSelect.Wait(3);
                }

                if (requiredField.Equals(ViewPortalResultsSearchFields.GradeLevelTo))
                {
                    this.GradeToSelect.Wait(3);
                }

                if (requiredField.Equals(ViewPortalResultsSearchFields.AdminDateRangeFrom))
                {
                    AdminDateRangeFrom.Wait(3);
                }

                if (requiredField.Equals(ViewPortalResultsSearchFields.AdminDateRangeTo))
                {
                    AdminDateRangeTo.Wait(3);
                }

                if (requiredField.Equals(ViewPortalResultsSearchFields.DataCollectionStatus))
                {
                    DataCollectionStatus.Wait(3);
                }

                if (requiredField.Equals(ViewPortalResultsSearchFields.TestContent))
                {
                    TestContent.Wait(3);
                }

                if (requiredField.Equals(ViewPortalResultsSearchFields.TestCreatorFirstname))
                {
                    TestCreatorFirstName.Wait(3);
                }

                if (requiredField.Equals(ViewPortalResultsSearchFields.TestCreatorLastname))
                {
                    TestCreatorLastName.Wait(3);
                }

                if (requiredField.Equals(ViewPortalResultsSearchFields.StandardSet))
                {
                    StandardSet.Wait(3);
                }

                if (requiredField.Equals(ViewPortalResultsSearchFields.AdaptiveTests))
                {
                    AdaptiveTests.Wait(3);
                }

                if (requiredField.Equals(ViewPortalResultsSearchFields.TestCategory))
                {
                    TestCategory.Wait(3);
                }
            }
        }
    }
}
