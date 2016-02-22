using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Views;
using UITests.Pages.Components;
using UITests.Pages.Assess.ItemCentral.ItemCentralHome;

namespace UITests.Pages.Assess.ItemCentral
{
    /// <summary>
    /// item central page
    /// </summary>
    public class ItemCentralHomePage : SNWebPage
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public ItemCentralHomePage()
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            this.ExpectedUrl = "/Assess/ItemCentralHome.aspx";
            this.VerifyCurrentUrl();
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            this.Form = new ItemCentralHomeForm(ControlPrefix);
            this.Form.Parent = this;
            this.Detail = new ItemCentralHomeDetail(ControlPrefix);
            this.Detail.Parent = this;
        }

        /// <summary>
        /// the form
        /// </summary>
        public new ItemCentralHomeForm Form { get; set; }
        /// <summary>
        /// the detail
        /// </summary>
        public new ItemCentralHomeDetail Detail { get; set; }

        /// <summary>
        /// the data
        /// </summary>
        public new ItemCentralHomeData Data
        {
            get
            {
                return (ItemCentralHomeData)base.Data;
            }
            set
            {
                base.Data = value;
                this.Form.Data = value;
            }
        }
        /// <summary>
        /// intializes the data
        /// </summary>
        /// <returns>object data</returns>
        public ItemCentralHomeData InitData()
        {
            base.InitData(new ItemCentralHomeData());
            return (ItemCentralHomeData)base.Data;
        }
        /// <summary>
        /// initializes the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>object data</returns>
        public ItemCentralHomeData InitData(object data)
        {
            base.InitData(data);
            return (ItemCentralHomeData)base.Data;
        }

        private ItemCentralType _itemCentralType;
        /// <summary>
        /// the item central type
        /// </summary>
        public ItemCentralType ItemCentralType
        {
            get
            {
                return _itemCentralType;
            }
            set
            {
                _itemCentralType = value;
                this.Form.ItemCentralType = _itemCentralType;
            }
        }
    }
}
