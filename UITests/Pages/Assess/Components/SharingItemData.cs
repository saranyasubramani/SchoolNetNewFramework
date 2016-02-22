using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;

namespace UITests.Pages.Assess.Components
{
    public class SharingItemData : TestData
    {
        public SharingItemData()
            : base(typeof(SharingItemData).Assembly) { }
        public string SearchName { get; set; }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            this.SearchName = base.GetParameterFromResxResource("SearchName", testAttribute, row);
        }
    }
}
