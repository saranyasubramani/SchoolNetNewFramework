using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages;

namespace UITests.Pages.UserManagement.UserManagementHome
{
    /// <summary>
    /// user management home form
    /// </summary>
    public class UserManagementHomeForm : SNForm
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public UserManagementHomeForm(string overrideControlPrefix = null)
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
            FirstName_textbox = new WebElementWrapper(ByFirstName_textbox);
            LastName_textbox = new WebElementWrapper(ByLastName_textbox);
            Username_textbox = new WebElementWrapper(ByUsername_textbox);
            Institution_dropdown = new SelectElementWrapper(new WebElementWrapper(ByInstitution_dropdown));
            IncludeChildInstitutions_chkbox = new WebElementWrapper(ByIncludeChildInstitutions_chkbox);
            Role_dropdown = new SelectElementWrapper(new WebElementWrapper(ByRole_dropdown));
        }

        /// <summary>
        /// the data
        /// </summary>
        public new UserManagementHomeData Data
        {
            get
            {
                return (UserManagementHomeData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        public By ByFirstName_textbox { get { return By.Id(ControlPrefix + "HomeControl_UserSearchCriteria1_TextBoxFirstName"); } }
        public WebElementWrapper FirstName_textbox { get; private set; }

        public By ByLastName_textbox { get { return By.Id(ControlPrefix + "HomeControl_UserSearchCriteria1_TextBoxLastName"); } }
        public WebElementWrapper LastName_textbox { get; private set; }

        public By ByUsername_textbox { get { return By.Id(ControlPrefix + "HomeControl_UserSearchCriteria1_TextBoxUsername"); } }
        public WebElementWrapper Username_textbox { get; private set; }

        public By ByInstitution_dropdown { get { return By.Id(ControlPrefix + "HomeControl_UserSearchCriteria1_InstitutionSelector1_DropDownListInstitution"); } }
        public SelectElementWrapper Institution_dropdown { get; private set; }

        public By ByIncludeChildInstitutions_chkbox { get { return By.Id(ControlPrefix + "HomeControl_UserSearchCriteria1_CheckBoxSearchChildren"); } }
        public WebElementWrapper IncludeChildInstitutions_chkbox { get; private set; }

        public By ByRole_dropdown { get { return By.Id(ControlPrefix + "HomeControl_UserSearchCriteria1_DropdownlistRole"); } }
        public SelectElementWrapper Role_dropdown { get; private set; }

        public override By BySubmit { get { return By.Id(ControlPrefix + "HomeControl_UserSearchCriteria1_ButtonSearch"); } }


        // TO BE ADDED LATER TO COMPONENTS
        // SelectCourseName method to check/uncheck checkbox 
        // Parameters:
        // WebElementWrapper checkBox 
        // bool status = true  - check the checkbox
        // bool status = false - uncheck the checkbox
        public void CheckBoxClick(WebElementWrapper checkBox, bool status)
        {
            switch (status)
            {
                case true:
                    if (!checkBox.Selected)
                    {
                        checkBox.Click();
                    }
                    break;
                case false:
                    if (checkBox.Selected)
                    {
                        checkBox.Click();
                    }
                    break;
            }
        }

        //implement methods
        public override void InputFormFields()
        {
            if (Data.FirstName != null)
            {
                FirstName_textbox.Wait(5).Clear();
                FirstName_textbox.SendKeys(Data.FirstName);
            }
            if (Data.LastName != null)
            {
                LastName_textbox.Wait(5).Clear();
                LastName_textbox.SendKeys(Data.LastName);
            }
            if (Data.Username != null)
            {
                Username_textbox.Wait(5).Clear();
                Username_textbox.SendKeys(Data.Username);
            }
            if (Data.Institution != null)
            {
                Institution_dropdown.Wait(5).SelectByText(Data.Institution);
                DriverCommands.WaitAndMeasurePageLoadTime();
                InitElements();
            }
            if (Data.IncludeChildInistutitons != null)
            {
                if (Data.IncludeChildInistutitons.Equals("1"))
                {
                    CheckBoxClick(IncludeChildInstitutions_chkbox, true);
                }
            }
            if (Data.Role != null)
            {
                Role_dropdown.Wait(5).SelectByText(Data.Role);
                DriverCommands.WaitAndMeasurePageLoadTime();
                InitElements();
            }
        }

        public override IBaseScreenView ReturnSubmitPage()
        {
            return null;
        }
        public override IBaseScreenView ReturnCancelPage()
        {
            return null;
        }
    }
}
