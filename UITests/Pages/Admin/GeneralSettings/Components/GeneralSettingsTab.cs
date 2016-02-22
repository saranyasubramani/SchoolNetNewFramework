using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;

namespace UITests.Pages.Admin.GeneralSettings.Components
{
    /// <summary>
    /// general settings tab
    /// </summary>
    public class GeneralSettingsTab : SNTab
    {
        /// <summary>
        /// constructor
        /// </summary>
        public GeneralSettingsTab()
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
