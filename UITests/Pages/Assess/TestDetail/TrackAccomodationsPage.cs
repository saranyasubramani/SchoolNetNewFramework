using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Views;
using UITests.Pages.Assess.TestDetail.Components;
using UITests.Pages.Assess.TestDetail.TrackAccomodations;

namespace UITests.Pages.Assess.TestDetail
{
    /// <summary>
    /// Track Accomodations Page
    /// </summary>
    public class TrackAccomodationsPage : SNWebPage
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public TrackAccomodationsPage()
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            this.ExpectedUrl = "Assess/TrackAccomodations.aspx";
            this.VerifyCurrentUrl();
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            this.Form = new TrackAccomodationsForm();
            this.Form.Parent = this;
        }
        /// <summary>
        /// the form
        /// </summary>
        public new TrackAccomodationsForm Form { get; set; }

        /// <summary>
        /// the data
        /// </summary>
        public new TrackAccomodationsData Data
        {
            get
            {
                return (TrackAccomodationsData)base.Data;
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
        public new TrackAccomodationsData InitData()
        {
            base.InitData(new TrackAccomodationsData());
            return (TrackAccomodationsData)base.Data;
        }
        /// <summary>
        /// initializes the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>object data</returns>
        public TrackAccomodationsData InitData(object data)
        {
            base.InitData(data);
            return (TrackAccomodationsData)base.Data;
        }
    }
}
