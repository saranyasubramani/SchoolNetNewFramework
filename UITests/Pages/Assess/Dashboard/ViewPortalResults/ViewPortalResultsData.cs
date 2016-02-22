using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Core.Data;

namespace UITests.Pages.Assess.Dashboard.ViewPortalResults
{
    public class ViewPortalResultsData : TestData
    {
        public ViewPortalResultsData() : base(typeof(ViewPortalResultsData).Assembly) { }
        public string TestNameId { get; set; }
        public string Subject { get; set; }
        public string GradeLevelFrom { get; set; }
        public string GradeLevelTo { get; set; }
        public string AdminDateRangeFrom { get; set; }
        public string AdminDateRangeTo { get; set; }
        public string DataCollectionStatus { get; set; }
        public string TestCategory { get; set; }
        public string TestContent { get; set; }
        public string TestCreatorFirstName { get; set; }
        public string TestCreatorLastName { get; set; }
        public string StandardSet { get; set; }
        public string AdaptiveTests { get; set; }
        public string RecentlyViewedTests { get; set; }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            this.TestNameId = base.GetParameterFromResxResource("TestNameId", testAttribute, row);
            this.Subject = base.GetParameterFromResxResource("Subject", testAttribute, row);
            this.GradeLevelFrom = base.GetParameterFromResxResource("GradeLevelFrom", testAttribute, row);
            this.GradeLevelTo = base.GetParameterFromResxResource("GradeLevelTo", testAttribute, row);
            this.AdminDateRangeFrom = base.GetParameterFromResxResource("AdminDateRangeFrom", testAttribute, row);
            this.AdminDateRangeTo = base.GetParameterFromResxResource("AdminDateRangeTo", testAttribute, row);
            this.DataCollectionStatus = base.GetParameterFromResxResource("DataCollectionStatus", testAttribute, row);
            this.TestCategory = base.GetParameterFromResxResource("TestCategory", testAttribute, row);
            this.TestContent = base.GetParameterFromResxResource("TestContent", testAttribute, row);
            this.TestCreatorFirstName = base.GetParameterFromResxResource("TestCreatorFirstName", testAttribute, row);
            this.TestCreatorLastName = base.GetParameterFromResxResource("TestCreatorLastName", testAttribute, row);
            this.StandardSet = base.GetParameterFromResxResource("StandardSet", testAttribute, row);
            this.AdaptiveTests = base.GetParameterFromResxResource("AdaptiveTests", testAttribute, row);
            this.RecentlyViewedTests = base.GetParameterFromResxResource("RecentlyViewedTests", testAttribute, row);
        }
    }
}
