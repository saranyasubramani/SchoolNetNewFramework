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
using UITests.Pages.Components.Editors;
using UITests.Pages.Assess.ItemCreateEdit.v01;
using UITests.Pages.Assess.ItemCreateEdit.v01.ItemForms;

namespace UITests.Pages.Assess.TestDetail.ViewTestDetails
{
    /// <summary>
    /// the view test details form
    /// </summary>
    public class ViewTestDetailsForm : SNForm
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public ViewTestDetailsForm(  string overrideControlPrefix = null)
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
            AddItemLink = new WebElementWrapper( ByAddItemLink);
            AddInstructionsButton = new WebElementWrapper( ByAddInstructionsButton);
            TestContentGrid = new WebElementWrapper( ByTestContentGrid);
            TestContentRows = new WebElementWrapper( ByTestContentRows);
            InstructionEditor = new Editor( PageNames.ViewTestDetails, this.ControlPrefix);
            //generates a list on page load
            SetTestContentList();
        }

        /// <summary>
        /// the data
        /// </summary>
        public new ViewTestDetailsData Data
        {
            get
            {
                return (ViewTestDetailsData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        public string FakeText { get; set; }
        private By ByAddItemLink { get { return By.Id(ControlPrefix + "ButtonAddNewItem"); } }
        private WebElementWrapper AddItemLink { get; set; }
        private By ByAddInstructionsButton { get { return By.Id("addInstructionBTN"); } }
        private WebElementWrapper AddInstructionsButton { get; set; }
        private By ByTestContentGrid { get { return By.CssSelector(".DataGridTable"); } }
        private WebElementWrapper TestContentGrid { get; set; }
        private By ByTestContentRows { get { return By.CssSelector("tr.DataGridRow > td > a"); } }
        private WebElementWrapper TestContentRows { get; set; }
        private WebElementWrapper QuestionLabel { get; set; }
        private ReadOnlyCollection<IWebElement> TestContentWebElementList { get; set; }
        private List<TestContentLineItem> TestContentList { get; set; }
        /// <summary>
        /// the html editor
        /// </summary>
        public Editor InstructionEditor { get; private set; }

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
            TestContentList = new List<TestContentLineItem>();
            TestContentGrid.Wait(3);
            TestContentWebElementList = TestContentRows.WaitForElements(5);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                DummyWebElement dummy1 = new DummyWebElement();
                dummy1.FakeAttributeId = "Anchor326237";//"256324";
                dummy1.FakeAttributeName = "Anchor326237";//"256324";
                DummyWebElement dummy2 = new DummyWebElement();
                dummy2.FakeAttributeId = "Anchor326238";//"256325";
                dummy2.FakeAttributeName = "Anchor326238";//"256325";
                DummyWebElement dummy3 = new DummyWebElement();
                dummy3.FakeAttributeId = "Anchor326239";
                dummy3.FakeAttributeName = "Anchor326239";
                DummyWebElement dummy4 = new DummyWebElement();
                dummy4.FakeAttributeId = "Anchor326240";
                dummy4.FakeAttributeName = "Anchor326240";
                DummyWebElement dummy5 = new DummyWebElement();
                dummy5.FakeAttributeId = "Anchor326241";
                dummy5.FakeAttributeName = "Anchor326241";
                DummyWebElement dummy6 = new DummyWebElement();
                dummy6.FakeAttributeId = "Anchor326242";
                dummy6.FakeAttributeName = "Anchor326242";
                DummyWebElement dummy7 = new DummyWebElement();
                dummy7.FakeAttributeId = "Anchor326243";
                dummy7.FakeAttributeName = "Anchor326243";
                DummyWebElement dummy8 = new DummyWebElement();
                dummy8.FakeAttributeId = "Anchor326244";
                dummy8.FakeAttributeName = "Anchor326244";
                DummyWebElement dummy9 = new DummyWebElement();
                dummy9.FakeAttributeId = "Anchor326245";
                dummy9.FakeAttributeName = "Anchor326245";
                List<IWebElement> list = new List<IWebElement> { dummy1, dummy2, dummy3, dummy4, dummy5, dummy6, dummy7, dummy8, dummy9 };
                TestContentWebElementList = new ReadOnlyCollection<IWebElement>(list);
            }

            int index = 0;
            foreach (var webElement in TestContentWebElementList)
            {
                string id = webElement.GetAttribute("id");
                int itemid = int.Parse(GetItemId(id));
                QuestionLabel = new WebElementWrapper( ByQuestionLabelLocator(id));
                QuestionLabel.FakeAttributeId = "ctl00_MainContent_RepeaterTestItems_ctl01_ViewTestItems1_LabelQuestionLabel";
                string uniqueId = GetUniqueId(QuestionLabel, ByQuestionLabelLocator(id));
                QuestionLabel.Text = "" + index + 1;
                string label = QuestionLabel.Text;
                Report.Write("TestContentLineItem by itemid: '" + itemid + "'; index: '" + index
                    + "'; uniqueId: '" + uniqueId + "'; label: '" + label);
                var lineItem = new TestContentLineItem( webElement, itemid, index, uniqueId, label);
                TestContentList.Add(lineItem);
                index++;
            }
        }

        /// <summary>
        /// get the item central result list
        /// </summary>
        /// <returns>List of TestContentLineItem</returns>
        public List<TestContentLineItem> GetResultsList()
        {
            return TestContentList;
        }

        /// <summary>
        /// gets an item from the item central results list
        /// </summary>
        /// <param name="index">the index of the item</param>
        /// <returns>TestContentLineItem</returns>
        public TestContentLineItem GetItemFromResultsList(int index)
        {
            return TestContentList[index];
        }

        /// <summary>
        /// add item
        /// </summary>
        /// <returns>EditQuestionChooseNewItemPage</returns>
        public EditQuestionChooseNewItemPage AddItem()
        {
            AddItemLink.Wait(3).Click();
            return new EditQuestionChooseNewItemPage();
        }

        /// <summary>
        /// add instruction
        /// </summary>
        /// <returns>EditQuestionChooseNewItemPage</returns>
        public void AddInstructions()
        {
            AddInstructionsButton.Wait(3).Click();
            InstructionEditor.ContentData = Data.Instruction;
            InstructionEditor.InputAndSubmitForm();
        }

        /// <summary>
        /// verify the item content in the results list
        /// </summary>
        /// <param name="index">the item index</param>
        /// <param name="contents">the content</param>
        public void VerifyItemInResultsList(int index, List<string> contents)
        {

            Report.Write("Verifying the expected content is within the actual content.");
            var testContentLineItem = TestContentList[index];
            string actual = null;
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                //actual = "<p>This morning, I went to the <u> 1 - (A) blue  (B) purple  (C) yellow  <b>(D) orange</b>  </u>and bought some milk and eggs. I knew it was going to rain, but I forgot my <u> 2 - (A) blue  <b>(C) purple</b>  </u>and ended up getting <u> 3 - (A) blue  (B) purple  <b>(C) yellow</b>  </u>on the way.</p>";
                actual = FakeText;
            }
            else
            {
                actual = testContentLineItem.GetItemContentText();
            }
            foreach (var content in contents)
            {
                Assert.IsTrue(actual.Contains(content), "The expected content: '" + content + "' was not found within the actual content: '" + actual + "'.");
                Report.Write("Verified the expected content: '" + content + "' was found within the actual content: '" + actual + "'.");
            }
        }

        /// <summary>
        /// verify the correct answers in the results list
        /// </summary>
        /// <param name="index">the item index</param>
        /// <param name="contents">the content</param>
        public void VerifyCorrectAnswersInResultsList(int index, List<string> contents)
        {
            Report.Write("Verifying the expected content is within the actual content.");
            var testContentLineItem = TestContentList[index];
            string actual = null;
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                actual = "Gap 1 - D<br>Gap 2 - C<br>Gap 3 - C<br>";
            }
            else
            {
                actual = testContentLineItem.GetCorrectAnswerText();
            }
            foreach (var content in contents)
            {
                Assert.IsTrue(actual.Contains(content), "The expected content: '" + content + "' was not found within the actual content: '" + actual + "'.");
                Report.Write("Verified the expected content: '" + content + "' was found within the actual content: '" + actual + "'.");
            }
        }

        /// <summary>
        /// verify the point values in the results list
        /// </summary>
        /// <param name="index">the item index</param>
        /// <param name="contents">the content</param>
        public void VerifyPointValuesInResultsList(int index, List<string> contents)
        {
            Report.Write("Verifying the expected content is within the actual content.");
            var testContentLineItem = TestContentList[index];
            string actual = null;
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                actual = "15 Points:<br>Gap 1 - 5<br>Gap 2 - 5<br>Gap 3 - 5<br>";
            }
            else
            {
                actual = testContentLineItem.GetPointValueText();
            }
            foreach (var content in contents)
            {
                Assert.IsTrue(actual.Contains(content), "The expected content: '" + content + "' was not found within the actual content: '" + actual + "'.");
                Report.Write("Verified the expected content: '" + content + "' was found within the actual content: '" + actual + "'.");
            }
        }

        /// <summary>
        /// verify the not worth any points messages
        /// </summary>
        /// <param name="index">the item index</param>
        /// <param name="requiredFields">required fields list</param>
        public void VerifyNotWorthAnyPoints(int index, List<ItemTypeDragDropFields> requiredFields)
        {
            Report.Write("Verifying the expected required message is within the actual required message list.");
            var testContentLineItem = TestContentList[index];
            List<string> actualRequiredErrorsList = testContentLineItem.GetStepsToCompleteList();

            string tabAnswerChoice = "Not worth any points";

            foreach (var requiredField in requiredFields)
            {
                if (requiredField.Equals(ItemTypeDragDropFields.Tab1AnswerChoiceA))
                {
                    //assert that the expected error message is found in the actual error message list
                    VerifyExpectedIsInActualList(tabAnswerChoice, actualRequiredErrorsList);
                }
                if (requiredField.Equals(ItemTypeDragDropFields.Tab1AnswerChoiceB))
                {
                    //assert that the expected error message is found in the actual error message list
                    VerifyExpectedIsInActualList(tabAnswerChoice, actualRequiredErrorsList);
                }
                if (requiredField.Equals(ItemTypeDragDropFields.Tab1AnswerChoiceC))
                {
                    //assert that the expected error message is found in the actual error message list
                    VerifyExpectedIsInActualList(tabAnswerChoice, actualRequiredErrorsList);
                }
                if (requiredField.Equals(ItemTypeDragDropFields.Tab1AnswerChoiceD))
                {
                    //assert that the expected error message is found in the actual error message list
                    VerifyExpectedIsInActualList(tabAnswerChoice, actualRequiredErrorsList);
                }

                if (requiredField.Equals(ItemTypeDragDropFields.Tab2AnswerChoiceA))
                {
                    //assert that the expected error message is found in the actual error message list
                    VerifyExpectedIsInActualList(tabAnswerChoice, actualRequiredErrorsList);
                }
                if (requiredField.Equals(ItemTypeDragDropFields.Tab2AnswerChoiceB))
                {
                    //assert that the expected error message is found in the actual error message list
                    VerifyExpectedIsInActualList(tabAnswerChoice, actualRequiredErrorsList);
                }
                if (requiredField.Equals(ItemTypeDragDropFields.Tab2AnswerChoiceC))
                {
                    //assert that the expected error message is found in the actual error message list
                    VerifyExpectedIsInActualList(tabAnswerChoice, actualRequiredErrorsList);
                }
                if (requiredField.Equals(ItemTypeDragDropFields.Tab2AnswerChoiceD))
                {
                    //assert that the expected error message is found in the actual error message list
                    VerifyExpectedIsInActualList(tabAnswerChoice, actualRequiredErrorsList);
                }

                if (requiredField.Equals(ItemTypeDragDropFields.Tab3AnswerChoiceA))
                {
                    //assert that the expected error message is found in the actual error message list
                    VerifyExpectedIsInActualList(tabAnswerChoice, actualRequiredErrorsList);
                }
                if (requiredField.Equals(ItemTypeDragDropFields.Tab3AnswerChoiceB))
                {
                    //assert that the expected error message is found in the actual error message list
                    VerifyExpectedIsInActualList(tabAnswerChoice, actualRequiredErrorsList);
                }
                if (requiredField.Equals(ItemTypeDragDropFields.Tab3AnswerChoiceC))
                {
                    //assert that the expected error message is found in the actual error message list
                    VerifyExpectedIsInActualList(tabAnswerChoice, actualRequiredErrorsList);
                }
                if (requiredField.Equals(ItemTypeDragDropFields.Tab3AnswerChoiceD))
                {
                    //assert that the expected error message is found in the actual error message list
                    VerifyExpectedIsInActualList(tabAnswerChoice, actualRequiredErrorsList);
                }
            }
        }

        /// <summary>
        /// verify the steps to complete in results list
        /// </summary>
        /// <param name="index">the item index</param>
        /// <param name="expectedRequiredErrorsList">expected required errors list</param>
        public void VerifyStepsToCompleteInResultsList(int index, List<string> expectedRequiredErrorsList)
        {
            Report.Write("Verifying the expected required message is within the actual required message list.");
            var testContentLineItem = TestContentList[index];
            List<string> actualRequiredErrorsList = testContentLineItem.GetStepsToCompleteList();

            foreach (var expectedRequiredError in expectedRequiredErrorsList)
            {
                VerifyExpectedIsInActualList(expectedRequiredError, actualRequiredErrorsList);
            }
        }

        private void VerifyExpectedIsInActualList(string expected, List<string> actualList)
        {
            bool isFound = false;
            foreach (var actual in actualList)
            {
                //check that the expected error message is found in the actual error message list
                if (actual.Contains(expected))
                {
                    isFound = true;
                }
            }
            Assert.IsTrue(isFound, "The expected message '" + expected + "' was not found in the actual message list.");
            Report.Write("Verified the expected message: '" + expected + "' was found within the actual message list.");
        }


        /// <summary>
        /// verify error for required field
        /// </summary>
        /// <param name="index">index</param>
        /// <param name="requiredFields">list of required item type drag and drop form fields</param>
        public void VerifyErrorForRequiredField(int index, List<ItemTypeDragDropFields> requiredFields)
        {
            Report.Write("Verifying the expected required message is within the actual required message list.");
            var testContentLineItem = TestContentList[index];
            List<string> actualRequiredErrorsList = testContentLineItem.GetStepsToCompleteList();

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
                    //assert that the expected error message is found in the actual error message list
                    VerifyExpectedIsInActualList("Enter content", actualRequiredErrorsList);
                }
                if (requiredField.Equals(ItemTypeDragDropFields.QuestionStem1))
                {
                    //assert that the expected error message is found in the actual error message list
                    VerifyExpectedIsInActualList(questionStem, actualRequiredErrorsList);
                }
                if (requiredField.Equals(ItemTypeDragDropFields.QuestionStem2))
                {
                    //assert that the expected error message is found in the actual error message list
                    VerifyExpectedIsInActualList(questionStem, actualRequiredErrorsList);
                }
                if (requiredField.Equals(ItemTypeDragDropFields.QuestionStem3))
                {
                    //assert that the expected error message is found in the actual error message list
                    VerifyExpectedIsInActualList(questionStem, actualRequiredErrorsList);
                }
                if (requiredField.Equals(ItemTypeDragDropFields.AnswerChoiceA))
                {
                    //assert that the expected error message is found in the actual error message list
                    VerifyExpectedIsInActualList(answerChoice, actualRequiredErrorsList);
                }
                if (requiredField.Equals(ItemTypeDragDropFields.AnswerChoiceB))
                {
                    //assert that the expected error message is found in the actual error message list
                    VerifyExpectedIsInActualList(answerChoice, actualRequiredErrorsList);
                }
                if (requiredField.Equals(ItemTypeDragDropFields.AnswerChoiceC))
                {
                    //assert that the expected error message is found in the actual error message list
                    VerifyExpectedIsInActualList(answerChoice, actualRequiredErrorsList);
                }
                if (requiredField.Equals(ItemTypeDragDropFields.AnswerChoiceD))
                {
                    //assert that the expected error message is found in the actual error message list
                    VerifyExpectedIsInActualList(answerChoice, actualRequiredErrorsList);
                }


                if (requiredField.Equals(ItemTypeDragDropFields.Tab1AnswerChoiceA))
                {
                    //assert that the expected error message is found in the actual error message list
                    VerifyExpectedIsInActualList(tabAnswerChoice, actualRequiredErrorsList);
                }
                if (requiredField.Equals(ItemTypeDragDropFields.Tab1AnswerChoiceB))
                {
                    //assert that the expected error message is found in the actual error message list
                    VerifyExpectedIsInActualList(tabAnswerChoice, actualRequiredErrorsList);
                }
                if (requiredField.Equals(ItemTypeDragDropFields.Tab1AnswerChoiceC))
                {
                    //assert that the expected error message is found in the actual error message list
                    VerifyExpectedIsInActualList(tabAnswerChoice, actualRequiredErrorsList);
                }
                if (requiredField.Equals(ItemTypeDragDropFields.Tab1AnswerChoiceD))
                {
                    //assert that the expected error message is found in the actual error message list
                    VerifyExpectedIsInActualList(tabAnswerChoice, actualRequiredErrorsList);
                }

                if (requiredField.Equals(ItemTypeDragDropFields.Tab2AnswerChoiceA))
                {
                    //assert that the expected error message is found in the actual error message list
                    VerifyExpectedIsInActualList(tabAnswerChoice, actualRequiredErrorsList);
                }
                if (requiredField.Equals(ItemTypeDragDropFields.Tab2AnswerChoiceB))
                {
                    //assert that the expected error message is found in the actual error message list
                    VerifyExpectedIsInActualList(tabAnswerChoice, actualRequiredErrorsList);
                }
                if (requiredField.Equals(ItemTypeDragDropFields.Tab2AnswerChoiceC))
                {
                    //assert that the expected error message is found in the actual error message list
                    VerifyExpectedIsInActualList(tabAnswerChoice, actualRequiredErrorsList);
                }
                if (requiredField.Equals(ItemTypeDragDropFields.Tab2AnswerChoiceD))
                {
                    //assert that the expected error message is found in the actual error message list
                    VerifyExpectedIsInActualList(tabAnswerChoice, actualRequiredErrorsList);
                }

                if (requiredField.Equals(ItemTypeDragDropFields.Tab3AnswerChoiceA))
                {
                    //assert that the expected error message is found in the actual error message list
                    VerifyExpectedIsInActualList(tabAnswerChoice, actualRequiredErrorsList);
                }
                if (requiredField.Equals(ItemTypeDragDropFields.Tab3AnswerChoiceB))
                {
                    //assert that the expected error message is found in the actual error message list
                    VerifyExpectedIsInActualList(tabAnswerChoice, actualRequiredErrorsList);
                }
                if (requiredField.Equals(ItemTypeDragDropFields.Tab3AnswerChoiceC))
                {
                    //assert that the expected error message is found in the actual error message list
                    VerifyExpectedIsInActualList(tabAnswerChoice, actualRequiredErrorsList);
                }
                if (requiredField.Equals(ItemTypeDragDropFields.Tab3AnswerChoiceD))
                {
                    //assert that the expected error message is found in the actual error message list
                    VerifyExpectedIsInActualList(tabAnswerChoice, actualRequiredErrorsList);
                }
            }
        }
    }
}
