using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;

namespace UITests.Pages.Assess.ItemCentral.ItemCentralHome.Passage
{
    /// <summary>
    /// item central: passages detail tab
    /// </summary>
    public class ItemCentralPassagesDetailTab : ItemCentralDetailTab
    {
        /// <summary>
        /// constructor
        /// </summary>
        public ItemCentralPassagesDetailTab()
            : base()
        {
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            SubjectLink = new WebElementWrapper(BySubjectLink);
            GradeLink = new WebElementWrapper(ByGradeLink);
            ItemCentralPassagesSubjectFormTab = new ItemCentralPassagesSubjectFormTab();
            ItemCentralPassagesGradeFormTab = new ItemCentralPassagesGradeFormTab();
        }

        private By BySubjectLink { get { return By.Id(ControlPrefix + "RepeaterBrowseCategories_ctl01_LinkButtonBrowseCategory"); } }
        private WebElementWrapper SubjectLink { get; set; }
        private By ByGradeLink { get { return By.Id(ControlPrefix + "RepeaterBrowseCategories_ctl02_LinkButtonBrowseCategory"); } }
        private WebElementWrapper GradeLink { get; set; }

        private ItemCentralPassagesSubjectFormTab ItemCentralPassagesSubjectFormTab { get; set; }
        private ItemCentralPassagesGradeFormTab ItemCentralPassagesGradeFormTab { get; set; }

        /// <summary>
        /// select subject tab
        /// </summary>
        public void SelectSubjectTab()
        {
            SubjectLink.Wait(3).Click();
        }
        /// <summary>
        /// select grade tab
        /// </summary>
        public void SelectGradeTab()
        {
            GradeLink.Wait(3).Click();
        }
        /// <summary>
        /// subject tab
        /// </summary>
        /// <returns>ItemCentralPassagesSubjectFormTab</returns>
        public ItemCentralPassagesSubjectFormTab SubjectTab()
        {
            return ItemCentralPassagesSubjectFormTab;
        }
        /// <summary>
        /// grade tab
        /// </summary>
        /// <returns>ItemCentralPassagesGradeFormTab</returns>
        public ItemCentralPassagesGradeFormTab GradeTab()
        {
            return ItemCentralPassagesGradeFormTab;
        }
    }
}
