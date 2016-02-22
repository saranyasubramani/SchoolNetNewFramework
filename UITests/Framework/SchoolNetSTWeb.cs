using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Config;
using Core.Framework;

namespace UITests.Framework
{
    public class SchoolNetSTWeb : TestApplication, SchoolNet
    {
        public SchoolNetSTWeb(TestConfiguration testConfiguration)
            : base(testConfiguration)
        {

        }
    }
}
