using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Views;
using UITests.Pages.Assess.TestDetail.Components;
using UITests.Pages.Assess.Schedule.ViewAssignmentSummary;

namespace UITests.Pages.Assess.Schedule
{
    /// <summary>
    /// View Assignment Summary page
    /// </summary>
    public class ViewAssignmentSummaryPage : SNWebPage
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="assignmentType"></param>
        public ViewAssignmentSummaryPage( string assignmentType = null)
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            this.ExpectedUrl = "/Assess/ViewAssignmentSummary.aspx";
            this.VerifyCurrentUrl();
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            this.Form = new ViewAssignmentSummaryForm();
            this.Form.Parent = this;
        }
        /// <summary>
        /// the form
        /// </summary>
        public new ViewAssignmentSummaryForm Form { get; set; }

        /// <summary>
        /// the data
        /// </summary>
        public new ViewAssignmentSummaryData Data
        {
            get
            {
                return (ViewAssignmentSummaryData)base.Data;
            }
            set
            {
                base.Data = value;
                this.Form.Data = value;
            }
        }
        /// <summary>
        /// intializes the data
        /// </summary>
        /// <returns>object data</returns>
        public new ViewAssignmentSummaryData InitData()
        {
            base.InitData(new ViewAssignmentSummaryData());
            return (ViewAssignmentSummaryData)base.Data;
        }
        /// <summary>
        /// initializes the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>object data</returns>
        public ViewAssignmentSummaryData InitData(object data)
        {
            base.InitData(data);
            return (ViewAssignmentSummaryData)base.Data;
        }
    }
}
