using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Views;

namespace UITests.Pages.Assess.TestCreateEdit
{
    /// <summary>
    /// the create test express page
    /// </summary>
    public class CreateTestExpressPage : CreateTestPage
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public CreateTestExpressPage()
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            this.ExpectedUrl = "/Assess/TestBluePrinting/CreateTest.aspx?mode=0";
            this.VerifyCurrentUrl();
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            Report.Write("Martin CreateTestExpressPage.InitElements");
            base.InitElements();
        }
    }
}
