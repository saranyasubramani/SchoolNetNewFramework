using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITests.Pages.Components
{
    /// <summary>
    /// Answer Choice Layouts. Especially useful for Multiple Choice Items. 
    /// Determines the display inside the Test Tunnel.
    /// </summary>
    public enum MultipleChoiceLayout
    {
        OneColumn,
        TwoColumnsAcrossThenDown,
        TwoColumnsDownThenAcross
    }
}
