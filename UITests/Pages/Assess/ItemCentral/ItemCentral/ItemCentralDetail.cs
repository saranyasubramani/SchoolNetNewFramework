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
using UITests.Pages.Assess.Components;
using UITests.Pages.Assess.ItemCreateEdit.v01;
using UITests.Pages.Assess.Passage;
using UITests.Pages.Assess.Rubric;

namespace UITests.Pages.Assess.ItemCentral.ItemCentral
{
    /// <summary>
    /// the item central detail
    /// </summary>
    public class ItemCentralDetail : SNDetail
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="itemCentralType">item central type</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public ItemCentralDetail(ItemCentralType itemCentralType, string overrideControlPrefix = null)
            : base()
        {
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }
            this.ItemCentralType = itemCentralType;
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            AssessLinks = new AssessLinks(PageNames.ItemCentral, ControlPrefix);
            BackToPreviousPageLink = new WebElementWrapper(ByBackToPreviousPageLink);
        }

        /// <summary>
        /// the data
        /// </summary>
        public new ItemCentralData Data
        {
            get
            {
                return (ItemCentralData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        /// <summary>
        /// the item central type
        /// </summary>
        public ItemCentralType ItemCentralType { get; set; }
        private AssessLinks AssessLinks { get; set; }
        private By ByBackToPreviousPageLink { get { return By.Id("ctl00_AppTitle_BackToPreviousPageControl_HyperLinkBack"); } }
        private WebElementWrapper BackToPreviousPageLink { get; set; }

        /// <summary>
        /// back to previous page
        /// </summary>
        public void BackToPreviousPage()
        {
            BackToPreviousPageLink.Click();
        }

        /// <summary>
        /// create an item
        /// </summary>
        /// <returns>EditTestItemChooseNewItemPage</returns>
        public EditTestItemChooseNewItemPage CreateAnItem()
        {
            return AssessLinks.CreateAnItem();
        }
        /// <summary>
        /// create a passage
        /// </summary>
        /// <returns>EditPassagePage</returns>
        public EditPassagePage CreateAPassage()
        {
            return AssessLinks.CreateAPassage();
        }
        /// <summary>
        /// create a rubric
        /// </summary>
        /// <returns>ChooseGroupingRubricDialog</returns>
        public ChooseGroupingRubricDialog CreateARubric()
        {
            return AssessLinks.CreateARubric();
        }
    }
}
