using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Views;
using UITests.Pages.Assess.TestDetail.Components;
using UITests.Pages.Assess.TestCreateEdit.CreateTestBySelectingStandards;

namespace UITests.Pages.Assess.TestCreateEdit
{
    /// <summary>
    /// the create test by selecting standards page
    /// </summary>
    public class CreateTestBySelectingStandardsPage : SNWebPage
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public CreateTestBySelectingStandardsPage()
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            this.ExpectedUrl = "/Assess/TestBluePrinting/CreateTestBySelectingStandards.aspx";
            this.VerifyCurrentUrl();
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            this.Form = new CreateTestBySelectingStandardsForm();
            this.Form.Parent = this;
            this.Detail = new CreateTestBySelectingStandardsDetail();
            this.Detail.Parent = this;
        }
        /// <summary>
        /// the form
        /// </summary>
        public new CreateTestBySelectingStandardsForm Form { get; set; }
        /// <summary>
        /// the form
        /// </summary>
        public new CreateTestBySelectingStandardsDetail Detail { get; set; }

        /// <summary>
        /// the data
        /// </summary>
        public new CreateTestBySelectingStandardsData Data
        {
            get
            {
                return (CreateTestBySelectingStandardsData)base.Data;
            }
            set
            {
                base.Data = value;
                this.Form.Data = value;
                this.Detail.Data = value;
            }
        }
        /// <summary>
        /// intializes the data
        /// </summary>
        /// <returns>object data</returns>
        public new CreateTestBySelectingStandardsData InitData()
        {
            base.InitData(new CreateTestBySelectingStandardsData());
            return (CreateTestBySelectingStandardsData)base.Data;
        }
        /// <summary>
        /// initializes the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>object data</returns>
        public CreateTestBySelectingStandardsData InitData(object data)
        {
            base.InitData(data);
            return (CreateTestBySelectingStandardsData)base.Data;
        }
    }
}
