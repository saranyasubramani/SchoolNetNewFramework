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
using UITests.Pages.Assess.ItemCentral.ItemCentralHome.Items;
using UITests.Pages.Assess.ItemCentral.ItemCentralHome.Passage;
using UITests.Pages.Assess.ItemCentral.ItemCentralHome.Rubric;
using UITests.Pages.Assess.ItemCreateEdit.v01;
using UITests.Pages.Assess.Passage;
using UITests.Pages.Assess.Rubric;

namespace UITests.Pages.Assess.ItemCentral.ItemCentralHome
{
    /// <summary>
    /// the item central home detail
    /// </summary>
    public class ItemCentralHomeDetail : SNDetail
    {
        /// <summary>
        /// the item central home detail constructor
        /// </summary>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public ItemCentralHomeDetail(string overrideControlPrefix = null)
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
            AssessLinks = new AssessLinks(PageNames.ItemCentralHome, ControlPrefix);
            AdvancedSearchLink = new WebElementWrapper(ByAdvancedSearchLink);
            ItemsLink = new WebElementWrapper(ByItemsLink);
            PassagesLink = new WebElementWrapper(ByPassagesLink);
            RubricsLink = new WebElementWrapper(ByRubricsLink);
            ItemCentralItemsDetailTab = new ItemCentralItemsDetailTab();
            ItemCentralPassagesDetailTab = new ItemCentralPassagesDetailTab();
            ItemCentralRubricsDetailTab = new ItemCentralRubricsDetailTab();

            //stop hover over menu
            //SiteTitleLabel = new WebElementWrapper(Driver, BySiteTitleLabel);
            try
            {
                //SiteTitleLabel.Wait(3).Click();
                this.Utilities.FocusOnMainContentArea();//this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            }
            catch (Exception e)
            {
                //do nothing
            }
        }

        /// <summary>
        /// the data
        /// </summary>
        public ItemCentralHomeData Data
        {
            get
            {
                return (ItemCentralHomeData)base.Data;
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

        //protected By BySiteTitleLabel { get { return By.CssSelector(".SiteTitle"); } }
        //protected WebElementWrapper SiteTitleLabel { get; set; }

        private AssessLinks AssessLinks { get; set; }
        private By ByAdvancedSearchLink { get { return By.Id(ControlPrefix + "ItemFinderSearchCompressed1_linkSearchType"); } }
        private WebElementWrapper AdvancedSearchLink { get; set; }

        private By ByItemsLink { get { return By.Id(ControlPrefix + "LinkButtonItemSearch"); } }
        private WebElementWrapper ItemsLink { get; set; }
        private By ByPassagesLink { get { return By.Id(ControlPrefix + "LinkButtonPassageSearch"); } }
        private WebElementWrapper PassagesLink { get; set; }
        private By ByRubricsLink { get { return By.Id(ControlPrefix + "LinkButtonRubricSearch"); } }
        private WebElementWrapper RubricsLink { get; set; }

        private ItemCentralItemsDetailTab ItemCentralItemsDetailTab { get; set; }
        private ItemCentralPassagesDetailTab ItemCentralPassagesDetailTab { get; set; }
        private ItemCentralRubricsDetailTab ItemCentralRubricsDetailTab { get; set; }

        /// <summary>
        /// Select advanced search
        /// </summary>
        public ItemCentralPage AdvancedSearch()
        {
            try
            {   //stop hover over menu
                //SiteTitleLabel.Wait(3).Click();
                this.Utilities.FocusOnMainContentArea();//this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            }
            catch (Exception e)
            {
                //do nothing
            }
            AdvancedSearchLink.Click();
            return new ItemCentralPage(this.ItemCentralType);
        }
        /// <summary>
        /// create an item
        /// </summary>
        /// <returns>EditTestItemChooseNewItemPage</returns>
        public EditTestItemChooseNewItemPage CreateAnItem()
        {
            try
            {   //stop hover over menu
                //SiteTitleLabel.Wait(3).Click();
                this.Utilities.FocusOnMainContentArea();//this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            }
            catch (Exception e)
            {
                //do nothing
            }
            return AssessLinks.CreateAnItem();
        }
        /// <summary>
        /// create a passage
        /// </summary>
        /// <returns>EditPassagePage</returns>
        public EditPassagePage CreateAPassage()
        {
            try
            {   //stop hover over menu
                //SiteTitleLabel.Wait(3).Click();
                this.Utilities.FocusOnMainContentArea();//this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            }
            catch (Exception e)
            {
                //do nothing
            }
            return AssessLinks.CreateAPassage();
        }
        /// <summary>
        /// create a rubric
        /// </summary>
        /// <returns>ChooseGroupingRubricDialog</returns>
        public ChooseGroupingRubricDialog CreateARubric()
        {
            try
            {   //stop hover over menu
                //SiteTitleLabel.Wait(3).Click();
                this.Utilities.FocusOnMainContentArea();//this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            }
            catch (Exception e)
            {
                //do nothing
            }
            // To be recode using AssessLinks component. 
            // Selenium 2.37 dll issue. Click CreateRubric link, selenium thinks it click
            // successfully, but it didn't
            //return AssessLinks.CreateARubric();
            string startUrl = "";
            if (Driver.GetType() == typeof(DriverWrapper))
            {
                startUrl = this.TestConfiguration.ApplicationPath + "/";
            }
            if (Driver.GetType() == typeof(DummyDriver))
            {
                startUrl = this.TestConfiguration.ApplicationPath + "/";
            }
            Driver.Navigate().GoToUrl(startUrl + "Assess/Items/EditRubric.aspx");
            return new ChooseGroupingRubricDialog();
        }
        /// <summary>
        /// pending items
        /// </summary>
        /// <returns>?</returns>
        public SNWebPage PendingItems()
        {
            try
            {   //stop hover over menu
                //SiteTitleLabel.Wait(3).Click();
                this.Utilities.FocusOnMainContentArea();//this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            }
            catch (Exception e)
            {
                //do nothing
            }
            return AssessLinks.PendingItems();
        }
        /// <summary>
        /// select items tab
        /// </summary>
        public void SelectItemsTab()
        {
            try
            {   //stop hover over menu
                //SiteTitleLabel.Wait(3).Click();
                this.Utilities.FocusOnMainContentArea();//this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            }
            catch (Exception e)
            {
                //do nothing
            }
            ItemsLink.Wait(3).Click();
            this.ItemCentralType = ItemCentralType.Item;
            ((ItemCentralHomePage)this.Parent).ItemCentralType = this.ItemCentralType;
        }
        /// <summary>
        /// select passages tab
        /// </summary>
        public void SelectPassagesTab()
        {
            try
            {   //stop hover over menu
                //SiteTitleLabel.Wait(3).Click();
                this.Utilities.FocusOnMainContentArea();//this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            }
            catch (Exception e)
            {
                //do nothing
            }
            PassagesLink.Wait(3).Click();
            this.ItemCentralType = ItemCentralType.Passage;
            ((ItemCentralHomePage)this.Parent).ItemCentralType = this.ItemCentralType;
        }
        /// <summary>
        /// select rubrics tab
        /// </summary>
        public void SelectRubricsTab()
        {
            try
            {   //stop hover over menu
                //SiteTitleLabel.Wait(3).Click();
                this.Utilities.FocusOnMainContentArea();//this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            }
            catch (Exception e)
            {
                //do nothing
            }
            RubricsLink.Wait(3).Click();
            this.ItemCentralType = ItemCentralType.Rubric;
            ((ItemCentralHomePage)this.Parent).ItemCentralType = this.ItemCentralType;
        }
        /// <summary>
        /// items tab
        /// </summary>
        /// <returns>ItemCentralItemsDetailTab</returns>
        public ItemCentralItemsDetailTab ItemsTab()
        {
            return ItemCentralItemsDetailTab;
        }
        /// <summary>
        /// passages tab
        /// </summary>
        /// <returns>ItemCentralPassagesDetailTab</returns>
        public ItemCentralPassagesDetailTab PassagesTab()
        {
            return ItemCentralPassagesDetailTab;
        }
        /// <summary>
        /// rubrics tab
        /// </summary>
        /// <returns>ItemCentralRubricsDetailTab</returns>
        public ItemCentralRubricsDetailTab RubricsTab()
        {
            return ItemCentralRubricsDetailTab;
        }
    }
}
