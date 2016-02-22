using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;

namespace UITests.Pages.Assess.ItemCreateEdit.v01.ItemParts
{
    /// <summary>
    /// the attach rubric data
    /// </summary>
    public class AttachRubricDialogData : TestData
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public AttachRubricDialogData() : base(typeof(AttachRubricDialogData).Assembly) { }
        /// <summary>
        /// keyword search data
        /// </summary>
        public string FilterKeyword { get; set; }
        /// <summary>
        /// subject search data
        /// </summary>
        public string FilterSubject { get; set; }
        /// <summary>
        /// from grade search data
        /// </summary>
        public string FilterFromGrade { get; set; }
        /// <summary>
        /// to grade search data
        /// </summary>
        public string FilterToGrade { get; set; }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            this.FilterKeyword = base.GetParameterFromResxResource("FilterKeyword", testAttribute, row);
            this.FilterSubject = base.GetParameterFromResxResource("FilterSubject", testAttribute, row);
            this.FilterFromGrade = base.GetParameterFromResxResource("FilterFromGrade", testAttribute, row);
            this.FilterToGrade = base.GetParameterFromResxResource("FilterToGrade", testAttribute, row);
        }
    }
}
