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
    /// the benchmark tests tab detail
    /// </summary>
    public class BenchmarkTestsTabAllTestsViewDetail : SNDetail
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public BenchmarkTestsTabAllTestsViewDetail(string overrideControlPrefix = null)
            : base()
        {
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
        }

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
            }
        }
    }
}
