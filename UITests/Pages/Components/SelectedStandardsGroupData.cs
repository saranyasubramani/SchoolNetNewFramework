using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;

namespace UITests.Pages.Components
{
    public class SelectedStandardsGroupData : TestData
    {
        public SelectedStandardsGroupData() : base(typeof(SelectedStandardsGroupData).Assembly) { }
        public int StandardId { get; set; }
        public string StandardName { get; set; }
        public int StandardDocumentId { get; set; }
        public string Class { get; set; }
        public SelectedStandardsGroupData Parent { get; set; }
        public List<SelectedStandardsGroupData> Children { get; set; }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            this.StandardId = base.GetIntParameterFromResxResource("StandardId", testAttribute, row);
            this.StandardName = base.GetParameterFromResxResource("StandardName", testAttribute, row);
            this.StandardDocumentId = base.GetIntParameterFromResxResource("StandardDocumentId", testAttribute, row);
            this.Class = base.GetParameterFromResxResource("Class", testAttribute, row);
        }
    }
}
