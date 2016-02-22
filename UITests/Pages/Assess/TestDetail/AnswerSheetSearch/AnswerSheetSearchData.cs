using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;

namespace UITests.Pages.Assess.TestDetail.AnswerSheetSearch
{
    /// <summary>
    /// answer sheet generation search criteria data
    /// </summary>
    public class AnswerSheetSearchData : TestData
    {
        /// <summary>
        /// constructor
        /// </summary>
        public AnswerSheetSearchData()
            : base(typeof(AnswerSheetSearchData).Assembly) { }
        public string Region { get; set; }
        public string SchoolType { get; set; }
        public string School { get; set; }
        public string Grade { get; set; }
        public string Department { get; set; }
        public string Course { get; set; }
        public string Teacher { get; set; }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            this.Region = base.GetParameterFromResxResource("Region", testAttribute, row);
            this.SchoolType = base.GetParameterFromResxResource("SchoolType", testAttribute, row);
            this.School = base.GetParameterFromResxResource("School", testAttribute, row);
            this.Grade = base.GetParameterFromResxResource("Grade", testAttribute, row);
            this.Department = base.GetParameterFromResxResource("Department", testAttribute, row);
            this.Course = base.GetParameterFromResxResource("Course", testAttribute, row);
            this.Teacher = base.GetParameterFromResxResource("Teacher", testAttribute, row);
        }
    }
}
