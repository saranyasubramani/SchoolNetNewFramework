using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Views;

namespace UITests.Pages.SchoolAndDistrict.Dashboard.KPI
{
    /// <summary>
    /// the Configure Goal Modal Dialog
    /// </summary>
    public class KPIGoalsConfigure : SNWebPage
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public KPIGoalsConfigure()
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            this.ExpectedUrl = "/Account/KPIGoalsConfigure.aspx";
            this.VerifyCurrentUrl();
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            this.Detail = new KPIGoalsConfigureDetail();
            this.Detail.Parent = this;
            this.Form = new KPIGoalsConfigureForm();
            this.Form.Parent = this;
        }
        /// <summary>
        /// the detail
        /// </summary>
        public new KPIGoalsConfigureDetail Detail { get; set; }
        /// <summary>
        /// the form
        /// </summary>
        public new KPIGoalsConfigureForm Form { get; set; }

    }
}
