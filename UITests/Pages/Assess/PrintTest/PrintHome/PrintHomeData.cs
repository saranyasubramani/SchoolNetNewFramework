using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;

namespace UITests.Pages.Assess.PrintTest.PrintHome
{
    /// <summary>
    /// Schedule Print Data
    /// </summary>
    public class PrintHomeData : TestData
    {
        /// <summary>
        /// constructor
        /// </summary>
        public PrintHomeData() : base(typeof(PrintHomeData).Assembly) { }
        public string TestNameID { get; set; }
        public string Subject { get; set; }
        public string GradeLow { get; set; }
        public string GradeHigh { get; set; }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            this.TestNameID = base.GetParameterFromResxResource("TestNameID", testAttribute, row);
            this.Subject = base.GetParameterFromResxResource("Subject", testAttribute, row);
            this.GradeLow = base.GetParameterFromResxResource("GradeLow", testAttribute, row);
            this.GradeHigh = base.GetParameterFromResxResource("GradeHigh", testAttribute, row);
        }
    }
}
