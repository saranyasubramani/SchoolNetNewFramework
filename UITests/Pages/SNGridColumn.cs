using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Core.Views.Grids;

namespace UITests.Pages
{
    /// <summary>
    /// The grid column component
    /// </summary>
    public class SNGridColumn : GridColumn
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="gridCssSelector">the grid CSS Selector</param>
        /// <param name="webElement">IWebElement</param>
        /// <param name="index">the index</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public SNGridColumn(string gridCssSelector, IWebElement webElement, int index, string overrideControlPrefix = null)
            : base()
        {
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }
            this.gridCssSelector = gridCssSelector;
            Element = webElement;
            Index = index;
            Report.Write("GridColumn Index: " + Index);
            InitElements();
        }

        public override void InitElements()
        {
            SetColumnSortType();
            SetColumnName();
        }

        protected string gridCssSelector { get; set; }
        /// <summary>
        /// IWebElement
        /// </summary>
        public IWebElement Element { get; private set; }
        /// <summary>
        /// the column's index
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// the column name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// the sort type
        /// </summary>
        public GridColumnSortType SortType { get; set; }
        /// <summary>
        /// fake text
        /// </summary>
        public string FakeText { get; set; }

        protected virtual void SetColumnSortType()
        {
            string content = Element.GetAttribute("class");
            Report.Write("Column attribute class: " + content);
            if (content.ToLower().Contains("sortable"))
            {
                if (content.ToLower().Contains("active-ascending"))
                {
                    SortType = GridColumnSortType.Ascending;
                }
                else if (content.ToLower().Contains("active-descending"))
                {
                    SortType = GridColumnSortType.Descending;
                }
                else
                {
                    SortType = GridColumnSortType.Sortable;
                }
            }
            else
            {
                SortType = GridColumnSortType.NotSortable;
            }
            Report.Write("GridColumn SortType: " + SortType);
        }

        protected virtual void SetColumnName()
        {
            string content = Element.Text;
            Report.Write("Column text: " + content);
            if (content.Contains("Test Name"))
            {
                Name = SNGridColumnNames.TestName;
            }
            else if (content.Contains("Actions"))
            {
                Name = SNGridColumnNames.Actions;
            }
            else
            {
                throw new Exception("The column was not found within the column content: '" + content + "'.");
            }
            Report.Write("GridColumn Name: " + Name);
        }
    }
}
