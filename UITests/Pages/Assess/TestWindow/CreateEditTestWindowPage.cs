using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Views;
using UITests.Pages.Assess.TestWindow.CreateEditTestWindow;

namespace UITests.Pages.Assess.TestWindow
{
    /// <summary>
    /// create edit test window page
    /// </summary>
    public class CreateEditTestWindowPage : SNWebPage
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public CreateEditTestWindowPage()
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            this.ExpectedUrl = "/Assess/CreateEditTestWindow.aspx";
            this.VerifyCurrentUrl();
            InitElements();
        }
        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            this.Form = new CreateEditTestWindowForm();
            this.Form.Parent = this;
        }
        /// <summary>
        /// the form
        /// </summary>
        public new CreateEditTestWindowForm Form { get; set; }

        /// <summary>
        /// the data
        /// </summary>
        public new CreateEditTestWindowData Data
        {
            get
            {
                return (CreateEditTestWindowData)base.Data;
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
        public new CreateEditTestWindowData InitData()
        {
            base.InitData(new CreateEditTestWindowData());
            return (CreateEditTestWindowData)base.Data;
        }
        /// <summary>
        /// initializes the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>object data</returns>
        public CreateEditTestWindowData InitData(object data)
        {
            base.InitData(data);
            return (CreateEditTestWindowData)base.Data;
        }
    }
}
