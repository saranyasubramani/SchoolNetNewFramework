using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;

namespace UITests.Pages.Assess.ItemCentral.ItemCentralHome.Passage
{
    /// <summary>
    /// item central: passages tab: subject form tab
    /// </summary>
    public class ItemCentralPassagesSubjectFormTab : ItemCentralFormTab
    {
        /// <summary>
        /// constructor
        /// </summary>
        public ItemCentralPassagesSubjectFormTab()
            : base()
        {
            InitElements();
        }
        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            SubjectLink = new WebElementWrapper(BySubjectLink);
            DraftingOption = new WebElementWrapper(ByDraftingOption);
            FineArtsOption = new WebElementWrapper(ByFineArtsOption);
            EnergyOption = new WebElementWrapper(ByEnergyOption);
            VocationalOption = new WebElementWrapper(ByVocationalOption);
            ConsumerOption = new WebElementWrapper(ByConsumerOption);
            MilitaryOption = new WebElementWrapper(ByMilitaryOption);
            AgricultureOption = new WebElementWrapper(ByAgricultureOption);
            ConstructionOption = new WebElementWrapper(ByConstructionOption);
            BusinessOption = new WebElementWrapper(ByBusinessOption);
            EnglishOption = new WebElementWrapper(ByEnglishOption);
            LiteratureOption = new WebElementWrapper(ByLiteratureOption);
            SocialScienceOption = new WebElementWrapper(BySocialScienceOption);
            IndustrialOption = new WebElementWrapper(ByIndustrialOption);
            LifeScienceOption = new WebElementWrapper(ByLifeScienceOption);
            ReligiousOption = new WebElementWrapper(ByReligiousOption);
            CosmetologyOption = new WebElementWrapper(ByCosmetologyOption);
            MathematicsOption = new WebElementWrapper(ByMathematicsOption);
            ComputerOption = new WebElementWrapper(ByComputerOption);
            CommunicationOption = new WebElementWrapper(ByCommunicationOption);
            MarketingOption = new WebElementWrapper(ByMarketingOption);
        }

        private By BySubjectLink { get { return By.Id(ControlPrefix + "RepeaterBrowseCategories_ctl01_LinkButtonBrowseCategory"); } }
        private WebElementWrapper SubjectLink { get; set; }
        //ctl00_MainContent_DataListSubjects_ctl01_RadioButtonSubject
        private By ByDraftingOption { get { return By.Id(ControlPrefix + "DataListSubjects_ctl01_RadioButtonSubject"); } }
        private WebElementWrapper DraftingOption { get; set; }
        //ctl00_MainContent_DataListSubjects_ctl11_RadioButtonSubject
        private By ByFineArtsOption { get { return By.Id(ControlPrefix + "DataListSubjects_ctl11_RadioButtonSubject"); } }
        private WebElementWrapper FineArtsOption { get; set; }
        private By ByEnergyOption { get { return By.Id(ControlPrefix + "DataListSubjects_ctl02_RadioButtonSubject"); } }
        private WebElementWrapper EnergyOption { get; set; }
        private By ByVocationalOption { get { return By.Id(ControlPrefix + "DataListSubjects_ctl12_RadioButtonSubject"); } }
        private WebElementWrapper VocationalOption { get; set; }
        private By ByConsumerOption { get { return By.Id(ControlPrefix + "DataListSubjects_ctl03_RadioButtonSubject"); } }
        private WebElementWrapper ConsumerOption { get; set; }
        private By ByMilitaryOption { get { return By.Id(ControlPrefix + "DataListSubjects_ctl13_RadioButtonSubject"); } }
        private WebElementWrapper MilitaryOption { get; set; }
        private By ByAgricultureOption { get { return By.Id(ControlPrefix + "DataListSubjects_ctl04_RadioButtonSubject"); } }
        private WebElementWrapper AgricultureOption { get; set; }
        private By ByConstructionOption { get { return By.Id(ControlPrefix + "DataListSubjects_ctl14_RadioButtonSubject"); } }
        private WebElementWrapper ConstructionOption { get; set; }
        private By ByBusinessOption { get { return By.Id(ControlPrefix + "DataListSubjects_ctl05_RadioButtonSubject"); } }
        private WebElementWrapper BusinessOption { get; set; }
        private By ByEnglishOption { get { return By.Id(ControlPrefix + "DataListSubjects_ctl15_RadioButtonSubject"); } }
        private WebElementWrapper EnglishOption { get; set; }
        private By ByLiteratureOption { get { return By.Id(ControlPrefix + "DataListSubjects_ctl06_RadioButtonSubject"); } }
        private WebElementWrapper LiteratureOption { get; set; }
        private By BySocialScienceOption { get { return By.Id(ControlPrefix + "DataListSubjects_ctl16_RadioButtonSubject"); } }
        private WebElementWrapper SocialScienceOption { get; set; }
        private By ByIndustrialOption { get { return By.Id(ControlPrefix + "DataListSubjects_ctl07_RadioButtonSubject"); } }
        private WebElementWrapper IndustrialOption { get; set; }
        private By ByLifeScienceOption { get { return By.Id(ControlPrefix + "DataListSubjects_ctl17_RadioButtonSubject"); } }
        private WebElementWrapper LifeScienceOption { get; set; }
        private By ByReligiousOption { get { return By.Id(ControlPrefix + "DataListSubjects_ctl08_RadioButtonSubject"); } }
        private WebElementWrapper ReligiousOption { get; set; }
        private By ByCosmetologyOption { get { return By.Id(ControlPrefix + "DataListSubjects_ctl18_RadioButtonSubject"); } }
        private WebElementWrapper CosmetologyOption { get; set; }
        private By ByMathematicsOption { get { return By.Id(ControlPrefix + "DataListSubjects_ctl09_RadioButtonSubject"); } }
        private WebElementWrapper MathematicsOption { get; set; }
        private By ByComputerOption { get { return By.Id(ControlPrefix + "DataListSubjects_ctl19_RadioButtonSubject"); } }
        private WebElementWrapper ComputerOption { get; set; }
        private By ByCommunicationOption { get { return By.Id(ControlPrefix + "DataListSubjects_ctl10_RadioButtonSubject"); } }
        private WebElementWrapper CommunicationOption { get; set; }
        private By ByMarketingOption { get { return By.Id(ControlPrefix + "DataListSubjects_ctl20_RadioButtonSubject"); } }
        private WebElementWrapper MarketingOption { get; set; }

        /// <summary>
        /// subject
        /// </summary>
        public void SelectSubject()
        {
            SubjectLink.Wait(3).Click();
        }
        /// <summary>
        /// drafting option
        /// </summary>
        public void SelectDraftingOption()
        {
            DraftingOption.Wait(3).Click();
        }
        /// <summary>
        /// fine arts option
        /// </summary>
        public void SelectFineArtsOption()
        {
            FineArtsOption.Wait(3).Click();
        }
        /// <summary>
        /// energy option
        /// </summary>
        public void SelectEnergyOption()
        {
            EnergyOption.Wait(3).Click();
        }
        /// <summary>
        /// vocational option
        /// </summary>
        public void SelectVocationalOption()
        {
            VocationalOption.Wait(3).Click();
        }
        /// <summary>
        /// consumer option
        /// </summary>
        public void SelectConsumerOption()
        {
            ConsumerOption.Wait(3).Click();
        }
        /// <summary>
        /// military option
        /// </summary>
        public void SelectMilitaryOption()
        {
            MilitaryOption.Wait(3).Click();
        }
        /// <summary>
        /// agriculture option
        /// </summary>
        public void SelectAgricultureOption()
        {
            AgricultureOption.Wait(3).Click();
        }
        /// <summary>
        /// construction option
        /// </summary>
        public void SelectConstructionOption()
        {
            ConstructionOption.Wait(3).Click();
        }
        /// <summary>
        /// business option
        /// </summary>
        public void SelectBusinessOption()
        {
            BusinessOption.Wait(3).Click();
        }
        /// <summary>
        /// english option
        /// </summary>
        public void SelectEnglishOption()
        {
            EnglishOption.Wait(3).Click();
        }
        /// <summary>
        /// literature option
        /// </summary>
        public void SelectLiteratureOption()
        {
            LiteratureOption.Wait(3).Click();
        }
        /// <summary>
        /// social science option
        /// </summary>
        public void SelectSocialScienceOption()
        {
            SocialScienceOption.Wait(3).Click();
        }
        /// <summary>
        /// industrial option
        /// </summary>
        public void SelectIndustrialOption()
        {
            IndustrialOption.Wait(3).Click();
        }
        /// <summary>
        /// life science option
        /// </summary>
        public void SelectLifeScienceOption()
        {
            LifeScienceOption.Wait(3).Click();
        }
        /// <summary>
        /// religious option
        /// </summary>
        public void SelectReligiousOption()
        {
            ReligiousOption.Wait(3).Click();
        }
        /// <summary>
        /// cosmetology option
        /// </summary>
        public void SelectCosmetologyOption()
        {
            CosmetologyOption.Wait(3).Click();
        }
        /// <summary>
        /// mathematics option
        /// </summary>
        public void SelectMathematicsOption()
        {
            MathematicsOption.Wait(3).Click();
        }
        /// <summary>
        /// computer option
        /// </summary>
        public void SelectComputerOption()
        {
            ComputerOption.Wait(3).Click();
        }
        /// <summary>
        /// communication option
        /// </summary>
        public void SelectCommunicationOption()
        {
            CommunicationOption.Wait(3).Click();
        }
        /// <summary>
        /// marketing option
        /// </summary>
        public void SelectMarketingOption()
        {
            MarketingOption.Wait(3).Click();
        }
    }
}
