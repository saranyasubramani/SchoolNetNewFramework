using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;

namespace UITests.Pages.Components
{
    /// <summary>
    /// Data Object containing all the AutoIt related variables.
    /// </summary>
    public class AutoItData : TestData
    {
        public AutoItData() : base(typeof(AutoItData).Assembly) { }
        public string DeploymentDirectory { get; set; }
        public string FileNameToBeUploaded { get; set; }
        public string AutoItExecutableName { get; set; }
        public string UploadImageScriptName { get; set; }
        public string UploadImageInIEScriptName { get; set; }
        public string UploadImageInChromeScriptName { get; set; }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            this.DeploymentDirectory = base.GetParameterFromResxResource("DeploymentDirectory", testAttribute, row);
            this.FileNameToBeUploaded = base.GetParameterFromResxResource("FileNameToBeUploaded", testAttribute, row);
            this.AutoItExecutableName = base.GetParameterFromResxResource("AutoItExecutableName", testAttribute, row);
            this.UploadImageScriptName = base.GetParameterFromResxResource("UploadImageScriptName", testAttribute, row);
            this.UploadImageInIEScriptName = base.GetParameterFromResxResource("UploadImageInIEScriptName", testAttribute, row);
            this.UploadImageInChromeScriptName = base.GetParameterFromResxResource("UploadImageInChromeScriptName", testAttribute, row);
        }
    }
}
