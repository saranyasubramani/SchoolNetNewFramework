using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;

namespace UITests.Pages.Admin.GeneralSettings.Cache
{
    /// <summary>
    /// cache form
    /// </summary>
    public class CacheForm : SNForm
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="overrideControlPrefix"></param>
        public CacheForm(string overrideControlPrefix = null)
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
            Refresh_button = new WebElementWrapper(ByRefresh_button);
            ClearAll_button = new WebElementWrapper(ByClearAll_button);
        }

        /// <summary>
        /// the data
        /// </summary>
        public new CacheData Data
        {
            get
            {
                return (CacheData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        public By ByClearAll_button { get { return By.Id(ControlPrefix + "ctl00_AdminControl_ButtonClearAll"); } }
        public WebElementWrapper ClearAll_button { get; private set; }
        public By ByRefresh_button { get { return By.Id(ControlPrefix + "ctl00_AdminControl_ButtonRefresh"); } }
        public WebElementWrapper Refresh_button { get; private set; }

        /// <summary>
        /// clear all
        /// </summary>
        public void ClickClearAllButton()
        {
            ClearAll_button.Click();
        }

        /// <summary>
        /// refresh
        /// </summary>
        public void ClickRefreshButton()
        {
            Refresh_button.Click();
        }
    }
}
