using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;

namespace UITests.Pages.Assess.ItemCreateEdit.v01.ItemParts
{
    /// <summary>
    /// attach rubric dialog form
    /// </summary>
    public class AttachRubricDialogForm : SNForm
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="overrideControlPrefix"></param>
        public AttachRubricDialogForm(string overrideControlPrefix = null)
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
            Keyword = new WebElementWrapper(ByKeyword);
            IFrame = new WebElementWrapper(ByIFrame);
            FormId = new WebElementWrapper(ByFormId); 
        }

        /// <summary>
        /// the data
        /// </summary>
        public new AttachRubricDialogData Data
        {
            get
            {
                return (AttachRubricDialogData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        private By ByKeyword { get { return By.Id(ControlPrefix + "tbxSearch"); } }
        private WebElementWrapper Keyword { get; set; }
        private By ByIFrame { get { return By.Id("lightBoxFrame"); } }
        private WebElementWrapper IFrame { get; set; }
        private By ByFormId { get { return By.Id("aspnetForm"); } }
        private WebElementWrapper FormId { get; set; }
        public override By BySubmit { get { return By.Id(ControlPrefix + "ApplyButton"); } }

        private void WaitForIFrameToDisplay()
        {
            this.Parent.CurrentWindowHandle = Driver.CurrentWindowHandle;
            Report.Write("The current window is: '" + this.Parent.CurrentWindowHandle + "'.");

            IFrame.WaitUntilExists(3);
            this.DriverCommands.WaitToSwitchFrame(IFrame, 3);
        }

        private void WaitForFormIdToDisplay()
        {
            System.Threading.Thread.Sleep(2000);
            FormId.WaitUntilExists(15);
        }

        //implemented methods
        public override void InputFormFields()
        {
            WaitForIFrameToDisplay();
            WaitForFormIdToDisplay();
            Keyword.Wait(5).SendKeys(Data.FilterKeyword);
        }

        public override IBaseScreenView ReturnSubmitPage()
        {
            this.DriverCommands.WaitToSwitchWindow(this.Parent.CurrentWindowHandle, 3);
            throw null;
        }
    }
}
