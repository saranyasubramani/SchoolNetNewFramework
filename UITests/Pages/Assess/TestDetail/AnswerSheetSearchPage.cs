using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Views;
using UITests.Pages.Assess.TestDetail.Components;
using UITests.Pages.Assess.TestDetail.AnswerSheetSearch;

namespace UITests.Pages.Assess.TestDetail
{
    /// <summary>
    /// the answer sheet generation page. A search page for answer sheet
    /// </summary>
    public class AnswerSheetSearchPage : SNWebPage
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public AnswerSheetSearchPage()
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            this.ExpectedUrl = "/Assess/AnswerSheetGenerator.aspx";
            this.VerifyCurrentUrl();
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            TabSection = new AnswerSheetSearchSectionForm();
            TabSection.Parent = this;
            TabSchoolGrade = new AnswerSheetSearchSchoolGradeForm();
            TabSchoolGrade.Parent = this;
            Detail = new AnswerSheetSearchDetail();
            Detail.Parent = this;
        }
        /// <summary>
        /// the section tab search form
        /// </summary>
        public AnswerSheetSearchSectionForm TabSection { get; set; }
        /// <summary>
        /// the school/grade tab search form
        /// </summary>
        public AnswerSheetSearchSchoolGradeForm TabSchoolGrade { get; set; }
        /// <summary>
        /// the details
        /// </summary>
        public new AnswerSheetSearchDetail Detail { get; set; }

        /// <summary>
        /// the data
        /// </summary>
        public new AnswerSheetSearchData Data
        {
            get
            {
                return (AnswerSheetSearchData)base.Data;
            }
            set
            {
                base.Data = value;
                this.TabSection.Data = value;
                this.TabSchoolGrade.Data = value;
                this.Detail.Data = value;
            }
        }
        /// <summary>
        /// intializes the data
        /// </summary>
        /// <returns>object data</returns>
        public new AnswerSheetSearchData InitData()
        {
            base.InitData(new AnswerSheetSearchData());
            return (AnswerSheetSearchData)base.Data;
        }
        /// <summary>
        /// initializes the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>object data</returns>
        public AnswerSheetSearchData InitData(object data)
        {
            base.InitData(data);
            return (AnswerSheetSearchData)base.Data;
        }
    }
}
