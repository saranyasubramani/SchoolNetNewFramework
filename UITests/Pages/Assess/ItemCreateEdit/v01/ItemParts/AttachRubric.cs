using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Framework;
using Core.Views;
using Core.Tools.WebDriver;
using OpenQA.Selenium;
using UITests.Pages.Components;

namespace UITests.Pages.Assess.ItemCreateEdit.v01.ItemParts
{
    /// <summary>
    /// attach rubric component
    /// </summary>
    public class AttachRubric : SNComponent
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="overrideControlPrefix"></param>
        public AttachRubric(string overrideControlPrefix = null)
            : base()
        {
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }

            View = new WebElementWrapper(ByView);
            Clear = new WebElementWrapper(ByClear);
            WeightGrid = new WebElementWrapper(ByWeightGrid);
            WeightRows = new WebElementWrapper(ByWeightRows);
        }

        private string _controlPrefix2 = "EditTestItemControl_RubricQuickPicker1_";
        //ctl00_MainContent_EditTestItemControl_RubricQuickPicker1_lnkViewRubric
        private By ByView { get { return By.Id(ControlPrefix + _controlPrefix2 + "lnkViewRubric"); } }
        private WebElementWrapper View { get; set; }
        //ctl00_MainContent_EditTestItemControl_RubricQuickPicker1_btnDeleteRubric
        private By ByClear { get { return By.Id(ControlPrefix + _controlPrefix2 + "btnDeleteRubric"); } }
        private WebElementWrapper Clear { get; set; }
        private By ByWeightGrid { get { return By.Id("tblWeightSet"); } }
        private WebElementWrapper WeightGrid { get; set; }
        private By ByWeightRows { get { return By.CssSelector("tr"); } }
        private WebElementWrapper WeightRows { get; set; }
        List<AttachRubricPointsLineItem> AttachRubricWeightList;
        private ReadOnlyCollection<IWebElement> AttachRubricWeightWebElementList { get; set; }

        private string GetUniqueId(int index)
        {
            if (index >= 0 && index < 10)
                return "ctl0" + index.ToString();
            if (index >= 10 && index < 100)
                return "ctl" + index.ToString();

            return null;
        }

        private void SetAttachRubricWeightList()
        {
            AttachRubricWeightList = new List<AttachRubricPointsLineItem>();
            WeightGrid.Wait(3);
            AttachRubricWeightWebElementList = WeightRows.WaitForElements(5);
            if (Driver.GetType() == typeof(DummyDriver))
            {
                DummyWebElement dummy = new DummyWebElement();

                List<IWebElement> list = new List<IWebElement> { dummy, dummy, dummy, dummy };
                AttachRubricWeightWebElementList = new ReadOnlyCollection<IWebElement>(list);
            }

            int index = 0;
            foreach (var webElement in AttachRubricWeightWebElementList)
            {
                string uniqueId = null;
                uniqueId = GetUniqueId(index);

                var lineItem = new AttachRubricPointsLineItem(index, uniqueId);
                AttachRubricWeightList.Add(lineItem);
                index++;
            }
        }

        /// <summary>
        /// get the attach rubric weight list
        /// </summary>
        /// <returns>List of AttachRubricPointsLineItem</returns>
        public List<AttachRubricPointsLineItem> GetWeightList()
        {
            SetAttachRubricWeightList();
            return AttachRubricWeightList;
        }

        /// <summary>
        /// gets an item from the attach rubric weight list
        /// </summary>
        /// <param name="index">the index of the item</param>
        /// <returns>AttachRubricPointsLineItem</returns>
        public AttachRubricPointsLineItem GetItemFromWeightList(int index)
        {
            SetAttachRubricWeightList();
            return AttachRubricWeightList[index];
        }
    }
}
