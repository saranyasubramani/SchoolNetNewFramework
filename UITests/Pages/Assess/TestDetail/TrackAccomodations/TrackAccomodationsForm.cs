using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;

namespace UITests.Pages.Assess.TestDetail.TrackAccomodations
{
    /// <summary>
    /// Track Accomodations Form
    /// </summary>
    public class TrackAccomodationsForm : SNForm
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="overrideControlPrefix"></param>
        public TrackAccomodationsForm(  string overrideControlPrefix = null)
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
        public new TrackAccomodationsData Data
        {
            get
            {
                return (TrackAccomodationsData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }
    }
}
