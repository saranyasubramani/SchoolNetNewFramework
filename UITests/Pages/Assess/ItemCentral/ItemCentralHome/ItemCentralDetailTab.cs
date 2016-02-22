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
    /// item central detail tab
    /// </summary>
    public class ItemCentralDetailTab : SNTab
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public ItemCentralDetailTab()
            : base()
        {
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            
        }
    }
}
