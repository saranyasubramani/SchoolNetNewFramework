using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;

namespace UITests.Pages.Assess.TestDetail.TrackAccomodations
{
    /// <summary>
    /// TrackAccomodations Data Class
    /// </summary>
    public class TrackAccomodationsData : TestData
    {
        /// <summary>
        /// constructor
        /// </summary>
        public TrackAccomodationsData()
            : base(typeof(TrackAccomodationsData).Assembly) { }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
        }
    }
}
