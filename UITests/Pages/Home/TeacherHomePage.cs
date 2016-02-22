using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using UITests.Pages.Home.Components;

namespace UITests.Pages.Home
{
    /// <summary>
    /// the teacher home page
    /// </summary>
    public class TeacherHomePage : HomePage
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public TeacherHomePage()
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            InitElements();
        }
        /// <summary>
        /// intialize elements
        /// </summary>
        public override void InitElements()
        {
            
        }
    }
}
