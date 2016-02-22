using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages.Components;
using UITests.Pages.Assess.ItemCentral.ItemCentral;

namespace UITests.Pages.Assess.ItemCentral.ItemCentralSearchResults
{
    /// <summary>
    /// the item central - search results detail
    /// </summary>
    public class ItemCentralSearchResultsDetail : ItemCentralDetail
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="itemCentralType">item central type</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public ItemCentralSearchResultsDetail(ItemCentralType itemCentralType, string overrideControlPrefix = null)
            : base(itemCentralType, overrideControlPrefix)
        {
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            OpenCloseFiltersLink = new WebElementWrapper(ByOpenCloseFiltersLink);
            ExpandAllLink = new WebElementWrapper(ByExpandAllLink);
            CollapseAllLink = new WebElementWrapper(ByCollapseAllLink);
        }

        private By ByOpenCloseFiltersLink { get { return By.Id("openClose"); } }
        private WebElementWrapper OpenCloseFiltersLink { get; set; }
        private By ByExpandAllLink { get { return By.ClassName("expand-all"); } }
        private WebElementWrapper ExpandAllLink { get; set; }
        private By ByCollapseAllLink { get { return By.ClassName("collapse-all"); } }
        private WebElementWrapper CollapseAllLink { get; set; }

        /// <summary>
        /// open filters
        /// </summary>
        public void OpenFilters()
        {
            OpenCloseFiltersLink.Wait(3).Click();
        }

        /// <summary>
        /// close filters
        /// </summary>
        public void CloseFilters()
        {
            OpenCloseFiltersLink.Wait(3).Click();
        }

        /// <summary>
        /// verify bread crumb
        /// </summary>
        /// <param name="breadCrumb">the bread crumb</param>
        public void VerifyBreadCrumb(string breadCrumb)
        {
            //todo
            throw new NotImplementedException();
        }

        /// <summary>
        /// remove bread crumb
        /// </summary>
        /// <param name="breadCrumb">the bread crumb</param>
        public void RemoveBreadCrumb(string breadCrumb)
        {
            //todo
            throw new NotImplementedException();
        }

        /// <summary>
        /// expand all
        /// </summary>
        public void ExpandAll()
        {
            ExpandAllLink.Wait(3).Click();
        }

        /// <summary>
        /// collapse all
        /// </summary>
        public void CollapseAll()
        {
            CollapseAllLink.Wait(3).Click();
        }
    }
}
