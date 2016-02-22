using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Views;
using UITests.Pages.Components;

namespace UITests.Pages
{
    public abstract class SNForm : Form
    {
        public SNForm() : base()
        {
            DriverCommands = new SNDriverCommands();
            Utilities = new SNGlobalUtilities();
        }

        protected new SNDriverCommands DriverCommands { get; set; }
        protected SNGlobalUtilities Utilities { get; set; }

        public new SNWebPage Parent { get; set; }

        public override void ClearForm()
        {
            throw new NotImplementedException();
        }

        public override void InputFormFields()
        {
            throw new NotImplementedException();
        }

        public override void InputAllFieldsExcept(List<string> excludeFields)
        {
            throw new NotImplementedException();
        }

        public override IBaseScreenView ReturnSubmitPage()
        {
            return null;
        }

        public override IBaseScreenView ReturnCancelPage()
        {
            return null;
        }

        public override void VerifyErrorsForRequiredFields()
        {
            throw new NotImplementedException();
        }

        public override void VerifyErrorForRequiredField(List<string> requiredFields)
        {
            throw new NotImplementedException();
        }

        public override void VerifyErrorForInvalidField(List<string> invalidFields)
        {
            throw new NotImplementedException();
        }

        public override void VerifyFieldsAreDeselected()
        {
            throw new NotImplementedException();
        }

        public override void VerifyFieldsAreEmpty()
        {
            throw new NotImplementedException();
        }

        public override void VerifyFieldsExist()
        {
            throw new NotImplementedException();
        }

        public override void VerifyFieldsValues()
        {
            throw new NotImplementedException();
        }

        public override void VerifyFieldSelectedOption(List<string> requiredFields, object parameter)
        {
            throw new NotImplementedException();
        }

        public override void VerifyFieldsAreEnabled(List<string> includeFields)
        {
            throw new NotImplementedException();
        }

        public override void VerifyFieldsAreDisabled(List<string> includeFields)
        {
            throw new NotImplementedException();
        }

        public override void VerifyFieldsAreVisible(List<string> includeFields)
        {
            throw new NotImplementedException();
        }

        public override void VerifyFieldsAreInvisible(List<string> includeFields)
        {
            throw new NotImplementedException();
        }

        public override void VerifyFieldsListOfValues(List<string> includeFields)
        {
            throw new NotImplementedException();
        }
    }
}
