using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Views;
using UITests.Pages.Assess.TestDetail.Components;
using UITests.Pages.Assess.TestDetail.UsernameGenerator;

namespace UITests.Pages.Assess.TestDetail
{
    /// <summary>
    /// username generator page
    /// </summary>
    public class UsernameGeneratorPage : SNWebPage
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public UsernameGeneratorPage()
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            this.ExpectedUrl = "Assess/UsernameGenerator.aspx";
            this.VerifyCurrentUrl();
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            this.Form = new UsernameGeneratorForm();
            this.Form.Parent = this;
        }
        /// <summary>
        /// the form
        /// </summary>
        public new UsernameGeneratorForm Form { get; set; }

        /// <summary>
        /// the data
        /// </summary>
        public new UsernameGeneratorData Data
        {
            get
            {
                return (UsernameGeneratorData)base.Data;
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
        public new UsernameGeneratorData InitData()
        {
            base.InitData(new UsernameGeneratorData());
            return (UsernameGeneratorData)base.Data;
        }
        /// <summary>
        /// initializes the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>object data</returns>
        public UsernameGeneratorData InitData(object data)
        {
            base.InitData(data);
            return (UsernameGeneratorData)base.Data;
        }
    }
}
