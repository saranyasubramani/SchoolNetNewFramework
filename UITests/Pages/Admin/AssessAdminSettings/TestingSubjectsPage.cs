using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Views;

namespace UITests.Pages.Admin.AssessAdminSettings
{
    /// <summary>
    /// testing subjects page
    /// </summary>
    public class TestingSubjectsPage : SNWebPage
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public TestingSubjectsPage()
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            //https://team-automation-st.sndev.net/admin/?&admin_current_app_tab_id=5e10edea-eb8b-4000-b8cd-91a9ec533c89&admin_current_control_src=~/Assess/AdminControls/SelectBenchmarkTestSubjects.ascx&snidx=5
            this.ExpectedUrl = "/admin/";
            this.VerifyCurrentUrl();
            this.VerifyCurrentUrlQueryStringParameters("/Assess/AdminControls/SelectBenchmarkTestSubjects.ascx");
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
        }
    }
}
