using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages;
using UITests.Pages.Components;
using UITests.Pages.Assess.Components;

namespace UITests.Pages.Assess.ItemCreateEdit.v01.ItemForms
{
    /// <summary>
    /// Item Type Form
    /// </summary>
    public abstract class ItemTypeForm : SNForm
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="itemType"></param>
        public ItemTypeForm(ItemType itemType)
            : base()
        {
            this.ItemType = itemType;
            InitElements();
        }
        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            EnableToolsManipulatives = new EnableToolsManipulatives(PageNames.CreateNewItem, this.ControlPrefix);
            EnableTextFormatting = new EnableTextFormatting(PageNames.CreateNewItem, this.ControlPrefix);
            FormulaReferenceSheetSelect = new WebElementWrapper(ByFormulaReferenceSheetSelect);
            StepsToCompleteLabels = new WebElementWrapper(ByStepsToCompleteLabels);
        }

        /// <summary>
        /// the data
        /// </summary>
        public new ItemTypeData Data
        {
            get
            {
                return (ItemTypeData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        protected QuestionAnswerData _questionAnswerDataObject;
        /// <summary>
        /// Question Answer data object
        /// </summary>
        public Object QuestionAnswerDataObject
        {
            get
            {
                return _questionAnswerDataObject;
            }
            set
            {
                _questionAnswerDataObject = (QuestionAnswerData)value;
            }
        }

        protected AutoItData _autoItDataObject;
        /// <summary>
        /// Auto It Data Object
        /// </summary>
        public Object AutoItDataObject
        {
            get
            {
                return _autoItDataObject;
            }
            set
            {
                _autoItDataObject = (AutoItData)value;
            }
        }
        
        public ItemType ItemType { get; private set; }

        protected EnableToolsManipulatives EnableToolsManipulatives { get; set; }
        protected EnableTextFormatting EnableTextFormatting { get; set; }
        public By ByFormulaReferenceSheetSelect { get { return By.CssSelector(".btn.fileupload"); } }
        public WebElementWrapper FormulaReferenceSheetSelect { get; private set; }

        private readonly List<string> _lettersList = new List<string>
        {
            "A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"
        };
        private readonly List<string> _trueFalseList = new List<string>
        {
            "T","F"
        };


        private bool _fakeDummyBooleanValue;
        /// <summary>
        /// fake dummy boolean value for debugging
        /// </summary>
        public bool FakeDummyBooleanValue
        {
            get { return _fakeDummyBooleanValue; }
            set
            {
                _fakeDummyBooleanValue = value;
                EnableTextFormatting.FakeDummyBooleanValue = value;
            }
        }
        /// <summary>
        /// fake text
        /// </summary>
        public string FakeText { get; set; }

        public List<string> ExpectedRequiredErrorsList { get; set; }

        protected By ByStepsToCompleteLabels { get { return By.CssSelector(".well .divTable .divTableCell > span"); } }
        protected WebElementWrapper StepsToCompleteLabels { get; private set; }

        public override IBaseScreenView ReturnSubmitPage()
        {
            return null;
        }

        public override IBaseScreenView ReturnCancelPage()
        {
            return null;
        }

        public abstract void InputFormFields_AnswerKeyOnly();

        private ReadOnlyCollection<IWebElement> GetDummyUniqueControlIdentifiers()
        {
            ReadOnlyCollection<IWebElement> webElements = null;
            List<IWebElement> list = new List<IWebElement>();
            DummyWebElement dummy1 = new DummyWebElement();
            DummyWebElement dummy2 = new DummyWebElement();
            DummyWebElement dummy3 = new DummyWebElement();
            DummyWebElement dummy4 = new DummyWebElement();
            DummyWebElement dummy5 = new DummyWebElement();
            DummyWebElement dummy6 = new DummyWebElement();
            DummyWebElement dummy7 = new DummyWebElement();
            switch (ItemType)
            {
                case ItemType.InlineResponse:
                    dummy1.FakeAttributeValue = "A";
                    dummy1.FakeAttributeId = "ctl00_MainContent_EditTestItemControl_RepeaterClozeStemAnswers_ctl12_txtAnswerLabel";

                    dummy2.FakeAttributeValue = "B";
                    dummy2.FakeAttributeId = "ctl00_MainContent_EditTestItemControl_RepeaterClozeStemAnswers_ctl14_txtAnswerLabel";

                    dummy3.FakeAttributeValue = "C";
                    dummy3.FakeAttributeId = "ctl00_MainContent_EditTestItemControl_RepeaterClozeStemAnswers_ctl16_txtAnswerLabel";

                    list = new List<IWebElement> { dummy1, dummy2, dummy3 };
                    webElements = new ReadOnlyCollection<IWebElement>(list);
                    break;
                case ItemType.Matching:
                    dummy1.FakeAttributeValue = "1";
                    dummy1.FakeAttributeId = "ctl00_MainContent_EditTestItemControl_stemRepeator_ctl01_txtStemLabel";

                    dummy2.FakeAttributeValue = "2";
                    dummy2.FakeAttributeId = "ctl00_MainContent_EditTestItemControl_stemRepeator_ctl02_txtStemLabel";

                    dummy3.FakeAttributeValue = "3";
                    dummy3.FakeAttributeId = "ctl00_MainContent_EditTestItemControl_stemRepeator_ctl03_txtStemLabel";

                    dummy4.FakeAttributeValue = "A";
                    dummy4.FakeAttributeId = "ctl00_MainContent_EditTestItemControl_choicesRepeator_ctl01_txtChoiceLabel";

                    dummy5.FakeAttributeValue = "B";
                    dummy5.FakeAttributeId = "ctl00_MainContent_EditTestItemControl_choicesRepeator_ctl02_txtChoiceLabel";

                    dummy6.FakeAttributeValue = "C";
                    dummy6.FakeAttributeId = "ctl00_MainContent_EditTestItemControl_choicesRepeator_ctl03_txtChoiceLabel";

                    dummy7.FakeAttributeValue = "D";
                    dummy7.FakeAttributeId = "ctl00_MainContent_EditTestItemControl_choicesRepeator_ctl04_txtChoiceLabel";

                    list = new List<IWebElement> { dummy1, dummy2, dummy3, dummy4, dummy5, dummy6, dummy7 };
                    webElements = new ReadOnlyCollection<IWebElement>(list);
                    break;
                case ItemType.MultipleChoice:
                    dummy1.FakeAttributeValue = "A";
                    dummy1.FakeAttributeId = "ctl00_MainContent_EditTestItemControl_RepeaterAnswers_ctl01_txtAnswerLabel";

                    dummy2.FakeAttributeValue = "B";
                    dummy2.FakeAttributeId = "ctl00_MainContent_EditTestItemControl_RepeaterAnswers_ctl03_txtAnswerLabel";

                    dummy3.FakeAttributeValue = "C";
                    dummy3.FakeAttributeId = "ctl00_MainContent_EditTestItemControl_RepeaterAnswers_ctl05_txtAnswerLabel";

                    dummy4.FakeAttributeValue = "D";
                    dummy4.FakeAttributeId = "ctl00_MainContent_EditTestItemControl_RepeaterAnswers_ctl07_txtAnswerLabel";

                    list = new List<IWebElement> { dummy1, dummy2, dummy3, dummy4 };
                    webElements = new ReadOnlyCollection<IWebElement>(list);
                    break;
                case ItemType.TrueFalse:
                    dummy1.FakeAttributeValue = "T";
                    dummy1.FakeAttributeId = "ctl00_MainContent_EditTestItemControl_RepeaterAnswers_ctl01_txtAnswerLabel";

                    dummy2.FakeAttributeValue = "F";
                    dummy2.FakeAttributeId = "ctl00_MainContent_EditTestItemControl_RepeaterAnswers_ctl03_txtAnswerLabel";

                    list = new List<IWebElement> { dummy1, dummy2 };
                    webElements = new ReadOnlyCollection<IWebElement>(list);
                    break;
            }
            return webElements;
        }

        public Dictionary<string, string> GetUniqueControlIdentifiers(By by)
        {
            var dictionary = new Dictionary<string, string>();

            ReadOnlyCollection<IWebElement> webElements = Driver.FindElements(by);
            Report.Write("Found the elements by: '" + by.ToString() + "'.");
            if (Driver.GetType() == typeof(DummyDriver))
            {
                webElements = GetDummyUniqueControlIdentifiers();
            }

            foreach (var webElement in webElements)
            {
                string label = webElement.GetAttribute("value");
                Report.Write("Got the attribute: 'value' = '" + label + "' of this element by: '" + by.ToString() + "'.");
                string idAttribute = webElement.GetAttribute("id");
                Report.Write("Got the attribute: 'id' = '" + idAttribute + "' of this element by: '" + by.ToString() + "'.");
                int from = idAttribute.IndexOf("_ctl") + "_ctl".Length;
                int to = idAttribute.LastIndexOf("_");
                string index = idAttribute.Substring(from, to - from);
                string uniqueId = "ctl" + index;
                dictionary.Add(label, uniqueId);
            }
            return dictionary;
        }

        public int GetIndexByAlphabet(string label)
        {
            int index = 0;
            if (_lettersList.Contains(label.ToUpper()))
            {
                index = _lettersList.IndexOf(label.ToUpper());
            }
            return index;
        }

        public int GetIndexByAlphabet(string label, List<string> lettersList)
        {
            lettersList.Sort();
            int index = 0;
            if (lettersList.Contains(label.ToUpper()))
            {
                index = lettersList.IndexOf(label.ToUpper());
            }
            return index;
        }

        public int GetIndexByTrueFalse(string label)
        {
            int index = 0;
            if (_trueFalseList.Contains(label.ToUpper()))
            {
                index = _trueFalseList.IndexOf(label.ToUpper());
            }
            return index;
        }

        /// <summary>
        /// select enable manipulatives: use item settings
        /// </summary>
        public void SelectEnableManipulativesUseItemSettings()
        {
            EnableToolsManipulatives.SelectEnableManipulativesUseItemSettings();
        }
        /// <summary>
        /// is enable manipulatives: use item settings checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsSelectedEnableManipulativesUseItemSettings()
        {
            return EnableToolsManipulatives.IsSelectedEnableManipulativesUseItemSettings();
        }
        /// <summary>
        /// is enable manipulatives: use item settings enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledEnableManipulativesUseItemSettings()
        {
            return EnableToolsManipulatives.IsEnabledEnableManipulativesUseItemSettings();
        }
        /// <summary>
        /// is enable manipulatives: use item settings displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedEnableManipulativesUseItemSettings()
        {
            return EnableToolsManipulatives.IsDisplayedEnableManipulativesUseItemSettings();
        }

        /// <summary>
        /// select enable manipulatives: yes
        /// </summary>
        public void SelectEnableManipulativesYes()
        {
            EnableToolsManipulatives.SelectEnableManipulativesYes();
        }
        /// <summary>
        /// is enable manipulatives: yes checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsSelectedEnableManipulativesYes()
        {
            return EnableToolsManipulatives.IsSelectedEnableManipulativesYes();
        }
        /// <summary>
        /// is enable manipulatives: yes enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledEnableManipulativesYes()
        {
            return EnableToolsManipulatives.IsEnabledEnableManipulativesYes();
        }
        /// <summary>
        /// is enable manipulatives: yes displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedEnableManipulativesYes()
        {
            return EnableToolsManipulatives.IsDisplayedEnableManipulativesYes();
        }

        /// <summary>
        /// select enable manipulatives: no
        /// </summary>
        public void SelectEnableManipulativesNo()
        {
            EnableToolsManipulatives.SelectEnableManipulativesNo();
        }
        /// <summary>
        /// is enable manipulatives: no checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsSelectedEnableManipulativesNo()
        {
            return EnableToolsManipulatives.IsSelectedEnableManipulativesNo();
        }
        /// <summary>
        /// is enable manipulatives: no enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledEnableManipulativesNo()
        {
            return EnableToolsManipulatives.IsEnabledEnableManipulativesNo();
        }
        /// <summary>
        /// is enable manipulatives: no displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedEnableManipulativesNo()
        {
            return EnableToolsManipulatives.IsDisplayedEnableManipulativesNo();
        }

        /// <summary>
        /// check enable manipulatives
        /// </summary>
        public void CheckEnableManipulatives()
        {
            EnableToolsManipulatives.CheckEnableManipulatives();
        }
        /// <summary>
        /// uncheck enable manipulatives
        /// </summary>
        public void UnCheckEnableManipulatives()
        {
            EnableToolsManipulatives.UnCheckEnableManipulatives();
        }
        /// <summary>
        /// is enable manipulatives checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedEnableManipulatives()
        {
            return EnableToolsManipulatives.IsCheckedEnableManipulatives();
        }
        /// <summary>
        /// is enable manipulatives enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledEnableManipulatives()
        {
            return EnableToolsManipulatives.IsEnabledEnableManipulatives();
        }
        /// <summary>
        /// is enable manipulatives displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedEnableManipulatives()
        {
            return EnableToolsManipulatives.IsDisplayedEnableManipulatives();
        }

        /// <summary>
        /// check Four Function Calculator
        /// </summary>
        public void CheckFourFunctionCalculator()
        {
            EnableToolsManipulatives.CheckFourFunctionCalculator();
        }
        /// <summary>
        /// uncheck Four Function Calculator
        /// </summary>
        public void UnCheckFourFunctionCalculator()
        {
            EnableToolsManipulatives.UnCheckFourFunctionCalculator();
        }
        /// <summary>
        /// is Four Function Calculator checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedFourFunctionCalculator()
        {
            return EnableToolsManipulatives.IsCheckedFourFunctionCalculator();
        }
        /// <summary>
        /// is Four Function Calculator enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledFourFunctionCalculator()
        {
            return EnableToolsManipulatives.IsEnabledFourFunctionCalculator();
        }
        /// <summary>
        /// is Four Function Calculator displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedFourFunctionCalculator()
        {
            return EnableToolsManipulatives.IsDisplayedFourFunctionCalculator();
        }

        /// <summary>
        /// check Scientific Calculator
        /// </summary>
        public void CheckScientificCalculator()
        {
            EnableToolsManipulatives.CheckScientificCalculator();
        }
        /// <summary>
        /// uncheck Scientific Calculator
        /// </summary>
        public void UnCheckScientificCalculator()
        {
            EnableToolsManipulatives.UnCheckScientificCalculator();
        }
        /// <summary>
        /// is Scientific Calculator checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedScientificCalculator()
        {
            return EnableToolsManipulatives.IsCheckedScientificCalculator();
        }
        /// <summary>
        /// is Scientific Calculator enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledScientificCalculator()
        {
            return EnableToolsManipulatives.IsEnabledScientificCalculator();
        }
        /// <summary>
        /// is Scientific Calculator displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedScientificCalculator()
        {
            return EnableToolsManipulatives.IsDisplayedScientificCalculator();
        }

        /// <summary>
        /// check Graphing Calculator
        /// </summary>
        public void CheckGraphingCalculator()
        {
            EnableToolsManipulatives.CheckGraphingCalculator();
        }
        /// <summary>
        /// uncheck Graphing Calculator
        /// </summary>
        public void UnCheckGraphingCalculator()
        {
            EnableToolsManipulatives.UnCheckGraphingCalculator();
        }
        /// <summary>
        /// is Graphing Calculator checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedGraphingCalculator()
        {
            return EnableToolsManipulatives.IsCheckedGraphingCalculator();
        }
        /// <summary>
        /// is Graphing Calculator enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledGraphingCalculator()
        {
            return EnableToolsManipulatives.IsEnabledGraphingCalculator();
        }
        /// <summary>
        /// is Graphing Calculator displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedGraphingCalculator()
        {
            return EnableToolsManipulatives.IsDisplayedGraphingCalculator();
        }

        /// <summary>
        /// check Compass
        /// </summary>
        public void CheckCompass()
        {
            EnableToolsManipulatives.CheckCompass();
        }
        /// <summary>
        /// uncheck Compass
        /// </summary>
        public void UnCheckCompass()
        {
            EnableToolsManipulatives.UnCheckCompass();
        }
        /// <summary>
        /// is Compass checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedCompass()
        {
            return EnableToolsManipulatives.IsCheckedCompass();
        }
        /// <summary>
        /// is Compass enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledCompass()
        {
            return EnableToolsManipulatives.IsEnabledCompass();
        }
        /// <summary>
        /// is Compass displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedCompass()
        {
            return EnableToolsManipulatives.IsDisplayedCompass();
        }

        /// <summary>
        /// check Centimeter Ruler
        /// </summary>
        public void CheckCentimeterRuler()
        {
            EnableToolsManipulatives.CheckCentimeterRuler();
        }
        /// <summary>
        /// uncheck Centimeter Ruler
        /// </summary>
        public void UnCheckCentimeterRuler()
        {
            EnableToolsManipulatives.UnCheckCentimeterRuler();
        }
        /// <summary>
        /// is Centimeter Ruler checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedCentimeterRuler()
        {
            return EnableToolsManipulatives.IsCheckedCentimeterRuler();
        }
        /// <summary>
        /// is Centimeter Ruler enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledCentimeterRuler()
        {
            return EnableToolsManipulatives.IsEnabledCentimeterRuler();
        }
        /// <summary>
        /// is Centimeter Ruler displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedCentimeterRuler()
        {
            return EnableToolsManipulatives.IsDisplayedCentimeterRuler();
        }

        /// <summary>
        /// check Inch Ruler
        /// </summary>
        public void CheckInchRuler()
        {
            EnableToolsManipulatives.CheckInchRuler();
        }
        /// <summary>
        /// uncheck Inch Ruler
        /// </summary>
        public void UnCheckInchRuler()
        {
            EnableToolsManipulatives.UnCheckInchRuler();
        }
        /// <summary>
        /// is Inch Ruler checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedInchRuler()
        {
            return EnableToolsManipulatives.IsCheckedInchRuler();
        }
        /// <summary>
        /// is Inch Ruler enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledInchRuler()
        {
            return EnableToolsManipulatives.IsEnabledInchRuler();
        }
        /// <summary>
        /// is Inch Ruler displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedInchRuler()
        {
            return EnableToolsManipulatives.IsDisplayedInchRuler();
        }

        /// <summary>
        /// check Unit Ruler
        /// </summary>
        public void CheckUnitRuler()
        {
            EnableToolsManipulatives.CheckUnitRuler();
        }
        /// <summary>
        /// uncheck Unit Ruler
        /// </summary>
        public void UnCheckUnitRuler()
        {
            EnableToolsManipulatives.UnCheckUnitRuler();
        }
        /// <summary>
        /// is Unit Ruler checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedUnitRuler()
        {
            return EnableToolsManipulatives.IsCheckedUnitRuler();
        }
        /// <summary>
        /// is Unit Ruler enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledUnitRuler()
        {
            return EnableToolsManipulatives.IsEnabledUnitRuler();
        }
        /// <summary>
        /// is Unit Ruler displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedUnitRuler()
        {
            return EnableToolsManipulatives.IsDisplayedUnitRuler();
        }

        /// <summary>
        /// check Protractor
        /// </summary>
        public void CheckProtractor()
        {
            EnableToolsManipulatives.CheckProtractor();
        }
        /// <summary>
        /// uncheck Protractor
        /// </summary>
        public void UnCheckProtractor()
        {
            EnableToolsManipulatives.UnCheckProtractor();
        }
        /// <summary>
        /// is Protractor checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedProtractor()
        {
            return EnableToolsManipulatives.IsCheckedProtractor();
        }
        /// <summary>
        /// is Protractor enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledProtractor()
        {
            return EnableToolsManipulatives.IsEnabledProtractor();
        }
        /// <summary>
        /// is Protractor displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedProtractor()
        {
            return EnableToolsManipulatives.IsDisplayedProtractor();
        }

        /// <summary>
        /// check enable text formatting
        /// </summary>
        public void CheckEnableTextFormatting()
        {
            EnableTextFormatting.CheckEnableTextFormatting();
        }
        /// <summary>
        /// uncheck enable text formatting
        /// </summary>
        public void UnCheckEnableTextFormatting()
        {
            EnableTextFormatting.UnCheckEnableTextFormatting();
        }
        /// <summary>
        /// is enable text formatting checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedEnableTextFormatting()
        {
            return EnableTextFormatting.IsCheckedEnableTextFormatting();
        }
        /// <summary>
        /// is enable text formatting enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledEnableTextFormatting()
        {
            return EnableTextFormatting.IsEnabledEnableTextFormatting();
        }
        /// <summary>
        /// is enable text formatting displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedEnableTextFormatting()
        {
            return EnableTextFormatting.IsDisplayedEnableTextFormatting();
        }

        /// <summary>
        /// check enable special character palette
        /// </summary>
        public void CheckEnableSpecialCharacterPalette()
        {
            EnableTextFormatting.CheckEnableSpecialCharacterPalette();
        }
        /// <summary>
        /// uncheck enable special character palette
        /// </summary>
        public void UnCheckEnableSpecialCharacterPalette()
        {
            EnableTextFormatting.UnCheckEnableSpecialCharacterPalette();
        }
        /// <summary>
        /// is enable special character palette checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedEnableSpecialCharacterPalette()
        {
            return EnableTextFormatting.IsCheckedEnableSpecialCharacterPalette();
        }
        /// <summary>
        /// is enable special character palette enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledEnableSpecialCharacterPalette()
        {
            return EnableTextFormatting.IsEnabledEnableSpecialCharacterPalette();
        }
        /// <summary>
        /// is enable special character palette displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedEnableSpecialCharacterPalette()
        {
            return EnableTextFormatting.IsDisplayedEnableSpecialCharacterPalette();
        }

        /// <summary>
        /// check enable spell checker
        /// </summary>
        public void CheckEnableSpellChecker()
        {
            EnableTextFormatting.CheckEnableSpellChecker();
        }
        /// <summary>
        /// uncheck enable spell checker
        /// </summary>
        public void UnCheckEnableSpellChecker()
        {
            EnableTextFormatting.UnCheckEnableSpellChecker();
        }
        /// <summary>
        /// is enable spell checker checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedEnableSpellChecker()
        {
            return EnableTextFormatting.IsCheckedEnableSpellChecker();
        }
        /// <summary>
        /// is enable spell checker enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledEnableSpellChecker()
        {
            return EnableTextFormatting.IsEnabledEnableSpellChecker();
        }
        /// <summary>
        /// is enable spell checker displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedEnableSpellChecker()
        {
            return EnableTextFormatting.IsDisplayedEnableSpellChecker();
        }

        /// <summary>
        /// check enable grammar checker
        /// </summary>
        public void CheckEnableGrammarChecker()
        {
            EnableTextFormatting.CheckEnableGrammarChecker();
        }
        /// <summary>
        /// uncheck enable grammar checker
        /// </summary>
        public void UnCheckEnableGrammarChecker()
        {
            EnableTextFormatting.UnCheckEnableGrammarChecker();
        }
        /// <summary>
        /// is enable grammar checker checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedEnableGrammarChecker()
        {
            return EnableTextFormatting.IsCheckedEnableGrammarChecker();
        }
        /// <summary>
        /// is enable grammar checker enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledEnableGrammarChecker()
        {
            return EnableTextFormatting.IsEnabledEnableGrammarChecker();
        }
        /// <summary>
        /// is enable grammar checker displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedEnableGrammarChecker()
        {
            return EnableTextFormatting.IsDisplayedEnableGrammarChecker();
        }

        /// <summary>
        /// check enable equation editor
        /// </summary>
        public void CheckEnableEquationEditor()
        {
            EnableTextFormatting.CheckEnableEquationEditor();
        }
        /// <summary>
        /// uncheck enable equation editor
        /// </summary>
        public void UnCheckEnableEquationEditor()
        {
            EnableTextFormatting.UnCheckEnableEquationEditor();
        }
        /// <summary>
        /// is enable equation editor checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedEnableEquationEditor()
        {
            return EnableTextFormatting.IsCheckedEnableEquationEditor();
        }
        /// <summary>
        /// is enable equation editor enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledEnableEquationEditor()
        {
            return EnableTextFormatting.IsEnabledEnableEquationEditor();
        }
        /// <summary>
        /// is enable equation editor displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedEnableEquationEditor()
        {
            return EnableTextFormatting.IsDisplayedEnableEquationEditor();
        }

        /// <summary>
        /// select formula reference sheet
        /// </summary>
        public void SelectFormulaReferenceSheet()
        {
            FormulaReferenceSheetSelect.Wait(3).Click();
        }

        protected ReadOnlyCollection<IWebElement> GetDummyStepsToCompleteLabels()
        {
            ReadOnlyCollection<IWebElement> webElements = null;
            List<IWebElement> list = new List<IWebElement>();
            DummyWebElement dummy1 = new DummyWebElement();
            DummyWebElement dummy2 = new DummyWebElement();
            DummyWebElement dummy3 = new DummyWebElement();
            DummyWebElement dummy4 = new DummyWebElement();
            DummyWebElement dummy5 = new DummyWebElement();
            DummyWebElement dummy6 = new DummyWebElement();
            DummyWebElement dummy7 = new DummyWebElement();
            switch (ItemType)
            {
                case ItemType.InlineResponse:
                    dummy1.Text = "Add at least one gap";
                    dummy1.Displayed = true;

                    list = new List<IWebElement> { dummy1 };
                    webElements = new ReadOnlyCollection<IWebElement>(list);
                    break;
                case ItemType.OpenResponse:
                    dummy1.Text = "Enter content";
                    dummy1.Displayed = true;

                    list = new List<IWebElement> { dummy1 };
                    webElements = new ReadOnlyCollection<IWebElement>(list);
                    break;
                case ItemType.Matching:
                    dummy1.Text = "Add content for question 1, 2, 3";
                    dummy1.Displayed = true;
                    dummy2.Text = "Add content for answer choice A, B, C, D";
                    dummy2.Displayed = true;
                    dummy3.Text = "Choose question & answer choices for matches";
                    dummy3.Displayed = true;
                    //16.0 dummy4.Text = "Enter student instructions";
                    //16.1
                    dummy4.Text = "Enter content";
                    dummy4.Displayed = true;

                    list = new List<IWebElement> { dummy1, dummy2, dummy3, dummy4 };
                    webElements = new ReadOnlyCollection<IWebElement>(list);
                    break;
                case ItemType.MultipleChoice:
                    dummy1.Text = "Enter content";
                    dummy1.Displayed = true;
                    dummy2.Text = "Select correct answer";
                    dummy2.Displayed = true;
                    dummy3.Text = "Not worth any points";
                    dummy3.Displayed = true;

                    list = new List<IWebElement> { dummy1, dummy2, dummy3 };
                    webElements = new ReadOnlyCollection<IWebElement>(list);
                    break;
                case ItemType.TrueFalse:
                    dummy1.Text = "Enter content";
                    dummy1.Displayed = true;
                    dummy2.Text = "Select correct answer";
                    dummy2.Displayed = true;
                    dummy3.Text = "Not worth any points";
                    dummy3.Displayed = true;

                    list = new List<IWebElement> { dummy1, dummy2, dummy3 };
                    webElements = new ReadOnlyCollection<IWebElement>(list);
                    break;
                case ItemType.Gridded:
                    dummy1.Text = "Enter content";
                    dummy1.Displayed = true;
                    dummy2.Text = "Select correct answer";
                    dummy2.Displayed = true;
                    dummy3.Text = "Not worth any points";
                    dummy3.Displayed = true;

                    list = new List<IWebElement> { dummy1, dummy2, dummy3 };
                    webElements = new ReadOnlyCollection<IWebElement>(list);
                    break;
                case ItemType.DragAndDrop:
                    dummy1.Text = "Enter content";
                    dummy1.Displayed = true;
                    dummy2.Text = "Add question content for question container 1,2,3";
                    dummy2.Displayed = true;
                    dummy3.Text = "Add content for answer choice A,B,C,D";
                    dummy3.Displayed = true;
                    dummy4.Text = "Select correct answer for question container 1,2,3";
                    dummy4.Displayed = true;
                    dummy5.Text = "Not worth any points";
                    dummy5.Displayed = true;

                    list = new List<IWebElement> { dummy1, dummy2, dummy3, dummy4, dummy5 };
                    webElements = new ReadOnlyCollection<IWebElement>(list);
                    break;
                case ItemType.Task:
                    dummy1.Text = "Add an activity";
                    dummy1.Displayed = true;
                    dummy2.Text = "Enter a name";
                    dummy2.Displayed = true;
                    dummy3.Text = "Enter content";
                    dummy3.Displayed = true;
                    dummy4.Text = "Not worth any points";
                    dummy4.Displayed = true;

                    list = new List<IWebElement> { dummy1, dummy2, dummy3, dummy4 };
                    webElements = new ReadOnlyCollection<IWebElement>(list);
                    break;
            }
            return webElements;
        }

        public override void VerifyErrorsForRequiredFields()
        {
            List<string> actualRequiredErrorsList = new List<string>();
            //get the error message element list
            ReadOnlyCollection<IWebElement> messageElements = StepsToCompleteLabels.WaitForElements(5);

            if (Driver.GetType() == typeof(DummyDriver))
            {
                messageElements = GetDummyStepsToCompleteLabels();
            }

            //for each element in the list
            foreach (var messageElement in messageElements)
            {
                //if the error message element is displayed
                if (messageElement.Displayed)
                {
                    string actualMessage = messageElement.Text;
                    //get the error message text and add it to the actual error message list
                    actualRequiredErrorsList.Add(actualMessage);
                    Report.Write("Actual required message: " + actualMessage);
                }
            }
            //for each expected error message in the list
            foreach (var expectedMessage in ExpectedRequiredErrorsList)
            {
                //assert that the expected error message is found in the actual error message list
                Assert.IsTrue(actualRequiredErrorsList.Contains(expectedMessage),
                    "The expected required message '" + expectedMessage + "' was not found in the actual required message list.");
            }
        }



    }
}
