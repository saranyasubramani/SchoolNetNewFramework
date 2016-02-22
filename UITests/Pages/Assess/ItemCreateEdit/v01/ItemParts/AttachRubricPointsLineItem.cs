using System;
using System.Collections.Generic;
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
    /// attach rubric points line item
    /// </summary>
    public class AttachRubricPointsLineItem : SNComponent
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="index"></param>
        /// <param name="uniqueId"></param>
        /// <param name="overrideControlPrefix"></param>
        public AttachRubricPointsLineItem(int index, string uniqueId, string overrideControlPrefix = null)
            : base()
        {
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }
            Index = index;
            UniqueId = uniqueId;
            Points = new WebElementWrapper(ByPoints);
        }

        /// <summary>
        /// the line item's index
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// the line item's unique ID
        /// </summary>
        public string UniqueId { get; set; }
        //ctl00_MainContent_EditTestItemControl_EditRubricWeightControl1_rptRubricDimensions_ctl00_txtWeight
        //ctl00_MainContent_EditTestItemControl_EditRubricWeightControl1_rptRubricDimensions_ctl01_txtWeight
        private By ByPoints { get { return By.Id(ControlPrefix + "EditTestItemControl_EditRubricWeightControl1_rptRubricDimensions_" + UniqueId + "_txtWeight"); } }
        private WebElementWrapper Points { get; set; }

        /// <summary>
        /// input points
        /// </summary>
        /// <param name="pointsValue">points value</param>
        public void InputPoints(string pointsValue)
        {
            Points.Clear();
            Points.SendKeys(pointsValue);
        }
    }
}
