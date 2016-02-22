using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Views;
using UITests.Pages.Admin.SystemOperation;

namespace UITests.Pages.Admin
{
    /// <summary>
    /// System Operation Page.  Basically a wall of links leading to other places.
    /// </summary>
    public class SystemOperationPage : SNWebPage
    {
        /// <summary>
        /// constructor
        /// </summary>
        public SystemOperationPage()
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
            this.Detail = new SystemOperationDetail();
            this.Detail.Parent = this;
        }
        /// <summary>
        /// the form
        /// </summary>
        public new SystemOperationDetail Detail { get; set; }
    }
}
