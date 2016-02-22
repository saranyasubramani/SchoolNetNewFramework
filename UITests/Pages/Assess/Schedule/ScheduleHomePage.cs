using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Views;
using UITests.Pages.Assess.Schedule.ScheduleHome;

namespace UITests.Pages.Assess.Schedule
{
    /// <summary>
    /// Schedule Home page
    /// </summary>
    public class ScheduleHomePage : SNWebPage
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public ScheduleHomePage()
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            this.ExpectedUrl = "/Assess/ScheduleHome.aspx";
            this.VerifyCurrentUrl();
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            this.Form = new ScheduleHomeForm();
            this.Form.Parent = this;
            this.Detail = new ScheduleHomeDetail();
            this.Detail.Parent = this;
        }
        /// <summary>
        /// the form
        /// </summary>
        public new ScheduleHomeForm Form { get; set; }
        /// <summary>
        /// the form
        /// </summary>
        public new ScheduleHomeDetail Detail { get; set; }

        /// <summary>
        /// the data
        /// </summary>
        public new ScheduleHomeData Data
        {
            get
            {
                return (ScheduleHomeData)base.Data;
            }
            set
            {
                base.Data = value;
                this.Form.Data = value;
                this.Detail.Data = value;
            }
        }
        /// <summary>
        /// intializes the data
        /// </summary>
        /// <returns>object data</returns>
        public new ScheduleHomeData InitData()
        {
            base.InitData(new ScheduleHomeData());
            return (ScheduleHomeData)base.Data;
        }
        /// <summary>
        /// initializes the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>object data</returns>
        public ScheduleHomeData InitData(object data)
        {
            base.InitData(data);
            return (ScheduleHomeData)base.Data;
        }
    }
}
