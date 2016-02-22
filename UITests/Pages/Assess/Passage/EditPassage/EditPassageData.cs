using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;
using UITests.Pages.Components;

namespace UITests.Pages.Assess.Passage.EditPassage
{
    /// <summary>
    /// edit passage data
    /// </summary>
    public class EditPassageData : TestData
    {
        /// <summary>
        /// constructor
        /// </summary>
        public EditPassageData()
            : base(typeof(EditPassageData).Assembly) { }
        /// <summary>        
        /// Inner Dictionary Uses for Question, Answer, Teacher or Student Explanation as Key. Inner Dictionary uses Image File Name to be uploaded as the Value.
        /// Outer Dictionary Uses True or False (boolean) as Key to indicate WithFileUpload or WithoutFileUpload.        
        /// </summary>
        public Dictionary<bool, Dictionary<string, string>> FileUploadTree { get; set; }
        /// <summary>
        /// AutoIt Data Object - For Dealing with File Uploads
        /// </summary>
        public AutoItData AutoItData { get; set; }

        public string Title { get; set; }
        public string Subject { get; set; }
        public string GradeLow { get; set; }
        public string GradeHigh { get; set; }
        public string HideOptionalProperties { get; set; }
        public string AdditionalPassageID { get; set; }
        public string AssetType { get; set; }
        public string Author { get; set; }
        public string CourseID { get; set; }
        public string FleschKincaid { get; set; }
        public string Genre { get; set; }
        public string QuestionLanguage { get; set; }
        public string LexileCode { get; set; }
        public string Lexile { get; set; }
        public string BeginningReader { get; set; }
        public string Publisher { get; set; }
        public string ReadingMaturityMetric { get; set; }
        public string Topic { get; set; }
        public string Type { get; set; }
        public string Year { get; set; }
        public string Batch { get; set; }
        public string AddTeacherInstructions { get; set; }
        public string PassageText { get; set; }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            this.Title = base.GetParameterFromResxResource("Title", testAttribute, row);
            this.Subject = base.GetParameterFromResxResource("Subject", testAttribute, row);
            this.GradeLow = base.GetParameterFromResxResource("GradeLow", testAttribute, row);
            this.GradeHigh = base.GetParameterFromResxResource("GradeHigh", testAttribute, row);
            this.HideOptionalProperties = base.GetParameterFromResxResource("HideOptionalProperties", testAttribute, row);
            this.AdditionalPassageID = base.GetParameterFromResxResource("AdditionalPassageID", testAttribute, row);
            this.AssetType = base.GetParameterFromResxResource("AssetType", testAttribute, row);
            this.Author = base.GetParameterFromResxResource("Author", testAttribute, row);
            this.CourseID = base.GetParameterFromResxResource("CourseID", testAttribute, row);
            this.FleschKincaid = base.GetParameterFromResxResource("FleschKincaid", testAttribute, row);
            this.Genre = base.GetParameterFromResxResource("Genre", testAttribute, row);
            this.QuestionLanguage = base.GetParameterFromResxResource("QuestionLanguage", testAttribute, row);
            this.LexileCode = base.GetParameterFromResxResource("LexileCode", testAttribute, row);
            this.Lexile = base.GetParameterFromResxResource("Lexile", testAttribute, row);
            this.BeginningReader = base.GetParameterFromResxResource("BeginningReader", testAttribute, row);
            this.Publisher = base.GetParameterFromResxResource("Publisher", testAttribute, row);
            this.ReadingMaturityMetric = base.GetParameterFromResxResource("ReadingMaturityMetric", testAttribute, row);
            this.Topic = base.GetParameterFromResxResource("Topic", testAttribute, row);
            this.Type = base.GetParameterFromResxResource("Type", testAttribute, row);
            this.Year = base.GetParameterFromResxResource("Year", testAttribute, row);
            this.Batch = base.GetParameterFromResxResource("Batch", testAttribute, row);
            this.AddTeacherInstructions = base.GetParameterFromResxResource("AddTeacherInstructions", testAttribute, row);
            this.PassageText = base.GetParameterFromResxResource("PassageText", testAttribute, row);
        }
    }
}
