using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;

namespace UITests.Pages.Admin.GeneralSettings.Cache
{
    /// <summary>
    /// cache data
    /// </summary>
    public class CacheData : TestData
    {
        /// <summary>
        /// constructor
        /// </summary>
        public CacheData()
            : base(typeof(CacheData).Assembly) { }
        public Boolean ClearAll { get; set; }
        public Boolean Refresh { get; set; }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            this.ClearAll = base.GetBoolParameterFromResxResource("ClearAll", testAttribute, row);
            this.Refresh = base.GetBoolParameterFromResxResource("Refresh", testAttribute, row);
        }
    }
}
