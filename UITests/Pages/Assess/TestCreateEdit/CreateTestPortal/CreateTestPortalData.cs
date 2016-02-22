using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;
using UITests.Pages.Assess.TestCreateEdit.Components;

namespace UITests.Pages.Assess.TestCreateEdit.CreateTestPortal
{
    /// <summary>
    /// the create test portal page data
    /// </summary>
    public class CreateTestPortalData : CreateTestData
    {
        /// <summary>
        /// constructor
        /// </summary>
        public CreateTestPortalData()
            : base() { }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
        }
    }
}
