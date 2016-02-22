using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;
using UITests.Pages.Components;
using UITests.Pages.Assess.ItemCreateEdit.v01.ItemForms;

namespace UITests.Pages.Assess.ItemCreateEdit.v01.Components
{
    public class EditPageData : TestData
    {
        public EditPageData()
            : base(typeof(EditPageData).Assembly)
        {
            this.StandardPickerData = new StandardPickerData();
            this.ItemTypeData = new ItemTypeData();
            this.QuestionAnswerData = new QuestionAnswerData();
            this.AutoItData = new AutoItData();
        }
        public StandardPickerData StandardPickerData { get; set; }
        public ItemTypeData ItemTypeData { get; set; }
        public QuestionAnswerData QuestionAnswerData { get; set; }
        public AutoItData AutoItData { get; set; }
        public string PassageTitle { get; set; }

        public void GetTestDataFromResxResource(string ItemTypeUrl, string QuestionAnswerUrl, string testAttribute, int row)
        {
            //this.StandardPickerData.GetTestDataFromResxResource(url, testAttribute, row);
            this.ItemTypeData.GetTestDataFromResxResource(ItemTypeUrl, testAttribute, row);
            this.QuestionAnswerData.GetTestDataFromResxResource(QuestionAnswerUrl, testAttribute, row);
            if (this.QuestionAnswerData.PassageTitle != null)
            {
                this.PassageTitle = this.QuestionAnswerData.PassageTitle;
            }
            else if (this.ItemTypeData.PassageTitle != null)
            {
                this.PassageTitle = this.ItemTypeData.PassageTitle;
            }
            else
            {
                this.PassageTitle = "";
            }
        }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            //this.StandardPickerData.GetTestDataFromResxResource(url, testAttribute, row);
            this.ItemTypeData.GetTestDataFromResxResource(url, testAttribute, row);
            this.QuestionAnswerData.GetTestDataFromResxResource(url, testAttribute, row);
            if (this.QuestionAnswerData.PassageTitle != null)
            {
                this.PassageTitle = this.QuestionAnswerData.PassageTitle;
            }
            else if (this.ItemTypeData.PassageTitle != null)
            {
                this.PassageTitle = this.ItemTypeData.PassageTitle;
            }
            else
            {
                this.PassageTitle = "";
            }
        }
    }
}
