using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages.Admin.AssessAdminSettings;
using UITests.Pages.Admin.GeneralSettings;

namespace UITests.Pages.Admin.SystemOperation
{
    /// <summary>
    /// System Operation detail.  Basically a wall of links leading to other places.
    /// </summary>
    public class SystemOperationDetail : SNDetail
    {
        /// <summary>
        /// constructor
        /// </summary>
        public SystemOperationDetail()
            : base()
        {
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            //stop hover over menu
            //Header.SelectWelcomeMessage(); //stop hover over menu
            //SiteTitleLabel = new WebElementWrapper(BySiteTitleLabel);
            //SiteTitleLabel.Wait(3).Click();
            this.Utilities.FocusOnMainContentArea();

            //GENERAL SETTINGS
            ContactUs_Link = new WebElementWrapper(ByContactUs_Link);
            Design_Link = new WebElementWrapper(ByDesign_Link);
            Institutions_Link = new WebElementWrapper(ByInstitutions_Link);
            Tabs_Link = new WebElementWrapper(ByTabs_Link);
            StudentProfile_Link = new WebElementWrapper(ByStudentProfile_Link);
            Standards_Link = new WebElementWrapper(ByStandards_Link);
            Subjects_Link = new WebElementWrapper(BySubjects_Link);
            ScoreType_Link = new WebElementWrapper(ByScoreType_Link);
            EventLog_Link = new WebElementWrapper(ByEventLog_Link);
            ScheduledTasks_Link = new WebElementWrapper(ByScheduledTasks_Link);
            Config_Link = new WebElementWrapper(ByConfig_Link);
            Cache_Link = new WebElementWrapper(ByCache_Link);
            Mobile_Link = new WebElementWrapper(ByMobile_Link);
            ConfigureLinkDisplay_Link = new WebElementWrapper(ByConfigureLinkDisplay_Link);
            APIMgmt_Link = new WebElementWrapper(ByAPIMgmt_Link);

            //OUTREACH SETTINGS
            Modules_Link = new WebElementWrapper(ByModules_Link);
            Pages_Link = new WebElementWrapper(ByPages_Link);
            DeletedPages_Link = new WebElementWrapper(ByDeletedPages_Link);
            OnlineClassroom_Link = new WebElementWrapper(ByOnlineClassroom_Link);
            Calendar_Link = new WebElementWrapper(ByCalendar_Link);
            Forums_Link = new WebElementWrapper(ByForums_Link);

            //EDUCATOR DEVELOPMENT: PD PLANNER SETTINGS
            ManageLocations_Link = new WebElementWrapper(ByManageLocations_Link);
            ReviewerComments_Link = new WebElementWrapper(ByReviewerComments_Link);
            ContentAreas_Link = new WebElementWrapper(ByContentAreas_Link);
            Resources_Link = new WebElementWrapper(ByResources_Link);
            Activities_Link = new WebElementWrapper(ByActivities_Link);
            IssuesDiscussed_Link = new WebElementWrapper(ByIssuesDiscussed_Link);
            PDMentor_Link = new WebElementWrapper(ByPDMentor_Link);
            PDForms_Link = new WebElementWrapper(ByPDForms_Link);
            PDSettings_Link = new WebElementWrapper(ByPDSettings_Link);
            CreditTypes_Link = new WebElementWrapper(ByCreditTypes_Link);
            PDProfile_Link = new WebElementWrapper(ByPDProfile_Link);
            //ConfigureEmails_Link = new WebElementWrapper(ByConfigureEmails_Link);  DUPE LINK, TODO workaround
            ExpenseCategories_Link = new WebElementWrapper(ByExpenseCategories_Link);

            //SCHOOL AND DISTRICT DATA SETTINGS
            PerformanceIndicators_Link = new WebElementWrapper(ByPerformanceIndicators_Link);
            Dimensions_Link = new WebElementWrapper(ByDimensions_Link);
            PreFormattedReports_Link = new WebElementWrapper(ByPreFormattedReports_Link);
            StudentFilter_Link = new WebElementWrapper(ByStudentFilter_Link);
            Reports_Link = new WebElementWrapper(ByReports_Link);
            AnalysisSpreadsheet_Link = new WebElementWrapper(ByAnalysisSpreadsheet_Link);
            Identifiers_Link = new WebElementWrapper(ByIdentifiers_Link);
            TestDetails_Link = new WebElementWrapper(ByTestDetails_Link);
            StudentSubgroups_Link = new WebElementWrapper(ByStudentSubgroups_Link);
            SavedReports_Link = new WebElementWrapper(BySavedReports_Link);
            MarkingCategories_Link = new WebElementWrapper(ByMarkingCategories_Link);

            //CLASSROOMS SETTINGS
            InstructionalUnit_Link = new WebElementWrapper(ByInstructionalUnit_Link);
            LessonPlans_Link = new WebElementWrapper(ByLessonPlans_Link);
            Assessment_Link = new WebElementWrapper(ByAssessment_Link);
            Resource_Link = new WebElementWrapper(ByResource_Link);
            ResourceFormats_Link = new WebElementWrapper(ByResourceFormats_Link);
            Organizers_Link = new WebElementWrapper(ByOrganizers_Link);
            StandardsAnnotations_Link = new WebElementWrapper(ByStandardsAnnotations_Link);
            Curriculum_Link = new WebElementWrapper(ByCurriculum_Link);
            Reporting_Link = new WebElementWrapper(ByReporting_Link);
            StudentGroups_Link = new WebElementWrapper(ByStudentGroups_Link);
            MaterialSuggestions_Link = new WebElementWrapper(ByMaterialSuggestions_Link);
            MaterialSources_Link = new WebElementWrapper(ByMaterialSources_Link);

            //EDUCATOR DEVELOPMENT: GENERAL SETTINGS
            GrowthReporting_Link = new WebElementWrapper(ByGrowthReporting_Link);
            DepartmentMappings_Link = new WebElementWrapper(ByDepartmentMappings_Link);
            RubricsAndExemplars_Link = new WebElementWrapper(ByRubricsAndExemplars_Link);
            ConfigureExternalLinks_Link = new WebElementWrapper(ByConfigureExternalLinks_Link);
            ImportData_Link = new WebElementWrapper(ByImportData_Link);
            Windows_Link = new WebElementWrapper(ByWindows_Link);
            MeasureTemplates_Link = new WebElementWrapper(ByMeasureTemplates_Link);
            EvidenceTemplates_Link = new WebElementWrapper(ByEvidenceTemplates_Link);
            MeasureSettings_Link = new WebElementWrapper(ByMeasureSettings_Link);
            ScoringTemplates_Link = new WebElementWrapper(ByScoringTemplates_Link);
            PGPSettings_Link = new WebElementWrapper(ByPGPSettings_Link);
            MiscellaneousSettings_Link = new WebElementWrapper(ByMiscellaneousSettings_Link);

            //ASSESSMENT ADMIN SETTINGS
            BenchmarkScoreGroups_Link = new WebElementWrapper(ByBenchmarkScoreGroups_Link);
            DataCollectionAndMonitoring_Link = new WebElementWrapper(ByDataCollectionAndMonitoring_Link);
            Counts_Link = new WebElementWrapper(ByCounts_Link);
            TestingSubjects_Link = new WebElementWrapper(ByTestingSubjects_Link);
            TestProperties_Link = new WebElementWrapper(ByTestProperties_Link);
            ItemProperties_Link = new WebElementWrapper(ByItemProperties_Link);
            CustomDescription_Link = new WebElementWrapper(ByCustomDescription_Link);
            OnlineTesting_Link = new WebElementWrapper(ByOnlineTesting_Link);
            ScanItFormDefinitions_Link = new WebElementWrapper(ByScanItFormDefinitions_Link);
            CMSItemSharing_Link = new WebElementWrapper(ByCMSItemSharing_Link);
            QTIImport_Link = new WebElementWrapper(ByQTIImport_Link);

            //INTERVENTIONS SETTINGS
            PlanRoleSettings_Link = new WebElementWrapper(ByPlanRoleSettings_Link);
            AreasOfConcern_Link = new WebElementWrapper(ByAreasOfConcern_Link);
            InterventionTiers_Link = new WebElementWrapper(ByInterventionTiers_Link);
            ManageInterventions_Link = new WebElementWrapper(ByManageInterventions_Link);
            ProgressRubrics_Link = new WebElementWrapper(ByProgressRubrics_Link);
            StudentStrengths_Link = new WebElementWrapper(ByStudentStrengths_Link);
            ProgressMonitoringFrequency_Link = new WebElementWrapper(ByProgressMonitoringFrequency_Link);
            ReasonsForRemoval_Link = new WebElementWrapper(ByReasonsForRemoval_Link);

            //MY SCHOOLNET SETTINGS
            MySchoolnet_Link = new WebElementWrapper(ByMySchoolnet_Link);

            //USER MANAGEMENT SETTINGS
            //ConfigureEmails = new WebElementWrapper();  BAH, there are two "Configure Emails" links on the page, TODO needs a workaround
        }

        //protected By BySiteTitleLabel { get { return By.CssSelector(".SiteTitle"); } }
        //protected WebElementWrapper SiteTitleLabel { get; set; }

        //GENERAL SETTINGS
        public By ByContactUs_Link { get { return By.LinkText("Contact Us"); } }
        public WebElementWrapper ContactUs_Link { get; private set; }

        public By ByDesign_Link { get { return By.LinkText("Design"); } }
        public WebElementWrapper Design_Link { get; private set; }

        public By ByInstitutions_Link { get { return By.LinkText("Institutions"); } }
        public WebElementWrapper Institutions_Link { get; private set; }

        public By ByTabs_Link { get { return By.LinkText("Tabs"); } }
        public WebElementWrapper Tabs_Link { get; private set; }

        public By ByStudentProfile_Link { get { return By.LinkText("Student Profile"); } }
        public WebElementWrapper StudentProfile_Link { get; private set; }

        public By ByStandards_Link { get { return By.LinkText("Standards"); } }
        public WebElementWrapper Standards_Link { get; private set; }

        public By BySubjects_Link { get { return By.LinkText("Subjects"); } }
        public WebElementWrapper Subjects_Link { get; private set; }

        public By ByScoreType_Link { get { return By.LinkText("Score Type"); } }
        public WebElementWrapper ScoreType_Link { get; private set; }

        public By ByEventLog_Link { get { return By.LinkText("EventLog"); } }
        public WebElementWrapper EventLog_Link { get; private set; }

        public By ByScheduledTasks_Link { get { return By.LinkText("Scheduled Tasks"); } }
        public WebElementWrapper ScheduledTasks_Link { get; private set; }

        public By ByConfig_Link { get { return By.LinkText("Config"); } }
        public WebElementWrapper Config_Link { get; private set; }

        public By ByCache_Link { get { return By.LinkText("Cache"); } }
        public WebElementWrapper Cache_Link { get; private set; }

        public By ByMobile_Link { get { return By.LinkText("Mobile"); } }
        public WebElementWrapper Mobile_Link { get; private set; }

        public By ByConfigureLinkDisplay_Link { get { return By.LinkText("Configure Link Display"); } }
        public WebElementWrapper ConfigureLinkDisplay_Link { get; private set; }

        public By ByAPIMgmt_Link { get { return By.LinkText("API Mgmt"); } }
        public WebElementWrapper APIMgmt_Link { get; private set; }


        //OUTREACH SETTINGS
        public By ByModules_Link { get { return By.LinkText("Modules"); } }
        public WebElementWrapper Modules_Link { get; private set; }

        public By ByPages_Link { get { return By.LinkText("Pages"); } }
        public WebElementWrapper Pages_Link { get; private set; }

        public By ByDeletedPages_Link { get { return By.LinkText("Deleted Pages"); } }
        public WebElementWrapper DeletedPages_Link { get; private set; }

        public By ByOnlineClassroom_Link { get { return By.LinkText("Online Classroom"); } }
        public WebElementWrapper OnlineClassroom_Link { get; private set; }

        public By ByCalendar_Link { get { return By.LinkText("Calendar"); } }
        public WebElementWrapper Calendar_Link { get; private set; }

        public By ByForums_Link { get { return By.LinkText("Forums"); } }
        public WebElementWrapper Forums_Link { get; private set; }


        //EDUCATOR DEVELOPMENT: PD PLANNER SETTINGS
        public By ByManageLocations_Link { get { return By.LinkText("Manage Locations"); } }
        public WebElementWrapper ManageLocations_Link { get; private set; }

        public By ByReviewerComments_Link { get { return By.LinkText("Reviewer Comments"); } }
        public WebElementWrapper ReviewerComments_Link { get; private set; }

        public By ByContentAreas_Link { get { return By.LinkText("Content Areas"); } }
        public WebElementWrapper ContentAreas_Link { get; private set; }

        public By ByResources_Link { get { return By.LinkText("Resources"); } }
        public WebElementWrapper Resources_Link { get; private set; }

        public By ByActivities_Link { get { return By.LinkText("Activities"); } }
        public WebElementWrapper Activities_Link { get; private set; }

        public By ByIssuesDiscussed_Link { get { return By.LinkText("Issues Discussed"); } }
        public WebElementWrapper IssuesDiscussed_Link { get; private set; }

        public By ByPDMentor_Link { get { return By.LinkText("PD Mentor"); } }
        public WebElementWrapper PDMentor_Link { get; private set; }

        public By ByPDForms_Link { get { return By.LinkText("PD Forms"); } }
        public WebElementWrapper PDForms_Link { get; private set; }

        public By ByPDSettings_Link { get { return By.LinkText("PD Settings"); } }
        public WebElementWrapper PDSettings_Link { get; private set; }

        public By ByCreditTypes_Link { get { return By.LinkText("Credit Types"); } }
        public WebElementWrapper CreditTypes_Link { get; private set; }

        public By ByPDProfile_Link { get { return By.LinkText("PD Profile"); } }
        public WebElementWrapper PDProfile_Link { get; private set; }

        public By ByConfigureEmails_Link { get { return By.LinkText("Configure Emails"); } }
        public WebElementWrapper ConfigureEmails_Link { get; private set; }

        public By ByExpenseCategories_Link { get { return By.LinkText("Expense Categories"); } }
        public WebElementWrapper ExpenseCategories_Link { get; private set; }

        //SCHOOL & DISTRICT DATA SETTINGS
        public By ByPerformanceIndicators_Link { get { return By.LinkText("Performance Indicators"); } }
        public WebElementWrapper PerformanceIndicators_Link { get; private set; }

        public By ByDimensions_Link { get { return By.LinkText("Dimensions"); } }
        public WebElementWrapper Dimensions_Link { get; private set; }

        public By ByPreFormattedReports_Link { get { return By.LinkText("Pre-Formatted Reports"); } }
        public WebElementWrapper PreFormattedReports_Link { get; private set; }

        public By ByStudentFilter_Link { get { return By.LinkText("Student Filter"); } }
        public WebElementWrapper StudentFilter_Link { get; private set; }

        public By ByReports_Link { get { return By.LinkText("Reports"); } }
        public WebElementWrapper Reports_Link { get; private set; }

        public By ByAnalysisSpreadsheet_Link { get { return By.LinkText("Analysis Spreadsheet"); } }
        public WebElementWrapper AnalysisSpreadsheet_Link { get; private set; }

        public By ByIdentifiers_Link { get { return By.LinkText("Identifiers"); } }
        public WebElementWrapper Identifiers_Link { get; private set; }

        public By ByTestDetails_Link { get { return By.LinkText("Test Details"); } }
        public WebElementWrapper TestDetails_Link { get; private set; }

        public By ByStudentSubgroups_Link { get { return By.LinkText("Student Subgroups"); } }
        public WebElementWrapper StudentSubgroups_Link { get; private set; }

        public By BySavedReports_Link { get { return By.LinkText("Saved Reports"); } }
        public WebElementWrapper SavedReports_Link { get; private set; }

        public By ByMarkingCategories_Link { get { return By.LinkText("Marking Categories"); } }
        public WebElementWrapper MarkingCategories_Link { get; private set; }


        //CLASSROOMS SETTINGS
        public By ByInstructionalUnit_Link { get { return By.LinkText("Instructional Unit"); } }
        public WebElementWrapper InstructionalUnit_Link { get; private set; }

        public By ByLessonPlans_Link { get { return By.LinkText("Lesson Plans"); } }
        public WebElementWrapper LessonPlans_Link { get; private set; }

        public By ByAssessment_Link { get { return By.LinkText("Assessment"); } }
        public WebElementWrapper Assessment_Link { get; private set; }

        public By ByResource_Link { get { return By.LinkText("Resource"); } }
        public WebElementWrapper Resource_Link { get; private set; }

        public By ByResourceFormats_Link { get { return By.LinkText("Resource Formats"); } }
        public WebElementWrapper ResourceFormats_Link { get; private set; }

        public By ByOrganizers_Link { get { return By.LinkText("Organizers"); } }
        public WebElementWrapper Organizers_Link { get; private set; }

        public By ByStandardsAnnotations_Link { get { return By.LinkText("Standards Annotations"); } }
        public WebElementWrapper StandardsAnnotations_Link { get; private set; }

        public By ByCurriculum_Link { get { return By.LinkText("Curriculum"); } }
        public WebElementWrapper Curriculum_Link { get; private set; }

        public By ByReporting_Link { get { return By.LinkText("Reporting"); } }
        public WebElementWrapper Reporting_Link { get; private set; }

        public By ByStudentGroups_Link { get { return By.LinkText("Student Groups"); } }
        public WebElementWrapper StudentGroups_Link { get; private set; }

        public By ByMaterialSuggestions_Link { get { return By.LinkText("Material Suggestions"); } }
        public WebElementWrapper MaterialSuggestions_Link { get; private set; }

        public By ByMaterialSources_Link { get { return By.LinkText("Material Sources"); } }
        public WebElementWrapper MaterialSources_Link { get; private set; }


        //EDUCATOR DEVEL: GENERAL SETTINGS
        public By ByGrowthReporting_Link { get { return By.LinkText("Growth Reporting"); } }
        public WebElementWrapper GrowthReporting_Link { get; private set; }

        public By ByDepartmentMappings_Link { get { return By.LinkText("Department Mappings"); } }
        public WebElementWrapper DepartmentMappings_Link { get; private set; }

        public By ByRubricsAndExemplars_Link { get { return By.LinkText("Rubrics & Exemplars"); } }
        public WebElementWrapper RubricsAndExemplars_Link { get; private set; }

        public By ByConfigureExternalLinks_Link { get { return By.LinkText("Configure External Links"); } }
        public WebElementWrapper ConfigureExternalLinks_Link { get; private set; }

        public By ByImportData_Link { get { return By.LinkText("Import Data"); } }
        public WebElementWrapper ImportData_Link { get; private set; }

        public By ByWindows_Link { get { return By.LinkText("Windows"); } }
        public WebElementWrapper Windows_Link { get; private set; }

        public By ByMeasureTemplates_Link { get { return By.LinkText("Measure Templates"); } }
        public WebElementWrapper MeasureTemplates_Link { get; private set; }

        public By ByEvidenceTemplates_Link { get { return By.LinkText("Evidence Templates"); } }
        public WebElementWrapper EvidenceTemplates_Link { get; private set; }

        public By ByMeasureSettings_Link { get { return By.LinkText("Measure Settings"); } }
        public WebElementWrapper MeasureSettings_Link { get; private set; }

        public By ByScoringTemplates_Link { get { return By.LinkText("Scoring Templates"); } }
        public WebElementWrapper ScoringTemplates_Link { get; private set; }

        public By ByPGPSettings_Link { get { return By.LinkText("PGP Settings"); } }
        public WebElementWrapper PGPSettings_Link { get; private set; }

        public By ByMiscellaneousSettings_Link { get { return By.LinkText("Miscellaneous Settings"); } }
        public WebElementWrapper MiscellaneousSettings_Link { get; private set; }


        //ASSESS ADMIN SETTINGS
        public By ByBenchmarkScoreGroups_Link { get { return By.LinkText("Benchmark Score Groups"); } }
        public WebElementWrapper BenchmarkScoreGroups_Link { get; private set; }

        public By ByDataCollectionAndMonitoring_Link { get { return By.LinkText("Data Collection and Monitoring"); } }
        public WebElementWrapper DataCollectionAndMonitoring_Link { get; private set; }

        public By ByCounts_Link { get { return By.LinkText("Counts"); } }
        public WebElementWrapper Counts_Link { get; private set; }

        public By ByTestingSubjects_Link { get { return By.LinkText("Testing Subjects"); } }
        public WebElementWrapper TestingSubjects_Link { get; private set; }

        public By ByTestProperties_Link { get { return By.LinkText("Test Properties"); } }
        public WebElementWrapper TestProperties_Link { get; private set; }

        public By ByItemProperties_Link { get { return By.LinkText("Item Properties"); } }
        public WebElementWrapper ItemProperties_Link { get; private set; }

        public By ByCustomDescription_Link { get { return By.LinkText("Custom Description"); } }
        public WebElementWrapper CustomDescription_Link { get; private set; }

        public By ByOnlineTesting_Link { get { return By.LinkText("Online Testing"); } }
        public WebElementWrapper OnlineTesting_Link { get; private set; }

        public By ByScanItFormDefinitions_Link { get { return By.LinkText("ScanIt Form Definitions"); } }
        public WebElementWrapper ScanItFormDefinitions_Link { get; private set; }

        public By ByCMSItemSharing_Link { get { return By.LinkText("CMS Item Sharing"); } }
        public WebElementWrapper CMSItemSharing_Link { get; private set; }

        public By ByQTIImport_Link { get { return By.LinkText("QTI Import"); } }
        public WebElementWrapper QTIImport_Link { get; private set; }

        //INTERVENTIONS SETTINGS
        public By ByPlanRoleSettings_Link { get { return By.LinkText("Plan Role Settings"); } }
        public WebElementWrapper PlanRoleSettings_Link { get; private set; }

        public By ByAreasOfConcern_Link { get { return By.LinkText("Areas of Concern"); } }
        public WebElementWrapper AreasOfConcern_Link { get; private set; }

        public By ByInterventionTiers_Link { get { return By.LinkText("Intervention Tiers"); } }
        public WebElementWrapper InterventionTiers_Link { get; private set; }

        public By ByManageInterventions_Link { get { return By.LinkText("Manage Interventions"); } }
        public WebElementWrapper ManageInterventions_Link { get; private set; }

        public By ByProgressRubrics_Link { get { return By.LinkText("Progress Rubrics"); } }
        public WebElementWrapper ProgressRubrics_Link { get; private set; }

        public By ByStudentStrengths_Link { get { return By.LinkText("Student Strengths"); } }
        public WebElementWrapper StudentStrengths_Link { get; private set; }

        public By ByProgressMonitoringFrequency_Link { get { return By.LinkText("Progress Monitoring Frequency"); } }
        public WebElementWrapper ProgressMonitoringFrequency_Link { get; private set; }

        public By ByReasonsForRemoval_Link { get { return By.LinkText("Reasons for Removal"); } }
        public WebElementWrapper ReasonsForRemoval_Link { get; private set; }

        //MY SCHOOLNET SETTINGS
        public By ByMySchoolnet_Link { get { return By.LinkText("My Schoolnet"); } }
        public WebElementWrapper MySchoolnet_Link { get; private set; }

        //USER MANAGEMENT SETTINGS
        //public By ByConfigureEmails_Link { get { return By.LinkText("Configure Emails"); } }
        //public WebElementWrapper ConfigureEmails_Link { get; private set; }


        // **** FUNCTIONS ****


        //FUNCTIONS - GENERAL SETTINGS
        public ContactUsPage Navigate_to_ContactUs()
        {
            ContactUs_Link.Click();
            return new ContactUsPage();
        }

        public ConfigPage Navigate_to_Config()
        {
            Config_Link.Click();
            return new ConfigPage();
        }

        public StudentProfilePage Navigate_to_StudentProfile()
        {
            StudentProfile_Link.Click();
            return new StudentProfilePage();
        }

        //FUNCTIONS - OUTREACH SETTINGS

        //FUNCTIONS - EDUCATOR DEVELOPMENT: PD PLANNER SETTINGS

        //FUNCTIONS - SCHOOL & DISTRICT DATA SETTINGS

        //FUNCTIONS - CLASSROOM SETTINGS

        //FUNCTIONS - EDUCATOR DEVELOPMENT: GENERAL SETTINGS



        //FUNCTIONS - ASSESS ADMIN SETTINGS   

        public void Navigate_to_Benchmark_Score_Groups()
        {
            BenchmarkScoreGroups_Link.Click();
        }

        public void Navigate_to_Data_Collection_And_Monitoring()
        {
            DataCollectionAndMonitoring_Link.Click();
        }

        public void Navigate_to_Counts()
        {
            Counts_Link.Click();
        }

        public void Navigate_to_Testing_Subjects()
        {
            TestingSubjects_Link.Click();
        }

        public TestPropertiesPage Navigate_to_Test_Properties()
        {
            TestProperties_Link.Click();
            return new TestPropertiesPage();
        }

        public ItemPropertiesPage Navigate_to_Item_Properties()
        {
            ItemProperties_Link.Wait(3).Click();
            return new ItemPropertiesPage();
        }

        public void Navigate_to_Custom_Description()
        {
            CustomDescription_Link.Click();
        }

        public OnlineTestingPage Navigate_to_Online_Testing()
        {
            OnlineTesting_Link.Click();
            return new OnlineTestingPage();
        }

        public void Navigate_to_ScanIt_Form_Definitions()
        {
            ScanItFormDefinitions_Link.Click();
        }

        public void Navigate_to_CMS_Item_Sharing()
        {
            CMSItemSharing_Link.Click();
        }

        public void Navigate_to_QTI_Import()
        {
            QTIImport_Link.Click();
        }


        //FUNCTIONS - INTERVENTIONS SETTINGS

        public void Navigate_to_Plan_Role_Settings()
        {
            PlanRoleSettings_Link.Click();
        }

        public void Navigate_to_Areas_of_Concern()
        {
            AreasOfConcern_Link.Click();
        }

        public void Navigate_to_Intervention_Tiers()
        {
            InterventionTiers_Link.Click();
        }

        public void Navigate_to_Manage_interventions()
        {
            ManageInterventions_Link.Click();
        }

        public void Navigate_to_Progress_Rubrics()
        {
            ProgressRubrics_Link.Click();
        }

        public void Navigate_to_Student_Strengths()
        {
            StudentStrengths_Link.Click();
        }

        public void Navigate_to_Progress_Monitoring_Frequency()
        {
            ProgressMonitoringFrequency_Link.Click();
        }

        public void Navigate_to_Reasons_For_Removal()
        {
            ReasonsForRemoval_Link.Click();
        }


        //FUNCTIONS - MY SCHOOLNET SETTINGS

        public void Navigate_to_My_Schoolnet()
        {
            MySchoolnet_Link.Click();
        }

        //FUNCTIONS - USER MANAGEMENT SETTINGS

        public void Navigate_to_Configure_Emails()
        {
            ConfigureEmails_Link.Click();
        }
    }
}
