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
    /// enable tools and manipulatives component
    /// </summary>
    public class EnableToolsManipulatives : SNComponent
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="pageName"></param>
        /// <param name="overrideControlPrefix"></param>
        public EnableToolsManipulatives(PageNames pageName, string overrideControlPrefix = null)
            : base()
        {
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }
            PageName = pageName;
            switch (pageName)
            {
                case PageNames.CreateNewItem:
                    _controlPrefix2 = ControlPrefix + "EditTestItemControl_ItemToolsAndManipulativesSelector_";
                    break;
                case PageNames.CreateTest:
                    _controlPrefix2 = ControlPrefix + "TestToolsAndManipulativesSelector_";
                    break;
                case PageNames.ViewTestDetailsTestProperties:
                    _controlPrefix2 = ControlPrefix + "TestInfoSidebar1_";
                    break;
            }
            UseItemSettings = new WebElementWrapper(ByUseItemSettings);
            Yes = new WebElementWrapper(ByYes);
            No = new WebElementWrapper(ByNo);
            Check = new WebElementWrapper(ByCheck);
            FourFunctionCalculator = new WebElementWrapper(ByFourFunctionCalculator());
            ScientificCalculator = new WebElementWrapper(ByScientificCalculator());
            GraphingCalculator = new WebElementWrapper(ByGraphingCalculator());
            Compass = new WebElementWrapper(ByCompass());
            CentimeterRuler = new WebElementWrapper(ByCentimeterRuler());
            InchRuler = new WebElementWrapper(ByInchRuler());
            UnitRuler = new WebElementWrapper(ByUnitRuler());
            Protractor = new WebElementWrapper(ByProtractor());
        }

        private PageNames PageName;

        /// <summary>
        /// fake dummy boolean value for debugging
        /// </summary>
        public bool FakeDummyBooleanValue { get; set; }

        public By ByUseItemSettings { get { return By.Id("ManipulativesUseItemSettings"); } }
        public WebElementWrapper UseItemSettings { get; private set; }

        //public By ByYes { get { return By.Id("ManipulativesYes"); } }
        public By ByYes { get { return By.Id(_controlPrefix2 + "RadioButtonListUseManipulatives_1"); } }
        public WebElementWrapper Yes { get; private set; }

        //public By ByNo { get { return By.Id("ManipulativesNo"); } }
        public By ByNo { get { return By.Id(_controlPrefix2 + "RadioButtonListUseManipulatives_2"); } }
        public WebElementWrapper No { get; private set; }

        public By ByCheck { get { return By.Id(_controlPrefix2 + "chkUseManipulatives"); } }
        public WebElementWrapper Check { get; private set; }

        //public By ByFourFunctionCalculator { get { return By.Id(_controlPrefix2 + "rptTools_ctl01_cbManipulativeFlag"); } }
        public WebElementWrapper FourFunctionCalculator { get; private set; }

        //public By ByScientificCalculator { get { return By.Id(_controlPrefix2 + "rptTools_ctl02_cbManipulativeFlag"); } }
        public WebElementWrapper ScientificCalculator { get; private set; }

        //public By ByGraphingCalculator { get { return By.Id(_controlPrefix2 + "rptTools_ctl03_cbManipulativeFlag"); } }
        public WebElementWrapper GraphingCalculator { get; private set; }

        //public By ByCompass { get { return By.Id(_controlPrefix2 + "rptManipulatives_ctl01_cbManipulativeFlag"); } }
        public WebElementWrapper Compass { get; private set; }

        //public By ByCentimeterRuler { get { return By.Id(_controlPrefix2 + "rptManipulatives_ctl02_cbManipulativeFlag"); } }
        public WebElementWrapper CentimeterRuler { get; private set; }

        //public By ByInchRuler { get { return By.Id(_controlPrefix2 + "rptManipulatives_ctl03_cbManipulativeFlag"); } }
        public WebElementWrapper InchRuler { get; private set; }

        //public By ByUnitRuler { get { return By.Id(_controlPrefix2 + "rptManipulatives_ctl04_cbManipulativeFlag"); } }
        public WebElementWrapper UnitRuler { get; private set; }

        //public By ByProtractor { get { return By.Id(_controlPrefix2 + "rptManipulatives_ctl05_cbManipulativeFlag"); } }
        public WebElementWrapper Protractor { get; private set; }

        private string _controlPrefix2 = "";

        private By ByFourFunctionCalculator()
        {
            By by = null;
            switch (PageName)
            {
                case PageNames.CreateTest:
                    by = By.Id(_controlPrefix2 + "rptTools_ctl01_cbManipulativeFlag");
                    break;
                case PageNames.CreateNewItem:
                    by = By.Id(_controlPrefix2 + "rptTools_ctl01_cbManipulativeFlag");
                    break;
                case PageNames.ViewTestDetailsTestProperties:
                    by = By.Id(_controlPrefix2 + "CheckBox0");
                    break;
            }
            return by;
        }
        private By ByScientificCalculator()
        {
            By by = null;
            switch (PageName)
            {
                case PageNames.CreateTest:
                    by = By.Id(_controlPrefix2 + "rptTools_ctl02_cbManipulativeFlag");
                    break;
                case PageNames.CreateNewItem:
                    by = By.Id(_controlPrefix2 + "rptTools_ctl02_cbManipulativeFlag");
                    break;
                case PageNames.ViewTestDetailsTestProperties:
                    by = By.Id(_controlPrefix2 + "CheckBox1");
                    break;
            }
            return by;
        }
        private By ByGraphingCalculator()
        {
            By by = null;
            switch (PageName)
            {
                case PageNames.CreateTest:
                    by = By.Id(_controlPrefix2 + "rptTools_ctl03_cbManipulativeFlag");
                    break;
                case PageNames.CreateNewItem:
                    by = By.Id(_controlPrefix2 + "rptTools_ctl03_cbManipulativeFlag");
                    break;
                case PageNames.ViewTestDetailsTestProperties:
                    by = By.Id(_controlPrefix2 + "CheckBox2");
                    break;
            }
            return by;
        }
        private By ByCompass()
        {
            By by = null;
            switch (PageName)
            {
                case PageNames.CreateTest:
                    //by = By.Id(_controlPrefix2 + "rptManipulatives_ctl01_cbManipulativeFlag");
                    by = By.Id(_controlPrefix2 + "rptTools_ctl01_cbManipulativeFlag");
                    break;
                case PageNames.CreateNewItem:
                    by = By.Id(_controlPrefix2 + "rptManipulatives_ctl01_cbManipulativeFlag");
                    break;
                case PageNames.ViewTestDetailsTestProperties:
                    //by = By.Id(_controlPrefix2 + "CheckBox3");
                    by = By.Id(_controlPrefix2 + "CheckBox4");
                    break;
            }
            return by;
        }
        private By ByCentimeterRuler()
        {
            By by = null;
            switch (PageName)
            {
                case PageNames.CreateTest:
                    //by = By.Id(_controlPrefix2 + "rptManipulatives_ctl02_cbManipulativeFlag");
                    by = By.Id(_controlPrefix2 + "rptRulers_ctl01_cbManipulativeFlag");
                    break;
                case PageNames.CreateNewItem:
                    by = By.Id(_controlPrefix2 + "rptManipulatives_ctl02_cbManipulativeFlag");
                    break;
                case PageNames.ViewTestDetailsTestProperties:
                    //by = By.Id(_controlPrefix2 + "CheckBox4");
                    by = By.Id(_controlPrefix2 + "CheckBox0");
                    break;
            }
            return by;
        }
        private By ByInchRuler()
        {
            By by = null;
            switch (PageName)
            {
                case PageNames.CreateTest:
                    //by = By.Id(_controlPrefix2 + "rptManipulatives_ctl03_cbManipulativeFlag");
                    by = By.Id(_controlPrefix2 + "rptRulers_ctl02_cbManipulativeFlag");
                    break;
                case PageNames.CreateNewItem:
                    by = By.Id(_controlPrefix2 + "rptManipulatives_ctl03_cbManipulativeFlag");
                    break;
                case PageNames.ViewTestDetailsTestProperties:
                    //by = By.Id(_controlPrefix2 + "CheckBox5");
                    by = By.Id(_controlPrefix2 + "CheckBox1");
                    break;
            }
            return by;
        }
        private By ByUnitRuler()
        {
            By by = null;
            switch (PageName)
            {
                case PageNames.CreateTest:
                    //by = By.Id(_controlPrefix2 + "rptManipulatives_ctl04_cbManipulativeFlag");
                    by = By.Id(_controlPrefix2 + "rptRulers_ctl04_cbManipulativeFlag");
                    break;
                case PageNames.CreateNewItem:
                    by = By.Id(_controlPrefix2 + "rptManipulatives_ctl04_cbManipulativeFlag");
                    break;
                case PageNames.ViewTestDetailsTestProperties:
                    //by = By.Id(_controlPrefix2 + "CheckBox6");
                    by = By.Id(_controlPrefix2 + "CheckBox3");
                    break;
            }
            return by;
        }
        private By ByProtractor()
        {
            By by = null;
            switch (PageName)
            {
                case PageNames.CreateTest:
                    //by = By.Id(_controlPrefix2 + "rptManipulatives_ctl05_cbManipulativeFlag");
                    by = By.Id(_controlPrefix2 + "rptTools_ctl02_cbManipulativeFlag");
                    break;
                case PageNames.CreateNewItem:
                    by = By.Id(_controlPrefix2 + "rptManipulatives_ctl05_cbManipulativeFlag");
                    break;
                case PageNames.ViewTestDetailsTestProperties:
                    //by = By.Id(_controlPrefix2 + "CheckBox7");
                    by = By.Id(_controlPrefix2 + "CheckBox5");
                    break;
            }
            return by;
        }

        /// <summary>
        /// select enable manipulatives: use item settings
        /// </summary>
        public void SelectEnableManipulativesUseItemSettings()
        {
            UseItemSettings.Wait(3).Click();
            //debugging
            UseItemSettings.Selected = true;
            Yes.Selected = false;
            No.Selected = false;
        }
        /// <summary>
        /// is enable manipulatives: use item settings checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsSelectedEnableManipulativesUseItemSettings()
        {
            UseItemSettings.Wait(3);
            //debugging
            UseItemSettings.Selected = FakeDummyBooleanValue;
            return UseItemSettings.Selected;
        }
        /// <summary>
        /// is enable manipulatives: use item settings enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledEnableManipulativesUseItemSettings()
        {
            UseItemSettings.WaitUntilExists(3);
            //debugging
            UseItemSettings.Enabled = FakeDummyBooleanValue;
            return UseItemSettings.Enabled;
        }
        /// <summary>
        /// is enable manipulatives: use item settings displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedEnableManipulativesUseItemSettings()
        {
            UseItemSettings.WaitUntilExists(3);
            //debugging
            UseItemSettings.Displayed = FakeDummyBooleanValue;
            return UseItemSettings.Displayed;
        }

        /// <summary>
        /// select enable manipulatives: yes
        /// </summary>
        public void SelectEnableManipulativesYes()
        {
            Yes.Wait(3).Click();
            //debugging
            Yes.Selected = true;
            No.Selected = false;
            UseItemSettings.Selected = false;
        }
        /// <summary>
        /// is enable manipulatives: yes checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsSelectedEnableManipulativesYes()
        {
            Yes.Wait(3);
            //debugging
            Yes.Selected = FakeDummyBooleanValue;
            return Yes.Selected;
        }
        /// <summary>
        /// is enable manipulatives: yes enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledEnableManipulativesYes()
        {
            Yes.WaitUntilExists(3);
            //debugging
            Yes.Enabled = FakeDummyBooleanValue;
            return Yes.Enabled;
        }
        /// <summary>
        /// is enable manipulatives: yes displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedEnableManipulativesYes()
        {
            Yes.WaitUntilExists(3);
            //debugging
            Yes.Displayed = FakeDummyBooleanValue;
            return Yes.Displayed;
        }

        /// <summary>
        /// select enable manipulatives: no
        /// </summary>
        public void SelectEnableManipulativesNo()
        {
            No.Wait(3).Click();
            //debugging
            No.Selected = true;
            Yes.Selected = false;
            UseItemSettings.Selected = false;
        }
        /// <summary>
        /// is enable manipulatives: no checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsSelectedEnableManipulativesNo()
        {
            No.Wait(3);
            //debugging
            No.Selected = FakeDummyBooleanValue;
            return No.Selected;
        }
        /// <summary>
        /// is enable manipulatives: no enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledEnableManipulativesNo()
        {
            No.WaitUntilExists(3);
            //debugging
            No.Enabled = FakeDummyBooleanValue;
            return No.Enabled;
        }
        /// <summary>
        /// is enable manipulatives: no displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedEnableManipulativesNo()
        {
            No.WaitUntilExists(3);
            //debugging
            No.Displayed = FakeDummyBooleanValue;
            return No.Displayed;
        }

        /// <summary>
        /// check enable manipulatives
        /// </summary>
        public void CheckEnableManipulatives()
        {
            Check.Wait(3).Check();
            //pause the script for a second to rebuild the DOM
            System.Threading.Thread.Sleep(1000);
            //debugging
            Check.Selected = true;
        }
        /// <summary>
        /// uncheck enable manipulatives
        /// </summary>
        public void UnCheckEnableManipulatives()
        {
            Check.Wait(3).UnCheck();
            //pause the script for a second to rebuild the DOM
            System.Threading.Thread.Sleep(1000);
            //debugging
            Check.Selected = false;
        }
        /// <summary>
        /// is enable manipulatives checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedEnableManipulatives()
        {
            Check.Wait(3);
            //debugging
            Check.Selected = FakeDummyBooleanValue;
            return Check.Selected;
        }
        /// <summary>
        /// is enable manipulatives enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledEnableManipulatives()
        {
            Check.WaitUntilExists(3);
            //debugging
            Check.Enabled = FakeDummyBooleanValue;
            return Check.Enabled;
        }
        /// <summary>
        /// is enable manipulatives displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedEnableManipulatives()
        {
            Check.WaitUntilExists(3);
            //debugging
            Check.Displayed = FakeDummyBooleanValue;
            return Check.Displayed;
        }

        /// <summary>
        /// check Four Function Calculator
        /// </summary>
        public void CheckFourFunctionCalculator()
        {
            FourFunctionCalculator.Wait(3).Check();
            //debugging
            FourFunctionCalculator.Selected = true;
        }
        /// <summary>
        /// uncheck Four Function Calculator
        /// </summary>
        public void UnCheckFourFunctionCalculator()
        {
            FourFunctionCalculator.Wait(3).UnCheck();
            //debugging
            FourFunctionCalculator.Selected = false;
        }
        /// <summary>
        /// is Four Function Calculator checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedFourFunctionCalculator()
        {
            FourFunctionCalculator.Wait(3);
            //debugging
            FourFunctionCalculator.Selected = FakeDummyBooleanValue;
            return FourFunctionCalculator.Selected;
        }
        /// <summary>
        /// is Four Function Calculator enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledFourFunctionCalculator()
        {
            FourFunctionCalculator.WaitUntilExists(3);
            //debugging
            FourFunctionCalculator.Enabled = FakeDummyBooleanValue;
            return FourFunctionCalculator.Enabled;
        }
        /// <summary>
        /// is Four Function Calculator displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedFourFunctionCalculator()
        {
            FourFunctionCalculator.WaitUntilExists(3);
            //debugging
            FourFunctionCalculator.Displayed = FakeDummyBooleanValue;
            return FourFunctionCalculator.Displayed;
        }

        /// <summary>
        /// check Scientific Calculator
        /// </summary>
        public void CheckScientificCalculator()
        {
            ScientificCalculator.Wait(3).Check();
            //debugging
            ScientificCalculator.Selected = true;
        }
        /// <summary>
        /// uncheck Scientific Calculator
        /// </summary>
        public void UnCheckScientificCalculator()
        {
            ScientificCalculator.Wait(3).UnCheck();
            //debugging
            ScientificCalculator.Selected = false;
        }
        /// <summary>
        /// is Scientific Calculator checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedScientificCalculator()
        {
            ScientificCalculator.Wait(3);
            //debugging
            ScientificCalculator.Selected = FakeDummyBooleanValue;
            return ScientificCalculator.Selected;
        }
        /// <summary>
        /// is Scientific Calculator enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledScientificCalculator()
        {
            ScientificCalculator.WaitUntilExists(3);
            //debugging
            ScientificCalculator.Enabled = FakeDummyBooleanValue;
            return ScientificCalculator.Enabled;
        }
        /// <summary>
        /// is Scientific Calculator displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedScientificCalculator()
        {
            ScientificCalculator.WaitUntilExists(3);
            //debugging
            ScientificCalculator.Displayed = FakeDummyBooleanValue;
            return ScientificCalculator.Displayed;
        }

        /// <summary>
        /// check Graphing Calculator
        /// </summary>
        public void CheckGraphingCalculator()
        {
            GraphingCalculator.Wait(3).Check();
            //debugging
            GraphingCalculator.Selected = true;
        }
        /// <summary>
        /// uncheck Graphing Calculator
        /// </summary>
        public void UnCheckGraphingCalculator()
        {
            GraphingCalculator.Wait(3).UnCheck();
            //debugging
            GraphingCalculator.Selected = false;
        }
        /// <summary>
        /// is Graphing Calculator checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedGraphingCalculator()
        {
            GraphingCalculator.Wait(3);
            //debugging
            GraphingCalculator.Selected = FakeDummyBooleanValue;
            return GraphingCalculator.Selected;
        }
        /// <summary>
        /// is Graphing Calculator enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledGraphingCalculator()
        {
            GraphingCalculator.WaitUntilExists(3);
            //debugging
            GraphingCalculator.Enabled = FakeDummyBooleanValue;
            return GraphingCalculator.Enabled;
        }
        /// <summary>
        /// is Graphing Calculator displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedGraphingCalculator()
        {
            GraphingCalculator.WaitUntilExists(3);
            //debugging
            GraphingCalculator.Displayed = FakeDummyBooleanValue;
            return GraphingCalculator.Displayed;
        }

        /// <summary>
        /// check Compass
        /// </summary>
        public void CheckCompass()
        {
            Compass.Wait(3).Check();
            //debugging
            Compass.Selected = true;
        }
        /// <summary>
        /// uncheck Compass
        /// </summary>
        public void UnCheckCompass()
        {
            Compass.Wait(3).UnCheck();
            //debugging
            Compass.Selected = false;
        }
        /// <summary>
        /// is Compass checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedCompass()
        {
            Compass.Wait(3);
            //debugging
            Compass.Selected = FakeDummyBooleanValue;
            return Compass.Selected;
        }
        /// <summary>
        /// is Compass enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledCompass()
        {
            Compass.WaitUntilExists(3);
            //debugging
            Compass.Enabled = FakeDummyBooleanValue;
            return Compass.Enabled;
        }
        /// <summary>
        /// is Compass displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedCompass()
        {
            Compass.WaitUntilExists(3);
            //debugging
            Compass.Displayed = FakeDummyBooleanValue;
            return Compass.Displayed;
        }

        /// <summary>
        /// check Centimeter Ruler
        /// </summary>
        public void CheckCentimeterRuler()
        {
            CentimeterRuler.Wait(3).Check();
            //debugging
            CentimeterRuler.Selected = true;
        }
        /// <summary>
        /// uncheck Centimeter Ruler
        /// </summary>
        public void UnCheckCentimeterRuler()
        {
            CentimeterRuler.Wait(3).UnCheck();
            //debugging
            CentimeterRuler.Selected = false;
        }
        /// <summary>
        /// is Centimeter Ruler checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedCentimeterRuler()
        {
            CentimeterRuler.Wait(3);
            //debugging
            CentimeterRuler.Selected = FakeDummyBooleanValue;
            return CentimeterRuler.Selected;
        }
        /// <summary>
        /// is Centimeter Ruler enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledCentimeterRuler()
        {
            CentimeterRuler.WaitUntilExists(3);
            //debugging
            CentimeterRuler.Enabled = FakeDummyBooleanValue;
            return CentimeterRuler.Enabled;
        }
        /// <summary>
        /// is Centimeter Ruler displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedCentimeterRuler()
        {
            CentimeterRuler.WaitUntilExists(3);
            //debugging
            CentimeterRuler.Displayed = FakeDummyBooleanValue;
            return CentimeterRuler.Displayed;
        }

        /// <summary>
        /// check Inch Ruler
        /// </summary>
        public void CheckInchRuler()
        {
            InchRuler.Wait(3).Check();
            //debugging
            InchRuler.Selected = true;
        }
        /// <summary>
        /// uncheck Inch Ruler
        /// </summary>
        public void UnCheckInchRuler()
        {
            InchRuler.Wait(3).UnCheck();
            //debugging
            InchRuler.Selected = false;
        }
        /// <summary>
        /// is Inch Ruler checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedInchRuler()
        {
            InchRuler.Wait(3);
            //debugging
            InchRuler.Selected = FakeDummyBooleanValue;
            return InchRuler.Selected;
        }
        /// <summary>
        /// is Inch Ruler enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledInchRuler()
        {
            InchRuler.WaitUntilExists(3);
            //debugging
            InchRuler.Enabled = FakeDummyBooleanValue;
            return InchRuler.Enabled;
        }
        /// <summary>
        /// is Inch Ruler displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedInchRuler()
        {
            InchRuler.WaitUntilExists(3);
            //debugging
            InchRuler.Displayed = FakeDummyBooleanValue;
            return InchRuler.Displayed;
        }

        /// <summary>
        /// check Unit Ruler
        /// </summary>
        public void CheckUnitRuler()
        {
            UnitRuler.Wait(3).Check();
            //debugging
            UnitRuler.Selected = true;
        }
        /// <summary>
        /// uncheck Unit Ruler
        /// </summary>
        public void UnCheckUnitRuler()
        {
            UnitRuler.Wait(3).UnCheck();
            //debugging
            UnitRuler.Selected = false;
        }
        /// <summary>
        /// is Unit Ruler checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedUnitRuler()
        {
            UnitRuler.Wait(3);
            //debugging
            UnitRuler.Selected = FakeDummyBooleanValue;
            return UnitRuler.Selected;
        }
        /// <summary>
        /// is Unit Ruler enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledUnitRuler()
        {
            UnitRuler.WaitUntilExists(3);
            //debugging
            UnitRuler.Enabled = FakeDummyBooleanValue;
            return UnitRuler.Enabled;
        }
        /// <summary>
        /// is Unit Ruler displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedUnitRuler()
        {
            UnitRuler.WaitUntilExists(3);
            //debugging
            UnitRuler.Displayed = FakeDummyBooleanValue;
            return UnitRuler.Displayed;
        }

        /// <summary>
        /// check Protractor
        /// </summary>
        public void CheckProtractor()
        {
            Protractor.Wait(3).Check();
            //debugging
            Protractor.Selected = true;
        }
        /// <summary>
        /// uncheck Protractor
        /// </summary>
        public void UnCheckProtractor()
        {
            Protractor.Wait(3).UnCheck();
            //debugging
            Protractor.Selected = false;
        }
        /// <summary>
        /// is Protractor checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedProtractor()
        {
            Protractor.Wait(3);
            //debugging
            Protractor.Selected = FakeDummyBooleanValue;
            return Protractor.Selected;
        }
        /// <summary>
        /// is Protractor enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledProtractor()
        {
            Protractor.WaitUntilExists(3);
            //debugging
            Protractor.Enabled = FakeDummyBooleanValue;
            return Protractor.Enabled;
        }
        /// <summary>
        /// is Protractor displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedProtractor()
        {
            Protractor.WaitUntilExists(3);
            //debugging
            Protractor.Displayed = FakeDummyBooleanValue;
            return Protractor.Displayed;
        }
    }
}
