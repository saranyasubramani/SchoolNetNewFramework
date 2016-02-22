using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;

namespace UITests.Pages.UserManagement.UserManagementHome
{
    public class UserManagementHomeData : TestData
    {
        public UserManagementHomeData() : base(typeof(UserManagementHomeData).Assembly) { }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Institution { get; set; }
        public string IncludeChildInistutitons { get; set; }
        public string Role { get; set; }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            this.FirstName = base.GetParameterFromResxResource("FirstName", testAttribute, row);
            this.LastName = base.GetParameterFromResxResource("LastName", testAttribute, row);
            this.Username = base.GetParameterFromResxResource("Username", testAttribute, row);
            this.Institution = base.GetParameterFromResxResource("Institution", testAttribute, row);
            this.IncludeChildInistutitons = base.GetParameterFromResxResource("IncludeChildInistutitons", testAttribute, row);
            this.Role = base.GetParameterFromResxResource("Role", testAttribute, row);
        }
    }
}
