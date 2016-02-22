using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;

namespace UITests.Pages.Assess.TestTunnel.Login
{
    /// <summary>
    /// the test tunnel login form
    /// </summary>
    public class LoginForm : SNForm
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public LoginForm()
            : base()
        {
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            UsernameText = new WebElementWrapper( ByUsernameText);
            PasswordText = new WebElementWrapper( ByPasswordText);
            PasscodeText = new WebElementWrapper( ByPasscodeText);
        }

        /// <summary>
        /// the data
        /// </summary>
        public new LoginData Data
        {
            get
            {
                return (LoginData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        public By ByUsernameText { get { return By.Id("TextBoxUsername"); } }
        private WebElementWrapper UsernameText { get; set; }
        public By ByPasswordText { get { return By.Id("TextBoxPassword"); } }
        private WebElementWrapper PasswordText { get; set; }
        public By ByPasscodeText { get { return By.Id("TextBoxTestCode"); } }
        private WebElementWrapper PasscodeText { get; set; }
        /// <summary>
        /// the submit by
        /// </summary>
        public override By BySubmit { get { return By.Id("ButtonLogin"); } }
        /// <summary>
        /// the cancel by
        /// </summary>
        public override By ByCancel { get { return By.Id("ButtonBack"); } }

        //overridden methods

        public override void InputFormFields()
        {
            if (Data.Username != null)
            {
                UsernameText.Wait(3).SendKeys(Data.Username);
            }
            if (Data.Password != null)
            {
                PasswordText.Wait(3).SendKeys(Data.Password);
            }
            if (Data.Passcode != null)
            {
                PasscodeText.Wait(3).SendKeys(Data.Passcode);
            }
        }

        public override IBaseScreenView ReturnSubmitPage()
        {
            return new DefaultPage();
        }
    }
}
