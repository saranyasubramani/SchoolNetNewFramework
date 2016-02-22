using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;

namespace UITests.Pages.Assess.Components
{
    /// <summary>
    /// the test stages detail component
    /// </summary>
    public class TestStages : SNDetail
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="pageNames">the page name</param>
        /// <param name="overrideControlPrefix">the override control prefix</param>
        public TestStages(PageNames pageNames, string overrideControlPrefix = null)
            : base()
        {
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }
            PageNames = pageNames;
            InitElements();
        }
        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            PrivateDraftLabel = new WebElementWrapper(ByPrivateDraftLabel);
            PublicDraftLabel = new WebElementWrapper(ByPublicDraftLabel);
            ReadyToScheduleLabel = new WebElementWrapper(ByReadyToScheduleLabel);
            ScheduledLabel = new WebElementWrapper(ByScheduledLabel);
            InProgressLabel = new WebElementWrapper(ByInProgressLabel);
            CompletedLabel = new WebElementWrapper(ByCompletedLabel);
            NotSpecifiedLabel = new WebElementWrapper(ByNotSpecifiedLabel);
            MakePublicButton = new WebElementWrapper(ByMakePublicButton);
            ReadyToScheduleButton = new WebElementWrapper(ByReadyToScheduleButton);
            ScheduleButton = new WebElementWrapper(ByScheduleButton);
        }

        private PageNames PageNames { get; set; }
        /// <summary>
        /// the test stage
        /// </summary>
        public TestStage TestStage { get; set; }
        private By ByPrivateDraftLabel { get { return By.XPath("//span[contains(text(), 'Private Draft')]"); } }
        private WebElementWrapper PrivateDraftLabel { get; set; }
        private By ByPublicDraftLabel { get { return By.XPath("//span[contains(text(), 'Public Draft')]"); } }
        private WebElementWrapper PublicDraftLabel { get; set; }
        private By ByReadyToScheduleLabel { get { return By.XPath("//span[contains(text(), 'Ready To Schedule')]"); } }
        private WebElementWrapper ReadyToScheduleLabel { get; set; }
        private By ByScheduledLabel { get { return By.XPath("//span[contains(text(), 'Scheduled')]"); } }
        private WebElementWrapper ScheduledLabel { get; set; }
        private By ByInProgressLabel { get { return By.XPath("//span[contains(text(), 'In Progress')]"); } }
        private WebElementWrapper InProgressLabel { get; set; }
        private By ByCompletedLabel { get { return By.XPath("//span[contains(text(), 'Completed')]"); } }
        private WebElementWrapper CompletedLabel { get; set; }
        private By ByNotSpecifiedLabel { get { return By.XPath("//span[contains(text(), '?')]"); } }
        private WebElementWrapper NotSpecifiedLabel { get; set; }
        private By ByMakePublicButton { get { return By.Id(ControlPrefix + "ButtonNextStage"); } }
        private WebElementWrapper MakePublicButton { get; set; }
        private By ByReadyToScheduleButton { get { return By.Id(ControlPrefix + "ButtonNextStage"); } }
        private WebElementWrapper ReadyToScheduleButton { get; set; }
        private By ByScheduleButton { get { return By.Id(ControlPrefix + "ButtonNextStage"); } }
        private WebElementWrapper ScheduleButton { get; set; }

        /// <summary>
        /// make the test public
        /// </summary>
        public void MakePublic()
        {
            TestStage = TestStage.PublicDraft;
            MakePublicButton.Click();
        }
        /// <summary>
        /// ready to schedule the test
        /// </summary>
        public void ReadyToSchedule()
        {
            TestStage = TestStage.ReadyToSchedule;
            ReadyToScheduleButton.Click();
        }
        /// <summary>
        /// schedule the test
        /// </summary>
        public void Schedule()
        {
            TestStage = TestStage.Scheduled;
            ScheduleButton.Click();
        }
        /// <summary>
        /// is the stage private draft?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsStagePrivateDraft()
        {
            bool isHighlighted = false;
            PrivateDraftLabel.Wait(3);
            PrivateDraftLabel.FakeAttributeClass = "label-warning";
            string attr = PrivateDraftLabel.GetAttribute("class");
            if ((attr.Contains("label-warning")) || (attr.Contains("label-info")))
            {
                TestStage = TestStage.PrivateDraft;
                isHighlighted = true;
            }
            return isHighlighted;
        }
        /// <summary>
        /// is the stage public draft?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsStagePublicDraft()
        {
            bool isHighlighted = false;
            PublicDraftLabel.Wait(3);
            PublicDraftLabel.FakeAttributeClass = "label-warning";
            string attr = PublicDraftLabel.GetAttribute("class");
            if ((attr.Contains("label-warning")) || (attr.Contains("label-info")))
            {
                TestStage = TestStage.PublicDraft;
                isHighlighted = true;
            }
            return isHighlighted;
        }
        /// <summary>
        /// is the stage ready to schedule?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsStageReadyToSchedule()
        {
            bool isHighlighted = false;
            ReadyToScheduleLabel.Wait(3);
            ReadyToScheduleLabel.FakeAttributeClass = "label-warning";
            string attr = ReadyToScheduleLabel.GetAttribute("class");
            if ((attr.Contains("label-warning")) || (attr.Contains("label-info")))
            {
                TestStage = TestStage.ReadyToSchedule;
                isHighlighted = true;
            }
            return isHighlighted;
        }
        /// <summary>
        /// is the stage scheduled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsStageScheduled()
        {
            bool isHighlighted = false;
            ScheduledLabel.Wait(3);
            ScheduledLabel.FakeAttributeClass = "label-warning";
            string attr = ScheduledLabel.GetAttribute("class");
            if ((attr.Contains("label-warning")) || (attr.Contains("label-info")))
            {
                TestStage = TestStage.Scheduled;
                isHighlighted = true;
            }
            return isHighlighted;
        }
        /// <summary>
        /// is the stage in progress?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsStageInProgress()
        {
            bool isHighlighted = false;
            InProgressLabel.Wait(3);
            InProgressLabel.FakeAttributeClass = "label-warning";
            string attr = InProgressLabel.GetAttribute("class");
            if ((attr.Contains("label-warning")) || (attr.Contains("label-info")))
            {
                TestStage = TestStage.InProgress;
                isHighlighted = true;
            }
            return isHighlighted;
        }
        /// <summary>
        /// is the stage completed draft?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsStageCompletedDraft()
        {
            bool isHighlighted = false;
            CompletedLabel.Wait(3);
            CompletedLabel.FakeAttributeClass = "label-warning";
            string attr = CompletedLabel.GetAttribute("class");
            if ((attr.Contains("label-warning")) || (attr.Contains("label-info")))
            {
                TestStage = TestStage.Completed;
                isHighlighted = true;
            }
            return isHighlighted;
        }
        /// <summary>
        /// is the stage not specified?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsStageNotSpecified()
        {
            bool isHighlighted = false;
            NotSpecifiedLabel.Wait(3);
            NotSpecifiedLabel.FakeAttributeClass = "label-warning";
            string attr = NotSpecifiedLabel.GetAttribute("class");
            if ((attr.Contains("label-warning")) || (attr.Contains("label-info")))
            {
                TestStage = TestStage.NotSpecified;
                isHighlighted = true;
            }
            return isHighlighted;
        }
    }
}
