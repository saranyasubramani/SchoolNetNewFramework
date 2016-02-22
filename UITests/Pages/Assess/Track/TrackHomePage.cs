using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Views;

namespace UITests.Pages.Assess.Track
{
    /// <summary>
    /// Track Home page
    /// </summary>
    public class TrackHomePage : SNWebPage
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public TrackHomePage()
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            this.ExpectedUrl = "/Assess/TrackHome.aspx";
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
