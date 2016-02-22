using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages.Components;
using UITests.Pages.Components.Editors;
using UITests.Pages.Assess.ItemCreateEdit.v01.ItemParts;

namespace UITests.Pages.Assess.ItemCreateEdit.v01.ItemForms
{
    /// <summary>
    /// the item type: inline response form
    /// </summary>
    public class ItemTypeInlineResponseForm : ItemTypeForm
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public ItemTypeInlineResponseForm(string overrideControlPrefix = null)
            : base(ItemType.InlineResponse)
        {
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }
            //Gaps = 0;
            InitElements();
        }
        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            Editor = new Editor(PageNames.EditorPopup, this.ControlPrefix);
            QuestionContent = new WebElementWrapper(ByQuestionContent);
            QuestionContentReedit = new WebElementWrapper(ByQuestionContentReedit);
            InteractionTabs = new WebElementWrapper(ByInteractionTabs);
            InteractionTabContents = new WebElementWrapper(ByInteractionTabContents);
            ExpectedRequiredErrorsList = new List<string>()
            {
                "Add at least one gap"
            };
        }

        /// <summary>
        /// the answer choice tabs by letter
        /// </summary>
        public Dictionary<string, ItemTypeTabForm> AnswerChoiceTabs { get; private set; }

        private By ByQuestionContent { get { return By.Id("divNoItemContent"); } }
        private WebElementWrapper QuestionContent { get; set; }
        private By ByQuestionContentReedit { get { return By.Id("divItemContent"); } }
        private WebElementWrapper QuestionContentReedit { get; set; }

        private By ByInteractionTabs { get { return By.CssSelector("ul.INTERACTION_TABS > li"); } }
        private WebElementWrapper InteractionTabs { get; set; }

        private WebElementWrapper InteractionTab { get; set; }

        private By ByInteractionTabContents { get { return By.CssSelector("div.INTERACTION_TAB_CONTENT"); } }
        private WebElementWrapper InteractionTabContents { get; set; }

        private By ByAnswerLabels { get { return By.ClassName("clozeStem-answerLabel"); } }

        private Editor Editor { get; set; }

        private void SetUniqueControlIdentifiers()
        {
            AnswerChoiceTabs = new Dictionary<string, ItemTypeTabForm>();
            InteractionTabs.WaitUntilVisible();
            //get the tabs
            ReadOnlyCollection<IWebElement> webElementTabs = Driver.FindElements(ByInteractionTabs);
            Report.Write("Found the elements by: '" + ByInteractionTabs.ToString() + "'.");
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                DummyWebElement dummy1 = new DummyWebElement();
                dummy1.FakeAttributeId = "tabfc5d6a01-9539-46d2-966a-15ab568698e8";
                dummy1.FakeAttributeClass = "active";
                DummyWebElement dummy2 = new DummyWebElement();
                dummy2.FakeAttributeId = "tabe2e3dda0-5708-40b5-8354-198a1232176a";
                dummy2.FakeAttributeClass = "";
                DummyWebElement dummy3 = new DummyWebElement();
                dummy3.FakeAttributeId = "tab76962807-988c-4d06-b977-9f9a4c35d87f";
                dummy3.FakeAttributeClass = "";
                List<IWebElement> list = new List<IWebElement> { dummy1, dummy2, dummy3 };
                webElementTabs = new ReadOnlyCollection<IWebElement>(list);
            }

            int dummyindex = 1;
            int index = 0;
            foreach (var webElement in webElementTabs)
            {
                string tempTabId = webElement.GetAttribute("id");
                Report.Write("Got the attribute: 'id' = '" + tempTabId + "' of this element by: '" + ByInteractionTabs.ToString() + "'.");

                //parse the tab ids to get the root id
                int from = tempTabId.IndexOf("tab") + "tab".Length;
                string tabId = tempTabId.Substring(from);

                string tabClass = webElement.GetAttribute("class");
                Report.Write("Got the attribute: 'class' = '" + tabClass + "' of this element by: '" + ByInteractionTabs.ToString() + "'.");
                InteractionTab = new WebElementWrapper(By.CssSelector("#tab" + tabId + " > a"));
                InteractionTab.Wait(3).Text = "" + dummyindex;
                dummyindex++;
                string tabName = InteractionTab.Text.Trim();
                //string tabName, string tabId, string tabClass
                Report.Write("Tab control identifier by tabName: " + tabName + "; tabId: " + tabId + "; tabClass: " + tabClass);
                //click the tab to make it visible, then create the item type tab object
                InteractionTab.Click();
                //create an item type tab object
                var itemTypeFormTab = new ItemTypeTabForm(ItemType.InlineResponse, tabName, tabId, tabClass,
                    index, ControlPrefix);
                //add the item type tab object to the collection (1, 2, 3)
                AnswerChoiceTabs.Add(tabName, itemTypeFormTab);
                index = index + 1000;
            }
        }

        //specific methods
        /// <summary>
        /// select question content, return the element clicked.
        /// When the question context had value entered, the question context element change. 
        /// Hence another element will be return.
        /// </summary>
        public WebElementWrapper SelectQuestionContent()
        {
            try
            {
                QuestionContent.Wait(5).Click();
            }
            catch (Exception e)
            {
                //The first click is not happening, assume user had already input a value. 
                //When question editor had inputed value, it will show up inside another div element with different id.
                //Click on this other element.
                Report.Write("Re-attempting to click this element by: '" + QuestionContentReedit.By.ToString() + "'.");
                QuestionContentReedit.Wait(5).Click();
                return QuestionContentReedit;
            }
            return QuestionContent;
        }
        /// <summary>
        /// input question content
        /// </summary>
        public void InputQuestionContent()
        {
            WebElementWrapper questionContentElement = SelectQuestionContent();
            Editor.ContentData = Data.EndOfQuestionGaps;
            Editor.GapContentData = Data.QuestionGapsList;
            Editor.InputAndSubmitForm(questionContentElement);
            //pause the script for a second to let the page settle down
            System.Threading.Thread.Sleep(1000);
            SetUniqueControlIdentifiers();
        }
        /// <summary>
        /// select tab
        /// </summary>
        /// <param name="tab">the tab's number</param>
        public void SelectTab(string tab)
        {
            /*
            foreach (var key in AnswerChoiceTabs.Keys)
            {
                Debug.WriteLine("tab: {0}; key: {1}.", tab, key);
                if (key.Equals(tab))
                {
                    Debug.WriteLine("found match - tab: {0}; key: {1}.", tab, key);
                }
            }
            */
            AnswerChoiceTabs[tab].SelectTab();
        }
        /// <summary>
        /// input tab content
        /// </summary>
        /// <param name="tab">the tab's number</param>
        public void InputTabContent(string tab)
        {
            AnswerChoiceTabs[tab].Data = Data;
            AnswerChoiceTabs[tab].SelectTab();
            AnswerChoiceTabs[tab].InputFormFields();
        }
        /// <summary>
        /// add answer choice
        /// </summary>
        /// <param name="tab">the tab's number</param>
        public void AddAnswerChoice(string tab)
        {
            AnswerChoiceTabs[tab].SelectTab();
            AnswerChoiceTabs[tab].AddAnswerChoice();
        }
        /// <summary>
        /// remove tab line item
        /// </summary>
        /// <param name="tab">the tab's number</param>
        /// <param name="label">the line item's letter</param>
        public void RemoveTabLine(string tab, string label)
        {
            AnswerChoiceTabs[tab].SelectTab();
            AnswerChoiceTabs[tab].RemoveLine(label);
        }
        /// <summary>
        /// get the answer choice list
        /// </summary>
        /// <param name="tab">the tab's number</param>
        /// <returns></returns>
        public List<AnswerChoice> GetAnswerChoiceList(string tab)
        {
            return AnswerChoiceTabs[tab].AnswerChoiceList;
        }

        //implemented methods
        public override void InputFormFields()
        {
            WebElementWrapper questionContentElement = SelectQuestionContent();
            //QuestionAnswerData
            if (_questionAnswerDataObject != null)
            {
                this.Utilities.DoFileUpload(Editor, _autoItDataObject, _questionAnswerDataObject.FileUploadTree, _questionAnswerDataObject.QuestionEndingAfterLastGap);
                Editor.ContentData = _questionAnswerDataObject.QuestionEndingAfterLastGap;
                Editor.GapContentData = _questionAnswerDataObject.QuestionList;
            }
            else //ItemTypeData
            {
                this.Utilities.DoFileUpload(Editor, _autoItDataObject, Data.FileUploadTree, Data.EndOfQuestionGaps);
                Editor.ContentData = Data.EndOfQuestionGaps;
                Editor.GapContentData = Data.QuestionGapsList;
            }

            Editor.InputAndSubmitForm(questionContentElement);

            SetUniqueControlIdentifiers();

            //for each element in the hash
            foreach (var tab in AnswerChoiceTabs.Keys)
            {
                //get the tab
                ItemTypeTabForm answerChoiceTab = AnswerChoiceTabs[tab];
                //QuestionAnswerData
                if (_questionAnswerDataObject != null)
                {
                    answerChoiceTab.QuestionAnswerDataObject = _questionAnswerDataObject;
                }
                else //ItemTypeData
                {
                    answerChoiceTab.Data = Data;
                }
                answerChoiceTab.SelectTab();
                answerChoiceTab.InputFormFields();
            }
            //this is only applicable on https://qa-153mt.sndev.net
            //SelectEnableManipulativesNo();
            //TODO: work on enable manipulatives for version 15.4
        }

        public override void InputFormFields_AnswerKeyOnly()
        {
            throw new NotImplementedException();
        }
    }
}
