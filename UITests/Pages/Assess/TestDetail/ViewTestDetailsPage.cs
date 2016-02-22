using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages.Components;
using UITests.Pages.Assess.Components;
using UITests.Pages.Assess.ItemCreateEdit.v01;
using UITests.Pages.Assess.Schedule;
using UITests.Pages.Assess.TestDetail.Components;
using UITests.Pages.Assess.TestDetail.ViewTestDetails;

namespace UITests.Pages.Assess.TestDetail
{
    /// <summary>
    /// the view test details page
    /// </summary>
    public class ViewTestDetailsPage : SNWebPage
    {
        /// <summary>
        /// constrcutor
        /// </summary>
        /// <param name="testStage">the test stage, default to "Not Specified"</param>
        public ViewTestDetailsPage(TestStage testStage = TestStage.NotSpecified)
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            this.ExpectedUrl = "Assess/ViewTestDetails.aspx";
            this.VerifyCurrentUrl();
            this.testStage = testStage;
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            this.Side = new ViewTestDetailsSideBar( this.testStage, ControlPrefix);
            this.Side.Parent = this;
            this.Detail = new ViewTestDetailsDetail( ControlPrefix);
            this.Detail.Parent = this;
            this.Form = new ViewTestDetailsForm( ControlPrefix);
            this.Form.Parent = this;

            TestStages = new TestStages(PageNames.ViewTestDetails, ControlPrefix);
            if (this.testStage != TestStage.NotSpecified)
            {
                TestStages.TestStage = this.testStage;
                if (Data == null)
                {
                    this.InitData();
                }
            }

            AddItemsToItemCentral = new WebElementWrapper(ByAddItemsToItemCentral);
        }
        /// <summary>
        /// the side bar
        /// </summary>
        public new ViewTestDetailsSideBar Side { get; private set; }
        /// <summary>
        /// the detail
        /// </summary>
        public new ViewTestDetailsDetail Detail { get; private set; }
        /// <summary>
        /// the form
        /// </summary>
        public ViewTestDetailsForm Form { get; private set; }

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
                this.Side.Data = value;
                this.Detail.Data = value;
                this.Form.Data = value;
                if (this.testStage != TestStage.NotSpecified)
                {
                    ((ViewTestDetailsData)base.Data).TestStage = this.testStage;
                    this.Side.Data.TestStage = this.testStage;
                    this.Detail.Data.TestStage = this.testStage;
                    this.Form.Data.TestStage = this.testStage;
                }
            }
        }
        /// <summary>
        /// intializes the data
        /// </summary>
        /// <returns>object data</returns>
        public new ViewTestDetailsData InitData()
        {
            base.InitData(new ViewTestDetailsData());
            return (ViewTestDetailsData)base.Data;
        }
        /// <summary>
        /// initializes the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>object data</returns>
        public ViewTestDetailsData InitData(object data)
        {
            base.InitData(data);
            return (ViewTestDetailsData)base.Data;
        }

        private TestStage testStage { get; set; }
        private TestStages TestStages { get; set; }
        private By ByAddItemsToItemCentral { get { return By.Id(ControlPrefix + "ButtonAddToItemCentral"); } }
        private WebElementWrapper AddItemsToItemCentral { get; set; }

        private void ReloadThePage()
        {
            this.Side = null;
            this.Detail = null;
            this.Form = null;
            this.VerifyCurrentUrl();
            this.Side = new ViewTestDetailsSideBar(TestStages.TestStage, ControlPrefix);
            this.Detail = new ViewTestDetailsDetail( ControlPrefix);
            this.Form = new ViewTestDetailsForm( ControlPrefix);
            this.Side.Data = Data;
            this.Detail.Data = Data;
            this.Form.Data = Data;
        }

        /// <summary>
        /// add all items to item central
        /// </summary>
        /// <returns>EditItemAvailabilityPage</returns>
        public EditItemAvailabilityPage AddAllItemsToItemCentral()
        {
            AddItemsToItemCentral.Click();
            return new EditItemAvailabilityPage();
        }
        /// <summary>
        /// make the test public
        /// </summary>
        /// <returns>ViewTestDetailsPage</returns>
        public ViewTestDetailsPage MakePublic()
        {
            TestStages.MakePublic();
            //wait a second for the event to catch up
            // (getting stale element reference on page reload - after waiting for page to load)
            Thread.Sleep(TimeSpan.FromSeconds(1));
            DriverCommands.WaitAndMeasurePageLoadTime(90, 30);
            //return new ViewTestDetailsPage(Driver, TestStage.PublicDraft);
            Data.TestStage = TestStage.PublicDraft;
            ReloadThePage();
            return this;
        }
        /// <summary>
        /// ready to schedule the test
        /// </summary>
        /// <returns>ViewTestDetailsPage</returns>
        public ViewTestDetailsPage ReadyToSchedule()
        {
            this.CurrentWindowHandle = Driver.CurrentWindowHandle;
            Report.Write("The current window is: '" + this.CurrentWindowHandle + "'.");

            TestStages.ReadyToSchedule();
            //Driver.AcceptAlert();

            AlertHandler alert = new AlertHandler();
            alert.VerifyText("Are you sure you are ready to schedule the test?");
            alert.VerifyText("You will no longer be able to make changes to the test.");
            alert.VerifyText("Do you want to proceed?");
            alert.Accept();

            //switch to window
            DriverCommands.WaitToSwitchWindow(this.CurrentWindowHandle, 5);

            DriverCommands.WaitAndMeasurePageLoadTime();
            //return new ViewTestDetailsPage( TestStage.ReadyToSchedule);
            Data.TestStage = TestStage.ReadyToSchedule;
            ReloadThePage();
            return this;
        }
        /// <summary>
        /// schedule the test
        /// </summary>
        /// <returns>EditSchedulePage</returns>
        public EditSchedulePage Schedule()
        {
            TestStages.Schedule();
            //TODO: need to add test stage to edit schedule page - will need Santosh guidance on this
            //return new EditSchedulePage(Driver, TestStage.ReadyToSchedule);
            Data.TestStage = TestStage.Scheduled;
            return new EditSchedulePage();
        }
        /// <summary>
        /// is the stage private draft?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsStagePrivateDraft()
        {
            return TestStages.IsStagePrivateDraft();
        }
        /// <summary>
        /// is the stage public draft?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsStagePublicDraft()
        {
            return TestStages.IsStagePublicDraft();
        }
        /// <summary>
        /// is the stage ready to schedule?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsStageReadyToSchedule()
        {
            return TestStages.IsStageReadyToSchedule();
        }
        /// <summary>
        /// is the stage scheduled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsStageScheduled()
        {
            return TestStages.IsStageScheduled();
        }
        /// <summary>
        /// is the stage in progress?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsStageInProgress()
        {
            return TestStages.IsStageInProgress();
        }
        /// <summary>
        /// is the stage completed draft?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsStageCompletedDraft()
        {
            return TestStages.IsStageCompletedDraft();
        }
        /// <summary>
        /// is the stage not specified?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsStageNotSpecified()
        {
            return TestStages.IsStageNotSpecified();
        }
    }
}
