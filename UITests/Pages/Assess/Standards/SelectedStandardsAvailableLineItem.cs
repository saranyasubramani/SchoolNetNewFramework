using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages.Components;

namespace UITests.Pages.Assess.Standards
{
    /// <summary>
    /// selected standard available line item
    /// </summary>
    public class SelectedStandardsAvailableLineItem : SNForm
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="element"></param>
        /// <param name="standardId"></param>
        /// <param name="controlId"></param>
        public SelectedStandardsAvailableLineItem(IWebElement element, int standardId, string controlId)
            : base()
        {
            this.Element = element;
            this.StandardId = standardId;
            this.ControlId = controlId;
            InitElements();
        }
        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            RemoveStandard_Link = new WebElementWrapper(ByRemoveStandard_Link);
            ItemsStandard_Text = new WebElementWrapper(ByItemsStandard_Text);
        }

        /// <summary>
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
            }
        }
        /// <summary>
        /// IWebElement
        /// </summary>
        public IWebElement Element { get; private set; }
        /// <summary>
        /// standard ID
        /// </summary>
        public int StandardId { get; private set; }
        /// <summary>
        /// standard name
        /// </summary>
        public string StandardName { get; private set; }
        private string ControlId { get; set; }
        //ctl00_MainContent_TestMapControl1_RepeaterTestMap_ctl00_LinkButtonRemoveStandard
        //ctl00_MainContent_TestMapControl1_RepeaterTestMap_ctl01_LinkButtonRemoveStandard
        private By ByRemoveStandard_Link { get { return By.Id(ControlPrefix + "TestMapControl1_RepeaterTestMap_" + getUniqueId() + "_LinkButtonRemoveStandard"); } }
        private WebElementWrapper RemoveStandard_Link { get; set; }
        //ctl00_MainContent_TestMapControl1_RepeaterTestMap_ctl00_TextBoxItems
        //ctl00_MainContent_TestMapControl1_RepeaterTestMap_ctl01_TextBoxItems
        private By ByItemsStandard_Text { get { return By.Id(ControlId); } }
        private WebElementWrapper ItemsStandard_Text { get; set; }

        private string getUniqueId()
        {
            int from = ControlId.IndexOf("_ctl") + "_ctl".Length;
            int to = ControlId.LastIndexOf("_");
            string index = ControlId.Substring(from, to - from);
            string uniqueId = "ctl" + index;
            return uniqueId;
        }
        /// <summary>
        /// remove
        /// </summary>
        public void Remove()
        {
            RemoveStandard_Link.Wait(3).Click();
        }
        /// <summary>
        /// set item quantity
        /// </summary>
        /// <param name="quantity"></param>
        public void SetItemQuantity(int quantity)
        {
            ItemsStandard_Text.Wait(3).SendKeys("" + quantity);
        }
    }
}
