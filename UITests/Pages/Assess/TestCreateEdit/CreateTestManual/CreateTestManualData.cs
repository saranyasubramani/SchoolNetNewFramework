using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;
using UITests.Pages.Assess.TestCreateEdit.Components;

namespace UITests.Pages.Assess.TestCreateEdit.CreateTestManual
{
    /// <summary>
    /// the create test manual data
    /// </summary>
    public class CreateTestManualData : CreateTestData
    {
        /// <summary>
        /// constructor
        /// </summary>
        public CreateTestManualData()
            : base() { }
        /// <summary>
        /// number of items
        /// </summary>
        public int NumberOfItems { get; set; }
        /// <summary>
        /// description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// link to test window
        /// </summary>
        public string LinkToTestWindow { get; set; }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            this.NumberOfItems = base.GetIntParameterFromResxResource("NumberOfItems", testAttribute, row);
            this.Description = base.GetParameterFromResxResource("Description", testAttribute, row);
            this.LinkToTestWindow = base.GetParameterFromResxResource("LinkToTestWindow", testAttribute, row);
        }
    }
}
