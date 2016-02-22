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
using UITests.Pages.Assess.ItemCreateEdit.v01.ItemParts;

namespace UITests.Pages.Assess.ItemCreateEdit.v01.ItemForms
{
    /// <summary>
    /// the item type: drag and drop form
    /// </summary>
    public class ItemTypeDragDropForm : ItemTypeForm
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public ItemTypeDragDropForm(string overrideControlPrefix = null)
            : base(ItemType.DragAndDrop)
        {
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }
            InitElements();
        }
        /// <summary>
        /// intialize elements
        /// </summary>
        public override void InitElements()
        {
            Editor = new Editor(PageNames.EditorPopup, this.ControlPrefix);
            DragDropContainer = new WebElementWrapper(ByDragDropContainer);
            QuestionContent = new WebElementWrapper(ByQuestionContent);
            AddTargetContainerLink = new WebElementWrapper(ByAddTargetContainerLink);
            AddAnswerChoiceLink = new WebElementWrapper(ByAddAnswerChoiceLink);

            FieldNames = new List<ItemTypeDragDropFields>()
            {
                ItemTypeDragDropFields.QuestionContent, ItemTypeDragDropFields.QuestionStem1, ItemTypeDragDropFields.QuestionStem2, ItemTypeDragDropFields.QuestionStem3,
                ItemTypeDragDropFields.AnswerChoiceA, ItemTypeDragDropFields.AnswerChoiceB, ItemTypeDragDropFields.AnswerChoiceC, ItemTypeDragDropFields.AnswerChoiceD,
                ItemTypeDragDropFields.Tab1AnswerChoiceA, ItemTypeDragDropFields.Tab1AnswerChoiceB, ItemTypeDragDropFields.Tab1AnswerChoiceC, ItemTypeDragDropFields.Tab1AnswerChoiceD,
                ItemTypeDragDropFields.Tab2AnswerChoiceA, ItemTypeDragDropFields.Tab2AnswerChoiceB, ItemTypeDragDropFields.Tab2AnswerChoiceC, ItemTypeDragDropFields.Tab2AnswerChoiceD,
                ItemTypeDragDropFields.Tab3AnswerChoiceA, ItemTypeDragDropFields.Tab3AnswerChoiceB, ItemTypeDragDropFields.Tab3AnswerChoiceC, ItemTypeDragDropFields.Tab3AnswerChoiceD
            };

            ExpectedRequiredErrorsList = new List<string>()
            {
                //Bug #81626: EditTestItem.aspx Drag and Drop item: Steps to Complete missing Enter content
                //"Enter content",
                //TODO fix index in methods below
                "Add question content for question container 1,2,3",
                "Add content for answer choice A,B,C,D",
                "Select correct answer for question container 1,2,3",
                "Not worth any points"
            };
            SetUniqueControlIdentifiers();
        }

        /// <summary>
        /// the html editor
        /// </summary>
        public Editor Editor { get; private set; }

        /// <summary>
        /// the match tabs by number
        /// </summary>
        public Dictionary<string, ItemTypeTabForm> MatchTabs { get; private set; }

        /// <summary>
        /// a list of question stems
        /// </summary>
        public List<QuestionAnswerContent> QuestionStemList { get; private set; }
        /// <summary>
        /// a list of answer choices
        /// </summary>
        public List<QuestionAnswerContent> AnswerChoiceList { get; private set; }

        protected List<ItemTypeDragDropFields> FieldNames { get; set; }

        private By ByQuestionContent { get { return By.CssSelector("#data-ng-app .itemContent[data-content='QuestionContent']"); } }
        private WebElementWrapper QuestionContent { get; set; }

        private By ByDragDropContainer { get { return By.Id("data-ng-app"); } }
        private WebElementWrapper DragDropContainer { get; set; }
        private By ByTargetContainerLabels { get { return By.CssSelector(".listChoices li[data-ng-repeat='container in TestItem.Containers'] .AnswerLabel"); } }
        private By ByAnswerChoiceLabels { get { return By.CssSelector(".listChoices li[data-ng-repeat='choice in TestItem.Choices'] .AnswerLabel"); } }
        private By ByMatchTabLabels { get { return By.CssSelector(".nav-tabs li[data-ng-repeat='tab in TestItem.Containers'] > a"); } }
        private By ByMatchTabContentLabels { get { return By.CssSelector(".listChoices li[data-ng-repeat='tabChoice in tab.AllChoices']"); } }

        private By ByAddTargetContainerLink { get { return By.CssSelector("a[data-ng-click='AddContainer()']"); } }
        private WebElementWrapper AddTargetContainerLink { get; set; }

        private By ByAddAnswerChoiceLink { get { return By.CssSelector("a[data-ng-click='AddChoice()']"); } }
        private WebElementWrapper AddAnswerChoiceLink { get; set; }

        private void SetUniqueControlIdentifiers()
        {
            this.GetTargetContainers();
            this.GetAnswerChoices();
            this.GetMatchTabs();
        }

        private List<IWebElement> GetDummyElementsTargetContainers()
        {
            List<IWebElement> list = null;
            if (Driver.GetType() == typeof(DummyDriver))
            {
                DummyWebElement dummy1 = new DummyWebElement();
                dummy1.FakeAttributeDataNgLabel = "1";
                DummyWebElement dummy2 = new DummyWebElement();
                dummy2.FakeAttributeDataNgLabel = "2";
                DummyWebElement dummy3 = new DummyWebElement();
                dummy3.FakeAttributeDataNgLabel = "3";
                list = new List<IWebElement> { dummy1, dummy2, dummy3 };
            }
            return list;
        }
        private void GetTargetContainers()
        {
            DragDropContainer.WaitUntilVisible();
            ReadOnlyCollection<IWebElement> targetContainerLabels = Driver.FindElements(ByTargetContainerLabels);
            Report.Write("Found the elements by: '" + ByTargetContainerLabels.ToString() + "'.");
            if (Driver.GetType() == typeof(DummyDriver))
            {
                targetContainerLabels = new ReadOnlyCollection<IWebElement>(GetDummyElementsTargetContainers());
            }

            QuestionStemList = new List<QuestionAnswerContent>();
            int index = 1;
            foreach (var webElement in targetContainerLabels)
            {
                string label = webElement.GetAttribute("data-ng-label");
                //string label, string index
                Report.Write("Target container unique control identifier by label: "+ label + "; index: " + index);
                //WebElementWrapper targetContainerLabel = new WebElementWrapper(Driver, By.CssSelector(".listChoices li[data-ng-repeat='container in TestItem.Containers']:nth-of-type(" + index + ") .AnswerLabel"));
                //create a question stem object
                var questionStem = new QuestionAnswerContent(label, index, null, ContentType.TargetContainer, ItemType.DragAndDrop, ControlPrefix);
                //add the question stem object to the collection (1, 2, 3)
                QuestionStemList.Add(questionStem);
                index = index + 1;
            }
        }
        private List<IWebElement> GetDummyElementsAnswerChoices()
        {
            List<IWebElement> list2 = null;
            if (Driver.GetType() == typeof(DummyDriver))
            {
                DummyWebElement dummy4 = new DummyWebElement();
                dummy4.FakeAttributeDataNgLabel = "A";
                DummyWebElement dummy5 = new DummyWebElement();
                dummy5.FakeAttributeDataNgLabel = "B";
                DummyWebElement dummy6 = new DummyWebElement();
                dummy6.FakeAttributeDataNgLabel = "C";
                DummyWebElement dummy7 = new DummyWebElement();
                dummy7.FakeAttributeDataNgLabel = "D";
                list2 = new List<IWebElement> { dummy4, dummy5, dummy6, dummy7 };
            }
            return list2;
        }
        private void GetAnswerChoices()
        {
            DragDropContainer.WaitUntilVisible();
            ReadOnlyCollection<IWebElement> answerChoiceLabels = Driver.FindElements(ByAnswerChoiceLabels);
            Report.Write("Found the elements by: '" + ByAnswerChoiceLabels.ToString() + "'.");
            if (Driver.GetType() == typeof(DummyDriver))
            {
                answerChoiceLabels = new ReadOnlyCollection<IWebElement>(GetDummyElementsAnswerChoices());
            }

            AnswerChoiceList = new List<QuestionAnswerContent>();
            int index = 1;
            foreach (var webElement in answerChoiceLabels)
            {
                string label = webElement.GetAttribute("data-ng-label");
                //string label, string index
                Report.Write("Answer choice unique control identifier by label: " + label + "; index: " + index);
                //WebElementWrapper answerChoiceLabel = new WebElementWrapper(Driver, By.CssSelector(".listChoices li[data-ng-repeat='choice in TestItem.Choices']:nth-of-type(" + index + ") .AnswerLabel"));
                //create an answer choice object
                var answerChoice = new QuestionAnswerContent(label, index, null, ContentType.AvailableChoice, ItemType.DragAndDrop, ControlPrefix);
                //add the answer choice object to the collection (A, B, C, D)
                AnswerChoiceList.Add(answerChoice);
                index = index + 1;
            }
        }
        private List<IWebElement> GetDummyElementsMatchTabs()
        {
            List<IWebElement> list3 = null;
            if (Driver.GetType() == typeof(DummyDriver))
            {
                DummyWebElement dummy8 = new DummyWebElement();
                dummy8.Text = "1";
                dummy8.FakeAttributeClass = "ng-scope active";
                DummyWebElement dummy9 = new DummyWebElement();
                dummy9.Text = "2";
                dummy9.FakeAttributeClass = "ng-scope";
                DummyWebElement dummy10 = new DummyWebElement();
                dummy10.Text = "3";
                dummy10.FakeAttributeClass = "ng-scope";
                list3 = new List<IWebElement> { dummy8, dummy9, dummy10 };
            }
            return list3;
        }
        private void GetMatchTabs()
        {
            DragDropContainer.WaitUntilVisible();
            //get the tabs
            ReadOnlyCollection<IWebElement> matchTabLabels = Driver.FindElements(ByMatchTabLabels);
            Report.Write("Found the elements by: '" + ByMatchTabLabels.ToString() + "'.");
            if (Driver.GetType() == typeof(DummyDriver))
            {
                matchTabLabels = new ReadOnlyCollection<IWebElement>(GetDummyElementsMatchTabs());
            }

            MatchTabs = new Dictionary<string, ItemTypeTabForm>();
            int index = 1;
            foreach (var webElement in matchTabLabels)
            {
                string tabName = webElement.Text.Trim();
                string tabClass = webElement.GetAttribute("class");
                Report.Write("Got the attribute: 'class' = '" + tabClass + "' of this element by: '" + ByMatchTabLabels.ToString() + "'.");
                if (tabClass.ToLower().Contains("active"))
                {
                    tabClass = "active";
                }
                else
                {
                    tabClass = null;
                }
                //string tabName, string index
                Report.Write("Tab unique control identifier by tabName: " + tabName + "; tabClass: " + tabClass + "; index: " + index);
                WebElementWrapper matchTabLabel = new WebElementWrapper(By.CssSelector(".nav-tabs li[data-ng-repeat='tab in TestItem.Containers']:nth-of-type(" + index + ") > a"));
                //click the tab to make it visible, then create the item type tab object
                matchTabLabel.Click();

                //create an item type tab object
                var itemTypeFormTab = new ItemTypeTabForm(ItemType.DragAndDrop, tabName, null, tabClass, index, ControlPrefix);
                //add the item type tab object to the collection (1, 2, 3)
                MatchTabs.Add(tabName, itemTypeFormTab);
                index = index + 1;
            }
        }

        //specific methods

        /// <summary>
        /// select question content
        /// </summary>
        public void SelectQuestionContent()
        {
            QuestionContent.Wait(5).Click();
        }
        /// <summary>
        /// add target container
        /// </summary>
        public void AddTargetContainer()
        {
            AddTargetContainerLink.Click();
            QuestionStemList.Clear();
            //SetUniqueControlIdentifiers();
            this.GetTargetContainers();
            this.GetMatchTabs();
            if (Driver.GetType() == typeof(DummyDriver))
            {
                int index = QuestionStemList.Count() + 1;

                DummyWebElement webElement = new DummyWebElement();
                webElement.FakeAttributeDataNgLabel = "" + index;

                string label = webElement.GetAttribute("data-ng-label");
                //string label, string index
                Report.Write("Target container unique control identifier by label: " + label + "; index: " + index);
                //create a question stem object
                var questionStem = new QuestionAnswerContent(label, index, null, ContentType.TargetContainer, ItemType.DragAndDrop, ControlPrefix);
                //add the question stem object to the collection (1, 2, 3)
                QuestionStemList.Add(questionStem);

                DummyWebElement webElementTab = new DummyWebElement();
                webElementTab.Text = "" + index;
                webElementTab.FakeAttributeClass = "ng-scope";

                string tabName = webElementTab.Text.Trim();
                string tabClass = webElementTab.GetAttribute("class");
                Report.Write("Got the attribute: 'class' = '" + tabClass + "' of this element by: '" + ByMatchTabLabels.ToString() + "'.");
                tabClass = null;
                //string tabName, string index
                Report.Write("Tab unique control identifier by tabName: " + tabName + "; tabClass: " + tabClass + "; index: " + index);
                WebElementWrapper matchTabLabel = new WebElementWrapper(By.CssSelector(".nav-tabs li[data-ng-repeat='tab in TestItem.Containers']:nth-of-type(" + index + ") > a"));
                //click the tab to make it visible, then create the item type tab object
                matchTabLabel.Click();

                //create an item type tab object
                var itemTypeFormTab = new ItemTypeTabForm(ItemType.DragAndDrop, tabName, null, tabClass, index, ControlPrefix);
                //add the item type tab object to the collection (1, 2, 3)
                MatchTabs.Add(tabName, itemTypeFormTab);
            }
        }
        /// <summary>
        /// add draggable answer choice
        /// </summary>
        public void AddAnswerChoice()
        {
            AddAnswerChoiceLink.Click();
            AnswerChoiceList.Clear();
            //SetUniqueControlIdentifiers();
            this.GetAnswerChoices();
            this.GetMatchTabs();
            if (Driver.GetType() == typeof(DummyDriver))
            {
                int index = AnswerChoiceList.Count() + 1;
                DummyWebElement webElement = new DummyWebElement();
                webElement.FakeAttributeDataNgLabel = "E";

                string label = webElement.GetAttribute("data-ng-label");
                //string label, string index
                Report.Write("Answer choice unique control identifier by label: " + label + "; index: " + index);
                //create an answer choice object
                var questionAnswerChoice = new QuestionAnswerContent(label, index, null, ContentType.AvailableChoice, ItemType.DragAndDrop, ControlPrefix);
                //add the answer choice object to the collection (A, B, C, D)
                AnswerChoiceList.Add(questionAnswerChoice);

                //string label, string index
                Report.Write("Match tab answer choice unique control identifier by label: " + label + "; index: " + index);
                //WebElementWrapper answerChoiceLabel = new WebElementWrapper(Driver, By.CssSelector(".tab-pane.ng-scope.active .listChoices li[data-ng-repeat='tabChoice in tab.AllChoices']:nth-of-type(" + index + ") .AnswerLabel"));
                //create an answer choice object
                var answerChoice = new AnswerChoice(ItemType.DragAndDrop, label, index, null, ControlPrefix);
                foreach (var matchTab in MatchTabs.Values)
                {
                    //add the answer choice object to the collection (A, B, C, D)
                    matchTab.AnswerChoiceList.Add(answerChoice);
                }
            }
        }
        /// <summary>
        /// select tab
        /// </summary>
        /// <param name="tab">the tab's number</param>
        public void SelectTab(string tab)
        {
            /*
            foreach (var key in MatchTabs.Keys)
            {
                Report.Write("tab: {0}; key: {1}.", tab, key);
                if (key.Equals(tab))
                {
                    Report.Write("found match - tab: {0}; key: {1}.", tab, key);
                }
            }
            */
            MatchTabs[tab].SelectTab();
        }
        /// <summary>
        /// Get the content from the target container label
        /// </summary>
        /// <param name="tab">the tab's number</param>
        /// <param name="fakeData">fake data</param>
        /// <returns>the label's content</returns>
        public string GetTargetContainerContent(string tab, string fakeData = null)
        {
            return MatchTabs[tab].GetTargetContainerContent(fakeData);
        }
        /// <summary>
        /// Check the content from the target container capacity check box
        /// </summary>
        /// <param name="tab">the tab's number</param>
        public void CheckTargetContainerCapacity(string tab)
        {
            MatchTabs[tab].CheckTargetContainerCapacity();
        }
        /// <summary>
        /// Uncheck the content from the target container capacity check box
        /// </summary>
        /// <param name="tab">the tab's number</param>
        public void UnCheckTargetContainerCapacity(string tab)
        {
            MatchTabs[tab].UnCheckTargetContainerCapacity();
        }
        /// <summary>
        /// Select the content from the target container capacity
        /// </summary>
        /// <param name="tab">the tab's number</param>
        public void SelectTargetContainerCapacity(string tab, string capacity)
        {
            MatchTabs[tab].SelectTargetContainerCapacity(capacity);
        }


        //implemented methods
        public override void ClearForm()
        {
            SelectQuestionContent();
            Editor.ClearForm(QuestionContent);
            Editor.SubmitForm();

            foreach (var questionStem in QuestionStemList)
            {
                questionStem.ContentAdd.Click();
                Editor.ClearForm(questionStem.ContentAdd);
                Editor.SubmitForm();
            }

            foreach (var answerChoice in AnswerChoiceList)
            {
                answerChoice.ContentAdd.Click();
                Editor.ClearForm(answerChoice.ContentAdd);
                Editor.SubmitForm();
            }

            //for each element in the hash
            foreach (var tab in MatchTabs.Keys)
            {
                //get the tab
                ItemTypeTabForm matchTab = MatchTabs[tab];
                matchTab.Data = Data;
                matchTab.QuestionAnswerDataObject = _questionAnswerDataObject;

                //select the tab
                matchTab.SelectTab();

                //get the tab's answer choice list
                foreach (var answerChoice in matchTab.AnswerChoiceList)
                {
                    //assign the points possible
                    answerChoice.EditPointsPossible(0);
                }
            }
        }

        public override void InputFormFields()
        {
            SelectQuestionContent();
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
            Editor.InputAndSubmitForm(QuestionContent);

            int index = 0;
            foreach (var questionStem in QuestionStemList)
            {
                questionStem.ContentAdd.Click();
                //QuestionAnswerData
                if (_questionAnswerDataObject != null)
                {
                    Utilities.DoFileUpload(Editor, _autoItDataObject, _questionAnswerDataObject.FileUploadTree, _questionAnswerDataObject.QuestionList[index]);
                    Editor.ContentData = _questionAnswerDataObject.QuestionList[index];
                }
                else //ItemTypeData
                {
                    Utilities.DoFileUpload(Editor, _autoItDataObject, Data.FileUploadTree, Data.QuestionList[index]);
                    Editor.ContentData = Data.QuestionList[index];
                }
                index++;
                Editor.InputAndSubmitForm(questionStem.ContentAdd);
            }

            index = 0;
            foreach (var answerChoice in AnswerChoiceList)
            {
                answerChoice.ContentAdd.Click();
                //QuestionAnswerData
                if (_questionAnswerDataObject != null)
                {
                    Utilities.DoFileUpload(Editor, _autoItDataObject, _questionAnswerDataObject.FileUploadTree, _questionAnswerDataObject.AnswerList[index]);
                    Editor.ContentData = _questionAnswerDataObject.AnswerList[index];
                }
                else //ItemTypeData
                {
                    Utilities.DoFileUpload(Editor, _autoItDataObject, Data.FileUploadTree, Data.AnswerList[index]);
                    Editor.ContentData = Data.AnswerList[index];
                }
                index++;
                Editor.InputAndSubmitForm(answerChoice.ContentAdd);
            }

            index = 0;
            //for each element in the hash
            foreach (var tab in MatchTabs.Keys)
            {
                //get the tab
                ItemTypeTabForm matchTab = MatchTabs[tab];
                matchTab.Data = Data;
                matchTab.QuestionAnswerDataObject = _questionAnswerDataObject;

                //select the tab
                matchTab.SelectTab();

                //get the tab's target container content
                string targetcontent = null;
                //QuestionAnswerData
                if (_questionAnswerDataObject != null)
                {
                    targetcontent = matchTab.GetTargetContainerContent(_questionAnswerDataObject.QuestionList[index]).Trim();
                }
                else //ItemTypeData
                {
                    targetcontent = matchTab.GetTargetContainerContent(Data.QuestionList[index]).Trim();
                }
                index++;
                //if the target container content/draggable answer choice list contains the target container content
                List<string> answerList = null;
                //QuestionAnswerData
                if (_questionAnswerDataObject != null)
                {
                    if (_questionAnswerDataObject.QuestionAnswerTree.ContainsKey(targetcontent))
                    {
                        //get the list of draggable answers for the target container content
                        answerList = _questionAnswerDataObject.QuestionAnswerTree[targetcontent];
                        string fakeData = null;
                        if (answerList != null)
                        {
                            fakeData = answerList[0];
                        }
                        //get the tab's answer choice list
                        foreach (var answerChoice in matchTab.AnswerChoiceList)
                        {
                            //get the answer choice content
                            string answercontent = answerChoice.GetContent(fakeData).Trim();
                            if (answerList != null)
                            {
                                //if the draggable answer list contains the answer choice content
                                if (answerList.Contains(answercontent))
                                {
                                    //mark the is correct response check box
                                    answerChoice.CheckIsCorrectResponse();
                                    //assign the points possible
                                    Dictionary<string, string> dictionary = _questionAnswerDataObject.PointValueTree[targetcontent];
                                    var enumerator = dictionary.GetEnumerator();
                                    while (enumerator.MoveNext())
                                    {
                                        var pair = enumerator.Current;
                                        Report.Write("question: " + targetcontent + "; answer: " + answercontent + "; key: " + pair.Key + "; value: " + pair.Value);
                                    }
                                    try
                                    {
                                        string points = dictionary[answercontent];
                                        Report.Write("answer: " + answercontent + "; points: " + points);
                                        answerChoice.EditPointsPossible(points);
                                    }
                                    catch (Exception e)
                                    {
                                        //do nothing
                                    }
                                }
                            }

                            answerChoice.SelectTeacherExplanation();
                            Utilities.DoFileUpload(Editor, _autoItDataObject, _questionAnswerDataObject.FileUploadTree, _questionAnswerDataObject.TeacherExplanationList[0]);
                            Editor.ContentData = _questionAnswerDataObject.TeacherExplanationList[0];
                            Editor.InputAndSubmitForm(answerChoice.TeacherExplanation.Add);

                            answerChoice.SelectEditStudentExplanation();
                            Utilities.DoFileUpload(Editor, _autoItDataObject, _questionAnswerDataObject.FileUploadTree, _questionAnswerDataObject.StudentExplanationList[0]);
                            Editor.ContentData = _questionAnswerDataObject.StudentExplanationList[0];
                            Editor.InputAndSubmitForm(answerChoice.StudentExplanation.Edit);
                        }
                    }
                }
                else //ItemTypeData
                {
                    if (Data.QuestionAnswerList.ContainsKey(targetcontent))
                    {
                        //get the list of draggable answers for the target container content
                        answerList = Data.QuestionAnswerList[targetcontent];
                        string fakeData = null;
                        if (answerList != null)
                        {
                            fakeData = answerList[0];
                        }
                        //get the tab's answer choice list
                        foreach (var answerChoice in matchTab.AnswerChoiceList)
                        {
                            //get the answer choice content
                            string answercontent = answerChoice.GetContent(fakeData).Trim();
                            if (answerList != null)
                            {
                                //if the draggable answer list contains the answer choice content
                                if (answerList.Contains(answercontent))
                                {
                                    //mark the is correct response check box
                                    answerChoice.CheckIsCorrectResponse();
                                    //assign the points possible
                                    answerChoice.EditPointsPossible("" + Data.PointsValue);
                                }
                            }

                            answerChoice.SelectTeacherExplanation();
                            Utilities.DoFileUpload(Editor, _autoItDataObject, Data.FileUploadTree, Data.TeacherExplanation);
                            Editor.ContentData = Data.TeacherExplanation;
                            Editor.InputAndSubmitForm(answerChoice.TeacherExplanation.Add);

                            answerChoice.SelectEditStudentExplanation();
                            Utilities.DoFileUpload(Editor, _autoItDataObject, Data.FileUploadTree, Data.StudentExplanation);
                            Editor.ContentData = Data.StudentExplanation;
                            Editor.InputAndSubmitForm(answerChoice.StudentExplanation.Edit);
                        }
                    }
                }

            }
        }

        public override void InputFormFields_AnswerKeyOnly()
        {
            throw new NotImplementedException();
        }

        public void InputAllFieldsExcept(List<ItemTypeDragDropFields> excludeFields)
        {
            //remove the excluded fields
            foreach (var excludeField in excludeFields)
            {
                if (FieldNames.Contains(excludeField))
                {
                    Report.Write("Removing: " + excludeField);
                    FieldNames.Remove(excludeField);
                }
            }
            //do not input the excluded fields
            foreach (var excludeField in excludeFields)
            {
                //if the field does match, then make it blank
                if (excludeField.Equals(ItemTypeDragDropFields.QuestionContent))
                {
                    SelectQuestionContent();
                    Editor.ClearForm(QuestionContent);
                    Editor.SubmitForm();
                }
                if (excludeField.Equals(ItemTypeDragDropFields.QuestionStem1))
                {
                    QuestionStemList[0].ContentAdd.Wait(5).Click();
                    Editor.ClearForm(QuestionStemList[0].ContentAdd);
                    Editor.SubmitForm();
                }
                if (excludeField.Equals(ItemTypeDragDropFields.QuestionStem2))
                {
                    QuestionStemList[1].ContentAdd.Wait(5).Click();
                    Editor.ClearForm(QuestionStemList[1].ContentAdd);
                    Editor.SubmitForm();
                }
                if (excludeField.Equals(ItemTypeDragDropFields.QuestionStem3))
                {
                    QuestionStemList[2].ContentAdd.Wait(5).Click();
                    Editor.ClearForm(QuestionStemList[2].ContentAdd);
                    Editor.SubmitForm();
                }
                if (excludeField.Equals(ItemTypeDragDropFields.AnswerChoiceA))
                {
                    AnswerChoiceList[0].ContentAdd.Wait(5).Click();
                    Editor.ClearForm(AnswerChoiceList[0].ContentAdd);
                    Editor.SubmitForm();
                }
                if (excludeField.Equals(ItemTypeDragDropFields.AnswerChoiceB))
                {
                    AnswerChoiceList[1].ContentAdd.Wait(5).Click();
                    Editor.ClearForm(AnswerChoiceList[1].ContentAdd);
                    Editor.SubmitForm();
                }
                if (excludeField.Equals(ItemTypeDragDropFields.AnswerChoiceC))
                {
                    AnswerChoiceList[2].ContentAdd.Wait(5).Click();
                    Editor.ClearForm(AnswerChoiceList[2].ContentAdd);
                    Editor.SubmitForm();
                }
                if (excludeField.Equals(ItemTypeDragDropFields.AnswerChoiceD))
                {
                    AnswerChoiceList[3].ContentAdd.Wait(5).Click();
                    Editor.ClearForm(AnswerChoiceList[3].ContentAdd);
                    Editor.SubmitForm();
                }


                /*TODO: uncheck doesnt work cause Devs dont set the 'checked' attribute on check box.
                if (excludeField.Equals(ItemTypeDragDropFormFields.Tab1AnswerChoiceA))
                {
                    ItemTypeFormTab matchTab = MatchTabs["1"];
                    matchTab.SelectTab();
                    matchTab.AnswerChoiceList[0].UnCheckIsCorrectResponse();
                }
                if (excludeField.Equals(ItemTypeDragDropFormFields.Tab1AnswerChoiceB))
                {
                    ItemTypeFormTab matchTab = MatchTabs["1"];
                    matchTab.SelectTab();
                    matchTab.AnswerChoiceList[1].UnCheckIsCorrectResponse();
                }
                if (excludeField.Equals(ItemTypeDragDropFormFields.Tab1AnswerChoiceC))
                {
                    ItemTypeFormTab matchTab = MatchTabs["1"];
                    matchTab.SelectTab();
                    matchTab.AnswerChoiceList[2].UnCheckIsCorrectResponse();
                }
                if (excludeField.Equals(ItemTypeDragDropFormFields.Tab1AnswerChoiceD))
                {
                    ItemTypeFormTab matchTab = MatchTabs["1"];
                    matchTab.SelectTab();
                    matchTab.AnswerChoiceList[3].UnCheckIsCorrectResponse();
                }

                if (excludeField.Equals(ItemTypeDragDropFormFields.Tab2AnswerChoiceA))
                {
                    ItemTypeFormTab matchTab = MatchTabs["2"];
                    matchTab.SelectTab();
                    matchTab.AnswerChoiceList[0].UnCheckIsCorrectResponse();
                }
                if (excludeField.Equals(ItemTypeDragDropFormFields.Tab2AnswerChoiceB))
                {
                    ItemTypeFormTab matchTab = MatchTabs["2"];
                    matchTab.SelectTab();
                    matchTab.AnswerChoiceList[1].UnCheckIsCorrectResponse();
                }
                if (excludeField.Equals(ItemTypeDragDropFormFields.Tab2AnswerChoiceC))
                {
                    ItemTypeFormTab matchTab = MatchTabs["2"];
                    matchTab.SelectTab();
                    matchTab.AnswerChoiceList[2].UnCheckIsCorrectResponse();
                }
                if (excludeField.Equals(ItemTypeDragDropFormFields.Tab2AnswerChoiceD))
                {
                    ItemTypeFormTab matchTab = MatchTabs["2"];
                    matchTab.SelectTab();
                    matchTab.AnswerChoiceList[3].UnCheckIsCorrectResponse();
                }

                if (excludeField.Equals(ItemTypeDragDropFormFields.Tab3AnswerChoiceA))
                {
                    ItemTypeFormTab matchTab = MatchTabs["3"];
                    matchTab.SelectTab();
                    matchTab.AnswerChoiceList[0].UnCheckIsCorrectResponse();
                }
                if (excludeField.Equals(ItemTypeDragDropFormFields.Tab3AnswerChoiceB))
                {
                    ItemTypeFormTab matchTab = MatchTabs["3"];
                    matchTab.SelectTab();
                    matchTab.AnswerChoiceList[1].UnCheckIsCorrectResponse();
                }
                if (excludeField.Equals(ItemTypeDragDropFormFields.Tab3AnswerChoiceC))
                {
                    ItemTypeFormTab matchTab = MatchTabs["3"];
                    matchTab.SelectTab();
                    matchTab.AnswerChoiceList[2].UnCheckIsCorrectResponse();
                }
                if (excludeField.Equals(ItemTypeDragDropFormFields.Tab3AnswerChoiceD))
                {
                    ItemTypeFormTab matchTab = MatchTabs["3"];
                    matchTab.SelectTab();
                    matchTab.AnswerChoiceList[3].UnCheckIsCorrectResponse();
                }
                */
            }
            //input the included fields
            foreach (var includeField in FieldNames)
            {
                //if the field does match, then input it
                if (includeField.Equals(ItemTypeDragDropFields.QuestionContent))
                {
                    SelectQuestionContent();
                    Utilities.DoFileUpload(Editor, _autoItDataObject, Data.FileUploadTree, Data.QuestionContent);
                    Editor.ContentData = Data.QuestionContent;
                    Editor.InputAndSubmitForm(QuestionContent);
                }
                if (includeField.Equals(ItemTypeDragDropFields.QuestionStem1))
                {
                    QuestionStemList[0].ContentAdd.Wait(5).Click();
                    Utilities.DoFileUpload(Editor, _autoItDataObject, Data.FileUploadTree, Data.QuestionList[0]);
                    Editor.ContentData = Data.QuestionList[0];
                    Editor.InputAndSubmitForm(QuestionStemList[0].ContentAdd);
                }
                if (includeField.Equals(ItemTypeDragDropFields.QuestionStem2))
                {
                    QuestionStemList[1].ContentAdd.Wait(5).Click();
                    Utilities.DoFileUpload(Editor, _autoItDataObject, Data.FileUploadTree, Data.QuestionList[1]);
                    Editor.ContentData = Data.QuestionList[1];
                    Editor.InputAndSubmitForm(QuestionStemList[1].ContentAdd);
                }
                if (includeField.Equals(ItemTypeDragDropFields.QuestionStem3))
                {
                    QuestionStemList[2].ContentAdd.Wait(5).Click();
                    Utilities.DoFileUpload(Editor, _autoItDataObject, Data.FileUploadTree, Data.QuestionList[2]);
                    Editor.ContentData = Data.QuestionList[2];
                    Editor.InputAndSubmitForm(QuestionStemList[2].ContentAdd);
                }
                if (includeField.Equals(ItemTypeDragDropFields.AnswerChoiceA))
                {
                    AnswerChoiceList[0].ContentAdd.Wait(5).Click();
                    Utilities.DoFileUpload(Editor, _autoItDataObject, Data.FileUploadTree, Data.AnswerList[0]);
                    Editor.ContentData = Data.AnswerList[0];
                    Editor.InputAndSubmitForm(AnswerChoiceList[0].ContentAdd);
                }
                if (includeField.Equals(ItemTypeDragDropFields.AnswerChoiceB))
                {
                    AnswerChoiceList[1].ContentAdd.Wait(5).Click();
                    Utilities.DoFileUpload(Editor, _autoItDataObject, Data.FileUploadTree, Data.AnswerList[1]);
                    Editor.ContentData = Data.AnswerList[1];
                    Editor.InputAndSubmitForm(AnswerChoiceList[1].ContentAdd);
                }
                if (includeField.Equals(ItemTypeDragDropFields.AnswerChoiceC))
                {
                    AnswerChoiceList[2].ContentAdd.Wait(5).Click();
                    Utilities.DoFileUpload(Editor, _autoItDataObject, Data.FileUploadTree, Data.AnswerList[2]);
                    Editor.ContentData = Data.AnswerList[2];
                    Editor.InputAndSubmitForm(AnswerChoiceList[2].ContentAdd);
                }
                if (includeField.Equals(ItemTypeDragDropFields.AnswerChoiceD))
                {
                    AnswerChoiceList[3].ContentAdd.Wait(5).Click();
                    Utilities.DoFileUpload(Editor, _autoItDataObject, Data.FileUploadTree, Data.AnswerList[3]);
                    Editor.ContentData = Data.AnswerList[3];
                    Editor.InputAndSubmitForm(AnswerChoiceList[3].ContentAdd);
                }

                if (includeField.Equals(ItemTypeDragDropFields.Tab1AnswerChoiceA))
                {
                    ItemTypeTabForm matchTab = MatchTabs["1"];
                    matchTab.SelectTab();
                    matchTab.AnswerChoiceList[0].CheckIsCorrectResponse();
                }
                if (includeField.Equals(ItemTypeDragDropFields.Tab1AnswerChoiceB))
                {
                    ItemTypeTabForm matchTab = MatchTabs["1"];
                    matchTab.SelectTab();
                    matchTab.AnswerChoiceList[1].CheckIsCorrectResponse();
                }
                if (includeField.Equals(ItemTypeDragDropFields.Tab1AnswerChoiceC))
                {
                    ItemTypeTabForm matchTab = MatchTabs["1"];
                    matchTab.SelectTab();
                    matchTab.AnswerChoiceList[2].CheckIsCorrectResponse();
                }
                if (includeField.Equals(ItemTypeDragDropFields.Tab1AnswerChoiceD))
                {
                    ItemTypeTabForm matchTab = MatchTabs["1"];
                    matchTab.SelectTab();
                    matchTab.AnswerChoiceList[3].CheckIsCorrectResponse();
                }

                if (includeField.Equals(ItemTypeDragDropFields.Tab2AnswerChoiceA))
                {
                    ItemTypeTabForm matchTab = MatchTabs["2"];
                    matchTab.SelectTab();
                    matchTab.AnswerChoiceList[0].CheckIsCorrectResponse();
                }
                if (includeField.Equals(ItemTypeDragDropFields.Tab2AnswerChoiceB))
                {
                    ItemTypeTabForm matchTab = MatchTabs["2"];
                    matchTab.SelectTab();
                    matchTab.AnswerChoiceList[1].CheckIsCorrectResponse();
                }
                if (includeField.Equals(ItemTypeDragDropFields.Tab2AnswerChoiceC))
                {
                    ItemTypeTabForm matchTab = MatchTabs["2"];
                    matchTab.SelectTab();
                    matchTab.AnswerChoiceList[2].CheckIsCorrectResponse();
                }
                if (includeField.Equals(ItemTypeDragDropFields.Tab2AnswerChoiceD))
                {
                    ItemTypeTabForm matchTab = MatchTabs["2"];
                    matchTab.SelectTab();
                    matchTab.AnswerChoiceList[3].CheckIsCorrectResponse();
                }

                if (includeField.Equals(ItemTypeDragDropFields.Tab3AnswerChoiceA))
                {
                    ItemTypeTabForm matchTab = MatchTabs["3"];
                    matchTab.SelectTab();
                    matchTab.AnswerChoiceList[0].CheckIsCorrectResponse();
                }
                if (includeField.Equals(ItemTypeDragDropFields.Tab3AnswerChoiceB))
                {
                    ItemTypeTabForm matchTab = MatchTabs["3"];
                    matchTab.SelectTab();
                    matchTab.AnswerChoiceList[1].CheckIsCorrectResponse();
                }
                if (includeField.Equals(ItemTypeDragDropFields.Tab3AnswerChoiceC))
                {
                    ItemTypeTabForm matchTab = MatchTabs["3"];
                    matchTab.SelectTab();
                    matchTab.AnswerChoiceList[2].CheckIsCorrectResponse();
                }
                if (includeField.Equals(ItemTypeDragDropFields.Tab3AnswerChoiceD))
                {
                    ItemTypeTabForm matchTab = MatchTabs["3"];
                    matchTab.SelectTab();
                    matchTab.AnswerChoiceList[3].CheckIsCorrectResponse();
                }
            }
        }

        /// <summary>
        /// input the Match Target Containers with Answer Choices fields to trigger the Not worth any points message
        /// </summary>
        /// <param name="requiredFields">required field list</param>
        public void InputNotWorthAnyPoints(List<ItemTypeDragDropFields> requiredFields)
        {
            foreach (var requiredField in requiredFields)
            {
                if (requiredField.Equals(ItemTypeDragDropFields.Tab1AnswerChoiceA))
                {
                    ItemTypeTabForm matchTab = MatchTabs["1"];
                    matchTab.SelectTab();
                    matchTab.AnswerChoiceList[0].CheckIsCorrectResponse();
                    matchTab.AnswerChoiceList[0].EditPointsPossible(0);
                }
                if (requiredField.Equals(ItemTypeDragDropFields.Tab1AnswerChoiceB))
                {
                    ItemTypeTabForm matchTab = MatchTabs["1"];
                    matchTab.SelectTab();
                    matchTab.AnswerChoiceList[1].CheckIsCorrectResponse();
                    matchTab.AnswerChoiceList[1].EditPointsPossible(0);
                }
                if (requiredField.Equals(ItemTypeDragDropFields.Tab1AnswerChoiceC))
                {
                    ItemTypeTabForm matchTab = MatchTabs["1"];
                    matchTab.SelectTab();
                    matchTab.AnswerChoiceList[2].CheckIsCorrectResponse();
                    matchTab.AnswerChoiceList[2].EditPointsPossible(0);
                }
                if (requiredField.Equals(ItemTypeDragDropFields.Tab1AnswerChoiceD))
                {
                    ItemTypeTabForm matchTab = MatchTabs["1"];
                    matchTab.SelectTab();
                    matchTab.AnswerChoiceList[3].CheckIsCorrectResponse();
                    matchTab.AnswerChoiceList[3].EditPointsPossible(0);
                }

                if (requiredField.Equals(ItemTypeDragDropFields.Tab2AnswerChoiceA))
                {
                    ItemTypeTabForm matchTab = MatchTabs["2"];
                    matchTab.SelectTab();
                    matchTab.AnswerChoiceList[0].CheckIsCorrectResponse();
                    matchTab.AnswerChoiceList[0].EditPointsPossible(0);
                }
                if (requiredField.Equals(ItemTypeDragDropFields.Tab2AnswerChoiceB))
                {
                    ItemTypeTabForm matchTab = MatchTabs["2"];
                    matchTab.SelectTab();
                    matchTab.AnswerChoiceList[1].CheckIsCorrectResponse();
                    matchTab.AnswerChoiceList[1].EditPointsPossible(0);
                }
                if (requiredField.Equals(ItemTypeDragDropFields.Tab2AnswerChoiceC))
                {
                    ItemTypeTabForm matchTab = MatchTabs["2"];
                    matchTab.SelectTab();
                    matchTab.AnswerChoiceList[2].CheckIsCorrectResponse();
                    matchTab.AnswerChoiceList[2].EditPointsPossible(0);
                }
                if (requiredField.Equals(ItemTypeDragDropFields.Tab2AnswerChoiceD))
                {
                    ItemTypeTabForm matchTab = MatchTabs["2"];
                    matchTab.SelectTab();
                    matchTab.AnswerChoiceList[3].CheckIsCorrectResponse();
                    matchTab.AnswerChoiceList[3].EditPointsPossible(0);
                }

                if (requiredField.Equals(ItemTypeDragDropFields.Tab3AnswerChoiceA))
                {
                    ItemTypeTabForm matchTab = MatchTabs["3"];
                    matchTab.SelectTab();
                    matchTab.AnswerChoiceList[0].CheckIsCorrectResponse();
                    matchTab.AnswerChoiceList[0].EditPointsPossible(0);
                }
                if (requiredField.Equals(ItemTypeDragDropFields.Tab3AnswerChoiceB))
                {
                    ItemTypeTabForm matchTab = MatchTabs["3"];
                    matchTab.SelectTab();
                    matchTab.AnswerChoiceList[1].CheckIsCorrectResponse();
                    matchTab.AnswerChoiceList[1].EditPointsPossible(0);
                }
                if (requiredField.Equals(ItemTypeDragDropFields.Tab3AnswerChoiceC))
                {
                    ItemTypeTabForm matchTab = MatchTabs["3"];
                    matchTab.SelectTab();
                    matchTab.AnswerChoiceList[2].CheckIsCorrectResponse();
                    matchTab.AnswerChoiceList[2].EditPointsPossible(0);
                }
                if (requiredField.Equals(ItemTypeDragDropFields.Tab3AnswerChoiceD))
                {
                    ItemTypeTabForm matchTab = MatchTabs["3"];
                    matchTab.SelectTab();
                    matchTab.AnswerChoiceList[3].CheckIsCorrectResponse();
                    matchTab.AnswerChoiceList[3].EditPointsPossible(0);
                }
            }
        }

        /// <summary>
        /// verify the not worth any points messages
        /// </summary>
        /// <param name="requiredFields">required fields list</param>
        public void VerifyNotWorthAnyPoints(List<ItemTypeDragDropFields> requiredFields)
        {
            List<string> actualRequiredErrorsList = new List<string>();
            //get the error message element list
            ReadOnlyCollection<IWebElement> messageElements = StepsToCompleteLabels.WaitForElements(5);

            if (Driver.GetType() == typeof(DummyDriver))
            {
                messageElements = GetDummyStepsToCompleteLabels();
            }

            //for each element in the list
            foreach (var messageElement in messageElements)
            {
                //if the error message element is displayed
                if (messageElement.Displayed)
                {
                    string actualMessage = messageElement.Text;
                    //get the error message text and add it to the actual error message list
                    actualRequiredErrorsList.Add(actualMessage);
                    Report.Write("Actual required message: " + actualMessage);
                }
            }

            string tabAnswerChoice = "Not worth any points";

            foreach (var requiredField in requiredFields)
            {
                if (requiredField.Equals(ItemTypeDragDropFields.Tab1AnswerChoiceA))
                {
                    //assert that the expected error message is found in the actual error message list
                    Assert.IsTrue(actualRequiredErrorsList.Contains(tabAnswerChoice),
                        "The expected required message '" + tabAnswerChoice + "' was not found in the actual required message list.");
                }
                if (requiredField.Equals(ItemTypeDragDropFields.Tab1AnswerChoiceB))
                {
                    //assert that the expected error message is found in the actual error message list
                    Assert.IsTrue(actualRequiredErrorsList.Contains(tabAnswerChoice),
                        "The expected required message '" + tabAnswerChoice + "' was not found in the actual required message list.");
                }
                if (requiredField.Equals(ItemTypeDragDropFields.Tab1AnswerChoiceC))
                {
                    //assert that the expected error message is found in the actual error message list
                    Assert.IsTrue(actualRequiredErrorsList.Contains(tabAnswerChoice),
                        "The expected required message '" + tabAnswerChoice + "' was not found in the actual required message list.");
                }
                if (requiredField.Equals(ItemTypeDragDropFields.Tab1AnswerChoiceD))
                {
                    //assert that the expected error message is found in the actual error message list
                    Assert.IsTrue(actualRequiredErrorsList.Contains(tabAnswerChoice),
                        "The expected required message '" + tabAnswerChoice + "' was not found in the actual required message list.");
                }

                if (requiredField.Equals(ItemTypeDragDropFields.Tab2AnswerChoiceA))
                {
                    //assert that the expected error message is found in the actual error message list
                    Assert.IsTrue(actualRequiredErrorsList.Contains(tabAnswerChoice),
                        "The expected required message '" + tabAnswerChoice + "' was not found in the actual required message list.");
                }
                if (requiredField.Equals(ItemTypeDragDropFields.Tab2AnswerChoiceB))
                {
                    //assert that the expected error message is found in the actual error message list
                    Assert.IsTrue(actualRequiredErrorsList.Contains(tabAnswerChoice),
                        "The expected required message '" + tabAnswerChoice + "' was not found in the actual required message list.");
                }
                if (requiredField.Equals(ItemTypeDragDropFields.Tab2AnswerChoiceC))
                {
                    //assert that the expected error message is found in the actual error message list
                    Assert.IsTrue(actualRequiredErrorsList.Contains(tabAnswerChoice),
                        "The expected required message '" + tabAnswerChoice + "' was not found in the actual required message list.");
                }
                if (requiredField.Equals(ItemTypeDragDropFields.Tab2AnswerChoiceD))
                {
                    //assert that the expected error message is found in the actual error message list
                    Assert.IsTrue(actualRequiredErrorsList.Contains(tabAnswerChoice),
                        "The expected required message '" + tabAnswerChoice + "' was not found in the actual required message list.");
                }

                if (requiredField.Equals(ItemTypeDragDropFields.Tab3AnswerChoiceA))
                {
                    //assert that the expected error message is found in the actual error message list
                    Assert.IsTrue(actualRequiredErrorsList.Contains(tabAnswerChoice),
                        "The expected required message '" + tabAnswerChoice + "' was not found in the actual required message list.");
                }
                if (requiredField.Equals(ItemTypeDragDropFields.Tab3AnswerChoiceB))
                {
                    //assert that the expected error message is found in the actual error message list
                    Assert.IsTrue(actualRequiredErrorsList.Contains(tabAnswerChoice),
                        "The expected required message '" + tabAnswerChoice + "' was not found in the actual required message list.");
                }
                if (requiredField.Equals(ItemTypeDragDropFields.Tab3AnswerChoiceC))
                {
                    //assert that the expected error message is found in the actual error message list
                    Assert.IsTrue(actualRequiredErrorsList.Contains(tabAnswerChoice),
                        "The expected required message '" + tabAnswerChoice + "' was not found in the actual required message list.");
                }
                if (requiredField.Equals(ItemTypeDragDropFields.Tab3AnswerChoiceD))
                {
                    //assert that the expected error message is found in the actual error message list
                    Assert.IsTrue(actualRequiredErrorsList.Contains(tabAnswerChoice),
                        "The expected required message '" + tabAnswerChoice + "' was not found in the actual required message list.");
                }
            }
        }

        public void VerifyErrorForRequiredField(List<ItemTypeDragDropFields> requiredFields)
        {
            List<string> actualRequiredErrorsList = new List<string>();
            //get the error message element list
            ReadOnlyCollection<IWebElement> messageElements = StepsToCompleteLabels.WaitForElements(5);

            if (Driver.GetType() == typeof(DummyDriver))
            {
                messageElements = GetDummyStepsToCompleteLabels();
            }

            //for each element in the list
            foreach (var messageElement in messageElements)
            {
                //if the error message element is displayed
                if (messageElement.Displayed)
                {
                    string actualMessage = messageElement.Text;
                    //get the error message text and add it to the actual error message list
                    actualRequiredErrorsList.Add(actualMessage);
                    Report.Write("Actual required message: " + actualMessage);
                }
            }

            string stemCount = "";
            bool stemAddComma = false;
            string choiceCount = "";
            bool choiceAddComma = false;
            string tab1Count = "";
            string tab2Count = "";
            string tab3Count = "";
            bool tab1AddComma = false;
            bool tab2AddComma = false;
            foreach (var requiredField in requiredFields)
            {
                if (requiredField.Equals(ItemTypeDragDropFields.QuestionStem1))
                {
                    stemCount = stemCount + "1";
                    stemAddComma = true;
                }
                if (requiredField.Equals(ItemTypeDragDropFields.QuestionStem2))
                {
                    if (stemAddComma)
                    {
                        stemCount = stemCount + ",";
                    }
                    stemCount = stemCount + "2";
                    stemAddComma = true;
                }
                if (requiredField.Equals(ItemTypeDragDropFields.QuestionStem3))
                {
                    if (stemAddComma)
                    {
                        stemCount = stemCount + ",";
                    }
                    stemCount = stemCount + "3";
                }

                if (requiredField.Equals(ItemTypeDragDropFields.AnswerChoiceA))
                {
                    choiceCount = choiceCount + "A";
                    choiceAddComma = true;
                }
                if (requiredField.Equals(ItemTypeDragDropFields.AnswerChoiceB))
                {
                    if (choiceAddComma)
                    {
                        choiceCount = choiceCount + ",";
                    }
                    choiceCount = choiceCount + "B";
                    choiceAddComma = true;
                }
                if (requiredField.Equals(ItemTypeDragDropFields.AnswerChoiceC))
                {
                    if (choiceAddComma)
                    {
                        choiceCount = choiceCount + ",";
                    }
                    choiceCount = choiceCount + "C";
                    choiceAddComma = true;
                }
                if (requiredField.Equals(ItemTypeDragDropFields.AnswerChoiceD))
                {
                    if (choiceAddComma)
                    {
                        choiceCount = choiceCount + ",";
                    }
                    choiceCount = choiceCount + "D";
                }

                if ((requiredField.Equals(ItemTypeDragDropFields.Tab1AnswerChoiceA))
                    || (requiredField.Equals(ItemTypeDragDropFields.Tab1AnswerChoiceB))
                    || (requiredField.Equals(ItemTypeDragDropFields.Tab1AnswerChoiceC))
                    || (requiredField.Equals(ItemTypeDragDropFields.Tab1AnswerChoiceD)))
                {
                    tab1Count = "1";
                }
                if ((requiredField.Equals(ItemTypeDragDropFields.Tab2AnswerChoiceA))
                    || (requiredField.Equals(ItemTypeDragDropFields.Tab2AnswerChoiceB))
                    || (requiredField.Equals(ItemTypeDragDropFields.Tab2AnswerChoiceC))
                    || (requiredField.Equals(ItemTypeDragDropFields.Tab2AnswerChoiceD)))
                {
                    tab2Count = "2";
                }
                if ((requiredField.Equals(ItemTypeDragDropFields.Tab3AnswerChoiceA))
                    || (requiredField.Equals(ItemTypeDragDropFields.Tab3AnswerChoiceB))
                    || (requiredField.Equals(ItemTypeDragDropFields.Tab3AnswerChoiceC))
                    || (requiredField.Equals(ItemTypeDragDropFields.Tab3AnswerChoiceD)))
                {
                    tab3Count = "3";
                }
            }
            string tabCount = "";
            if (tab1Count.Equals("1"))
            {
                tabCount = tab1Count;
                if (tab2Count.Equals("2"))
                {
                    tabCount = tabCount + ",2";
                }
                if (tab3Count.Equals("3"))
                {
                    tabCount = tabCount + ",3";
                }
            }
            else
            {
                if (tab2Count.Equals("2"))
                {
                    tabCount = "2";
                    if (tab3Count.Equals("3"))
                    {
                        tabCount = tabCount + ",3";
                    }
                }
                else
                {
                    if (tab3Count.Equals("3"))
                    {
                        tabCount = "3";
                    }
                }
            }

            string questionStem = "Add question content for question container ";
            questionStem = questionStem + stemCount;
            string answerChoice = "Add content for answer choice ";
            answerChoice = answerChoice + choiceCount;
            string tabAnswerChoice = "Select correct answer for question container ";
            tabAnswerChoice = tabAnswerChoice + tabCount;

            foreach (var requiredField in requiredFields)
            {
                if (requiredField.Equals(ItemTypeDragDropFields.QuestionContent))
                {
                    //get the element's value
                    SelectQuestionContent();
                    string actual = Editor.GetText("").Trim();
                    Editor.SubmitForm();
                    //assert that the element's value is null
                    Assert.AreEqual("", actual, "QuestionContent should be null.");
                    //assert that the expected error message is found in the actual error message list
                    Assert.IsTrue(actualRequiredErrorsList.Contains("Enter content"),
                        "The expected required message '" + "Enter content" + "' was not found in the actual required message list.");
                }
                if (requiredField.Equals(ItemTypeDragDropFields.QuestionStem1))
                {
                    //get the element's value
                    QuestionStemList[0].ContentAdd.Wait(5).Click();
                    string actual = Editor.GetText("").Trim();
                    Editor.SubmitForm();
                    //assert that the element's value is null
                    Assert.AreEqual("", actual, "QuestionStem1 should be null.");
                    //assert that the expected error message is found in the actual error message list
                    Assert.IsTrue(actualRequiredErrorsList.Contains(questionStem),
                        "The expected required message '" + questionStem + "' was not found in the actual required message list.");
                }
                if (requiredField.Equals(ItemTypeDragDropFields.QuestionStem2))
                {
                    //get the element's value
                    QuestionStemList[1].ContentAdd.Wait(5).Click();
                    string actual = Editor.GetText("").Trim();
                    Editor.SubmitForm();
                    //assert that the element's value is null
                    Assert.AreEqual("", actual, "QuestionStem2 should be null.");
                    //assert that the expected error message is found in the actual error message list
                    Assert.IsTrue(actualRequiredErrorsList.Contains(questionStem),
                        "The expected required message '" + questionStem + "' was not found in the actual required message list.");
                }
                if (requiredField.Equals(ItemTypeDragDropFields.QuestionStem3))
                {
                    //get the element's value
                    QuestionStemList[2].ContentAdd.Wait(5).Click();
                    string actual = Editor.GetText("").Trim();
                    Editor.SubmitForm();
                    //assert that the element's value is null
                    Assert.AreEqual("", actual, "QuestionStem3 should be null.");
                    //assert that the expected error message is found in the actual error message list
                    Assert.IsTrue(actualRequiredErrorsList.Contains(questionStem),
                        "The expected required message '" + questionStem + "' was not found in the actual required message list.");
                }
                if (requiredField.Equals(ItemTypeDragDropFields.AnswerChoiceA))
                {
                    //get the element's value
                    AnswerChoiceList[0].ContentAdd.Wait(5).Click();
                    string actual = Editor.GetText("").Trim();
                    Editor.SubmitForm();
                    //assert that the element's value is null
                    Assert.AreEqual("", actual, "AnswerChoiceA should be null.");
                    //assert that the expected error message is found in the actual error message list
                    Assert.IsTrue(actualRequiredErrorsList.Contains(answerChoice),
                        "The expected required message '" + answerChoice + "' was not found in the actual required message list.");
                }
                if (requiredField.Equals(ItemTypeDragDropFields.AnswerChoiceB))
                {
                    //get the element's value
                    AnswerChoiceList[1].ContentAdd.Wait(5).Click();
                    string actual = Editor.GetText("").Trim();
                    Editor.SubmitForm();
                    //assert that the element's value is null
                    Assert.AreEqual("", actual, "AnswerChoiceB should be null.");
                    //assert that the expected error message is found in the actual error message list
                    Assert.IsTrue(actualRequiredErrorsList.Contains(answerChoice),
                        "The expected required message '" + answerChoice + "' was not found in the actual required message list.");
                }
                if (requiredField.Equals(ItemTypeDragDropFields.AnswerChoiceC))
                {
                    //get the element's value
                    AnswerChoiceList[2].ContentAdd.Wait(5).Click();
                    string actual = Editor.GetText("").Trim();
                    Editor.SubmitForm();
                    //assert that the element's value is null
                    Assert.AreEqual("", actual, "AnswerChoiceC should be null.");
                    //assert that the expected error message is found in the actual error message list
                    Assert.IsTrue(actualRequiredErrorsList.Contains(answerChoice),
                        "The expected required message '" + answerChoice + "' was not found in the actual required message list.");
                }
                if (requiredField.Equals(ItemTypeDragDropFields.AnswerChoiceD))
                {
                    //get the element's value
                    AnswerChoiceList[3].ContentAdd.Wait(5).Click();
                    string actual = Editor.GetText("").Trim();
                    Editor.SubmitForm();
                    //assert that the element's value is null
                    Assert.AreEqual("", actual, "AnswerChoiceD should be null.");
                    //assert that the expected error message is found in the actual error message list
                    Assert.IsTrue(actualRequiredErrorsList.Contains(answerChoice),
                        "The expected required message '" + answerChoice + "' was not found in the actual required message list.");
                }


                if (requiredField.Equals(ItemTypeDragDropFields.Tab1AnswerChoiceA))
                {
                    //assert that the expected error message is found in the actual error message list
                    Assert.IsTrue(actualRequiredErrorsList.Contains(tabAnswerChoice),
                        "The expected required message '" + tabAnswerChoice + "' was not found in the actual required message list.");
                }
                if (requiredField.Equals(ItemTypeDragDropFields.Tab1AnswerChoiceB))
                {
                    //assert that the expected error message is found in the actual error message list
                    Assert.IsTrue(actualRequiredErrorsList.Contains(tabAnswerChoice),
                        "The expected required message '" + tabAnswerChoice + "' was not found in the actual required message list.");
                }
                if (requiredField.Equals(ItemTypeDragDropFields.Tab1AnswerChoiceC))
                {
                    //assert that the expected error message is found in the actual error message list
                    Assert.IsTrue(actualRequiredErrorsList.Contains(tabAnswerChoice),
                        "The expected required message '" + tabAnswerChoice + "' was not found in the actual required message list.");
                }
                if (requiredField.Equals(ItemTypeDragDropFields.Tab1AnswerChoiceD))
                {
                    //assert that the expected error message is found in the actual error message list
                    Assert.IsTrue(actualRequiredErrorsList.Contains(tabAnswerChoice),
                        "The expected required message '" + tabAnswerChoice + "' was not found in the actual required message list.");
                }

                if (requiredField.Equals(ItemTypeDragDropFields.Tab2AnswerChoiceA))
                {
                    //assert that the expected error message is found in the actual error message list
                    Assert.IsTrue(actualRequiredErrorsList.Contains(tabAnswerChoice),
                        "The expected required message '" + tabAnswerChoice + "' was not found in the actual required message list.");
                }
                if (requiredField.Equals(ItemTypeDragDropFields.Tab2AnswerChoiceB))
                {
                    //assert that the expected error message is found in the actual error message list
                    Assert.IsTrue(actualRequiredErrorsList.Contains(tabAnswerChoice),
                        "The expected required message '" + tabAnswerChoice + "' was not found in the actual required message list.");
                }
                if (requiredField.Equals(ItemTypeDragDropFields.Tab2AnswerChoiceC))
                {
                    //assert that the expected error message is found in the actual error message list
                    Assert.IsTrue(actualRequiredErrorsList.Contains(tabAnswerChoice),
                        "The expected required message '" + tabAnswerChoice + "' was not found in the actual required message list.");
                }
                if (requiredField.Equals(ItemTypeDragDropFields.Tab2AnswerChoiceD))
                {
                    //assert that the expected error message is found in the actual error message list
                    Assert.IsTrue(actualRequiredErrorsList.Contains(tabAnswerChoice),
                        "The expected required message '" + tabAnswerChoice + "' was not found in the actual required message list.");
                }

                if (requiredField.Equals(ItemTypeDragDropFields.Tab3AnswerChoiceA))
                {
                    //assert that the expected error message is found in the actual error message list
                    Assert.IsTrue(actualRequiredErrorsList.Contains(tabAnswerChoice),
                        "The expected required message '" + tabAnswerChoice + "' was not found in the actual required message list.");
                }
                if (requiredField.Equals(ItemTypeDragDropFields.Tab3AnswerChoiceB))
                {
                    //assert that the expected error message is found in the actual error message list
                    Assert.IsTrue(actualRequiredErrorsList.Contains(tabAnswerChoice),
                        "The expected required message '" + tabAnswerChoice + "' was not found in the actual required message list.");
                }
                if (requiredField.Equals(ItemTypeDragDropFields.Tab3AnswerChoiceC))
                {
                    //assert that the expected error message is found in the actual error message list
                    Assert.IsTrue(actualRequiredErrorsList.Contains(tabAnswerChoice),
                        "The expected required message '" + tabAnswerChoice + "' was not found in the actual required message list.");
                }
                if (requiredField.Equals(ItemTypeDragDropFields.Tab3AnswerChoiceD))
                {
                    //assert that the expected error message is found in the actual error message list
                    Assert.IsTrue(actualRequiredErrorsList.Contains(tabAnswerChoice),
                        "The expected required message '" + tabAnswerChoice + "' was not found in the actual required message list.");
                }
            }
        }
    }
}
