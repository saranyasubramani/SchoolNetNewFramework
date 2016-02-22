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
using UITests.Pages.Controls;
using UITests.Pages.Assess.ItemCreateEdit.v01.ItemForms;

namespace UITests.Pages.Assess.ItemCreateEdit.v01.ViewItemStatistics
{
    /// <summary>
    /// the view item statistics detail
    /// </summary>
    public class ViewItemStatisticsDetail : SNDetail
    {
        /// <summary>
        /// constructor
        /// </summary>
        public ViewItemStatisticsDetail()
            : base()
        {
            //TODO: need an index?
            //I don't know if there are more than one items displayed on this page
            InitElements();
        }
        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            ItemContent = new WebElementWrapper(ByItemContent);
            PassageContent = new WebElementWrapper(ByPassageContent);

            PreviousPageBottomLink = new PreviousPageBottomLink(PageNames.ViewItemStatistics, ControlPrefix);

            Edit_Link = new WebElementWrapper(ByEditItem_Link);
            Copy_Link = new WebElementWrapper(ByCopyItem_Link);
            Preview_Dropdown = new SelectElementWrapper(new WebElementWrapper(ByPreviewItem_Dropwdown));
            AddToTest_Link = new WebElementWrapper(ByAddToTest_Link);
            ChangeStatus_Link = new WebElementWrapper(ByChangeStatus_Link);
            ReturnThisItem_Link = new WebElementWrapper(ByReturnThisItem_Link);
            Delete_Link = new WebElementWrapper(ByDelete_Link);
            ViewStatus_textLabel = new WebElementWrapper(ByViewStatus_textLabel);
            PropertiesLink = new WebElementWrapper(ByPropertiesLink);
            PropertiesContainer = new WebElementWrapper(ByPropertiesContainer);
            NameLabel = new WebElementWrapper(ByNameLabel);
            QuestionLabel = new WebElementWrapper(ByQuestionLabel);
            PublisherLabel = new WebElementWrapper(ByPublisherLabel);
            KeywordsLabel = new WebElementWrapper(ByKeywordsLabel);
            AuthoredDifficultyLabel = new WebElementWrapper(ByAuthoredDifficultyLabel);
            BloomsTaxonomyLabel = new WebElementWrapper(ByBloomsTaxonomyLabel);
            WebbLabel = new WebElementWrapper(ByWebbLabel);
            CognitiveDemandLevelLabel = new WebElementWrapper(ByCognitiveDemandLevelLabel);
            AdditionalItemIdentifierLabel = new WebElementWrapper(ByAdditionalItemIdentifierLabel);
            BatchLabel = new WebElementWrapper(ByBatchLabel);
            CourseIdLabel = new WebElementWrapper(ByCourseIdLabel);
            CourseSpecificItemsLabel = new WebElementWrapper(ByCourseSpecificItemsLabel);
            CurriculumLabel = new WebElementWrapper(ByCurriculumLabel);
            HardToMeasureContentAreaLabel = new WebElementWrapper(ByHardToMeasureContentAreaLabel);
            ItemCategoryLabel = new WebElementWrapper(ByItemCategoryLabel);
            YearLabel = new WebElementWrapper(ByYearLabel);
            FormulaReferenceSheetLabel = new WebElementWrapper(ByFormulaReferenceSheetLabel);

            Grid = new ViewItemStatisticsGrid(gridCssSelector, false, this.ControlPrefix);
        }

        /// <summary>
        /// the data
        /// </summary>
        public ItemTypeData Data
        {
            get
            {
                return (ItemTypeData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }
        
        /// <summary>
        /// the line item's index
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// fake text
        /// </summary>
        public string FakeText { get; set; }
        private string gridCssSelector { get { return "#" + ControlPrefix + "ItemPassageControl_gridPassages"; } }
        /// <summary>
        /// the grid
        /// </summary>
        public ViewItemStatisticsGrid Grid { get; private set; }
        private By ByItemContent { get { return By.Id("contentDiv"); } }
        private WebElementWrapper ItemContent { get; set; }
        private By ByPassageContent { get { return By.CssSelector("#divPassageContent_" + Index + " p"); } }
        private WebElementWrapper PassageContent { get; set; }
        /// <summary>
        /// previous page link
        /// </summary>
        public PreviousPageBottomLink PreviousPageBottomLink { get; set; }

        //ITEM DETAIL LINKS
        //Not all will be shown (depends on item state)
        //private By ByEditItem_Link { get { return By.Id(ControlPrefix + "ButtonEditItem"); } }
        private By ByEditItem_Link { get { return By.CssSelector("a[href*='EditTestItem.aspx']"); } }
        private WebElementWrapper Edit_Link { get; set; }
        private By ByCopyItem_Link { get { return By.Id(ControlPrefix + "ButtonCopyItem"); } }
        private WebElementWrapper Copy_Link { get; set; }
        private By ByPreviewItem_Dropwdown { get { return By.LinkText("Preview"); } }
        private SelectElementWrapper Preview_Dropdown { get; set; }
        private By ByAddToTest_Link { get { return By.Id(ControlPrefix + "ButtonAddItem"); } }
        private WebElementWrapper AddToTest_Link { get; set; }
        private By ByChangeStatus_Link { get { return By.Id(ControlPrefix + "ButtonChangeItemAvailability"); } }
        private WebElementWrapper ChangeStatus_Link { get; set; }
        private By ByReturnThisItem_Link { get { return By.Id("ReturnItemLink"); } }
        private WebElementWrapper ReturnThisItem_Link { get; set; }
        private By ByDelete_Link { get { return By.Id(ControlPrefix + "ButtonDeleteItem"); } }
        private WebElementWrapper Delete_Link { get; set; }

        //ITEM METADATA (shown as labels on right side of page.  Not all coded at the moment (and might never need all)
        private By ByViewStatus_textLabel { get { return By.Id("spanStatus"); } }
        private WebElementWrapper ViewStatus_textLabel { get; set; }
        private By ByPropertiesLink { get { return By.Id("linkPropertiesToggle"); } }
        private WebElementWrapper PropertiesLink { get; set; }
        private By ByPropertiesContainer { get { return By.Id("conProperties"); } }
        private WebElementWrapper PropertiesContainer { get; set; }
        private By ByNameLabel { get { return By.Id(ControlPrefix + "lblNameValue"); } }
        private WebElementWrapper NameLabel { get; set; }
        private By ByQuestionLabel { get { return By.Id(ControlPrefix + "lblQuestionLanguageValue"); } }
        private WebElementWrapper QuestionLabel { get; set; }
        private By ByPublisherLabel { get { return By.Id(ControlPrefix + "lblPublisherValue"); } }
        private WebElementWrapper PublisherLabel { get; set; }
        private By ByKeywordsLabel { get { return By.Id(ControlPrefix + "lblKeywordsValue"); } }
        private WebElementWrapper KeywordsLabel { get; set; }
        private By ByAuthoredDifficultyLabel { get { return By.Id(ControlPrefix + "lblAuthoredValue"); } }
        private WebElementWrapper AuthoredDifficultyLabel { get; set; }
        private By ByBloomsTaxonomyLabel { get { return By.Id(ControlPrefix + "lblBloomTaxonomyValue"); } }
        private WebElementWrapper BloomsTaxonomyLabel { get; set; }
        private By ByWebbLabel { get { return By.Id(ControlPrefix + "lblWebbValue"); } }
        private WebElementWrapper WebbLabel { get; set; }
        private By ByCognitiveDemandLevelLabel { get { return By.Id(ControlPrefix + "lblCognitiveLevelValue"); } }
        private WebElementWrapper CognitiveDemandLevelLabel { get; set; }
        private By ByAdditionalItemIdentifierLabel { get { return By.Id(ControlPrefix + "lblAdditionalItemValue"); } }
        private WebElementWrapper AdditionalItemIdentifierLabel { get; set; }
        private By ByBatchLabel { get { return By.Id(ControlPrefix + "lblBatchValue"); } }
        private WebElementWrapper BatchLabel { get; set; }
        private By ByCourseIdLabel { get { return By.Id(ControlPrefix + "lblCourseIdValue"); } }
        private WebElementWrapper CourseIdLabel { get; set; }
        private By ByCourseSpecificItemsLabel { get { return By.Id(ControlPrefix + "RepeaterItemAttributes_ctl00_lblItemAttributesValue"); } }
        private WebElementWrapper CourseSpecificItemsLabel { get; set; }
        private By ByCurriculumLabel { get { return By.Id(ControlPrefix + "RepeaterItemAttributes_ctl01_lblItemAttributesValue"); } }
        private WebElementWrapper CurriculumLabel { get; set; }
        private By ByHardToMeasureContentAreaLabel { get { return By.Id(ControlPrefix + "lblHardToMesureValue"); } }
        private WebElementWrapper HardToMeasureContentAreaLabel { get; set; }
        private By ByItemCategoryLabel { get { return By.Id(ControlPrefix + "lblItemCategoryValue"); } }
        private WebElementWrapper ItemCategoryLabel { get; set; }
        private By ByYearLabel { get { return By.Id(ControlPrefix + "lblYearValue"); } }
        private WebElementWrapper YearLabel { get; set; }
        private By ByFormulaReferenceSheetLabel { get { return By.Id(ControlPrefix + "lblFormulaReferenceValue"); } }
        private WebElementWrapper FormulaReferenceSheetLabel { get; set; }

        //FUNCTIONS

        /// <summary>
        /// get the item's text content
        /// </summary>
        /// <returns>text content</returns>
        public string GetItemContentText()
        {
            return ItemContent.Text;
        }
        /// <summary>
        /// get the passage's text content
        /// </summary>
        /// <returns>text content</returns>
        public string GetPassageContentText()
        {
            return PassageContent.Text;
        }

        /// <summary>
        /// back to previous page
        /// </summary>
        public void BackToPreviousPage()
        {
            PreviousPageBottomLink.Control.Wait(3).Click();
        }
        /// <summary>
        /// edit item
        /// </summary>
        public void EditItem()
        {
            Utilities.FocusOnMainContentArea(); //stop hover over menu
            Edit_Link.Click();
        }
        /// <summary>
        /// copy item
        /// </summary>
        public void CopyItem()
        {
            Utilities.FocusOnMainContentArea(); //stop hover over menu
            Copy_Link.Click();
        }
        /// <summary>
        /// preview item
        /// </summary>
        /// <param name="itemToSelect"></param>
        public void PreviewItem(string itemToSelect)
        {
            Utilities.FocusOnMainContentArea(); //stop hover over menu
            Preview_Dropdown.SelectByText(itemToSelect);
        }
        /// <summary>
        /// add item to test
        /// </summary>
        public void AddItemToTest()
        {
            Utilities.FocusOnMainContentArea(); //stop hover over menu
            AddToTest_Link.Click();
        }
        /// <summary>
        /// change item status
        /// </summary>
        public void ChangeItemStatus()
        {
            Utilities.FocusOnMainContentArea(); //stop hover over menu
            ChangeStatus_Link.Click();
        }
        /// <summary>
        /// return item
        /// </summary>
        public void ReturnItem()
        {
            Utilities.FocusOnMainContentArea(); //stop hover over menu
            ReturnThisItem_Link.Click();
        }

        /// <summary>
        /// Delete the item and Accept the Alert.
        /// </summary>
        public void DeleteItem()
        {
            this.Parent.CurrentWindowHandle = Driver.CurrentWindowHandle;
            Report.Write("The current window is: '" + this.Parent.CurrentWindowHandle + "'.");

            Utilities.FocusOnMainContentArea(); //stop hover over menu
            Delete_Link.Wait(3).Click();

            AlertHandler alert = new AlertHandler();
            alert.VerifyText("Are you sure you wish to delete this item?");
            alert.Accept();

            //switch to window
            DriverCommands.WaitToSwitchWindow(this.Parent.CurrentWindowHandle, 5);
        }
        /// <summary>
        /// get view status
        /// </summary>
        /// <returns></returns>
        public String GetViewStatus()
        {
            return ViewStatus_textLabel.Text;
        }

        /// <summary>
        /// expand test actions
        /// </summary>
        public void ExpandProperties()
        {
            PropertiesContainer.WaitUntilExists(5);
            PropertiesContainer.FakeAttributeStyle = "display: none;";
            if (PropertiesContainer.GetAttribute("style").Trim().ToLower().Contains("none"))
            {
                PropertiesLink.Click();
            }
        }
        /// <summary>
        /// collapse test actions
        /// </summary>
        public void CollapseProperties()
        {
            PropertiesContainer.WaitUntilExists(5);
            PropertiesContainer.FakeAttributeStyle = "display: block;";
            if (PropertiesContainer.GetAttribute("style").Trim().ToLower().Contains("block"))
            {
                PropertiesLink.Click();
            }
        }

        /// <summary>
        /// verify the item content
        /// </summary>
        /// <param name="contents">the content</param>
        public void VerifyItemContent(List<string> contents)
        {
            Report.Write("Verifying the expected content is within the actual content.");
            string actual = null;
            if (Driver.GetType() == typeof(DummyDriver))
            {
                actual = "<p>This morning, I went to the <u> 1 - (A) blue  (B) purple  (C) yellow  <b>(D) orange</b>  </u>and bought some milk and eggs. I knew it was going to rain, but I forgot my <u> 2 - (A) blue  <b>(C) purple</b>  </u>and ended up getting <u> 3 - (A) blue  (B) purple  <b>(C) yellow</b>  </u>on the way.</p>";
            }
            else
            {
                actual = GetItemContentText();
            }
            foreach (var content in contents)
            {
                Assert.IsTrue(actual.Contains(content), "The expected content: '" + content + "' was not found within the actual content: '" + actual + "'.");
                Report.Write("Verified the expected content: '" + content + "' was found within the actual content: '" + actual + "'.");
            }
        }

        /// <summary>
        /// verify the passage content in the results list by the index
        /// </summary>
        /// <param name="index">the passage index</param>
        /// <param name="contents">the content</param>
        public void VerifyPassageInResultsListByIndex(int index, List<string> contents)
        {
            Index = index;
            Report.Write("Verifying the expected content is within the actual content.");
            string actual = null;
            if (Driver.GetType() == typeof(DummyDriver))
            {
                actual = "The FIFA World Cup (also called the Football World Cup, the Soccer World Cup, or simply the World Cup)"
                    + " is an international association football competition contested by the senior men's national teams of the "
                    + "members of Federation International de Football Association (FIFA), the sport's global governing body. The"
                    + " championship has been awarded every four years since the inaugural tournament in 1930, except in 1942 and"
                    + " 1946 when it was not held because of the Second World War. The current champions are Spain, who won the 2010"
                    + " tournament. The current format of the tournament involves 32 teams competing for the title at venues within"
                    + " the host nation(s) over a period of about a month - this phase is often called the World Cup Finals. A quali"
                    + "fication phase, which currently takes place over the preceding three years, is used to determine which teams "
                    + "qualify for the tournament together with the host nation(s).The 19 World Cup tournaments have been won by eight"
                    + " different national teams. Brazil have won five times, and they are the only team to have played in every tour"
                    + "nament. The other World Cup winners are Italy, with four titles; Germany, with three titles; Argentina and ina"
                    + "ugural winners Uruguay, with two titles each; and England, France, and Spain, with one title each. The World Cup"
                    + " is the world's most widely viewed sporting event; an estimated 715.1 million people watched the final match of"
                    + " the 2006 FIFA World Cup held in Germany. The next three World Cups will be hosted by Brazil in 2014, Russia in"
                    + " 2018, and Qatar in 2022";
            }
            else
            {
                actual = GetPassageContentText();
            }
            foreach (var content in contents)
            {
                Assert.IsTrue(actual.Contains(content), "The expected content: '" + content + "' was not found within the actual content: '" + actual + "'.");
                Report.Write("Verified the expected content: '" + content + "' was found within the actual content: '" + actual + "'.");
            }
        }

        /// <summary>
        /// get the question language text
        /// </summary>
        /// <returns>question language text</returns>
        public string GetQuestionLanguage()
        {
            if (Driver.GetType() == typeof(DummyDriver))
            {
                QuestionLabel.Text = FakeText;
            }
            return QuestionLabel.Text;
        }

        /// <summary>
        /// find the row ty title
        /// </summary>
        /// <param name="title">the title</param>
        /// <returns>ViewItemStatisticsRow</returns>
        public ViewItemStatisticsRow FindRowByTitle(string title)
        {
            return this.Grid.GetsFirstRowContainingTextToFindFromList(ViewItemStatisticsColumnNames.Content, title);
        }
        /// <summary>
        /// select the row by title
        /// </summary>
        /// <param name="title">the title</param>
        public void SelectRowByTitle(string title)
        {
            ViewItemStatisticsRow row = FindRowByTitle(title);
            row.SelectTitle();
        }

        //implemented methods

        public override void VerifyFieldsExists()
        {
            throw new NotImplementedException();
        }

        public override void VerifyContentExists()
        {
            NameLabel.Wait(3);
            NameLabel.Text = Data.Name;
            Assert.AreEqual(Data.Name, NameLabel.Text.Trim(), "NameLabel does not match.");
            PublisherLabel.Text = Data.Publisher;
            Assert.AreEqual(Data.Publisher, PublisherLabel.Text.Trim(), "PublisherLabel does not match.");
            KeywordsLabel.Text = Data.Keyword;
            Assert.AreEqual(Data.Keyword, KeywordsLabel.Text.Trim(), "KeywordsLabel does not match.");
            AdditionalItemIdentifierLabel.Text = Data.AdditionalItemIdentifier;
            Assert.AreEqual(Data.AdditionalItemIdentifier, AdditionalItemIdentifierLabel.Text.Trim(), "AdditionalItemIdentifierLabel does not match.");
            BatchLabel.Text = Data.Batch;
            Assert.AreEqual(Data.Batch, BatchLabel.Text.Trim(), "BatchLabel does not match.");
            CourseIdLabel.Text = Data.CourseId;
            Assert.AreEqual(Data.CourseId, CourseIdLabel.Text.Trim(), "CourseIdLabel does not match.");
            ItemCategoryLabel.Text = Data.ItemCategory;
            Assert.AreEqual(Data.ItemCategory, ItemCategoryLabel.Text.Trim(), "ItemCategoryLabel does not match.");
            YearLabel.Text = Data.Year;
            Assert.AreEqual(Data.Year, YearLabel.Text.Trim(), "YearLabel does not match.");
        }
    }
}
