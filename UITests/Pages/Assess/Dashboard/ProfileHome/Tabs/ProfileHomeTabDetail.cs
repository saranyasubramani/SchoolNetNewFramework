using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Core.Tools.WebDriver;

namespace UITests.Pages.Assess.Dashboard.ProfileHome.Tabs
{
    /// <summary>
    /// profile home tab detail
    /// </summary>
    public class ProfileHomeTabDetail : SNDetail
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="tabName">tab name</param>
        /// <param name="overrideControlPrefix">override Control Prefix</param>
        public ProfileHomeTabDetail(ProfileHomeTabNames tabName, string overrideControlPrefix = null)
            : base()
        {
            TabName = tabName;
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
            SearchForm = new ProfileHomeTabSearchForm(TabName);
            this.SearchForm.Parent = this.Parent;
            Grid = new ProfileHomeTabGrid(gridCssSelector, true, ControlPrefix);
        }

        /// <summary>
        /// tab name
        /// </summary>
        public ProfileHomeTabNames TabName { get; set; }
        /// <summary>
        /// the form
        /// </summary>
        public ProfileHomeTabSearchForm SearchForm { get; set; }
        private string gridCssSelector { get { return "#" + ControlPrefix + "ProfileControl_gridResults"; } }
        /// <summary>
        /// the grid
        /// </summary>
        public new ProfileHomeTabGrid Grid { get; set; }
    }
}
