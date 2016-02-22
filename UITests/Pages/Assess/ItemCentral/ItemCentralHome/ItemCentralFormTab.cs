using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;

namespace UITests.Pages.Assess.ItemCentral.ItemCentralHome
{
    /// <summary>
    /// item central form tab
    /// </summary>
    public class ItemCentralFormTab : SNForm
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public ItemCentralFormTab() : base()
        {
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            
        }

        /// <summary>
        /// submit by
        /// </summary>
        public override By BySubmit { get { return By.Id(ControlPrefix + "TestItemBreadCrumb1_ButtonViewResults"); } }
        /// <summary>
        /// cancel by
        /// </summary>
        public override By ByCancel { get { return By.Id(ControlPrefix + "TestItemBreadCrumb1_LinkButtonStartOver"); } }
    }
}
