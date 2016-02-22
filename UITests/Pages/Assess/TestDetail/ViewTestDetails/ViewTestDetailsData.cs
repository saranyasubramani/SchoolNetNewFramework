using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;
using UITests.Pages.Assess.Components;

namespace UITests.Pages.Assess.TestDetail.ViewTestDetails
{
    /// <summary>
    /// the view test details data
    /// </summary>
    public class ViewTestDetailsData : TestData
    {
        /// <summary>
        /// constructor
        /// </summary>
        public ViewTestDetailsData()
            : base(typeof(ViewTestDetailsData).Assembly) { }
        public TestStage TestStage { get; set; }
        //public List<ItemTypeData> TestItemsData { get; set; }
        public List<TestContentLineItemData> TestItemsData { get; set; }
        public string TestId { get; set; }
        public string TestName { get; set; }
        public string TestStartDate { get; set; }
        public string TestEndDate { get; set; }
        public string ScoringEndDate { get; set; }
        public string SourceInstitution { get; set; }
        public string TestCategory { get; set; }
        public string GradeRange { get; set; }
        public string ScoreType { get; set; }
        public string Subject { get; set; }
        public string PreferredStandardsDocument { get; set; }
        public string NumberofItems { get; set; }
        public string TotalPointValue { get; set; }
        public string TestCreator { get; set; }
        public string EnableTextFormatting { get; set; }
        public string MultipleChoiceAnswerChoiceLayout { get; set; }
        public string EnableToolsAndManipulatives { get; set; }
        public string EnableStudentComments { get; set; }
        public string CaptureTeacherCommentsOnAnswerSheets { get; set; }
        public string EnableStudentSelfAssessment { get; set; }
        public string ItemVisibility { get; set; }
        public string Instruction { get; set; }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            this.TestId = base.GetParameterFromResxResource("TestId", testAttribute, row);
            this.TestName = base.GetParameterFromResxResource("TestName", testAttribute, row);
            this.TestStartDate = base.GetParameterFromResxResource("TestStartDate", testAttribute, row);
            this.TestEndDate = base.GetParameterFromResxResource("TestEndDate", testAttribute, row);
            this.ScoringEndDate = base.GetParameterFromResxResource("ScoringEndDate", testAttribute, row);
            this.SourceInstitution = base.GetParameterFromResxResource("SourceInstitution", testAttribute, row);
            this.TestCategory = base.GetParameterFromResxResource("TestCategory", testAttribute, row);
            this.GradeRange = base.GetParameterFromResxResource("GradeRange", testAttribute, row);
            this.ScoreType = base.GetParameterFromResxResource("ScoreType", testAttribute, row);
            this.Subject = base.GetParameterFromResxResource("Subject", testAttribute, row);
            this.PreferredStandardsDocument = base.GetParameterFromResxResource("PreferredStandardsDocument", testAttribute, row);
            this.NumberofItems = base.GetParameterFromResxResource("NumberofItems", testAttribute, row);
            this.TotalPointValue = base.GetParameterFromResxResource("TotalPointValue", testAttribute, row);
            this.TestCreator = base.GetParameterFromResxResource("TestCreator", testAttribute, row);
            this.EnableTextFormatting = base.GetParameterFromResxResource("EnableTextFormatting", testAttribute, row);
            this.MultipleChoiceAnswerChoiceLayout = base.GetParameterFromResxResource("MultipleChoiceAnswerChoiceLayout", testAttribute, row);
            this.EnableToolsAndManipulatives = base.GetParameterFromResxResource("EnableToolsAndManipulatives", testAttribute, row);
            this.EnableStudentComments = base.GetParameterFromResxResource("EnableStudentComments", testAttribute, row);
            this.CaptureTeacherCommentsOnAnswerSheets = base.GetParameterFromResxResource("CaptureTeacherCommentsOnAnswerSheets", testAttribute, row);
            this.EnableStudentSelfAssessment = base.GetParameterFromResxResource("EnableStudentSelfAssessment", testAttribute, row);
            this.ItemVisibility = base.GetParameterFromResxResource("ItemVisibility", testAttribute, row);
            this.Instruction = base.GetParameterFromResxResource("Instruction", testAttribute, row);
        }
    }
}
