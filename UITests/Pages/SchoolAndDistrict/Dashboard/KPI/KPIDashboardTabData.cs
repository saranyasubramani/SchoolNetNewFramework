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
    /// the SchoolDistrict KPI dashboard data
    /// </summary>
    public class KPIDashboardTabData : TestData
    {
        /// <summary>
        /// constructor
        /// </summary>
        public KPIDashboardTabData()
            : base(typeof(KPIDashboardTabData).Assembly) { }
        public string TextSchTeachSec { get; set; }
        public string SectionHeading { get; set; }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            this.TextSchTeachSec = base.GetParameterFromResxResource("TextSchTeachSec", testAttribute, row);
            this.SectionHeading = base.GetParameterFromResxResource("SectionHeading", testAttribute, row);
        }
    }
}
