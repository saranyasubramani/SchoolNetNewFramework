using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;
using UITests.Pages.Assess.Components;
using UITests.Pages.Assess.ItemCreateEdit.v01.ItemParts;

namespace UITests.Pages.Components
{
    /// <summary>
    /// represents a test item's question and answer data
    /// </summary>
    public class QuestionAnswerData : TestData
    {
        public QuestionAnswerData()
            : base(typeof(QuestionAnswerData).Assembly)
        {
            QuestionLabelList = new List<string>();
            QuestionList = new List<string>();
            AnswerLabelList = new List<string>();
            AnswerList = new List<string>();
            AnswerCanBeUsedList = new List<string>();
            QuestionAnswerPair = new Dictionary<string, string>();
            QuestionAnswerTree = new Dictionary<string, List<string>>();
            CorrectAnswerList = new List<string>();
            CorrectAnswerPair = new Dictionary<string, string>();
            CorrectAnswerTree = new Dictionary<string, List<string>>();
            StudentAnswerList = new List<string>();
            StudentAnswerPair = new Dictionary<string, string>();
            StudentAnswerTree = new Dictionary<string, List<string>>();
            PointValueList = new List<string>();
            PointValuePair = new Dictionary<string, string>();
            PointValueTree = new Dictionary<string, Dictionary<string, string>>();
            TeacherExplanationList = new List<string>();
            StudentExplanationList = new List<string>();
            TrueFalseList = new List<string>() { "True", "False" };
            FileUploadTree = new Dictionary<bool, Dictionary<string, string>>();
        }

        public MultipleChoiceLayout AnswerChoiceLayoutOption { get; set; }

        public ItemType ItemType { get; set; }
        public int ItemID { get; set; }
        public int TestTunnelIndex { get; set; }
        public string QuestionContent { get; set; }
        public string StudentInstructions { get; set; }
        public string ScoringInstructions { get; set; }

        public List<string> QuestionLabelList { get; set; }
        public List<string> QuestionList { get; set; }
        public string QuestionEndingAfterLastGap { get; set; }

        public List<string> AnswerLabelList { get; set; }
        public List<string> AnswerList { get; set; }
        public List<string> AnswerCanBeUsedList { get; set; }

        public Dictionary<string, string> QuestionAnswerPair { get; set; }
        public Dictionary<string, List<string>> QuestionAnswerTree { get; set; }

        public List<string> CorrectAnswerList { get; set; }
        public Dictionary<string, string> CorrectAnswerPair { get; set; }
        public Dictionary<string, List<string>> CorrectAnswerTree { get; set; }

        public string StudentAnswer { get; set; }
        public List<string> StudentAnswerList { get; set; }
        public Dictionary<string, string> StudentAnswerPair { get; set; }
        public Dictionary<string, List<string>> StudentAnswerTree { get; set; }

        public List<string> PointValueList { get; set; }
        public Dictionary<string, string> PointValuePair { get; set; }
        public Dictionary<string, Dictionary<string, string>> PointValueTree { get; set; }
        public List<string> TeacherExplanationList { get; set; }
        public List<string> StudentExplanationList { get; set; }

        public List<string> TrueFalseList { get; set; }
        public string NumberOfAnswerSheetPages { get; set; }
        public string FilePath { get; set; }
        public string ResponseType { get; set; }
        public string Exemplars { get; set; }
        public string PassageTitle { get; set; }
        public AttachRubricDialogData RubricSearchData { get; set; }

        /// <summary>        
        /// Inner Dictionary Uses Question Content, Answer Content, Teacher or Student Explanation as Key. Inner Dictionary uses Image File Name to be uploaded as the Value.
        /// Outer Dictionary Uses True or False (boolean) as Key to indicate WithFileUpload or WithoutFileUpload. 
        /// To be used like PointValueTree. 
        /// </summary>
        public Dictionary<bool, Dictionary<string, string>> FileUploadTree { get; set; }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            this.ItemID = base.GetIntParameterFromResxResource("ItemID", testAttribute, row);
            this.TestTunnelIndex = base.GetIntParameterFromResxResource("TestTunnelIndex", testAttribute, row);
            this.QuestionContent = base.GetParameterFromResxResource("QuestionContent", testAttribute, row);
            this.StudentInstructions = base.GetParameterFromResxResource("StudentInstructions", testAttribute, row);
            this.ScoringInstructions = base.GetParameterFromResxResource("ScoringInstructions", testAttribute, row);
            this.QuestionEndingAfterLastGap = base.GetParameterFromResxResource("QuestionEndingAfterLastGap", testAttribute, row);
            this.StudentAnswer = base.GetParameterFromResxResource("StudentAnswer", testAttribute, row);
            this.NumberOfAnswerSheetPages = base.GetParameterFromResxResource("NumberOfAnswerSheetPages", testAttribute, row);
            this.FilePath = base.GetParameterFromResxResource("FilePath", testAttribute, row);
            this.ResponseType = base.GetParameterFromResxResource("ResponseType", testAttribute, row);
            this.Exemplars = base.GetParameterFromResxResource("Exemplars", testAttribute, row);
            this.PassageTitle = base.GetParameterFromResxResource("PassageTitle", testAttribute, row);
            getItemType(base.GetParameterFromResxResource("ItemType", testAttribute, row));
            getAnswerChoiceLayoutOption(base.GetParameterFromResxResource("AnswerChoiceLayoutOption", testAttribute, row));
            this.PointValuePair = this.GetPair(base.GetParameterFromResxResource("PointValuePair", testAttribute, row));
            this.PointValueList = this.GetList(base.GetParameterFromResxResource("PointValueList", testAttribute, row));
            this.QuestionList = this.GetList(base.GetParameterFromResxResource("QuestionList", testAttribute, row));
            this.AnswerList = this.GetList(base.GetParameterFromResxResource("AnswerList", testAttribute, row));
            this.CorrectAnswerList = this.GetList(base.GetParameterFromResxResource("CorrectAnswerList", testAttribute, row));
            this.StudentAnswerList = this.GetList(base.GetParameterFromResxResource("StudentAnswerList", testAttribute, row));
            this.StudentExplanationList = this.GetList(base.GetParameterFromResxResource("StudentExplanationList", testAttribute, row));
            this.TeacherExplanationList = this.GetList(base.GetParameterFromResxResource("TeacherExplanationList", testAttribute, row));
            this.QuestionAnswerPair = this.GetPair(base.GetParameterFromResxResource("QuestionAnswerPair", testAttribute, row));
            this.CorrectAnswerPair = this.GetPair(base.GetParameterFromResxResource("CorrectAnswerPair", testAttribute, row));
            this.StudentAnswerPair = this.GetPair(base.GetParameterFromResxResource("StudentAnswerPair", testAttribute, row));
        }

        private void getItemType(string itemType)
        {
            if (itemType != null)
            {
                if (!itemType.Trim().Equals(""))
                {
                    if (itemType.ToLower().Equals(ItemType.ClickStickClickDrop.ToString().ToLower()))
                    {
                        this.ItemType = ItemType.ClickStickClickDrop;
                    }
                    else if (itemType.ToLower().Equals(ItemType.DragAndDrop.ToString().ToLower()))
                    {
                        this.ItemType = ItemType.DragAndDrop;
                    }
                    else if (itemType.ToLower().Equals(ItemType.Gridded.ToString().ToLower()))
                    {
                        this.ItemType = ItemType.Gridded;
                    }
                    else if (itemType.ToLower().Equals(ItemType.HotSpotMultipleSelection.ToString().ToLower()))
                    {
                        this.ItemType = ItemType.HotSpotMultipleSelection;
                    }
                    else if (itemType.ToLower().Equals(ItemType.HotSpotSingleSelection.ToString().ToLower()))
                    {
                        this.ItemType = ItemType.HotSpotSingleSelection;
                    }
                    else if (itemType.ToLower().Equals(ItemType.InlineResponse.ToString().ToLower()))
                    {
                        this.ItemType = ItemType.InlineResponse;
                    }
                    else if (itemType.ToLower().Equals(ItemType.Matching.ToString().ToLower()))
                    {
                        this.ItemType = ItemType.Matching;
                    }
                    else if (itemType.ToLower().Equals(ItemType.MultipleChoice.ToString().ToLower()))
                    {
                        this.ItemType = ItemType.MultipleChoice;
                    }
                    else if (itemType.ToLower().Equals(ItemType.OpenResponse.ToString().ToLower()))
                    {
                        this.ItemType = ItemType.OpenResponse;
                    }
                    else if (itemType.ToLower().Equals(ItemType.Task.ToString().ToLower()))
                    {
                        this.ItemType = ItemType.Task;
                    }
                    else if (itemType.ToLower().Equals(ItemType.TrueFalse.ToString().ToLower()))
                    {
                        this.ItemType = ItemType.TrueFalse;
                    }
                }
            }
        }

        private void getAnswerChoiceLayoutOption(string answerChoiceLayoutOption)
        {
            if (answerChoiceLayoutOption != null)
            {
                if (!answerChoiceLayoutOption.Trim().Equals(""))
                {
                    if (answerChoiceLayoutOption.ToLower().Equals(MultipleChoiceLayout.OneColumn.ToString().ToLower()))
                    {
                        this.AnswerChoiceLayoutOption = MultipleChoiceLayout.OneColumn;
                    }
                    else if (answerChoiceLayoutOption.ToLower().Equals(MultipleChoiceLayout.TwoColumnsAcrossThenDown.ToString().ToLower()))
                    {
                        this.AnswerChoiceLayoutOption = MultipleChoiceLayout.TwoColumnsAcrossThenDown;
                    }
                    else if (answerChoiceLayoutOption.ToLower().Equals(MultipleChoiceLayout.TwoColumnsDownThenAcross.ToString().ToLower()))
                    {
                        this.AnswerChoiceLayoutOption = MultipleChoiceLayout.TwoColumnsDownThenAcross;
                    }
                }
            }
        }
    }
}
