using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Views;
using Core.Tools.WebDriver;

namespace UITests.Pages.Assess.ItemCentral
{
    /// <summary>
    /// the rubric central page
    /// </summary>
    public class RubricCentralPage : SNWebPage
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public RubricCentralPage()
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            this.ExpectedUrl = "/Assess/RubricCentral.aspx";
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
