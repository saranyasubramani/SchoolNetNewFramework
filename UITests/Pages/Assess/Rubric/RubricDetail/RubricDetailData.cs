using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;
using UITests.Pages.Assess.ItemCreateEdit.v01.ItemForms;
using UITests.Pages.Assess.Rubric.Components;

namespace UITests.Pages.Assess.Rubric.RubricDetail
{
    /// <summary>
    /// rubric detail data
    /// </summary>
    public class RubricDetailData : TestData
    {
        /// <summary>
        /// constructor
        /// </summary>
        public RubricDetailData()
            : base(typeof(RubricDetailData).Assembly) { }
        public ItemTypeData RubricProperties { get; set; }
        public List<RubricGroupData> RubricLevels { get; set; }
        public List<RubricColumnData> RubricColumns { get; set; }
        public string Scale { get; set; }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            this.Scale = base.GetParameterFromResxResource("Scale", testAttribute, row);
        }
    }
}
