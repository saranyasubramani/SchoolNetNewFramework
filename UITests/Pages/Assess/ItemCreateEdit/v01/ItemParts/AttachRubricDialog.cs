using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Views;

namespace UITests.Pages.Assess.ItemCreateEdit.v01.ItemParts
{
    /// <summary>
    /// attach rubric dialog
    /// </summary>
    public class AttachRubricDialog : SNWebPage
    {
        public AttachRubricDialog(string overrideControlPrefix = null)
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }
            InitElements();
        }
        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            this.Form = new AttachRubricDialogForm();
            this.Form.Parent = this;
            this.Detail = new AttachRubricDialogDetail();
            this.Detail.Parent = this;
        }
        /// <summary>
        /// the form
        /// </summary>
        public new AttachRubricDialogForm Form { get; set; }
        /// <summary>
        /// the detail
        /// </summary>
        public new AttachRubricDialogDetail Detail { get; set; }

        /// <summary>
        /// the data
        /// </summary>
        public new AttachRubricDialogData Data
        {
            get
            {
                return (AttachRubricDialogData)base.Data;
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
        public AttachRubricDialogData InitData()
        {
            base.InitData(new AttachRubricDialogData());
            return (AttachRubricDialogData)base.Data;
        }
        /// <summary>
        /// initializes the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>object data</returns>
        public AttachRubricDialogData InitData(object data)
        {
            base.InitData(data);
            return (AttachRubricDialogData)base.Data;
        }
    }
}
