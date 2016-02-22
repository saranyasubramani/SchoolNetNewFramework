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
    /// the passage properties form
    /// </summary>
    public class PassagePropertiesForm : SNForm
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public PassagePropertiesForm(PageNames pageNames, string overrideControlPrefix = null)
            : base()
        {
            this.PageNames = pageNames;
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            switch (PageNames)
            {
                case PageNames.ItemCentral:
                    //ctl00_MainContent_ItemFinder1_ItemFinderSearch1_PassageFinder_DropDownListTypes
                    ControlMiddle = "ItemFinder1_ItemFinderSearch1_PassageFinder_";
                    break;
            }
            Type = new SelectElementWrapper(new WebElementWrapper(ByType));
            Subject = new SelectElementWrapper(new WebElementWrapper(BySubject));
            FromGrade = new SelectElementWrapper(new WebElementWrapper(ByFromGrade));
            ToGrade = new SelectElementWrapper(new WebElementWrapper(ByToGrade));
            Title = new WebElementWrapper(ByTitle);
            Genre = new WebElementWrapper(ByGenre);
            Topic = new WebElementWrapper(ByTopic);
            Author = new WebElementWrapper(ByAuthor);
            CreatedBy = new SelectElementWrapper(new WebElementWrapper(ByCreatedBy));
            QuestionLanguage = new SelectElementWrapper(new WebElementWrapper(ByQuestionLanguage));
            Publisher = new WebElementWrapper(ByPublisher);
            NumberOfWordsFrom = new WebElementWrapper(ByNumberOfWordsFrom);
            NumberOfWordsTo = new WebElementWrapper(ByNumberOfWordsTo);
        }

        /// <summary>
        /// the data
        /// </summary>
        public new PassagePropertiesData Data
        {
            get
            {
                return (PassagePropertiesData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        private PageNames PageNames { get; set; }
        private string ControlMiddle { get; set; }
        //ctl00_MainContent_ItemFinder1_ItemFinderSearch1_PassageFinder_DropDownListTypes
        private By ByType { get { return By.Id(ControlPrefix + ControlMiddle + "DropDownListTypes"); } }
        private SelectElementWrapper Type { get; set; }
        //ctl00_MainContent_ItemFinder1_ItemFinderSearch1_PassageFinder_TestSubjectSelector_DropDownListSubject
        private By BySubject { get { return By.Id(ControlPrefix + ControlMiddle + "TestSubjectSelector_DropDownListSubject"); } }
        private SelectElementWrapper Subject { get; set; }
        //ctl00_MainContent_ItemFinder1_ItemFinderSearch1_PassageFinder_GradeRangeControl_GradeDropDownLow_DropDownGrade
        private By ByFromGrade { get { return By.Id(ControlPrefix + ControlMiddle + "GradeRangeControl_GradeDropDownLow_DropDownGrade"); } }
        private SelectElementWrapper FromGrade { get; set; }
        //ctl00_MainContent_ItemFinder1_ItemFinderSearch1_PassageFinder_GradeRangeControl_GradeDropDownHigh_DropDownGrade
        private By ByToGrade { get { return By.Id(ControlPrefix + ControlMiddle + "GradeRangeControl_GradeDropDownLow_DropDownGrade"); } }
        private SelectElementWrapper ToGrade { get; set; }
        //ctl00_MainContent_ItemFinder1_ItemFinderSearch1_PassageFinder_TextBoxPassageTitle
        private By ByTitle { get { return By.Id(ControlPrefix + ControlMiddle + "TextBoxPassageTitle"); } }
        private WebElementWrapper Title { get; set; }
        //ctl00_MainContent_ItemFinder1_ItemFinderSearch1_PassageFinder_TextBoxGenre
        private By ByGenre { get { return By.Id(ControlPrefix + ControlMiddle + "TextBoxGenre"); } }
        private WebElementWrapper Genre { get; set; }
        //ctl00_MainContent_ItemFinder1_ItemFinderSearch1_PassageFinder_TextBoxTopic
        private By ByTopic { get { return By.Id(ControlPrefix + ControlMiddle + "TextBoxTopic"); } }
        private WebElementWrapper Topic { get; set; }
        //ctl00_MainContent_ItemFinder1_ItemFinderSearch1_PassageFinder_TextBoxAuthor
        private By ByAuthor { get { return By.Id(ControlPrefix + ControlMiddle + "TextBoxAuthor"); } }
        private WebElementWrapper Author { get; set; }
        //ctl00_MainContent_ItemFinder1_ItemFinderSearch1_PassageFinder_ddlItemAvailability
        private By ByCreatedBy { get { return By.Id(ControlPrefix + ControlMiddle + "ddlItemAvailability"); } }
        private SelectElementWrapper CreatedBy { get; set; }
        //ctl00_MainContent_ItemFinder1_ItemFinderSearch1_PassageFinder_ddlPassageLanguages
        private By ByQuestionLanguage { get { return By.Id(ControlPrefix + ControlMiddle + "ddlPassageLanguages"); } }
        private SelectElementWrapper QuestionLanguage { get; set; }
        //ctl00_MainContent_ItemFinder1_ItemFinderSearch1_PassageFinder_TextBoxPublisher
        private By ByPublisher { get { return By.Id(ControlPrefix + ControlMiddle + "TextBoxPublisher"); } }
        private WebElementWrapper Publisher { get; set; }
        //ctl00_MainContent_ItemFinder1_ItemFinderSearch1_PassageFinder_TextBoxWordQuantityMinimum
        private By ByNumberOfWordsFrom { get { return By.Id(ControlPrefix + ControlMiddle + "TextBoxWordQuantityMinimum"); } }
        private WebElementWrapper NumberOfWordsFrom { get; set; }
        //ctl00_MainContent_ItemFinder1_ItemFinderSearch1_PassageFinder_TextBoxWordQuantityMaximum
        private By ByNumberOfWordsTo { get { return By.Id(ControlPrefix + ControlMiddle + "TextBoxWordQuantityMaximum"); } }
        private WebElementWrapper NumberOfWordsTo { get; set; }
        /// <summary>
        /// the submit by
        /// ctl00_MainContent_ItemFinder1_ItemFinderSearch1_ButtonSearchPassages
        /// </summary>
        public override By BySubmit { get { return By.Id(ControlPrefix + "ItemFinder1_ItemFinderSearch1_ButtonSearchPassages"); } }

        public override void InputFormFields()
        {
            if (Data.Type != null)
            {
                Type.Wait(5).SelectByText(Data.Type);
            }
            if (Data.Subject != null)
            {
                Subject.Wait(5).SelectByText(Data.Subject);
            }
            if (Data.FromGrade != null)
            {
                FromGrade.Wait(5).SelectByText(Data.FromGrade);
            }
            if (Data.ToGrade != null)
            {
                ToGrade.Wait(5).SelectByText(Data.ToGrade);
            }
            if (Data.Title != null)
            {
                Title.SendKeys("" + Data.Title);
            }
            if (Data.Genre != null)
            {
                Genre.SendKeys("" + Data.Genre);
            }
            if (Data.Topic != null)
            {
                Topic.SendKeys("" + Data.Topic);
            }
            if (Data.Author != null)
            {
                Author.SendKeys("" + Data.Author);
            }
            if (Data.CreatedBy != null)
            {
                CreatedBy.Wait(5).SelectByText(Data.CreatedBy);
            }
            if (Data.QuestionLanguage != null)
            {
                QuestionLanguage.Wait(5).SelectByText(Data.QuestionLanguage);
            }
            if (Data.Publisher != null)
            {
                Publisher.SendKeys("" + Data.Publisher);
            }
            if (Data.NumberOfWordsFrom != null)
            {
                NumberOfWordsFrom.SendKeys("" + Data.NumberOfWordsFrom);
            }
            if (Data.NumberOfWordsTo != null)
            {
                NumberOfWordsTo.SendKeys("" + Data.NumberOfWordsTo);
            }
        }
    }
}
