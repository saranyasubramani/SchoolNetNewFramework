using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages.Components;

namespace UITests.Pages.Assess.Standards
{
    /// <summary>
    /// selected standards group line item
    /// </summary>
    public class SelectedStandardsGroupLineItem : SNForm
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="element"></param>
        /// <param name="pageName"></param>
        /// <param name="standardId"></param>
        /// <param name="clazz"></param>
        /// <param name="standardDocumentId"></param>
        /// <param name="standardName"></param>
        public SelectedStandardsGroupLineItem(IWebElement element, PageNames pageName,
            int standardId, string clazz, int standardDocumentId, string standardName)
            : base()
        {
            this.Element = element;
            this.PageNames = pageName;
            this.StandardId = standardId;
            this.Class = clazz;
            this.StandardDocumentId = standardDocumentId;
            this.StandardName = standardName;
            InitElements();
        }
        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            switch (PageNames)
            {
                case PageNames.EditQuestion:
                    InputType = ".radio";
                    break;
                case PageNames.EditTestItem:
                    InputType = ".checkbox";
                    break;
                case PageNames.EditTask:
                    InputType = ".radio";
                    break;
                case PageNames.CreateNewItem:
                    InputType = ".checkbox";
                    break;
                case PageNames.EditRubric:
                    InputType = ".radio";
                    break;
            }

            SelectedStandardsLineItem = new WebElementWrapper(BySelectedStandardsLineItem);
            AccordionImage = new WebElementWrapper(ByAccordionImage);
            SelectedStandardsGroupCheck = new WebElementWrapper(BySelectedStandardsGroupCheck);
            SelectedStandardsGroupLink = new WebElementWrapper(BySelectedStandardsGroupLink);
            SelectedStandardsItems = new WebElementWrapper(BySelectedStandardsItems);
        }

        /// <summary>
        /// the data
        /// </summary>
        public StandardPickerData Data
        {
            get
            {
                return (StandardPickerData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        private PageNames PageNames { get; set; }
        /// <summary>
        /// IWebElement
        /// </summary>
        public IWebElement Element { get; private set; }
        /// <summary>
        /// standard ID
        /// </summary>
        public int StandardId { get; private set; }
        /// <summary>
        /// class
        /// </summary>
        public string Class { get; private set; }
        /// <summary>
        /// standard document ID
        /// </summary>
        public int StandardDocumentId { get; private set; }
        /// <summary>
        /// standard name
        /// </summary>
        public string StandardName { get; set; }
        private string InputType { get; set; }

        private By BySelectedStandardsLineItem { get { return By.CssSelector("li[id='" + StandardId + "']"); } }
        private WebElementWrapper SelectedStandardsLineItem { get; set; }
        private By ByAccordionImage { get { return By.CssSelector("li[id='" + StandardId + "'] > img"); } }
        private WebElementWrapper AccordionImage { get; set; }
        private By BySelectedStandardsGroupCheck { get { return By.CssSelector("input[value='" + StandardId + "']"); } }
        private WebElementWrapper SelectedStandardsGroupCheck { get; set; }
        private By BySelectedStandardsGroupLink { get { return By.CssSelector("li[id='" + StandardId + "'] > " + InputType + " > a"); } }
        private WebElementWrapper SelectedStandardsGroupLink { get; set; }
        private By BySelectedStandardsItems { get { return By.CssSelector("li[id='" + StandardId + "'] > ul > li"); } }
        private WebElementWrapper SelectedStandardsItems { get; set; }
        private ReadOnlyCollection<IWebElement> ChildSelectedStandardsGroupWebElementList { get; set; }
        private List<SelectedStandardsGroupLineItem> ChildSelectedStandardsGroupList { get; set; }

        private void SetSelectedStandardsGroupList()
        {
            ChildSelectedStandardsGroupList = new List<SelectedStandardsGroupLineItem>();
            try
            {
                //try waiting to find the list of VISIBLE elements for a specified amount of time
                SelectedStandardsItems.WaitUntilVisible(5);
            }
            catch (Exception e)
            {
                //if the list of elements are not found, then they are INVISIBLE, so IGNORE them by nulling the list
                Report.Write("element was not found");
                ChildSelectedStandardsGroupList = null;
            }
            //if the list is not null, then the list of VISIBLE elements were found
            if (ChildSelectedStandardsGroupList != null)
            {
                //wait to find EXISTING elements (should only be VISIBLE, but checks for INVISIBLE) for a specified amount of time
                ChildSelectedStandardsGroupWebElementList = SelectedStandardsItems.WaitForElements(5);
                if (Driver.GetType() == typeof(DummyDriver))
                {
                    DummyWebElement dummy1 = new DummyWebElement();
                    dummy1.FakeAttributeId = "17714";
                    dummy1.FakeAttributeDocid = "49";
                    dummy1.FakeAttributeNk = "ACT-Alg1-D.1";
                    dummy1.FakeCssValueClass = "ContractedNode";
                    DummyWebElement dummy2 = new DummyWebElement();
                    dummy2.FakeAttributeId = "17715";
                    dummy2.FakeAttributeDocid = "49";
                    dummy2.FakeAttributeNk = "ACT-Alg1-D.2";
                    dummy2.FakeCssValueClass = "ContractedNode";
                    List<IWebElement> list = new List<IWebElement> { dummy1, dummy2 };
                    ChildSelectedStandardsGroupWebElementList = new ReadOnlyCollection<IWebElement>(list);
                }

                foreach (var webElement in ChildSelectedStandardsGroupWebElementList)
                {
                    int standardId = int.Parse(webElement.GetAttribute("id"));
                    //string clazz = webElement.GetCssValue("class");
                    string clazz = webElement.GetAttribute("class");
                    int standardDocumentId = int.Parse(webElement.GetAttribute("docid"));
                    string standardName = webElement.GetAttribute("nk");
                    Report.Write("ChildStandardsLineItemList by standardId: '" + standardId + "'; class: '" + clazz + "'; standardDocumentId: '" + standardDocumentId + "'; standardName: '" + standardName + "'.");
                    var standardsLineItem = new SelectedStandardsGroupLineItem(webElement, PageNames, standardId, clazz, standardDocumentId, standardName);
                    ChildSelectedStandardsGroupList.Add(standardsLineItem);
                }
            }
        }
        /// <summary>
        /// get child selected standards group list
        /// </summary>
        /// <returns></returns>
        public List<SelectedStandardsGroupLineItem> GetChildSelectedStandardsGroupList()
        {
            SetSelectedStandardsGroupList();
            return ChildSelectedStandardsGroupList;
        }
        /// <summary>
        /// expand standard
        /// </summary>
        public void ExpandStandard()
        {
            //Debug.WriteLine("in ExpandStandard()");
            SelectedStandardsLineItem.Wait(3);
            if (SelectedStandardsLineItem.WrappedElement.GetType() == typeof(DummyWebElement))
            {
                ((DummyWebElement)SelectedStandardsLineItem.WrappedElement).FakeAttributeClass = "ContractedNode";
            }
            Class = SelectedStandardsLineItem.GetAttribute("class");
            if (Class.Equals("ContractedNode"))
            {
                //Debug.WriteLine("in ExpandStandard() - ContractedNode");
                AccordionImage.Wait(5).Click();
                //pause the script for a second to let the javascript and css catch up
                System.Threading.Thread.Sleep(1000);
                SelectedStandardsLineItem.Wait(3);
                if (SelectedStandardsLineItem.WrappedElement.GetType() == typeof(DummyWebElement))
                {
                    //((DummyWebElement)SelectedStandardsLineItem.Element).FakeCssValueClass = "ExpandedNode";
                    ((DummyWebElement)SelectedStandardsLineItem.WrappedElement).FakeAttributeClass = "ExpandedNode";
                }
                //Class = SelectedStandardsLineItem.GetCssValue("class");
                Class = SelectedStandardsLineItem.GetAttribute("class");
                if (Class.Equals("ContractedNode"))
                {
                    throw new Exception("Clicked this element by: " + this.SelectedStandardsLineItem.By.ToString()
                        + " to expand the Standard Group, and expected: 'ExpandedNode', but actual: '" + Class + "'.");
                }
                SetSelectedStandardsGroupList();
            }
        }
        /// <summary>
        /// collapse standard
        /// </summary>
        public void CollapseStandard()
        {
            //Debug.WriteLine("in CollapseStandard()");
            SelectedStandardsLineItem.Wait(3);
            if (SelectedStandardsLineItem.WrappedElement.GetType() == typeof(DummyWebElement))
            {
                ((DummyWebElement)SelectedStandardsLineItem.WrappedElement).FakeAttributeClass = "ExpandedNode";
            }
            Class = SelectedStandardsLineItem.GetAttribute("class");
            if (Class.Equals("ExpandedNode"))
            {
                //Debug.WriteLine("in CollapseStandard() - ExpandedNode");
                AccordionImage.Wait(5).Click();
                //pause the script for a second to let the javascript and css catch up
                System.Threading.Thread.Sleep(1000);
                SelectedStandardsLineItem.Wait(3);
                if (SelectedStandardsLineItem.WrappedElement.GetType() == typeof(DummyWebElement))
                {
                    //((DummyWebElement)SelectedStandardsLineItem.Element).FakeCssValueClass = "ContractedNode";
                    ((DummyWebElement)SelectedStandardsLineItem.WrappedElement).FakeAttributeClass = "ContractedNode";
                }
                //Class = SelectedStandardsLineItem.GetCssValue("class");
                Class = SelectedStandardsLineItem.GetAttribute("class");
                if (Class.Equals("ExpandedNode"))
                {
                    throw new Exception("Clicked this element by: " + this.SelectedStandardsLineItem.By.ToString()
                        + " to expand the Standard Group, and expected: 'ContractedNode', but actual: '" + Class + "'.");
                }
            }
        }
        /// <summary>
        /// select standard only
        /// </summary>
        public void SelectStandardOnly()
        {
            SelectedStandardsGroupCheck.Wait(5).Click();
        }
        /// <summary>
        /// select standards in group
        /// </summary>
        public void SelectStandardsInGroup()
        {
            SelectedStandardsGroupLink.Wait(10).Click();
            //pause the script for a second to let the javascript and css catch up
            System.Threading.Thread.Sleep(1000);
            ExpandStandard();
        }
    }
}
