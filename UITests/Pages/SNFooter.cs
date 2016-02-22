using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Views;
using UITests.Pages.Components;

namespace UITests.Pages
{
    public abstract class SNFooter : Footer
    {
        public SNFooter()
            : base()
        {
            DriverCommands = new SNDriverCommands();
            Utilities = new SNGlobalUtilities();
        }

        protected new SNDriverCommands DriverCommands { get; set; }
        protected SNGlobalUtilities Utilities { get; set; }

        public new SNWebPage Parent { get; set; }
    }
}
