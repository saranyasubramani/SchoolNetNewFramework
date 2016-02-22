using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages.Assess.ItemCreateEdit.v01.Components;

namespace UITests.Pages.Assess.ItemCreateEdit.v01
{
    /// <summary>
    /// The edit question page
    /// </summary>
    public abstract class EditQuestionPage : EditPageBase
    {
        /// <summary>
        /// the edit question page constructor
        /// </summary>
        public EditQuestionPage()
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            this.ExpectedUrl = "/Assess/Items/EditQuestion.aspx";
            this.VerifyCurrentUrl();
            //overriding class calls InitElements();
        }
        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            Report.Write("Martin EditQuestionPage.InitElements");
            SetRibbonBarItems();
        }

        private By ByRibbonBarItems { get { return By.CssSelector(".RibbonBarItem"); } }
        private WebElementWrapper RibbonBarItems { get; set; }
        private ReadOnlyCollection<IWebElement> RibbonBarItemWebElementList { get; set; }
        /// <summary>
        /// ribbon bar item list
        /// </summary>
        public List<RibbonBarItem> RibbonBarItemList { get; set; }

        /// <summary>
        /// set ribbon bar items
        /// </summary>
        public void SetRibbonBarItems()
        {
            RibbonBarItemList = new List<RibbonBarItem>();
            RibbonBarItems = new WebElementWrapper(ByRibbonBarItems);
            RibbonBarItemWebElementList = RibbonBarItems.WaitForElements(5);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                DummyWebElement dummy1 = new DummyWebElement();
                dummy1.FakeCssValueClass = "RibbonBarItem RibbonBarError";
                dummy1.FakeAttributeOnClick = "gotoQuestion(270396); return false;";
                dummy1.Text = "                                                         1                                                     ";

                DummyWebElement dummy2 = new DummyWebElement();
                dummy1.FakeCssValueClass = "RibbonBarItem RibbonBarReady";
                dummy2.FakeAttributeOnClick = "gotoQuestion(270397); return false;";
                dummy2.Text = "                                                         2                                                     ";

                DummyWebElement dummy3 = new DummyWebElement();
                dummy1.FakeCssValueClass = "RibbonBarItem RibbonBarReady";
                dummy3.FakeAttributeOnClick = "gotoQuestion(270398); return false;";
                dummy3.Text = "                                                         3                                                     ";

                DummyWebElement dummy4 = new DummyWebElement();
                dummy1.FakeCssValueClass = "RibbonBarItem RibbonBarSelectedItem";
                dummy4.FakeAttributeOnClick = "gotoQuestion(270399); return false;";
                dummy4.Text = "                                                         4                                                     ";

                List<IWebElement> list = new List<IWebElement> { dummy1, dummy2, dummy3, dummy4 };
                RibbonBarItemWebElementList = new ReadOnlyCollection<IWebElement>(list);
            }

            foreach (var webElement in RibbonBarItemWebElementList)
            {
                string onclickID = webElement.GetAttribute("onclick");
                int from = onclickID.IndexOf("(") + 1;
                int to = onclickID.LastIndexOf(")");
                string stringid = onclickID.Substring(from, to - from);
                int itemId = int.Parse(stringid);
                int index = int.Parse(webElement.Text.Trim());
                Report.Write("RibbonBarItem by index: '" + index + "'; itemId: '" + itemId);
                var ribbonBarItem = new RibbonBarItem(index, itemId);
                RibbonBarItemList.Add(ribbonBarItem);
            }
        }
    }
}
