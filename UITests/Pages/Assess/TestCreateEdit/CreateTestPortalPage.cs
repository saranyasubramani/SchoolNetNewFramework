using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITests.Pages.Assess.TestDetail.Components;
using System.Reflection;
using Core.Views;
using UITests.Pages.Assess.TestCreateEdit.CreateTestPortal;

namespace UITests.Pages.Assess.TestCreateEdit
{
    /// <summary>
    /// the create test portal page
    /// </summary>
    public class CreateTestPortalPage : SNWebPage
    {
        /// <summary>
        /// constructor
        /// </summary>
        public CreateTestPortalPage()
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            this.ExpectedUrl = "/Assess/CreateTestPortal.aspx";
            this.VerifyCurrentUrl();
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            this.Detail = new CreateTestPortalDetail();
            this.Detail.Parent = this;
        }
        /// <summary>
        /// the create test portal detail
        /// </summary>
        public new CreateTestPortalDetail Detail { get; set; }

        /// <summary>
        /// the data
        /// </summary>
        public new CreateTestPortalData Data
        {
            get
            {
                return (CreateTestPortalData)base.Data;
            }
            set
            {
                base.Data = value;
                this.Detail.Data = value;
            }
        }
        /// <summary>
        /// intializes the data
        /// </summary>
        /// <returns>object data</returns>
        public new CreateTestPortalData InitData()
        {
            base.InitData(new CreateTestPortalData());
            return (CreateTestPortalData)base.Data;
        }
        /// <summary>
        /// initializes the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>object data</returns>
        public CreateTestPortalData InitData(object data)
        {
            base.InitData(data);
            return (CreateTestPortalData)base.Data;
        }
    }
}
