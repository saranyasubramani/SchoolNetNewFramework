using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITests.Pages.Components.Editors
{
    /// <summary>
    /// teacher instruction editor
    /// </summary>
    public class TeacherInstructionEditor : SNWebPage
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="pageName"></param>
        /// <param name="overrideControlPrefix"></param>
        public TeacherInstructionEditor(PageNames pageName, string overrideControlPrefix = null)
            : base()
        {
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }

            PageNames = pageName;
            InitElements();
        }
        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            switch (PageNames)
            {
                case PageNames.EditTestItem:
                    ControlPrefix = ControlPrefix + "ContentHtmlEditor_HtmlEditor_";
                    break;
                case PageNames.CreateNewItem:
                    ControlPrefix = ControlPrefix + "ContentHtmlEditor_HtmlEditor_";
                    break;
                case PageNames.CreatePassage:
                    //ControlPrefix = ControlPrefix + "HtmlEditor_HtmlEditor_";
                    ControlPrefix = ControlPrefix + "ContentHtmlEditor_HtmlEditor_";
                    break;
                case PageNames.EditPassage:
                    //ControlPrefix = ControlPrefix + "HtmlEditor_HtmlEditor_";
                    ControlPrefix = ControlPrefix + "ContentHtmlEditor_HtmlEditor_";
                    break;
                case PageNames.EditTask:
                    //ControlPrefix = ControlPrefix + "HtmlEditor_HtmlEditor_";
                    ControlPrefix = ControlPrefix + "ContentHtmlEditor_HtmlEditor_";
                    break;
                case PageNames.EditQuestion:
                    //ControlPrefix = ControlPrefix + "HtmlEditor_HtmlEditor_";
                    ControlPrefix = ControlPrefix + "ContentHtmlEditor_HtmlEditor_";
                    break;
            }
            this.Form = new TeacherInstructionEditorForm(this.ControlPrefix);
            this.Form.Parent = this;
        }
        /// <summary>
        /// the form
        /// </summary>
        public new TeacherInstructionEditorForm Form { get; set; }

        /// <summary>
        /// the data
        /// </summary>
        public AutoItData Data
        {
            get
            {
                return (AutoItData)base.Data;
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
        public AutoItData InitData()
        {
            base.InitData(new AutoItData());
            return (AutoItData)base.Data;
        }
        /// <summary>
        /// initializes the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>object data</returns>
        public AutoItData InitData(object data)
        {
            base.InitData(data);
            return (AutoItData)base.Data;
        }

        private PageNames PageNames { get; set; }
    }
}
