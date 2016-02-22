using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Views;
using UITests.Pages.Assess.Rubric.Components;
using UITests.Pages.Assess.Rubric.EditRubricAvailability;

namespace UITests.Pages.Assess.Rubric
{
    /// <summary>
    /// The edit rubric availability page
    /// </summary>
    public class EditRubricAvailabilityPage : SNWebPage
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public EditRubricAvailabilityPage()
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            this.ExpectedUrl = "/Assess/EditRubricAvailability.aspx";
            this.VerifyCurrentUrl();
            InitElements();
        }
        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            this.Form = new EditRubricAvailabilityForm();
            this.Form.Parent = this;
        }
        /// <summary>
        /// the form
        /// </summary>
        public new EditRubricAvailabilityForm Form { get; private set; }

        /// <summary>
        /// the data
        /// </summary>
        public new EditRubricAvailabilityData Data
        {
            get
            {
                return (EditRubricAvailabilityData)base.Data;
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
        public new EditRubricAvailabilityData InitData()
        {
            base.InitData(new EditRubricAvailabilityData());
            return (EditRubricAvailabilityData)base.Data;
        }
        /// <summary>
        /// initializes the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>object data</returns>
        public EditRubricAvailabilityData InitData(object data)
        {
            base.InitData(data);
            return (EditRubricAvailabilityData)base.Data;
        }
    }
}
