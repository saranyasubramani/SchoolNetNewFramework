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
    /// subject element
    /// </summary>
    public class SubjectElement : SNComponent
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="pageName">page names</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public SubjectElement(PageNames pageName, string overrideControlPrefix = null)
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
            SelectElement = new SelectElementWrapper(new WebElementWrapper(getBy()));
        }

        private PageNames pageName;
        private string prefix;
        /// <summary>
        /// subject (select dropdown)
        /// </summary>
        public SelectElementWrapper SelectElement { get; private set; }
        
        private By getBy()
        {
            string byString = "";
            By by = null;
            switch (pageName)
            {
                case PageNames.AssessDashboard:
                    //ctl00_MainContent_ProfileControl_TestFinderSearchCompressed1_TestSubjectSelector1_DropDownListSubject
                    byString = prefix + "ProfileControl_TestFinderSearchCompressed1_TestSubjectSelector1_DropDownListSubject";
                    by = By.Id(byString);
                    break;
                case PageNames.TeacherAssessDashboard:
                    //ctl00_MainContent_ProfileControl_TestSubjectSelector1_DropDownListSubject
                    byString = prefix + "ProfileControl_TestSubjectSelector1_DropDownListSubject";
                    by = By.Id(byString);
                    break;
                case PageNames.CreateTest:
                    //ctl00_MainContent_TestSubjectSelector1_DropDownListSubject
                    byString = prefix + "TestSubjectSelector1_DropDownListSubject";
                    by = By.Id(byString);
                    break;
                case PageNames.CreateNewItem:
                    //ctl00_MainContent_TestSubjectSelector_DropDownListSubject
                    byString = prefix + "TestSubjectSelector_DropDownListSubject";
                    by = By.Id(byString);
                    break;
                case PageNames.EditTestItem:
                    //ctl00_MainContent_TestSubjectSelector_DropDownListSubject
                    byString = prefix + "TestSubjectSelector_DropDownListSubject";
                    by = By.Id(byString);
                    break;
                case PageNames.EditQuestion:
                    byString = prefix + "TestSubjectSelector_DropDownListSubject";
                    by = By.Id(byString);
                    break;
                case PageNames.ItemCentral:
                    //not sure what page this is on..., so I'm commenting out
                    //ctl00_MainContent_ItemFinder1_ItemFinderSearch1_StandardsPicker1_DropDownSubject
                    //_controlPrefix2 = ControlPrefix + "ItemFinder1_ItemFinderSearch1_StandardsPicker1_DropDownSubject";
                    //this is from ItemCentral.aspx
                    //ctl00_MainContent_ItemFinder1_ItemFinderSearch1_TestSubjectSelector1_DropDownListSubject
                    byString = prefix + "ItemFinder1_ItemFinderSearch1_TestSubjectSelector1_DropDownListSubject";
                    by = By.Id(byString);
                    break;
                case PageNames.TestItemStandardPopup:
                    //ctl00_MainContent_StandardsPicker_DropDownSubject
                    byString = prefix + "StandardsPicker_DropDownSubject";
                    by = By.Id(byString);
                    break;
                case PageNames.CreatePassage:
                    byString = prefix + "TestSubjectSelector_DropDownListSubject";
                    by = By.Id(byString);
                    break;
                case PageNames.EditRubric:
                    byString = prefix + "ctl00_TestSubjectSelector_DropDownListSubject";
                    by = By.Id(byString);
                    break;
                case PageNames.ViewTestDetailsTestProperties:
                    //ctl00_MainContent_TestInfoSidebar1_TestSubjectSelector1_DropDownListSubject
                    byString = prefix + "TestInfoSidebar1_TestSubjectSelector1_DropDownListSubject";
                    by = By.Id(byString);
                    break;
                case PageNames.TestCentralHome:
                    //ctl00_MainContent_TestSearchResults1_TestFinderSearch1_TestSubjectSelector1_DropDownListSubject
                    byString = prefix + "TestSearchResults1_TestFinderSearch1_TestSubjectSelector1_DropDownListSubject";
                    by = By.Id(byString);
                    break;
                case PageNames.TestWindowCreateEditTestWindow:
                    //ctl00_MainContent_TestSubjectSelector1_DropDownListSubject
                    byString = prefix + "TestSubjectSelector1_DropDownListSubject";
                    by = By.Id(byString);
                    break;
                case PageNames.TestWindowPlanHome:
                    //ctl00_MainContent_TestWindowSearchResults1_TestWindowFinderSearch1_TestSubjectSelector1_DropDownListSubject
                    byString = prefix + "TestWindowSearchResults1_TestWindowFinderSearch1_TestSubjectSelector1_DropDownListSubject";
                    by = By.Id(byString);
                    break;
                case PageNames.TestWindowViewTestWindow:
                    //ctl00_MainContent_TestSearchResults1_TestFinderSearch1_TestSubjectSelector1_DropDownListSubject
                    byString = prefix + "TestSearchResults1_TestFinderSearch1_TestSubjectSelector1_DropDownListSubject";
                    by = By.Id(byString);
                    break;
                case PageNames.ViewPortalResults:
                    //ctl00_MainContent_TestSearchResults1_TestFinderSearch1_TestSubjectSelector1_DropDownListSubject
                    byString = prefix + "TestSearchResults1_TestFinderSearch1_TestSubjectSelector1_DropDownListSubject";
                    by = By.Id(byString);
                    break;
                case PageNames.CreateTestBySelectingStandardsPage:
                    //ctl00_MainContent_StandardsPicker1_DropDownSubject
                    byString = prefix + "StandardsPicker1_DropDownSubject";
                    by = By.Id(byString);
                    break;
                case PageNames.TestItem:
                    by = By.CssSelector("select[data-ng-model='testItem.subjectId']");
                    break;
            }
            return by;
        }
    }
}
