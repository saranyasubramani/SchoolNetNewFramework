using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;

namespace UITests.Pages.Assess.TestDetail.UsernameGenerator
{
    /// <summary>
    /// UsernameGenerator Data Class
    /// </summary>
    public class UsernameGeneratorData : TestData
    {
        /// <summary>
        /// constructor
        /// </summary>
        public UsernameGeneratorData()
            : base(typeof(UsernameGeneratorData).Assembly) { }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
        }
    }
}
