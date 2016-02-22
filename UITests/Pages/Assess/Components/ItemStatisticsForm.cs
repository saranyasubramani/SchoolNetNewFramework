using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;

namespace UITests.Pages.Assess.Components
{
    /// <summary>
    /// the item type map form
    /// </summary>
    public class ItemStatisticsForm : SNForm
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="driver">IWebDriver</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public ItemStatisticsForm(PageNames pageNames, string overrideControlPrefix = null)
            : base()
        {
            this.PageNames = pageNames;
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
            switch (PageNames)
            {
                case PageNames.CreateTestBySelectingStandardsPage:
                    //ctl00_MainContent_TestMapControl1_txtPValueLow
                    //ctl00_MainContent_TestMapControl1_txtResponseTimeLow
                    ControlMiddle = "TestMapControl1_";
                    break;
                case PageNames.ItemCentral:
                    //ctl00_MainContent_ItemFinder1_ItemFinderSearch1_txtPValueLow
                    //ctl00_MainContent_ItemFinder1_ItemFinderSearch1_txtResponseTimeLow
                    ControlMiddle = "ItemFinder1_ItemFinderSearch1_";
                    break;
            }
            ItemTypeSelect = new SelectElementWrapper(new WebElementWrapper(ByItemTypeSelect));
            BloomsTaxonomySelect = new SelectElementWrapper(new WebElementWrapper(ByBloomsTaxonomySelect));
            PValueLowText = new WebElementWrapper(ByPValueLowText);
            PValueHighText = new WebElementWrapper(ByPValueHighText);
            ItemMeanLowText = new WebElementWrapper(ByItemMeanLowText);
            ItemMeanHighText = new WebElementWrapper(ByItemMeanHighText);
            ItemTotalScoreLowText = new WebElementWrapper(ByItemTotalScoreLowText);
            ItemTotalScoreHighText = new WebElementWrapper(ByItemTotalScoreHighText);
            RaschItemDifficultyLowText = new WebElementWrapper(ByRaschItemDifficultyLowText);
            RaschItemDifficultyHighText = new WebElementWrapper(ByRaschItemDifficultyHighText);
            ResponseTimeLowText = new WebElementWrapper(ByResponseTimeLowText);
            ResponseTimeHighText = new WebElementWrapper(ByResponseTimeHighText);
            PassageTypeSelect = new SelectElementWrapper(new WebElementWrapper(ByPassageTypeSelect));
            QuestionLanguageSelect = new SelectElementWrapper(new WebElementWrapper(ByQuestionLanguageSelect));
            ExcludeItemsOnCurrentYearTestsButton = new WebElementWrapper(ByExcludeItemsOnCurrentYearTestsButton);
            ExcludeItemsWithPassagesButton = new WebElementWrapper(ByExcludeItemsWithPassagesButton);
            SearchItemCentralItemsMatchingTestMapStandardsButton = new WebElementWrapper(BySearchItemCentralItemsMatchingTestMapStandardsButton);
            // Added by oleg
            Written_chkbox = new WebElementWrapper(ByWritten_chkbox);
            Spoken_chkbox = new WebElementWrapper(BySpoken_chkbox);
        }

        /// <summary>
        /// the data
        /// </summary>
        public ItemStatisticsData Data
        {
            get
            {
                return (ItemStatisticsData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        private PageNames PageNames { get; set; }
        private string ControlMiddle { get; set; }
        private By ByItemTypeSelect { get { return By.Id(ControlPrefix + ControlMiddle + "DropDownListItemTypes"); } }
        private SelectElementWrapper ItemTypeSelect { get; set; }
        private By ByBloomsTaxonomySelect { get { return By.Id(ControlPrefix + ControlMiddle + "DropDownListBlooms"); } }
        private SelectElementWrapper BloomsTaxonomySelect { get; set; }
        private By ByPValueLowText { get { return By.Id(ControlPrefix + ControlMiddle + "txtPValueLow"); } }
        private WebElementWrapper PValueLowText { get; set; }
        private By ByPValueHighText { get { return By.Id(ControlPrefix + ControlMiddle + "txtPValueHigh"); } }
        private WebElementWrapper PValueHighText { get; set; }
        private By ByItemMeanLowText { get { return By.Id(ControlPrefix + ControlMiddle + "txtItemMeanLow"); } }
        private WebElementWrapper ItemMeanLowText { get; set; }
        private By ByItemMeanHighText { get { return By.Id(ControlPrefix + ControlMiddle + "txtItemMeanHigh"); } }
        private WebElementWrapper ItemMeanHighText { get; set; }
        private By ByItemTotalScoreLowText { get { return By.Id(ControlPrefix + ControlMiddle + "txtTotalScoreLow"); } }
        private WebElementWrapper ItemTotalScoreLowText { get; set; }
        private By ByItemTotalScoreHighText { get { return By.Id(ControlPrefix + ControlMiddle + "txtTotalScoreHigh"); } }
        private WebElementWrapper ItemTotalScoreHighText { get; set; }
        private By ByRaschItemDifficultyLowText { get { return By.Id(ControlPrefix + ControlMiddle + "txtRaschLow"); } }
        private WebElementWrapper RaschItemDifficultyLowText { get; set; }
        private By ByRaschItemDifficultyHighText { get { return By.Id(ControlPrefix + ControlMiddle + "txtRaschHigh"); } }
        private WebElementWrapper RaschItemDifficultyHighText { get; set; }
        private By ByResponseTimeLowText { get { return By.Id(ControlPrefix + ControlMiddle + "txtResponseTimeLow"); } }
        private WebElementWrapper ResponseTimeLowText { get; set; }
        private By ByResponseTimeHighText { get { return By.Id(ControlPrefix + ControlMiddle + "txtResponseTimeHigh"); } }
        private WebElementWrapper ResponseTimeHighText { get; set; }
        private By ByPassageTypeSelect { get { return By.Id(ControlPrefix + ControlMiddle + "DropDownListPassageTypes"); } }
        private SelectElementWrapper PassageTypeSelect { get; set; }
        private By ByQuestionLanguageSelect { get { return By.Id(ControlPrefix + ControlMiddle + "DropDownListLanguage"); } }
        private SelectElementWrapper QuestionLanguageSelect { get; set; }
        private By ByExcludeItemsOnCurrentYearTestsButton { get { return By.Id(ControlPrefix + ControlMiddle + "CheckBoxExclude"); } }
        private WebElementWrapper ExcludeItemsOnCurrentYearTestsButton { get; set; }
        private By ByExcludeItemsWithPassagesButton { get { return By.Id(ControlPrefix + ControlMiddle + "CheckBoxNoPassages"); } }
        private WebElementWrapper ExcludeItemsWithPassagesButton { get; set; }
        private By BySearchItemCentralItemsMatchingTestMapStandardsButton { get { return By.Id(ControlPrefix + ControlMiddle + "CheckBoxSearchItemCentral"); } }
        private WebElementWrapper SearchItemCentralItemsMatchingTestMapStandardsButton { get; set; }
        // added by oleg for open response 
        public By ByWritten_chkbox { get { return By.Id(ControlPrefix + ControlMiddle + "chkWritten"); } }
        public WebElementWrapper Written_chkbox { get; private set; }
        public By BySpoken_chkbox { get { return By.Id(ControlPrefix + ControlMiddle + "chkSpoken"); } }
        public WebElementWrapper Spoken_chkbox { get; private set; }
        /// <summary>
        /// the submit by
        /// </summary>
        public override By BySubmit { get { return By.Id(ControlPrefix + ControlMiddle + "LinkButtonApplyOptions"); } }


        private bool VerifySpokenCheckboxExist()
        {
            bool isFound = true;
            try
            {
                Spoken_chkbox.Wait(3);
            }

            catch (Exception e)
            {
                isFound = false;
            }
            return isFound;
        }

        /// <summary>
        /// check Exclude items on current year tests 
        /// </summary>
        public void CheckExcludeItemsOnCurrentYearTests()
        {
            ExcludeItemsOnCurrentYearTestsButton.Wait(5).Check();
        }
        /// <summary>
        /// uncheck Exclude items on current year tests 
        /// </summary>
        public void UnCheckExcludeItemsOnCurrentYearTests()
        {
            ExcludeItemsOnCurrentYearTestsButton.Wait(5).UnCheck();
        }
        /// <summary>
        /// check Exclude items with Passages 
        /// </summary>
        public void CheckExcludeItemsWithPassages()
        {
            ExcludeItemsWithPassagesButton.Wait(5).Check();
        }
        /// <summary>
        /// uncheck Exclude items with Passages 
        /// </summary>
        public void UnCheckExcludeItemsWithPassages()
        {
            ExcludeItemsWithPassagesButton.Wait(5).UnCheck();
        }
        /// <summary>
        /// check Search Item Central for items matching the selected standards in your Test Map 
        /// </summary>
        public void CheckSearchItemCentralItemsMatchingTestMapStandards()
        {
            SearchItemCentralItemsMatchingTestMapStandardsButton.Wait(5).Check();
        }
        /// <summary>
        /// uncheck Search Item Central for items matching the selected standards in your Test Map 
        /// </summary>
        public void UnCheckSearchItemCentralItemsMatchingTestMapStandards()
        {
            SearchItemCentralItemsMatchingTestMapStandardsButton.Wait(5).UnCheck();
        }
        /// <summary>
        /// select item type
        /// </summary>
        public void SelectItemType()
        {
            ItemTypeSelect.Wait(5).SelectByText(Data.ItemType);
        }
        /// <summary>
        /// select item type
        /// </summary>
        /// <param name="itemType">the item type</param>
        public void SelectItemType(string itemType)
        {
            ItemTypeSelect.Wait(5).SelectByText(itemType);
        }

        /// <summary>
        /// select question language
        /// </summary>
        public void SelectQuestionLanguage()
        {
            QuestionLanguageSelect.Wait(5).SelectByText(Data.QuestionLanguage);
        }

        /// <summary>
        /// select item type
        /// </summary>
        public void InputFormFields_ItemType()
        {
            if (Data.ItemType != null)
            {
                ItemTypeSelect.Wait(5).SelectByText(Data.ItemType);
            }
        }

        public override void InputFormFields()
        {
            if (Data.ItemType != null)
            {
                ItemTypeSelect.Wait(5).SelectByText(Data.ItemType);
            }
            if (Data.BloomsTaxonomy != null)
            {
                BloomsTaxonomySelect.SelectByText(Data.BloomsTaxonomy);
            }
            if (Data.PValueLow != null)
            {
                PValueLowText.SendKeys("" + Data.PValueLow);
            }
            if (Data.PValueHigh != null)
            {
                PValueHighText.SendKeys("" + Data.PValueHigh);
            }
            if (Data.ItemMeanLow != null)
            {
                ItemMeanLowText.SendKeys("" + Data.ItemMeanLow);
            }
            if (Data.ItemMeanHigh != null)
            {
                ItemMeanHighText.SendKeys("" + Data.ItemMeanHigh);
            }
            if (Data.ItemTotalScoreLow != null)
            {
                ItemTotalScoreLowText.SendKeys("" + Data.ItemTotalScoreLow);
            }
            if (Data.ItemTotalScoreHigh != null)
            {
                ItemTotalScoreHighText.SendKeys("" + Data.ItemTotalScoreHigh);
            }
            if (Data.RaschItemDifficultyLow != null)
            {
                RaschItemDifficultyLowText.SendKeys("" + Data.RaschItemDifficultyLow);
            }
            if (Data.RaschItemDifficultyHigh != null)
            {
                RaschItemDifficultyHighText.SendKeys("" + Data.RaschItemDifficultyHigh);
            }
            if (Data.ResponseTimeLow != null)
            {
                ResponseTimeLowText.SendKeys("" + Data.ResponseTimeLow);
            }
            if (Data.ResponseTimeHigh != null)
            {
                ResponseTimeHighText.SendKeys("" + Data.ResponseTimeHigh);
            }
            if (Data.PassageType != null)
            {
                PassageTypeSelect.SelectByText(Data.PassageType);
            }
            if (Data.QuestionLanguage != null)
            {
                QuestionLanguageSelect.SelectByText(Data.QuestionLanguage);
            }
            if (Data.Written != null)
            {
                if (Data.Written.Equals("1"))
                {
                    Written_chkbox.Check();
                }
            }
            if (Data.Spoken != null)
            {
                if (Data.Spoken.Equals("1"))
                {
                    VerifySpokenCheckboxExist();
                    Spoken_chkbox.Check();
                }
            }
            else { VerifySpokenCheckboxExist(); }
        }
    }
}
