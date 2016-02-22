using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;

namespace UITests.Pages.Assess.Schedule.ScheduleHome
{
    /// <summary>
    /// Schedule Home detail
    /// </summary>
    public class ScheduleHomeDetail : SNDetail
    {
        /// <summary>
        /// the plan home constructor
        /// </summary>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public ScheduleHomeDetail(string overrideControlPrefix = null)
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
            CreateTest = new WebElementWrapper(byCreateTest);
        }

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
            }
        }

        private string ControlPrefix2 = "ctl00_MainContent_TestSearchResults1_TestFinderSearch1_";
        private By byCreateTest { get { return By.Id(ControlPrefix2 + "ButtonCreateTest"); } }
        //id = ctl00_MainContent_TestSearchResults1_TestFinderSearch1_ButtonCreateTest
        private WebElementWrapper CreateTest { get; set; }
    }
}
