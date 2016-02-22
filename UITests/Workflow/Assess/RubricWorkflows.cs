using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages;
using UITests.Pages.Components;
using UITests.Pages.Assess;
using UITests.Pages.Assess.Dashboard;
using UITests.Pages.Assess.ItemCentral;
using UITests.Pages.Assess.ItemCentral.ItemCentral;
using UITests.Pages.Assess.ItemCentral.ItemCentralHome;
using UITests.Pages.Assess.ItemCentral.ItemCentralSearchResults;
using UITests.Pages.Assess.ItemCentral.ItemCentralStandardPicker;
using UITests.Pages.Assess.ItemCreateEdit.v01;
using UITests.Pages.Assess.ItemCreateEdit.v01.Components;
using UITests.Pages.Assess.ItemCreateEdit.v01.EditItemAvailability;
using UITests.Pages.Assess.ItemCreateEdit.v01.EditQuestion;
using UITests.Pages.Assess.ItemCreateEdit.v01.EditTask;
using UITests.Pages.Assess.ItemCreateEdit.v01.EditTestItem;
using UITests.Pages.Assess.ItemCreateEdit.v01.ItemForms;
using UITests.Pages.Assess.ItemCreateEdit.v01.ItemParts;
using UITests.Pages.Assess.ItemCreateEdit.v01.ViewItemStatistics;
using UITests.Pages.Assess.Passage;
using UITests.Pages.Assess.Passage.EditPassage;
using UITests.Pages.Assess.Passage.PassageDetail;
using UITests.Pages.Assess.PrintTest;
using UITests.Pages.Assess.Rubric;
using UITests.Pages.Assess.Rubric.Components;
using UITests.Pages.Assess.Rubric.EditRubric;
using UITests.Pages.Assess.Rubric.EditRubricAvailability;
using UITests.Pages.Assess.Rubric.RubricDetail;
using UITests.Pages.Assess.Scantron;
using UITests.Pages.Assess.Schedule;
using UITests.Pages.Assess.Standards;
using UITests.Pages.Assess.TestCentral;
using UITests.Pages.Assess.TestCreateEdit;
using UITests.Pages.Assess.TestCreateEdit.Components;
using UITests.Pages.Assess.TestCreateEdit.CreateTestBySelectingStandards;
using UITests.Pages.Assess.TestDetail;
using UITests.Pages.Assess.TestTunnel;
using UITests.Pages.Assess.TestWindow;
using UITests.Pages.Assess.Track;
using UITests.Pages.Home;
using UITests.Workflow;

namespace UITests.Workflow.Assess
{
    /// <summary>
    /// the rubric workflows
    /// </summary>
    public class RubricWorkflows : SNComponent
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="workflows">workflows</param>
        public RubricWorkflows( AssessWorkflows workflows)
            : base()
        {
            AssessWorkflows = workflows;
        }

        //workflows
        public AssessWorkflows AssessWorkflows { get; set; }

        /// <summary>
        /// navigate to the choose grouping rubric dialog
        /// </summary>
        /// <returns>Workflows</returns>
        public RubricWorkflows NavigateToChooseGroupingRubricDialog()
        {
            AssessWorkflows.NavigateToAssessDashboardPage();
            AssessWorkflows.ItemCentralHomePage = null;
            if ((AssessWorkflows.Workflows.IsDistrictAdmin)
                || (AssessWorkflows.Workflows.IsLeadership)
                || (AssessWorkflows.Workflows.IsStudent)
                || (AssessWorkflows.Workflows.IsSystemSetup))
            {
                AssessWorkflows.ItemCentralHomePage = AssessWorkflows.ProfileHomePage.FindAnItem();
            }
            if (AssessWorkflows.Workflows.IsTeacher)
            {
                AssessWorkflows.ItemCentralHomePage = AssessWorkflows.TeacherProfileHomePage.FindAnItem();
            }
            if (AssessWorkflows.ItemCentralHomePage == null)
            {
                throw new Exception("Navigate to the AssessDashboardPage before trying to use this workflow.");
            }
            AssessWorkflows.ChooseGroupingRubricDialog = AssessWorkflows.ItemCentralHomePage.Detail.CreateARubric();
            return this;
        }
        /// <summary>
        /// navigate to the edit rubric page with grouping disabled
        /// </summary>
        /// <remarks>requires the home page to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public RubricWorkflows NavigateToEditRubricPageGroupingDisabled(EditRubricData editRubricData)
        {
            if (AssessWorkflows.ChooseGroupingRubricDialog == null)
            {
                throw new Exception("The ChooseGroupingRubricDialog is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.ChooseGroupingRubricDialog.SetGroupingDisabled();
            AssessWorkflows.EditRubricPage = (EditRubricPage)AssessWorkflows.ChooseGroupingRubricDialog.SubmitForm();
            if (editRubricData == null)
            {//use default data
                AssessWorkflows.EditRubricPage.InitData();
                AssessWorkflows.EditRubricPage.Data = getRubricData(RubricGroupType.None);
            }
            else
            {
                AssessWorkflows.EditRubricPage.InitData(editRubricData);
            }
            return this;
        }
        /// <summary>
        /// navigate to the edit rubric page with grouping enabled and score entry on quality trait or skill
        /// </summary>
        /// <remarks>requires the home page to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public RubricWorkflows NavigateToEditRubricPageScoreOnQualityTraitSkill(EditRubricData editRubricData)
        {
            if (AssessWorkflows.ChooseGroupingRubricDialog == null)
            {
                throw new Exception("The ChooseGroupingRubricDialog is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.ChooseGroupingRubricDialog.SetGroupingEnabled();
            AssessWorkflows.ChooseGroupingRubricDialog.SetScoreEntryOnEachQualityTraitOrskill();
            AssessWorkflows.EditRubricPage = (EditRubricPage)AssessWorkflows.ChooseGroupingRubricDialog.SubmitForm();
            if (editRubricData == null)
            {//use default data
                AssessWorkflows.EditRubricPage.InitData();
                AssessWorkflows.EditRubricPage.Data = getRubricData(RubricGroupType.EachQualityTraitOrskill);
            }
            else
            {
                AssessWorkflows.EditRubricPage.InitData(editRubricData);
            }
            return this;
        }
        /// <summary>
        /// navigate to the edit rubric page with grouping enabled and score entry on groups
        /// </summary>
        /// <remarks>requires the ChooseGroupingRubricDialog to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public RubricWorkflows NavigateToEditRubricPageScoreOnGroups(EditRubricData editRubricData)
        {
            if (AssessWorkflows.ChooseGroupingRubricDialog == null)
            {
                throw new Exception("The ChooseGroupingRubricDialog is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.ChooseGroupingRubricDialog.SetGroupingEnabled();
            AssessWorkflows.ChooseGroupingRubricDialog.SetScoreEntryOnGroups();
            AssessWorkflows.EditRubricPage = (EditRubricPage)AssessWorkflows.ChooseGroupingRubricDialog.SubmitForm();
            if (editRubricData == null)
            {//use default data
                AssessWorkflows.EditRubricPage.InitData();
                AssessWorkflows.EditRubricPage.Data = getRubricData(RubricGroupType.GroupOfThese);
            }
            else
            {
                AssessWorkflows.EditRubricPage.InitData(editRubricData);
            }
            return this;
        }
        /// <summary>
        /// navigate to the edit rubric availability page
        /// </summary>
        /// <remarks>requires the EditRubricPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public RubricWorkflows NavigateToEditRubricAvailabilityPage()
        {
            if (AssessWorkflows.EditRubricPage == null)
            {
                throw new Exception("The EditRubricPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.EditRubricAvailabilityPage = (EditRubricAvailabilityPage)AssessWorkflows.EditRubricPage.Form.InputAndSubmitForm();
            return this;
        }
        /// <summary>
        /// edit rubric availability page is viewable only to me
        /// </summary>
        /// <remarks>requires the EditRubricAvailabilityPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public RubricWorkflows EditRubricAvailabilitySeenOnlyByMe()
        {
            if (AssessWorkflows.EditRubricAvailabilityPage == null)
            {
                throw new Exception("The EditRubricAvailabilityPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.ShareWithOtherUser = AssessWorkflows.EditRubricAvailabilityPage.Form.SharingRubric;

            AssessWorkflows.ShareWithOtherUser.SelectOnlyToMe();
            AssessWorkflows.EditRubricAvailabilityPage = new EditRubricAvailabilityPage();
            AssessWorkflows.ShareWithOtherUser = AssessWorkflows.EditRubricAvailabilityPage.Form.SharingRubric;
            return this;
        }
        /// <summary>
        /// edit rubric availability page is shared with everyone
        /// </summary>
        /// <remarks>requires the EditRubricAvailabilityPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public RubricWorkflows EditRubricAvailabilityShareWithEveryone()
        {
            if (AssessWorkflows.EditRubricAvailabilityPage == null)
            {
                throw new Exception("The EditRubricAvailabilityPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.ShareWithOtherUser = AssessWorkflows.EditRubricAvailabilityPage.Form.SharingRubric;

            AssessWorkflows.ShareWithOtherUser.SelectShareWithOthers();
            AssessWorkflows.EditRubricAvailabilityPage = new EditRubricAvailabilityPage();
            AssessWorkflows.ShareWithOtherUser = AssessWorkflows.EditRubricAvailabilityPage.Form.SharingRubric;

            AssessWorkflows.ShareWithOtherUser.SelectEveryone();
            AssessWorkflows.EditRubricAvailabilityPage = new EditRubricAvailabilityPage();
            AssessWorkflows.ShareWithOtherUser = AssessWorkflows.EditRubricAvailabilityPage.Form.SharingRubric;
            return this;
        }
        /// <summary>
        /// edit rubric availability page is shared with district item admins only
        /// </summary>
        /// <remarks>requires the EditRubricAvailabilityPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public RubricWorkflows EditRubricAvailabilityShareWithDistrictItemAdminsOnly()
        {
            if (AssessWorkflows.EditRubricAvailabilityPage == null)
            {
                throw new Exception("The EditRubricAvailabilityPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.ShareWithOtherUser = AssessWorkflows.EditRubricAvailabilityPage.Form.SharingRubric;

            AssessWorkflows.ShareWithOtherUser.SelectShareWithOthers();
            AssessWorkflows.EditRubricAvailabilityPage = new EditRubricAvailabilityPage();
            AssessWorkflows.ShareWithOtherUser = AssessWorkflows.EditRubricAvailabilityPage.Form.SharingRubric;

            AssessWorkflows.ShareWithOtherUser.SelectDistrictItemAdminsOnly();
            AssessWorkflows.EditRubricAvailabilityPage = new EditRubricAvailabilityPage();
            AssessWorkflows.ShareWithOtherUser = AssessWorkflows.EditRubricAvailabilityPage.Form.SharingRubric;
            return this;
        }
        /// <summary>
        /// edit rubric availability page is shared with district and regional item admins
        /// </summary>
        /// <remarks>requires the EditRubricAvailabilityPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public RubricWorkflows EditRubricAvailabilityShareWithDistrictRegionalItemAdmins()
        {
            if (AssessWorkflows.EditRubricAvailabilityPage == null)
            {
                throw new Exception("The EditRubricAvailabilityPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.ShareWithOtherUser = AssessWorkflows.EditRubricAvailabilityPage.Form.SharingRubric;

            AssessWorkflows.ShareWithOtherUser.SelectShareWithOthers();
            AssessWorkflows.EditRubricAvailabilityPage = new EditRubricAvailabilityPage();
            AssessWorkflows.ShareWithOtherUser = AssessWorkflows.EditRubricAvailabilityPage.Form.SharingRubric;

            AssessWorkflows.ShareWithOtherUser.SelectDistrictAndRegionalItemAdmins();
            AssessWorkflows.EditRubricAvailabilityPage = new EditRubricAvailabilityPage();
            AssessWorkflows.ShareWithOtherUser = AssessWorkflows.EditRubricAvailabilityPage.Form.SharingRubric;
            return this;
        }
        /// <summary>
        /// edit rubric availability page is shared with district regional and school item admins
        /// </summary>
        /// <remarks>requires the EditRubricAvailabilityPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public RubricWorkflows EditRubricAvailabilityShareWithDistrictRegionalSchoolItemAdmins()
        {
            if (AssessWorkflows.EditRubricAvailabilityPage == null)
            {
                throw new Exception("The EditRubricAvailabilityPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.ShareWithOtherUser = AssessWorkflows.EditRubricAvailabilityPage.Form.SharingRubric;

            AssessWorkflows.ShareWithOtherUser.SelectShareWithOthers();
            AssessWorkflows.EditRubricAvailabilityPage = new EditRubricAvailabilityPage();
            AssessWorkflows.ShareWithOtherUser = AssessWorkflows.EditRubricAvailabilityPage.Form.SharingRubric;

            AssessWorkflows.ShareWithOtherUser.SelectDistrictRegionalAndSchoolItemAdmins();
            AssessWorkflows.EditRubricAvailabilityPage = new EditRubricAvailabilityPage();
            AssessWorkflows.ShareWithOtherUser = AssessWorkflows.EditRubricAvailabilityPage.Form.SharingRubric;
            return this;
        }
        /// <summary>
        /// share the rubric availability page and return to item central home page
        /// </summary>
        /// <remarks>requires the EditRubricAvailabilityPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public RubricWorkflows ShareRubricReturnToItemCentralHomePage()
        {
            if (AssessWorkflows.EditRubricAvailabilityPage == null)
            {
                throw new Exception("The EditRubricAvailabilityPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.ItemCentralHomePage = (ItemCentralHomePage)AssessWorkflows.EditRubricAvailabilityPage.Form.SubmitForm();
            return this;
        }
        /// <summary>
        /// share the rubric availability page and return to item central page
        /// </summary>
        /// <remarks>requires the EditRubricAvailabilityPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public RubricWorkflows ShareRubricReturnToItemCentralPage()
        {
            if (AssessWorkflows.EditRubricAvailabilityPage == null)
            {
                throw new Exception("The EditRubricAvailabilityPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.EditRubricAvailabilityPage.Form.SubmitForm();
            AssessWorkflows.ItemCentralSearchResultsPage = new ItemCentralSearchResultsPage(ItemCentralType.Rubric);
            return this;
        }

        private EditRubricData getRubricData(RubricGroupType rubricGroupType)
        {
            ItemTypeData itemTypeData = new ItemTypeData();
            itemTypeData.GetTestDataFromResxResource("UITests.Data.Assess.Rubric.RubricResource",
                    "default_" + this.TestConfiguration.ApplicationName, 0);
            itemTypeData.Name = string.Format("Web Test Rubric: {0}", DateTime.Now.ToString("yyMMddMMssfff"));

            RubricColumnData rubricColumnData = new RubricColumnData();
            rubricColumnData.GetTestDataFromResxResource("UITests.Data.Assess.Rubric.RubricResource",
                    "default_" + this.TestConfiguration.ApplicationName, 0);

            RubricDescriptionData rubricDescriptionData = new RubricDescriptionData();
            rubricDescriptionData.GetTestDataFromResxResource("UITests.Data.Assess.Rubric.RubricResource",
                    "default_" + this.TestConfiguration.ApplicationName, 0);

            RubricRowData rubricRowData = new RubricRowData();
            rubricRowData.GetTestDataFromResxResource("UITests.Data.Assess.Rubric.RubricResource",
                    "default_" + this.TestConfiguration.ApplicationName, 0);
            rubricRowData.Descriptions = new List<RubricDescriptionData>();
            for (int i = 0; i < 3; i++)
            {
                rubricRowData.Descriptions.Add(rubricDescriptionData);
            }

            var standardPickerData = new StandardPickerData();
            standardPickerData.GetTestDataFromResxResource("UITests.Data.Assess.Standards.StandardPickerResource",
                    "default_" + this.TestConfiguration.ApplicationName, 0);

            var parentData = new SelectedStandardsGroupData();
            parentData.GetTestDataFromResxResource("UITests.Data.Assess.Standards.StandardPickerResource",
                    "default_" + this.TestConfiguration.ApplicationName, 0);

            var childData = new SelectedStandardsGroupData();
            childData.GetTestDataFromResxResource("UITests.Data.Assess.Standards.SelectedStandardsGroupResource",
                    "default_" + this.TestConfiguration.ApplicationName, 0);

            childData.Parent = parentData;
            parentData.Children = new List<SelectedStandardsGroupData> { childData };
            standardPickerData.SelectedStandardsGroupData = parentData;

            RubricGroupData rubricGroupData = new RubricGroupData();
            rubricGroupData.GetTestDataFromResxResource("UITests.Data.Assess.Rubric.RubricResource",
                    "default_" + this.TestConfiguration.ApplicationName, 0);
            rubricGroupData.Row = new List<RubricRowData>();
            rubricGroupData.Row.Add(rubricRowData);
            rubricGroupData.Row.Add(rubricRowData);
            rubricGroupData.Standard = new List<StandardPickerData>();
            if (rubricGroupType == RubricGroupType.GroupOfThese)
            {
                rubricGroupData.Standard.Add(standardPickerData);
            }
            else
            {
                rubricGroupData.Standard.Add(standardPickerData);
                rubricGroupData.Standard.Add(standardPickerData);
            }

            EditRubricData data = new EditRubricData();
            data.RubricProperties = itemTypeData;
            data.Scale = "Level";
            data.RubricLevels = new List<RubricGroupData>();
            data.RubricLevels.Add(rubricGroupData);
            data.RubricColumns = new List<RubricColumnData>();
            data.RubricColumns.Add(rubricColumnData);
            data.RubricColumns.Add(rubricColumnData);
            data.RubricColumns.Add(rubricColumnData);
            return data;
        }
    }
}
