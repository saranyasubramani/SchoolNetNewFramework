using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages.Components;

namespace UITests.Pages.Assess.Standards
{
    /// <summary>
    /// the standard popup dialog (page via inline frame) in the test item or rubric pages
    /// </summary>
    public class StandardPopupDialog : SNWebPage
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="pageName">page name</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public StandardPopupDialog(PageNames pageName, string overrideControlPrefix = null)
            : base()
        {
            this.PageName = pageName;
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
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
            LightBox = new WebElementWrapper(ByLightBox);
            IFrame = new WebElementWrapper(ByIFrame);
            WaitForFrameToDisplay();
            Form = new StandardPickerForm(PageName, ControlPrefix);
        }

        //// <summary>
        /// the data
        /// </summary>
        public new StandardPickerData Data
        {
            get
            {
                return (StandardPickerData)base.Data;
            }
            set
            {
                base.Data = value;
                this.Form.Data = value;
            }
        }
        /// <summary>
        /// intializes the data
        /// </summary>
        /// <returns>object data</returns>
        public StandardPickerData InitData()
        {
            base.InitData(new StandardPickerData());
            return (StandardPickerData)base.Data;
        }
        /// <summary>
        /// initializes the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>object data</returns>
        public StandardPickerData InitData(object data)
        {
            base.InitData(data);
            return (StandardPickerData)base.Data;
        }
        /// <summary>
        /// the form
        /// </summary>
        public new StandardPickerForm Form { get; private set; }
        private PageNames PageName { get; set; }
        private By ByLightBox { get { return By.Id("lightBox"); } }
        private WebElementWrapper LightBox { get; set; }
        private By ByIFrame { get { return By.Id("lightBoxFrame"); } }
        private WebElementWrapper IFrame { get; set; }

        private void WaitForFrameToDisplay()
        {
            //_currentWindow = Driver.CurrentWindowHandle;
            this.CurrentWindowHandle = Driver.CurrentWindowHandle;
            Report.Write("The current window is: '" + this.CurrentWindowHandle + "'.");
            LightBox.WaitUntilExists(3);
            IFrame.WaitUntilExists(3);
            //Driver.SwitchTo().Frame(IFrame.Element);
            DriverCommands.WaitToSwitchFrame(IFrame, 3);
        }
    }
}
