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
    /// item properties form
    /// </summary>
    public class ItemPropertiesForm : SNForm
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="overrideControlPrefix"></param>
        public ItemPropertiesForm( string overrideControlPrefix = null)
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
            Language = new LanguageProperties(ControlPrefix);
        }

        /// <summary>
        /// language properties
        /// </summary>
        public LanguageProperties Language { get; private set; }

        /// <summary>
        /// check english language
        /// </summary>
        public void CheckLanguageEnglish()
        {
            Language.CheckLanguageEnglish();
        }
        /// <summary>
        /// uncheck english language
        /// </summary>
        public void UnCheckLanguageEnglish()
        {
            Language.UnCheckLanguageEnglish();
        }
        /// <summary>
        /// is english language checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedLanguageEnglish()
        {
            return Language.IsCheckedLanguageEnglish();
        }

        /// <summary>
        /// check American sign language
        /// </summary>
        public void CheckLanguageAmericanSign()
        {
            Language.CheckLanguageAmericanSign();
        }
        /// <summary>
        /// uncheck American sign language
        /// </summary>
        public void UnCheckLanguageAmericanSign()
        {
            Language.UnCheckLanguageAmericanSign();
        }
        /// <summary>
        /// is American sign language checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedLanguageAmericanSign()
        {
            return Language.IsCheckedLanguageAmericanSign();
        }

        /// <summary>
        /// check chinese language
        /// </summary>
        public void CheckLanguageChinese()
        {
            Language.CheckLanguageChinese();
        }
        /// <summary>
        /// uncheck chinese language
        /// </summary>
        public void UnCheckLanguageChinese()
        {
            Language.UnCheckLanguageChinese();
        }
        /// <summary>
        /// is chinese language checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedLanguageChinese()
        {
            return Language.IsCheckedLanguageChinese();
        }

        /// <summary>
        /// check french language
        /// </summary>
        public void CheckLanguageFrench()
        {
            Language.CheckLanguageFrench();
        }
        /// <summary>
        /// uncheck french language
        /// </summary>
        public void UnCheckLanguageFrench()
        {
            Language.UnCheckLanguageFrench();
        }
        /// <summary>
        /// is french language checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedLanguageFrench()
        {
            return Language.IsCheckedLanguageFrench();
        }

        /// <summary>
        /// check german language
        /// </summary>
        public void CheckLanguageGerman()
        {
            Language.CheckLanguageGerman();
        }
        /// <summary>
        /// uncheck german language
        /// </summary>
        public void UnCheckLanguageGerman()
        {
            Language.UnCheckLanguageGerman();
        }
        /// <summary>
        /// is german language checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedLanguageGerman()
        {
            return Language.IsCheckedLanguageGerman();
        }

        /// <summary>
        /// check italian language
        /// </summary>
        public void CheckLanguageItalian()
        {
            Language.CheckLanguageItalian();
        }
        /// <summary>
        /// uncheck italian language
        /// </summary>
        public void UnCheckLanguageItalian()
        {
            Language.UnCheckLanguageItalian();
        }
        /// <summary>
        /// is italian language checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedLanguageItalian()
        {
            return Language.IsCheckedLanguageItalian();
        }

        /// <summary>
        /// check latin language
        /// </summary>
        public void CheckLanguageLatin()
        {
            Language.CheckLanguageLatin();
        }
        /// <summary>
        /// uncheck latin language
        /// </summary>
        public void UnCheckLanguageLatin()
        {
            Language.UnCheckLanguageLatin();
        }
        /// <summary>
        /// is latin language checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedLanguageLatin()
        {
            return Language.IsCheckedLanguageLatin();
        }

        /// <summary>
        /// check spanish language
        /// </summary>
        public void CheckLanguageSpanish()
        {
            Language.CheckLanguageSpanish();
        }
        /// <summary>
        /// uncheck spanish language
        /// </summary>
        public void UnCheckLanguageSpanish()
        {
            Language.UnCheckLanguageSpanish();
        }
        /// <summary>
        /// is spanish language checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedLanguageSpanish()
        {
            return Language.IsCheckedLanguageSpanish();
        }

        //overridden methods

        public override void InputFormFields()
        {
            Language.InputAndSubmitForm();

        }
    }
}
