using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;

namespace UITests.Pages.Login.Components
{
    /// <summary>
    /// authentication data
    /// </summary>
    public class AuthenticationData : TestData
    {
        /// <summary>
        /// constructor
        /// </summary>
        public AuthenticationData()
            : base(typeof(AuthenticationData).Assembly) { }
        public string DistrictName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string UsernameErrorMessage { get; set; }
        public string PasswordErrorMessage { get; set; }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            this.DistrictName = base.GetParameterFromResxResource("DistrictName", testAttribute, row);
            this.Username = base.GetParameterFromResxResource("Username", testAttribute, row);
            this.Password = base.GetParameterFromResxResource("Password", testAttribute, row);
            this.UsernameErrorMessage = base.GetParameterFromResxResource("UsernameErrorMessage", testAttribute, row);
            this.PasswordErrorMessage = base.GetParameterFromResxResource("PasswordErrorMessage", testAttribute, row);
        }
    }
}
