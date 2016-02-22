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
    /// the benchmark tests tab detail
    /// </summary>
    public class BenchmarkTestsTabItemResponseViewDetail : SNDetail
    {
        /// <summary>
        /// the benchmark tests tab constructor
        /// </summary>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public BenchmarkTestsTabItemResponseViewDetail( string overrideControlPrefix = null)
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
            StudentItemLabel = new WebElementWrapper( ByStudentItemLabel);
        }

        private By ByStudentItemLabel { get { return By.Id("spanItemNumberOfTotalItemsNumber"); } }
        private WebElementWrapper StudentItemLabel { get; set; }

        public void VerifyTabIsLoaded()
        {
            //Verified by checking the header contain string Student Item Response
            StudentItemLabel.Wait(3);
        }
    }
}
