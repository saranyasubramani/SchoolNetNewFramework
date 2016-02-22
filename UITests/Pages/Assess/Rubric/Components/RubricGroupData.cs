using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;
using UITests.Pages.Components;

namespace UITests.Pages.Assess.Rubric.Components
{
    /// <summary>
    /// rubric group data
    /// </summary>
    public class RubricGroupData : TestData
    {
        /// <summary>
        /// constructor
        /// </summary>
        public RubricGroupData()
            : base(typeof(RubricGroupData).Assembly) { }
        public List<RubricRowData> Row { get; set; }
        public List<StandardPickerData> Standard { get; set; }
        public string GroupLabel { get; set; }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            this.GroupLabel = base.GetParameterFromResxResource("GroupLabel", testAttribute, row);
        }
    }
}
