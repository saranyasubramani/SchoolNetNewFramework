using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages.Controls;
using UITests.Pages.Home;
using UITests.Pages.Components;

namespace UITests.Pages.Assess.Standards
{
    /// <summary>
    /// the standard picker form
    /// </summary>
    public class StandardPickerForm : SNForm
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="pageName">the page name</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        /// <param name="customControlPrefix">custom id (eg for rubric)</param>
        public StandardPickerForm(PageNames pageName, string overrideControlPrefix = null)
            : base()
        {
            this.PageNames = pageName;
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }
            InitElements();
            ExpectedRequiredErrorsList = new List<string>()
            {
                "Align to a standard"
            };
        }
        /// <summary>
        /// intialize elements
        /// </summary>
        public override void InitElements()
        {
            _currentWindow = Driver.CurrentWindowHandle;
            Report.Write("The current window is: '" + _currentWindow + "'.");
            switch (PageNames)
            {
                case PageNames.TestItemStandardPopup:
                    //ctl00_MainContent_StandardsPicker_TableMain
                    //ctl00_MainContent_StandardsPicker_ddlStandardDoc
                    //ctl00_MainContent_StandardsPicker_DropDownGrade
                    ControlMiddle = "StandardsPicker_";
                    break;
                case PageNames.CreateNewItem:
                    ControlMiddle = "StandardsPicker_";
                    break;
                case PageNames.EditTestItem:
                    ControlMiddle = "StandardsPicker_";
                    break;
                case PageNames.EditTask:
                    ControlMiddle = "StandardsPicker_";
                    break;
                case PageNames.EditQuestion:
                    ControlMiddle = "StandardsPicker_";
                    break;
                case PageNames.ItemCentral:
                    //ctl00_MainContent_ItemFinder1_ItemFinderSearch1_StandardsPicker1_TableMain
                    //ctl00_MainContent_ItemFinder1_ItemFinderSearch1_StandardsPicker1_ddlStandardDoc
                    //ctl00_MainContent_ItemFinder1_ItemFinderSearch1_StandardsPicker1_DropDownGrade
                    ControlMiddle = "ItemFinder1_ItemFinderSearch1_StandardsPicker1_";
                    break;
                case PageNames.CreateTestBySelectingStandardsPage:
                    //ctl00_MainContent_StandardsPicker1_ddlStandardDoc
                    //ctl00_MainContent_StandardsPicker1_DropDownSubject
                    //ctl00_MainContent_StandardsPicker1_DropDownGrade
                    ControlMiddle = "StandardsPicker1_";
                    break;
                case PageNames.EditRubric:
                    //ctl00_MainContent_StandardsPicker1_ddlStandardDoc
                    //ctl00_MainContent_StandardsPicker1_DropDownSubject
                    //ctl00_MainContent_StandardsPicker1_DropDownGrade
                    ControlMiddle = "StandardsPicker_";
                    break;
            }
            LightBox = new WebElementWrapper(ByLightBox);
            IFrame = new WebElementWrapper(ByIFrame);
            MainTable = new WebElementWrapper(ByMainTable);
            MainDiv = new WebElementWrapper(ByMainDiv);
            StandardDocument = new SelectElementWrapper(new WebElementWrapper(ByStandardDocument));
            if (PageNames == PageNames.CreateTestBySelectingStandardsPage)
            {
                //Subject = new Subject(Driver, PageNames.CreateTestBySelectingStandardsPage, ControlPrefix);
                SubjectElement subject = new SubjectElement(PageNames.CreateTestBySelectingStandardsPage);
                SubjectSelect = subject.SelectElement;
            }
            else
            {
                //Subject = new Subject(Driver, PageNames.TestItemStandardPopup, ControlPrefix);
                SubjectElement subject = new SubjectElement(PageNames.TestItemStandardPopup);
                SubjectSelect = subject.SelectElement;
            }
            GradeLevel = new SelectElementWrapper(new WebElementWrapper(ByGradeLevel));
            FindStandardText = new WebElementWrapper(ByFindStandardText);
            FindStandardButton = new WebElementWrapper(ByFindStandardButton);
            ExpandAll = new WebElementWrapper(ByExpandAll);
            CollapseAll = new WebElementWrapper(ByCollapseAll);
            SelectedStandardsList = new WebElementWrapper(BySelectedStandardsList);
            SelectedStandardsItems = new WebElementWrapper(BySelectedStandardsItems);
            AvailableStandardsList = new WebElementWrapper(ByAvailableStandardsList);
            AvailableStandardsItems = new WebElementWrapper(ByAvailableStandardsItems);
            NoStandardSelectedLabel = new WebElementWrapper(ByNoStandardSelectedLabel);
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
        private string _currentWindow;
        /// <summary>
        /// fake text
        /// </summary>
        public string FakeText;
        /// <summary>
        /// expected required errors list
        /// </summary>
        public List<string> ExpectedRequiredErrorsList { get; set; }
        private new string ControlPrefix = "ctl00_MainContent_";
        private string ControlMiddle { get; set; }
        private By ByLightBox { get { return By.Id("lightBox"); } }
        private WebElementWrapper LightBox { get; set; }
        private By ByIFrame { get { return By.Id("lightBoxFrame"); } }
        private WebElementWrapper IFrame { get; set; }
        private By ByStandardDocument { get { return By.Id(ControlPrefix + ControlMiddle + "ddlStandardDoc"); } }
        private SelectElementWrapper StandardDocument { get; set; }
        //private Subject Subject { get; set; }
        public SelectElementWrapper SubjectSelect { get; private set; }
        private By ByGradeLevel { get { return By.Id(ControlPrefix + ControlMiddle + "DropDownGrade"); } }
        private SelectElementWrapper GradeLevel { get; set; }
        private By ByFindStandardText { get { return By.Id(ControlPrefix + ControlMiddle + "TxtFind"); } }
        private WebElementWrapper FindStandardText { get; set; }
        private By ByFindStandardButton { get { return By.Id("btnFind"); } }
        private WebElementWrapper FindStandardButton { get; set; }
        private By ByMainTable { get { return By.Id(ControlPrefix + ControlMiddle + "TableMain"); } }
        private WebElementWrapper MainTable { get; set; }
        private By ByMainDiv { get { return By.Id("divStandards"); } }
        private WebElementWrapper MainDiv { get; set; }
        private By ByExpandAll { get { return By.CssSelector("a[onclick*='toggleAll(true)']"); } }
        private WebElementWrapper ExpandAll { get; set; }
        private By ByCollapseAll { get { return By.CssSelector("a[onclick*='toggleAll(false)']"); } }
        private WebElementWrapper CollapseAll { get; set; }
        private By ByNoStandardSelectedLabel { get { return By.Id("spanNoStandards"); } }
        private WebElementWrapper NoStandardSelectedLabel { get; set; }
        private By BySelectedStandardsList { get { return By.Id("std0"); } }
        private WebElementWrapper SelectedStandardsList { get; set; }
        private By BySelectedStandardsItems { get { return By.CssSelector("ul#std0 > li"); } }
        private WebElementWrapper SelectedStandardsItems { get; set; }
        private ReadOnlyCollection<IWebElement> SelectedStandardsGroupWebElementList { get; set; }
        private List<SelectedStandardsGroupLineItem> SelectedStandardsGroupList { get; set; }
        private By ByAvailableStandardsList { get { return By.ClassName("CheckoutTable"); } }
        private WebElementWrapper AvailableStandardsList { get; set; }
        private By ByAvailableStandardsItems { get { return By.CssSelector(".ItemsCol > input"); } }
        private WebElementWrapper AvailableStandardsItems { get; set; }
        private ReadOnlyCollection<IWebElement> AvailableStandardsWebElementList { get; set; }
        private List<SelectedStandardsAvailableLineItem> AvailableStandardsGroupList { get; set; }

        /// <summary>
        /// the cancel by
        /// </summary>
        public override By ByCancel { get { return ByCancelLocator(); } }
        /// <summary>
        /// the submit by
        /// </summary>
        public override By BySubmit { get { return BySubmitLocator(); } }

        private By ByCancelLocator()
        {
            By by = null;
            if (PageNames == PageNames.TestItem)
            {
                by = By.CssSelector(".modal-footer [data-ng-click='close()']");
            }
            else
            {
                by = By.Id(ControlPrefix + "ButtonCancel");
            }
            return by;
        }
        private By BySubmitLocator()
        {
            By by = null;
            string locator = null;
            switch (PageNames)
            {
                case PageNames.TestItemStandardPopup:
                    //ctl00_MainContent_ButtonApply
                    locator = ControlPrefix + "ButtonApply";
                    by = By.Id(locator);
                    break;
                case PageNames.CreateNewItem:
                    locator = ControlPrefix + "ButtonApply";
                    by = By.Id(locator);
                    break;
                case PageNames.EditTestItem:
                    locator = ControlPrefix + "ButtonApply";
                    by = By.Id(locator);
                    break;
                case PageNames.EditTask:
                    locator = ControlPrefix + "ButtonApply";
                    by = By.Id(locator);
                    break;
                case PageNames.EditQuestion:
                    locator = ControlPrefix + "ButtonApply";
                    by = By.Id(locator);
                    break;
                case PageNames.ItemCentral:
                    //ctl00_MainContent_ItemFinder1_ItemFinderSearch1_btnAddStandards
                    locator = ControlPrefix + "ItemFinder1_ItemFinderSearch1_btnAddStandards";
                    by = By.Id(locator);
                    break;
                case PageNames.CreateTestBySelectingStandardsPage:
                    //btnAddBottom
                    locator = "btnAddBottom";
                    by = By.Id(locator);
                    break;
                case PageNames.EditRubric:
                    //btnAddBottom
                    locator = ControlPrefix + "ButtonApply";
                    by = By.Id(locator);
                    break;
                case PageNames.TestItem:
                    by = By.CssSelector(".modal-footer [data-ng-click='submit()']");
                    break;
            }
            return by;
        }
        private void SetSelectedStandardsGroupList()
        {
            SelectedStandardsGroupList = new List<SelectedStandardsGroupLineItem>();
            //wait to find the VISIBLE element for a specified amount of time
            SelectedStandardsList.Wait(15);
            //wait to find the list of EXISTING elements (VISIBLE or INVISIBLE) for a specified amount of time
            SelectedStandardsGroupWebElementList = SelectedStandardsItems.WaitForElements(5);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                DummyWebElement dummy0 = new DummyWebElement();
                dummy0.FakeAttributeValue = "49";
                dummy0.Text = "ACT Algebra 1";
                StandardDocument.FakeSelectedOption = dummy0;

                DummyWebElement dummy1 = new DummyWebElement();
                dummy1.FakeAttributeId = "17687";
                dummy1.FakeAttributeDocid = "49";
                dummy1.FakeAttributeNk = "ACT-Alg1-A";
                dummy1.FakeCssValueClass = "ExpandedNode";
                DummyWebElement dummy2 = new DummyWebElement();
                dummy2.FakeAttributeId = "17695";
                dummy2.FakeAttributeDocid = "49";
                dummy2.FakeAttributeNk = "ACT-Alg1-B";
                dummy2.FakeCssValueClass = "ExpandedNode";
                DummyWebElement dummy3 = new DummyWebElement();
                dummy3.FakeAttributeId = "17705";
                dummy3.FakeAttributeDocid = "49";
                dummy3.FakeAttributeNk = "ACT-Alg1-C";
                dummy3.FakeCssValueClass = "ExpandedNode";
                DummyWebElement dummy4 = new DummyWebElement();
                dummy4.FakeAttributeId = "17713";
                dummy4.FakeAttributeDocid = "49";
                dummy4.FakeAttributeNk = "ACT-Alg1-D";
                dummy4.FakeCssValueClass = "ContractedNode";
                DummyWebElement dummy5 = new DummyWebElement();
                dummy5.FakeAttributeId = "17732";
                dummy5.FakeAttributeDocid = "49";
                dummy5.FakeAttributeNk = "ACT-Alg1-E";
                dummy5.FakeCssValueClass = "ContractedNode";
                DummyWebElement dummy6 = new DummyWebElement();
                dummy6.FakeAttributeId = "17740";
                dummy6.FakeAttributeDocid = "49";
                dummy6.FakeAttributeNk = "ACT-Alg1-F";
                dummy6.FakeCssValueClass = "ContractedNode";
                DummyWebElement dummy7 = new DummyWebElement();
                dummy7.FakeAttributeId = "17749";
                dummy7.FakeAttributeDocid = "49";
                dummy7.FakeAttributeNk = "ACT-Alg1-G";
                dummy7.FakeCssValueClass = "ContractedNode";
                List<IWebElement> list = new List<IWebElement> { dummy1, dummy2, dummy3, dummy4, dummy5, dummy6, dummy7 };
                SelectedStandardsGroupWebElementList = new ReadOnlyCollection<IWebElement>(list);
            }

            foreach (var webElement in SelectedStandardsGroupWebElementList)
            {
                int standardId = int.Parse(webElement.GetAttribute("id"));
                //string clazz = webElement.GetCssValue("class");
                string clazz = webElement.GetAttribute("class");
                int standardDocumentId = int.Parse(webElement.GetAttribute("docid"));
                string standardName = webElement.GetAttribute("nk");
                Report.Write("SelectedStandardsGroupLineItem by standardId: '" + standardId + "'; class: '" + clazz + "'; standardDocumentId: '" + standardDocumentId + "'; standardName: '" + standardName);
                var standardsLineItem = new SelectedStandardsGroupLineItem(webElement, PageNames, standardId, clazz, standardDocumentId, standardName);
                SelectedStandardsGroupList.Add(standardsLineItem);
            }
        }

        /// <summary>
        /// gets the selected standards group list
        /// </summary>
        /// <returns>List of SelectedStandardsGroupLineItem</returns>
        public List<SelectedStandardsGroupLineItem> GetSelectedStandardsGroupList()
        {
            return SelectedStandardsGroupList;
        }

        private void SetAvailableStandardsGroupList()
        {
            AvailableStandardsGroupList = new List<SelectedStandardsAvailableLineItem>();
            //wait to find the VISIBLE element for a specified amount of time
            AvailableStandardsList.Wait(5);
            //wait to find the list of EXISTING elements (VISIBLE or INVISIBLE) for a specified amount of time
            AvailableStandardsWebElementList = AvailableStandardsItems.WaitForElements(5);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                DummyWebElement dummy1 = new DummyWebElement();
                dummy1.FakeAttributeId = "ctl00_MainContent_TestMapControl1_RepeaterTestMap_ctl00_TextBoxItems";
                dummy1.FakeAttributeKey = "17713";
                //dummy1.FakeAttributeNk = "ACT-Alg1-D";
                DummyWebElement dummy2 = new DummyWebElement();
                dummy2.FakeAttributeId = "ctl00_MainContent_TestMapControl1_RepeaterTestMap_ctl01_TextBoxItems";
                dummy2.FakeAttributeKey = "17714";
                //dummy2.FakeAttributeNk = "ACT-Alg1-D.1";
                List<IWebElement> list = new List<IWebElement> { dummy1, dummy2 };
                AvailableStandardsWebElementList = new ReadOnlyCollection<IWebElement>(list);
            }

            foreach (var webElement in AvailableStandardsWebElementList)
            {
                int standardId = int.Parse(webElement.GetAttribute("key"));
                string controlId = webElement.GetAttribute("id");
                Report.Write("SelectedStandardsAvailableLineItem by standardId: '" + standardId + "'; controlId: '" + controlId);
                var standardsLineItem = new SelectedStandardsAvailableLineItem(webElement, standardId, controlId);
                AvailableStandardsGroupList.Add(standardsLineItem);
            }
        }

        /// <summary>
        /// get the available standards group list
        /// </summary>
        /// <returns>List of SelectedStandardsAvailableLineItem</returns>
        public List<SelectedStandardsAvailableLineItem> GetAvailableStandardsGroupList()
        {
            return AvailableStandardsGroupList;
        }

        /// <summary>
        /// selects the standard document
        /// </summary>
        public void SelectStandardDocument()
        {
            WaitForFrameToDisplay();
            WaitForMainTableToDisplay();
            StandardDocument.Wait(5).SelectByText(Data.StandardDocument);
            DriverCommands.WaitAndMeasurePageLoadTime(90, 30);
            InitElements();
            WaitForFrameToDisplay();
            WaitForMainTableToDisplay();
            SetSelectedStandardsGroupList();
        }

        /// <summary>
        /// select the subject
        /// </summary>
        public void SelectSubject()
        {
            WaitForFrameToDisplay();
            WaitForMainTableToDisplay();
            SubjectSelect.Wait(5).SelectByText(Data.Subject);
            DriverCommands.WaitAndMeasurePageLoadTime(90, 30);
            InitElements();
            WaitForFrameToDisplay();
            WaitForMainTableToDisplay();
            SetSelectedStandardsGroupList();
        }

        /// <summary>
        /// select the grade level
        /// </summary>
        public void SelectGradeLevel()
        {
            WaitForFrameToDisplay();
            WaitForMainTableToDisplay();
            GradeLevel.Wait(5).SelectByText(Data.GradeLevel);
            DriverCommands.WaitAndMeasurePageLoadTime(90, 30);
            InitElements();
            WaitForFrameToDisplay();
            WaitForMainTableToDisplay();
            SetSelectedStandardsGroupList();
        }

        /// <summary>
        /// select the standard and verify that standard
        /// </summary>
        public void SelectAndVerifyStandard()
        {
            SelectStandardDocument();
            var selectedOption = StandardDocument.SelectedOption;
            int standardDocumentId = int.Parse(selectedOption.GetAttribute("value"));
            foreach (var standardsLineItem in SelectedStandardsGroupList)
            {
                int selectedStandardDocumentId = standardsLineItem.StandardDocumentId;
                int standardId = standardsLineItem.StandardId;
                Assert.IsTrue((standardDocumentId == selectedStandardDocumentId),
                    "Verified the Selected Standards Document ID does not match; StandardId: '" + standardId + "', expected: '" + standardDocumentId + "', actual: '" + selectedStandardDocumentId + "'.");
                Report.Write("Verified the Selected Standards Group Document ID : '" + standardDocumentId + "' does match for standardId: '" + standardId);
            }
        }

        /// <summary>
        /// expand the standard in the selected standards group list by name
        /// </summary>
        /// <param name="byStandardName">the standard name</param>
        public void ExpandStandardInGroupByName(string byStandardName)
        {
            //Debug.WriteLine("Expected standardName: " + byStandardName);
            foreach (var standard in SelectedStandardsGroupList)
            {
                //Debug.WriteLine("Actual StandardName: " + standard.StandardName);
                if (standard.StandardName.Equals(byStandardName))
                {
                    //Debug.WriteLine("in ExpandStandardInGroupByName()");
                    standard.ExpandStandard();
                    break;
                }
            }
        }

        /// <summary>
        /// expand the standard in the selected standards group list by ID
        /// </summary>
        /// <param name="byStandardId">the standard ID</param>
        public void ExpandStandardInGroupById(int byStandardId)
        {
            SetSelectedStandardsGroupList();
            //Debug.WriteLine("Expected standardId: " + byStandardId);
            foreach (var standard in SelectedStandardsGroupList)
            {
                //Debug.WriteLine("Actual StandardId: " + standard.StandardId);
                if (standard.StandardId == byStandardId)
                {
                    //Debug.WriteLine("in ExpandStandardInGroupById()");
                    standard.ExpandStandard();
                    break;
                }
            }
        }

        /// <summary>
        /// collapse the standard in the selected standards group list by name
        /// </summary>
        /// <param name="byStandardName">the standard name</param>
        public void CollapseStandardInGroupByName(string byStandardName)
        {
            //Debug.WriteLine("Expected standardName: " + byStandardName);
            foreach (var standard in SelectedStandardsGroupList)
            {
                //Debug.WriteLine("Actual StandardName: " + standard.StandardName);
                if (standard.StandardName.Equals(byStandardName))
                {
                    //Debug.WriteLine("in CollapseStandardInGroupByName()");
                    standard.CollapseStandard();
                    break;
                }
            }
        }

        /// <summary>
        /// collapse the standard in the selected standards group list by name
        /// </summary>
        /// <param name="byStandardId">the standard ID</param>
        public void CollapseStandardInGroupById(int byStandardId)
        {
            //Debug.WriteLine("Expected standardId: " + byStandardId);
            foreach (var standard in SelectedStandardsGroupList)
            {
                //Debug.WriteLine("Actual StandardId: " + standard.StandardId);
                if (standard.StandardId == byStandardId)
                {
                    //Debug.WriteLine("in CollapseStandardInGroupById()");
                    standard.CollapseStandard();
                    break;
                }
            }
        }

        /// <summary>
        /// select the standard check box in the selected standards group list by name
        /// </summary>
        /// <param name="byStandardName">the standard name</param>
        public void SelectStandardInGroupByName(string byStandardName)
        {
            //Debug.WriteLine("in SelectStandardInGroupByName()");
            RecursiveSelectStandardInGroupByName(byStandardName, SelectedStandardsGroupList);
        }

        private bool RecursiveSelectStandardInGroupByName(string byStandardName, List<SelectedStandardsGroupLineItem> selectedStandardsGroupList)
        {
            bool isFound = false;
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                selectedStandardsGroupList[0].StandardName = FakeText;
            }
            //Debug.WriteLine("in RecursiveSelectStandardInGroupByName()");
            //Debug.WriteLine("Expected standardName: " + byStandardName);
            foreach (var standard in selectedStandardsGroupList)
            {
                //Debug.WriteLine("Actual StandardName: " + standard.StandardName);
                if (standard.StandardName.ToLower().Contains(byStandardName.ToLower()))
                {
                    //Debug.WriteLine("in RecursiveSelectStandardInGroupByName() call SelectStandardOnly()");
                    standard.SelectStandardOnly();
                    isFound = true;
                    break;
                }
                List<SelectedStandardsGroupLineItem> childSelectedStandardsGroupList = standard.GetChildSelectedStandardsGroupList();
                if (childSelectedStandardsGroupList != null)
                {
                    isFound = RecursiveSelectStandardInGroupByName(byStandardName, childSelectedStandardsGroupList);
                    if (isFound == true)
                    {
                        break;
                    }
                }
            }
            return isFound;
        }

        /// <summary>
        /// select the standard in the selected standards group list by ID
        /// </summary>
        /// <param name="byStandardId">the standard ID</param>
        public void SelectStandardInGroupById(int byStandardId)
        {
            foreach (var standard in SelectedStandardsGroupList)
            {
                //Debug.WriteLine("StandardId: " + standard.StandardId);
                if (standard.StandardId == byStandardId)
                {
                    standard.SelectStandardOnly();
                    break;
                }
            }
        }

        /// <summary>
        /// select the first standard in the selected standards group list
        /// </summary>
        public void SelectFirstStandardInGroup()
        {
            SelectedStandardsGroupList.First().SelectStandardOnly();
        }

        /// <summary>
        /// select the last standard in the selected standards group list
        /// </summary>
        public void SelectLastStandardInGroup()
        {
            SelectedStandardsGroupList.Last().SelectStandardOnly();
        }

        /// <summary>
        /// select the first standard tree in the selected standards group list
        /// </summary>
        public void SelectFirstStandardTreeInGroup()
        {
            SelectedStandardsGroupList.First().SelectStandardsInGroup();
        }

        /// <summary>
        /// select the last standard tree in the selected standards group list
        /// </summary>
        public void SelectLastStandardTreeInGroup()
        {
            SelectedStandardsGroupList.Last().SelectStandardsInGroup();
        }

        /// <summary>
        /// select the entire standard tree in the selected standards group list
        /// </summary>
        public void SelectEntireStandardGroup()
        {
            foreach (var standard in SelectedStandardsGroupList)
            {
                standard.SelectStandardsInGroup();
            }
        }

        /// <summary>
        /// remove the standard in the available standards group list by ID
        /// </summary>
        /// <param name="byStandardId">the standard ID</param>
        public void RemoveAvailableStandard(int byStandardId)
        {
            SetAvailableStandardsGroupList();
            foreach (var standard in AvailableStandardsGroupList)
            {
                //Debug.WriteLine("StandardId: " + standard.StandardId);
                if (standard.StandardId == byStandardId)
                {
                    standard.Remove();
                    break;
                }
            }
        }

        /// <summary>
        /// set the quantity of the available standard item
        /// </summary>
        /// <param name="byStandardId"></param>
        /// <param name="quantity">the quantity</param>
        public void SetAvailableStandardItemQuantity(int byStandardId, int quantity)
        {
            SetAvailableStandardsGroupList();
            foreach (var standard in AvailableStandardsGroupList)
            {
                //Debug.WriteLine("StandardId: " + standard.StandardId);
                if (standard.StandardId == byStandardId)
                {
                    standard.SetItemQuantity(quantity);
                    break;
                }
            }
        }

        private void WaitForFrameToDisplay()
        {
            if ((this.PageNames == PageNames.TestItemStandardPopup)
                || (this.PageNames == PageNames.CreateNewItem)
                || (this.PageNames == PageNames.EditTestItem)
                || (this.PageNames == PageNames.EditTask)
                || (this.PageNames == PageNames.EditQuestion)
                || (this.PageNames == PageNames.EditRubric))
            {
                //switch to window
                DriverCommands.WaitToSwitchWindow(_currentWindow, 5);
                LightBox.WaitUntilExists(3);
                IFrame.WaitUntilExists(3);
                //Driver.SwitchTo().Frame(IFrame.Element);
                DriverCommands.WaitToSwitchFrame(IFrame, 3);
            }
        }

        private void WaitForMainTableToDisplay()
        {
            bool displayed = false;
            if ((this.PageNames == PageNames.TestItemStandardPopup)
                || (this.PageNames == PageNames.CreateNewItem)
                || (this.PageNames == PageNames.EditTestItem)
                || (this.PageNames == PageNames.EditTask)
                || (this.PageNames == PageNames.EditQuestion)
                || (this.PageNames == PageNames.ItemCentral)
                || (this.PageNames == PageNames.EditRubric))
            {
                displayed = MainTable.Wait(10).Displayed;
                if (MainTable.WrappedElement.GetType() != typeof(DummyWebElement))
                {
                    if (displayed == false)
                    {
                        throw new Exception(this.Utilities.GetInvisibleErrorMessage(MainTable.By.ToString()));
                    }
                }
            }
            if (this.PageNames == PageNames.CreateTestBySelectingStandardsPage)
            {
                displayed = MainDiv.Wait(10).Displayed;
                if (MainDiv.WrappedElement.GetType() != typeof(DummyWebElement))
                {
                    if (displayed == false)
                    {
                        throw new Exception(this.Utilities.GetInvisibleErrorMessage(MainDiv.By.ToString()));
                    }
                }
            }
        }

        public ReadOnlyCollection<IWebElement> GetDummyStepsToCompleteLabels()
        {
            ReadOnlyCollection<IWebElement> webElements = null;
            List<IWebElement> list = new List<IWebElement>();
            DummyWebElement dummy1 = new DummyWebElement();
            dummy1.Text = ExpectedRequiredErrorsList[0];
            dummy1.Displayed = true;

            list = new List<IWebElement> { dummy1 };
            webElements = new ReadOnlyCollection<IWebElement>(list);
            return webElements;
        }

        //implemented methods
        public override void InputFormFields()
        {
            SelectStandardDocument();
            SelectSubject();
            SelectGradeLevel();
            SelectFirstStandardTreeInGroup();
        }

        public override IBaseScreenView ReturnSubmitPage()
        {
            return null;
        }
        public override IBaseScreenView ReturnCancelPage()
        {
            return null;
        }

        public override IBaseScreenView SubmitForm()
        {
            Submit.Wait(5).Click();
            if ((this.PageNames == PageNames.TestItemStandardPopup)
                || (this.PageNames == PageNames.CreateNewItem)
                || (this.PageNames == PageNames.EditTestItem)
                || (this.PageNames == PageNames.EditTask)
                || (this.PageNames == PageNames.EditQuestion)
                || (this.PageNames == PageNames.EditRubric))
            {
                //switch to window
                DriverCommands.WaitToSwitchWindow(_currentWindow, 5);
            }
            //pause the script for a few seconds to let the page settle down
            System.Threading.Thread.Sleep(5000);

            //workaround for "*No standard(s) selected" after trying to select a standard
            try
            {
                if (NoStandardSelectedLabel.Wait(5).Displayed)
                {
                    SelectFirstStandardTreeInGroup();
                    Submit.Wait(5).Click();
                    if ((this.PageNames == PageNames.TestItemStandardPopup)
                        || (this.PageNames == PageNames.CreateNewItem)
                        || (this.PageNames == PageNames.EditTestItem)
                        || (this.PageNames == PageNames.EditTask)
                        || (this.PageNames == PageNames.EditQuestion)
                        || (this.PageNames == PageNames.EditRubric))
                    {
                        //switch to window
                        DriverCommands.WaitToSwitchWindow(_currentWindow, 5);
                    }
                    //pause the script for a few seconds to let the page settle down
                    System.Threading.Thread.Sleep(5000);
                }
            }
            catch (Exception e)
            {
                //do nothing
            }

            return ReturnSubmitPage();
        }
    }
}
