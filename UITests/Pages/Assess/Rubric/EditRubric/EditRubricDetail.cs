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
using UITests.Pages.Assess.Components;

namespace UITests.Pages.Assess.Rubric.EditRubric
{
    /// <summary>
    /// edit rubric detail
    /// </summary>
    public class EditRubricDetail : SNDetail
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="EditRubricType">item central type</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public EditRubricDetail(string overrideControlPrefix = null)
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
            BackToPreviousPageLink = new WebElementWrapper(ByBackToPreviousPageLink);
        }

        /// <summary>
        /// the data
        /// </summary>
        public new EditRubricData Data
        {
            get
            {
                return (EditRubricData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        //ctl00_AppTitle_BackToPreviousPageControl_HyperLinkBackText
        //ctl00_AppTitle_BackToPreviousPageControl_HyperLinkBack
        private By ByBackToPreviousPageLink { get { return By.Id("ctl00_AppTitle_BackToPreviousPageControl_HyperLinkBack"); } }
        private WebElementWrapper BackToPreviousPageLink { get; set; }

        /// <summary>
        /// back to previous page
        /// </summary>
        public void BackToPreviousPage()
        {
            BackToPreviousPageLink.Click();
        }
    }
}
