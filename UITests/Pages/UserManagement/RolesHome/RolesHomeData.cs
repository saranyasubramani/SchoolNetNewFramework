using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;

namespace UITests.Pages.UserManagement.RolesHome
{
    /// <summary>
    /// RolesHome data
    /// </summary>
    public class RolesHomeData : TestData
    {
        public RolesHomeData() : base(typeof(RolesHomeData).Assembly) { }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public string OperationTemplate { get; set; }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            this.RoleName = base.GetParameterFromResxResource("RoleName", testAttribute, row);
            this.OperationTemplate = base.GetParameterFromResxResource("OperationTemplate", testAttribute, row);
            this.Description = base.GetParameterFromResxResource("Description", testAttribute, row);
        }
    }
}
