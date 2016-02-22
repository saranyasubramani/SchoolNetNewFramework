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
    /// Represents the TinyMCE Editor
    /// </summary>
    public class Editor : SNForm
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="pageName"></param>
        /// <param name="overrideControlPrefix"></param>
        public Editor(PageNames pageName, string overrideControlPrefix = null)
            : base()
        {
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }

            PageNames = pageName;
            //_commands = new DriverCommands(Driver);
            LastElementExecuted = null;
            Gaps = 0;
            DoFileUpload = false;

            InitElements();
        }
        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            switch (PageNames)
            {
                case PageNames.EditorPopup:
                    //ctl00_MainContent_EditTestItemControl_HtmlEditor_HtmlEditor_ifr
                    _controlPrefix2 = ControlPrefix + "EditTestItemControl_HtmlEditor_HtmlEditor_";
                    break;
                case PageNames.CreatePassage:
                    //ctl00_MainContent_HtmlEditor_HtmlEditor_ifr
                    _controlPrefix2 = ControlPrefix + "HtmlEditor_HtmlEditor_";
                    break;
                case PageNames.ViewTestDetails:
                    //ctl00_MainContent_HtmlEditor_HtmlEditor_ifr
                    _controlPrefix2 = ControlPrefix + "HtmlEditor_HtmlEditor_";
                    break;
                case PageNames.OnlineTestTunnel:
                    //divLongResponseTM_ifr
                    _controlPrefix2 = "divLongResponseTM_";
                    break;
            }
            EditorId = new WebElementWrapper(ByEditorId);
            InsertLink = new WebElementWrapper(ByInsertLink);
            InsertImageLink = new WebElementWrapper(ByInsertImageLink);
            FileInputTag = new WebElementWrapper(ByFileInputTag);
            InsertNewGapLink = new WebElementWrapper(ByInsertNewGapLink);
            IFrame = new WebElementWrapper(ByIFrame);
            EditorContentArea = new WebElementWrapper(ByEditorContentArea);
            Thesaurus = new WebElementWrapper(ByThesaurus);
            BoldButton = new WebElementWrapper(ByBoldButton);
        }
        /// <summary>
        /// content data
        /// </summary>
        public string ContentData { get; set; }
        private List<string> _gapContentData;
        /// <summary>
        /// gap content data
        /// </summary>
        public List<string> GapContentData
        {
            get
            {
                return _gapContentData;
            }
            set
            {
                _gapContentData = value;
                Gaps = _gapContentData.Count;
            }
        }

        /// <summary>
        /// the data object
        /// </summary>
        public AutoItData Data
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

        //private DriverCommands _commands;
        private PageNames PageNames { get; set; }
        private string _currentWindow;
        private string _controlPrefix2 = "";

        private int Gaps { get; set; }

        public bool DoFileUpload;

        /// <summary>
        /// the last element that was executed
        /// </summary>
        public WebElementWrapper LastElementExecuted { get; set; }

        private By ByEditorId { get { return By.Id("divEditor"); } }
        private WebElementWrapper EditorId { get; set; }

        //ctl00_MainContent_EditTestItemControl_HtmlEditor_HtmlEditor_link
        private By ByInsertLink { get { return By.Id(_controlPrefix2 + "link"); } }
        private WebElementWrapper InsertLink { get; set; }

        //ctl00_MainContent_EditTestItemControl_HtmlEditor_HtmlEditor_SN_Image
        private By ByInsertImageLink { get { return By.Id(_controlPrefix2 + "SN_Image"); } }
        private WebElementWrapper InsertImageLink { get; set; }

        private By ByFileInputTag { get { return By.CssSelector("input[type=\"file\"][name=\"userImage\"]"); } }
        private WebElementWrapper FileInputTag { get; set; }

        //ctl00_MainContent_EditTestItemControl_HtmlEditor_HtmlEditor_SN_Interaction
        private By ByInsertNewGapLink { get { return By.Id(_controlPrefix2 + "SN_Interaction"); } }
        private WebElementWrapper InsertNewGapLink { get; set; }

        private By ByIFrame { get { return By.Id(_controlPrefix2 + "ifr"); } }
        private WebElementWrapper IFrame { get; set; }

        private By ByEditorContentArea { get { return By.Id("tinymce"); } }//{ get { return By.TagName("body"); } }
        private WebElementWrapper EditorContentArea { get; set; }

        private By ByThesaurus { get { return By.CssSelector("#divEditor > .modal-footer > input[value='Thesaurus']"); } }
        private WebElementWrapper Thesaurus { get; set; }

        private By ByBoldButton { get { return By.Id(_controlPrefix2 + "bold"); } }
        private WebElementWrapper BoldButton { get; set; }

        public override By ByCancel { get { return By.CssSelector("#divEditor > .modal-footer > input[value='Cancel']"); } }
        //public override By BySubmit { get { return By.CssSelector("#divEditor > .modal-footer > input[value='Save']"); } }
        public override By BySubmit { get { return BySubmitLocator(); } }


        /// <summary>
        /// gets submit button By object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private By BySubmitLocator()
        {
            By Submit = By.CssSelector("#divEditor > .modal-footer > input[value='Save']"); ;
            switch (PageNames)
            {
                case PageNames.EditorPopup:
                    Submit = By.CssSelector("#divEditor > .modal-footer > input[value='Save']");
                    break;
                case PageNames.CreatePassage:
                    Submit = By.CssSelector("#divEditor > .modal-footer > input[value='Save']");
                    break;
                case PageNames.ViewTestDetails:
                    Submit = By.Id(ControlPrefix + "btnSaveInstruction");
                    break;
            }
            return Submit;
        }

        private void WaitForEditorToDisplay()
        {
            _currentWindow = Driver.CurrentWindowHandle;
            Report.Write("The current window is: '" + _currentWindow + "'.");
            if (PageNames == PageNames.EditorPopup)
            {
                EditorId.WaitUntilExists(3);
            }
        }

        private void WaitForFrameToDisplay()
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
                    this.DriverCommands.WaitToSwitchWindow(_currentWindow, 3);
                    //more than likely a click was executed
                    Report.Write("Re-attempting to click this element by: '" + LastElementExecuted.By.ToString() + "'.");
                    LastElementExecuted.Wait(5).Click();
                    WaitForEditorToDisplay();
                    WaitForFrameToDisplay();
                    WaitForTinyMceToDisplay();
                }
            }
        }

        public void HighlightSentenceOnEditor()
        {
            WaitForEditorToDisplay();
            WaitForFrameToDisplay();
            ReWaitForTinyMceToDisplay();
            //EditorContentArea.SendKeys(Keys.Control + "a");
            EditorContentArea.SendKeys(Keys.Home);
            EditorContentArea.SendKeys(Keys.Shift + Keys.ArrowRight);
            this.DriverCommands.WaitToSwitchWindow(_currentWindow, 3);
        }

        /// <summary>
        /// select the insert image button/link
        /// </summary>
        public void SelectInsertImage()
        {
            WaitForEditorToDisplay();
            this.DriverCommands.WaitToSwitchWindow(_currentWindow, 3);
            InsertImageLink.Wait(3).Click();
        }

        /// <summary>
        /// select the insert/edit link
        /// </summary>
        public InsertLinkDialog SelectInsertLink()
        {
            HighlightSentenceOnEditor();
            InsertLink.Wait(3).Click();
            return new InsertLinkDialog();
        }

        /// <summary>
        /// get the text
        /// </summary>
        /// <param name="fakeText">fake text</param>
        /// <returns>text</returns>
        public string GetText(string fakeText)
        {
            WaitForEditorToDisplay();
            WaitForFrameToDisplay();
            ReWaitForTinyMceToDisplay();
            EditorContentArea.Text = fakeText;
            string text = EditorContentArea.Text;
            this.DriverCommands.WaitToSwitchWindow(_currentWindow, 3);
            return text;
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

            var oldFocus = _currentWindow;

            WaitForFrameToDisplay();
            ReWaitForTinyMceToDisplay();

            this.DriverCommands.WaitForSpinnersToVanish(30);

            //var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(45));
            //wait.Until(d => d.FindElement(By.XPath("//p//img")));
            this.DriverCommands.WaitForElement(By.XPath("//p//img"));

            //Driver.SwitchTo().Window(oldFocus);
            this.DriverCommands.WaitToSwitchWindow(oldFocus, 30);
        }

        //implement methods
        public override void ClearForm()
        {
            WaitForEditorToDisplay();
            WaitForFrameToDisplay();
            WaitForTinyMceToDisplay();
            EditorContentArea.Clear();
            this.DriverCommands.WaitToSwitchWindow(_currentWindow, 3);
        }
        public void ClearForm(WebElementWrapper lastElementExecuted)
        {
            LastElementExecuted = lastElementExecuted;
            WaitForEditorToDisplay();
            WaitForFrameToDisplay();
            ReWaitForTinyMceToDisplay();
            EditorContentArea.Clear();
            this.DriverCommands.WaitToSwitchWindow(_currentWindow, 3);
        }

        public override void InputFormFields()
        {
            WaitForEditorToDisplay();
            //WaitForFrameToDisplay();
            //WaitForTinyMceToDisplay();

            if (Gaps <= 0)
            {
                if (DoFileUpload)
                {
                    UploadImage();
                }

                WaitForFrameToDisplay();
                WaitForTinyMceToDisplay();

                EditorContentArea.SendKeys(ContentData);
            }
            else
            {
                for (int i = 0; i < Gaps; i++)
                {
                    if (DoFileUpload)
                    {
                        UploadImage();
                    }

                    WaitForFrameToDisplay();
                    WaitForTinyMceToDisplay();

                    EditorContentArea.SendKeys(GapContentData[i]);

                    this.DriverCommands.WaitToSwitchWindow(_currentWindow, 3);

                    InsertNewGapLink.Wait(3).Click();

                    //WaitForFrameToDisplay();
                    //WaitForTinyMceToDisplay();
                }

                WaitForFrameToDisplay();
                WaitForTinyMceToDisplay();

                EditorContentArea.SendKeys(ContentData);
            }
            //Driver.SwitchTo().Window(_currentWindow);
            this.DriverCommands.WaitToSwitchWindow(_currentWindow, 3);
        }

        public void InputFormFields(WebElementWrapper lastElementExecuted)
        {
            LastElementExecuted = lastElementExecuted;
            WaitForEditorToDisplay();
            //WaitForFrameToDisplay();
            //ReWaitForTinyMceToDisplay();

            if (Gaps <= 0)
            {
                if (DoFileUpload)
                {
                    UploadImage();
                }

                WaitForFrameToDisplay();
                //WaitForTinyMceToDisplay();
                ReWaitForTinyMceToDisplay();

                EditorContentArea.SendKeys(ContentData);
            }
            else
            {
                for (int i = 0; i < Gaps; i++)
                {
                    if (DoFileUpload)
                    {
                        UploadImage();
                    }

                    WaitForFrameToDisplay();
                    WaitForTinyMceToDisplay();

                    EditorContentArea.SendKeys(GapContentData[i]);

                    this.DriverCommands.WaitToSwitchWindow(_currentWindow, 3);

                    InsertNewGapLink.Wait(3).Click();

                    //WaitForFrameToDisplay();
                    //WaitForTinyMceToDisplay();
                }

                WaitForFrameToDisplay();
                WaitForTinyMceToDisplay();

                EditorContentArea.SendKeys(ContentData);
            }
            //Driver.SwitchTo().Window(_currentWindow);
            this.DriverCommands.WaitToSwitchWindow(_currentWindow, 3);
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
            Submit.Wait(3).Click();
            this.DriverCommands.WaitToSwitchWindow(_currentWindow, 3);
            //pause the script for a second to let the page settle down
            System.Threading.Thread.Sleep(1000);
            return ReturnSubmitPage();
        }
    }
}
