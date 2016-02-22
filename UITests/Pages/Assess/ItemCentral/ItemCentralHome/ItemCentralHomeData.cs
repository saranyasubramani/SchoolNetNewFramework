using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;

namespace UITests.Pages.Assess.ItemCentral.ItemCentralHome
{
    /// <summary>
    /// item central home data
    /// </summary>
    public class ItemCentralHomeData : TestData
    {
        /// <summary>
        /// the item central home data constructor
        /// </summary>
        public ItemCentralHomeData() : base(typeof(ItemCentralHomeData).Assembly) { }
        /// <summary>
        /// search text data
        /// </summary>
        public string SearchData { get; set; }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            this.SearchData = base.GetParameterFromResxResource("SearchData", testAttribute, row);
        }
    }
}
