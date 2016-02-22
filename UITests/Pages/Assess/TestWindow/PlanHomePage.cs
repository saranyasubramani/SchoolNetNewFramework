using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Views;
using UITests.Pages.Assess.TestWindow.PlanHome;

namespace UITests.Pages.Assess.TestWindow
{
    /// <summary>
    /// Plan Home page
    /// </summary>
    public class PlanHomePage : SNWebPage
    {
        /// <summary>
        /// constructor
        /// </summary>
        public PlanHomePage()
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            this.ExpectedUrl = "/Assess/PlanHome.aspx";
            this.VerifyCurrentUrl();
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            this.Form = new PlanHomeForm();
            this.Form.Parent = this;
            this.Detail = new PlanHomeDetail();
            this.Detail.Parent = this;
        }
        /// <summary>
        /// the form
        /// </summary>
        public new PlanHomeForm Form { get; set; }
        /// <summary>
        /// the form
        /// </summary>
        public new PlanHomeDetail Detail { get; set; }

        /// <summary>
        /// the data
        /// </summary>
        public new PlanHomeData Data
        {
            get
            {
                return (PlanHomeData)base.Data;
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
        public PlanHomeData InitData()
        {
            base.InitData(new PlanHomeData());
            return (PlanHomeData)base.Data;
        }
        /// <summary>
        /// initializes the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>object data</returns>
        public PlanHomeData InitData(object data)
        {
            base.InitData(data);
            return (PlanHomeData)base.Data;
        }
    }
}
