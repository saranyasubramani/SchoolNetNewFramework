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
    /// share with other user form
    /// </summary>
    public class ShareWithOtherUser : SNForm
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="index">the index</param>
        /// <param name="uniqueId">the unique ID is the control id for the rubric group</param>
        /// <param name="numberOfColumn">the initial number of columns when the group is created.</param>
        public ShareWithOtherUser(PageNames pageName, string overrideControlPrefix = null)
            : base()
        {
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }
            switch (pageName)
            {
                case PageNames.EditItemAvailability:
                    ControlMiddle = "Item";
                    break;
                case PageNames.EditRubricAvailability:
                    ControlMiddle = "Rubric";
                    break;
            }
            InitElements();
        }
        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            OnlyToMeButton = new WebElementWrapper(ByOnlyToMeButton);
            ShareWithOthersButton = new WebElementWrapper(ByShareWithOthersButton);
            DistrictItemAdminsOnlyButton = new WebElementWrapper(ByDistrictItemAdminsOnlyButton);
            DistrictAndRegionalItemAdminsButton = new WebElementWrapper(ByDistrictAndRegionalItemAdminsButton);
            DistrictRegionalAndSchoolItemAdminsButton = new WebElementWrapper(ByDistrictRegionalAndSchoolItemAdminsButton);
            EveryoneButton = new WebElementWrapper(ByEveryoneButton);
            LimitBySchoolLink = new WebElementWrapper(ByLimitBySchoolLink);
            ShareWithCoAuthorsButton = new WebElementWrapper(ByShareWithCoAuthorsButton);
            SearchCoAuthorsNameText = new WebElementWrapper(BySearchCoAuthorsNameText);
            SearchCoAuthorsRemoveButton = new WebElementWrapper(BySearchCoAuthorsRemoveButton);
            ViewOnlyButton = new WebElementWrapper(ByViewOnlyButton);
        }

        /// <summary>
        /// the data
        /// </summary>
        public new SharingItemData Data
        {
            get
            {
                return (SharingItemData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        private string ControlMiddle = "";
        //15.3
        //private By ByOnlyToMeButton { get { return By.Id(ControlPrefix + "ItemSharingControl_RadioButtonLevel0"); } }
        //15.4
        private By ByOnlyToMeButton { get { return By.Id(ControlPrefix + ControlMiddle + "SharingControl_rboLevel0"); } }
        private WebElementWrapper OnlyToMeButton { get; set; }
        //15.3
        //private By ByShareWithOthersButton { get { return By.Id(ControlPrefix + "ItemSharingControl_RadioButtonShare"); } }
        //15.4
        private By ByShareWithOthersButton { get { return By.Id(ControlPrefix + ControlMiddle + "SharingControl_rboShare"); } }
        private WebElementWrapper ShareWithOthersButton { get; set; }
        //15.3
        //private By ByDistrictItemAdminsOnlyButton { get { return By.Id(ControlPrefix + "ItemSharingControl_RadioButtonLevel1"); } }
        //15.4
        private By ByDistrictItemAdminsOnlyButton { get { return By.Id(ControlPrefix + ControlMiddle + "SharingControl_rboLevel1"); } }
        private WebElementWrapper DistrictItemAdminsOnlyButton { get; set; }
        //15.3
        //private By ByDistrictAndRegionalItemAdminsButton { get { return By.Id(ControlPrefix + "ItemSharingControl_RadioButtonLevel2"); } }
        //15.4
        private By ByDistrictAndRegionalItemAdminsButton { get { return By.Id(ControlPrefix + ControlMiddle + "SharingControl_rboLevel2"); } }
        private WebElementWrapper DistrictAndRegionalItemAdminsButton { get; set; }
        //15.3
        //private By ByDistrictRegionalAndSchoolItemAdminsButton { get { return By.Id(ControlPrefix + "ItemSharingControl_RadioButtonLevel3"); } }
        //15.4
        private By ByDistrictRegionalAndSchoolItemAdminsButton { get { return By.Id(ControlPrefix + ControlMiddle + "SharingControl_rboLevel3"); } }
        private WebElementWrapper DistrictRegionalAndSchoolItemAdminsButton { get; set; }
        //15.3
        //private By ByEveryoneButton { get { return By.Id(ControlPrefix + "ItemSharingControl_RadioButtonLevel4"); } }
        //15.4
        private By ByEveryoneButton { get { return By.Id(ControlPrefix + ControlMiddle + "SharingControl_rboLevel4"); } }
        private WebElementWrapper EveryoneButton { get; set; }
        private By ByLimitBySchoolLink { get { return By.Id(ControlPrefix + ControlMiddle + "SharingControl_anchorButtonSchools"); } }
        private WebElementWrapper LimitBySchoolLink { get; set; }
        //TODO add limit by school fields
        private By ByShareWithCoAuthorsButton { get { return By.Id(ControlPrefix + ControlMiddle + "SharingControl_rboEnable"); } }
        //private By ByShareWithCoAuthorsButton { get { return By.Id(ControlPrefix + "ItemSharingControl_RadioButtonEnable"); } }
        private WebElementWrapper ShareWithCoAuthorsButton { get; set; }
        private By BySearchCoAuthorsNameText { get { return By.Id(ControlPrefix + ControlMiddle + "SharingControl_txtSearchBox"); } }
        private WebElementWrapper SearchCoAuthorsNameText { get; set; }
        private By BySearchCoAuthorsRemoveButton { get { return By.Id(ControlPrefix + ControlMiddle + "SharingControl_gvViewNames_ctl02_lnkButtonName"); } }
        private WebElementWrapper SearchCoAuthorsRemoveButton { get; set; }
        private By ByViewOnlyButton { get { return By.Id(ControlPrefix + ControlMiddle + "SharingControl_gvViewNames_ctl02_chkView"); } }
        private WebElementWrapper ViewOnlyButton { get; set; }

        /// <summary>
        /// only to me
        /// </summary>
        public void SelectOnlyToMe()
        {
            OnlyToMeButton.Wait(5).Click();
        }
        /// <summary>
        /// share with others
        /// </summary>
        public void SelectShareWithOthers()
        {
            ShareWithOthersButton.Wait(5).Click();
        }
        /// <summary>
        /// district item admins only
        /// </summary>
        public void SelectDistrictItemAdminsOnly()
        {
            DistrictItemAdminsOnlyButton.Wait(5).Click();
        }
        /// <summary>
        /// district and regional item admins
        /// </summary>
        public void SelectDistrictAndRegionalItemAdmins()
        {
            DistrictAndRegionalItemAdminsButton.Wait(5).Click();
        }
        /// <summary>
        /// district regional and school item admins
        /// </summary>
        public void SelectDistrictRegionalAndSchoolItemAdmins()
        {
            DistrictRegionalAndSchoolItemAdminsButton.Wait(5).Click();
        }
        /// <summary>
        /// everyone
        /// </summary>
        public void SelectEveryone()
        {
            EveryoneButton.Wait(5).Click();
        }
        /// <summary>
        /// limit by school
        /// </summary>
        public void SelectLimitBySchool()
        {
            LimitBySchoolLink.Wait(5).Click();
        }
        /// <summary>
        /// share with co-authors
        /// </summary>
        public void SelectShareWithCoAuthors()
        {
            ShareWithCoAuthorsButton.Wait(5).Click();
        }
        /// <summary>
        /// co-authors by name
        /// </summary>
        public void SearchCoAuthorsByName()
        {
            SearchCoAuthorsNameText.Wait(5).SendKeys(Data.SearchName);
        }
        /// <summary>
        /// remove co-authors
        /// </summary>
        public void SelectRemoveCoAuthors()
        {
            SearchCoAuthorsRemoveButton.Wait(5).Click();
        }
        /// <summary>
        /// view only
        /// </summary>
        public void SelectViewOnly()
        {
            ViewOnlyButton.Wait(5).Click();
        }

        //implemented methods
        public override void InputFormFields()
        {
            SelectShareWithOthers();
            DriverCommands.WaitAndMeasurePageLoadTime(90, 30);
            InitElements();
            SelectEveryone();
        }
    }
}
