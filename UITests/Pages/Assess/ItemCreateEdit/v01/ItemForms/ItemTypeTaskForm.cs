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
using UITests.Pages.Components;
using UITests.Pages.Components.Editors;
using UITests.Pages.Assess.Components;
using UITests.Pages.Assess.ItemCreateEdit.v01.ItemParts;
using UITests.Pages.Assess.ItemCentral;

namespace UITests.Pages.Assess.ItemCreateEdit.v01.ItemForms
{
    /// <summary>
    /// the item type: task form
    /// </summary>
    public class ItemTypeTaskForm : ItemTypeForm
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="driver">IWebDriver</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public ItemTypeTaskForm(string overrideControlPrefix = null)
            : base(ItemType.Task)
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
            ItemList = new List<ItemTypeForm>();
            Editor = new Editor(PageNames.EditorPopup, this.ControlPrefix);
            QuestionContent = new WebElementWrapper(ByQuestionContent);
            QuestionContentReedit = new WebElementWrapper(ByQuestionContentReedit);
            AddActivity = new AddActivity(PageNames.CreateNewItem, this.ControlPrefix);
            ExpectedRequiredErrorsList = new List<string>()
            {
                "Add an activity",
                "Enter a name",
                "Enter content",
                "Not worth any points"
            };

            ItemContentGrid = new WebElementWrapper(ByItemContentGrid);
            ItemContentRows = new WebElementWrapper(ByItemContentRows);
            //generates a list on page load
            SetTestContentList();
        }

        private List<ItemTypeForm> _itemList;
        /// <summary>
        /// list of test form types
        /// </summary>
        public List<ItemTypeForm> ItemList
        {
            get
            {
                return _itemList;
            }
            set
            {
                _itemList = value;
            }
        }

        /// <summary>
        /// the html editor
        /// </summary>
        public Editor Editor { get; private set; }
        /// <summary>
        /// add activity
        /// </summary>
        private AddActivity AddActivity { get; set; }

        private By ByQuestionContent { get { return By.Id("divNoItemContent"); } }
        private WebElementWrapper QuestionContent { get; set; }
        private By ByQuestionContentReedit { get { return By.Id("divItemContent"); } }
        private WebElementWrapper QuestionContentReedit { get; set; }

        //TODO just plain awful, have Dev fix this crap
        private By ByItemContentGrid { get { return By.CssSelector(".DisabledForCMS > div"); } }
        //private By ByItemContentGrid { get { return By.CssSelector(".DisabledForCMS > div > table"); } }
        private WebElementWrapper ItemContentGrid { get; set; }
        private By ByItemContentRows { get { return By.CssSelector("tr.DataGridRow > td > a"); } }
        private WebElementWrapper ItemContentRows { get; set; }
        private WebElementWrapper QuestionLabel { get; set; }
        private ReadOnlyCollection<IWebElement> ItemContentWebElementList { get; set; }
        private List<ItemContentLineItem> ItemContentList { get; set; }

        /// <summary>
        /// gets the unique control ID
        /// </summary>
        /// <param name="webElement"></param>
        /// <param name="by"></param>
        /// <returns></returns>
        private string GetUniqueId(WebElementWrapper webElement, By by)
        {
            string id = webElement.GetAttribute("id");
            Report.Write("Got the attribute: 'id' = '" + id + "' of this element by: '" + by.ToString() + "'.");
            int from = id.IndexOf("_ctl") + "_ctl".Length;
            int to = id.IndexOf("_", from);
            //int to = id.LastIndexOf("_");
            string index = id.Substring(from, to - from);
            string uniqueId = "ctl" + index;
            return uniqueId;
        }
        /// <summary>
        /// gets the item ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private string GetItemId(string id)
        {
            return id.Substring("Anchor".Length);
        }
        /// <summary>
        /// gets the question label By object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private By ByQuestionLabelLocator(string id)
        {
            return By.CssSelector("a#" + id + " + strong > span");
        }

        /// <summary>
        /// gets the line item rows from the test content grid,
        /// creates test content line item components,
        /// assigns the primary identifiers to each line item component,
        /// and stores them in a collection
        /// </summary>
        private void SetTestContentList()
        {
            ItemContentList = new List<ItemContentLineItem>();
            ItemContentGrid.Wait(3);
            try
            {
                //get the list of items added to the task
                ItemContentWebElementList = ItemContentRows.WaitForElements(5);

                if (Driver.GetType() == typeof(DummyDriver))
                {
                    DummyWebElement dummy1 = new DummyWebElement();
                    dummy1.FakeAttributeId = "Anchor256324";
                    dummy1.FakeAttributeName = "Anchor256324";
                    DummyWebElement dummy2 = new DummyWebElement();
                    dummy2.FakeAttributeId = "Anchor256325";
                    dummy2.FakeAttributeName = "Anchor256325";
                    List<IWebElement> list = new List<IWebElement> { dummy1, dummy2 };
                    ItemContentWebElementList = new ReadOnlyCollection<IWebElement>(list);
                }

            }
            catch (Exception e)
            {
                //no items have been added to the task yet
                ItemContentWebElementList = null;
            }
            //if the task contains a list of items
            if (ItemContentWebElementList != null)
            {
                int index = 0;
                foreach (var webElement in ItemContentWebElementList)
                {
                    string id = webElement.GetAttribute("id");
                    int itemid = int.Parse(GetItemId(id));
                    QuestionLabel = new WebElementWrapper(ByQuestionLabelLocator(id));
                    QuestionLabel.FakeAttributeId = "ctl00_MainContent_EditTestItemControl_EditTaskItemControl1_ViewTaskItemControl_RepeaterTaskItems_ctl01_LabelQuestionLabel";
                    string uniqueId = GetUniqueId(QuestionLabel, ByQuestionLabelLocator(id));
                    QuestionLabel.Text = "A";
                    string label = QuestionLabel.Text;
                    Report.Write("ItemContentLineItem by itemid: '" + itemid + "'; index: '{" + index + "'; uniqueId: '" + uniqueId + "'; label: '" + label);
                    var lineItem = new ItemContentLineItem(webElement, itemid, index, uniqueId, label);
                    ItemContentList.Add(lineItem);
                    index++;
                }
            }
        }

        /// <summary>
        /// get the item central result list
        /// </summary>
        /// <returns>List of TestContentLineItem</returns>
        public List<ItemContentLineItem> GetResultsList()
        {
            return ItemContentList;
        }

        /// <summary>
        /// gets an item from the item central results list
        /// </summary>
        /// <param name="index">the index of the item</param>
        /// <returns>TestContentLineItem</returns>
        public ItemContentLineItem GetItemFromResultsList(int index)
        {
            return ItemContentList[index];
        }

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
        /// select add activity
        /// </summary>
        public void SelectAddActivity()
        {
            AddActivity.SelectAddActivity();
        }
        /// <summary>
        /// select add activity, then select multiple choice
        /// </summary>
        public EditTaskPage SelectAddActivityMultipleChoice()
        {
            EditTaskPage editTask = AddActivity.SelectAddActivityMultipleChoice();
            ItemList.Add(editTask.Form.ItemTypeForm);
            return editTask;
        }
        /// <summary>
        /// select add activity, then select true/false
        /// </summary>
        public EditTaskPage SelectAddActivityTrueFalse()
        {
            EditTaskPage editTask = AddActivity.SelectAddActivityTrueFalse();
            ItemList.Add(editTask.Form.ItemTypeForm);
            return editTask;
        }
        /// <summary>
        /// select add activity, then select gridded
        /// </summary>
        public EditTaskPage SelectAddActivityGridded()
        {
            EditTaskPage editTask = AddActivity.SelectAddActivityGridded();
            ItemList.Add(editTask.Form.ItemTypeForm);
            return editTask;
        }
        /// <summary>
        /// select add activity, then select open response
        /// </summary>
        public EditTaskPage SelectAddActivityOpenResponse()
        {
            EditTaskPage editTask = AddActivity.SelectAddActivityOpenResponse();
            ItemList.Add(editTask.Form.ItemTypeForm);
            return editTask;
        }
        /// <summary>
        /// select add activity, then select inline response
        /// </summary>
        public EditTaskPage SelectAddActivityInlineResponse()
        {
            EditTaskPage editTask = AddActivity.SelectAddActivityInlineResponse();
            ItemList.Add(editTask.Form.ItemTypeForm);
            return editTask;
        }
        /// <summary>
        /// select add activity, then select matching
        /// </summary>
        public EditTaskPage SelectAddActivityMatching()
        {
            EditTaskPage editTask = AddActivity.SelectAddActivityMatching();
            ItemList.Add(editTask.Form.ItemTypeForm);
            return editTask;
        }
        /// <summary>
        /// select add activity, then select hot spot multiple selection
        /// </summary>
        public EditTaskPage SelectAddActivityHotSpotMultipleSelection()
        {
            EditTaskPage editTask = AddActivity.SelectAddActivityHotSpotMultipleSelection();
            ItemList.Add(editTask.Form.ItemTypeForm);
            return editTask;
        }
        /// <summary>
        /// select add activity, then select hot spot single selection
        /// </summary>
        public EditTaskPage SelectAddActivityHotSpotSingleSelection()
        {
            EditTaskPage editTask = AddActivity.SelectAddActivityHotSpotSingleSelection();
            ItemList.Add(editTask.Form.ItemTypeForm);
            return editTask;
        }
        /// <summary>
        /// select add activity, then select drag and drop
        /// </summary>
        public EditTaskPage SelectAddActivityDragAndDrop()
        {
            EditTaskPage editTask = AddActivity.SelectAddActivityDragAndDrop();
            ItemList.Add(editTask.Form.ItemTypeForm);
            return editTask;
        }
        /// <summary>
        /// select add activity, then select click stick click drop
        /// </summary>
        public EditTaskPage SelectAddActivityClickStickClickDrop()
        {
            EditTaskPage editTask = AddActivity.SelectAddActivityClickStickClickDrop();
            ItemList.Add(editTask.Form.ItemTypeForm);
            return editTask;
        }
        /// <summary>
        /// select add activity, then select import from item central
        /// </summary>
        public ItemCentralHomePage SelectAddActivityImportFromItemCentral()
        {
            return AddActivity.SelectAddActivityImportFromItemCentral();
        }

        //implemented methods
        public override void InputFormFields()
        {
            WebElementWrapper questionContentElement = SelectQuestionContent();

            //QuestionAnswerData
            if (_questionAnswerDataObject != null)
            {
                Utilities.DoFileUpload(Editor, _autoItDataObject, _questionAnswerDataObject.FileUploadTree, _questionAnswerDataObject.QuestionContent);
                Editor.ContentData = _questionAnswerDataObject.QuestionContent;
            }
            else //ItemTypeData
            {
                Utilities.DoFileUpload(Editor, _autoItDataObject, Data.FileUploadTree, Data.QuestionContent);
                Editor.ContentData = Data.QuestionContent;
            }

            Editor.InputAndSubmitForm(questionContentElement);
        }

        public override void InputFormFields_AnswerKeyOnly()
        {
            throw new NotImplementedException();
        }
    }
}
