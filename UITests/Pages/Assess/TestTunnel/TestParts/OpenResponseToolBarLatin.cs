using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Tools.WebDriver;
using OpenQA.Selenium;

namespace UITests.Pages.Assess.TestTunnel.TestParts
{
    /// <summary>
    /// represents the test tunnel open response form's editor Latin tool bar
    /// </summary>
    public class OpenResponseToolBarLatin : SNComponent
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public OpenResponseToolBarLatin()
            : base()
        {
            CapitalA_AcuteButton = new WebElementWrapper( ByCapitalA_AcuteButton);
            SmallA_AcuteButton = new WebElementWrapper( BySmallA_AcuteButton);
            CapitalE_AcuteButton = new WebElementWrapper( ByCapitalE_AcuteButton);
            SmallE_AcuteButton = new WebElementWrapper( BySmallE_AcuteButton);
            CapitalI_AcuteButton = new WebElementWrapper( ByCapitalI_AcuteButton);
            SmallI_AcuteButton = new WebElementWrapper( BySmallI_AcuteButton);
            CapitalN_TildeButton = new WebElementWrapper( ByCapitalN_TildeButton);
            SmallN_TildeButton = new WebElementWrapper( BySmallN_TildeButton);
            CapitalO_AcuteButton = new WebElementWrapper( ByCapitalO_AcuteButton);
            SmallO_AcuteButton = new WebElementWrapper( BySmallO_AcuteButton);
            CapitalU_AcuteButton = new WebElementWrapper( ByCapitalU_AcuteButton);
            SmallU_AcuteButton = new WebElementWrapper( BySmallU_AcuteButton);
            CapitalU_DiaeresisButton = new WebElementWrapper( ByCapitalU_DiaeresisButton);
            SmallU_DiaeresisButton = new WebElementWrapper( BySmallU_DiaeresisButton);
        }

        private By ByCapitalA_AcuteButton { get { return By.Name("spec0"); } }
        private WebElementWrapper CapitalA_AcuteButton { get; set; }
        private By BySmallA_AcuteButton { get { return By.Name("spec1"); } }
        private WebElementWrapper SmallA_AcuteButton { get; set; }
        private By ByCapitalE_AcuteButton { get { return By.Name("spec2"); } }
        private WebElementWrapper CapitalE_AcuteButton { get; set; }
        private By BySmallE_AcuteButton { get { return By.Name("spec3"); } }
        private WebElementWrapper SmallE_AcuteButton { get; set; }
        private By ByCapitalI_AcuteButton { get { return By.Name("spec4"); } }
        private WebElementWrapper CapitalI_AcuteButton { get; set; }
        private By BySmallI_AcuteButton { get { return By.Name("spec5"); } }
        private WebElementWrapper SmallI_AcuteButton { get; set; }
        private By ByCapitalN_TildeButton { get { return By.Name("spec6"); } }
        private WebElementWrapper CapitalN_TildeButton { get; set; }
        private By BySmallN_TildeButton { get { return By.Name("spec7"); } }
        private WebElementWrapper SmallN_TildeButton { get; set; }
        private By ByCapitalO_AcuteButton { get { return By.Name("spec8"); } }
        private WebElementWrapper CapitalO_AcuteButton { get; set; }
        private By BySmallO_AcuteButton { get { return By.Name("spec9"); } }
        private WebElementWrapper SmallO_AcuteButton { get; set; }
        private By ByCapitalU_AcuteButton { get { return By.Name("spec10"); } }
        private WebElementWrapper CapitalU_AcuteButton { get; set; }
        private By BySmallU_AcuteButton { get { return By.Name("spec11"); } }
        private WebElementWrapper SmallU_AcuteButton { get; set; }
        private By ByCapitalU_DiaeresisButton { get { return By.Name("spec12"); } }
        private WebElementWrapper CapitalU_DiaeresisButton { get; set; }
        private By BySmallU_DiaeresisButton { get { return By.Name("spec13"); } }
        private WebElementWrapper SmallU_DiaeresisButton { get; set; }

        /// <summary>
        /// click capital 'A' with acute
        /// </summary>
        public void ClickCapitalA_Acute()
        {
            CapitalA_AcuteButton.Wait(3).Click();
        }
        /// <summary>
        /// click small 'a' with acute
        /// </summary>
        public void ClickSmallA_Acute()
        {
            SmallA_AcuteButton.Wait(3).Click();
        }
        /// <summary>
        /// click capital 'E' with acute
        /// </summary>
        public void ClickCapitalE_Acute()
        {
            CapitalE_AcuteButton.Wait(3).Click();
        }
        /// <summary>
        /// click small 'e' with acute
        /// </summary>
        public void ClickSmallE_Acute()
        {
            SmallE_AcuteButton.Wait(3).Click();
        }
        /// <summary>
        /// click capital 'I' with acute
        /// </summary>
        public void ClickCapitalI_Acute()
        {
            CapitalI_AcuteButton.Wait(3).Click();
        }
        /// <summary>
        /// click small 'i' with acute
        /// </summary>
        public void ClickSmallI_Acute()
        {
            SmallI_AcuteButton.Wait(3).Click();
        }
        /// <summary>
        /// click capital 'N' with tilde
        /// </summary>
        public void ClickCapitalN_Tilde()
        {
            CapitalN_TildeButton.Wait(3).Click();
        }
        /// <summary>
        /// click small 'n' with tilde
        /// </summary>
        public void ClickSmallN_Tilde()
        {
            SmallN_TildeButton.Wait(3).Click();
        }
        /// <summary>
        /// click capital 'O' with acute
        /// </summary>
        public void ClickCapitalO_Acute()
        {
            CapitalO_AcuteButton.Wait(3).Click();
        }
        /// <summary>
        /// click small 'o' with acute
        /// </summary>
        public void ClickSmallO_Acute()
        {
            SmallO_AcuteButton.Wait(3).Click();
        }
        /// <summary>
        /// click capital 'U' with acute
        /// </summary>
        public void ClickCapitalU_Acute()
        {
            CapitalU_AcuteButton.Wait(3).Click();
        }
        /// <summary>
        /// click small 'u' with acute
        /// </summary>
        public void ClickSmallU_Acute()
        {
            SmallU_AcuteButton.Wait(3).Click();
        }
        /// <summary>
        /// click capital 'U' with diaeresis
        /// </summary>
        public void ClickCapitalU_Diaeresis()
        {
            CapitalU_DiaeresisButton.Wait(3).Click();
        }
        /// <summary>
        /// click small 'u' with diaeresis
        /// </summary>
        public void ClickSmallU_Diaeresis()
        {
            SmallU_DiaeresisButton.Wait(3).Click();
        }
    }
}
