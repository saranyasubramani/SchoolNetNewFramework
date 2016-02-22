using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages.Assess.TestTunnel.TestForms;

namespace UITests.Pages.Assess.TestTunnel.Default
{
    /// <summary>
    /// the test tunnel default form
    /// </summary>
    public class DefaultForm : SNForm
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public DefaultForm()
            : base()
        {
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            LightboxMessage = new WebElementWrapper(ByLightboxMessage);
        }

        /// <summary>
        /// the data
        /// </summary>
        public new DefaultData Data
        {
            get
            {
                return (DefaultData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        /// <summary>
        /// list of test form types
        /// </summary>
        public List<TestTypeForm> TestList { get; set; }
        /// <summary>
        /// get the item's list of IDs and indexes
        /// </summary>
        public ReadOnlyCollection<object> ItemIdToIndexList { get; set; }
        private By ByLightboxMessage { get { return By.Id("divLightboxMessage"); } }
        private WebElementWrapper LightboxMessage { get; set; }

        /// <summary>
        /// verify the message text in the light box
        /// </summary>
        /// <param name="expectedMessage">the expected message</param>
        public void LightBoxMessageVerifyText(string expectedMessage)
        {
            LightboxMessage.Wait(3);
            LightboxMessage.Text = expectedMessage;
            string actual = LightboxMessage.Text;
            Assert.IsTrue(actual.Contains(expectedMessage),
                "The light box pop-up does not contain the expected text: '" + expectedMessage + "'; actual text: '" + actual + "'.");
        }
    }
}
