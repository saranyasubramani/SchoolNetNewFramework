using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;

namespace UITests.Pages.Components.Editors
{
    /// <summary>
    /// insert link dialog form
    /// </summary>
    public class InsertLinkDialogForm : EditorDialogForm
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="overrideControlPrefix"></param>
        public InsertLinkDialogForm(string overrideControlPrefix = null)
            : base()
        {
            InitElements();
        }
        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            DialogId = new WebElementWrapper(ByDialogId);
            IFrame = new WebElementWrapper(ByIFrame);
            DialogBodyId = new WebElementWrapper(ByDialogBodyId);
            PanelId = new WebElementWrapper(ByPanelId);
            UrlText = new WebElementWrapper(ByUrlText);
            TitleText = new WebElementWrapper(ByTitleText);
        }

        /// <summary>
        /// the data
        /// </summary>
        public new InsertLinkDialogData Data
        {
            get
            {
                return (InsertLinkDialogData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        private By ByDialogId { get { return By.Id("mce_" + UniqueId); } }
        private WebElementWrapper DialogId { get; set; }
        private By ByIFrame { get { return By.Id("mce_" + UniqueId + "_ifr"); } }
        private WebElementWrapper IFrame { get; set; }
        private By ByDialogBodyId { get { return By.Id("advlink"); } }
        private WebElementWrapper DialogBodyId { get; set; }
        private By ByPanelId { get { return By.Id("general_panel"); } }
        private WebElementWrapper PanelId { get; set; }
        private By ByUrlText { get { return By.Id("href"); } }
        private WebElementWrapper UrlText { get; set; }
        private By ByTitleText { get { return By.Id("title"); } }
        private WebElementWrapper TitleText { get; set; }

        public override By ByCancel { get { return By.Id("cancel"); } }
        public override By BySubmit { get { return By.Id("insert"); } }

        private void WaitForEditorToDisplay()
        {
            this.Parent.CurrentWindowHandle = Driver.CurrentWindowHandle;
            Report.Write("At WaitForEditorToDisplay, The current window is: '" + this.Parent.CurrentWindowHandle + "'.");
            DialogId.WaitUntilExists(3);
        }

        private void WaitForFrameToDisplay()
        {
            IFrame.WaitUntilExists(3);
            this.DriverCommands.WaitToSwitchFrame(IFrame, 3);
        }

        private void WaitForBodyToDisplay()
        {
            Report.Write("At WaitForDialogBodyToDisplay.");
            DialogBodyId.WaitUntilExists(3);
        }

        private void WaitForPanelToDisplay()
        {
            Report.Write("At WaitForPanelToDisplay.");
            PanelId.WaitUntilExists(3);
        }

        //implement methods
        public override void InputFormFields()
        {
            WaitForEditorToDisplay();
            WaitForFrameToDisplay();
            WaitForBodyToDisplay();
            WaitForPanelToDisplay();

            UrlText.SendKeys(Data.Url);
            TitleText.SendKeys(Data.Title);
        }

        public override IBaseScreenView ReturnSubmitPage()
        {
            return null;
        }
        public override IBaseScreenView ReturnCancelPage()
        {
            return null;
        }

        public override IBaseScreenView SubmitForm()
        {
            Submit.Wait(3).Click();
            this.DriverCommands.WaitToSwitchWindow(this.Parent.CurrentWindowHandle, 3);
            //pause the script for a second to let the page settle down
            System.Threading.Thread.Sleep(1000);
            return ReturnSubmitPage();
        }
    }
}
