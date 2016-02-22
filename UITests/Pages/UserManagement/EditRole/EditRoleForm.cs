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

namespace UITests.Pages.UserManagement.EditRole
{
    /// <summary>
    /// edit role form
    /// </summary>
    public class EditRoleForm : SNForm
    {
        /// <summary>
        /// constructor
        /// </summary>
        public EditRoleForm()
            : base()
        {
            InitElements();
        }
        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            Description = new WebElementWrapper(ByDescription);
            RemoveArrow = new WebElementWrapper(ByRemoveArrow);
            AddArrow = new WebElementWrapper(ByAddArrow);
            OperationAvailable = new SelectElementWrapper(new WebElementWrapper(ByOperationAvailable));
            OperationIncluded = new SelectElementWrapper(new WebElementWrapper(ByOperationIncluded));
        }

        /// <summary>
        /// the data
        /// </summary>
        public new EditRoleData Data
        {
            get
            {
                return (EditRoleData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        private string _controlPrefix2 = "RoleEditControl_";
        //ctl00_MainContent_RoleEditControl_TextboxDescription
        private By ByDescription { get { return By.Id(ControlPrefix + _controlPrefix2 + "TextboxDescription"); } }
        private WebElementWrapper Description { get; set; }
        //ctl00_MainContent_RoleEditControl_ImagebuttonRemoveOperation
        private By ByRemoveArrow { get { return By.Id(ControlPrefix + _controlPrefix2 + "ImagebuttonRemoveOperation"); } }
        private WebElementWrapper RemoveArrow { get; set; }
        //ctl00_MainContent_RoleEditControl_ImagebuttonAddOperation
        private By ByAddArrow { get { return By.Id(ControlPrefix + _controlPrefix2 + "ImagebuttonAddOperation"); } }
        private WebElementWrapper AddArrow { get; set; }
        //ctl00_MainContent_RoleEditControl_ListBoxAvailableOperations
        private By ByOperationAvailable { get { return By.Id(ControlPrefix + _controlPrefix2 + "ListBoxAvailableOperations"); } }
        private SelectElementWrapper OperationAvailable { get; set; }
        //ctl00_MainContent_RoleEditControl_ListBoxIncludedOperations
        private By ByOperationIncluded { get { return By.Id(ControlPrefix + _controlPrefix2 + "ListBoxIncludedOperations"); } }
        private SelectElementWrapper OperationIncluded { get; set; }
        /// <summary>
        /// submit by
        /// </summary>
        public override By BySubmit { get { return By.Id(ControlPrefix + _controlPrefix2 + "ButtonSave"); } }
        /// <summary>
        /// cancel by
        /// </summary>
        public override By ByCancel { get { return By.Id(ControlPrefix + _controlPrefix2 + "ButtonCancel"); } }

        /// <summary>
        /// remove operation
        /// </summary>
        public void RemoveOperation()
        {
            OperationIncluded.SelectByText(Data.OperationToRemove);
            RemoveArrow.Click();
            this.DriverCommands.WaitAndMeasurePageLoadTime();
            InitElements();
        }
        /// <summary>
        /// add operation
        /// </summary>
        public void AddOperation()
        {
            OperationAvailable.SelectByText(Data.OperationToAdd);
            AddArrow.Click();
            this.DriverCommands.WaitAndMeasurePageLoadTime();
            InitElements();
        }
        /// <summary>
        /// verify operation included
        /// </summary>
        public void VerifyOperationIncluded()
        {
            OperationIncluded.Wait(3);
            IList<IWebElement> list;
            if (Driver.GetType() == typeof(DummyDriver))
            {

                DummyWebElement dummy1 = new DummyWebElement();
                dummy1.Text = Data.OperationToRemove;
                OperationIncluded.FakeOptionsList = new List<IWebElement> { dummy1 };
            }
            list = OperationIncluded.Options;
            bool isFound = false;
            foreach (var webElement in list)
            {
                Report.Write("OperationIncluded value: " + webElement.GetAttribute("value") + "; text: " + webElement.Text);
                if (webElement.Text.Equals(Data.OperationToRemove))
                {
                    isFound = true;
                }
            }
            Assert.IsTrue(isFound, "Verified the operation '" + Data.OperationToRemove + "' is not included.");
        }
        /// <summary>
        /// verify operation available
        /// </summary>
        public void VerifyOperationAvailable()
        {
            OperationAvailable.Wait(3);
            IList<IWebElement> list;
            if (Driver.GetType() == typeof(DummyDriver))
            {
                DummyWebElement dummy1 = new DummyWebElement();
                dummy1.Text = Data.OperationToAdd;
                OperationAvailable.FakeOptionsList = new List<IWebElement> { dummy1 };
            }
            list = OperationAvailable.Options;
            bool isFound = false;
            foreach (var webElement in list)
            {
                Report.Write("OperationAvailable value: " + webElement.GetAttribute("value") + "; text: " + webElement.Text);
                if (webElement.Text.Equals(Data.OperationToAdd))
                {
                    isFound = true;
                }
            }
            Assert.IsTrue(isFound, "Verified the operation '" + Data.OperationToAdd + "' is not available.");
        }

        public override IBaseScreenView ReturnSubmitPage()
        {
            return null;
        }
        public override IBaseScreenView ReturnCancelPage()
        {
            return null;
        }
    }
}
