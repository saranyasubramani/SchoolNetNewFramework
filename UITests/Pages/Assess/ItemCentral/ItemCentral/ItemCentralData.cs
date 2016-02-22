using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;
using UITests.Pages.Components;
using UITests.Pages.Assess.Components;
using UITests.Pages.Assess.ItemCreateEdit.v01.ItemForms;

namespace UITests.Pages.Assess.ItemCentral.ItemCentral
{
    /// <summary>
    /// item central data
    /// </summary>
    public class ItemCentralData : TestData
    {
        /// <summary>
        /// constructor
        /// </summary>
        public ItemCentralData()
            : base(typeof(ItemCentralData).Assembly)
        {
            this.StandardPickerData = new StandardPickerData();
            this.ItemTypeData = new ItemTypeData();
            this.ItemStatisticsData = new ItemStatisticsData();
            this.PassagePropertiesData = new PassagePropertiesData();
        }
        /// <summary>
        /// standard picker data object
        /// </summary>
        public StandardPickerData StandardPickerData { get; set; }
        /// <summary>
        /// item type data object
        /// </summary>
        public ItemTypeData ItemTypeData { get; set; }
        /// <summary>
        /// item statistics data object
        /// </summary>
        public ItemStatisticsData ItemStatisticsData { get; set; }
        /// <summary>
        /// passage properties data object
        /// </summary>
        public PassagePropertiesData PassagePropertiesData { get; set; }
        /// <summary>
        /// Number of Items to be Added to the Test being created (if any) from the Item Search Results
        /// </summary>
        public int NumberOfItemsToBeAddedToTestFromSearchResults { get; set; }

        public void GetTestDataFromResxResource(string ItemTypeUrl, string ItemStatisticsUrl, string PassagePropertiesUrl, string ItemCentralUrl, string testAttribute, int row)
        {
            //this.StandardPickerData.GetTestDataFromResxResource(url, testAttribute, row);
            this.ItemTypeData.GetTestDataFromResxResource(ItemTypeUrl, testAttribute, row);
            this.ItemStatisticsData.GetTestDataFromResxResource(ItemStatisticsUrl, testAttribute, row);
            this.PassagePropertiesData.GetTestDataFromResxResource(PassagePropertiesUrl, testAttribute, row);
            base.GetTestDataFromResxResource(ItemCentralUrl, testAttribute, row);
            this.NumberOfItemsToBeAddedToTestFromSearchResults =
                base.GetIntParameterFromResxResource("NumberOfItemsToBeAddedToTestFromSearchResults", testAttribute, row);
        }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            //this.StandardPickerData.GetTestDataFromResxResource(url, testAttribute, row);
            this.ItemTypeData.GetTestDataFromResxResource(url, testAttribute, row);
            this.ItemStatisticsData.GetTestDataFromResxResource(url, testAttribute, row);
            this.PassagePropertiesData.GetTestDataFromResxResource(url, testAttribute, row);
            base.GetTestDataFromResxResource(url, testAttribute, row);
            this.NumberOfItemsToBeAddedToTestFromSearchResults =
                base.GetIntParameterFromResxResource("NumberOfItemsToBeAddedToTestFromSearchResults", testAttribute, row);
        }
    }
}
