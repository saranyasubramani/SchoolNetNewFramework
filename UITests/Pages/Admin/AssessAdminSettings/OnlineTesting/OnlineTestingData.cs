using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;

namespace UITests.Pages.Admin.AssessAdminSettings.OnlineTesting
{
    /// <summary>
    /// Online Testing data
    /// </summary>
    public class OnlineTestingData : TestData
    {
        /// <summary>
        /// constructor
        /// </summary>
        public OnlineTestingData()
            : base(typeof(OnlineTestingData).Assembly) { }
        public string Message { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            this.Message = base.GetParameterFromResxResource("Message", testAttribute, row);
            this.Name = base.GetParameterFromResxResource("Name", testAttribute, row);
            this.Address = base.GetParameterFromResxResource("Address", testAttribute, row);
        }
    }
}
