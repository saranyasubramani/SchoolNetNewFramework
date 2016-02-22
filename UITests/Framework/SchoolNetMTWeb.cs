using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Config;
using Core.Framework;

namespace UITests.Framework
{
    public class SchoolNetMTWeb : TestApplication, SchoolNet
    {
        public SchoolNetMTWeb(TestConfiguration testConfiguration)
            : base(testConfiguration)
        {

        }
    }
}
