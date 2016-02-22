using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITests.Framework;
using UITests.Pages.Login;
using UITests.Pages.Login.Components;
using UITests.Pages.Home;

namespace UnitTests.Pages.Login
{
    public class AuthenticationTest
    {
        public void testLocators(SchoolNet schoolnet)
        {
            schoolnet.LoadWebPage();
            AuthenticationPage page = new AuthenticationPage();
            AuthenticationForm form = page.Form;
            Assert.AreEqual("By.CssSelector: .btn.btn-primary.SignInButton", form.BySubmit.ToString(), "BySubmit locator matches");
            Assert.AreEqual("By.Id: ctl02_ddlListProvider", form.ByDistrictName.ToString(), "BySubmit locator matches");
            Assert.AreEqual("By.Id: ctl02_TextBoxUsername", form.ByUsername.ToString(), "BySubmit locator matches");
            Assert.AreEqual("By.Id: ctl02_TextBoxPassword", form.ByPassword.ToString(), "BySubmit locator matches");
            /*
            Assert.AreEqual(form.ByErrorMessages.ToString(), "By.selector: .alert.alert-error", "BySubmit locator matches");
            Assert.AreEqual(form.ByTroubleSigningInLinkLink.ToString(), "By.selector: #ctl02_liForgetPasswordLink > a", "BySubmit locator matches");
            */
        }

        public void testClearForm(SchoolNet schoolnet)
        {
            schoolnet.LoadWebPage();
            AuthenticationPage page = new AuthenticationPage();
            page.Form.ClearForm();
        }

        public void testInputAndSubmitForm(SchoolNet schoolnet)
        {
            schoolnet.LoadWebPage();
            AuthenticationPage page = new AuthenticationPage();
            AuthenticationData data = new AuthenticationData();
            data.DistrictName = "National";
            data.Username = "sn_qa";
            data.Password = "sch00lnet";
            page.Data = data;
            HomePage homePage = (HomePage)page.Form.InputAndSubmitForm();
        }

        public void testInputAndSubmitFormAndVerifyErrors(SchoolNet schoolnet)
        {
            schoolnet.LoadWebPage();
            AuthenticationPage page = new AuthenticationPage();
            AuthenticationData data = new AuthenticationData();
            data.DistrictName = "";
            data.Username = "";
            data.Password = "";
            page.Data = data;
            page.Form.InputAndSubmitFormWithErrors();
        }
    }
}
