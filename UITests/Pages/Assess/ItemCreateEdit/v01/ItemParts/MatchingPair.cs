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
    /// matchine pair component
    /// </summary>
    public class MatchingPair : SNComponent
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="label"></param>
        /// <param name="index"></param>
        /// <param name="uniqueId"></param>
        /// <param name="overrideControlPrefix"></param>
        public MatchingPair(string label, int index, string uniqueId, string overrideControlPrefix = null)
            : base()
        {
            this.Label = label;
            this.Index = index;
            this.UniqueId = uniqueId;
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }
            QuestionAnswerPair = new QuestionAnswerPair(uniqueId, ItemType.Matching, ControlPrefix);
            AnswerLineItem = new AnswerLineItem(index, uniqueId, ItemType.Matching, ControlPrefix);
            TeacherExplanation = new StudentTeacherExplanation(index, ExplanationType.Teacher, ItemType.Matching, ControlPrefix);
            StudentExplanation = new StudentTeacherExplanation(index, ExplanationType.Student, ItemType.Matching, ControlPrefix);
        }
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
        /// question/answer pair
        /// </summary>
        public QuestionAnswerPair QuestionAnswerPair { get; private set; }
        /// <summary>
        /// answer line item
        /// </summary>
        public AnswerLineItem AnswerLineItem { get; private set; }
        /// <summary>
        /// teacher explanation
        /// </summary>
        public StudentTeacherExplanation TeacherExplanation { get; private set; }
        /// <summary>
        /// student explanation
        /// </summary>
        public StudentTeacherExplanation StudentExplanation { get; private set; }
        /// <summary>
        /// select question
        /// </summary>
        /// <param name="text">question</param>
        public void SelectQuestionStem(string text)
        {
            QuestionAnswerPair.Stem.SelectByText(text);
        }
        /// <summary>
        /// select answer choice
        /// </summary>
        /// <param name="text">answer</param>
        public void SelectAnswerChoice(string text)
        {
            QuestionAnswerPair.Choice.SelectByText(text);
        }
        /// <summary>
        /// edit points possible
        /// </summary>
        /// <param name="text">points</param>
        public void EditPointsPossible(string text)
        {
            AnswerLineItem.PointsPossible.Clear();
            AnswerLineItem.PointsPossible.Wait(3).SendKeys(text);
        }
        /// <summary>
        /// get points possible
        /// </summary>
        /// <returns></returns>
        public string GetPointsPossibles()
        {
            return AnswerLineItem.PointsPossible.Wait(3).Text;
        }
        /// <summary>
        /// check is correct response
        /// </summary>
        public void SelectIsCorrectResponse()
        {
            AnswerLineItem.IsCorrectResponse.Wait(3).Check();
        }
        /// <summary>
        /// remove line
        /// </summary>
        public void RemoveLine()
        {
            AnswerLineItem.RemoveLine.Wait(3).Click();
        }
        /// <summary>
        /// add teacher explanation
        /// </summary>
        public void SelectAddTeacherExplanation()
        {
            TeacherExplanation.Add.Wait(3).Click();
        }
        /// <summary>
        /// edit teacher explanation
        /// </summary>
        public void SelectEditTeacherExplanation()
        {
            TeacherExplanation.Edit.Wait(3).Click();
        }
        /// <summary>
        /// add student explanation
        /// </summary>
        public void SelectAddStudentExplanation()
        {
            StudentExplanation.Add.Wait(3).Click();
        }
        /// <summary>
        /// edit student explanation
        /// </summary>
        public void SelectEditStudentExplanation()
        {
            StudentExplanation.Edit.Wait(3).Click();
        }
    }
}
