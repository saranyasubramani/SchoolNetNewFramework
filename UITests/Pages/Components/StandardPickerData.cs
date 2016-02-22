using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;

namespace UITests.Pages.Components
{
    public class StandardPickerData : TestData
    {
        public StandardPickerData()
            : base(typeof(StandardPickerData).Assembly)
        {
            this.SelectedStandardsGroupData = new SelectedStandardsGroupData();
        }
        public string StandardDocument { get; set; }
        public string Subject { get; set; }
        public string GradeLevel { get; set; }
        public SelectedStandardsGroupData SelectedStandardsGroupData { get; set; }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            this.StandardDocument = base.GetParameterFromResxResource("StandardDocument", testAttribute, row);
            this.Subject = base.GetParameterFromResxResource("Subject", testAttribute, row);
            this.GradeLevel = base.GetParameterFromResxResource("GradeLevel", testAttribute, row);
            //this.SelectedStandardsGroupData.GetTestDataFromResxResource(url, testAttribute, row);
        }
    }
}
