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
    /// event log page
    /// </summary>
    public class EventLogPage : SNWebPage
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public EventLogPage()
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            this.ExpectedUrl = "/admin/";
            this.VerifyCurrentUrl();
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