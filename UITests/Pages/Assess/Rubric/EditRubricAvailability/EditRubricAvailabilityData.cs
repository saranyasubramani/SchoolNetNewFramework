using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;

namespace UITests.Pages.Assess.Rubric.EditRubricAvailability
{
    /// <summary>
    /// edit rubric availability data
    /// </summary>
    public class EditRubricAvailabilityData : TestData
    {
        /// <summary>
        /// constructor
        /// </summary>
        public EditRubricAvailabilityData()
            : base(typeof(EditRubricAvailabilityData).Assembly) { }
        public string SearchName { get; set; }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            this.SearchName = base.GetParameterFromResxResource("SearchName", testAttribute, row);
        }
    }
}
