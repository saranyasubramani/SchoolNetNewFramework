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
    /// rubric column data
    /// </summary>
    public class RubricColumnData : TestData
    {
        /// <summary>
        /// constructor
        /// </summary>
        public RubricColumnData()
            : base(typeof(RubricColumnData).Assembly) { }
        public string ColumnLabel { get; set; }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            this.ColumnLabel = base.GetParameterFromResxResource("ColumnLabel", testAttribute, row);
        }
    }
}
