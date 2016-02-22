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
using UITests.Pages.Assess.ItemCreateEdit.v01.ItemForms;
using UITests.Pages.Assess.TestTunnel.TestParts;

namespace UITests.Pages.Assess.TestTunnel.TestForms
{
    /// <summary>
    /// represents the test tunnel - test type form on each page
    /// </summary>
    public class TestTypeForm : SNForm
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="itemType">the item type</param>
        public TestTypeForm(  ItemType itemType)
            : base()
        {
            ItemType = itemType;
            TestItemFlagged = false;
            TestItemStatus = TestItemStatus.Unanswered;
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            SpinnerLoadingImage = new WebElementWrapper(BySpinnerLoadingImage);
            Flag = new WebElementWrapper(ByFlag);
        }

        /// <summary>
        /// the data
        /// </summary>
        public new QuestionAnswerData Data
        {
            get
            {
                return (QuestionAnswerData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        protected ItemTypeData _oldDataObject;
        /// <summary>
        /// the data object
        /// </summary>
        public Object OldDataObject
        {
            get
            {
                return _oldDataObject;
            }
            set
            {
                _oldDataObject = (ItemTypeData)value;
            }
        }

        /// <summary>
        /// the current status of the test item
        /// </summary>
        public TestItemStatus TestItemStatus { get; set; }
        /// <summary>
        /// the current flagged status of the test item
        /// </summary>
        public bool TestItemFlagged { get; set; }
        private ItemType ItemType { get; set; }
        //imgRightLoading
        private By BySpinnerLoadingImage { get { return By.Id("imgRightLoading"); } }
        /// <summary>
        /// the spinner loading image
        /// </summary>
        protected WebElementWrapper SpinnerLoadingImage { get; private set; }
        private By ByFlag { get { return By.Id("divFlagTool"); } }
        private WebElementWrapper Flag { get; set; }


        /// <summary>
        /// is the question answered?
        /// </summary>
        /// <returns>true or false</returns>
        public virtual bool IsQuestionAnswered()
        {
            bool status = false;
            if (TestItemStatus == TestItemStatus.Answered)
            {
                status = true;
            }
            return status;
        }

        /// <summary>
        /// is the question unanswered?
        /// </summary>
        /// <returns>true or false</returns>
        public virtual bool IsQuestionUnanswered()
        {
            bool status = false;
            if (TestItemStatus == TestItemStatus.Unanswered)
            {
                status = true;
            }
            return status;
        }

        /// <summary>
        /// is the question incomplete?
        /// </summary>
        /// <returns>true or false</returns>
        public virtual bool IsQuestionIncomplete()
        {
            bool status = false;
            if (TestItemStatus == TestItemStatus.Incomplete)
            {
                status = true;
            }
            return status;
        }

        /// <summary>
        /// is the question instructions?
        /// </summary>
        /// <returns>true or false</returns>
        public virtual bool IsQuestionInstructions()
        {
            bool status = false;
            if (TestItemStatus == TestItemStatus.Instructions)
            {
                status = true;
            }
            return status;
        }

        /// <summary>
        /// flag the item
        /// </summary>
        public void FlagItem()
        {
            TestItemFlagged = true;
            Flag.Click();
        }
    }
}
