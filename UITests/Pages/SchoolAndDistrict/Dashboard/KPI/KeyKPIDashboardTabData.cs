using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;

namespace UITests.Pages.SchoolAndDistrict.Dashboard.KPI
{
    /// <summary>
    /// the SchoolDistrict Key KPI dashboard data
    /// </summary>
    public class KeyKPIDashboardTabData : TestData
    {
        /// <summary>
        /// constructor
        /// </summary>
        public KeyKPIDashboardTabData()
            : base(typeof(KeyKPIDashboardTabData).Assembly) { }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            //this.TextSchTeachSec = base.GetParameterFromResxResource("TextSchTeachSec", testAttribute, row);
        }
    }
}
