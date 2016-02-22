using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;

namespace UITests.Pages.Components.Editors
{
    public class InsertLinkDialogData : TestData
    {
        public InsertLinkDialogData() : base(typeof(InsertLinkDialogData).Assembly) { }
        public string Url { get; set; }
        public string Title { get; set; }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            this.Url = base.GetParameterFromResxResource("Url", testAttribute, row);
            this.Title = base.GetParameterFromResxResource("Title", testAttribute, row);
        }
    }
}
