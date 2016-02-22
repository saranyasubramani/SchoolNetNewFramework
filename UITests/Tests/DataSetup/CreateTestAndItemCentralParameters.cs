using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using UITests.Pages.Components;

namespace UITests.Tests.DataSetup
{
    /// <summary>
    /// Create Test and Item Central parameters to iterate the tests
    /// </summary>
    public class CreateTestAndItemCentralParameters
    {
        /// <summary>
        /// Get Create Test and Item Central data to search for 1 item
        /// </summary>
        public static IEnumerable GetParametersToForOneItem
        {
            get
            {
                //multiple choice items
                yield return new TestCaseData(new CreateTestAndItemCentralData("OriginalAutomationTestWithOneMCItemWithOneColumnLayout",
                    ItemType.MultipleChoice, "OriginalAutomationMCItemWithOneColumnLayoutName", "OriginalAutomationMultipleChoiceItemKeyword", 1));
                yield return new TestCaseData(new CreateTestAndItemCentralData("OriginalAutomationTestWithOneMCItemWithTwoColumnsAcrossThenDownLayout",
                    ItemType.MultipleChoice, "OriginalAutomationMCItemWithTwoColumnsAcrossThenDownLayoutName", "OriginalAutomationMultipleChoiceItemKeyword", 1));
                yield return new TestCaseData(new CreateTestAndItemCentralData("OriginalAutomationTestWithOneMCItemWithTwoColumnsDownThenAcrossLayout",
                    ItemType.MultipleChoice, "OriginalAutomationMCItemWithTwoColumnsDownThenAcrossLayoutName", "OriginalAutomationMultipleChoiceItemKeyword", 1));
                yield return new TestCaseData(new CreateTestAndItemCentralData("OriginalAutomationTestWithTwoMCItemsWithOneColumnLayout",
                    ItemType.MultipleChoice, "OriginalAutomationMCItemWithOneColumnLayoutName", "OriginalAutomationMultipleChoiceItemKeyword", 2));
                yield return new TestCaseData(new CreateTestAndItemCentralData("OriginalAutomationTestWithFiveMCItemsWithOneColumnLayout",
                    ItemType.MultipleChoice, "OriginalAutomationMCItemWithOneColumnLayoutName", "OriginalAutomationMultipleChoiceItemKeyword", 5));
                //open response items
                yield return new TestCaseData(new CreateTestAndItemCentralData("OriginalAutomationTestWithOneORItemWithTextFormattingEnabled",
                    ItemType.OpenResponse, "OriginalAutomationORItemWithTextFormattingEnabledName", "OriginalAutomationOpenResponseItemKeyword", 1));
                //true false items
                yield return new TestCaseData(new CreateTestAndItemCentralData("OriginalAutomationTestWithOneTFItemWithCorrectResponseTrue",
                    ItemType.TrueFalse, "OriginalAutomationTFItemWithCorrectResponseTrueName", "OriginalAutomationTrueFalseItemKeyword", 1));
            }
        }

        /// <summary>
        /// Get Create Test and Item Central data to search for 2 items
        /// </summary>
        public static IEnumerable GetParametersToForTwoItems
        {
            get
            {
                //multiple choice items
                yield return new TestCaseData(
                    new CreateTestAndItemCentralData("OriginalAutomationTestWithTwoItems_OneMCItemWithOneColumnLayoutAndOneMatchingItem",
                    ItemType.MultipleChoice, "OriginalAutomationMCItemWithOneColumnLayoutName", "OriginalAutomationMultipleChoiceItemKeyword", 1),
                    new CreateTestAndItemCentralData("OriginalAutomationTestWithTwoItems_OneMCItemWithOneColumnLayoutAndOneMatchingItem",
                    ItemType.Matching, "OriginalAutomationMatchingItemName", "OriginalAutomationMatchingItemKeyword", 1) );


            }
        }
    }
    /// <summary>
    /// Create Test and Item Central data to drive the tests
    /// </summary>
    public class CreateTestAndItemCentralData
    {
        public CreateTestAndItemCentralData(string testID, ItemType itemType, string itemName, string itemKeyword, int numberOfItems)
        {
            TestID = testID;
            ItemType = itemType;
            ItemName = itemName;
            ItemKeyword = itemKeyword;
            NumberOfItems = numberOfItems;
            
        }
        public string TestID { get; set; }
        public string ItemName { get; set; }
        public string ItemKeyword { get; set; }
        public int NumberOfItems { get; set; }
        public ItemType ItemType { get; set; }
    }
}

