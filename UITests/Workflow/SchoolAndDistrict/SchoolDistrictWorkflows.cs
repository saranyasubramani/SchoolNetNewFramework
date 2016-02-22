using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITests.Pages;
using UITests.Pages.Home;
using UITests.Pages.SchoolAndDistrict;
using UITests.Pages.SchoolAndDistrict.Dashboard;
using UITests.Pages.SchoolAndDistrict.Student;
using UITests.Workflow;

namespace UITests.Workflow.SchoolAndDistrict
{
    /// <summary>
    /// the SchoolDistrictment workflows
    /// </summary>
    public class SchoolDistrictWorkflows : SNComponent
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="workflows">workflows</param>
        public SchoolDistrictWorkflows(Workflows workflows)
            : base()
        {
            this.Workflows = workflows;
            StudentProfileWorkflows = new StudentProfileWorkflows(this);
        }

        //workflows
        /// <summary>
        /// Workflows
        /// </summary>
        public Workflows Workflows { get; set; }
        /// <summary>
        /// StudentProfileWorkflows
        /// </summary>
        public StudentProfileWorkflows StudentProfileWorkflows { get; set; }

        //pages
        /// <summary>
        /// StudentDetailPage
        /// </summary>
        public StudentDetailPage StudentDetailPage { get; set; }

        /// <summary>
        /// navigate to the School District dashboard page
        /// </summary>
        /// <returns>Workflows</returns>
        public SchoolDistrictWorkflows NavigateToSchoolDistrictDashboardPage()
        {
            throw new NotImplementedException();
        }
    }
}
