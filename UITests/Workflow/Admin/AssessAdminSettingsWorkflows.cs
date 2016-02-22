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
    public class AssessAdminSettingsWorkflows : SNComponent
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="workflows">workflows</param>
        public AssessAdminSettingsWorkflows( AdminWorkflows workflows)
            : base()
        {
            AdminWorkflows = workflows;
        }
        //workflows
        private AdminWorkflows AdminWorkflows { get; set; }

        /// <summary>
        /// navigate to the assessment admin settings > test properties tab
        /// </summary>
        /// <returns>Workflows</returns>
        public AssessAdminSettingsWorkflows NavigateToTestPropertiesPage()
        {
            AdminWorkflows.NavigateToSystemOperationPage();
            if (AdminWorkflows.SystemOperationPage == null)
            {
                throw new Exception("Navigate to the SystemOperationPage before trying to use this workflow.");
            }
            AdminWorkflows.TestPropertiesPage = AdminWorkflows.SystemOperationPage.Detail.Navigate_to_Test_Properties();
            return this;
        }
        /// <summary>
        /// navigate to the assessment admin settings > item properties tab
        /// </summary>
        /// <returns>Workflows</returns>
        public AssessAdminSettingsWorkflows NavigateToItemPropertiesPage()
        {
            AdminWorkflows.NavigateToSystemOperationPage();
            //SystemOperationPage = AdminWorkflows.SystemOperationPage;
            if (AdminWorkflows.SystemOperationPage == null)
            {
                throw new Exception("Navigate to the SystemOperationPage before trying to use this workflow.");
            }
            AdminWorkflows.ItemPropertiesPage = AdminWorkflows.SystemOperationPage.Detail.Navigate_to_Item_Properties();
            return this;
        }

        /// <summary>
        /// on item properties tab, select all languages
        /// </summary>
        /// <returns>Workflows</returns>
        public AssessAdminSettingsWorkflows SelectAllLanguages()
        {
            if (AdminWorkflows.ItemPropertiesPage == null)
            {
                throw new Exception("Navigate to the SystemOperationPage > Item Properties tab before trying to use this workflow.");
            }
            AdminWorkflows.ItemPropertiesPage.Form.Language.InputFormFields();
            AdminWorkflows.ItemPropertiesPage.Form.Language.VerifyFieldsAreSelected();
            AdminWorkflows.ItemPropertiesPage.Form.Language.SubmitForm();
            return this;
        }

        /// <summary>
        /// navigate to the assessment admin settings > online testing tab
        /// </summary>
        /// <returns>Workflows</returns>
        public AssessAdminSettingsWorkflows NavigateToOnlineTestingPage()
        {
            AdminWorkflows.NavigateToSystemOperationPage();
            if (AdminWorkflows.SystemOperationPage == null)
            {
                throw new Exception("Navigate to the SystemOperationPage before trying to use this workflow.");
            }
            AdminWorkflows.OnlineTestingPage = AdminWorkflows.SystemOperationPage.Detail.Navigate_to_Online_Testing();
            return this;
        }
    }
}
