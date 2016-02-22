using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using UITests.Pages.Assess.ItemCreateEdit.v01.Components;
using UITests.Pages.Assess.ItemCreateEdit.v01.ItemForms;
using UITests.Pages.Assess.ItemCreateEdit.v01.EditTask;

namespace UITests.Pages.Assess.ItemCreateEdit.v01
{
    /// <summary>
    /// edit task page
    /// </summary>
    public class EditTaskPage : SNWebPage
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="itemTypeForm"></param>
        public EditTaskPage(ItemTypeForm itemTypeForm)
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            this.ExpectedUrl = "/Assess/Items/EditTask.aspx";
            this.VerifyCurrentUrl();

            this.itemTypeForm = itemTypeForm;
            InitElements();
        }
        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            Form = new EditTaskForm(itemTypeForm, ControlPrefix);
            Form.Parent = this;
            Detail = new EditTaskDetail(ControlPrefix);
            Detail.Parent = this;
        }
        /// <summary>
        /// the form
        /// </summary>
        public new EditTaskForm Form { get; private set; }
        /// <summary>
        /// the detail
        /// </summary>
        public new EditTaskDetail Detail { get; private set; }

        /// <summary>
        /// the data
        /// </summary>
        public new EditPageData Data
        {
            get
            {
                return (EditPageData)base.Data;
            }
            set
            {
                base.Data = value;
                this.Form.Data = value;
                this.Detail.Data = value;
            }
        }
        /// <summary>
        /// intializes the data
        /// </summary>
        /// <returns>object data</returns>
        public EditPageData InitData()
        {
            base.InitData(new EditPageData());
            return (EditPageData)base.Data;
        }
        /// <summary>
        /// initializes the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>object data</returns>
        public EditPageData InitData(object data)
        {
            base.InitData(data);
            return (EditPageData)base.Data;
        }

        private ItemTypeForm itemTypeForm;

        private List<ItemTypeForm> _itemList;
        /// <summary>
        /// list of test form types
        /// </summary>
        public List<ItemTypeForm> ItemList
        {
            get
            {
                return _itemList;
            }
            set
            {
                _itemList = value;
                this.Form.ItemList = _itemList;
                this.Detail.ItemList = _itemList;
            }
        }
    }
}
