using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITests.Pages.Assess.Components
{
    /// <summary>
    /// the test stage
    /// </summary>
    public enum TestStage
    {
        PrivateDraft,
        PublicDraft,
        ReadyToSchedule,
        Scheduled,
        InProgress,
        Completed,
        NotSpecified
    }
}
