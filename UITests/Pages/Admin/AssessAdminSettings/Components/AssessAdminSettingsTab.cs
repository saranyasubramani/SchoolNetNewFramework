using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;

namespace UITests.Pages.Admin.AssessAdminSettings.Components
{
    /// <summary>
    /// assess admin settings tab
    /// </summary>
    public class AssessAdminSettingsTab : SNTab
    {
        /// <summary>
        /// constructor
        /// </summary>
        public AssessAdminSettingsTab()
            : base()
        {
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            BenchmarkScoreGroups_Tab = new WebElementWrapper( ByBenchmarkScoreGroups_Tab);
            DataCollectionAndMonitoring_Tab = new WebElementWrapper( ByDataCollectionAndMonitoring_Tab);
            Counts_Tab = new WebElementWrapper( ByCounts_Tab);
            TestingSubjects_Tab = new WebElementWrapper( ByTestingSubjects_Tab);
            TestProperties_Tab = new WebElementWrapper( ByTestProperties_Tab);
            ItemProperties_Tab = new WebElementWrapper( ByItemProperties_Tab);
            CustomDescription_Tab = new WebElementWrapper( ByCustomDescription_Tab);
            OnlineTesting_Tab = new WebElementWrapper( ByOnlineTesting_Tab);
            ScanItFormDefinitions_Tab = new WebElementWrapper( ByScanItFormDefinitions_Tab);
            CMSItemSharing_Tab = new WebElementWrapper( ByCMSItemSharing_Tab);
            QTIImport_Tab = new WebElementWrapper( ByQTIImport_Tab);
        }

        public By ByBenchmarkScoreGroups_Tab { get { return By.CssSelector("a[href*='ManageBenchmarkScoreGroups'"); } }
        public WebElementWrapper BenchmarkScoreGroups_Tab { get; private set; }

        public By ByDataCollectionAndMonitoring_Tab { get { return By.CssSelector("a[href*='ManageCollectionThreshold'"); } }
        public WebElementWrapper DataCollectionAndMonitoring_Tab { get; private set; }

        public By ByCounts_Tab { get { return By.CssSelector("a[href*='ShowCounts'"); } }
        public WebElementWrapper Counts_Tab { get; private set; }

        public By ByTestingSubjects_Tab { get { return By.CssSelector("a[href*='SelectBenchmarkTestSubjects'"); } }
        public WebElementWrapper TestingSubjects_Tab { get; private set; }

        public By ByTestProperties_Tab { get { return By.CssSelector("a[href*='ManageTestCategories'"); } }
        public WebElementWrapper TestProperties_Tab { get; private set; }

        public By ByItemProperties_Tab { get { return By.CssSelector("a[href*='ManageItemCategories'"); } }
        public WebElementWrapper ItemProperties_Tab { get; private set; }

        public By ByCustomDescription_Tab { get { return By.CssSelector("a[href*='EditCustomDescription'"); } }
        public WebElementWrapper CustomDescription_Tab { get; private set; }

        public By ByOnlineTesting_Tab { get { return By.CssSelector("a[href*='EditOnlineTestSettings'"); } }
        public WebElementWrapper OnlineTesting_Tab { get; private set; }

        public By ByScanItFormDefinitions_Tab { get { return By.CssSelector("a[href*='ScanItFormDefinitions'"); } }
        public WebElementWrapper ScanItFormDefinitions_Tab { get; private set; }

        public By ByCMSItemSharing_Tab { get { return By.CssSelector("a[href*='EditCMSItemSharing'"); } }
        public WebElementWrapper CMSItemSharing_Tab { get; private set; }

        public By ByQTIImport_Tab { get { return By.CssSelector("a[href*='QTIImport'"); } }
        public WebElementWrapper QTIImport_Tab { get; private set; }
    }
}
