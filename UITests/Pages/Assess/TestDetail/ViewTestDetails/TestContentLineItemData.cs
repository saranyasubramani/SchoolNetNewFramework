using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;
using UITests.Pages.Assess.ItemCreateEdit.v01.ItemForms;

namespace UITests.Pages.Assess.TestDetail.ViewTestDetails
{
    /// <summary>
    /// represents the test detail - test content line item data.
    /// </summary>
    public class TestContentLineItemData : TestData
    {
        /// <summary>
        /// constructor
        /// </summary>
        public TestContentLineItemData()
            : base(typeof(TestContentLineItemData).Assembly) { }
        public ItemTypeData TestContentItemData { get; set; }
        public TestContentLineItemState TestContentLineItemState { get; set; }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
        }
    }
}
