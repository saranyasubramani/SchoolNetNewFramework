using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITests.Pages.Components.Editors
{
    /// <summary>
    /// editor dialog
    /// </summary>
    public class EditorDialog : SNWebPage
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="dialogType"></param>
        /// <param name="overrideControlPrefix"></param>
        public EditorDialog(EditorDialogType dialogType, string overrideControlPrefix = null)
            : base()
        {
            //Dialog shows up as iframe and new inner page. Hence dialog is model as page here. But no expected url. 
            DialogType = dialogType;
            InitElements();
        }
        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            this.Form = new EditorDialogForm();
            this.Form.Parent = this;
        }
        /// <summary>
        /// the form
        /// </summary>
        public new EditorDialogForm Form { get; set; }
        /// <summary>
        /// dialog type
        /// </summary>
        private EditorDialogType DialogType { get; set; }
    }
}
