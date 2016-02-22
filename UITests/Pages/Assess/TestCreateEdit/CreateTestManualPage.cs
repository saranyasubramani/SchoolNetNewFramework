using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Views;
using UITests.Pages.Assess.TestCreateEdit.Components;
using UITests.Pages.Assess.TestCreateEdit.CreateTestManual;

namespace UITests.Pages.Assess.TestCreateEdit
{
    /// <summary>
    /// the create test manual page
    /// </summary>
    public class CreateTestManualPage : CreateTestPage
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public CreateTestManualPage(CreateTestModes createTestMode = CreateTestModes.CreateManualTest)
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            if (createTestMode == CreateTestModes.CreateManualTest)
            {
                urlMode = "1";
            }
            if (createTestMode == CreateTestModes.CreateCopyOfTest)
            {
                urlMode = "ByQuestionNumber";
            }
            this.ExpectedUrl = "/Assess/TestBluePrinting/CreateTest.aspx?mode=" + urlMode;
            this.VerifyCurrentUrl();
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            Report.Write("Martin CreateTestManualPage.InitElements");
            this.Form = new CreateTestManualForm();
            this.Form.Parent = this;
        }
        /// <summary>
        /// the form
        /// </summary>
        public new CreateTestManualForm Form { get; set; }

        /// <summary>
        /// the data
        /// </summary>
        public new CreateTestManualData Data
        {
            get
            {
                return (CreateTestManualData)base.Data;
            }
            set
            {
                Report.Write("Martin CreateTestManualPage.Data");
                base.Data = value;
                this.Form.Data = value;
            }
        }
        /// <summary>
        /// intializes the data
        /// </summary>
        /// <returns>object data</returns>
        public new CreateTestManualData InitData()
        {
            base.InitData(new CreateTestManualData());
            return (CreateTestManualData)base.Data;
        }
        /// <summary>
        /// initializes the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>object data</returns>
        public CreateTestManualData InitData(object data)
        {
            base.InitData(data);
            return (CreateTestManualData)base.Data;
        }

        /// <summary>
        /// Value for Mode Query String Parameter in the Page URL
        /// </summary>
        private string urlMode; 
    }
}
