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
    /// the item type tab form
    /// </summary>
    public class ItemTypeTabForm : ItemTypeForm
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="itemType">the item type</param>
        /// <param name="tabName">the tab's name</param>
        /// <param name="tabId">the tab's ID</param>
        /// <param name="tabClass">the tab's class</param>
        /// <param name="index">the tab's index</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public ItemTypeTabForm(ItemType itemType, string tabName, string tabId, string tabClass, int index, string overrideControlPrefix = null)
            : base(itemType)
        {
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }
            TabName = tabName;
            TabId = tabId;
            TabClass = tabClass;
            Index = index;
            InitElements();
        }
        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            SetUniqueControlIdentifiers();
            Editor = new Editor(PageNames.EditorPopup, this.ControlPrefix);
            InteractionTab = new WebElementWrapper(ByInteractionTab());
            AddAnswerChoiceLink = new WebElementWrapper(ByAddAnswerChoiceLink);
            TargetContainerLabel = new WebElementWrapper(ByTargetContainerLabel);
            TargetContainerCapacityCheck = new WebElementWrapper(ByTargetContainerCapacityCheck);
            TargetContainerCapacitySelect = new SelectElementWrapper(new WebElementWrapper(ByTargetContainerCapacitySelect));
        }

        /// <summary>
        /// the tab's name
        /// </summary>
        public string TabName { get; private set; }
        /// <summary>
        /// the tab's ID
        /// </summary>
        public string TabId { get; private set; }
        /// <summary>
        /// the tab's class
        /// </summary>
        public string TabClass { get; private set; }
        /// <summary>
        /// is the tab active?
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// the tab's index
        /// </summary>
        public int Index { get; private set; }

        /// <summary>
        /// a list of answer choices
        /// </summary>
        public List<AnswerChoice> AnswerChoiceList { get; private set; }
        /// <summary>
        /// a list of unique control identifiers by letter
        /// </summary>
        private Dictionary<string, string> UniqueControlIdentifiers { get; set; }

        private WebElementWrapper InteractionTab { get; set; }

        private By ByAddAnswerChoiceLink { get { return By.CssSelector("a[id$='_btnAddAnswer']"); } }
        private WebElementWrapper AddAnswerChoiceLink { get; set; }

        //15.4
        //private By ByTargetContainerLabel { get { return By.CssSelector(".tab-pane.ng-scope.active > div[data-ng-bind-html-unsafe]"); } }
        //16.0
        private By ByTargetContainerLabel { get { return By.CssSelector(".tab-pane.ng-scope.active > div[data-ng-bind-html]"); } }
        private WebElementWrapper TargetContainerLabel { get; set; }

        private By ByTargetContainerCapacityCheck { get { return By.CssSelector(".tab-pane.ng-scope.active > div > .checkbox > input"); } }
        private WebElementWrapper TargetContainerCapacityCheck { get; set; }

        private By ByTargetContainerCapacitySelect { get { return By.CssSelector(".tab-pane.ng-scope.active select[data-ng-model='tab.MatchMax']"); } }
        private SelectElementWrapper TargetContainerCapacitySelect { get; set; }

        private Editor Editor { get; set; }

        private void SetUniqueControlIdentifiers()
        {
            AnswerChoiceList = new List<AnswerChoice>();
            int index;
            switch (this.ItemType)
            {
                case ItemType.InlineResponse:
                    //get a hash of the answer choice's: label and unique control identifier using WebDriver.FindElements(By.ClassName)
                    UniqueControlIdentifiers = GetUniqueControlIdentifiers(ByAnswerLabels());
                    //get the list of answer labels
                    var keyList = new List<string>();
                    foreach (var key in UniqueControlIdentifiers.Keys)
                    {
                        keyList.Add(key);
                    }

                    //for each element in the hash
                    foreach (var key in UniqueControlIdentifiers.Keys)
                    {
                        //is the key numeric?
                        bool isNumeric = int.TryParse(key, out index);
                        if (isNumeric == false)
                        {
                            //get a numeric zero based index based on the letter of the answer label
                            index = Index + this.GetIndexByAlphabet(key, keyList);
                            //get the unique control identifier
                            string uniqueId = UniqueControlIdentifiers[key];
                            Report.Write("Unique control identifier by key: " + key + "; index: " + index + "; ID: " + uniqueId);
                            //create an answer choice object
                            var answerChoice = new AnswerChoice(ItemType, key, index, uniqueId, ControlPrefix);
                            //add the answer choice object to the collection (A, B, C, D)
                            AnswerChoiceList.Add(answerChoice);
                        }
                    }
                    break;
                case ItemType.DragAndDrop:
                    ReadOnlyCollection<IWebElement> answerChoiceLabels = Driver.FindElements(ByAnswerLabels());
                    Report.Write("Found the elements by: '" + ByAnswerLabels().ToString() + "'.");
                    if (Driver.GetType() == typeof(DummyDriver))
                    {
                        DummyWebElement dummy1 = new DummyWebElement();
                        dummy1.FakeAttributeDataNgLabel = "A";
                        DummyWebElement dummy2 = new DummyWebElement();
                        dummy2.FakeAttributeDataNgLabel = "B";
                        DummyWebElement dummy3 = new DummyWebElement();
                        dummy3.FakeAttributeDataNgLabel = "C";
                        DummyWebElement dummy4 = new DummyWebElement();
                        dummy4.FakeAttributeDataNgLabel = "D";
                        List<IWebElement> list = new List<IWebElement> { dummy1, dummy2, dummy3, dummy4 };
                        answerChoiceLabels = new ReadOnlyCollection<IWebElement>(list);
                    }

                    index = 1;
                    foreach (var webElement in answerChoiceLabels)
                    {
                        string label = webElement.GetAttribute("data-ng-label");
                        //string label, string index
                        Report.Write("Answer choice unique control identifier by label: " + label + "; index: " + index);
                        //WebElementWrapper answerChoiceLabel = new WebElementWrapper(Driver, By.CssSelector(".tab-pane.ng-scope.active .listChoices li[data-ng-repeat='tabChoice in tab.AllChoices']:nth-of-type(" + index + ") .AnswerLabel"));
                        //create an answer choice object
                        var answerChoice = new AnswerChoice(ItemType, label, index, null, ControlPrefix);
                        //add the answer choice object to the collection (A, B, C, D)
                        AnswerChoiceList.Add(answerChoice);
                        index = index + 1;
                    }
                    break;
            }
        }

        private By ByInteractionTab()
        {
            By by = null;
            switch (this.ItemType)
            {
                case ItemType.InlineResponse:
                    //the style attribute is unreliable, so using the class is unreliable, instead we need to use the id attribute
                    //"div.INTERACTION_TAB_CONTENT:not([style='display:none']) .clozeStem-answerLabel"
                    by = By.CssSelector("#tab" + TabId + " > a");
                    break;
                case ItemType.DragAndDrop:
                    by = By.CssSelector(".nav-tabs li[data-ng-repeat='tab in TestItem.Containers']:nth-of-type(" + Index + ") > a");
                    break;
            }
            return by;
        }

        private By ByAnswerLabels()
        {
            By by = null;
            switch (this.ItemType)
            {
                case ItemType.InlineResponse:
                    by = By.CssSelector("#div" + TabId + " .clozeStem-answerLabel");
                    break;
                case ItemType.DragAndDrop:
                    by = By.CssSelector(".tab-pane.ng-scope.active .listChoices li[data-ng-repeat='tabChoice in tab.AllChoices'] .AnswerLabel");
                    break;
            }
            return by;
        }


        //specific methods
        /// <summary>
        /// add answer choice
        /// </summary>
        public void AddAnswerChoice()
        {
            AddAnswerChoiceLink.WaitUntilVisible().Click();
            AnswerChoiceList.Clear();
            //wait for post back to find the tab
            InteractionTab.WaitUntilVisible();
            SetUniqueControlIdentifiers();
        }
        /// <summary>
        /// select tab
        /// </summary>
        public void SelectTab()
        {
            InteractionTab.Wait(3).Click();
        }
        /// <summary>
        /// remove line
        /// </summary>
        /// <param name="label">the line item's letter</param>
        public void RemoveLine(string label)
        {
            foreach (var answerChoice in AnswerChoiceList)
            {
                if (answerChoice.Label.Equals(label))
                {
                    answerChoice.RemoveLine();
                }
            }
            AnswerChoiceList.Clear();
            //wait for post back to find the tab
            InteractionTab.WaitUntilVisible();
            SetUniqueControlIdentifiers();
        }

        /// <summary>
        /// Get the content from the target container label
        /// </summary>
        /// <param name="fakeData">fake data</param>
        /// <returns>the label's content</returns>
        public string GetTargetContainerContent(string fakeData = null)
        {
            TargetContainerLabel.Wait(3);
            TargetContainerLabel.Text = fakeData;
            return TargetContainerLabel.Text; ;
        }
        /// <summary>
        /// Get the content from the target container label
        /// </summary>
        /// <returns>the label's content</returns>
        public string GetTargetContainerContent()
        {
            return TargetContainerLabel.Wait(3).Text; ;
        }
        /// <summary>
        /// Check the content from the target container capacity check box
        /// </summary>
        public void CheckTargetContainerCapacity()
        {
            if (TargetContainerCapacityCheck.Selected == false)
            {
                TargetContainerCapacityCheck.Wait(3).Click();
            }
        }
        /// <summary>
        /// Uncheck the content from the target container capacity check box
        /// </summary>
        public void UnCheckTargetContainerCapacity()
        {
            if (TargetContainerCapacityCheck.Selected == true)
            {
                TargetContainerCapacityCheck.Wait(3).Click();
            }
        }
        /// <summary>
        /// Select the content from the target container capacity
        /// </summary>
        public void SelectTargetContainerCapacity(string capacity)
        {
            TargetContainerCapacitySelect.Wait(3).SelectByText(capacity);
        }

        //implemented methods
        public override void InputFormFields()
        {
            int index = 0;
            //QuestionAnswerData
            if (_questionAnswerDataObject != null)
            {
                foreach (var answerChoice in AnswerChoiceList)
                {
                    //get the question
                    string question = _questionAnswerDataObject.QuestionList[index];
                    //get the 1st answer
                    string answer = _questionAnswerDataObject.QuestionAnswerTree[question][0];
                    answerChoice.EditContent(answer);
                    index++;

                    answerChoice.SelectTeacherExplanation();
                    this.Utilities.DoFileUpload(Editor, _autoItDataObject, _questionAnswerDataObject.FileUploadTree, _questionAnswerDataObject.TeacherExplanationList[0]);
                    Editor.ContentData = _questionAnswerDataObject.TeacherExplanationList[0];
                    Editor.InputAndSubmitForm(answerChoice.TeacherExplanation.Add);

                    answerChoice.SelectEditStudentExplanation();
                    this.Utilities.DoFileUpload(Editor, _autoItDataObject, _questionAnswerDataObject.FileUploadTree, _questionAnswerDataObject.StudentExplanationList[0]);
                    Editor.ContentData = _questionAnswerDataObject.StudentExplanationList[0];
                    Editor.InputAndSubmitForm(answerChoice.StudentExplanation.Edit);

                    //get the 1st answer's points
                    Dictionary<string, string> dictionary = _questionAnswerDataObject.PointValueTree[question];
                    var enumerator = dictionary.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        var pair = enumerator.Current;
                        Report.Write("question: " + question + "; answer: " + answer + "; key: " + pair.Key + "; value: " + pair.Value);
                    }
                    try
                    {
                        string points = dictionary[answer];
                        Report.Write("answer: " + answer + "; points: " + points);
                        answerChoice.SelectIsCorrectResponse();
                        answerChoice.EditPointsPossible(points);
                    }
                    catch (Exception e)
                    {
                        //do nothing
                    }
                }
            }
            else //ItemTypeData
            {
                foreach (var answerChoice in AnswerChoiceList)
                {
                    answerChoice.EditContent(Data.AnswerChoiceList[index]);
                    index++;

                    answerChoice.SelectTeacherExplanation();
                    this.Utilities.DoFileUpload(Editor, _autoItDataObject, Data.FileUploadTree, Data.TeacherExplanation);
                    Editor.ContentData = Data.TeacherExplanation;
                    Editor.InputAndSubmitForm(answerChoice.TeacherExplanation.Add);

                    answerChoice.SelectEditStudentExplanation();
                    this.Utilities.DoFileUpload(Editor, _autoItDataObject, Data.FileUploadTree, Data.StudentExplanation);
                    Editor.ContentData = Data.StudentExplanation;
                    Editor.InputAndSubmitForm(answerChoice.StudentExplanation.Edit);
                }
                AnswerChoiceList.Last().SelectIsCorrectResponse();
                AnswerChoiceList.Last().EditPointsPossible("" + Data.PointsValue);
            }
        }

        public override void InputFormFields_AnswerKeyOnly()
        {
            throw new NotImplementedException();
        }
    }
}
