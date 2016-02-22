using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Config;
using Core.Framework;

namespace UITests.Framework
{
    public class TestThread: BaseTestThread
    {
        public TestThread()
        {
            log.Info("constructor...");
        }

        public override void SetUpThread(TestConfiguration baseTestConfiguration)
        {
            log.Info("setting up schoolnet thread...");
            ITestApplication testApplication = null;
            TestConfiguration testConfiguration = (TestConfiguration)baseTestConfiguration;
            if (testConfiguration.ApplicationName.Equals(ApplicationName.schoolnetsingletenant))
            {
                switch (testConfiguration.ApplicationType)
                {
                    case ApplicationType.ANDROID_PHONE_WEB:
                    case ApplicationType.ANDROID_TABLET_WEB:
                    case ApplicationType.IOS_IPAD_MINI_WEB:
                    case ApplicationType.IOS_IPAD_PRO_WEB:
                    case ApplicationType.IOS_IPAD_WEB:
                    case ApplicationType.IOS_IPHONE_WEB:
                    case ApplicationType.LINUX_WEB_CHROME:
                    case ApplicationType.LINUX_WEB_FIREFOX:
                    case ApplicationType.LINUX_WEB_OPERA:
                    case ApplicationType.MAC_WEB_CHROME:
                    case ApplicationType.MAC_WEB_FIREFOX:
                    case ApplicationType.MAC_WEB_OPERA:
                    case ApplicationType.MAC_WEB_SAFARI:
                    case ApplicationType.WEB_HEADLESS:
                    case ApplicationType.WEB_PHANTOMJS:
                    case ApplicationType.WINDOWS_WEB_CHROME:
                    case ApplicationType.WINDOWS_WEB_EDGE:
                    case ApplicationType.WINDOWS_WEB_FIREFOX:
                    case ApplicationType.WINDOWS_WEB_INTERNET_EXPLORER:
                    case ApplicationType.WINDOWS_WEB_OPERA:
                        testApplication = new SchoolNetSTWeb(testConfiguration);
                        break;
                    default:
                        break;
                }
            }
            if (testConfiguration.ApplicationName.Equals(ApplicationName.schoolnetmultitenant))
            {
                switch (testConfiguration.ApplicationType)
                {
                    case ApplicationType.ANDROID_PHONE_WEB:
                    case ApplicationType.ANDROID_TABLET_WEB:
                    case ApplicationType.IOS_IPAD_MINI_WEB:
                    case ApplicationType.IOS_IPAD_PRO_WEB:
                    case ApplicationType.IOS_IPAD_WEB:
                    case ApplicationType.IOS_IPHONE_WEB:
                    case ApplicationType.LINUX_WEB_CHROME:
                    case ApplicationType.LINUX_WEB_FIREFOX:
                    case ApplicationType.LINUX_WEB_OPERA:
                    case ApplicationType.MAC_WEB_CHROME:
                    case ApplicationType.MAC_WEB_FIREFOX:
                    case ApplicationType.MAC_WEB_OPERA:
                    case ApplicationType.MAC_WEB_SAFARI:
                    case ApplicationType.WEB_HEADLESS:
                    case ApplicationType.WEB_PHANTOMJS:
                    case ApplicationType.WINDOWS_WEB_CHROME:
                    case ApplicationType.WINDOWS_WEB_EDGE:
                    case ApplicationType.WINDOWS_WEB_FIREFOX:
                    case ApplicationType.WINDOWS_WEB_INTERNET_EXPLORER:
                    case ApplicationType.WINDOWS_WEB_OPERA:
                        testApplication = new SchoolNetMTWeb(testConfiguration);
                        break;
                    default:
                        break;
                }
            }
            //TODO: add other types here...
            SetUpThread(testApplication);
            log.Info("set up schoolnet thread.");
        }
    }
}
