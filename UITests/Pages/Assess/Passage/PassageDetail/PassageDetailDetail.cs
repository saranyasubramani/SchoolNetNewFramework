using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages.Controls;
using UITests.Pages.Assess.ItemCreateEdit.v01;
using UITests.Pages.Assess.Passage.EditPassage;

namespace UITests.Pages.Assess.Passage.PassageDetail
{
    /// <summary>
    /// passage detail
    /// </summary>
    public class PassageDetailDetail : SNDetail
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public PassageDetailDetail(string overrideControlPrefix = null)
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
            Header_Lable = new WebElementWrapper(ByHeader_Lable);
            Title_label = new WebElementWrapper(ByTitle_label);
            Subject_Text = new WebElementWrapper(BySubject_Text);
            Grade_Text = new WebElementWrapper(ByGrade_Text);
            QuestionLanguage_Text = new WebElementWrapper(ByQuestionLanguage_Text);
            Type_Text = new WebElementWrapper(ByType_Text);
            Genre_Text = new WebElementWrapper(ByGenre_Text);
            Grade_Text = new WebElementWrapper(ByGrade_Text);
            Topic_Text = new WebElementWrapper(ByTopic_Text);
            Lexile_Text = new WebElementWrapper(ByLexile_Text);
            FleschKincaid_Text = new WebElementWrapper(ByFleschKincaid_Text);
            ReadingMaturityMetric_Text = new WebElementWrapper(ByReadingMaturityMetric_Text);
            QuestionLanguage_Text = new WebElementWrapper(ByQuestionLanguage_Text);
            Publisher_Text = new WebElementWrapper(ByPublisher_Text);
            AdditionalPassageID_Text = new WebElementWrapper(ByAdditionalPassageID_Text);
            AssetType_Text = new WebElementWrapper(ByAssetType_Text);
            Batch_Text = new WebElementWrapper(ByBatch_Text);
            CourseID_Text = new WebElementWrapper(ByCourseID_Text);
            Year_Text = new WebElementWrapper(ByYear_Text);
            NumberOfItemsLinked_Label = new WebElementWrapper(ByNumberOfItemsLinked_Label);
            ViewItem_Link = new WebElementWrapper(ByViewItem_Link);
            Copy_Link = new WebElementWrapper(ByCopy_Link);
            Edit_Link = new WebElementWrapper(ByEdit_Link);
            Delete_Link = new WebElementWrapper(ByDelete_Link);
            ChgStatus_Link = new WebElementWrapper(ByChgStatus_Link);
            PreviousPageBottomLink = new PreviousPageBottomLink(PageNames.PassageDetail, ControlPrefix);
            NumberOfItemsLinkedToPassageLabel = new WebElementWrapper(ByNumberOfItemsLinkedToPassageLabel);
            AddNewItemLink = new WebElementWrapper(ByAddNewItemLink);
            ItemsLinkedToPassageSelectAllCheck = new WebElementWrapper(ByItemsLinkedToPassageSelectAllCheck);
            ItemsLinkedToPassageExpandAllLink = new WebElementWrapper(ByItemsLinkedToPassageExpandAllLink);
            ItemsLinkedToPassageCollapseAllLink = new WebElementWrapper(ByItemsLinkedToPassageCollapseAllLink);
            AddPassageAndSelectedItemsToTestLink = new WebElementWrapper(ByAddPassageAndSelectedItemsToTestLink);
            ItemsLinkedToPassageRows = new WebElementWrapper(ByItemsLinkedToPassageRows);
            ItemsLinkedToPassageRows2 = new WebElementWrapper(ByItemsLinkedToPassageRows2);
            SetItemCentralResultList();
        }

        /// <summary>
        /// the data
        /// </summary>
        public EditPassageData Data
        {
            get
            {
                return (EditPassageData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        private string ControlMiddle = "";
        private By ByHeader_Lable { get { return By.CssSelector("p.text-info"); } }
        private WebElementWrapper Header_Lable { get; set; }
        private By ByNumberOfItemsLinkedToPassageLabel { get { return By.Id(ControlPrefix + "LabelNumberOfItemsLinked"); } }
        private WebElementWrapper NumberOfItemsLinkedToPassageLabel { get; set; }
        private By ByAddNewItemLink { get { return By.Id(ControlPrefix + "LinkButtonAddItem"); } }
        private WebElementWrapper AddNewItemLink { get; set; }
        private By ByItemsLinkedToPassageSelectAllCheck { get { return By.Id("cbSelectAll"); } }
        private WebElementWrapper ItemsLinkedToPassageSelectAllCheck { get; set; }
        private By ByItemsLinkedToPassageExpandAllLink { get { return By.Id("expandAllTestItems"); } }
        private WebElementWrapper ItemsLinkedToPassageExpandAllLink { get; set; }
        private By ByItemsLinkedToPassageCollapseAllLink { get { return By.Id("expandAllTestItems"); } }
        private WebElementWrapper ItemsLinkedToPassageCollapseAllLink { get; set; }
        private By ByAddPassageAndSelectedItemsToTestLink { get { return By.Id(ControlPrefix + "ButtonAddItemsToTest"); } }
        private WebElementWrapper AddPassageAndSelectedItemsToTestLink { get; set; }

        private By ByItemsLinkedToPassageRows { get { return By.CssSelector(".testItem"); } }
        private WebElementWrapper ItemsLinkedToPassageRows { get; set; }
        private ReadOnlyCollection<IWebElement> ItemsLinkedToPassageWebElementList { get; set; }
        private By ByItemsLinkedToPassageRows2 { get { return By.CssSelector(".checkbox.cbAddItemsToTest > input"); } }
        private WebElementWrapper ItemsLinkedToPassageRows2 { get; set; }
        private ReadOnlyCollection<IWebElement> ItemsLinkedToPassageWebElementList2 { get; set; }
        private List<ItemsLinkedToPassageLineItem> ItemsLinkedToPassageList { get; set; }

        // LOCATORS
        public By ByTitle_label { get { return By.Id(ControlPrefix + "LabelTitle"); } }
        public WebElementWrapper Title_label { get; private set; }

        public By BySubject_Text { get { return By.CssSelector("div.space6 > div:nth-of-type(5) > div:nth-of-type(2)"); } }
        public WebElementWrapper Subject_Text { get; private set; }

        public By ByGrade_Text { get { return By.CssSelector("div.space6 > div:nth-of-type(5) > div:nth-of-type(4)"); } }
        public WebElementWrapper Grade_Text { get; private set; }

        public By ByQuestionLanguage_Text { get { return By.CssSelector("div.space6 > div:nth-of-type(5) > div:nth-of-type(6)"); } }
        public WebElementWrapper QuestionLanguage_Text { get; private set; }

        public By ByType_Text { get { return By.CssSelector("div.space6 > div:nth-of-type(5) > div:nth-of-type(8)"); } }
        public WebElementWrapper Type_Text { get; private set; }

        public By ByGenre_Text { get { return By.CssSelector("div.space6 > div:nth-of-type(5) > div:nth-of-type(10)"); } }
        public WebElementWrapper Genre_Text { get; private set; }

        public By ByTopic_Text { get { return By.CssSelector("div.space6 > div:nth-of-type(5) > div:nth-of-type(12)"); } }
        public WebElementWrapper Topic_Text { get; private set; }

        public By ByLexile_Text { get { return By.CssSelector("div.space6 > div:nth-of-type(5) > div:nth-of-type(14)"); } }
        public WebElementWrapper Lexile_Text { get; private set; }

        public By ByFleschKincaid_Text { get { return By.CssSelector("div.space6 > div:nth-of-type(5) > div:nth-of-type(16)"); } }
        public WebElementWrapper FleschKincaid_Text { get; private set; }

        public By ByReadingMaturityMetric_Text { get { return By.CssSelector("div.space6 > div:nth-of-type(5) > div:nth-of-type(18)"); } }
        public WebElementWrapper ReadingMaturityMetric_Text { get; private set; }

        public By ByPublisher_Text { get { return By.CssSelector("div.space6 > div:nth-of-type(5) > div:nth-of-type(22)"); } }
        public WebElementWrapper Publisher_Text { get; private set; }

        public By ByAdditionalPassageID_Text { get { return By.CssSelector("div.space6 > div:nth-of-type(5) > div:nth-of-type(26)"); } }
        public WebElementWrapper AdditionalPassageID_Text { get; private set; }

        public By ByAssetType_Text { get { return By.CssSelector("div.space6 > div:nth-of-type(5) > div:nth-of-type(28)"); } }
        public WebElementWrapper AssetType_Text { get; private set; }

        public By ByBatch_Text { get { return By.CssSelector("div.space6 > div:nth-of-type(5) > div:nth-of-type(30)"); } }
        public WebElementWrapper Batch_Text { get; private set; }

        public By ByCourseID_Text { get { return By.CssSelector("div.space6 > div:nth-of-type(5) > div:nth-of-type(32)"); } }
        public WebElementWrapper CourseID_Text { get; private set; }

        public By ByYear_Text { get { return By.CssSelector("div.space6 > div:nth-of-type(5) > div:nth-of-type(34)"); } }
        public WebElementWrapper Year_Text { get; private set; }

        public By ByNumberOfItemsLinked_Label { get { return By.Id(ControlPrefix + "LabelNumberOfItemsLinked"); } }
        public WebElementWrapper NumberOfItemsLinked_Label { get; private set; }

        public By ByViewItem_Link { get { return By.Id(ControlPrefix + "RepeaterTestItemsLinkedToPassage_ctl00_LinkButtonTestItemDetails"); } }
        public WebElementWrapper ViewItem_Link { get; private set; }

        public By ByEdit_Link { get { return By.Id(ControlPrefix + "lnkEditButton"); } }
        public WebElementWrapper Edit_Link { get; private set; }

        public By ByCopy_Link { get { return By.Id(ControlPrefix + "lnkCopyButton"); } }
        public WebElementWrapper Copy_Link { get; private set; }

        public By ByChgStatus_Link { get { return By.Id(ControlPrefix + "lnkChangeStatus"); } }
        public WebElementWrapper ChgStatus_Link { get; private set; }

        //prior to 16.1
        //public By ByDelete_Link { get { return By.CssSelector("a.btn.btn-link[onclick^='javascript:return window.confirm']"); } }
        //16.1
        public By ByDelete_Link { get { return By.CssSelector("a.LnkBtnSpace[onclick^='javascript:return window.confirm']"); } }
        public WebElementWrapper Delete_Link { get; private set; }

        private PreviousPageBottomLink PreviousPageBottomLink { get; set; }

        private void SetItemCentralResultList()
        {
            var dictionary = new Dictionary<int, string>();
            ItemsLinkedToPassageList = new List<ItemsLinkedToPassageLineItem>();
            bool isFound = true;
            try
            {
                ItemsLinkedToPassageWebElementList = ItemsLinkedToPassageRows.WaitForElements(5);
                ItemsLinkedToPassageWebElementList2 = ItemsLinkedToPassageRows2.WaitForElements(5);
                if (Driver.GetType() == typeof(DummyDriver))
                {
                    DummyWebElement dummy1 = new DummyWebElement();
                    dummy1.FakeAttributeId = "ctl00_MainContent_RepeaterTestItemsLinkedToPassage_ctl00_CheckBoxAddToTest";
                    dummy1.FakeAttributeDetail = "testItemDetail339338";
                    DummyWebElement dummy2 = new DummyWebElement();
                    dummy2.FakeAttributeId = "ctl00_MainContent_RepeaterTestItemsLinkedToPassage_ctl01_CheckBoxAddToTest";
                    dummy2.FakeAttributeDetail = "testItemDetail339339";
                    List<IWebElement> list = new List<IWebElement> { dummy1, dummy2 };
                    ItemsLinkedToPassageWebElementList = new ReadOnlyCollection<IWebElement>(list);
                    ItemsLinkedToPassageWebElementList2 = new ReadOnlyCollection<IWebElement>(list);
                }
            }
            catch (Exception exception)
            {
                isFound = false;
            }

            if (isFound == true)
            {
                int index = 0;
                foreach (var webElement in ItemsLinkedToPassageWebElementList)
                {
                    string itemid = webElement.GetAttribute("_detail");
                    dictionary.Add(index, itemid);
                    index++;
                }

                index = 0;
                foreach (var webElement in ItemsLinkedToPassageWebElementList2)
                {
                    string idAttribute = webElement.GetAttribute("id");
                    Report.Write("Got the attribute: 'id' = '" + idAttribute + "' of this element by: '" + ByItemsLinkedToPassageRows2.ToString() + "'.");
                    int from = idAttribute.IndexOf("_ctl") + "_ctl".Length;
                    int to = idAttribute.LastIndexOf("_");
                    string ctl = idAttribute.Substring(from, to - from);
                    string uniqueId = "ctl" + ctl;
                    string itemid = dictionary[index];
                    Report.Write("ItemsLinkedToPassageLineItem by itemid: '" + itemid +"'; index: '" + index + "'; uniqueId: '" + uniqueId);
                    var lineItem = new ItemsLinkedToPassageLineItem(itemid, index, uniqueId);
                    ItemsLinkedToPassageList.Add(lineItem);
                    index++;
                }
            }
        }

        /// <summary>
        /// get the item central result list
        /// </summary>
        /// <returns>List of ItemCentralLineItem</returns>
        public List<ItemsLinkedToPassageLineItem> GetItemsLinkedToPassageList()
        {
            return ItemsLinkedToPassageList;
        }

        /// <summary>
        /// back to previous page
        /// </summary>
        public void BackToPreviousPage()
        {
            PreviousPageBottomLink.Control.Wait(3).Click();
        }

        /// <summary>
        /// verify passage title
        /// </summary>
        /// <param name="title">title</param>
        public void VerifyPassageTitle(string title)
        {
            Title_label.Wait(3);
            //Title_label.Text = Data.Title;
            //Assert.AreEqual(Data.Title, Title_label.Text.Trim(), "Title Label does not match.");
            Title_label.Text = title;
            Assert.AreEqual(title, Title_label.Text.Trim(), "Title Label does not match.");
        }

        /// <summary>
        /// verify passage header title
        /// </summary>
        /// <param name="title">title</param>
        public void VerifyPassageheaderTitle(string title)
        {
            Header_Lable.Wait(3);
            Assert.AreEqual(title, Header_Lable.Text.Trim(), "Title Label does not match.");
        }

        /// <summary>
        /// verify passage language
        /// </summary>
        /// <param name="language">language</param>
        public void VerifyPassageLanguage(string language)
        {
            QuestionLanguage_Text.Wait(3);
            Assert.AreEqual(language, QuestionLanguage_Text.Text.Trim(), "Title Label does not match.");
        }

        /// <summary>
        /// verify number of items linked to passage
        /// </summary>
        /// <param name="Number">number</param>
        public void VerifyNumberOfItemsLinkedToPassage(string Number)
        {
            Assert.AreEqual(Number, NumberOfItemsLinked_Label.Text.Trim(), "Numebr of items liked do not match.");
        }

        /// <summary>
        /// verify items are linked to passage by question content
        /// </summary>
        /// <param name="partialQuestionContent">partial question content</param>
        public void VerifyItemsIsLinkedToPassageByQuestionContent(string partialQuestionContent)
        {
            ItemsLinkedToPassageLineItem itemFound = GetItemsLinkedToPassageList().FirstOrDefault(p => p.GetItemDetail().Contains(partialQuestionContent));
            Assert.IsNotNull(itemFound, "Cannot find item linked to passage by searching for partial question content");
        }

        // <summary>
        /// View Link  Click
        /// </summary>
        public void ClickViewLink()
        {
            ViewItem_Link.Click();
        }

        // <summary>
        /// Copy Link Click
        /// </summary>
        public void ClickCopyLink()
        {
            Copy_Link.Click();
            this.DriverCommands.WaitAndMeasurePageLoadTime();
            InitElements();
        }

        // <summary>
        /// ChangeStatus Click
        /// </summary>
        public EditItemAvailabilityPage ClickChgStatusLink()
        {
            ChgStatus_Link.Click();
            return new EditItemAvailabilityPage();

        }

        /// <summary>
        /// edit the passage
        /// </summary>
        /// <returns>EditPassagePage</returns>
        public EditPassagePage ClickEditLink()
        {
            Edit_Link.Click();
            return new EditPassagePage();
        }

        //public void ClickDeleteLink()
        //{
        //    Delete_Link.Click();
        //}

        /// <summary>
        /// delete the Passage
        /// </summary>
        public void ClickDeleteLink(bool isItemLinked)
        {
            this.Parent.CurrentWindowHandle = Driver.CurrentWindowHandle;
            Report.Write("The current window is: '" + this.Parent.CurrentWindowHandle + "'.");

            Delete_Link.Wait(2).Click();
            IAlert alert = Driver.SwitchTo().Alert();
            string expected1 = "Are you sure you wish to delete this passage?";
            string expected2 = "Warning: All 1 Items linked to passage will be deleted.";

            string actual = alert.Text;
            Report.Write("The alert text: '" + actual + "'.");

            if (isItemLinked)
            {
                Assert.IsTrue(actual.Contains(expected2), "The delete confirmation pop-up does not contain the expected text: '" + expected1 + "'; actual text: '" + actual + "'.");
            }
            else
            {
                Assert.IsTrue(actual.Contains(expected1), "The delete confirmation pop-up does not contain the expected text: '" + expected1 + "'; actual text: '" + actual + "'.");
            }
            alert.Accept();
            //switch to window
            DriverCommands.WaitToSwitchWindow(this.Parent.CurrentWindowHandle, 5);
            //wait for page to load after delete
            DriverCommands.WaitAndMeasurePageLoadTime();
        }

        /// <summary>
        /// get the number of items linked to the passage
        /// </summary>
        /// <returns>number of items</returns>
        public string GetNumberOfItemsLinkedToPassage()
        {
            return NumberOfItemsLinkedToPassageLabel.Wait(3).Text;
        }
        /// <summary>
        /// verify the number of items linked to the passage
        /// </summary>
        /// <param name="expected">expected number of items</param>
        public void VerifyNumberOfItemsLinkedToPassage(int expected)
        {
            Report.Write("Verifying the expected content matches the actual content.");
            int actual;
            if (Driver.GetType() == typeof(DummyDriver))
            {
                actual = expected;
            }
            else
            {
                actual = int.Parse(NumberOfItemsLinkedToPassageLabel.Wait(3).Text);
            }
            Assert.AreEqual(expected, actual, "The expected content: '" + expected + "' does not match the actual content: '" + actual + "'.");
            Report.Write("Verified the expected content: '" + expected + "' does match the actual content: '" + actual + "'.");
        }
        /// <summary>
        /// add new item to link to a passage
        /// </summary>
        public void AddNewItemToPassage()
        {
            AddNewItemLink.Wait(3).Click();

        }
        /// <summary>
        /// check all items linked to a passage
        /// </summary>
        public void CheckAllItemsLinkedToPassage()
        {
            ItemsLinkedToPassageSelectAllCheck.Wait(3).Check();
        }

        /// <summary>
        /// uncheck all items linked to a passage
        /// </summary>
        public void UnCheckAllItemsLinkedToPassage()
        {
            ItemsLinkedToPassageSelectAllCheck.Wait(3).UnCheck();
        }

        /// <summary>
        /// Click on Item Remove link
        /// </summary>
        public void ClickRemove(int Itemno)
        {
            Itemno = Itemno - 1;
            string ItemId = "ctl0" + Itemno.ToString();
            By ByRemoveItem_Link = By.Id((ControlPrefix + "RepeaterTestItemsLinkedToPassage_" + ItemId + "_LinkButtonUnLink"));
            WebElementWrapper RemoveItem_Link = new WebElementWrapper(ByRemoveItem_Link);
            RemoveItem_Link.InitializeWebElement();
            RemoveItem_Link.Wait(3).Click();
        }

        /// <summary>
        /// expand all items linked to a passage
        /// </summary>
        public void ExpandAllItemsLinkedToPassage()
        {
            ItemsLinkedToPassageExpandAllLink.Wait(3).Click();
        }
        /// <summary>
        /// verify all the item details linked to a passage
        /// </summary>
        /// <param name="index">the item index</param>
        /// <param name="contents">the content</param>
        public void VerifyAllItemDetailsLinkedToPassage(int index, List<string> contents)
        {
            ExpandAllItemsLinkedToPassage();
            Report.Write("Verifying the expected content is within the actual content.");
            var itemsLinkedToPassageLineItem = ItemsLinkedToPassageList[index];
            string actual = null;
            if (Driver.GetType() == typeof(DummyDriver))
            {
                actual = "";
                foreach (var content in contents)
                {
                    actual = actual + " " + content;
                }
            }
            else
            {
                actual = itemsLinkedToPassageLineItem.GetItemDetail();
            }
            foreach (var content in contents)
            {
                Assert.IsTrue(actual.Contains(content), "The expected content: '" + content + "' was not found within the actual content: '" + actual + "'.");
                Report.Write("Verified the expected content: '" + content + "' was found within the actual content: '" + actual + "'.");
            }
        }
        /// <summary>
        /// collapse all items linked to a passage
        /// </summary>
        public void CollapseAllItemsLinkedToPassage()
        {
            ItemsLinkedToPassageCollapseAllLink.Wait(3).Click();
        }
        /// <summary>
        /// add passage and selected items to test
        /// </summary>
        public void AddPassageAndSelectedItemsToTest()
        {
            AddPassageAndSelectedItemsToTestLink.Wait(3).Click();
            //returns /Assess/Items/AddItemsToTest.aspx
        }

        public override void VerifyContentExists()
        {
            Subject_Text.Wait(3);
            //Subject_Text.Text = Data.Subject;
            Assert.AreEqual(Data.Subject, Subject_Text.Text.Trim(), "Subject text does not match.");

            //Grade_Text.Text = Data.GradeLow +"-" + Data.GradeHigh;
            Assert.AreEqual(Data.GradeLow + "-" + Data.GradeHigh, Grade_Text.Text.Trim(), "Grade text does not match.");

            //QuestionLanguage_Text.Text = Data.QuestionLanguage;
            Assert.AreEqual(Data.QuestionLanguage, QuestionLanguage_Text.Text.Trim(), "Question Language text does not match.");

            //Type_Text.Text = Data.Type;
            Assert.AreEqual(Data.Type, Type_Text.Text.Trim(), "Type text does not match.");

            //Genre_Text.Text = Data.Genre;
            Assert.AreEqual(Data.Genre, Genre_Text.Text.Trim(), "Genre text does not match.");

            //Topic_Text.Text = Data.Topic;
            Assert.AreEqual(Data.Topic, Topic_Text.Text.Trim(), "Topic text does not match.");

            //Lexile_Text.Text = Data.Lexile;
            if (Data.LexileCode.Equals("NP - Non Prose") || Data.LexileCode.Equals("BR - Beginning Reader"))
            {
                Data.Lexile = "0";
            }
            //if (Data.BeginningReader.Equals("1"))
            //{
            //    Data.Lexile = "0";
            //}
            StringAssert.Contains(Lexile_Text.Text.Trim(), Data.Lexile, "Lexile text does not match."); //implemented in 16.0
            //Assert.AreEqual(Data.Lexile, Lexile_Text.Text.Trim(), "Lexile text does not match.");

            //FleschKincaid_Text.Text = Data.FleschKincaid;
            Assert.AreEqual(Data.FleschKincaid, FleschKincaid_Text.Text.Trim(), "Flesh Kincaid text does not match.");

            //ReadingMaturityMetric_Text.Text = Data.ReadingMaturityMetric;
            Assert.AreEqual(Data.ReadingMaturityMetric, ReadingMaturityMetric_Text.Text.Trim(), "RMM text does not match.");

            //Publisher_Text.Text = Data.Publisher;
            Assert.AreEqual(Data.Publisher, Publisher_Text.Text.Trim(), "Publisher text does not match.");

            //AdditionalPassageID_Text.Text = Data.AdditionalPassageID;
            Assert.AreEqual(Data.AdditionalPassageID, AdditionalPassageID_Text.Text.Trim(), "Addtional Passage ID text does not match.");

            //AssetType_Text.Text = Data.AssetType;
            Assert.AreEqual(Data.AssetType, AssetType_Text.Text.Trim(), "Asset Type text does not match.");

            //CourseID_Text.Text = Data.CourseID;
            Assert.AreEqual(Data.CourseID, CourseID_Text.Text.Trim(), "Course ID text does not match.");

            //Year_Text.Text = Data.Year;
            Assert.AreEqual(Data.Year, Year_Text.Text.Trim(), "Year text does not match.");
        }
    }
}
