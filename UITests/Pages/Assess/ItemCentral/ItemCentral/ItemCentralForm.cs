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
using UITests.Pages.Assess.Standards;

namespace UITests.Pages.Assess.ItemCentral.ItemCentral
{
    /// <summary>
    /// the item central form
    /// </summary>
    public class ItemCentralForm : SNForm
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="itemCentralType">item central type</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public ItemCentralForm(ItemCentralType itemCentralType, string overrideControlPrefix = null)
            : base()
        {
            this.ItemCentralType = itemCentralType;
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
            StandardControlsForm = new StandardControlsForm(PageNames.ItemCentral, ControlPrefix);
            ItemProperties = new ItemPropertiesForm(PageNames.ItemCentral, ControlPrefix);
            ItemStatistics = new ItemStatisticsForm(PageNames.ItemCentral, ControlPrefix);
            PassageProperties = new PassagePropertiesForm(PageNames.ItemCentral, ControlPrefix);
            SearchPassagesButton = new WebElementWrapper(BySearchPassagesButton);
            TextLink = new WebElementWrapper(ByTextLink);
            TextContainer = new WebElementWrapper(ByTextContainer);
            SearchText = new WebElementWrapper(BySearchText);
            StandardLink = new WebElementWrapper(ByStandardLink);
            StandardContainer = new WebElementWrapper(ByStandardContainer);
            ItemPropertiesLink = new WebElementWrapper(ByItemPropertiesLink);
            ItemPropertiesContainer = new WebElementWrapper(ByItemPropertiesContainer);
            ItemStatisticsLink = new WebElementWrapper(ByItemStatisticsLink);
            ItemStatisticsContainer = new WebElementWrapper(ByItemStatisticsContainer);
            PassagePropertiesLink = new WebElementWrapper(ByPassagePropertiesLink);
            PassagePropertiesContainer = new WebElementWrapper(ByPassagePropertiesContainer);
            PassageReadingLevelsLink = new WebElementWrapper(ByPassageReadingLevelsLink);
            PassageReadingLevelsContainer = new WebElementWrapper(ByPassageReadingLevelsContainer);
        }

        /// <summary>
        /// the data
        /// </summary>
        public ItemCentralData Data
        {
            get
            {
                return (ItemCentralData)base.Data;
            }
            set
            {
                base.Data = value;
                ItemCentralData data = (ItemCentralData)value;
                StandardControlsForm.Data = data.StandardPickerData;
                //initialized in StandardLookup()
                //StandardPicker.Data
                ItemProperties.Data = data.ItemTypeData;
                ItemStatistics.Data = data.ItemStatisticsData;
                PassageProperties.Data = data.PassagePropertiesData;
            }
        }

        /// <summary>
        /// the item central type
        /// </summary>
        public ItemCentralType ItemCentralType { get; set; }
        private StandardControlsForm StandardControlsForm { get; set; }
        /// <summary>
        /// the standard picker form
        /// </summary>
        public StandardPickerForm StandardPicker { get; private set; }
        /// <summary>
        /// the item properties form
        /// </summary>
        public ItemPropertiesForm ItemProperties { get; private set; }
        /// <summary>
        /// the item statistics form
        /// </summary>
        public ItemStatisticsForm ItemStatistics { get; private set; }
        /// <summary>
        /// the passage properties form
        /// </summary>
        public PassagePropertiesForm PassageProperties { get; private set; }
        //TODO: public PassageReadingLevelsForm PassageReadingLevels { get; private set; }

        /// <summary>
        /// the submit by
        /// </summary>
        public override By BySubmit { get { return By.Id(ControlPrefix + "ItemFinder1_ItemFinderSearch1_ButtonSearchItems"); } }
        private By BySearchPassagesButton { get { return By.Id(ControlPrefix + "ItemFinder1_ItemFinderSearch1_ButtonSearchPassages"); } }
        private WebElementWrapper SearchPassagesButton { get; set; }
        private By ByTextLink { get { return By.Id("linkTextSearchToggle"); } }
        private WebElementWrapper TextLink { get; set; }
        private By ByTextContainer { get { return By.Id("conTextSearch"); } }
        private WebElementWrapper TextContainer { get; set; }
        private By BySearchText { get { return By.Id(ControlPrefix + "ItemFinder1_ItemFinderSearch1_txtFullText"); } }
        private WebElementWrapper SearchText { get; set; }
        private By ByStandardLink { get { return By.Id("linkStandardsToggle"); } }
        private WebElementWrapper StandardLink { get; set; }
        private By ByStandardContainer { get { return By.Id("conStandards"); } }
        private WebElementWrapper StandardContainer { get; set; }
        private By ByItemPropertiesLink { get { return By.Id("linkAdvancedSearchToggle"); } }
        private WebElementWrapper ItemPropertiesLink { get; set; }
        private By ByItemPropertiesContainer { get { return By.Id("conAdvancedSearch"); } }
        private WebElementWrapper ItemPropertiesContainer { get; set; }
        private By ByItemStatisticsLink { get { return By.Id("linkStatisticsToggle"); } }
        private WebElementWrapper ItemStatisticsLink { get; set; }
        private By ByItemStatisticsContainer { get { return By.Id("conStatistics"); } }
        private WebElementWrapper ItemStatisticsContainer { get; set; }
        private By ByPassagePropertiesLink { get { return By.Id("linkAdvancedPassageSearchToggle"); } }
        private WebElementWrapper PassagePropertiesLink { get; set; }
        private By ByPassagePropertiesContainer { get { return By.Id("conAdvancedPassageSearch"); } }
        private WebElementWrapper PassagePropertiesContainer { get; set; }
        private By ByPassageReadingLevelsLink { get { return By.Id("linkPassageReadingLevelsToggle"); } }
        private WebElementWrapper PassageReadingLevelsLink { get; set; }
        private By ByPassageReadingLevelsContainer { get { return By.Id("conPassageReadingLevels"); } }
        private WebElementWrapper PassageReadingLevelsContainer { get; set; }

        /// <summary>
        /// expand text
        /// </summary>
        public void ExpandText()
        {
            TextContainer.FakeCssValueStyle = "display: none;";
            if (TextContainer.WaitUntilExists(3).GetAttribute("class").Contains("none"))
            {
                TextLink.Wait(3).Click();
            }
        }

        /// <summary>
        /// collapse text
        /// </summary>
        public void CollapseText()
        {
            TextContainer.FakeAttributeClass = "display: block;";
            if (TextContainer.WaitUntilExists(3).GetAttribute("class").Equals("block"))
            {
                TextLink.Wait(3).Click();
            }
        }

        /// <summary>
        /// expand standard
        /// </summary>
        public void ExpandStandard()
        {
            StandardContainer.FakeCssValueStyle = "display: none;";
            if (StandardContainer.WaitUntilExists(3).GetAttribute("class").Contains("none"))
            {
                StandardLink.Wait(3).Click();
            }
        }

        /// <summary>
        /// collapse standard
        /// </summary>
        public void CollapseStandard()
        {
            StandardContainer.FakeAttributeClass = "display: block;";
            if (StandardContainer.WaitUntilExists(3).GetAttribute("class").Equals("block"))
            {
                StandardLink.Wait(3).Click();
            }
        }

        /// <summary>
        /// expand item properties
        /// </summary>
        public void ExpandItemProperties()
        {
            ItemPropertiesContainer.FakeCssValueStyle = "display: none;";
            if (ItemPropertiesContainer.WaitUntilExists(3).GetAttribute("class").Contains("none"))
            {
                ItemPropertiesLink.Wait(3).Click();
            }
        }

        /// <summary>
        /// collapse item properties
        /// </summary>
        public void CollapseItemProperties()
        {
            ItemPropertiesContainer.FakeAttributeClass = "display: block;";
            if (ItemPropertiesContainer.WaitUntilExists(3).GetAttribute("class").Equals("block"))
            {
                ItemPropertiesLink.Wait(3).Click();
            }
        }

        /// <summary>
        /// expand item statistics
        /// </summary>
        public void ExpandItemStatistics()
        {
            ItemStatisticsContainer.FakeCssValueStyle = "display: none;";
            if (ItemStatisticsContainer.WaitUntilExists(3).GetAttribute("class").Contains("none"))
            {
                ItemStatisticsLink.Wait(3).Click();
            }
        }

        /// <summary>
        /// collapse item statistics
        /// </summary>
        public void CollapseItemStatistics()
        {
            ItemStatisticsContainer.FakeAttributeClass = "display: block;";
            if (ItemStatisticsContainer.WaitUntilExists(3).GetAttribute("class").Equals("block"))
            {
                ItemStatisticsLink.Wait(3).Click();
            }
        }

        /// <summary>
        /// expand passage properties
        /// </summary>
        public void ExpandPassageProperties()
        {
            PassagePropertiesContainer.FakeCssValueStyle = "display: none;";
            if (PassagePropertiesContainer.WaitUntilExists(3).GetAttribute("class").Contains("none"))
            {
                PassagePropertiesLink.Wait(3).Click();
            }
        }

        /// <summary>
        /// collapse passage properties
        /// </summary>
        public void CollapsePassageProperties()
        {
            PassagePropertiesContainer.FakeAttributeClass = "display: block;";
            if (PassagePropertiesContainer.WaitUntilExists(3).GetAttribute("class").Equals("block"))
            {
                PassagePropertiesLink.Wait(3).Click();
            }
        }

        /// <summary>
        /// expand passage reading levels
        /// </summary>
        public void ExpandPassageReadingLevels()
        {
            PassageReadingLevelsContainer.FakeCssValueStyle = "display: none;";
            if (PassageReadingLevelsContainer.WaitUntilExists(3).GetAttribute("class").Contains("none"))
            {
                PassageReadingLevelsLink.Wait(3).Click();
            }
        }

        /// <summary>
        /// collapse passage reading levels
        /// </summary>
        public void CollapsePassageReadingLevels()
        {
            PassageReadingLevelsContainer.FakeAttributeClass = "display: block;";
            if (PassageReadingLevelsContainer.WaitUntilExists(3).GetAttribute("class").Equals("block"))
            {
                PassageReadingLevelsLink.Wait(3).Click();
            }
        }

        /// <summary>
        /// select the standard lookup button
        /// </summary>
        /// <returns>StandardPickerForm</returns>
        public StandardPickerForm StandardLookup()
        {
            this.StandardPicker = StandardControlsForm.StandardLookup_StandardForm();
            this.StandardPicker.Data = Data.StandardPickerData;
            return this.StandardPicker;
        }

        /// <summary>
        /// select the edit standard link
        /// </summary>
        /// <returns>this StandardControlsForm</returns>
        public StandardControlsForm EditStandard()
        {
            return StandardControlsForm.EditStandard();
        }

        /// <summary>
        /// set the standard document and ID
        /// </summary>
        /// <param name="standardDocument">the standard document</param>
        /// <param name="standardId">the standard ID</param>
        /// <returns>this StandardControlsForm</returns>
        public ItemCentralStandardPickerPage SelectStandard(string standardDocument, string standardId)
        {
            StandardControlsForm.SelectStandard(standardDocument, standardId);
            return new ItemCentralStandardPickerPage(this.ItemCentralType);
        }

        /// <summary>
        /// select search passages
        /// </summary>
        public void SearchPassages()
        {
            SearchPassagesButton.Wait(3).Click();
        }

        public override void InputFormFields()
        {
            if (Data.ItemTypeData != null)
            {
                ItemProperties.InputFormFields();
            }
        }

        public override IBaseScreenView ReturnSubmitPage()
        {
            return new ItemCentralSearchResultsPage(this.ItemCentralType);
        }
    }
}
