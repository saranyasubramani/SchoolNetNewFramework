using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UITests.Pages.Assess.ItemCreateEdit.v01.Components;
using UITests.Pages.Assess.ItemCreateEdit.v01.EditTestItem;

namespace UITests.Pages.Assess.ItemCreateEdit.v01
{
    /// <summary>
    /// The choose new item type page inherited from the edit test item page
    /// </summary>
    public class EditTestItemChooseNewItemPage : EditTestItemPage
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public EditTestItemChooseNewItemPage()
            : base()
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
            Report.Write("Martin... in EditTestItemChooseNewItemPage.InitElements...");
            this.Detail = new EditTestItemChooseNewItemDetail();
            this.Detail.Parent = this;
        }

        /// <summary>
        /// the detail
        /// </summary>
        public new EditTestItemChooseNewItemDetail Detail { get; private set; }
    }
}
