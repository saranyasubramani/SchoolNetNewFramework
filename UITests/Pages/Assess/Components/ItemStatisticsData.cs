using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;

namespace UITests.Pages.Assess.Components
{
    /// <summary>
    /// item statistics data
    /// </summary>
    public class ItemStatisticsData : TestData
    {
        /// <summary>
        /// constructor
        /// </summary>
        public ItemStatisticsData()
            : base(typeof(ItemStatisticsData).Assembly) { }
        public string ItemType { get; set; }
        public string BloomsTaxonomy { get; set; }
        public string PassageType { get; set; }
        public string QuestionLanguage { get; set; }
        public string Spoken { get; set; }
        public string Written { get; set; }

        public int PValueLow { get; set; }
        public int PValueHigh { get; set; }
        public int ItemMeanLow { get; set; }
        public int ItemMeanHigh { get; set; }
        public int ResponseTimeLow { get; set; }
        public int ResponseTimeHigh { get; set; }

        public double ItemTotalScoreLow { get; set; }
        public double ItemTotalScoreHigh { get; set; }
        public double RaschItemDifficultyLow { get; set; }
        public double RaschItemDifficultyHigh { get; set; }
        
        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            this.ItemType = base.GetParameterFromResxResource("ItemType", testAttribute, row);
            this.BloomsTaxonomy = base.GetParameterFromResxResource("BloomsTaxonomy", testAttribute, row);
            this.PassageType = base.GetParameterFromResxResource("PassageType", testAttribute, row);
            this.QuestionLanguage = base.GetParameterFromResxResource("QuestionLanguage", testAttribute, row);
            this.Spoken = base.GetParameterFromResxResource("Spoken", testAttribute, row);
            this.Written = base.GetParameterFromResxResource("Written", testAttribute, row);

            this.PValueLow = base.GetIntParameterFromResxResource("PValueLow", testAttribute, row);
            this.PValueHigh = base.GetIntParameterFromResxResource("PValueHigh", testAttribute, row);
            this.ItemMeanLow = base.GetIntParameterFromResxResource("ItemMeanLow", testAttribute, row);
            this.ItemMeanHigh = base.GetIntParameterFromResxResource("ItemMeanHigh", testAttribute, row);
            this.ResponseTimeLow = base.GetIntParameterFromResxResource("ResponseTimeLow", testAttribute, row);
            this.ResponseTimeHigh = base.GetIntParameterFromResxResource("ResponseTimeHigh", testAttribute, row);

            this.ItemTotalScoreLow = base.GetDoubleParameterFromResxResource("ItemTotalScoreLow", testAttribute, row);
            this.ItemTotalScoreHigh = base.GetDoubleParameterFromResxResource("ItemTotalScoreHigh", testAttribute, row);
            this.RaschItemDifficultyLow = base.GetDoubleParameterFromResxResource("RaschItemDifficultyLow", testAttribute, row);
            this.RaschItemDifficultyHigh = base.GetDoubleParameterFromResxResource("RaschItemDifficultyHigh", testAttribute, row);
        }
    }
}
