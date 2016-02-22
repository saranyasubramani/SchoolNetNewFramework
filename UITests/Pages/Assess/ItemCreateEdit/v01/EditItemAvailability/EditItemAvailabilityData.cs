using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;

namespace UITests.Pages.Assess.ItemCreateEdit.v01.EditItemAvailability
{
    public class EditItemAvailabilityData : TestData
    {
        public EditItemAvailabilityData()
            : base(typeof(EditItemAvailabilityData).Assembly) { }
        public string SearchName { get; set; }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            this.SearchName = base.GetParameterFromResxResource("SearchName", testAttribute, row);
        }
    }
}
