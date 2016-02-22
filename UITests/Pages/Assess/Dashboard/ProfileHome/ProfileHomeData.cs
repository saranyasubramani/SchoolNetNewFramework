using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;

namespace UITests.Pages.Assess.Dashboard.ProfileHome
{
    public class ProfileHomeData : TestData
    {
        public ProfileHomeData() : base(typeof(ProfileHomeData).Assembly) { }
        public string TestId { get; set; }
        public string Subject { get; set; }
        public string RecentlyViewedTests { get; set; }
        public string GradeLevelFrom { get; set; }
        public string GradeLevelTo { get; set; }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            this.TestId = base.GetParameterFromResxResource("TestId", testAttribute, row);
            this.Subject = base.GetParameterFromResxResource("Subject", testAttribute, row);
            this.RecentlyViewedTests = base.GetParameterFromResxResource("RecentlyViewedTests", testAttribute, row);
            this.GradeLevelFrom = base.GetParameterFromResxResource("GradeLevelFrom", testAttribute, row);
            this.GradeLevelTo = base.GetParameterFromResxResource("GradeLevelTo", testAttribute, row);
        }
    }
}
