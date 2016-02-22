using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITests.Pages.Components.Editors
{
    /// <summary>
    /// insert link dialog
    /// </summary>
    public class InsertLinkDialog : EditorDialog
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="overrideControlPrefix"></param>
        public InsertLinkDialog(string overrideControlPrefix = null)
            : base(EditorDialogType.InsertLink)
        {
            InitElements();
        }
        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            this.Form = new InsertLinkDialogForm();
            this.Form.Parent = this;
        }
        /// <summary>
        /// the form
        /// </summary>
        public new InsertLinkDialogForm Form { get; set; }

        /// <summary>
        /// the data
        /// </summary>
        public new InsertLinkDialogData Data
        {
            get
            {
                return (InsertLinkDialogData)base.Data;
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
        public new InsertLinkDialogData InitData()
        {
            base.InitData(new InsertLinkDialogData());
            return (InsertLinkDialogData)base.Data;
        }
        /// <summary>
        /// initializes the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>object data</returns>
        public InsertLinkDialogData InitData(object data)
        {
            base.InitData(data);
            return (InsertLinkDialogData)base.Data;
        }
    }
}
