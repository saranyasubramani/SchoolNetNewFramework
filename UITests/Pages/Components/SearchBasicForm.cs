using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;

namespace UITests.Pages.Components
{
    /// <summary>
    /// the basic search form
    /// </summary>
    public class SearchBasicForm : SNForm
    {
        /// <summary>
        /// the basic search form constructor
        /// </summary>
        /// <param name="pageNames">the page name</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public SearchBasicForm(PageNames pageNames, string overrideControlPrefix = null)
            : base()
        {
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }
            PageNames = pageNames;
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            switch (PageNames)
            {
                case PageNames.ItemCentralHome:
                    //ctl00_MainContent_ItemFinderSearchCompressed1_txtFullText
                    //ctl00_MainContent_ItemFinderSearchCompressed1_btnGo
                    ControlPrefix2 = ControlPrefix + "ItemFinderSearchCompressed1_";
                    break;
                case PageNames.ItemCentral:
                    //ctl00_MainContent_ItemFinderSearchCompressed1_txtFullText
                    //ctl00_MainContent_ItemFinderSearchCompressed1_btnGo
                    ControlPrefix2 = ControlPrefix + "ItemFinderSearchCompressed1_";
                    break;
            }
            SearchText = new WebElementWrapper(BySearchText);
        }

        /// <summary>
        /// the search data
        /// </summary>
        public string SearchData { get; set; }

        private PageNames PageNames { get; set; }
        private string ControlPrefix2 { get; set; }
        /// <summary>
        /// submit by
        /// </summary>
        public override By BySubmit { get { return By.Id(ControlPrefix2 + "btnGo"); } }
        private By BySearchText { get { return By.Id(ControlPrefix2 + "txtFullText"); } }
        private WebElementWrapper SearchText { get; set; }

        public override void InputFormFields()
        {
            SearchText.Clear();
            SearchText.SendKeys(SearchData);
        }
    }
}
