using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;

namespace UITests.Pages.Assess.Components
{
    /// <summary>
    /// passage properties data
    /// </summary>
    public class PassagePropertiesData : TestData
    {
        /// <summary>
        /// constructor
        /// </summary>
        public PassagePropertiesData()
            : base(typeof(PassagePropertiesData).Assembly) { }
        public string Type { get; set; }
        public string Subject { get; set; }
        public string FromGrade { get; set; }
        public string ToGrade { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Topic { get; set; }
        public string Author { get; set; }
        public string CreatedBy { get; set; }
        public string QuestionLanguage { get; set; }
        public string Publisher { get; set; }
        public string NumberOfWordsFrom { get; set; }
        public string NumberOfWordsTo { get; set; }  

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            this.Type = base.GetParameterFromResxResource("Type", testAttribute, row);
            this.Subject = base.GetParameterFromResxResource("Subject", testAttribute, row);
            this.FromGrade = base.GetParameterFromResxResource("GradeLow", testAttribute, row);
            this.ToGrade = base.GetParameterFromResxResource("GradeHigh", testAttribute, row);
            this.Title = base.GetParameterFromResxResource("Title", testAttribute, row);
            this.Genre = base.GetParameterFromResxResource("Genre", testAttribute, row);
            this.Topic = base.GetParameterFromResxResource("Topic", testAttribute, row);
            this.Author = base.GetParameterFromResxResource("Author", testAttribute, row);
            this.CreatedBy = base.GetParameterFromResxResource("CreatedBy", testAttribute, row);
            this.QuestionLanguage = base.GetParameterFromResxResource("QuestionLanguage", testAttribute, row);
            this.Publisher = base.GetParameterFromResxResource("Publisher", testAttribute, row);
            this.NumberOfWordsFrom = base.GetParameterFromResxResource("NumberOfWordsFrom", testAttribute, row);
            this.NumberOfWordsTo = base.GetParameterFromResxResource("NumberOfWordsTo", testAttribute, row);
        }
    }
}
