using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Framework;
using Core.Views;
using Core.Tools.WebDriver;
using OpenQA.Selenium;
using UITests.Pages.Components;

namespace UITests.Pages.Assess.Components
{
    /// <summary>
    /// enable text formatting component
    /// </summary>
    public class EnableTextFormatting : SNComponent
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="pageName"></param>
        /// <param name="overrideControlPrefix"></param>
        public EnableTextFormatting(PageNames pageName, string overrideControlPrefix = null)
            : base()
        {
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }
            PageName = pageName;
            switch (pageName)
            {
                case PageNames.CreateTest:
                    ControlMiddle = ControlPrefix + "";
                    break;
                case PageNames.CreateNewItem:
                    ControlMiddle = ControlPrefix + "EditTestItemControl_";
                    break;
                case PageNames.EditTestItem:
                    ControlMiddle = ControlPrefix + "EditTestItemControl_";
                    break;
                case PageNames.EditQuestion:
                    ControlMiddle = ControlPrefix + "EditTestItemControl_";
                    break;
                case PageNames.ViewTestDetailsTestProperties:
                    ControlMiddle = ControlPrefix + "TestInfoSidebar1_";
                    break;
            }
            UseItemSettings = new WebElementWrapper(ByUseItemSettings);
            EnableTextFormattingOpenResponseItems = new WebElementWrapper(ByEnableTextFormattingOpenResponseItems);
            DisableTextFormattingOpenResponseItems = new WebElementWrapper(ByDisableTextFormattingOpenResponseItems);
            EnableTextFormattingCheck = new WebElementWrapper(ByEnableTextFormattingCheck);
            EnableSpecialCharacterPalette = new WebElementWrapper(ByEnableSpecialCharacterPalette);
            EnableSpellChecker = new WebElementWrapper(ByEnableSpellChecker);
            EnableGrammarChecker = new WebElementWrapper(ByEnableGrammarChecker);
            EnableEquationEditor = new WebElementWrapper(ByEnableEquationEditor());
        }

        private PageNames PageName;
        private string ControlMiddle { get; set; }

        /// <summary>
        /// fake dummy boolean value for debugging
        /// </summary>
        public bool FakeDummyBooleanValue { get; set; }

        public By ByUseItemSettings { get { return By.Id(ControlMiddle + "RadioButtonListEnableTextFormatting_0"); } }
        public WebElementWrapper UseItemSettings { get; private set; }

        public By ByEnableTextFormattingOpenResponseItems { get { return By.Id(ControlMiddle + "RadioButtonListEnableTextFormatting_2"); } }
        public WebElementWrapper EnableTextFormattingOpenResponseItems { get; private set; }

        public By ByDisableTextFormattingOpenResponseItems { get { return By.Id(ControlMiddle + "RadioButtonListEnableTextFormatting_1"); } }
        public WebElementWrapper DisableTextFormattingOpenResponseItems { get; private set; }

        public By ByEnableTextFormattingCheck { get { return By.Id(ControlMiddle + "CheckBoxETFP"); } }
        public WebElementWrapper EnableTextFormattingCheck { get; private set; }

        public By ByEnableSpecialCharacterPalette { get { return By.Id(ControlMiddle + "CheckBoxESCP"); } }
        public WebElementWrapper EnableSpecialCharacterPalette { get; private set; }

        public By ByEnableSpellChecker { get { return By.Id(ControlMiddle + "chkSpellChecker"); } }
        public WebElementWrapper EnableSpellChecker { get; private set; }

        public By ByEnableGrammarChecker { get { return By.Id(ControlMiddle + "chkGrammarChecker"); } }
        public WebElementWrapper EnableGrammarChecker { get; private set; }

        //public By ByEnableEquationEditor { get { return By.Id(ControlMiddle + "checkBoxEquationEditor"); } }
        public WebElementWrapper EnableEquationEditor { get; private set; }

        private By ByEnableEquationEditor()
        {
            By by = null;
            switch (PageName)
            {
                case PageNames.CreateTest:
                    //by = By.Id(ControlMiddle + "checkBoxEquationEditor");
                    by = By.Id(ControlMiddle + "chkEquationEditor");
                    break;
                case PageNames.CreateNewItem:
                    by = By.Id(ControlMiddle + "checkBoxEquationEditor");
                    break;
                case PageNames.EditTestItem:
                    by = By.Id(ControlMiddle + "checkBoxEquationEditor");
                    break;
                case PageNames.EditQuestion:
                    by = By.Id(ControlMiddle + "checkBoxEquationEditor");
                    break;
                case PageNames.ViewTestDetailsTestProperties:
                    by = By.Id(ControlMiddle + "chkEquationEditor");
                    break;
            }
            return by;
        }

        /// <summary>
        /// select user item settings
        /// </summary>
        public void SelectEnableTextFormattingUseItemSettings()
        {
            UseItemSettings.Wait(7).Click();
            //debugging
            UseItemSettings.Selected = true;
            DisableTextFormattingOpenResponseItems.Selected = false;
            EnableTextFormattingOpenResponseItems.Selected = false;
        }
        /// <summary>
        /// is user item settings selected?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsSelectedEnableTextFormattingUseItemSettings()
        {
            UseItemSettings.Wait(3);
            //debugging
            UseItemSettings.Selected = FakeDummyBooleanValue;
            return UseItemSettings.Selected;
        }
        /// <summary>
        /// is enable text formatting: use item settings enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledEnableTextFormattingUseItemSettings()
        {
            UseItemSettings.WaitUntilExists(3);
            //debugging
            UseItemSettings.Enabled = FakeDummyBooleanValue;
            return UseItemSettings.Enabled;
        }
        /// <summary>
        /// is enable text formatting: use item settings displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedEnableTextFormattingUseItemSettings()
        {
            UseItemSettings.WaitUntilExists(3);
            //debugging
            UseItemSettings.Displayed = FakeDummyBooleanValue;
            return UseItemSettings.Displayed;
        }

        /// <summary>
        /// select disable text formatting open response items
        /// </summary>
        public void SelectDisableTextFormattingOpenResponseItems()
        {
            DisableTextFormattingOpenResponseItems.Wait(3).Click();
            //debugging
            UseItemSettings.Selected = false;
            DisableTextFormattingOpenResponseItems.Selected = true;
            EnableTextFormattingOpenResponseItems.Selected = false;
        }
        /// <summary>
        /// is disable text formatting open response items selected?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsSelectedDisableTextFormattingOpenResponseItems()
        {
            DisableTextFormattingOpenResponseItems.Wait(3);
            //debugging
            DisableTextFormattingOpenResponseItems.Selected = FakeDummyBooleanValue;
            return DisableTextFormattingOpenResponseItems.Selected;
        }
        /// <summary>
        /// is disable text formatting enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledDisableTextFormattingOpenResponseItems()
        {
            DisableTextFormattingOpenResponseItems.WaitUntilExists(3);
            //debugging
            DisableTextFormattingOpenResponseItems.Enabled = FakeDummyBooleanValue;
            return DisableTextFormattingOpenResponseItems.Enabled;
        }
        /// <summary>
        /// is disable text formatting displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedDisableTextFormattingOpenResponseItems()
        {
            DisableTextFormattingOpenResponseItems.WaitUntilExists(3);
            //debugging
            DisableTextFormattingOpenResponseItems.Displayed = FakeDummyBooleanValue;
            return DisableTextFormattingOpenResponseItems.Displayed;
        }

        /// <summary>
        /// select enable text formatting open response items
        /// </summary>
        public void SelectEnableTextFormattingOpenResponseItems()
        {
            EnableTextFormattingOpenResponseItems.Wait(3).Click();
            //debugging
            UseItemSettings.Selected = false;
            DisableTextFormattingOpenResponseItems.Selected = false;
            EnableTextFormattingOpenResponseItems.Selected = true;
        }
        /// <summary>
        /// is enable text formatting open response items selected?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsSelectedEnableTextFormattingOpenResponseItems()
        {
            EnableTextFormattingOpenResponseItems.Wait(3);
            //debugging
            EnableTextFormattingOpenResponseItems.Selected = FakeDummyBooleanValue;
            return EnableTextFormattingOpenResponseItems.Selected;
        }
        /// <summary>
        /// is enable text formatting enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledEnableTextFormattingOpenResponseItems()
        {
            EnableTextFormattingOpenResponseItems.WaitUntilExists(3);
            //debugging
            EnableTextFormattingOpenResponseItems.Enabled = FakeDummyBooleanValue;
            return EnableTextFormattingOpenResponseItems.Enabled;
        }
        /// <summary>
        /// is enable text formatting displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedEnableTextFormattingOpenResponseItems()
        {
            EnableTextFormattingOpenResponseItems.WaitUntilExists(3);
            //debugging
            EnableTextFormattingOpenResponseItems.Displayed = FakeDummyBooleanValue;
            return EnableTextFormattingOpenResponseItems.Displayed;
        }

        /// <summary>
        /// check enable text formatting
        /// </summary>
        public void CheckEnableTextFormatting()
        {
            EnableTextFormattingCheck.Wait(3).Check();
            //pause the script for a second to rebuild the DOM
            System.Threading.Thread.Sleep(1000);
            //debugging
            EnableTextFormattingCheck.Selected = true;
        }
        /// <summary>
        /// uncheck enable text formatting
        /// </summary>
        public void UnCheckEnableTextFormatting()
        {
            EnableTextFormattingCheck.Wait(3).UnCheck();
            //pause the script for a second to rebuild the DOM
            System.Threading.Thread.Sleep(1000);
            //debugging
            EnableTextFormattingCheck.Selected = false;
        }
        /// <summary>
        /// is enable text formatting checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedEnableTextFormatting()
        {
            EnableTextFormattingCheck.Wait(3);
            //debugging
            EnableTextFormattingCheck.Selected = FakeDummyBooleanValue;
            return EnableTextFormattingCheck.Selected;
        }
        /// <summary>
        /// is enable text formatting enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledEnableTextFormatting()
        {
            EnableTextFormattingCheck.WaitUntilExists(3);
            //debugging
            EnableTextFormattingCheck.Enabled = FakeDummyBooleanValue;
            return EnableTextFormattingCheck.Enabled;
        }
        /// <summary>
        /// is enable text formatting displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedEnableTextFormatting()
        {
            EnableTextFormattingCheck.WaitUntilExists(3);
            //debugging
            EnableTextFormattingCheck.Displayed = FakeDummyBooleanValue;
            return EnableTextFormattingCheck.Displayed;
        }

        /// <summary>
        /// check enable special character palette
        /// </summary>
        public void CheckEnableSpecialCharacterPalette()
        {
            EnableSpecialCharacterPalette.Wait(3).Check();
            //debugging
            EnableSpecialCharacterPalette.Selected = true;
        }
        /// <summary>
        /// uncheck enable special character palette
        /// </summary>
        public void UnCheckEnableSpecialCharacterPalette()
        {
            EnableSpecialCharacterPalette.Wait(3).UnCheck();
            //debugging
            EnableSpecialCharacterPalette.Selected = false;
        }
        /// <summary>
        /// is enable special character palette checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedEnableSpecialCharacterPalette()
        {
            EnableSpecialCharacterPalette.Wait(3);
            EnableSpecialCharacterPalette.Selected = FakeDummyBooleanValue;
            return EnableSpecialCharacterPalette.Selected;
        }
        /// <summary>
        /// is enable special character palette enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledEnableSpecialCharacterPalette()
        {
            EnableSpecialCharacterPalette.WaitUntilExists(3);
            EnableSpecialCharacterPalette.Enabled = FakeDummyBooleanValue;
            return EnableSpecialCharacterPalette.Enabled;
        }
        /// <summary>
        /// is enable special character palette displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedEnableSpecialCharacterPalette()
        {
            EnableSpecialCharacterPalette.WaitUntilExists(3);
            EnableSpecialCharacterPalette.Displayed = FakeDummyBooleanValue;
            return EnableSpecialCharacterPalette.Displayed;
        }

        /// <summary>
        /// check enable spell checker
        /// </summary>
        public void CheckEnableSpellChecker()
        {
            EnableSpellChecker.Wait(3).Check();
            //debugging
            EnableSpellChecker.Selected = true;
        }
        /// <summary>
        /// uncheck enable spell checker
        /// </summary>
        public void UnCheckEnableSpellChecker()
        {
            EnableSpellChecker.Wait(3).UnCheck();
            //debugging
            EnableSpellChecker.Selected = false;
        }
        /// <summary>
        /// is enable spell checker checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedEnableSpellChecker()
        {
            EnableSpellChecker.Wait(3);
            EnableSpellChecker.Selected = FakeDummyBooleanValue;
            return EnableSpellChecker.Selected;
        }
        /// <summary>
        /// is enable spell checker enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledEnableSpellChecker()
        {
            EnableSpellChecker.WaitUntilExists(3);
            EnableSpellChecker.Enabled = FakeDummyBooleanValue;
            return EnableSpellChecker.Enabled;
        }
        /// <summary>
        /// is enable spell checker displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedEnableSpellChecker()
        {
            EnableSpellChecker.WaitUntilExists(3);
            EnableSpellChecker.Displayed = FakeDummyBooleanValue;
            return EnableSpellChecker.Displayed;
        }

        /// <summary>
        /// check enable grammar checker
        /// </summary>
        public void CheckEnableGrammarChecker()
        {
            EnableGrammarChecker.Wait(3).Check();
            //debugging
            EnableGrammarChecker.Selected = true;
        }
        /// <summary>
        /// uncheck enable grammar checker
        /// </summary>
        public void UnCheckEnableGrammarChecker()
        {
            EnableGrammarChecker.Wait(3).UnCheck();
            //debugging
            EnableGrammarChecker.Selected = false;
        }
        /// <summary>
        /// is enable grammar checker checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedEnableGrammarChecker()
        {
            EnableGrammarChecker.Wait(3);
            EnableGrammarChecker.Selected = FakeDummyBooleanValue;
            return EnableGrammarChecker.Selected;
        }
        /// <summary>
        /// is enable grammar checker enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledEnableGrammarChecker()
        {
            EnableGrammarChecker.WaitUntilExists(3);
            EnableGrammarChecker.Enabled = FakeDummyBooleanValue;
            return EnableGrammarChecker.Enabled;
        }
        /// <summary>
        /// is enable grammar checker displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedEnableGrammarChecker()
        {
            EnableGrammarChecker.WaitUntilExists(3);
            EnableGrammarChecker.Displayed = FakeDummyBooleanValue;
            return EnableGrammarChecker.Displayed;
        }

        /// <summary>
        /// check enable equation editor
        /// </summary>
        public void CheckEnableEquationEditor()
        {
            EnableEquationEditor.Wait(3).Check();
            //debugging
            EnableEquationEditor.Selected = true;
        }
        /// <summary>
        /// uncheck enable equation editor
        /// </summary>
        public void UnCheckEnableEquationEditor()
        {
            EnableEquationEditor.Wait(3).UnCheck();
            //debugging
            EnableEquationEditor.Selected = false;
        }
        /// <summary>
        /// is enable equation editor checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedEnableEquationEditor()
        {
            EnableEquationEditor.Wait(3);
            EnableEquationEditor.Selected = FakeDummyBooleanValue;
            return EnableEquationEditor.Selected;
        }
        /// <summary>
        /// is enable equation editor enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledEnableEquationEditor()
        {
            EnableEquationEditor.WaitUntilExists(3);
            EnableEquationEditor.Enabled = FakeDummyBooleanValue;
            return EnableEquationEditor.Enabled;
        }
        /// <summary>
        /// is enable equation editor displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedEnableEquationEditor()
        {
            EnableEquationEditor.WaitUntilExists(3);
            EnableEquationEditor.Displayed = FakeDummyBooleanValue;
            return EnableEquationEditor.Displayed;
        }
    }
}
