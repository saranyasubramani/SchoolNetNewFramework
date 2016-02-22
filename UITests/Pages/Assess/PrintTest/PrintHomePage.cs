using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Views;
using UITests.Pages.Assess.PrintTest.PrintHome;

namespace UITests.Pages.Assess.PrintTest
{
    /// <summary>
    /// Print Home page
    /// </summary>
    public class PrintHomePage : SNWebPage
    {
        /// <summary>
        /// constructor
        /// </summary>
        public PrintHomePage()
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            this.ExpectedUrl = "/Assess/PrintHome.aspx";
            this.VerifyCurrentUrl();
            InitElements();
        }
        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            this.Form = new PrintHomeForm();
            this.Form.Parent = this;
            this.Detail = new PrintHomeDetail();
            this.Detail.Parent = this;
        }
        /// <summary>
        /// the form
        /// </summary>
        public new PrintHomeForm Form { get; set; }
        /// <summary>
        /// the form
        /// </summary>
        public new PrintHomeDetail Detail { get; set; }

        /// <summary>
        /// the data
        /// </summary>
        public new PrintHomeData Data
        {
            get
            {
                return (PrintHomeData)base.Data;
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
        public PrintHomeData InitData()
        {
            base.InitData(new PrintHomeData());
            return (PrintHomeData)base.Data;
        }
        /// <summary>
        /// initializes the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>object data</returns>
        public PrintHomeData InitData(object data)
        {
            base.InitData(data);
            return (PrintHomeData)base.Data;
        }
    }
}
