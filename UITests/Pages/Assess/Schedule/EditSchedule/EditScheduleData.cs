using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;

namespace UITests.Pages.Assess.Schedule.EditSchedule
{
    /// <summary>
    /// edit schedule data
    /// </summary>
    public class EditScheduleData : TestData
    {
        /// <summary>
        /// constructor
        /// </summary>
        public EditScheduleData()
            : base(typeof(EditScheduleData).Assembly) { }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string ScoreDate { get; set; }
        public string OnlinePassCode { get; set; }
        public string TestTime { get; set; }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            this.StartDate = base.GetParameterFromResxResource("StartDate", testAttribute, row);
            this.EndDate = base.GetParameterFromResxResource("EndDate", testAttribute, row);
            this.ScoreDate = base.GetParameterFromResxResource("ScoreDate", testAttribute, row);
            this.OnlinePassCode = base.GetParameterFromResxResource("OnlinePassCode", testAttribute, row);
            this.TestTime = base.GetParameterFromResxResource("TestTime", testAttribute, row);
        }
    }
}
