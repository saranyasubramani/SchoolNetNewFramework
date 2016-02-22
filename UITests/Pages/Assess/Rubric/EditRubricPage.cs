using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Views;
using UITests.Pages.Assess.Rubric.Components;
using UITests.Pages.Assess.Rubric.EditRubric;

namespace UITests.Pages.Assess.Rubric
{
    /// <summary>
    /// Create or Edit Rubric page
    /// </summary>
    public class EditRubricPage : SNWebPage
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public EditRubricPage(RubricGroupType groupType)
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            this.ExpectedUrl = "/Assess/Items/EditRubric.aspx";
            this.VerifyCurrentUrl();
            GroupType = groupType;
            InitElements();
        }
        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            this.Form = new EditRubricForm(GroupType);
            this.Form.Parent = this;
            this.Detail = new EditRubricDetail();
            this.Detail.Parent = this;
        }
        /// <summary>
        /// the form
        /// </summary>
        public new EditRubricForm Form { get; set; }
        /// <summary>
        /// the detail
        /// </summary>
        public new EditRubricDetail Detail { get; set; }

        /// <summary>
        /// the data
        /// </summary>
        public new EditRubricData Data
        {
            get
            {
                return (EditRubricData)base.Data;
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
        public EditRubricData InitData()
        {
            base.InitData(new EditRubricData());
            return (EditRubricData)base.Data;
        }
        /// <summary>
        /// initializes the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>object data</returns>
        public EditRubricData InitData(object data)
        {
            base.InitData(data);
            return (EditRubricData)base.Data;
        }

        /// <summary>
        /// the rubric group type
        /// </summary>
        public RubricGroupType GroupType { get; set; }
    }
}
