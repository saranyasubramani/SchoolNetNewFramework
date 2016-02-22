using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;

namespace UITests.Pages.Assess.Rubric.Components
{
    /// <summary>
    /// rubric row data
    /// </summary>
    public class RubricRowData : TestData
    {
        /// <summary>
        /// constructor
        /// </summary>
        public RubricRowData()
            : base(typeof(RubricRowData).Assembly) { }
        public string RowLabel { get; set; }
        public List<RubricDescriptionData> Descriptions { get; set; }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            this.RowLabel = base.GetParameterFromResxResource("RowLabel", testAttribute, row);
        }
    }
}
