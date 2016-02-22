using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Views;
using UITests.Pages.Assess.ItemCreateEdit.v01.Components;
using UITests.Pages.Assess.ItemCreateEdit.v01.ItemForms;
using UITests.Pages.Assess.ItemCreateEdit.v01.ViewItemStatistics;

namespace UITests.Pages.Assess.ItemCreateEdit.v01
{
    /// <summary>
    /// the view item statistics page
    /// </summary>
    public class ViewItemStatisticsPage : SNWebPage
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="driver">IWebDriver</param>
        public ViewItemStatisticsPage()
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            this.ExpectedUrl = "/Assess/Items/ViewItemStatistics.aspx";
            this.VerifyCurrentUrl();
        }
        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            Detail = new ViewItemStatisticsDetail();
            Detail.Parent = this;
        }

        /// <summary>
        /// the detail
        /// </summary>
        public new ViewItemStatisticsDetail Detail { get; private set; }

        /// <summary>
        /// the data
        /// </summary>
        public new ItemTypeData Data
        {
            get
            {
                return (ItemTypeData)base.Data;
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
        public new ItemTypeData InitData()
        {
            base.InitData(new ItemTypeData());
            return (ItemTypeData)base.Data;
        }
        /// <summary>
        /// initializes the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>object data</returns>
        public ItemTypeData InitData(object data)
        {
            base.InitData(data);
            return (ItemTypeData)base.Data;
        }
    }
}
