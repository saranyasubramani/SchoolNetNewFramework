using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Views;
using UITests.Pages.Assess.TestCreateEdit.Components;

namespace UITests.Pages.Assess.TestCreateEdit
{
    /// <summary>
    /// create test page
    /// </summary>
    public abstract class CreateTestPage : SNWebPage
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public CreateTestPage()
            : base()
        {
            //overriding class calls InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            Report.Write("Martin CreateTestPage.InitElements");
            this.Form = new CreateTestForm();
            this.Form.Parent = this;
        }
        /// <summary>
        /// the form
        /// </summary>
        public new CreateTestForm Form { get; set; }

        /// <summary>
        /// the data
        /// </summary>
        public new CreateTestData Data
        {
            get
            {
                return (CreateTestData)base.Data;
            }
            set
            {
                Report.Write("Martin CreateTestPage.Data");
                base.Data = value;
                //overriding class calls this.Form.Data = value;
            }
        }
        /// <summary>
        /// intializes the data
        /// </summary>
        /// <returns>object data</returns>
        public new CreateTestData InitData()
        {
            base.InitData(new CreateTestData());
            return (CreateTestData)base.Data;
        }
        /// <summary>
        /// initializes the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>object data</returns>
        public CreateTestData InitData(object data)
        {
            base.InitData(data);
            return (CreateTestData)base.Data;
        }
    }
}
