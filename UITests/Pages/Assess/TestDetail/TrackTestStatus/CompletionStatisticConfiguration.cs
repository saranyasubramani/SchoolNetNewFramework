using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITests.Pages.Assess.TestDetail.TrackTestStatus
{
    /// <summary>
    /// completion statistic configuration
    /// </summary>
    public class CompletionStatisticConfiguration
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="Location">location</param>
        /// <param name="NumEligibleTesting">number of eligible testing</param>
        /// <param name="NumDataCollected">number data collected</param>
        /// <param name="PercentDataCollected">percent data collected</param>
        /// <param name="CompletedOnline">completed online</param>
        /// <param name="CollectionStatus">collection status</param>
        public CompletionStatisticConfiguration(bool Location = false, bool NumEligibleTesting = false, bool NumDataCollected = false,
            bool PercentDataCollected = false, bool CompletedOnline = false, bool CollectionStatus = false)
        {
        }

        /// <summary>
        /// column field on grid that can be turn on/off
        /// </summary>
        public bool Location { get; set; }
        public bool NumEligibleTesting { get; set; }
        public bool NumDataCollected { get; set; }
        public bool PercentDataCollected { get; set; }
        public bool CompletedOnline { get; set; }
        public bool CollectionStatus { get; set; }
    }
}
