using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Tools.WebDriver;
using OpenQA.Selenium;
using UITests.Pages.Components;

namespace UITests.Pages.Controls
{
    /// <summary>
    /// grade level to and from elements
    /// </summary>
    public class GradeLevelElement : SNComponent
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="pageName">page names</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public GradeLevelElement(PageNames pageName, string overrideControlPrefix = null)
            : base()
        {
            this.pageName = pageName;
            if (overrideControlPrefix != null)
            {
                prefix = overrideControlPrefix;
            }
            else
            {
                prefix = "ctl00_MainContent_";
            }
            FromSelectElement = new SelectElementWrapper(new WebElementWrapper(getByFrom()));
            ToSelectElement = new SelectElementWrapper(new WebElementWrapper(getByTo()));
        }

        private PageNames pageName;
        private string prefix;
        /// <summary>
        /// grade level from (select dropdown)
        /// </summary>
        public SelectElementWrapper FromSelectElement { get; private set; }
        /// <summary>
        /// grade level to (select dropdown)
        /// </summary>
        public SelectElementWrapper ToSelectElement { get; private set; }

        private By getByFrom()
        {
            By by = null;
            if (pageName == PageNames.TestItem)
            {
                by = By.CssSelector("select[data-ng-model='logradeModel']");
            }
            else
            {
                by = By.Id(getBy() + "GradeDropDownLow_DropDownGrade");
            }
            return by;
        }
        private By getByTo()
        {
            By by = null;
            if (pageName == PageNames.TestItem)
            {
                by = By.CssSelector("select[data-ng-model='higradeModel']");
            }
            else
            {
                by = By.Id(getBy() + "GradeDropDownHigh_DropDownGrade");
            }
            return by;
        }

        private string getBy()
        {
            string byString = "";
            //By by = null;
            switch (pageName)
            {
                case PageNames.AssessDashboard:
                    //ctl00_MainContent_ProfileControl_TestFinderSearchCompressed1_TestGradeRangeSelector1_GradeDropDownLow_DropDownGrade
                    //ctl00_MainContent_ProfileControl_TestFinderSearchCompressed1_TestGradeRangeSelector1_GradeDropDownHigh_DropDownGrade
                    byString = prefix + "ProfileControl_TestFinderSearchCompressed1_TestGradeRangeSelector1_";
                    break;
                case PageNames.TeacherAssessDashboard:
                    //ctl00_MainContent_ProfileControl_TestGradeRangeSelector1_GradeDropDownLow_DropDownGrade
                    //ctl00_MainContent_ProfileControl_TestGradeRangeSelector1_GradeDropDownHigh_DropDownGrade
                    byString = prefix + "ProfileControl_TestGradeRangeSelector1_";
                    break;
                case PageNames.CreateTest:
                    //ctl00_MainContent_GradeRangeControl1_GradeDropDownLow_DropDownGrade
                    //ctl00_MainContent_GradeRangeControl1_GradeDropDownHigh_DropDownGrade
                    byString = prefix + "GradeRangeControl1_";
                    break;
                case PageNames.CreateNewItem:
                    //ctl00_MainContent_GradeRangeControl_GradeDropDownLow_DropDownGrade
                    //ctl00_MainContent_GradeRangeControl_GradeDropDownHigh_DropDownGrade
                    byString = prefix + "GradeRangeControl_";
                    break;
                case PageNames.EditTestItem:
                    byString = prefix + "GradeRangeControl_";
                    break;
                case PageNames.EditQuestion:
                    byString = prefix + "GradeRangeControl_";
                    break;
                case PageNames.EditRubric:
                    //ctl00_MainContent_ctl00_GradeRangeControl_GradeDropDownLow_DropDownGrade
                    //ctl00_MainContent_GradeRangeControl_GradeDropDownHigh_DropDownGrade
                    byString = prefix + "ctl00_GradeRangeControl_";
                    break;
                case PageNames.CreatePassage:
                    //ctl00_MainContent_ctl00_GradeRangeControl_GradeDropDownLow_DropDownGrade
                    //ctl00_MainContent_GradeRangeControl_GradeDropDownHigh_DropDownGrade
                    byString = prefix + "GradeRangeControl_";
                    break;
                case PageNames.ItemCentral:
                    //ctl00_MainContent_ItemFinder1_ItemFinderSearch1_TestGradeRangeSelector1_GradeDropDownLow_DropDownGrade
                    //ctl00_MainContent_ItemFinder1_ItemFinderSearch1_TestGradeRangeSelector1_GradeDropDownHigh_DropDownGrade
                    byString = prefix + "ItemFinder1_ItemFinderSearch1_TestGradeRangeSelector1_";
                    break;
                case PageNames.ViewTestDetailsTestProperties:
                    //ctl00_MainContent_TestInfoSidebar1_GradeRangeControl1_GradeDropDownLow_DropDownGrade
                    //ctl00_MainContent_TestInfoSidebar1_GradeRangeControl1_GradeDropDownHigh_DropDownGrade
                    byString = prefix + "TestInfoSidebar1_GradeRangeControl1_";
                    break;
                case PageNames.EditAssignmentCourse:
                    byString = prefix + "GradeRangeControl1_";
                    break;
                case PageNames.TestCentralHome:
                    //ctl00_MainContent_TestSearchResults1_TestFinderSearch1_TestGradeRangeSelector1_GradeDropDownLow_DropDownGrade
                    byString = prefix + "TestSearchResults1_TestFinderSearch1_TestGradeRangeSelector1_";
                    break;
                case PageNames.TestWindowCreateEditTestWindow:
                    //ctl00_MainContent_GradeRangeControl1_GradeDropDownLow_DropDownGrade
                    byString = prefix + "GradeRangeControl1_";
                    break;
                case PageNames.TestWindowPlanHome:
                    //ctl00_MainContent_TestWindowSearchResults1_TestWindowFinderSearch1_TestGradeRangeSelector1_GradeDropDownLow_DropDownGrade
                    byString = prefix + "TestWindowSearchResults1_TestWindowFinderSearch1_TestGradeRangeSelector1_";
                    break;
                case PageNames.TestWindowViewTestWindow:
                    //ctl00_MainContent_TestSearchResults1_TestFinderSearch1_TestGradeRangeSelector1_GradeDropDownLow_DropDownGrade
                    byString = prefix + "TestSearchResults1_TestFinderSearch1_TestGradeRangeSelector1_";
                    break;
                case PageNames.ViewPortalResults:
                    //
                    byString = prefix + "TestSearchResults1_TestFinderSearch1_TestGradeRangeSelector1_";
                    break;
            }
            return byString; // by;
        }
    }
}
