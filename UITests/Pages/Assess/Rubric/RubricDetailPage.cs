using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Views;
using UITests.Pages.Assess.Rubric.Components;
using UITests.Pages.Assess.Rubric.RubricDetail;

namespace UITests.Pages.Assess.Rubric
{
    /// <summary>
    /// rubric detail page
    /// </summary>
    public class RubricDetailPage : SNWebPage
    {
        /// <summary>
        /// constructor
        /// </summary>
        public RubricDetailPage()
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            this.ExpectedUrl = "/Assess/Items/RubricDetail.aspx";
            this.VerifyCurrentUrl();
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            this.Detail = new RubricDetailDetail();
            this.Detail.Parent = this;
        }
        /// <summary>
        /// the form
        /// </summary>
        public new RubricDetailDetail Detail { get; set; }

        /// <summary>
        /// the data
        /// </summary>
        public new RubricDetailData Data
        {
            get
            {
                return (RubricDetailData)base.Data;
            }
            set
            {
                base.Data = value;
                this.Detail.Data = value;
            }
        }
        /// <summary>
        /// intializes the data
        /// </summary>
        /// <returns>object data</returns>
        public new RubricDetailData InitData()
        {
            base.InitData(new RubricDetailData());
            return (RubricDetailData)base.Data;
        }
        /// <summary>
        /// initializes the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>object data</returns>
        public RubricDetailData InitData(object data)
        {
            base.InitData(data);
            return (RubricDetailData)base.Data;
        }
    }
}
