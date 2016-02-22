using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;

namespace UITests.Pages.Assess.TestTunnel.Default
{
    /// <summary>
    /// the test tunnel default data
    /// </summary>
    public class DefaultData : TestData
    {
        /// <summary>
        /// constructor
        /// </summary>
        public DefaultData()
            : base(typeof(DefaultData).Assembly) { }
        /// <summary>
        /// the name of the test
        /// </summary>
        public string TestName { get; set; }
        /// <summary>
        /// tester's first name
        /// <remarks>example: Joe</remarks>
        /// </summary>
        public string TestersFirstName { get; set; }
        /// <summary>
        /// tester's last name
        /// <remarks>example: Smith</remarks>
        /// </summary>
        public string TestersLastName { get; set; }
        /// <summary>
        /// Online passcode
        /// </summary>
        public string OnlinePassCode { get; set; }
        /// <summary>
        /// Expected result. This is used to test dummy mode for get function 
        /// that return element text. 
        /// </summary>
        public string ExpectedResult { get; set; }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            this.TestName = base.GetParameterFromResxResource("TestName", testAttribute, row);
            this.TestersFirstName = base.GetParameterFromResxResource("TestersFirstName", testAttribute, row);
            this.TestersLastName = base.GetParameterFromResxResource("TestersLastName", testAttribute, row);
            this.OnlinePassCode = base.GetParameterFromResxResource("OnlinePassCode", testAttribute, row);
            this.ExpectedResult = base.GetParameterFromResxResource("ExpectedResult", testAttribute, row);
        }
    }
}
