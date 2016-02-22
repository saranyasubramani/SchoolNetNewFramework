using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;

namespace UITests.Pages.Assess.TestDetail.Components
{
    /// <summary>
    /// view details link
    /// </summary>
    public class ViewDetailsLink : SNComponent
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="pageName">page name</param>
        /// <param name="overrideControlPrefix">override Control Prefix</param>
        public ViewDetailsLink(  PageNames pageName, string overrideControlPrefix = null)
            : base()
        {
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }
            switch (pageName)
            {
                case PageNames.AnswerSheetSearch:
                    //ctl00_MainContent_SelectedTestDisplayControl_HyperLinkViewDetails
                    _controlPrefix2 = ControlPrefix + "SelectedTestDisplayControl_";
                    break;
                case PageNames.TrackTestStatus:
                    //ctl00_MainContent_SelectedTestDisplayControl_HyperLinkViewDetails
                    _controlPrefix2 = ControlPrefix + "SelectedTestDisplayControl_";
                    break;
            }
            Control = new WebElementWrapper( ByViewDetailsLink);
        }

        public By ByViewDetailsLink { get { return By.Id(_controlPrefix2 + "HyperLinkViewDetails"); } }
        public WebElementWrapper Control { get; private set; }
        private string _controlPrefix2 = "";
    }
}
