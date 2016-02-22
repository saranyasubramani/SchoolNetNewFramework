using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Data;
using UITests.Pages.Components;

namespace UITests.Data.Assess.Standards
{
    public class StandardPickerDataStructures : TestData
    {
        public StandardPickerDataStructures()
            : base(typeof(StandardPickerDataStructures).Assembly)
        {
        }

        public StandardPickerData GetDefaultStandardPickerData()
        {
            var data1 = new SelectedStandardsGroupData();
            data1.GetTestDataFromResxResource("UITests.Data.Assess.Standards.StandardPickerResource",
                "default_" + this.TestConfiguration.ApplicationName, 0);

            var data1A = new SelectedStandardsGroupData();
            data1A.GetTestDataFromResxResource("UITests.Data.Assess.Standards.SelectedStandardsGroupResource",
                "default_" + this.TestConfiguration.ApplicationName, 0);

            data1.Children = new List<SelectedStandardsGroupData> { data1A };

            var standardPickerData = new StandardPickerData();
            standardPickerData.GetTestDataFromResxResource("UITests.Data.Assess.Standards.StandardPickerResource",
                "default_" + this.TestConfiguration.ApplicationName, 0);

            standardPickerData.SelectedStandardsGroupData = data1;
            return standardPickerData;
        }
    }
}
