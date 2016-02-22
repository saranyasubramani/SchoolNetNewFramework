using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;
using UITests.Pages.SchoolAndDistrict.Student.StudentDetail.BenchmarkTests.AllTests;
using UITests.Pages.SchoolAndDistrict.Student.StudentDetail.BenchmarkTests.OneTest;
using UITests.Pages.SchoolAndDistrict.Student.StudentDetail.BenchmarkTests.ItemResponse;

namespace UITests.Pages.SchoolAndDistrict.Student.StudentDetail
{
    /// <summary>
    /// student detail data
    /// </summary>
    public class StudentDetailData : TestData
    {
        /// <summary>
        /// constructor
        /// </summary>
        public StudentDetailData()
            : base(typeof(StudentDetailData).Assembly) { }
        public BenchmarkTestsTabAllTestsViewData BenchmarkTestsTabAllTestsViewData { get; set; }
        public BenchmarkTestsTabOneTestViewData BenchmarkTestsTabOneTestViewData { get; set; }
        public BenchmarkTestsTabItemResponseViewData BenchmarkTestsTabItemResponseViewData { get; set; }
        public string StudentName { get; set; }
        public string StudentGrade { get; set; }
        public string PrimaryStudentId { get; set; }
        public string SecondaryStudentId { get; set; }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            this.BenchmarkTestsTabAllTestsViewData.GetTestDataFromResxResource(url, testAttribute, row);
            this.BenchmarkTestsTabOneTestViewData.GetTestDataFromResxResource(url, testAttribute, row);
            this.BenchmarkTestsTabItemResponseViewData.GetTestDataFromResxResource(url, testAttribute, row);
            this.StudentName = base.GetParameterFromResxResource("StudentName", testAttribute, row);
            this.StudentGrade = base.GetParameterFromResxResource("StudentGrade", testAttribute, row);
            this.PrimaryStudentId = base.GetParameterFromResxResource("PrimaryStudentId", testAttribute, row);
            this.SecondaryStudentId = base.GetParameterFromResxResource("SecondaryStudentId", testAttribute, row);
        }
    }
}
