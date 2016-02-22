using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITests.Pages;
using UITests.Pages.Admin;
using UITests.Pages.Admin.AssessAdminSettings;
using UITests.Pages.Admin.GeneralSettings;
using UITests.Pages.Home;
using UITests.Workflow;

namespace UITests.Workflow.Admin
{
    /// <summary>
    /// the system admin workflows
    /// </summary>
    public class AdminWorkflows : SNComponent
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="workflows">workflows</param>
        public AdminWorkflows(Workflows workflows)
            : base()
        {
            this.Workflows = workflows;
            AssessAdminSettingsWorkflows = new AssessAdminSettingsWorkflows( this);
            GeneralSettingsWorkflows = new GeneralSettingsWorkflows( this);
        }

        //workflows
        /// <summary>
        /// Workflows
        /// </summary>
        public Workflows Workflows { get; set; }
        /// <summary>
        /// AssessAdminSettingsWorkflows
        /// </summary>
        public AssessAdminSettingsWorkflows AssessAdminSettingsWorkflows { get; set; }
        /// <summary>
        /// GeneralSettingsWorkflows
        /// </summary>
        public GeneralSettingsWorkflows GeneralSettingsWorkflows { get; set; }

        //pages
        /// <summary>
        /// HomePage
        /// </summary>
        public HomePage HomePage { get; set; }
        /// <summary>
        /// SystemOperationPage
        /// </summary>
        public SystemOperationPage SystemOperationPage { get; set; }
        /// <summary>
        /// TestPropertiesPage
        /// </summary>
        public TestPropertiesPage TestPropertiesPage { get; set; }
        /// <summary>
        /// ItemPropertiesPage
        /// </summary>
        public ItemPropertiesPage ItemPropertiesPage { get; set; }
        /// <summary>
        /// OnlineTestingPage
        /// </summary>
        public OnlineTestingPage OnlineTestingPage { get; set; }
        /// <summary>
        /// ContactUsPage
        /// </summary>
        public ContactUsPage ContactUsPage { get; set; }
        /// <summary>
        /// ConfigPage
        /// </summary>
        public ConfigPage ConfigPage { get; set; }
        /// <summary>
        /// ConfigPage
        /// </summary>
        public StudentProfilePage StudentProfilePage { get; set; }

        /// <summary>
        /// navigate to the system operation page
        /// </summary>
        /// <returns>Workflows</returns>
        public AdminWorkflows NavigateToSystemOperationPage()
        {
            if (Workflows.HomePage == null)
            {
                throw new Exception("The HomePage is null, please initialize it before trying to use it in a workflow.");
            }
            SystemOperationPage = Workflows.HomePage.Header.SelectSystem();
            return this;
        }
    }
}
