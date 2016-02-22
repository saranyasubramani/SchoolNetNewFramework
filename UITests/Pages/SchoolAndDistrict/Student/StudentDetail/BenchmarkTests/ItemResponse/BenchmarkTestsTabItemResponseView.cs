using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;

namespace UITests.Pages.SchoolAndDistrict.Student.StudentDetail.BenchmarkTests.ItemResponse
{
    /// <summary>
    /// create student detail page, benchmark tests tab, one test view
    /// </summary>
    public class BenchmarkTestsTabItemResponseView : BenchmarkTestsTab
    {
        /// <summary>
        /// constructor
        /// </summary>
        public BenchmarkTestsTabItemResponseView()
            : base()
        {
            Report.Write("BenchmarkTestsTabItemResponseView");
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            this.Detail = new BenchmarkTestsTabItemResponseViewDetail();
        }
        /// <summary>
        /// the detail
        /// </summary>
        public new BenchmarkTestsTabItemResponseViewDetail Detail { get; set; }

        /// <summary>
        /// the data
        /// </summary>
        public new BenchmarkTestsTabItemResponseViewData Data
        {
            get
            {
                return (BenchmarkTestsTabItemResponseViewData)base.Data;
            }
            set
            {
                base.Data = value;
                base.Detail.Data = value;
            }
        }
    }
}
