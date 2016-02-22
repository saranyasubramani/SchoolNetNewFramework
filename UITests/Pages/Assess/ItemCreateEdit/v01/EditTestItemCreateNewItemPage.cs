using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using UITests.Pages.Components;
using UITests.Pages.Assess.ItemCreateEdit.v01.Components;
using UITests.Pages.Assess.ItemCreateEdit.v01.ItemForms;
using UITests.Pages.Assess.ItemCreateEdit.v01.EditTestItem;

namespace UITests.Pages.Assess.ItemCreateEdit.v01
{
    /// <summary>
    /// The create new item type page inherited from the edit test item page
    /// </summary>
    public class EditTestItemCreateNewItemPage : EditTestItemPage
    {
        /// <summary>
        /// the create new item page constructor
        /// </summary>
        public EditTestItemCreateNewItemPage()
            : base()
        {
            this.Name = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            InitElements();
        }
        /// <summary>
        /// the create new item page constructor
        /// </summary>
        /// <param name="itemTypeForm">item type form</param>
        public EditTestItemCreateNewItemPage(ItemTypeForm itemTypeForm)
            : base()
        {
            this._itemTypeForm = itemTypeForm;
            this._itemType = itemTypeForm.ItemType;
            this.Name = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            InitElements();
        }
        /// <summary>
        /// the create new item page constructor
        /// </summary>
        /// <param name="itemType">item type</param>
        public EditTestItemCreateNewItemPage(ItemType itemType)
            : base()
        {
            this._itemType = itemType;
            this._itemTypeForm = null;
            this.Name = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            InitElements();
        }
        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            Report.Write("Martin... in EditTestItemCreateNewItemPage.InitElements...");
            if (_itemTypeForm == null)
            {
                this.Form = new EditTestItemCreateNewItemForm(this._itemType, this.ControlPrefix);
            }
            else
            {
                this.Form = new EditTestItemCreateNewItemForm(this._itemTypeForm, this.ControlPrefix);
            }
            this.Form.Parent = this;
        }

        /// <summary>
        /// the form
        /// </summary>
        public new EditTestItemCreateNewItemForm Form { get; private set; }

        /// <summary>
        /// the data
        /// </summary>
        /// <remarks>overrides EditPageData.Data</remarks>
        public EditPageData Data
        {
            get
            {
                return (EditPageData)base.Data;
            }
            set
            {
                Report.Write("Martin... in EditTestItemCreateNewItemPage.Data...");
                base.Data = value;
                this.Form.Data = value;
            }
        }

        private ItemTypeForm _itemTypeForm;
        private ItemType _itemType;
    }
}
