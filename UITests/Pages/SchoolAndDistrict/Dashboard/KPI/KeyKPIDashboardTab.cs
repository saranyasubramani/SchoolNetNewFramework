using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITests.Pages.SchoolAndDistrict.Dashboard.KPI
{
    /// <summary>
    /// the SchoolDistrict KeyKPI Dashboard Page
    /// </summary>
    public class KeyKPIDashboardTab : SNTab
    {
        /// <summary>
        /// constructor
        /// </summary>
        public KeyKPIDashboardTab()
            : base()
        {
            Report.Write("School District KPI Key Page");
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            this.Form = new KeyKPIDashboardTabForm();
        }
        /// <summary>
        /// the form
        /// </summary>
        public new KeyKPIDashboardTabForm Form { get; set; }

        /// <summary>
        /// the data
        /// </summary>
        public new KeyKPIDashboardTabData Data
        {
            get
            {
                return (KeyKPIDashboardTabData)base.Data;
            }
            set
            {
                base.Data = value;
                base.Form.Data = value;
            }
        }

    }
}
