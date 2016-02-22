using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;

namespace UITests.Pages.Assess.TestTunnel.TestAccess
{
    /// <summary>
    /// the test tunnel access data
    /// </summary>
    public class TestAccessData : TestData
    {
        /// <summary>
        /// constructor
        /// </summary>
        public TestAccessData()
            : base(typeof(TestAccessData).Assembly) { }
        public string Passcode { get; set; }
        public string ClassSection { get; set; }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            this.Passcode = base.GetParameterFromResxResource("Passcode", testAttribute, row);
            this.ClassSection = base.GetParameterFromResxResource("ClassSection", testAttribute, row);
        }
    }
}
