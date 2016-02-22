using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;

namespace UITests.Pages.SchoolAndDistrict.Student.StudentDetail.BenchmarkTests.OneTest
{
    /// <summary>
    /// create student detail page, benchmark tests tab, one test view
    /// </summary>
    public class BenchmarkTestsTabOneTestView : BenchmarkTestsTab
    {
        /// <summary>
        /// constructor
        /// </summary>
        public BenchmarkTestsTabOneTestView()
            : base()
        {
            Report.Write("BenchmarkTestsTabOneTestView");
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            this.Form = new BenchmarkTestsTabOneTestViewForm();
        }
        /// <summary>
        /// the form
        /// </summary>
        public new BenchmarkTestsTabOneTestViewForm Form { get; set; }

        /// <summary>
        /// the data
        /// </summary>
        public new BenchmarkTestsTabOneTestViewData Data
        {
            get
            {
                return (BenchmarkTestsTabOneTestViewData)base.Data;
            }
            set
            {
                base.Data = value;
                base.Form.Data = value;
            }
        }
    }
}
