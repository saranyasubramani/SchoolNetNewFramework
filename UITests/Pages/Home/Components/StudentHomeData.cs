using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;

namespace UITests.Pages.Home.Components
{
    public class StudentHomeData : TestData
    {
        public StudentHomeData() : base(typeof(StudentHomeData).Assembly) { }
        public string Passcode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            this.Passcode = base.GetParameterFromResxResource("Passcode", testAttribute, row);
            this.FirstName = base.GetParameterFromResxResource("FirstName", testAttribute, row);
            this.LastName = base.GetParameterFromResxResource("LastName", testAttribute, row);
        }
    }
}
