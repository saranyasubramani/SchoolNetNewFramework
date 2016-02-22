using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;

namespace UITests.Pages.Assess.ItemCreateEdit.v01.EditQuestion
{
    /// <summary>
    /// The edit question choose item type form
    /// </summary>
    public class EditQuestionChooseNewItemForm : SNForm
    {
        /// <summary>
        /// the edit question form constructor
        /// </summary>
        public EditQuestionChooseNewItemForm()
            : base()
        {
            InitElements();
        }
        //initialize elements
        public override void InitElements()
        {
            
        }
        /// <summary>
        /// submit by
        /// </summary>
        public override By BySubmit { get { return By.Id(ControlPrefix + "ButtonSubmit"); } }
    }
}
