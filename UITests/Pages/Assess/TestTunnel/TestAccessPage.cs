using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Views;
using UITests.Pages.Assess.TestTunnel.TestAccess;

namespace UITests.Pages.Assess.TestTunnel
{
    /// <summary>
    /// the test tunnel access page
    /// </summary>
    public class TestAccessPage : SNWebPage
    {
        /// <summary>
        /// constructor
        /// </summary>
        public TestAccessPage()
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            //https://team-automation-st.sndev.net/onlinetest/TestAccess.aspx?test_code=CU9VU4
            this.ExpectedUrl = "/onlinetest/TestAccess.aspx";
            this.VerifyCurrentUrl();
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            this.Form = new TestAccessForm();
            this.Form.Parent = this;
            this.Header = new TestAccessHeader();
            this.Header.Parent = this;
        }
        /// <summary>
        /// the form
        /// </summary>
        public new TestAccessForm Form { get; set; }
        /// <summary>
        /// the header
        /// </summary>
        public new TestAccessHeader Header { get; set; }

        /// <summary>
        /// the data
        /// </summary>
        public new TestAccessData Data
        {
            get
            {
                return (TestAccessData)base.Data;
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
        public new TestAccessData InitData()
        {
            base.InitData(new TestAccessData());
            return (TestAccessData)base.Data;
        }
        /// <summary>
        /// initializes the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>object data</returns>
        public TestAccessData InitData(object data)
        {
            base.InitData(data);
            return (TestAccessData)base.Data;
        }
    }
}
