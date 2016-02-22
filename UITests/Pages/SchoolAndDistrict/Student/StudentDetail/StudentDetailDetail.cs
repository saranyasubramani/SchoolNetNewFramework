using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;

namespace UITests.Pages.SchoolAndDistrict.Student.StudentDetail
{
    /// <summary>
    /// the student detail content
    /// </summary>
    public class StudentDetailDetail : SNDetail
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public StudentDetailDetail(string overrideControlPrefix = null)
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
        public new StudentDetailData Data
        {
            get
            {
                return (StudentDetailData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

    }
}
