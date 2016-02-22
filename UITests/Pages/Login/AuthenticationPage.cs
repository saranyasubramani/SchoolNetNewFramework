using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Views;
using UITests.Pages.Login.Components;
using UITests.Pages.Home;

namespace UITests.Pages.Login
{
    /// <summary>
    /// authentication page
    /// </summary>
    public class AuthenticationPage : SNWebPage
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public AuthenticationPage() : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            this.ExpectedUrl = "/Authentication.aspx";
            this.VerifyCurrentUrl();
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            this.Form = new AuthenticationForm();
            this.Form.Parent = this;
        }
        /// <summary>
        /// the form
        /// </summary>
        public new AuthenticationForm Form { get; set; }

        /// <summary>
        /// the data
        /// </summary>
        public new AuthenticationData Data
        {
            get
            {
                return (AuthenticationData) base.Data;
            }
            set
            {
                base.Data = value;
                this.Form.Data = value;
            }
        }
        /// <summary>
        /// intializes the data
        /// </summary>
        /// <returns>object data</returns>
        public new AuthenticationData InitData()
        {
            base.InitData(new AuthenticationData());
            return (AuthenticationData) base.Data;
        }
        /// <summary>
        /// initializes the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>object data</returns>
        public AuthenticationData InitData(object data)
        {
            base.InitData(data);
            return (AuthenticationData) base.Data;
        }

        /// <summary>
        /// log in
        /// </summary>
        /// <returns>HomePage</returns>
        public HomePage Login()
        {
            return (HomePage)this.Form.InputAndSubmitForm();
        }

        /// <summary>
        /// verify signed out
        /// </summary>
        public void VerifySignedOut()
        {
            ((AuthenticationForm)this.Form).Username.Wait(5);
            this.PrintName();
            this.VerifyCurrentUrl();
        }
    }
}
