using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITests.Pages.Assess.ItemCreateEdit.v01.Components;

namespace UITests.Pages.Assess.ItemCreateEdit.v01
{
    /// <summary>
    /// the base page for the edit test item and edit question pages
    /// </summary>
    public abstract class EditPageBase : SNWebPage
    {
        /// <summary>
        /// the edit page constructor
        /// </summary>
        public EditPageBase()
            : base()
        {
            //InitElements();
        }
        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {

        }

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
            }
        }
        /// <summary>
        /// intializes the data
        /// </summary>
        /// <returns>object data</returns>
        public new EditPageData InitData()
        {
            base.InitData(new EditPageData());
            return (EditPageData)base.Data;
        }
        /// <summary>
        /// initializes the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>object data</returns>
        public new EditPageData InitData(object data)
        {
            base.InitData(data);
            return (EditPageData)base.Data;
        }
    }
}
