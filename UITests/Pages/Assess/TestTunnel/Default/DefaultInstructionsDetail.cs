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
    /// test instructions content page within the test tunnel default page
    /// </summary>
    public class DefaultInstructionsDetail : SNDetail
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="overrideControlPrefix"></param>
        public DefaultInstructionsDetail(  string overrideControlPrefix = null)
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
            TestInstructions = new WebElementWrapper( ByTestInstructions);
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

        public By ByTestInstructions { get { return By.CssSelector(".divInstructionContent"); } }
        public WebElementWrapper TestInstructions { get; private set; }

        /// <summary>
        /// list of test form types
        /// </summary>
        public List<TestTypeForm> TestList { get; set; }
        /// <summary>
        /// get the item's list of IDs and indexes
        /// </summary>
        public ReadOnlyCollection<object> ItemIdToIndexList { get; set; }

        /// <summary>
        /// verify test name in test instructions
        /// </summary>
        public void VerifyTestNameInTestInstructions()
        {
            var testInstructions = TestInstructions.Wait(2);

            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                testInstructions.Text = Data.TestName;
            }

            var testInstructionsTextDisplayed = testInstructions.Text;
            Assert.IsTrue(testInstructionsTextDisplayed.Contains(Data.TestName),
                string.Format("Test Instructions displayed does not contain Test Name: '{0}'", Data.TestName));
        }
        /// <summary>
        /// verify tester's first name in test instructions
        /// </summary>
        public void VerifyTestersFirstNameInTestInstructions()
        {
            var testInstructions = TestInstructions.Wait(2);

            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                testInstructions.Text = Data.TestersFirstName;
            }

            var testInstructionsTextDisplayed = testInstructions.Text;
            Assert.IsTrue(testInstructionsTextDisplayed.Contains(Data.TestersFirstName),
                string.Format("Test Instructions displayed does not contain Tester's First Name: '{0}'", Data.TestersFirstName));
        }
        /// <summary>
        /// verify tester's last name in test instructions
        /// </summary>
        public void VerifyTestersLastNameInTestInstructions()
        {
            var testInstructions = TestInstructions.Wait(2);

            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                testInstructions.Text = Data.TestersLastName;
            }

            var testInstructionsTextDisplayed = testInstructions.Text;
            Assert.IsTrue(testInstructionsTextDisplayed.Contains(Data.TestersLastName),
                string.Format("Test Instructions displayed does not contain Tester's Last Name: '{0}'", Data.TestersLastName));
        }

        //overridden methods

        public override void VerifyFieldsExists()
        {
            var testInstructions = TestInstructions.Wait(2);

            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                testInstructions.Displayed = true;
            }

            Assert.AreEqual(true, testInstructions.Displayed, "The test instructions is invisible, but should be visible.");
        }
    }
}
