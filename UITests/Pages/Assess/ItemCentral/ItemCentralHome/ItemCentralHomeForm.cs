using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages.Components;

namespace UITests.Pages.Assess.ItemCentral.ItemCentralHome
{
    /// <summary>
    /// the item central home form
    /// </summary>
    public class ItemCentralHomeForm : SNForm
    {
        /// <summary>
        /// the item central home form constructor
        /// </summary>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public ItemCentralHomeForm(string overrideControlPrefix = null)
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
            SearchBasicForm = new SearchBasicForm(PageNames.ItemCentralHome, ControlPrefix);
            //SiteTitleLabel = new WebElementWrapper(Driver, BySiteTitleLabel);
        }

        /// <summary>
        /// the data
        /// </summary>
        public new ItemCentralHomeData Data
        {
            get
            {
                return (ItemCentralHomeData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        /// <summary>
        /// the item central type
        /// </summary>
        public ItemCentralType ItemCentralType { get; set; }
        private SearchBasicForm SearchBasicForm { get; set; }
        //private By BySiteTitleLabel { get { return By.CssSelector(".SiteTitle"); } }
        //private WebElementWrapper SiteTitleLabel { get; set; }

        /// <summary>
        /// the submit by
        /// </summary>
        public override By BySubmit { get { return SearchBasicForm.BySubmit; } }


        public override void InputFormFields()
        {
            SearchBasicForm.InputFormFields();
        }

        public override IBaseScreenView SubmitForm()
        {
            try
            {   //stop hover over menu
                //SiteTitleLabel.Wait(3).Click();
                this.Utilities.FocusOnMainContentArea();//this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            }
            catch (Exception e)
            {
                //do nothing
            }
            Submit.Wait(3).Click();
            return this.ReturnSubmitPage();
        }
    }
}
