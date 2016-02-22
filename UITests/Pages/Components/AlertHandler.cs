using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Framework;
using Core.Views;
using Core.Tools.WebDriver;
using OpenQA.Selenium;

namespace UITests.Pages.Components
{
    /// <summary>
    /// alert handler and wrapper utility
    /// </summary>
    public class AlertHandler : SNComponent
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public AlertHandler()
            : base()
        {
        }
        /// <summary>
        /// verify text
        /// </summary>
        /// <param name="expectedMessage">expected message</param>
        public void VerifyText(string expectedMessage)
        {
            IAlert alert = Driver.SwitchTo().Alert();
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                ((DummyIAlert)alert).Text = expectedMessage;
            }
            string actual = alert.Text;
            Report.Write("The alert text: '" + actual + "'.");
            Assert.IsTrue(actual.Contains(expectedMessage), "The delete confirmation pop-up does not contain the expected text: '" + expectedMessage + "'; actual text: '" + actual + "'.");
        }
        /// <summary>
        /// accept
        /// </summary>
        public void Accept()
        {
            IAlert alert = Driver.SwitchTo().Alert();
            alert.Accept();
        }
        /// <summary>
        /// dismiss
        /// </summary>
        public void Dismiss()
        {
            IAlert alert = Driver.SwitchTo().Alert();
            alert.Dismiss();
        }
        /// <summary>
        /// send keys
        /// </summary>
        /// <param name="keysToSend">keys to send</param>
        public void SendKeys(string keysToSend)
        {
            IAlert alert = Driver.SwitchTo().Alert();
            alert.SendKeys(keysToSend);
        }
    }
}
