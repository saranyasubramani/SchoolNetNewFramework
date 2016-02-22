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
    /// teacher instruction editor form
    /// </summary>
    public class TeacherInstructionEditorForm : SNForm
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="overrideControlPrefix"></param>
        public TeacherInstructionEditorForm(string overrideControlPrefix = null)
            : base()
        {
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }
            //PageNames = pageName;
            LastElementExecuted = null;
            DoFileUpload = false;

            InitElements();
        }
        /// <summary>
        /// intialize elements
        /// </summary>
        public override void InitElements()
        {
            //switch (PageNames)
            //{
            //    case PageNames.EditTestItem:
            //        _controlPrefix2 = ControlPrefix + "ContentHtmlEditor_HtmlEditor_";
            //        break;
            //    case PageNames.CreatePassage:
            //        _controlPrefix2 = ControlPrefix + "HtmlEditor_HtmlEditor_";
            //        break;
            //}

            TeacherInstructionEditorId = new WebElementWrapper(ByEditorId);
            LightBoxIFrame = new WebElementWrapper(ByLightBoxIFrame);
            InsertLink = new WebElementWrapper(ByInsertLink);
            InsertImageLink = new WebElementWrapper(ByInsertImageLink);
            FileInputTag = new WebElementWrapper(ByFileInputTag);
            IFrame = new WebElementWrapper(ByIFrame);
            EditorContentArea = new WebElementWrapper(ByEditorContentArea);
            BoldButton = new WebElementWrapper(ByBoldButton);
        }

        /// <summary>
        /// the data
        /// </summary>
        public new AutoItData Data
        {
            get
            {
                return (AutoItData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }
        /// <summary>
        /// content data
        /// </summary>
        public string ContentData { get; set; }
        //private PageNames PageNames { get; set; }
        //private string _controlPrefix2 = "";

        public bool DoFileUpload;

        /// <summary>
        /// the last element that was executed
        /// </summary>
        public WebElementWrapper LastElementExecuted { get; set; }

        private By ByEditorId { get { return By.Id("lightBox"); } }
        private WebElementWrapper TeacherInstructionEditorId { get; set; }
        private By ByLightBoxIFrame { get { return By.Id("lightBoxFrame"); } }
        private WebElementWrapper LightBoxIFrame { get; set; }
        //private By ByIFrame { get { return By.Id("ctl00_MainContent_ContentHtmlEditor_HtmlEditor_ifr"); } }
        private By ByIFrame { get { return By.Id(ControlPrefix + "ifr"); } }
        private WebElementWrapper IFrame { get; set; }

        //ctl00_MainContent_ContentHtmlEditor_HtmlEditor_link
        //ctl00_MainContent_HtmlEditor_HtmlEditor_link
        private By ByInsertLink { get { return By.Id(ControlPrefix + "link"); } }
        private WebElementWrapper InsertLink { get; set; }
        //ctl00_MainContent_ContentHtmlEditor_HtmlEditor_SN_Image
        //ctl00_MainContent_HtmlEditor_HtmlEditor_SN_Image
        private By ByInsertImageLink { get { return By.Id(ControlPrefix + "SN_Image"); } }
        private WebElementWrapper InsertImageLink { get; set; }
        private By ByFileInputTag { get { return By.CssSelector("input[type=\"file\"][name=\"userImage\"]"); } }
        private WebElementWrapper FileInputTag { get; set; }
        private By ByEditorContentArea { get { return By.Id("tinymce"); } }
        private WebElementWrapper EditorContentArea { get; set; }
        private By ByBoldButton { get { return By.Id(ControlPrefix + "bold"); } }
        private WebElementWrapper BoldButton { get; set; }

        public override By ByCancel { get { return By.Id("ctl00_MainContent_btnCancel"); } }
        public override By BySubmit { get { return By.Id("ctl00_MainContent_btnOk"); } }

        private void WaitForEditorToDisplay()
        {
            this.Parent.CurrentWindowHandle = Driver.CurrentWindowHandle;
            Report.Write("The current window is: '" + this.Parent.CurrentWindowHandle + "'.");

            TeacherInstructionEditorId.WaitUntilExists(3);
        }

        private void WaitForLightboxFrameToDisplay()
        {
            LightBoxIFrame.WaitUntilExists(3);
            this.DriverCommands.WaitToSwitchFrame(LightBoxIFrame, 3);
        }

        private void WaitForIFrameToDisplay()
        {
            IFrame.WaitUntilExists(3);
            this.DriverCommands.WaitToSwitchFrame(IFrame, 3);
        }

        private void WaitForTinyMceToDisplay()
        {
            bool enabled = EditorContentArea.WaitUntilExists(10).Enabled;
            bool displayed = EditorContentArea.WaitUntilVisible(15).Displayed;
            if (EditorContentArea.WrappedElement.GetType() != typeof(DummyWebElement))
            {
                if ((displayed == false) || (enabled == false))
                {
                    throw new Exception(this.Utilities.GetInvisibleErrorMessage(EditorContentArea.By.ToString()));
                }
            }
        }
        private void ReWaitForTinyMceToDisplay()
        {
            try
            {
                WaitForTinyMceToDisplay();
            }
            catch (Exception e)
            {
                if (LastElementExecuted != null)
                {
                    this.DriverCommands.WaitToSwitchWindow(this.Parent.CurrentWindowHandle, 3);
                    //more than likely a click was executed
                    Report.Write("Re-attempting to click this element by: '" + LastElementExecuted.By.ToString() + "'.");
                    LastElementExecuted.Wait(5).Click();
                    WaitForEditorToDisplay();
                    WaitForLightboxFrameToDisplay();
                    WaitForIFrameToDisplay();
                    WaitForTinyMceToDisplay();
                }
            }
        }

        public override void ClearForm()
        {
            WaitForEditorToDisplay();
            WaitForLightboxFrameToDisplay();
            WaitForIFrameToDisplay();
            ReWaitForTinyMceToDisplay();
            EditorContentArea.Clear();
            this.DriverCommands.WaitToSwitchWindow(this.Parent.CurrentWindowHandle, 3);
        }
        public void ClearForm(WebElementWrapper lastElementExecuted)
        {
            LastElementExecuted = lastElementExecuted;
            WaitForEditorToDisplay();
            WaitForLightboxFrameToDisplay();
            WaitForIFrameToDisplay();
            ReWaitForTinyMceToDisplay();
            EditorContentArea.Clear();
            this.DriverCommands.WaitToSwitchWindow(this.Parent.CurrentWindowHandle, 3);
        }

        public override void InputFormFields()
        {
            WaitForEditorToDisplay();

            if (DoFileUpload)
            {
                UploadImage();
            }

            WaitForLightboxFrameToDisplay();
            WaitForIFrameToDisplay();
            ReWaitForTinyMceToDisplay();

            EditorContentArea.SendKeys(ContentData);
            this.DriverCommands.WaitToSwitchWindow(this.Parent.CurrentWindowHandle, 3);
        }
        public void InputFormFields(WebElementWrapper lastElementExecuted)
        {
            LastElementExecuted = lastElementExecuted;
            WaitForEditorToDisplay();

            if (DoFileUpload)
            {
                UploadImage();
            }

            WaitForLightboxFrameToDisplay();
            WaitForIFrameToDisplay();
            ReWaitForTinyMceToDisplay();

            EditorContentArea.SendKeys(ContentData);
            this.DriverCommands.WaitToSwitchWindow(this.Parent.CurrentWindowHandle, 3);
        }

        public IBaseScreenView InputAndSubmitForm(WebElementWrapper lastElementExecuted)
        {
            InputFormFields(lastElementExecuted);
            return SubmitForm();
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
            WaitForLightboxFrameToDisplay();
            Submit.Wait(3).Click();
            this.DriverCommands.WaitToSwitchWindow(this.Parent.CurrentWindowHandle, 3);
            //pause the script for a second to let the page settle down
            System.Threading.Thread.Sleep(1000);
            return ReturnSubmitPage();
        }

        public void CancelForm()
        {
            WaitForLightboxFrameToDisplay();
            Cancel.Wait(3).Click();
            this.DriverCommands.WaitToSwitchWindow(this.Parent.CurrentWindowHandle, 3);
            //pause the script for a second to let the page settle down
            System.Threading.Thread.Sleep(1000);
        }

        /// <summary>
        /// Upload Image in the Editor using AutoIt
        /// </summary>            
        public void UploadImage()
        {
            InsertImageLink.Wait(5);
            //FileInputTag.Wait(5);

            if (this.TestConfiguration.BrowserName == Core.Framework.BrowserType.INTERNET_EXPLORER)
            {
                BoldButton.Wait(5).Click();
            }

            this.Utilities.UploadFile(Data, InsertImageLink);

            SearchForImageInEditor();
        }

        /// <summary>
        /// Search For Image Uploaded in the Editor
        /// </summary>
        public void SearchForImageInEditor()
        {
            WaitForEditorToDisplay();

            var oldFocus = this.Parent.CurrentWindowHandle;

            WaitForLightboxFrameToDisplay();
            WaitForIFrameToDisplay();
            ReWaitForTinyMceToDisplay();

            this.DriverCommands.WaitForSpinnersToVanish(30);

            //var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(45));
            //wait.Until(d => d.FindElement(By.XPath("//p//img")));
            this.DriverCommands.WaitForElement(By.XPath("//p//img"));

            //Driver.SwitchTo().Window(oldFocus);
            this.DriverCommands.WaitToSwitchWindow(oldFocus, 30);
        }
    }
}
