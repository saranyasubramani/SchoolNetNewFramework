using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Views;
using UITests.Pages.Assess.TestDetail.Components;
using UITests.Pages.Assess.Schedule.EditSchedule;

namespace UITests.Pages.Assess.Schedule
{
    /// <summary>
    /// Schedule a Test: Test Settings page
    /// </summary>
    public class EditSchedulePage : SNWebPage
    {
        public EditSchedulePage()
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            this.ExpectedUrl = "/Assess/EditSchedule.aspx";
            this.VerifyCurrentUrl();
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            this.Form = new EditSchedulePageForm();
            this.Form.Parent = this;
        }
        /// <summary>
        /// the form
        /// </summary>
        public new EditSchedulePageForm Form { get; set; }

        /// <summary>
        /// the data
        /// </summary>
        public new EditScheduleData Data
        {
            get
            {
                return (EditScheduleData)base.Data;
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
        public new EditScheduleData InitData()
        {
            base.InitData(new EditScheduleData());
            return (EditScheduleData)base.Data;
        }
        /// <summary>
        /// initializes the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>object data</returns>
        public EditScheduleData InitData(object data)
        {
            base.InitData(data);
            return (EditScheduleData)base.Data;
        }
    }
}
