using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Views;
using UITests.Pages.Assess.TestDetail.Components;
using UITests.Pages.Assess.TestDetail.TrackTestStatus;

namespace UITests.Pages.Assess.TestDetail
{
    /// <summary>
    /// the track test status page
    /// </summary>
    public class TrackTestStatusPage : SNWebPage
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public TrackTestStatusPage()
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            this.ExpectedUrl = "/Assess/TrackTestResults.aspx";
            this.VerifyCurrentUrl();
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            this.Detail = new TrackTestStatusDetail();
            this.Detail.Parent = this;
        }
        /// <summary>
        /// the detail
        /// </summary>
        public new TrackTestStatusDetail Detail { get; set; }
    }
}
