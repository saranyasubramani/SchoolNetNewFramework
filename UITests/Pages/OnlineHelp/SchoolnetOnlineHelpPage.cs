using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Views;

namespace UITests.Pages.OnlineHelp
{
    /// <summary>
    /// schoolnet online help page
    /// </summary>
    public class SchoolnetOnlineHelpPage : SNWebPage
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="driver">IWebDriver</param>
        public SchoolnetOnlineHelpPage(string windowName)
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            this.ExpectedUrl = "/MainHelp.aspx?";
            this.VerifyCurrentUrl();
            WindowName = windowName;
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
        }

        public string WindowName { get; set; }

        private void SwitchToOnlineHelpWindow()
        {
            DriverCommands.WaitToSwitchWindow(WindowName, 90.0);
        }

        /// <summary>
        /// Close online help window and switch back to parent window
        /// </summary>
        public void Close()
        {
            Report.Write("Closing online test help window");
            Driver.Close();

            Report.Write("Switch back to parent window");
            IReadOnlyCollection<string> WindowHandles = Driver.WindowHandles;
            DriverCommands.WaitToSwitchWindow(WindowHandles.FirstOrDefault(), 90.0);
        }
    }
}
