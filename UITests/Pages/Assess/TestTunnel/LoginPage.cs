using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Views;
using UITests.Pages.Assess.TestTunnel.Login;

namespace UITests.Pages.Assess.TestTunnel
{
    /// <summary>
    /// the test tunnel login page
    /// </summary>
    public class LoginPage : SNWebPage
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public LoginPage()
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            //https://team-automation-st.sndev.net/onlinetest/Login.aspx?secure=1
            this.ExpectedUrl = "/onlinetest/Login.aspx";
            this.VerifyCurrentUrl();
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            this.Form = new LoginForm();
            this.Form.Parent = this;
            this.Header = new LoginHeader();
            this.Header.Parent = this;
        }
        /// <summary>
        /// the form
        /// </summary>
        public new LoginForm Form { get; set; }
        /// <summary>
        /// the header
        /// </summary>
        public new LoginHeader Header { get; set; }

        /// <summary>
        /// the data
        /// </summary>
        public new LoginData Data
        {
            get
            {
                return (LoginData)base.Data;
            }
            set
            {
                base.Data = value;
                this.Form.Data = value;
                this.Header.Data = value;
            }
        }
        /// <summary>
        /// intializes the data
        /// </summary>
        /// <returns>object data</returns>
        public new LoginData InitData()
        {
            base.InitData(new LoginData());
            return (LoginData)base.Data;
        }
        /// <summary>
        /// initializes the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>object data</returns>
        public LoginData InitData(object data)
        {
            base.InitData(data);
            return (LoginData)base.Data;
        }
    }
}
