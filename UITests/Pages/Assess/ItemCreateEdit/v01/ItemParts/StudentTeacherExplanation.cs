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
    /// Represents the Teacher Explanation or Student Explanation fields.
    /// </summary>
    public class StudentTeacherExplanation : SNComponent
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="index"></param>
        /// <param name="explanationType"></param>
        /// <param name="itemType"></param>
        /// <param name="overrideControlPrefix"></param>
        public StudentTeacherExplanation(int index, ExplanationType explanationType, ItemType itemType, string overrideControlPrefix = null)
            : base()
        {
            this.Index = index;
            this.ExplanationType = explanationType;
            this.ItemType = itemType;
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }
            Add = new WebElementWrapper(ByAdd());
            Edit = new WebElementWrapper(ByEdit());
        }
        /// <summary>
        /// index
        /// </summary>
        public int Index { get; private set; }
        /// <summary>
        /// explanation type
        /// </summary>
        private ExplanationType ExplanationType { get; set; }
        /// <summary>
        /// item type
        /// </summary>
        private ItemType ItemType { get; set; }

        /// <summary>
        /// The teacher or student explanation add link.
        /// </summary>
        public WebElementWrapper Add { get; private set; }

        /// <summary>
        /// The teacher or student explanation edit label.
        /// </summary>
        public WebElementWrapper Edit { get; private set; }

        private By ByAdd()
        {
            By by = null;
            //Student
            if ((this.ExplanationType == ExplanationType.Student) && (this.ItemType == ItemType.Matching))
            {
                by = By.CssSelector("li[onclick*='MatchPairStuExpContent" + this.Index + "']");
            }
            if ((this.ExplanationType == ExplanationType.Student)
                && ((this.ItemType == ItemType.MultipleChoice) || (this.ItemType == ItemType.TrueFalse)))
            {
                by = By.CssSelector("li[onclick*='AnswerChoiceStuExpContent" + this.Index + "']");
            }
            if ((this.ExplanationType == ExplanationType.Student) && (this.ItemType == ItemType.InlineResponse))
            {
                by = By.CssSelector("div[onclick*='ClozeStemStuExpContent" + this.Index + "']");
            }
            if ((this.ExplanationType == ExplanationType.Student) && (this.ItemType == ItemType.DragAndDrop))
            {
                by = By.CssSelector(".tab-pane.ng-scope.active .listChoices li[data-ng-repeat='tabChoice in tab.AllChoices']:nth-of-type(" + this.Index + ") div[data-content='tabChoice.StudentExplanation.Body']");
            }
            //Teacher
            if ((this.ExplanationType == ExplanationType.Teacher) && (this.ItemType == ItemType.Matching))
            {
                by = By.CssSelector("li[onclick*='MatchPairTeaExpContent" + this.Index + "']");
            }
            if ((this.ExplanationType == ExplanationType.Teacher)
                && ((this.ItemType == ItemType.MultipleChoice) || (this.ItemType == ItemType.TrueFalse)))
            {
                by = By.CssSelector("li[onclick*='AnswerChoiceTeaExpContent" + this.Index + "']");
            }
            if ((this.ExplanationType == ExplanationType.Teacher) && (this.ItemType == ItemType.InlineResponse))
            {
                by = By.CssSelector("div[onclick*='ClozeStemTeaExpContent" + this.Index + "']");
            }
            if ((this.ExplanationType == ExplanationType.Teacher) && (this.ItemType == ItemType.DragAndDrop))
            {
                by = By.CssSelector(".tab-pane.ng-scope.active .listChoices li[data-ng-repeat='tabChoice in tab.AllChoices']:nth-of-type(" + this.Index + ") div[data-content='tabChoice.TeacherExplanation.Body']");
            }
            return by;
        }

        private By ByEdit()
        {
            By by = null;
            //Student
            if ((this.ExplanationType == ExplanationType.Student) && (this.ItemType == ItemType.Matching))
            {
                by = By.Id("divMatchPairStuExpContent" + this.Index);
            }
            if ((this.ExplanationType == ExplanationType.Student)
                && ((this.ItemType == ItemType.MultipleChoice) || (this.ItemType == ItemType.TrueFalse)))
            {
                by = By.Id("divAnswerChoiceStuExpContent" + this.Index);
            }
            if ((this.ExplanationType == ExplanationType.Student) && (this.ItemType == ItemType.InlineResponse))
            {
                by = By.Id("divClozeStemStuExpContent" + this.Index);
            }
            if ((this.ExplanationType == ExplanationType.Student) && (this.ItemType == ItemType.DragAndDrop))
            {
                by = By.CssSelector(".tab-pane.ng-scope.active .listChoices li[data-ng-repeat='tabChoice in tab.AllChoices']:nth-of-type(" + this.Index + ") div[data-content='tabChoice.StudentExplanation.Body']");
            }
            //Teacher
            if ((this.ExplanationType == ExplanationType.Teacher) && (this.ItemType == ItemType.Matching))
            {
                by = By.Id("divMatchPairTeaExpContent" + this.Index);
            }
            if ((this.ExplanationType == ExplanationType.Teacher)
                && ((this.ItemType == ItemType.MultipleChoice) || (this.ItemType == ItemType.TrueFalse)))
            {
                by = By.Id("divAnswerChoiceTeaExpContent" + this.Index);
            }
            if ((this.ExplanationType == ExplanationType.Teacher) && (this.ItemType == ItemType.InlineResponse))
            {
                by = By.Id("divClozeStemTeaExpContent" + this.Index);
            }
            if ((this.ExplanationType == ExplanationType.Teacher) && (this.ItemType == ItemType.DragAndDrop))
            {
                by = By.CssSelector(".tab-pane.ng-scope.active .listChoices li[data-ng-repeat='tabChoice in tab.AllChoices']:nth-of-type(" + this.Index + ") div[data-content='tabChoice.TeacherExplanation.Body']");
            }
            return by;
        }

    }
}
