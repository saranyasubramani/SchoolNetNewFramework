using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;

namespace UITests.Pages.SchoolAndDistrict.Student.StudentDetail.BenchmarkTests.AllTests
{
    /// <summary>
    /// create student detail page, benchmark tests tab, all test view
    /// </summary>
    public class BenchmarkTestsTabAllTestsView : BenchmarkTestsTab
    {
        /// <summary>
        /// constructor
        /// </summary>
        public BenchmarkTestsTabAllTestsView()
            : base()
        {
            Report.Write("BenchmarkTestsTabAllTestsView");
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            this.Detail = new BenchmarkTestsTabAllTestsViewDetail();
            this.Form = new BenchmarkTestsTabAllTestsViewForm();
        }
        /// <summary>
        /// the detail
        /// </summary>
        public new BenchmarkTestsTabAllTestsViewDetail Detail { get; set; }
        /// <summary>
        /// the form
        /// </summary>
        public new BenchmarkTestsTabAllTestsViewForm Form { get; set; }

        /// <summary>
        /// the data
        /// </summary>
        public new BenchmarkTestsTabAllTestsViewData Data
        {
            get
            {
                return (BenchmarkTestsTabAllTestsViewData)base.Data;
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
