using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Core.Views;
using UITests.Pages.Assess.TestDetail;
using UITests.Pages.Assess.Dashboard.ViewPortalResults;
using UITests.Pages.Assess.TestCreateEdit;

namespace UITests.Pages.Assess.Dashboard
{
    /// <summary>
    /// the assessment dashboard page for the teacher
    /// </summary>
    public class ViewPortalResultsPage : SNWebPage
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="gridName">View Portal Results Page Grid Name</param>
        public ViewPortalResultsPage(ViewPortalResultsGridNames gridName)
            : base()
        {
            GridName = gridName;
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            this.ExpectedUrl = "/Assess/ViewPortalResults.aspx";
            this.VerifyCurrentUrl();
            InitElements();
        }
        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            this.Form = new ViewPortalResultsSearchForm(GridName, this.ControlPrefix);
            this.Form.Parent = this;
            this.Detail = new ViewPortalResultsDetail(GridName, this.ControlPrefix);
            this.Detail.Parent = this;
        }

        /// <summary>
        /// the form
        /// </summary>
        public new ViewPortalResultsSearchForm Form { get; set; }

        /// <summary>
        /// the detail
        /// </summary>
        public new ViewPortalResultsDetail Detail { get; set; }

        /// <summary>
        /// the data
        /// </summary>
        public new ViewPortalResultsData Data
        {
            get
            {
                return (ViewPortalResultsData)base.Data;
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
        public ViewPortalResultsData InitData()
        {
            base.InitData(new ViewPortalResultsData());
            return (ViewPortalResultsData)base.Data;
        }
        /// <summary>
        /// initializes the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>object data</returns>
        public ViewPortalResultsData InitData(object data)
        {
            base.InitData(data);
            return (ViewPortalResultsData)base.Data;
        }

        /// <summary>
        /// View Portal Results Page Grid Name
        /// </summary>
        public ViewPortalResultsGridNames GridName { get; set; }

        //protected By BySiteTitleLabel { get { return By.CssSelector(".SiteTitle"); } }
        //protected WebElementWrapper SiteTitleLabel { get; set; }
        /// <summary>
        /// create a test
        /// </summary>
        /// <returns>CreateTestPortalPage</returns>
        public CreateTestPortalPage CreateATest()
        {
            return this.Detail.CreateATest();
        }
    }
}
