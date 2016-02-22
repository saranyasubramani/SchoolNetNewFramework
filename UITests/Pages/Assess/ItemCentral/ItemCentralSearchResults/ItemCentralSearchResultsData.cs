using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;
using UITests.Pages.Assess.ItemCentral.ItemCentral;

namespace UITests.Pages.Assess.ItemCentral.ItemCentralSearchResults
{
    /// <summary>
    /// the item central search results data
    /// </summary>
    public class ItemCentralSearchResultsData : ItemCentralData
    {
        /// <summary>
        /// constructor
        /// </summary>
        public ItemCentralSearchResultsData()
            : base() { }
        public string ResultPerPage { get; set; }
        public string SortBy { get; set; }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            this.ResultPerPage = base.GetParameterFromResxResource("ResultPerPage", testAttribute, row);
            this.SortBy = base.GetParameterFromResxResource("SortBy", testAttribute, row);
        }
    }
}
