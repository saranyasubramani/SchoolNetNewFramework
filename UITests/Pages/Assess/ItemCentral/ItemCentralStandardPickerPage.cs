using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Views;
using UITests.Pages.Components;
using UITests.Pages.Assess.ItemCentral.ItemCentralStandardPicker;

namespace UITests.Pages.Assess.ItemCentral
{
    /// <summary>
    /// the item central - standard picker page
    /// </summary>
    public class ItemCentralStandardPickerPage : ItemCentralPage
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="itemCentralType">item central type</param>
        public ItemCentralStandardPickerPage(ItemCentralType itemCentralType)
            : base(itemCentralType)
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            this.ExpectedUrl = "/Assess/ItemCentralHome.aspx";
            this.VerifyCurrentUrl();
            this.ItemCentralType = itemCentralType;
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            this.Form = new ItemCentralStandardPickerForm(ItemCentralType);
            this.Form.Parent = this;
        }

        /// <summary>
        /// the form
        /// </summary>
        public new ItemCentralStandardPickerForm Form { get; private set; }
    }
}
