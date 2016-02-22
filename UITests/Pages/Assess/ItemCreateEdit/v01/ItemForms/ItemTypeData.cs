using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;
using UITests.Pages.Components;
using UITests.Pages.Assess.ItemCreateEdit.v01.ItemParts;

namespace UITests.Pages.Assess.ItemCreateEdit.v01.ItemForms
{
    public class ItemTypeData : TestData
    {
        public ItemTypeData() : base(typeof(ItemTypeData).Assembly) { }
        public ItemType ItemType { get; set; }
        public string StudentInstructions { get; set; }
        public string QuestionContent { get; set; }
        public List<string> QuestionGapsList { get; set; }
        public string EndOfQuestionGaps { get; set; }
        public string QuestionStem { get; set; }
        public List<string> QuestionStemList { get; set; }
        public string AnswerChoice { get; set; }
        public List<string> AnswerChoiceList { get; set; }
        public string CorrectAnswer { get; set; }
        public List<string> CorrectAnswerList { get; set; }
        public string TeacherExplanation { get; set; }
        public string StudentExplanation { get; set; }
        public int PointsValue { get; set; }
        public List<string> PointsValueList { get; set; }
        public string ResponseType { get; set; }
        private List<string> _trueFalseList;
        public List<string> TrueFalseList
        {
            get
            {
                return _trueFalseList;
            }
            set
            {
                _trueFalseList = new List<string>() { "True", "False" };
            }
        }
        public List<string> QuestionList { get; set; }
        public string QuestionEndingAfterLastGap { get; set; }
        public List<string> AnswerList { get; set; }
        public Dictionary<string, string> QuestionAnswerPair { get; set; }
        public Dictionary<string, List<string>> QuestionAnswerList { get; set; }
        public int NumberOfAnswerColumns { get; set; }
        public string NumberOfAnswerSheetPages { get; set; }
        public string ScoringInstructions { get; set; }
        public string Exemplars { get; set; }
        public string FilePath { get; set; }
        public string PassageTitle { get; set; }
        public AttachRubricDialogData RubricSearchData { get; set; }

        /// <summary>        
        /// Inner Dictionary Uses for Question, Answer, Teacher or Student Explanation as Key. Inner Dictionary uses Image File Name to be uploaded as the Value.
        /// Outer Dictionary Uses True or False (boolean) as Key to indicate WithFileUpload or WithoutFileUpload. 
        /// To be used like PointValueTree. 
        /// </summary>
        public Dictionary<bool, Dictionary<string, string>> FileUploadTree { get; set; }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            //this.StudentInstructions = base.GetParameterFromResxResource("StudentInstructions", testAttribute, row);
            //this.QuestionContent = base.GetParameterFromResxResource("QuestionContent", testAttribute, row);
            //this.EndOfQuestionGaps = base.GetParameterFromResxResource("EndOfQuestionGaps", testAttribute, row);
            //this.QuestionStem = base.GetParameterFromResxResource("QuestionStem", testAttribute, row);
            //this.AnswerChoice = base.GetParameterFromResxResource("AnswerChoice", testAttribute, row);
            //this.CorrectAnswer = base.GetParameterFromResxResource("CorrectAnswer", testAttribute, row);
            //this.TeacherExplanation = base.GetParameterFromResxResource("TeacherExplanation", testAttribute, row);
            //this.StudentExplanation = base.GetParameterFromResxResource("StudentExplanation", testAttribute, row);
            //this.PointsValue = base.GetIntParameterFromResxResource("PointsValue", testAttribute, row);
            //this.ResponseType = base.GetParameterFromResxResource("ResponseType", testAttribute, row);
            //this.QuestionEndingAfterLastGap = base.GetParameterFromResxResource("QuestionEndingAfterLastGap", testAttribute, row);
            //this.NumberOfAnswerColumns = base.GetIntParameterFromResxResource("NumberOfAnswerColumns", testAttribute, row);
            //this.NumberOfAnswerSheetPages = base.GetParameterFromResxResource("NumberOfAnswerSheetPages", testAttribute, row);
            //this.ScoringInstructions = base.GetParameterFromResxResource("ScoringInstructions", testAttribute, row);
            //this.Exemplars = base.GetParameterFromResxResource("Exemplars", testAttribute, row);
            this.PassageTitle = base.GetParameterFromResxResource("PassageTitle", testAttribute, row);
            //this.FilePath = base.GetParameterFromResxResource("FilePath", testAttribute, row);

            /* from old SmokeTestItem.cs */
            this.Name = base.GetParameterFromResxResource("Name", testAttribute, row);
            this.Subject = base.GetParameterFromResxResource("Subject", testAttribute, row);
            this.GradeLow = base.GetParameterFromResxResource("GradeLow", testAttribute, row);
            this.GradeHigh = base.GetParameterFromResxResource("GradeHigh", testAttribute, row);
            this.Keyword = base.GetParameterFromResxResource("Keyword", testAttribute, row);
            this.QuestionLanguage = base.GetParameterFromResxResource("QuestionLanguage", testAttribute, row);
            this.ResponseLanguage = base.GetParameterFromResxResource("ResponseLanguage", testAttribute, row);
            this.TeacherInstruction = base.GetParameterFromResxResource("TeacherInstruction", testAttribute, row);
            this.Publisher = base.GetParameterFromResxResource("Publisher", testAttribute, row);
            this.AdditionalItemIdentifier = base.GetParameterFromResxResource("AdditionalItemIdentifier", testAttribute, row);
            this.Batch = base.GetParameterFromResxResource("Batch", testAttribute, row);
            this.CourseId = base.GetParameterFromResxResource("CourseId", testAttribute, row);
            this.ItemCategory = base.GetParameterFromResxResource("ItemCategory", testAttribute, row);
            this.Year = base.GetParameterFromResxResource("Year", testAttribute, row);
        }

        public string Name { get; set; }
        public string Subject { get; set; }
        public string GradeLow { get; set; }
        public string GradeHigh { get; set; }
        public string Keyword { get; set; }
        public string QuestionLanguage { get; set; }
        public List<string> QuestionLanguageList { get; set; }
        public string ResponseLanguage { get; set; }
        public List<string> ResponseLanguageList { get; set; }
        public string TeacherInstruction { get; set; }
        public string Publisher { get; set; }
        public string AdditionalItemIdentifier { get; set; }
        public string Batch { get; set; }
        public string CourseId { get; set; }
        public string ItemCategory { get; set; }
        public string Year { get; set; }
    }
}
