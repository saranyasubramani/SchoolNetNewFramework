using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;
using UITests.Pages.SchoolAndDistrict.Dashboard.KPI;

namespace UITests.Pages.SchoolAndDistrict.Dashboard.Components
{
    /// <summary>
    /// school & district data
    /// </summary>
    public class DashboardData : TestData
    {
        /// <summary>
        /// constructor
        /// </summary>
        public DashboardData()
            : base(typeof(DashboardData).Assembly) { }
        public KPIDashboardTabData SchoolDistrictKPIDashboardTabData { get; set; }
        public KeyKPIDashboardTabData SchoolDistrictKeyKPIDashboardTabData { get; set; }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            this.SchoolDistrictKPIDashboardTabData.GetTestDataFromResxResource(url, testAttribute, row);
            this.SchoolDistrictKeyKPIDashboardTabData.GetTestDataFromResxResource(url, testAttribute, row);
        }
    }
}
