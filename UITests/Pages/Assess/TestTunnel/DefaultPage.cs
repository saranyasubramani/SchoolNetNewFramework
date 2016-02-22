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
using UITests.Pages.Components;
using UITests.Pages.Assess.TestTunnel.TestForms;
using UITests.Pages.Assess.TestTunnel.TestParts;
using UITests.Pages.Assess.TestTunnel.Default;

namespace UITests.Pages.Assess.TestTunnel
{
    /// <summary>
    /// the test tunnel default page
    /// </summary>
    public class DefaultPage : SNWebPage
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public DefaultPage()
            : base()
        {
            InitElements();
            SwitchToTestTunnelWindow();
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            this.ExpectedUrl = "/onlinetest/default.aspx";
            this.VerifyCurrentUrl();
            GetItemMapping();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            Form = new DefaultForm();
            Form.Parent = this;
            Header = new DefaultHeader();
            Header.Parent = this;
            Footer = new DefaultFooter();
            Footer.Parent = this;
            Detail = new DefaultInstructionsDetail();
            Detail.Parent = this;
            TestResponseSummary = new DefaultResponseSummaryForm();
            TestResponseSummary.Parent = this;
            TestList = new List<TestTypeForm>();
        }
        /// <summary>
        /// the form
        /// </summary>
        public new DefaultForm Form { get; private set; }
        /// <summary>
        /// the header
        /// </summary>
        public new DefaultHeader Header { get; private set; }
        /// <summary>
        /// the footer
        /// </summary>
        public new DefaultFooter Footer { get; private set; }
        /// <summary>
        /// the test instructions
        /// </summary>
        public new DefaultInstructionsDetail Detail { get; private set; }
        /// <summary>
        /// Test Response Summary
        /// </summary>
        public DefaultResponseSummaryForm TestResponseSummary { get; private set; }
        /// <summary>
        /// schoolnet online help page
        /// </summary>
        //public SchoolnetOnlineHelpPage SchoolnetOnlineHelpPage { get; set; }


        /// <summary>
        /// the data
        /// </summary>
        public new DefaultData Data
        {
            get
            {
                return (DefaultData)base.Data;
            }
            set
            {
                base.Data = value;
                this.Form.Data = value;
                this.Header.Data = value;
                this.Footer.Data = value;
                this.Detail.Data = value;
                this.TestResponseSummary.Data = value;
            }
        }
        /// <summary>
        /// intializes the data
        /// </summary>
        /// <returns>object data</returns>
        public new DefaultData InitData()
        {
            base.InitData(new DefaultData());
            return (DefaultData)base.Data;
        }
        /// <summary>
        /// initializes the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>object data</returns>
        public DefaultData InitData(object data)
        {
            base.InitData(data);
            return (DefaultData)base.Data;
        }

        private List<TestTypeForm> _testList;
        /// <summary>
        /// list of test form types
        /// </summary>
        public List<TestTypeForm> TestList
        {
            get
            {
                return _testList;
            }
            set
            {
                _testList = value;
                this.Form.TestList = _testList;
                this.Header.TestList = _testList;
                this.Footer.TestList = _testList;
                this.Detail.TestList = _testList;
                this.TestResponseSummary.TestList = _testList;
            }
        }
        private ReadOnlyCollection<object> _itemIdToIndexList;
        /// <summary>
        /// get the item's list of IDs and indexes
        /// </summary>
        public ReadOnlyCollection<object> ItemIdToIndexList
        {
            get
            {
                return _itemIdToIndexList;
            }
            set
            {
                _itemIdToIndexList = value;
                this.Form.ItemIdToIndexList = _itemIdToIndexList;
                this.Header.ItemIdToIndexList = _itemIdToIndexList;
                this.Footer.ItemIdToIndexList = _itemIdToIndexList;
                this.Detail.ItemIdToIndexList = _itemIdToIndexList;
                this.TestResponseSummary.ItemIdToIndexList = _itemIdToIndexList;
            }
        }

        /// <summary>
        /// get the item's ID to index mapping, and store it in the ItemIdToIndexList
        /// </summary>
        private void GetItemMapping()
        {
            //https://team-automation-st.sndev.net/OnlineTest/onlinetest.js
            //getCurrentQuestion()
            string script =
                @"var items = [];"
                + "for (i = 0; i < questions.length; i++) {"
                + "    var index = questions[i].index;"
                + "    var itemID = questions[i].questionKey;"
                + "    var questionType = questions[i].questionType;"
                + "    var obj = {'index':index, 'itemID':itemID, 'questionType':questionType};"
                + "    items.push(obj);"
                + "}"
                + "return items;";

            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                List<object> list = new List<object>();
                Dictionary<string, object> dictionary1 = new Dictionary<string, object>();
                dictionary1.Add("itemID", "326237");
                dictionary1.Add("index", 0);
                dictionary1.Add("questionType", 0);
                list.Add(dictionary1);
                Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
                dictionary2.Add("itemID", "326238");
                dictionary2.Add("index", 1);
                dictionary2.Add("questionType", 1);
                list.Add(dictionary2);
                Dictionary<string, object> dictionary3 = new Dictionary<string, object>();
                dictionary3.Add("itemID", "326239");
                dictionary3.Add("index", 2);
                dictionary3.Add("questionType", 5);
                list.Add(dictionary3);
                Dictionary<string, object> dictionary4 = new Dictionary<string, object>();
                dictionary4.Add("itemID", "326240");
                dictionary4.Add("index", 3);
                dictionary4.Add("questionType", 2);
                list.Add(dictionary4);
                Dictionary<string, object> dictionary5 = new Dictionary<string, object>();
                dictionary5.Add("itemID", "326241");
                dictionary5.Add("index", 4);
                dictionary5.Add("questionType", 6);
                list.Add(dictionary5);
                Dictionary<string, object> dictionary6 = new Dictionary<string, object>();
                dictionary6.Add("itemID", "326242");
                dictionary6.Add("index", 5);
                dictionary6.Add("questionType", 7);
                list.Add(dictionary6);
                Dictionary<string, object> dictionary7 = new Dictionary<string, object>();
                dictionary7.Add("itemID", "326243");
                dictionary7.Add("index", 6);
                dictionary7.Add("questionType", 13);
                list.Add(dictionary7);
                Dictionary<string, object> dictionary8 = new Dictionary<string, object>();
                dictionary8.Add("itemID", "326244");
                dictionary8.Add("index", 7);
                dictionary8.Add("questionType", 14);
                list.Add(dictionary8);
                Dictionary<string, object> dictionary9 = new Dictionary<string, object>();
                dictionary9.Add("itemID", "326245");
                dictionary9.Add("index", 8);
                dictionary9.Add("questionType", 10);
                list.Add(dictionary9);
                Dictionary<string, object> dictionary10 = new Dictionary<string, object>();
                dictionary10.Add("itemID", "326246");
                dictionary10.Add("index", 9);
                dictionary10.Add("questionType", 0);
                list.Add(dictionary10);
                ItemIdToIndexList = new ReadOnlyCollection<object>(list);

                Report.Write("IJavaScriptExecutor.ExecuteScript('" + script + "')");
            }
            else
            {
                ItemIdToIndexList = ((IJavaScriptExecutor)Driver).ExecuteScript(script) as ReadOnlyCollection<object>;
            }
        }

        /// <summary>
        /// associate the test tunnel's index with each item in the test list.
        /// (map the item ID to the test tunnel's index).
        /// </summary>
        public void AssociateTestTunnelIndexWithTestList()
        {
            foreach (var testTypeForm in TestList)
            {
                QuestionAnswerData data = (QuestionAnswerData)testTypeForm.Data;
                data.TestTunnelIndex = GetTunnelIndexByItemId(data.ItemID);
            }
        }
        /// <summary>
        /// get an item from the test list by item ID
        /// </summary>
        /// <param name="itemID">the item ID</param>
        /// <returns>TestTypeForm</returns>
        public TestTypeForm GetItemFromTestListByItemID(int itemID)
        {
            TestTypeForm item = null;
            foreach (var testTypeForm in TestList)
            {
                QuestionAnswerData data = (QuestionAnswerData)testTypeForm.Data;
                if (data.ItemID == itemID)
                {
                    item = testTypeForm;
                    break;
                }
            }
            return item;
        }
        /// <summary>
        /// get an item from the test list by index
        /// </summary>
        /// <param name="index">the index</param>
        /// <returns>TestTypeForm</returns>
        public TestTypeForm GetItemFromTestListByIndex(int index)
        {
            TestTypeForm item = null;
            foreach (var testTypeForm in TestList)
            {
                QuestionAnswerData data = (QuestionAnswerData)testTypeForm.Data;
                if (data.TestTunnelIndex == index)
                {
                    item = testTypeForm;
                    break;
                }
            }
            return item;
        }

        /// <summary>
        /// get the index by item ID
        /// </summary>
        /// <param name="itemID">the item ID</param>
        /// <returns>index</returns>
        public int GetTunnelIndexByItemId(string itemID)
        {
            return GetTunnelIndexByItemId(Convert.ToInt32(itemID));
        }
        /// <summary>
        /// get the index by item ID
        /// </summary>
        /// <param name="itemID">the item ID</param>
        /// <returns>index</returns>
        public int GetTunnelIndexByItemId(int itemID)
        {
            Report.Write("itemID: " + itemID);
            object index = -1;
            foreach (var item in ItemIdToIndexList)
            {
                //Report.Write("Test Tunnel item type: " + item.GetType().ToString());
                var dictionary = (Dictionary<string, object>)item;
                if (dictionary.ContainsKey("itemID"))
                {
                    object id = dictionary["itemID"];
                    if (Convert.ToInt32(id).Equals(itemID))
                    {
                        if (dictionary.ContainsKey("index"))
                        {
                            index = dictionary["index"];
                            Report.Write("index: " + index);
                        }
                    }
                }
            }
            return Convert.ToInt32(index);
        }
        /// <summary>
        /// get the item ID by index
        /// </summary>
        /// <param name="index">the index</param>
        /// <returns>item ID</returns>
        public int GetTunnelItemIdByIndex(int index)
        {
            //Report.Write("Test Tunnel collection type: " + ItemIdIndexList.GetType().ToString());
            object itemID = null;
            foreach (var item in ItemIdToIndexList)
            {
                //Report.Write("Test Tunnel item type: " + item.GetType().ToString());
                var dictionary = (Dictionary<string, object>)item;
                if (dictionary.ContainsValue(index))
                {
                    if (dictionary.ContainsKey("itemID"))
                    {
                        itemID = dictionary["itemID"];
                    }
                }
            }
            return Convert.ToInt32(itemID);
        }

        public void SwitchToTestTunnelWindow()
        {
            //create dummy windows
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                List<string> windowList = new List<string>() { "Parent window", "Test tunnel window" };
                ReadOnlyCollection<string> windows = new ReadOnlyCollection<string>(windowList);
                ((DummyDriver)Driver.WrappedDriver).WindowHandles = windows;
            }

            //get the window handles
            IReadOnlyCollection<string> windowHandles = Driver.WindowHandles;
            //for each window in the window handles
            foreach (string window in windowHandles)
            {
                //if the window is NOT the current window in focus
                if (window != this.CurrentWindowHandle)
                {
                    //then it must be the test tunnel window
                    this.CurrentWindowHandle = window;
                    //switch to the test tunnel window
                    SwitchToWindow();
                    //DriverCommands.WaitToSwitchWindow(this.CurrentWindowHandle, 90.0);
                }
            }
        }

        /// <summary>
        /// Close test tunnel window and switch back to parent window
        /// </summary>
        public void Close()
        {
            Report.Write("Closing test tunnel window");
            Driver.Close();

            Report.Write("Switch back to parent window");
            IReadOnlyCollection<string> WindowLists = Driver.WindowHandles;
            DriverCommands.WaitToSwitchWindow(WindowLists.FirstOrDefault(), 90.0);
        }
    }
}
