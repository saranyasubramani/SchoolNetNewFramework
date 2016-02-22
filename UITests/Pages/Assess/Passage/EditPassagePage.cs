using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Views;
using UITests.Pages.Assess.Passage.EditPassage;

namespace UITests.Pages.Assess.Passage
{
    /// <summary>
    /// edit passage page
    /// </summary>
    public class EditPassagePage : SNWebPage
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public EditPassagePage()
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            this.ExpectedUrl = "/Assess/Items/EditPassage.aspx";
            this.VerifyCurrentUrl();
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            this.Form = new EditPassageForm();
            this.Form.Parent = this;
        }
        /// <summary>
        /// the form
        /// </summary>
        public new EditPassageForm Form { get; set; }

        /// <summary>
        /// the data
        /// </summary>
        public new EditPassageData Data
        {
            get
            {
                return (EditPassageData)base.Data;
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
        public new EditPassageData InitData()
        {
            base.InitData(new EditPassageData());
            return (EditPassageData)base.Data;
        }
        /// <summary>
        /// initializes the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>object data</returns>
        public EditPassageData InitData(object data)
        {
            base.InitData(data);
            return (EditPassageData)base.Data;
        }
    }
}
