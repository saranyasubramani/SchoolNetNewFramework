using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages.Components;
using UITests.Pages.Assess.Standards;

namespace UITests.Pages.Assess.ItemCentral.ItemCentralStandardPicker
{
    /// <summary>
    /// the item central page with standard picker form
    /// </summary>
    public class ItemCentralStandardPickerForm : SNForm
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="itemCentralType">item central type</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public ItemCentralStandardPickerForm(ItemCentralType itemCentralType, string overrideControlPrefix = null)
            : base()
        {
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }
            this.ItemCentralType = itemCentralType;
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            StandardPicker = new StandardPickerForm(PageNames.ItemCentral, ControlPrefix);
        }

        private PageNames PageNames { get; set; }
        /// <summary>
        /// the standard picker form
        /// </summary>
        public StandardPickerForm StandardPicker { get; private set; }
        /// <summary>
        /// the item central type
        /// </summary>
        public ItemCentralType ItemCentralType { get; set; }

        public override IBaseScreenView ReturnSubmitPage()
        {
            return new ItemCentralPage(this.ItemCentralType);
        }

        public override IBaseScreenView SubmitForm()
        {
            StandardPicker.SubmitForm();
            return ReturnSubmitPage();
        }
    }
}
