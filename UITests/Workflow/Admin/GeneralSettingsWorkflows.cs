using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITests.Pages;
using UITests.Pages.Admin;
using UITests.Pages.Home;

namespace UITests.Workflow.Admin
{
    /// <summary>
    /// the assessment admin settings workflows
    /// </summary>
    public class GeneralSettingsWorkflows : SNComponent
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="workflows">workflows</param>
        public GeneralSettingsWorkflows( AdminWorkflows workflows)
            : base()
        {
            AdminWorkflows = workflows;
        }
        //workflows
        private AdminWorkflows AdminWorkflows { get; set; }

        /// <summary>
        /// navigate to the general settings > contact us tab
        /// </summary>
        /// <returns>Workflows</returns>
        public GeneralSettingsWorkflows NavigateToContactUsPage()
        {
            AdminWorkflows.NavigateToSystemOperationPage();
            if (AdminWorkflows.SystemOperationPage == null)
            {
                throw new Exception("Navigate to the SystemOperationPage before trying to use this workflow.");
            }
            AdminWorkflows.ContactUsPage = AdminWorkflows.SystemOperationPage.Detail.Navigate_to_ContactUs();
            return this;
        }

        /// <summary>
        /// navigate to the general settings > config tab
        /// </summary>
        /// <returns>Workflows</returns>
        public GeneralSettingsWorkflows NavigateToConfigPage()
        {
            AdminWorkflows.NavigateToSystemOperationPage();
            if (AdminWorkflows.SystemOperationPage == null)
            {
                throw new Exception("Navigate to the SystemOperationPage before trying to use this workflow.");
            }
            AdminWorkflows.ConfigPage = AdminWorkflows.SystemOperationPage.Detail.Navigate_to_Config();
            return this;
        }

        /// <summary>
        /// navigate to the general settings > student profile tab
        /// </summary>
        /// <returns>Workflows</returns>
        public GeneralSettingsWorkflows NavigateToStudentProfilePage()
        {
            AdminWorkflows.NavigateToSystemOperationPage();
            if (AdminWorkflows.SystemOperationPage == null)
            {
                throw new Exception("Navigate to the SystemOperationPage before trying to use this workflow.");
            }
            AdminWorkflows.StudentProfilePage = AdminWorkflows.SystemOperationPage.Detail.Navigate_to_StudentProfile();
            return this;
        }
    }
}
