using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using TestContext = NUnit.Framework.TestContext;
using TestConfiguration = Core.Config.TestConfiguration;
using ApplicationType = Core.Framework.ApplicationType;
using TestGridType = Core.Framework.TestGridType;
using TestToolType = Core.Framework.TestToolType;
using ApplicationName = UITests.Framework.ApplicationName;
using TestRunner = UITests.Framework.TestRunner;
using DriverCommands = Core.Tools.WebDriver.DriverCommands;
using UITests.Pages.Login;
using UITests.Pages.Login.Components;
using UITests.Pages.Home;
using UITests.Pages.Components;
using UITests.Pages.Assess.ItemCreateEdit.v01.Components;
using UITests.Workflow;

namespace UnitTests.Workflow.Tests
{
    [TestFixture()]
    [Parallelizable(ParallelScope.Children)]
    public class SignInOutWorkflowsTests : TestRunner
    {
        public SignInOutWorkflowsTests()
        {
            TestContext.WriteLine("in SignInOutWorkflowsTests");
        }

        [SetUp]
        public void SetUp()
        {
            TestConfiguration testConfiguration = new TestConfiguration();
            testConfiguration.Language = "en";
            testConfiguration.Country = "US";
            testConfiguration.TestTool = TestToolType.DUMMY;
            testConfiguration.TestGrid = TestGridType.LOCAL;
            testConfiguration.ApplicationName = ApplicationName.schoolnetsingletenant;
            testConfiguration.ApplicationType = ApplicationType.WINDOWS_WEB_CHROME;
            testConfiguration.OperatingSystemVersion = "8";
            testConfiguration.BrowserVersion = "32";
            testConfiguration.EnvironmentName = "automation";
            testConfiguration.DeviceOrientation = "landscape";
            testConfiguration.ReleaseVersion = "17";
            testConfiguration.TestName = TestContext.CurrentContext.Test.FullName;
            testConfiguration.TextWriter = TestContext.Out;
            this.SetUpBeforeMethodNUnit(testConfiguration);
        }

        [Test()]
        public void SignInOutWorkflowsTest()
        {
            try
            {
                this.SchoolNet().LoadWebPage();
                Workflows workflows = new Workflows();
                SignInOutWorkflows signInOutWorkflows = workflows.SignInOutWorkflows;
            }
            catch (Exception e)
            {
                TestContext.WriteLine("\nInnerException:\n" + e.InnerException + "\nStackTrace:\n" + e.StackTrace, e);
                throw new Exception("\nInnerException:\n" + e.InnerException + "\nStackTrace:\n" + e.StackTrace, e);
            }
        }

        [Test()]
        public void SignInAsStateAdminTest()
        {
            try
            {
                this.SchoolNet().LoadWebPage();
                Workflows workflows = new Workflows();
                workflows.SignInOutWorkflows.SignInAsStateAdmin();
            }
            catch (Exception e)
            {
                TestContext.WriteLine("\nInnerException:\n" + e.InnerException + "\nStackTrace:\n" + e.StackTrace, e);
                throw new Exception("\nInnerException:\n" + e.InnerException + "\nStackTrace:\n" + e.StackTrace, e);
            }
        }

        [Test()]
        public void SignInAsStateSuperAdminTest()
        {
            try
            {
                this.SchoolNet().LoadWebPage();
                Workflows workflows = new Workflows();
                workflows.SignInOutWorkflows.SignInAsStateSuperAdmin();
            }
            catch (Exception e)
            {
                TestContext.WriteLine("\nInnerException:\n" + e.InnerException + "\nStackTrace:\n" + e.StackTrace, e);
                throw new Exception("\nInnerException:\n" + e.InnerException + "\nStackTrace:\n" + e.StackTrace, e);
            }
        }

        [Test()]
        public void SignInAsDistrictAdminTest()
        {
            try
            {
                this.SchoolNet().LoadWebPage();
                Workflows workflows = new Workflows();
                workflows.SignInOutWorkflows.SignInAsDistrictAdmin();
            }
            catch (Exception e)
            {
                TestContext.WriteLine("\nInnerException:\n" + e.InnerException + "\nStackTrace:\n" + e.StackTrace, e);
                throw new Exception("\nInnerException:\n" + e.InnerException + "\nStackTrace:\n" + e.StackTrace, e);
            }
        }

        [Test()]
        public void SignInAsLeadershipTest()
        {
            try
            {
                this.SchoolNet().LoadWebPage();
                Workflows workflows = new Workflows();
                workflows.SignInOutWorkflows.SignInAsLeadership();
            }
            catch (Exception e)
            {
                TestContext.WriteLine("\nInnerException:\n" + e.InnerException + "\nStackTrace:\n" + e.StackTrace, e);
                throw new Exception("\nInnerException:\n" + e.InnerException + "\nStackTrace:\n" + e.StackTrace, e);
            }
        }

        [Test()]
        public void SignInAsSchoolAdminTest()
        {
            try
            {
                this.SchoolNet().LoadWebPage();
                Workflows workflows = new Workflows();
                workflows.SignInOutWorkflows.SignInAsSchoolAdmin();
            }
            catch (Exception e)
            {
                TestContext.WriteLine("\nInnerException:\n" + e.InnerException + "\nStackTrace:\n" + e.StackTrace, e);
                throw new Exception("\nInnerException:\n" + e.InnerException + "\nStackTrace:\n" + e.StackTrace, e);
            }
        }

        [Test()]
        public void SignInAsRegionalAdminTest()
        {
            try
            {
                this.SchoolNet().LoadWebPage();
                Workflows workflows = new Workflows();
                workflows.SignInOutWorkflows.SignInAsRegionalAdmin();
            }
            catch (Exception e)
            {
                TestContext.WriteLine("\nInnerException:\n" + e.InnerException + "\nStackTrace:\n" + e.StackTrace, e);
                throw new Exception("\nInnerException:\n" + e.InnerException + "\nStackTrace:\n" + e.StackTrace, e);
            }
        }

        [Test()]
        public void SignInAsTeacherTest()
        {
            try
            {
                this.SchoolNet().LoadWebPage();
                Workflows workflows = new Workflows();
                workflows.SignInOutWorkflows.SignInAsTeacher();
            }
            catch (Exception e)
            {
                TestContext.WriteLine("\nInnerException:\n" + e.InnerException + "\nStackTrace:\n" + e.StackTrace, e);
                throw new Exception("\nInnerException:\n" + e.InnerException + "\nStackTrace:\n" + e.StackTrace, e);
            }
        }

        [Test()]
        public void SignInAsStudentTest()
        {
            try
            {
                this.SchoolNet().LoadWebPage();
                Workflows workflows = new Workflows();
                workflows.SignInOutWorkflows.SignInAsStudent();
            }
            catch (Exception e)
            {
                TestContext.WriteLine("\nInnerException:\n" + e.InnerException + "\nStackTrace:\n" + e.StackTrace, e);
                throw new Exception("\nInnerException:\n" + e.InnerException + "\nStackTrace:\n" + e.StackTrace, e);
            }
        }

        [Test()]
        public void SignInAsSystemSetupTest()
        {
            try
            {
                this.SchoolNet().LoadWebPage();
                Workflows workflows = new Workflows();
                workflows.SignInOutWorkflows.SignInAsSystemSetup();
            }
            catch (Exception e)
            {
                TestContext.WriteLine("\nInnerException:\n" + e.InnerException + "\nStackTrace:\n" + e.StackTrace, e);
                throw new Exception("\nInnerException:\n" + e.InnerException + "\nStackTrace:\n" + e.StackTrace, e);
            }
        }

        [Test()]
        public void SignInAsSystemSetupStateTest()
        {
            try
            {
                this.SchoolNet().LoadWebPage();
                Workflows workflows = new Workflows();
                workflows.SignInOutWorkflows.SignInAsSystemSetupState();
            }
            catch (Exception e)
            {
                TestContext.WriteLine("\nInnerException:\n" + e.InnerException + "\nStackTrace:\n" + e.StackTrace, e);
                throw new Exception("\nInnerException:\n" + e.InnerException + "\nStackTrace:\n" + e.StackTrace, e);
            }
        }

        [Test()]
        public void SignOutTest()
        {
            try
            {
                this.SchoolNet().LoadWebPage();
                Workflows workflows = new Workflows();
                workflows.SignInOutWorkflows.SignInAsDistrictAdmin();
                workflows.SignInOutWorkflows.SignOut();
            }
            catch (Exception e)
            {
                TestContext.WriteLine("\nInnerException:\n" + e.InnerException + "\nStackTrace:\n" + e.StackTrace, e);
                throw new Exception("\nInnerException:\n" + e.InnerException + "\nStackTrace:\n" + e.StackTrace, e);
            }
        }
    }
}
