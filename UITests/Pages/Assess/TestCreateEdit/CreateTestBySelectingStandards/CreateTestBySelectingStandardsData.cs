using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;
using UITests.Pages.Components;
using UITests.Pages.Assess.Components;

namespace UITests.Pages.Assess.TestCreateEdit.CreateTestBySelectingStandards
{
    /// <summary>
    /// the create test by selecting standards data
    /// </summary>
    public class CreateTestBySelectingStandardsData : TestData
    {
        /// <summary>
        /// constructor
        /// </summary>
        public CreateTestBySelectingStandardsData()
            : base(typeof(CreateTestBySelectingStandardsData).Assembly) { }
        public StandardPickerData StandardPickerData { get; set; }
        public ItemStatisticsData ItemTypeMapData { get; set; }
        public int NumberOfItem { get; set; }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            this.NumberOfItem = base.GetIntParameterFromResxResource("NumberOfItem", testAttribute, row);
            this.StandardPickerData.GetTestDataFromResxResource(url, testAttribute, row);
            this.ItemTypeMapData.GetTestDataFromResxResource(url, testAttribute, row);
        }
    }
}
