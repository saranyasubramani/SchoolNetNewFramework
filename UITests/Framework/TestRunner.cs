using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Config;
using Core.Framework;
using Core.Runners;

namespace UITests.Framework
{
    public class TestRunner : BaseTestRunnerNUnit
    {
        public TestRunner()
        {
            log.Info("constructor...");
        }

        public override void SetUpThread(TestConfiguration testConfiguration)
        {
            new TestThread().SetUpThread(testConfiguration);
        }

        public SchoolNet SchoolNet()
        {
            return (SchoolNet)BaseTestThread.GetTestThread();
        }
    }
}
