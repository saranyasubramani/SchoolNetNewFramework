using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITests.Pages;
using UITests.Pages.Admin;
using UITests.Pages.Admin.AssessAdminSettings;
using UITests.Pages.Admin.GeneralSettings;
using UITests.Pages.Home;
using UITests.Pages.Home.Components;
using UITests.Pages.Login;
using UITests.Pages.Login.Components;
using UITests.Workflow;
using UITests.Workflow.Admin;
using UITests.Workflow.Assess;
using UITests.Workflow.SchoolAndDistrict;
using UITests.Workflow.UserManagement;

namespace UITests.Workflow
{
    /// <summary>
    /// the global Schoolnet workflows
    /// </summary>
    public class Workflows : SNComponent
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public Workflows()
            : base()
        {
            SignInOutWorkflows = new SignInOutWorkflows( this);
            AdminWorkflows = new AdminWorkflows(this);
            AssessWorkflows = new AssessWorkflows(this);
            UserManagementWorkflows = new UserManagementWorkflows(this);
            SchoolDistrictWorkflows = new SchoolDistrictWorkflows(this);
        }

        //workflows
        /// <summary>
        /// SignInOutWorkflows
        /// </summary>
        public SignInOutWorkflows SignInOutWorkflows { get; set; }
        /// <summary>
        /// AdminWorkflows
        /// </summary>
        public AdminWorkflows AdminWorkflows { get; set; }
        /// <summary>
        /// AssessWorkflows
        /// </summary>
        public AssessWorkflows AssessWorkflows { get; set; }
        /// <summary>
        /// UserManagementWorkflows
        /// </summary>
        public UserManagementWorkflows UserManagementWorkflows { get; set; }
        /// <summary>
        /// SchoolDistrictWorkflows
        /// </summary>
        public SchoolDistrictWorkflows SchoolDistrictWorkflows { get; set; }

        //pages
        /// <summary>
        /// AuthenticationPage
        /// </summary>
        public AuthenticationPage AuthenticationPage { get; set; }
        /// <summary>
        /// HomePage
        /// </summary>
        public HomePage HomePage { get; set; }
        /// <summary>
        /// StudentHomePage
        /// </summary>
        public StudentHomePage StudentHomePage { get; set; }
        /// <summary>
        /// TeacherHomePage
        /// </summary>
        public TeacherHomePage TeacherHomePage { get; set; }

        /// <summary>
        /// Is State Admin?
        /// </summary>
        public bool IsStateAdmin { get; set; }
        /// <summary>
        /// Is Leadership?
        /// </summary>
        public bool IsLeadership { get; set; }
        /// <summary>
        /// Is DistrictAdmin?
        /// </summary>
        public bool IsDistrictAdmin { get; set; }
        /// <summary>
        /// Is SchoolAdmin?
        /// </summary>
        public bool IsSchoolAdmin { get; set; }
        /// <summary>
        /// Is Teacher?
        /// </summary>
        public bool IsTeacher { get; set; }
        /// <summary>
        /// Is Student?
        /// </summary>
        public bool IsStudent { get; set; }
        /// <summary>
        /// Is SystemSetup?
        /// </summary>
        public bool IsSystemSetup { get; set; }
        /// <summary>
        /// Is RegionalAdmin?
        /// </summary>
        public bool IsRegionalAdmin { get; set; }

        /// <summary>
        /// sign in as state admin
        /// </summary>
        /// <returns>Workflows</returns>
        public Workflows SignInAsStateAdmin()
        {
            SignInOutWorkflows.SignInAsStateAdmin();
            IsStateAdmin = true;
            IsLeadership = false;
            IsDistrictAdmin = false;
            IsSchoolAdmin = false;
            IsTeacher = false;
            IsStudent = false;
            IsSystemSetup = false;
            IsRegionalAdmin = false;
            return this;
        }
        /// <summary>
        /// sign in a s BM leadership
        /// </summary>
        /// <returns>Workflows</returns>
        public Workflows SignInAsLeadership()
        {
            SignInOutWorkflows.SignInAsLeadership();
            IsLeadership = true;
            IsDistrictAdmin = false;
            IsSchoolAdmin = false;
            IsTeacher = false;
            IsStudent = false;
            IsSystemSetup = false;
            IsRegionalAdmin = false;
            return this;
        }
        /// <summary>
        /// sign in as a district admin (sn_qa)
        /// </summary>
        /// <returns>Workflows</returns>
        public Workflows SignInAsDistrictAdmin()
        {
            SignInOutWorkflows.SignInAsDistrictAdmin();
            IsLeadership = false;
            IsDistrictAdmin = true;
            IsSchoolAdmin = false;
            IsTeacher = false;
            IsStudent = false;
            IsSystemSetup = false;
            IsRegionalAdmin = false;
            return this;
        }
        /// <summary>
        /// sign in as state admin
        /// </summary>
        /// <returns>Workflows</returns>
        public Workflows SignInAsStateSuperAdmin()
        {
            SignInOutWorkflows.SignInAsStateSuperAdmin();
            IsStateAdmin = true;
            IsLeadership = false;
            IsDistrictAdmin = false;
            IsSchoolAdmin = false;
            IsTeacher = false;
            IsStudent = false;
            IsSystemSetup = false;
            IsRegionalAdmin = false;
            return this;
        }
        /// <summary>
        /// sign in as a school admin
        /// </summary>
        /// <returns>Workflows</returns>
        public Workflows SignInAsSchoolAdmin()
        {
            SignInOutWorkflows.SignInAsSchoolAdmin();
            IsLeadership = false;
            IsDistrictAdmin = false;
            IsSchoolAdmin = true;
            IsTeacher = false;
            IsStudent = false;
            IsSystemSetup = false;
            IsRegionalAdmin = false;
            return this;
        }
        /// sign in as a student
        /// </summary>
        /// <returns>Workflows</returns>
        public Workflows SignInAsRegionalAdmin()
        {
            SignInOutWorkflows.SignInAsRegionalAdmin();
            IsLeadership = false;
            IsDistrictAdmin = false;
            IsSchoolAdmin = false;
            IsTeacher = false;
            IsStudent = true;
            IsSystemSetup = false;
            IsRegionalAdmin = true;
            return this;
        }
        /// <summary>
        /// Sign in as a Teacher
        /// </summary>
        /// <returns></returns>
        public Workflows SignInAsTeacher()
        {
            SignInOutWorkflows.SignInAsTeacher();
            IsLeadership = false;
            IsDistrictAdmin = false;
            IsSchoolAdmin = false;
            IsTeacher = true;
            IsStudent = false;
            IsSystemSetup = false;
            IsRegionalAdmin = false;
            return this;
        }
        /// <summary>
        /// sign in as a student
        /// </summary>
        /// <returns>Workflows</returns>
        public Workflows SignInAsStudent()
        {
            SignInOutWorkflows.SignInAsStudent();
            IsLeadership = false;
            IsDistrictAdmin = false;
            IsSchoolAdmin = false;
            IsTeacher = false;
            IsStudent = true;
            IsSystemSetup = false;
            IsRegionalAdmin = false;
            return this;
        }
        /// <summary>
        /// sign in as system setup
        /// </summary>
        /// <returns>Workflows</returns>
        public Workflows SignInAsSystemSetup()
        {
            SignInOutWorkflows.SignInAsSystemSetup();
            IsLeadership = false;
            IsDistrictAdmin = false;
            IsSchoolAdmin = false;
            IsTeacher = false;
            IsStudent = false;
            IsSystemSetup = true;
            IsRegionalAdmin = false;
            return this;
        }
        /// <summary>
        /// sign in as system setup at a state
        /// </summary>
        /// <returns>Workflows</returns>
        public Workflows SignInAsSystemSetupState()
        {
            SignInOutWorkflows.SignInAsSystemSetupState();
            IsLeadership = false;
            IsDistrictAdmin = false;
            IsSchoolAdmin = false;
            IsTeacher = false;
            IsStudent = false;
            IsSystemSetup = true;
            IsRegionalAdmin = false;
            return this;
        }
        /// <summary>
        /// sign out
        /// </summary>
        /// <remarks>requires the home page to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public Workflows SignOut()
        {
            SignInOutWorkflows.SignOut();
            return this;
        }
    }
}
