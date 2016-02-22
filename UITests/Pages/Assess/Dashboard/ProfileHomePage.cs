using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Core.Views;
using UITests.Pages.Assess.ItemCentral;
using UITests.Pages.Assess.ItemCreateEdit.v01;
using UITests.Pages.Assess.TestDetail;
using UITests.Pages.Assess.TestCentral;
using UITests.Pages.Assess.Dashboard.ProfileHome;
using UITests.Pages.Assess.TestCreateEdit;

namespace UITests.Pages.Assess.Dashboard
{
    /// <summary>
    /// the assessment dashboard page
    /// </summary>
    public class ProfileHomePage : SNWebPage
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public ProfileHomePage()
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            this.ExpectedUrl = "/Assess/ProfileHome.aspx";
            this.VerifyCurrentUrl();
            InitElements();
        }
        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            this.Form = new ProfileHomeForm();
            this.Form.Parent = this;
            this.Detail = new ProfileHomeDetail();
            this.Detail.Parent = this;
        }
        /// <summary>
        /// the form
        /// </summary>
        public new ProfileHomeForm Form { get; set; }
        /// <summary>
        /// the detail
        /// </summary>
        public new ProfileHomeDetail Detail { get; set; }
        /// <summary>
        /// the data
        /// </summary>
        public new ProfileHomeData Data
        {
            get
            {
                return (ProfileHomeData)base.Data;
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
        public ProfileHomeData InitData()
        {
            base.InitData(new ProfileHomeData());
            return (ProfileHomeData)base.Data;
        }
        /// <summary>
        /// initializes the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>object data</returns>
        public ProfileHomeData InitData(object data)
        {
            base.InitData(data);
            return (ProfileHomeData)base.Data;
        }
        /// <summary>
        /// find a test
        /// </summary>
        /// <returns>TestCentralHomePage</returns>
        public TestCentralHomePage FindATest()
        {
            return this.Detail.FindATest();
        }
        /// <summary>
        /// find an item
        /// </summary>
        /// <returns>ItemCentralHomePage</returns>
        public ItemCentralHomePage FindAnItem()
        {
            return this.Detail.FindAnItem();
        }
        /// <summary>
        /// create a test
        /// </summary>
        /// <returns>CreateTestPortalPage</returns>
        public CreateTestPortalPage CreateATest()
        {
            return this.Detail.CreateATest();
        }
        /// <summary>
        /// create an item
        /// </summary>
        /// <returns>EditTestItemChooseNewItemPage</returns>
        public EditTestItemChooseNewItemPage CreateAnItem()
        {
            return this.Detail.CreateAnItem();
        }
    }
}
