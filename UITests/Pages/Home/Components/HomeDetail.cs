using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;

namespace UITests.Pages.Home.Components
{
    /// <summary>
    /// home detail
    /// </summary>
    public class HomeDetail : SNDetail
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public HomeDetail()
            : base()
        {
            InitElements();
        }

        public override void InitElements()
        {
            
        }
    }
}
