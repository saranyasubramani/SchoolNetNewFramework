using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages.Assess.Rubric.Components;

namespace UITests.Pages.Assess.Rubric
{
    /// <summary>
    /// Dialog that pops up when first choosing to create a new rubric, or clicking the "Choose Rubric" button when editing a rubric.
    /// Access to it might be in other places as well.
    /// </summary>
    public class ChooseGroupingRubricDialog : SNForm
    {
        /// <summary>
        /// constructor
        /// </summary>
        public ChooseGroupingRubricDialog()
            : base()
        {
            InitElements();
        }
        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            Grouping_RadioDisabled = new WebElementWrapper(ByGrouping_RadioDisabled);
            Grouping_RadioEnabled = new WebElementWrapper(ByGrouping_RadioEnabled);
            CancelGrouping_Button = new WebElementWrapper(ByCancelGrouping_Button);
            ScoreEntryOnEach_Radio = new WebElementWrapper(ByScoreEntryOnEach_Radio);
            ScoreEntryOnGroups_Radio = new WebElementWrapper(ByScoreEntryOnGroups_Radio);  
        }

        /// <summary>
        /// the rubric group type
        /// </summary>
        public RubricGroupType GroupType { get; set; }
        public By ByGrouping_RadioDisabled { get { return By.Id(ControlPrefix + "ctl00_rbGroupingDisable"); } }
        public WebElementWrapper Grouping_RadioDisabled { get; private set; }
        public By ByGrouping_RadioEnabled { get { return By.Id(ControlPrefix + "ctl00_rbGroupingEnabled"); } }
        public WebElementWrapper Grouping_RadioEnabled { get; private set; }
        //ctl00_MainContent_ctl00_btnCancelChangeDisplayType
        public By ByCancelGrouping_Button { get { return By.Id(ControlPrefix + "ctl00_btnCancelChangeDisplayType"); } }
        public WebElementWrapper CancelGrouping_Button { get; private set; }
        public By ByScoreEntryOnEach_Radio { get { return By.Id(ControlPrefix + "ctl00_rbScoringOnRow"); } }
        public WebElementWrapper ScoreEntryOnEach_Radio { get; private set; }
        public By ByScoreEntryOnGroups_Radio { get { return By.Id(ControlPrefix + "ctl00_rbScoringOnHeader"); } }
        public WebElementWrapper ScoreEntryOnGroups_Radio { get; private set; }
        public override By BySubmit { get { return By.Id(ControlPrefix + "ctl00_btnChangeDisplayType"); } }

        /// <summary>
        /// set grouping enabled
        /// </summary>
        public void SetGroupingEnabled()
        {
            Grouping_RadioEnabled.Click();
        }
        /// <summary>
        /// set grouping disabled
        /// </summary>
        /// <returns>RubricGroupType</returns>
        public RubricGroupType SetGroupingDisabled()
        {
            Grouping_RadioDisabled.Click();
            GroupType = RubricGroupType.None;
            return GroupType;
        }
        /// <summary>
        /// set score entry on each quality trait or skill
        /// </summary>
        /// <returns>RubricGroupType</returns>
        public RubricGroupType SetScoreEntryOnEachQualityTraitOrskill()
        {
            ScoreEntryOnEach_Radio.Click();
            GroupType = RubricGroupType.EachQualityTraitOrskill;
            return GroupType;
        }
        /// <summary>
        /// set score entry on groups
        /// </summary>
        /// <returns>RubricGroupType</returns>
        public RubricGroupType SetScoreEntryOnGroups()
        {
            ScoreEntryOnGroups_Radio.Click();
            GroupType = RubricGroupType.GroupOfThese;
            return GroupType;
        }
        /// <summary>
        /// cancel grouping
        /// </summary>
        public void CancelGrouping()
        {
            CancelGrouping_Button.Click();
        }

        //implemented methods
        public override IBaseScreenView SubmitForm()
        {
            try
            {
                Submit.Wait(5).Click();
            }
            catch (Exception e)
            {
                //Retry clicking again
                Submit.Wait(5).Click();
            }
            return ReturnSubmitPage();
        }

        public override IBaseScreenView ReturnSubmitPage()
        {
            return new EditRubricPage(GroupType);
        }
    }
}
