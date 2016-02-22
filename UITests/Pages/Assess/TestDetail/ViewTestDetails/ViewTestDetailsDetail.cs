using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages.Controls;

namespace UITests.Pages.Assess.TestDetail.ViewTestDetails
{
    /// <summary>
    /// the view test details content
    /// </summary>
    public class ViewTestDetailsDetail : SNDetail
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="overrideControlPrefix"></param>
        public ViewTestDetailsDetail( string overrideControlPrefix = null)
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
            PreviousPageBottomLink = new PreviousPageBottomLink(PageNames.ViewTestDetails, ControlPrefix);
        }

        /// <summary>
        /// the data
        /// </summary>
        public new ViewTestDetailsData Data
        {
            get
            {
                return (ViewTestDetailsData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        public PreviousPageBottomLink PreviousPageBottomLink { get; set; }

        /// <summary>
        /// back to previous page
        /// </summary>
        public void BackToPreviousPage()
        {
            PreviousPageBottomLink.Control.Wait(3).Click();
        }
    }
}
