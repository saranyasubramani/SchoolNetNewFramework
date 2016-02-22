using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace UITests.Pages.Assess.ItemCreateEdit.v01
{
    /// <summary>
    /// The edit test item page
    /// </summary>
    public abstract class EditTestItemPage : EditPageBase
    {
        /// <summary>
        /// the edit test item page constructor
        /// </summary>
        public EditTestItemPage()
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            this.ExpectedUrl = "/Assess/Items/EditTestItem.aspx";
            this.VerifyCurrentUrl();
            //overriding class calls InitElements();
        }
        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            
        }
    }
}
