using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;

namespace UITests.Pages.Assess.TestDetail.UsernameGenerator
{
    /// <summary>
    /// Username Generator Form
    /// </summary>
    public class UsernameGeneratorForm : SNForm
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="overrideControlPrefix"></param>
        public UsernameGeneratorForm(  string overrideControlPrefix = null)
            : base()
        {
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
        }

        /// <summary>
        /// the data
        /// </summary>
        public new UsernameGeneratorData Data
        {
            get
            {
                return (UsernameGeneratorData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }
    }
}
