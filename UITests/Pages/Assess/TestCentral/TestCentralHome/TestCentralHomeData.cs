using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;

namespace UITests.Pages.Assess.TestCentral.TestCentralHome
{
    /// <summary>
    /// the test central home data
    /// </summary>
    public class TestCentralHomeData : TestData
    {
        /// <summary>
        /// constructor
        /// </summary>
        public TestCentralHomeData()
            : base(typeof(TestCentralHomeData).Assembly) { }
        public string TestName { get; set; }
        public string Subject { get; set; }
        public string FromGrade { get; set; }
        public string ToGrade { get; set; }
        public string DataCollectionStatus { get; set; }
        public string TestContent { get; set; }
        public string TestCreatorFirstname { get; set; }
        public string TestCreatorLastname { get; set; }
        public string StandardSet { get; set; }
        public string Institution { get; set; }
        public string TestCategory { get; set; }
        public string AdaptiveTests { get; set; }
        public string Publisher { get; set; }
        public string ExternalTestId { get; set; }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            this.TestName = base.GetParameterFromResxResource("TestName", testAttribute, row);
            this.Subject = base.GetParameterFromResxResource("Subject", testAttribute, row);
            this.FromGrade = base.GetParameterFromResxResource("FromGrade", testAttribute, row);
            this.ToGrade = base.GetParameterFromResxResource("ToGrade", testAttribute, row);
            this.DataCollectionStatus = base.GetParameterFromResxResource("DataCollectionStatus", testAttribute, row);
            this.TestContent = base.GetParameterFromResxResource("TestContent", testAttribute, row);
            this.TestCreatorFirstname = base.GetParameterFromResxResource("TestCreatorFirstname", testAttribute, row);
            this.TestCreatorLastname = base.GetParameterFromResxResource("TestCreatorLastname", testAttribute, row);
            this.StandardSet = base.GetParameterFromResxResource("StandardSet", testAttribute, row);
            this.Institution = base.GetParameterFromResxResource("Institution", testAttribute, row);
            this.TestCategory = base.GetParameterFromResxResource("TestCategory", testAttribute, row);
            this.AdaptiveTests = base.GetParameterFromResxResource("AdaptiveTests", testAttribute, row);
            this.Publisher = base.GetParameterFromResxResource("Publisher", testAttribute, row);
            this.ExternalTestId = base.GetParameterFromResxResource("ExternalTestId", testAttribute, row);
        }
    }
}
