using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using Core.Views.Grids;
using OpenQA.Selenium;

namespace UITests.Pages.Admin.GeneralSettings.Config
{
    /// <summary>
    /// Config form
    /// </summary>
    public class ConfigForm : SNForm
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="overrideControlPrefix">the override control prefix</param>
        public ConfigForm(string overrideControlPrefix = null)
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
            Applications_dropdown = new SelectElementWrapper(new WebElementWrapper( ByApplications_dropdown));
            //Go_button = new WebElementWrapper(Driver, ByGo_button);
            //AudioResponseCaptureEdit_image = new WebElementWrapper(Driver, ByAudioResponseCaptureEdit_image);
            //AudioResponseCaptureValue_textbox = new WebElementWrapper(Driver, ByAudioResponseCaptureValue_textbox);
            //AudioResponseCaptureSave_image = new WebElementWrapper(Driver, ByAudioResponseCaptureSave_image);
            Cache_tab = new WebElementWrapper( ByCache_tab);
            Grid = new ConfigGrid( gridCssSelector, true, this.ControlPrefix);
        }

        /// <summary>
        /// the data
        /// </summary>
        public new ConfigData Data
        {
            get
            {
                return (ConfigData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        //ctl00_MainContent_ctl00_AdminControl_SnDataGridConfig
        private string gridCssSelector { get { return "#" + ControlPrefix + "ctl00_AdminControl_SnDataGridConfig"; } }
        /// <summary>
        /// the grid
        /// </summary>
        public ConfigGrid Grid { get; private set; }
        /// <summary>
        /// submit by
        /// </summary>
        public override By BySubmit { get { return By.Id(ControlPrefix + "ctl00_AdminControl_Button1"); } }
        public By ByApplications_dropdown { get { return By.Id(ControlPrefix + "ctl00_AdminControl_DropDownListApplications"); } }
        public SelectElementWrapper Applications_dropdown { get; private set; }
        //public By ByGo_button { get { return By.Id(ControlPrefix + "ctl00_AdminControl_Button1"); } }
        //public WebElementWrapper Go_button { get; private set; }
        //public By ByAudioResponseCaptureEdit_image { get { return By.Id(ControlPrefix + "ctl00_AdminControl_SnDataGridConfig_ctl05_Image2"); } } //correct
        //public By ByAudioResponseCaptureEdit_image { get { return By.Id(ControlPrefix + "ctl00_AdminControl_SnDataGridConfig_ctl04_Image2"); } } //correct
        //public WebElementWrapper AudioResponseCaptureEdit_image { get; private set; }
        //public By ByAudioResponseCaptureValue_textbox { get { return By.Id(ControlPrefix + "ctl00_AdminControl_SnDataGridConfig_ctl05_TextBoxValue"); } } //correct
        //public By ByAudioResponseCaptureValue_textbox { get { return By.Id(ControlPrefix + "ctl00_AdminControl_SnDataGridConfig_ctl04_TextBoxValue"); } } //correct
        //public WebElementWrapper AudioResponseCaptureValue_textbox { get; private set; }
        //public By ByAudioResponseCaptureSave_image { get { return By.XPath(".//*[@id='ctl00_MainContent_ctl00_AdminControl_SnDataGridConfig']/tbody/tr[4]/td[1]/a[1]/img"); } }
        //public WebElementWrapper AudioResponseCaptureSave_image { get; private set; }
        //public By ByCache_tab { get { return By.Id(ControlPrefix + "ctl00_AdminNavigation_ProfileTabControl1_RepeaterTabs_ctl11_HyperLinkTab"); } }
        //changed for release 16.3
        public By ByCache_tab { get { return By.CssSelector("a[title='Cache']"); } }
        public WebElementWrapper Cache_tab { get; private set; }

        /// <summary>
        /// find row
        /// </summary>
        /// <returns>ConfigRow</returns>
        public ConfigRow FindRow()
        {
            return this.Grid.GetsFirstRowContainingTextToFindFromList(ConfigColumnnNames.Name, Data.Name);
        }
        /// <summary>
        /// add row
        /// </summary>
        /// <returns>ConfigRow</returns>
        public ConfigRow AddRow()
        {
            ConfigRow configRow = null;
            List<SNGridRow> list = this.Grid.GetRowList();
            foreach (var row in list)
            {
                if (row.Type == GridRowType.Header)
                {
                    configRow = (ConfigRow)row;
                    configRow.SelectAddEditElement();
                    break;
                }
            }
            return configRow;
        }
        /// <summary>
        /// edit row
        /// </summary>
        /// <returns>ConfigRow</returns>
        public ConfigRow EditRow()
        {
            ConfigRow configRow = FindRow();
            configRow.SelectAddEditElement();
            return configRow;
        }
        /// <summary>
        /// update row
        /// </summary>
        public void UpdateRow()
        {
            ConfigRow configRow = EditRow();
            this.DriverCommands.WaitAndMeasurePageLoadTime();
            InitElements();

            configRow = FindRow();
            configRow.SetValue(Data.Value);
            configRow.SelectUpdate();
            this.DriverCommands.WaitAndMeasurePageLoadTime();
            InitElements();
        }
        /// <summary>
        /// cancel row
        /// </summary>
        public void CancelRow()
        {
            ConfigRow configRow = EditRow();
            this.DriverCommands.WaitAndMeasurePageLoadTime();
            InitElements();

            configRow = FindRow();
            configRow.SelectCancel();
            this.DriverCommands.WaitAndMeasurePageLoadTime();
            InitElements();
        }
        /// <summary>
        /// delete row
        /// </summary>
        public void DeleteRow()
        {
            ConfigRow configRow = EditRow();
            this.DriverCommands.WaitAndMeasurePageLoadTime();
            InitElements();

            configRow = FindRow();
            configRow.SelectDelete();
            this.DriverCommands.WaitAndMeasurePageLoadTime();
            InitElements();
        }
        /// <summary>
        /// cache tab
        /// </summary>
        public void ClickCacheTab()
        {
            Cache_tab.Click();
        }

        /*
        // select Application
        public void SelectApplication(string Application) 
        {
            Applications_dropdown.Wait(5).SelectByText(Application);
        }

        public override void InputFormFields()
        {
            if (Data.AudioResponseCaptureEdit != null)
            {
                if (Data.AudioResponseCaptureEdit)
                {
                    AudioResponseCaptureEdit_image.Click();
                }
            }

            if (Data.AudioResponseCaptureValue != null)
            {
                AudioResponseCaptureValue_textbox.Clear();
                AudioResponseCaptureValue_textbox.SetText(Data.AudioResponseCaptureValue);
            }

            if (Data.AudioResponseCaptureSave != null)
            {
                if (Data.AudioResponseCaptureSave)
                {
                    AudioResponseCaptureSave_image.Click();
                }
            }
        }
        */

        //overridden methods

        public override void InputFormFields()
        {
            Applications_dropdown.Wait(5).SelectByText(Data.Applications);
        }
    }
}
