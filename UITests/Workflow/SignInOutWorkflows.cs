using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITests.Pages;
using UITests.Pages.Home;
using UITests.Pages.Home.Components;
using UITests.Pages.Login;
using UITests.Pages.Login.Components;


namespace UITests.Workflow
{
    /// <summary>
    /// the sign in/out workflows
    /// </summary>
    public class SignInOutWorkflows : SNComponent
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="workflows">workflows</param>
        public SignInOutWorkflows(Workflows workflows)
            : base()
        {
            this.Workflows = workflows;
        }

        //workflows
        /// <summary>
        /// Workflows
        /// </summary>
        public Workflows Workflows { get; set; }

        //pages

        /// <summary>
        /// sign in as a state admin on MT site (state_assess)
        /// </summary>
        /// <returns>Workflows</returns>
        public SignInOutWorkflows SignInAsStateAdmin(AuthenticationData authenticationData = null)
        {
            Workflows.AuthenticationPage = new AuthenticationPage();
            if (authenticationData == null)
            {//use default data
                authenticationData = Workflows.AuthenticationPage.InitData();
                authenticationData.GetTestDataFromResxResource("UITests.Data.Login.AuthenticationResource",
                    "stateadmin_" + this.TestConfiguration.ApplicationName, 0);
                Workflows.AuthenticationPage.Data = authenticationData;
            }
            else
            {
                Workflows.AuthenticationPage.InitData(authenticationData);
            }
            Workflows.HomePage = Workflows.AuthenticationPage.Login();
            return this;
        }
        /// <summary>
        /// sign in as a state super admin on MT site (sn_qa)
        /// </summary>
        /// <returns>Workflows</returns>
        public SignInOutWorkflows SignInAsStateSuperAdmin(AuthenticationData authenticationData = null)
        {
            Workflows.AuthenticationPage = new AuthenticationPage();
            if (authenticationData == null)
            {//use default data
                authenticationData = Workflows.AuthenticationPage.InitData();
                authenticationData.GetTestDataFromResxResource("UITests.Data.Login.AuthenticationResource",
                    "statesuperadmin_" + this.TestConfiguration.ApplicationName, 0);
                Workflows.AuthenticationPage.Data = authenticationData;
            }
            else
            {
                Workflows.AuthenticationPage.InitData(authenticationData);
            }
            Workflows.HomePage = Workflows.AuthenticationPage.Login();
            return this;
        }
        /// <summary>
        /// sign in as a district admin (sn_qa)
        /// </summary>
        /// <returns>Workflows</returns>
        public SignInOutWorkflows SignInAsDistrictAdmin(AuthenticationData authenticationData = null)
        {
            Workflows.AuthenticationPage = new AuthenticationPage();
            if (authenticationData == null)
            {//use default data
                authenticationData = Workflows.AuthenticationPage.InitData();
                authenticationData.GetTestDataFromResxResource("UITests.Data.Login.AuthenticationResource",
                    "districtadmin_" + this.TestConfiguration.ApplicationName, 0);
                Workflows.AuthenticationPage.Data = authenticationData;
            }
            else
            {
                Workflows.AuthenticationPage.InitData(authenticationData);
            }
            Workflows.HomePage = Workflows.AuthenticationPage.Login();
            return this;
        }
        /// <summary>
        /// sign in a s BM leadership
        /// </summary>
        /// <returns>Workflows</returns>
        public SignInOutWorkflows SignInAsLeadership(AuthenticationData authenticationData = null)
        {
            Workflows.AuthenticationPage = new AuthenticationPage();
            if (authenticationData == null)
            {//use default data
                authenticationData = Workflows.AuthenticationPage.InitData();
                authenticationData.GetTestDataFromResxResource("UITests.Data.Login.AuthenticationResource",
                    "leadership_" + this.TestConfiguration.ApplicationName, 0);
                Workflows.AuthenticationPage.Data = authenticationData;
            }
            else
            {
                Workflows.AuthenticationPage.InitData(authenticationData);
            }
            Workflows.HomePage = Workflows.AuthenticationPage.Login();
            return this;
        }
        /// <summary>
        /// sign in as a school admin
        /// </summary>
        /// <returns>Workflows</returns>
        public SignInOutWorkflows SignInAsSchoolAdmin(AuthenticationData authenticationData = null)
        {
            Workflows.AuthenticationPage = new AuthenticationPage();
            if (authenticationData == null)
            {//use default data
                authenticationData = Workflows.AuthenticationPage.InitData();
                authenticationData.GetTestDataFromResxResource("UITests.Data.Login.AuthenticationResource",
                    "schooladmin_" + this.TestConfiguration.ApplicationName, 0);
                Workflows.AuthenticationPage.Data = authenticationData;
            }
            else
            {
                Workflows.AuthenticationPage.InitData(authenticationData);
            }
            Workflows.HomePage = Workflows.AuthenticationPage.Login();
            return this;
        }
        /// <summary>
        /// Sign in as a teacher
        /// </summary>
        /// <returns>Workflows</returns>
        public SignInOutWorkflows SignInAsRegionalAdmin(AuthenticationData authenticationData = null)
        {
            Workflows.AuthenticationPage = new AuthenticationPage();
            if (authenticationData == null)
            {//use default data
                authenticationData = Workflows.AuthenticationPage.InitData();
                authenticationData.GetTestDataFromResxResource("UITests.Data.Login.AuthenticationResource",
                    "regionaladmin_" + this.TestConfiguration.ApplicationName, 0);
                Workflows.AuthenticationPage.Data = authenticationData;
            }
            else
            {
                Workflows.AuthenticationPage.InitData(authenticationData);
            }
            Workflows.TeacherHomePage = new TeacherHomePage();
            return this;
        }
        /// <summary>
        /// Sign in as a teacher
        /// </summary>
        /// <returns>Workflows</returns>
        public SignInOutWorkflows SignInAsTeacher(AuthenticationData authenticationData = null)
        {
            Workflows.AuthenticationPage = new AuthenticationPage();
            if (authenticationData == null)
            {//use default data
                authenticationData = Workflows.AuthenticationPage.InitData();
                authenticationData.GetTestDataFromResxResource("UITests.Data.Login.AuthenticationResource",
                    "teacher_" + this.TestConfiguration.ApplicationName, 0);
                Workflows.AuthenticationPage.Data = authenticationData;
            }
            else
            {
                Workflows.AuthenticationPage.InitData(authenticationData);
            }
            Workflows.HomePage = Workflows.AuthenticationPage.Login();
            Workflows.TeacherHomePage = new TeacherHomePage();
            return this;
        }
        /// <summary>
        /// sign in as a student
        /// </summary>
        /// <returns>Workflows</returns>
        public SignInOutWorkflows SignInAsStudent(AuthenticationData authenticationData = null, StudentHomeData studentHomeData = null)
        {
            Workflows.AuthenticationPage = new AuthenticationPage();
            if (authenticationData == null)
            {//use default data
                authenticationData = Workflows.AuthenticationPage.InitData();
                authenticationData.GetTestDataFromResxResource("UITests.Data.Login.AuthenticationResource",
                    "student_" + this.TestConfiguration.ApplicationName, 0);
                Workflows.AuthenticationPage.Data = authenticationData;
            }
            else
            {
                Workflows.AuthenticationPage.InitData(authenticationData);
            }
            Workflows.HomePage = Workflows.AuthenticationPage.Login();

            Workflows.StudentHomePage = new StudentHomePage();
            if (studentHomeData == null)
            {//use default data
                studentHomeData = Workflows.StudentHomePage.InitData();
                studentHomeData.GetTestDataFromResxResource("UITests.Data.Login.AuthenticationResource",
                    "student_" + this.TestConfiguration.ApplicationName, 0);
                Workflows.StudentHomePage.Data = studentHomeData;
            }
            else
            {
                Workflows.StudentHomePage.InitData(studentHomeData);
            }
            return this;
        }
        /// <summary>
        /// sign in as system setup
        /// </summary>
        /// <returns>Workflows</returns>
        public SignInOutWorkflows SignInAsSystemSetup(AuthenticationData authenticationData = null)
        {
            Workflows.AuthenticationPage = new AuthenticationPage();
            if (authenticationData == null)
            {//use default data
                authenticationData = Workflows.AuthenticationPage.InitData();
                authenticationData.GetTestDataFromResxResource("UITests.Data.Login.AuthenticationResource",
                    "systemsetup_" + this.TestConfiguration.ApplicationName, 0);
                Workflows.AuthenticationPage.Data = authenticationData;
            }
            else
            {
                Workflows.AuthenticationPage.InitData(authenticationData);
            }
            Workflows.HomePage = Workflows.AuthenticationPage.Login();
            return this;
        }
        /// <summary>
        /// sign in as system setup for a state
        /// </summary>
        /// <returns>Workflows</returns>
        public SignInOutWorkflows SignInAsSystemSetupState(AuthenticationData authenticationData = null)
        {
            Workflows.AuthenticationPage = new AuthenticationPage();
            if (authenticationData == null)
            {//use default data
                authenticationData = Workflows.AuthenticationPage.InitData();
                authenticationData.GetTestDataFromResxResource("UITests.Data.Login.AuthenticationResource",
                    "systemsetupstate_" + this.TestConfiguration.ApplicationName, 0);
                Workflows.AuthenticationPage.Data = authenticationData;
            }
            else
            {
                Workflows.AuthenticationPage.InitData(authenticationData);
            }
            Workflows.HomePage = Workflows.AuthenticationPage.Login();
            return this;
        }
        /// <summary>
        /// sign out
        /// </summary>
        /// <remarks>requires the home page to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public SignInOutWorkflows SignOut()
        {
            Workflows.HomePage.Logout();
            Workflows.AuthenticationPage.VerifySignedOut();
            return this;
        }
    }
}
