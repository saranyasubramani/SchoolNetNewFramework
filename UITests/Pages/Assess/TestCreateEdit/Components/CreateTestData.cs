using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;

namespace UITests.Pages.Assess.TestCreateEdit.Components
{
    /// <summary>
    /// create test data
    /// </summary>
    public class CreateTestData : TestData
    {
        /// <summary>
        /// constructor
        /// </summary>
        public CreateTestData()
            : base(typeof(CreateTestData).Assembly) { }
        public CreateTestModes TestCreationMode { get; set; }
        public string TestId { get; set; }
        public string Subject { get; set; }
        public string GradeLow { get; set; }
        public string GradeHigh { get; set; }
        public string InstitutionSource { get; set; }
        public string TestCategory { get; set; }
        public string ScoreType { get; set; }
        public string PreferredStandardsDocument { get; set; }
        public string EnableTextFormattingOpenResponse { get; set; }
        public string DisableTextFormattingOpenResponse { get; set; }
        public bool EnableEquationEditor { get; set; }
        public string EnableYes { get; set; }
        public string EnableNo { get; set; }
        public bool Compass { get; set; }
        public bool CentimeterRuler { get; set; }
        public bool InchRuler { get; set; }
        public bool UnitRuler { get; set; }
        public bool Protractor { get; set; }
        public bool StudentCommentEndOfTest { get; set; }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            this.TestId = base.GetParameterFromResxResource("TestId", testAttribute, row);
            this.Subject = base.GetParameterFromResxResource("Subject", testAttribute, row);
            this.GradeLow = base.GetParameterFromResxResource("GradeLow", testAttribute, row);
            this.GradeHigh = base.GetParameterFromResxResource("GradeHigh", testAttribute, row);
            this.InstitutionSource = base.GetParameterFromResxResource("InstitutionSource", testAttribute, row);
            this.TestCategory = base.GetParameterFromResxResource("TestCategory", testAttribute, row);
            this.ScoreType = base.GetParameterFromResxResource("ScoreType", testAttribute, row);
            this.PreferredStandardsDocument = base.GetParameterFromResxResource("PreferredStandardsDocument", testAttribute, row);
            this.EnableTextFormattingOpenResponse = base.GetParameterFromResxResource("EnableTextFormattingOpenResponse", testAttribute, row);
            this.DisableTextFormattingOpenResponse = base.GetParameterFromResxResource("DisableTextFormattingOpenResponse", testAttribute, row);
            this.EnableEquationEditor = base.GetBoolParameterFromResxResource("EnableEquationEditor", testAttribute, row);
            this.EnableYes = base.GetParameterFromResxResource("EnableYes", testAttribute, row);
            this.EnableNo = base.GetParameterFromResxResource("EnableNo", testAttribute, row);
            this.Compass = base.GetBoolParameterFromResxResource("Compass", testAttribute, row);
            this.CentimeterRuler = base.GetBoolParameterFromResxResource("CentimeterRuler", testAttribute, row);
            this.InchRuler = base.GetBoolParameterFromResxResource("InchRuler", testAttribute, row);
            this.UnitRuler = base.GetBoolParameterFromResxResource("UnitRuler", testAttribute, row);
            this.Protractor = base.GetBoolParameterFromResxResource("Protractor", testAttribute, row);
            this.StudentCommentEndOfTest = base.GetBoolParameterFromResxResource("StudentCommentEndOfTest", testAttribute, row);
        }
    }
}
