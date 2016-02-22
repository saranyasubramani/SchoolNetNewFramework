using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;

namespace UITests.Pages.Admin.AssessAdminSettings.ItemProperties
{
    /// <summary>
    /// language properties
    /// </summary>
    public class LanguageProperties : SNForm
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="overrideControlPrefix"></param>
        public LanguageProperties( string overrideControlPrefix = null)
            : base()
        {
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
            LanguageEnglishCheck = new WebElementWrapper( ByLanguageEnglishCheck);
            LanguageAmericanSignCheck = new WebElementWrapper( ByLanguageAmericanSignCheck);
            LanguageChineseCheck = new WebElementWrapper( ByLanguageChineseCheck);
            LanguageFrenchCheck = new WebElementWrapper( ByLanguageFrenchCheck);
            LanguageGermanCheck = new WebElementWrapper( ByLanguageGermanCheck);
            LanguageItalianCheck = new WebElementWrapper( ByLanguageItalianCheck);
            LanguageLatinCheck = new WebElementWrapper( ByLanguageLatinCheck);
            LanguageSpanishCheck = new WebElementWrapper( ByLanguageSpanishCheck);
        }

        /// <summary>
        /// the submit by
        /// </summary>
        public override By BySubmit { get { return By.Id(ControlPrefix + "ctl00_AdminControl_languageCategoryId_ButtonSaveSelections"); } }
        private By ByLanguageEnglishCheck { get { return By.Id(ControlPrefix + "ctl00_AdminControl_languageCategoryId_cblSupportedLanguages_0"); } }
        private WebElementWrapper LanguageEnglishCheck { get; set; }
        private By ByLanguageAmericanSignCheck { get { return By.Id(ControlPrefix + "ctl00_AdminControl_languageCategoryId_cblSupportedLanguages_1"); } }
        private WebElementWrapper LanguageAmericanSignCheck { get; set; }
        private By ByLanguageChineseCheck { get { return By.Id(ControlPrefix + "ctl00_AdminControl_languageCategoryId_cblSupportedLanguages_2"); } }
        private WebElementWrapper LanguageChineseCheck { get; set; }
        private By ByLanguageFrenchCheck { get { return By.Id(ControlPrefix + "ctl00_AdminControl_languageCategoryId_cblSupportedLanguages_3"); } }
        private WebElementWrapper LanguageFrenchCheck { get; set; }
        private By ByLanguageGermanCheck { get { return By.Id(ControlPrefix + "ctl00_AdminControl_languageCategoryId_cblSupportedLanguages_4"); } }
        private WebElementWrapper LanguageGermanCheck { get; set; }
        private By ByLanguageItalianCheck { get { return By.Id(ControlPrefix + "ctl00_AdminControl_languageCategoryId_cblSupportedLanguages_5"); } }
        private WebElementWrapper LanguageItalianCheck { get; set; }
        private By ByLanguageLatinCheck { get { return By.Id(ControlPrefix + "ctl00_AdminControl_languageCategoryId_cblSupportedLanguages_6"); } }
        private WebElementWrapper LanguageLatinCheck { get; set; }
        private By ByLanguageSpanishCheck { get { return By.Id(ControlPrefix + "ctl00_AdminControl_languageCategoryId_cblSupportedLanguages_7"); } }
        private WebElementWrapper LanguageSpanishCheck { get; set; }

        /// <summary>
        /// check english language
        /// </summary>
        public void CheckLanguageEnglish()
        {
            LanguageEnglishCheck.Wait(3).Check();
        }
        /// <summary>
        /// uncheck english language
        /// </summary>
        public void UnCheckLanguageEnglish()
        {
            LanguageEnglishCheck.Wait(3).UnCheck();
        }
        /// <summary>
        /// is english language checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedLanguageEnglish()
        {
            LanguageEnglishCheck.Wait(5);
            LanguageEnglishCheck.Selected = true;
            return LanguageEnglishCheck.Selected;
        }

        /// <summary>
        /// check American sign language
        /// </summary>
        public void CheckLanguageAmericanSign()
        {
            LanguageAmericanSignCheck.Wait(3).Check();
        }
        /// <summary>
        /// uncheck American sign language
        /// </summary>
        public void UnCheckLanguageAmericanSign()
        {
            LanguageAmericanSignCheck.Wait(3).UnCheck();
        }
        /// <summary>
        /// is American sign language checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedLanguageAmericanSign()
        {
            LanguageAmericanSignCheck.Wait(5);
            LanguageAmericanSignCheck.Selected = true;
            return LanguageAmericanSignCheck.Selected;
        }

        /// <summary>
        /// check chinese language
        /// </summary>
        public void CheckLanguageChinese()
        {
            LanguageChineseCheck.Wait(3).Check();
        }
        /// <summary>
        /// uncheck chinese language
        /// </summary>
        public void UnCheckLanguageChinese()
        {
            LanguageChineseCheck.Wait(3).UnCheck();
        }
        /// <summary>
        /// is chinese language checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedLanguageChinese()
        {
            LanguageChineseCheck.Wait(5);
            LanguageChineseCheck.Selected = true;
            return LanguageChineseCheck.Selected;
        }

        /// <summary>
        /// check french language
        /// </summary>
        public void CheckLanguageFrench()
        {
            LanguageFrenchCheck.Wait(3).Check();
        }
        /// <summary>
        /// uncheck french language
        /// </summary>
        public void UnCheckLanguageFrench()
        {
            LanguageFrenchCheck.Wait(3).UnCheck();
        }
        /// <summary>
        /// is french language checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedLanguageFrench()
        {
            LanguageFrenchCheck.Wait(5);
            LanguageFrenchCheck.Selected = true;
            return LanguageFrenchCheck.Selected;
        }

        /// <summary>
        /// check german language
        /// </summary>
        public void CheckLanguageGerman()
        {
            LanguageGermanCheck.Wait(3).Check();
        }
        /// <summary>
        /// uncheck german language
        /// </summary>
        public void UnCheckLanguageGerman()
        {
            LanguageGermanCheck.Wait(3).UnCheck();
        }
        /// <summary>
        /// is german language checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedLanguageGerman()
        {
            LanguageGermanCheck.Wait(5);
            LanguageGermanCheck.Selected = true;
            return LanguageGermanCheck.Selected;
        }

        /// <summary>
        /// check italian language
        /// </summary>
        public void CheckLanguageItalian()
        {
            LanguageItalianCheck.Wait(3).Check();
        }
        /// <summary>
        /// uncheck italian language
        /// </summary>
        public void UnCheckLanguageItalian()
        {
            LanguageItalianCheck.Wait(3).UnCheck();
        }
        /// <summary>
        /// is italian language checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedLanguageItalian()
        {
            LanguageItalianCheck.Wait(5);
            LanguageItalianCheck.Selected = true;
            return LanguageItalianCheck.Selected;
        }

        /// <summary>
        /// check latin language
        /// </summary>
        public void CheckLanguageLatin()
        {
            LanguageLatinCheck.Wait(3).Check();
        }
        /// <summary>
        /// uncheck latin language
        /// </summary>
        public void UnCheckLanguageLatin()
        {
            LanguageLatinCheck.Wait(3).UnCheck();
        }
        /// <summary>
        /// is latin language checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedLanguageLatin()
        {
            LanguageLatinCheck.Wait(5);
            LanguageLatinCheck.Selected = true;
            return LanguageLatinCheck.Selected;
        }

        /// <summary>
        /// check spanish language
        /// </summary>
        public void CheckLanguageSpanish()
        {
            LanguageSpanishCheck.Wait(3).Check();
        }
        /// <summary>
        /// uncheck spanish language
        /// </summary>
        public void UnCheckLanguageSpanish()
        {
            LanguageSpanishCheck.Wait(3).UnCheck();
        }
        /// <summary>
        /// is spanish language checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedLanguageSpanish()
        {
            LanguageSpanishCheck.Wait(5);
            LanguageSpanishCheck.Selected = true;
            return LanguageSpanishCheck.Selected;
        }

        /// <summary>
        /// verify fields are selected
        /// </summary>
        public void VerifyFieldsAreSelected()
        {
            Assert.IsTrue(IsCheckedLanguageAmericanSign(), "American Sign languages is not selected.");
            Assert.IsTrue(IsCheckedLanguageChinese(), "Chinese languages is not selected.");
            Assert.IsTrue(IsCheckedLanguageEnglish(), "English languages is not selected.");
            Assert.IsTrue(IsCheckedLanguageFrench(), "French languages is not selected.");
            Assert.IsTrue(IsCheckedLanguageGerman(), "German languages is not selected.");
            Assert.IsTrue(IsCheckedLanguageItalian(), "Italian languages is not selected.");
            Assert.IsTrue(IsCheckedLanguageLatin(), "Latin languages is not selected.");
            Assert.IsTrue(IsCheckedLanguageSpanish(), "Spanish languages is not selected.");
        }

        //overridden methods

        public override void InputFormFields()
        {
            CheckLanguageAmericanSign();
            CheckLanguageEnglish();
            CheckLanguageChinese();
            CheckLanguageFrench();
            CheckLanguageGerman();
            CheckLanguageItalian();
            CheckLanguageLatin();
            CheckLanguageSpanish();
        }

        public override IBaseScreenView ReturnSubmitPage()
        {
            return new ItemPropertiesPage();
        }
    }
}
