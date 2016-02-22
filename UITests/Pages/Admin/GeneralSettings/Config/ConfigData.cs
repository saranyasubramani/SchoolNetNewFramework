using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;

namespace UITests.Pages.Admin.GeneralSettings.Config
{
    /// <summary>
    /// Config data
    /// </summary>
    public class ConfigData : TestData
    {
        /// <summary>
        /// constructor
        /// </summary>
        public ConfigData()
            : base(typeof(ConfigData).Assembly) { }
        public string Applications { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Go { get; set; }
        public string AudioResponseCaptureValue { get; set; }
        public Boolean AudioResponseCaptureEdit { get; set; }
        public Boolean AudioResponseCaptureSave { get; set; }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            this.Applications = base.GetParameterFromResxResource("Applications", testAttribute, row);
            this.Name = base.GetParameterFromResxResource("Name", testAttribute, row);
            this.Value = base.GetParameterFromResxResource("Value", testAttribute, row);
            this.Go = base.GetParameterFromResxResource("Go", testAttribute, row);
            this.AudioResponseCaptureValue = base.GetParameterFromResxResource("AudioResponseCaptureValue", testAttribute, row);
            this.AudioResponseCaptureEdit = base.GetBoolParameterFromResxResource("AudioResponseCaptureEdit", testAttribute, row);
            this.AudioResponseCaptureSave = base.GetBoolParameterFromResxResource("AudioResponseCaptureSave", testAttribute, row);
        }
    }
}
