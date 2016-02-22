using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages;
using UITests.Pages.Home;

namespace UITests.Pages.Login.Components
{
    /// <summary>
    /// authentication form
    /// </summary>
    public class AuthenticationForm : SNForm
    {
        /// <summary>
        /// constructor
        /// </summary>
        public AuthenticationForm() : base()
        {
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            DistrictName = new SelectElementWrapper(new WebElementWrapper(ByDistrictName));
            Username = new WebElementWrapper(ByUsername);
            Password = new WebElementWrapper(ByPassword);
        }

        /// <summary>
        /// the data
        /// </summary>
        public new AuthenticationData Data
        {
            get
            {
                return (AuthenticationData) base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        public By ByDistrictName { get { return By.Id("ctl02_ddlListProvider"); } }
        public SelectElementWrapper DistrictName { get; set; }
        public By ByUsername { get { return By.Id("ctl02_TextBoxUsername"); } }
        public WebElementWrapper Username { get; set; }
        public By ByPassword { get { return By.Id("ctl02_TextBoxPassword"); } }
        public WebElementWrapper Password { get; set; }
        public override By BySubmit { get { return By.CssSelector(".btn.btn-primary.SignInButton"); } }

        //implemented methods
        public override void ClearForm()
        {
            Username.Clear();
            Password.Clear();
        }

        public override void InputFormFields()
        {
            Username.SendKeys(Data.Username);
            Password.SendKeys(Data.Password);
        }

        public override IBaseScreenView ReturnSubmitPage()
        {
            return new HomePage();
        }
        public override IBaseScreenView ReturnCancelPage()
        {
            return null;
        }
    }
}
