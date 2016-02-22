using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;

namespace UITests.Pages.Assess.TestTunnel.Login
{
    /// <summary>
    /// the test tunnel login data
    /// </summary>
    public class LoginData : TestData
    {
        /// <summary>
        /// constructor
        /// </summary>
        public LoginData()
            : base(typeof(LoginData).Assembly) { }
        public string Passcode { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            this.Passcode = base.GetParameterFromResxResource("Passcode", testAttribute, row);
            this.Username = base.GetParameterFromResxResource("Username", testAttribute, row);
            this.Password = base.GetParameterFromResxResource("Password", testAttribute, row);
        }
    }
}
