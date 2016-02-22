using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Tools.WebDriver;
using OpenQA.Selenium;
using UITests.Pages.Components;

namespace UITests.Pages.Assess.ItemCreateEdit.v01.ItemParts
{
    /// <summary>
    /// question/answer pair
    /// </summary>
    public class QuestionAnswerPair : SNComponent
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <param name="itemType"></param>
        /// <param name="overrideControlPrefix"></param>
        public QuestionAnswerPair(string uniqueId, ItemType itemType, string overrideControlPrefix = null)
            : base()
        {
            this.UniqueId = uniqueId;
            this.ItemType = itemType;
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }
            Stem = new SelectElementWrapper(new WebElementWrapper(ByStem));
            Choice = new SelectElementWrapper(new WebElementWrapper(ByChoice));
        }
        /// <summary>
        /// unique ID
        /// </summary>
        public string UniqueId { get; set; }
        /// <summary>
        /// item type
        /// </summary>
        private ItemType ItemType { get; set; }

        //ctl00_MainContent_EditTestItemControl_pairsRepeator_ctl03_ddlStems
        /// <summary>
        /// qustion stem by
        /// </summary>
        public By ByStem { get { return By.Id(StemLocator()); } }
        /// <summary>
        /// question stem
        /// </summary>
        public SelectElementWrapper Stem { get; private set; }

        //ctl00_MainContent_EditTestItemControl_pairsRepeator_ctl03_ddlChoices
        /// <summary>
        /// answer choice by
        /// </summary>
        public By ByChoice { get { return By.Id(ChoiceLocator()); } }
        /// <summary>
        /// answer choice
        /// </summary>
        public SelectElementWrapper Choice { get; private set; }

        private string StemLocator()
        {
            string locator = null;
            switch (this.ItemType)
            {
                case ItemType.Matching:
                    locator = ControlPrefix + "EditTestItemControl_pairsRepeator_" + this.UniqueId + "_ddlStems";
                    break;
            }
            return locator;
        }

        private string ChoiceLocator()
        {
            string locator = null;
            switch (this.ItemType)
            {
                case ItemType.Matching:
                    locator = ControlPrefix + "EditTestItemControl_pairsRepeator_" + this.UniqueId + "_ddlChoices";
                    break;
            }
            return locator;
        }
    }
}
