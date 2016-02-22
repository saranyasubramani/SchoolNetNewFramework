using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Views;
using UITests.Pages.Assess.TestWindow.ViewTestWindow;

namespace UITests.Pages.Assess.TestWindow
{
    /// <summary>
    /// view test window page
    /// </summary>
    public class ViewTestWindowPage : SNWebPage
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public ViewTestWindowPage()
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            this.ExpectedUrl = "/Assess/ViewTestWindow.aspx";
            this.VerifyCurrentUrl();
            InitElements();
        }
        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            this.Form = new ViewTestWindowForm();
            this.Form.Parent = this;
            this.Detail = new ViewTestWindowDetail();
            this.Detail.Parent = this;
        }
        /// <summary>
        /// the form
        /// </summary>
        public new ViewTestWindowForm Form { get; set; }
        /// <summary>
        /// the form
        /// </summary>
        public new ViewTestWindowDetail Detail { get; set; }

        /// <summary>
        /// the data
        /// </summary>
        public new ViewTestWindowData Data
        {
            get
            {
                return (ViewTestWindowData)base.Data;
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
        public ViewTestWindowData InitData()
        {
            base.InitData(new ViewTestWindowData());
            return (ViewTestWindowData)base.Data;
        }
        /// <summary>
        /// initializes the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>object data</returns>
        public ViewTestWindowData InitData(object data)
        {
            base.InitData(data);
            return (ViewTestWindowData)base.Data;
        }
    }
}
