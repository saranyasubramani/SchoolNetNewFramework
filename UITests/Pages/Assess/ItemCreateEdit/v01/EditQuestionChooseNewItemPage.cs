using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using UITests.Pages.Assess.ItemCreateEdit.v01.Components;
using UITests.Pages.Assess.ItemCreateEdit.v01.EditQuestion;

namespace UITests.Pages.Assess.ItemCreateEdit.v01
{
    /// <summary>
    /// The choose new item type page inherited from the edit question page
    /// </summary>
    public class EditQuestionChooseNewItemPage : EditQuestionPage
    {
        /// <summary>
        /// create item type page constructor
        /// </summary>
        public EditQuestionChooseNewItemPage()
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
            Report.Write("Martin EditQuestionChooseNewItemPage.InitElements");
            base.InitElements();
            this.Detail = new EditQuestionChooseNewItemDetail();
            this.Detail.Parent = this;
            this.Form = new EditQuestionChooseNewItemForm();
            this.Form.Parent = this;
        }

        /// <summary>
        /// the detail
        /// </summary>
        public new EditQuestionChooseNewItemDetail Detail { get; private set; }
        /// <summary>
        /// the form
        /// </summary>
        public new EditQuestionChooseNewItemForm Form { get; private set; }

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
                Report.Write("Martin EditQuestionChooseNewItemPage.Data");
                base.Data = value;
                this.Form.Data = value;
                this.Detail.Data = value;
            }
        }
    }
}
