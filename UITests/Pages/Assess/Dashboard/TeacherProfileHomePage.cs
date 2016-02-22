using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using UITests.Pages.Assess.Dashboard.TeacherProfileHome;
using UITests.Pages.Assess.Dashboard.ProfileHome;
using UITests.Pages.Assess.Dashboard.ProfileHome.Tabs;
using UITests.Pages.Assess.ItemCentral;
using UITests.Pages.Assess.ItemCreateEdit.v01;
using UITests.Pages.Assess.TestDetail;
using UITests.Pages.Assess.TestCentral;
using UITests.Pages.Assess.TestCreateEdit;

namespace UITests.Pages.Assess.Dashboard
{
    /// <summary>
    /// the assessment dashboard page for the teacher
    /// </summary>
    public class TeacherProfileHomePage : ProfileHomePage
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="tabName">the tab name - defaults to ActiveTests</param>
        public TeacherProfileHomePage(ProfileHomeTabNames tabName = ProfileHomeTabNames.ActiveTests)
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            TabName = tabName;
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            this.Form = new ProfileHomeForm();
            this.Form.Parent = this;
            this.Detail = new TeacherProfileHomeDetail(TabName);
            this.Detail.Parent = this;
            //stop hover over menu
            this.Utilities.FocusOnMainContentArea();
        }
        /// <summary>
        /// the detail
        /// </summary>
        public new TeacherProfileHomeDetail Detail;

        /// <summary>
        /// the tab name
        /// </summary>
        public ProfileHomeTabNames TabName { get; set; }

        /// <summary>
        /// the data
        /// </summary>
        public new TeacherProfileHomeData Data
        {
            get
            {
                return (TeacherProfileHomeData)base.Data;
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
        public TeacherProfileHomeData InitData()
        {
            base.InitData(new TeacherProfileHomeData());
            return (TeacherProfileHomeData)base.Data;
        }
        /// <summary>
        /// initializes the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>object data</returns>
        public TeacherProfileHomeData InitData(object data)
        {
            base.InitData(data);
            return (TeacherProfileHomeData)base.Data;
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
        /// <summary>
        /// create
        /// </summary>
        public void Create()
        {
            this.Detail.Create();
        }
        /// <summary>
        /// find
        /// </summary>
        public void Find()
        {
            this.Detail.Find();
        }
    }
}
