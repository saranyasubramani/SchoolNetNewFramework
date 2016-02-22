using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages.Assess.Components;
using UITests.Pages.Assess.ItemCreateEdit.v01.Components;

namespace UITests.Pages.Assess.ItemCreateEdit.v01.EditItemAvailability
{
    /// <summary>
    /// The edit item availability form
    /// </summary>
    public class EditItemAvailabilityForm : SNForm
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public EditItemAvailabilityForm(string overrideControlPrefix = null)
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
            SharingItem = new ShareWithOtherUser(PageNames.EditItemAvailability);
        }

        /// <summary>
        /// the data
        /// </summary>
        public new EditItemAvailabilityData Data
        {
            get
            {
                return (EditItemAvailabilityData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        /// <summary>
        /// cancel by
        /// </summary>
        public override By ByCancel { get { return By.Id(ControlPrefix + "ButtonCancel"); } }
        /// <summary>
        /// submit by
        /// </summary>
        public override By BySubmit { get { return By.Id(ControlPrefix + "ButtonSave"); } }
        /// <summary>
        /// share item with other users component
        /// </summary>
        public ShareWithOtherUser SharingItem { get; set; }
        private List<CoAuthor> CoAuthorsList { get; set; }

        /// <summary>
        /// co-authors list
        /// </summary>
        /// <returns></returns>
        public List<CoAuthor> GetCoAuthorsList()
        {
            return CoAuthorsList;
        }

        /// <summary>
        /// only to me
        /// </summary>
        public void ClickOnlyMe()
        {
            SharingItem.SelectOnlyToMe();
            DriverCommands.WaitAndMeasurePageLoadTime(90, 30);
            InitElements();
        }
        /// <summary>
        /// share with others
        /// </summary>
        public void ClickShareWithOthers()
        {
            SharingItem.SelectShareWithOthers();
            DriverCommands.WaitAndMeasurePageLoadTime(90, 30);
            InitElements();
        }
        /// <summary>
        /// share with everyone
        /// </summary>
        public void ClickShareWithEveryone()
        {
            SharingItem.SelectEveryone();
            DriverCommands.WaitAndMeasurePageLoadTime(90, 30);
            InitElements();
        }

        //implemented methods
        public override void InputFormFields()
        {
            SharingItem.InputFormFields();
            DriverCommands.WaitAndMeasurePageLoadTime(90, 30);
            InitElements();
        }
    }
}
