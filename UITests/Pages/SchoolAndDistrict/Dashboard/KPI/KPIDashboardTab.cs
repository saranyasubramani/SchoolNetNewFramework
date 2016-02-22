using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITests.Pages.SchoolAndDistrict.Dashboard.KPI
{
    /// <summary>
    /// the SchoolDistrict KPI dashboard page for the teacher
    /// </summary>
    public class KPIDashboardTab : SNTab
    {
        /// <summary>
        /// constructor
        /// </summary>
        public KPIDashboardTab()
            : base()
        {
            Report.Write("School District KPI Dashboard");
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            this.Detail = new KPIDashboardTabDetail();
            this.Form = new KPIDashboardTabForm();
        }
        /// <summary>
        /// the detail
        /// </summary>
        public new KPIDashboardTabDetail Detail { get; set; }
        /// <summary>
        /// the form
        /// </summary>
        public new KPIDashboardTabForm Form { get; set; }

        /// <summary>
        /// the data
        /// </summary>
        public new KPIDashboardTabData Data
        {
            get
            {
                return (KPIDashboardTabData)base.Data;
            }
            set
            {
                base.Data = value;
                base.Detail.Data = value;
                base.Form.Data = value;
            }
        }

    }
}
