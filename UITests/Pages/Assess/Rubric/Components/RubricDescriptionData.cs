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
    /// rubric description data
    /// </summary>
    public class RubricDescriptionData : TestData
    {
        /// <summary>
        /// constructor
        /// </summary>
        public RubricDescriptionData()
            : base(typeof(RubricDescriptionData).Assembly) { }
        public string Description { get; set; }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            this.Description = base.GetParameterFromResxResource("Description", testAttribute, row);
        }
    }
}
