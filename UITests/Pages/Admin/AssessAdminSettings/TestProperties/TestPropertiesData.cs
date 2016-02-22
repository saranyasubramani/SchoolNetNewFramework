using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;

namespace UITests.Pages.Admin.AssessAdminSettings.TestProperties
{
    /// <summary>
    /// TestProperties data
    /// </summary>
    public class TestPropertiesData : TestData
    {
        /// <summary>
        /// constructor
        /// </summary>
        public TestPropertiesData()
            : base(typeof(TestPropertiesData).Assembly) { }
        public string Message { get; set; }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            this.Message = base.GetParameterFromResxResource("Message", testAttribute, row);
        }
    }
}
