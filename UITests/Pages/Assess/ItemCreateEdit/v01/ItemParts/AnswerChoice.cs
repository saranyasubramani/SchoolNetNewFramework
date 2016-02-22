using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Framework;
using Core.Views;
using Core.Tools.WebDriver;
using OpenQA.Selenium;
using UITests.Pages.Components;

namespace UITests.Pages.Assess.ItemCreateEdit.v01.ItemParts
{
    /// <summary>
    /// Represents an Answer Choice line item.
    /// </summary>
    public class AnswerChoice : SNComponent
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="itemType"></param>
        /// <param name="label"></param>
        /// <param name="index"></param>
        /// <param name="uniqueId"></param>
        /// <param name="overrideControlPrefix"></param>
        public AnswerChoice(ItemType itemType, string label, int index, string uniqueId, string overrideControlPrefix = null)
            : base()
        {
            this.ItemType = itemType;
            this.Label = label;
            this.Index = index;
            this.UniqueId = uniqueId;
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }
            AnswerContent = new QuestionAnswerContent(label, index, uniqueId, ContentType.AnswerChoice, ItemType, ControlPrefix);
            AnswerLineItem = new AnswerLineItem(index, uniqueId, ItemType, ControlPrefix);
            TeacherExplanation = new StudentTeacherExplanation(index, ExplanationType.Teacher, ItemType, ControlPrefix);
            StudentExplanation = new StudentTeacherExplanation(index, ExplanationType.Student, ItemType, ControlPrefix);
            HotSpot = new WebElementWrapper(ByHotSpot());
        }
        /// <summary>
        /// item type
        /// </summary>
        public ItemType ItemType { get; private set; }
        /// <summary>
        /// label
        /// </summary>
        public string Label { get; set; }
        /// <summary>
        /// index
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// unique ID
        /// </summary>
        public string UniqueId { get; set; }
        /// <summary>
        /// is correct answer?
        /// </summary>
        public bool IsCorrectAnswer { get; set; }
        /// <summary>
        /// point value
        /// </summary>
        public int PointValue { get; set; }

        /// <summary>
        /// answer content
        /// </summary>
        public QuestionAnswerContent AnswerContent { get; private set; }

        /// <summary>
        /// The points possible, is correct response, and remove line fields.
        /// </summary>
        public AnswerLineItem AnswerLineItem { get; private set; }

        /// <summary>
        /// The teacher explanation field.
        /// </summary>
        public StudentTeacherExplanation TeacherExplanation { get; private set; }

        /// <summary>
        /// The student explanation field.
        /// </summary>
        public StudentTeacherExplanation StudentExplanation { get; private set; }

        /// <summary>
        /// hot spot by
        /// </summary>
        /// <returns>By</returns>
        public By ByHotSpot()
        {
            By by = null;
            switch (this.ItemType)
            {
                case ItemType.HotSpotSingleSelection:
                    by = By.CssSelector("#tblAnswers tbody[ng-repeat='answer in TestItem.Answers']:nth-of-type(" + Index + ") button.btn");
                    break;
            }
            return by;
        }
        /// <summary>
        /// hot spot element
        /// </summary>
        private WebElementWrapper HotSpot { get; set; }


        /// <summary>
        /// Selects the answer choice label, ie. A, B, C, D
        /// </summary>
        public void SelectLabel()
        {
            AnswerContent.ContentLabel.Wait(3).Click();
        }

        /// <summary>
        /// Edit the answer choice label, ie. A, B, C, D
        /// </summary>
        /// <param name="text">the new label</param>
        public void EditLabel(string text)
        {
            AnswerContent.ContentLabel.Wait(3).SendKeys(text);
        }

        /// <summary>
        /// Select the label "Click to add content" to add content in an Html Editor
        /// </summary>
        public void SelectContentAdd()
        {
            AnswerContent.ContentAdd.Wait(3).Click();
        }

        /// <summary>
        /// Select the label "Click to add content" to edit it's contents in an Html Editor
        /// </summary>
        public void SelectContentEdit()
        {
            AnswerContent.ContentEdit.Wait(3).Click();
        }

        /// <summary>
        /// Edit the text box "Click to add content"
        /// </summary>
        /// <param name="text">the content to add or edit</param>
        public void EditContent(string text)
        {
            AnswerContent.ContentEdit.Wait(3).SendKeys(text);
        }

        /// <summary>
        /// Get the content from the text box "Click to add content"
        /// </summary>
        /// <param name="fakeData">fake data</param>
        /// <returns>the content</returns>
        public string GetContent(string fakeData = null)
        {
            AnswerContent.ContentEdit.Wait(3);
            AnswerContent.ContentEdit.Text = fakeData;
            return AnswerContent.ContentEdit.Text;
        }
        /*
        /// <summary>
        /// Get the content from the text box "Click to add content"
        /// </summary>
        /// <returns>the content</returns>
        public string GetContent()
        {
            return AnswerContent.ContentEdit.Wait(3).Text;
        }
        */

        /// <summary>
        /// Edit the points possible
        /// </summary>
        /// <param name="points">the points possible</param>
        public void EditPointsPossible(string points)
        {
            AnswerLineItem.PointsPossible.Clear();
            AnswerLineItem.PointsPossible.Wait(3).SendKeys(points);
            PointValue = int.Parse(points);
        }

        /// <summary>
        /// Edit the points possible
        /// </summary>
        /// <param name="points">the points possible</param>
        public void EditPointsPossible(int points)
        {
            AnswerLineItem.PointsPossible.Clear();
            AnswerLineItem.PointsPossible.Wait(3).SendKeys("" + points);
            PointValue = points;
        }

        /// <summary>
        /// Get the points possible
        /// </summary>
        /// <param name="fakeData">fake data</param>
        /// <returns>the points possible</returns>
        public string GetPointsPossible(string fakeData = null)
        {
            AnswerLineItem.PointsPossible.Wait(3);
            AnswerLineItem.PointsPossible.Text = fakeData;
            return AnswerLineItem.PointsPossible.Text;
        }

        /// <summary>
        /// Check or uncheck is correct response
        /// </summary>
        public void SelectIsCorrectResponse()
        {
            AnswerLineItem.IsCorrectResponse.Wait(3).Check();
            IsCorrectAnswer = true;
        }
        /// <summary>
        /// Check is correct response
        /// </summary>
        public void CheckIsCorrectResponse()
        {
            AnswerLineItem.IsCorrectResponse.Wait(3).Check();
            IsCorrectAnswer = true;
        }
        /// <summary>
        /// Uncheck is correct response
        /// </summary>
        public void UnCheckIsCorrectResponse()
        {
            //TODO: uncheck doesnt work cause Devs dont set the 'checked' attribute on check box.
            AnswerLineItem.IsCorrectResponse.Wait(3).UnCheck();
            IsCorrectAnswer = false;
        }

        /// <summary>
        /// Remove the line item
        /// </summary>
        public void RemoveLine()
        {
            AnswerLineItem.RemoveLine.Wait(3).Click();
        }

        /// <summary>
        /// Select the teacher's explanation link to add content in an Html Editor
        /// </summary>
        public void SelectTeacherExplanation()
        {
            TeacherExplanation.Add.Wait(3).Click();
        }

        /// <summary>
        /// Select the teacher's explanation label to edit it's contents in an Html Editor
        /// </summary>
        public void SelectEditTeacherExplanation()
        {
            TeacherExplanation.Edit.Wait(3).Click();
        }

        /// <summary>
        /// Select the student's explanation link to add content in an Html Editor
        /// </summary>
        public void SelectStudentExplanation()
        {
            StudentExplanation.Add.Wait(3).Click();
        }

        /// <summary>
        /// Select the student's explanation label to edit it's contents in an Html Editor
        /// </summary>
        public void SelectEditStudentExplanation()
        {
            StudentExplanation.Edit.Wait(3).Click();
        }

        /// <summary>
        /// Selects the add/edit hotspot button, ie. A, B, C, D
        /// </summary>
        public void SelectHotSpot()
        {
            HotSpot.Wait(3).Click();
        }
    }
}
