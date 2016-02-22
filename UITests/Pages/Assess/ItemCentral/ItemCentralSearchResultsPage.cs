using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Views;
using Core.Tools.WebDriver;
using UITests.Pages.Components;
using UITests.Pages.Assess.ItemCentral.ItemCentralSearchResults;

namespace UITests.Pages.Assess.ItemCentral
{
    /// <summary>
    /// the item central - search results page
    /// </summary>
    public class ItemCentralSearchResultsPage : ItemCentralPage
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="itemCentralType">item central type</param>
        public ItemCentralSearchResultsPage(ItemCentralType itemCentralType)
            : base(itemCentralType)
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            this.Detail = new ItemCentralSearchResultsDetail(ItemCentralType);
            this.Detail.Parent = this;
            this.Form = new ItemCentralSearchResultsForm(ItemCentralType, ControlPrefix);
            this.Form.Parent = this;
        }

        /// <summary>
        /// the detail
        /// </summary>
        public new ItemCentralSearchResultsDetail Detail { get; private set; }
        /// <summary>
        /// the form
        /// </summary>
        public new ItemCentralSearchResultsForm Form { get; private set; }

        /// <summary>
        /// the data
        /// </summary>
        public new ItemCentralSearchResultsData Data
        {
            get
            {
                return (ItemCentralSearchResultsData)base.Data;
            }
            set
            {
                base.Data = value;
                this.Detail.Data = value;
                this.Form.Data = value;
            }
        }
        /// <summary>
        /// intializes the data
        /// </summary>
        /// <returns>object data</returns>
        public ItemCentralSearchResultsData InitData()
        {
            base.InitData(new ItemCentralSearchResultsData());
            return (ItemCentralSearchResultsData)base.Data;
        }
        /// <summary>
        /// initializes the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>object data</returns>
        public ItemCentralSearchResultsData InitData(object data)
        {
            base.InitData(data);
            return (ItemCentralSearchResultsData)base.Data;
        }
    }
}
