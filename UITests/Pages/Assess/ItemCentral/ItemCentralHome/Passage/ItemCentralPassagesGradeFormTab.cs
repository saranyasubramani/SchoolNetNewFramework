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
    /// item central: passages tab: grade form tab
    /// </summary>
    public class ItemCentralPassagesGradeFormTab : ItemCentralFormTab
    {
        /// <summary>
        /// constructor
        /// </summary>
        public ItemCentralPassagesGradeFormTab()
            : base()
        {
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            GradeLink = new WebElementWrapper(ByGradeLink);
            FromInfantOption = new WebElementWrapper(ByFromInfantOption);
            FromKindergartenOption = new WebElementWrapper(ByFromKindergartenOption);
            FromGradeOneOption = new WebElementWrapper(ByFromGradeOneOption);
            FromGradeTwoOption = new WebElementWrapper(ByFromGradeTwoOption);
            FromGradeThreeOption = new WebElementWrapper(ByFromGradeThreeOption);
            FromGradeFourOption = new WebElementWrapper(ByFromGradeFourOption);
            FromGradeFiveOption = new WebElementWrapper(ByFromGradeFiveOption);
            FromGradeSixOption = new WebElementWrapper(ByFromGradeSixOption);
            FromGradeSevenOption = new WebElementWrapper(ByFromGradeSevenOption);
            FromGradeEightOption = new WebElementWrapper(ByFromGradeEightOption);
            FromGradeNineOption = new WebElementWrapper(ByFromGradeNineOption);
            FromGradeTenOption = new WebElementWrapper(ByFromGradeTenOption);
            FromGradeElevenOption = new WebElementWrapper(ByFromGradeElevenOption);
            FromGradeTwelveOption = new WebElementWrapper(ByFromGradeTwelveOption);
            ToInfantOption = new WebElementWrapper(ByToInfantOption);
            ToKindergartenOption = new WebElementWrapper(ByToKindergartenOption);
            ToGradeOneOption = new WebElementWrapper(ByToGradeOneOption);
            ToGradeTwoOption = new WebElementWrapper(ByToGradeTwoOption);
            ToGradeThreeOption = new WebElementWrapper(ByToGradeThreeOption);
            ToGradeFourOption = new WebElementWrapper(ByToGradeFourOption);
            ToGradeFiveOption = new WebElementWrapper(ByToGradeFiveOption);
            ToGradeSixOption = new WebElementWrapper(ByToGradeSixOption);
            ToGradeSevenOption = new WebElementWrapper(ByToGradeSevenOption);
            ToGradeEightOption = new WebElementWrapper(ByToGradeEightOption);
            ToGradeNineOption = new WebElementWrapper(ByToGradeNineOption);
            ToGradeTenOption = new WebElementWrapper(ByToGradeTenOption);
            ToGradeElevenOption = new WebElementWrapper(ByToGradeElevenOption);
            ToGradeTwelveOption = new WebElementWrapper(ByToGradeTwelveOption);
        }

        //ctl00_MainContent_RepeaterBrowseCategories_ctl02_LinkButtonBrowseCategory
        private By ByGradeLink { get { return By.Id(ControlPrefix + "RepeaterBrowseCategories_ctl02_LinkButtonBrowseCategory"); } }
        private WebElementWrapper GradeLink { get; set; }
        //ctl00_MainContent_RepeaterLowGrade_ctl00_RadioButtonGrade
        private By ByFromInfantOption { get { return By.Id(ControlPrefix + "RepeaterLowGrade_ctl00_RadioButtonGrade"); } }
        private WebElementWrapper FromInfantOption { get; set; }
        private By ByFromKindergartenOption { get { return By.Id(ControlPrefix + "RepeaterLowGrade_ctl02_RadioButtonGrade"); } }
        private WebElementWrapper FromKindergartenOption { get; set; }
        private By ByFromGradeOneOption { get { return By.Id(ControlPrefix + "RepeaterLowGrade_ctl03_RadioButtonGrade"); } }
        private WebElementWrapper FromGradeOneOption { get; set; }
        private By ByFromGradeTwoOption { get { return By.Id(ControlPrefix + "RepeaterLowGrade_ctl04_RadioButtonGrade"); } }
        private WebElementWrapper FromGradeTwoOption { get; set; }
        private By ByFromGradeThreeOption { get { return By.Id(ControlPrefix + "RepeaterLowGrade_ctl05_RadioButtonGrade"); } }
        private WebElementWrapper FromGradeThreeOption { get; set; }
        private By ByFromGradeFourOption { get { return By.Id(ControlPrefix + "RepeaterLowGrade_ctl06_RadioButtonGrade"); } }
        private WebElementWrapper FromGradeFourOption { get; set; }
        private By ByFromGradeFiveOption { get { return By.Id(ControlPrefix + "RepeaterLowGrade_ctl07_RadioButtonGrade"); } }
        private WebElementWrapper FromGradeFiveOption { get; set; }
        private By ByFromGradeSixOption { get { return By.Id(ControlPrefix + "RepeaterLowGrade_ctl08_RadioButtonGrade"); } }
        private WebElementWrapper FromGradeSixOption { get; set; }
        private By ByFromGradeSevenOption { get { return By.Id(ControlPrefix + "RepeaterLowGrade_ctl09_RadioButtonGrade"); } }
        private WebElementWrapper FromGradeSevenOption { get; set; }
        private By ByFromGradeEightOption { get { return By.Id(ControlPrefix + "RepeaterLowGrade_ctl10_RadioButtonGrade"); } }
        private WebElementWrapper FromGradeEightOption { get; set; }
        private By ByFromGradeNineOption { get { return By.Id(ControlPrefix + "RepeaterLowGrade_ctl11_RadioButtonGrade"); } }
        private WebElementWrapper FromGradeNineOption { get; set; }
        private By ByFromGradeTenOption { get { return By.Id(ControlPrefix + "RepeaterLowGrade_ctl12_RadioButtonGrade"); } }
        private WebElementWrapper FromGradeTenOption { get; set; }
        private By ByFromGradeElevenOption { get { return By.Id(ControlPrefix + "RepeaterLowGrade_ctl13_RadioButtonGrade"); } }
        private WebElementWrapper FromGradeElevenOption { get; set; }
        private By ByFromGradeTwelveOption { get { return By.Id(ControlPrefix + "RepeaterLowGrade_ctl14_RadioButtonGrade"); } }
        private WebElementWrapper FromGradeTwelveOption { get; set; }
        //ctl00_MainContent_RepeaterHighGrade_ctl00_RadioButtonGrade
        private By ByToInfantOption { get { return By.Id(ControlPrefix + "RepeaterHighGrade_ctl00_RadioButtonGrade"); } }
        private WebElementWrapper ToInfantOption { get; set; }
        private By ByToKindergartenOption { get { return By.Id(ControlPrefix + "RepeaterHighGrade_ctl02_RadioButtonGrade"); } }
        private WebElementWrapper ToKindergartenOption { get; set; }
        private By ByToGradeOneOption { get { return By.Id(ControlPrefix + "RepeaterHighGrade_ctl03_RadioButtonGrade"); } }
        private WebElementWrapper ToGradeOneOption { get; set; }
        private By ByToGradeTwoOption { get { return By.Id(ControlPrefix + "RepeaterHighGrade_ctl04_RadioButtonGrade"); } }
        private WebElementWrapper ToGradeTwoOption { get; set; }
        private By ByToGradeThreeOption { get { return By.Id(ControlPrefix + "RepeaterHighGrade_ctl05_RadioButtonGrade"); } }
        private WebElementWrapper ToGradeThreeOption { get; set; }
        private By ByToGradeFourOption { get { return By.Id(ControlPrefix + "RepeaterHighGrade_ctl06_RadioButtonGrade"); } }
        private WebElementWrapper ToGradeFourOption { get; set; }
        private By ByToGradeFiveOption { get { return By.Id(ControlPrefix + "RepeaterHighGrade_ctl07_RadioButtonGrade"); } }
        private WebElementWrapper ToGradeFiveOption { get; set; }
        private By ByToGradeSixOption { get { return By.Id(ControlPrefix + "RepeaterHighGrade_ctl08_RadioButtonGrade"); } }
        private WebElementWrapper ToGradeSixOption { get; set; }
        private By ByToGradeSevenOption { get { return By.Id(ControlPrefix + "RepeaterHighGrade_ctl09_RadioButtonGrade"); } }
        private WebElementWrapper ToGradeSevenOption { get; set; }
        private By ByToGradeEightOption { get { return By.Id(ControlPrefix + "RepeaterHighGrade_ctl10_RadioButtonGrade"); } }
        private WebElementWrapper ToGradeEightOption { get; set; }
        private By ByToGradeNineOption { get { return By.Id(ControlPrefix + "RepeaterHighGrade_ctl11_RadioButtonGrade"); } }
        private WebElementWrapper ToGradeNineOption { get; set; }
        private By ByToGradeTenOption { get { return By.Id(ControlPrefix + "RepeaterHighGrade_ctl12_RadioButtonGrade"); } }
        private WebElementWrapper ToGradeTenOption { get; set; }
        private By ByToGradeElevenOption { get { return By.Id(ControlPrefix + "RepeaterHighGrade_ctl13_RadioButtonGrade"); } }
        private WebElementWrapper ToGradeElevenOption { get; set; }
        private By ByToGradeTwelveOption { get { return By.Id(ControlPrefix + "RepeaterHighGrade_ctl14_RadioButtonGrade"); } }
        private WebElementWrapper ToGradeTwelveOption { get; set; }

        /// <summary>
        /// grade
        /// </summary>
        public void SelectGrade()
        {
            GradeLink.Wait(3).Click();
        }
        /// <summary>
        /// from infant option
        /// </summary>
        public void SelectFromInfantOption()
        {
            FromInfantOption.Wait(3).Click();
        }
        /// <summary>
        /// from kindergarten option
        /// </summary>
        public void SelectFromKindergartenOption()
        {
            FromKindergartenOption.Wait(3).Click();
        }
        /// <summary>
        /// from grade one option
        /// </summary>
        public void SelectFromGradeOneOption()
        {
            FromGradeOneOption.Wait(3).Click();
        }
        /// <summary>
        /// from grade two option
        /// </summary>
        public void SelectFromGradeTwoOption()
        {
            FromGradeTwoOption.Wait(3).Click();
        }
        /// <summary>
        /// from grade three option
        /// </summary>
        public void SelectFromGradeThreeOption()
        {
            FromGradeThreeOption.Wait(3).Click();
        }
        /// <summary>
        /// from grade four option
        /// </summary>
        public void SelectFromGradeFourOption()
        {
            FromGradeFourOption.Wait(3).Click();
        }
        /// <summary>
        /// from grade five option
        /// </summary>
        public void SelectFromGradeFiveOption()
        {
            FromGradeFiveOption.Wait(3).Click();
        }
        /// <summary>
        /// from grade six option
        /// </summary>
        public void SelectFromGradeSixOption()
        {
            FromGradeSixOption.Wait(3).Click();
        }
        /// <summary>
        /// from grade seven option
        /// </summary>
        public void SelectFromGradeSevenOption()
        {
            FromGradeSevenOption.Wait(3).Click();
        }
        /// <summary>
        /// from grade eight option
        /// </summary>
        public void SelectFromGradeEightOption()
        {
            FromGradeEightOption.Wait(3).Click();
        }
        /// <summary>
        /// from grade nine option
        /// </summary>
        public void SelectFromGradeNineOption()
        {
            FromGradeNineOption.Wait(3).Click();
        }
        /// <summary>
        /// from grade ten option
        /// </summary>
        public void SelectFromGradeTenOption()
        {
            FromGradeTenOption.Wait(3).Click();
        }
        /// <summary>
        /// from grade eleven option
        /// </summary>
        public void SelectFromGradeElevenOption()
        {
            FromGradeElevenOption.Wait(3).Click();
        }
        /// <summary>
        /// from grade twelve option
        /// </summary>
        public void SelectFromGradeTwelveOption()
        {
            FromGradeTwelveOption.Wait(3).Click();
        }
        /// <summary>
        /// to infant option
        /// </summary>
        public void SelectToInfantOption()
        {
            ToInfantOption.Wait(3).Click();
        }
        /// <summary>
        /// to kindergarten option
        /// </summary>
        public void SelectToKindergartenOption()
        {
            ToKindergartenOption.Wait(3).Click();
        }
        /// <summary>
        /// to grade one option
        /// </summary>
        public void SelectToGradeOneOption()
        {
            ToGradeOneOption.Wait(3).Click();
        }
        /// <summary>
        /// to grade two option
        /// </summary>
        public void SelectToGradeTwoOption()
        {
            ToGradeTwoOption.Wait(3).Click();
        }
        /// <summary>
        /// to grade three option
        /// </summary>
        public void SelectToGradeThreeOption()
        {
            ToGradeThreeOption.Wait(3).Click();
        }
        /// <summary>
        /// to grade four option
        /// </summary>
        public void SelectToGradeFourOption()
        {
            ToGradeFourOption.Wait(3).Click();
        }
        /// <summary>
        /// to grade five option
        /// </summary>
        public void SelectToGradeFiveOption()
        {
            ToGradeFiveOption.Wait(3).Click();
        }
        /// <summary>
        /// to grade six option
        /// </summary>
        public void SelectToGradeSixOption()
        {
            ToGradeSixOption.Wait(3).Click();
        }
        /// <summary>
        /// to grade seven option
        /// </summary>
        public void SelectToGradeSevenOption()
        {
            ToGradeSevenOption.Wait(3).Click();
        }
        /// <summary>
        /// to grade eight option
        /// </summary>
        public void SelectToGradeEightOption()
        {
            ToGradeEightOption.Wait(3).Click();
        }
        /// <summary>
        /// to grade nine option
        /// </summary>
        public void SelectToGradeNineOption()
        {
            ToGradeNineOption.Wait(3).Click();
        }
        /// <summary>
        /// to grade ten option
        /// </summary>
        public void SelectToGradeTenOption()
        {
            ToGradeTenOption.Wait(3).Click();
        }
        /// <summary>
        /// to grade eleven option
        /// </summary>
        public void SelectToGradeElevenOption()
        {
            ToGradeElevenOption.Wait(3).Click();
        }
        /// <summary>
        /// to grade twelve option
        /// </summary>
        public void SelectToGradeTwelveOption()
        {
            ToGradeTwelveOption.Wait(3).Click();
        }
    }
}
