using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;

namespace UITests.Pages.UserManagement.EditRole
{
    public class EditRoleData : TestData
    {
        public EditRoleData() : base(typeof(EditRoleData).Assembly) { }
        public string OperationToRemove { get; set; }
        public string OperationToAdd { get; set; }
        public string Description { get; set; }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            this.OperationToRemove = base.GetParameterFromResxResource("OperationToRemove", testAttribute, row);
            this.OperationToAdd = base.GetParameterFromResxResource("OperationToAdd", testAttribute, row);
            this.Description = base.GetParameterFromResxResource("Description", testAttribute, row);
        }
    }
}
