using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Core.Tools.WebDriver;
using OpenQA.Selenium;

namespace UITests.Pages.Assess.TestTunnel.TestParts
{
    /// <summary>
    /// represents the test tunnel open response form's editor tool bar
    /// </summary>
    public class OpenResponseToolBar : SNComponent
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public OpenResponseToolBar( )
            : base()
        {
            BoldButton = new WebElementWrapper( ByBoldButton);
            ItalicButton = new WebElementWrapper( ByItalicButton);
            UnderlineButton = new WebElementWrapper( ByUnderlineButton);
            StrikethroughButton = new WebElementWrapper( ByStrikethroughButton);
            SubscriptButton = new WebElementWrapper( BySubscriptButton);
            SuperscriptButton = new WebElementWrapper( BySuperscriptButton);
            SpecialCharactersButton = new WebElementWrapper( BySpecialCharactersButton);
        }

        private By ByBoldButton { get { return By.Id("divLongResponseTM_bold"); } }
        private WebElementWrapper BoldButton { get; set; }
        private By ByItalicButton { get { return By.Id("divLongResponseTM_italic"); } }
        private WebElementWrapper ItalicButton { get; set; }
        private By ByUnderlineButton { get { return By.Id("divLongResponseTM_underline"); } }
        private WebElementWrapper UnderlineButton { get; set; }
        private By ByStrikethroughButton { get { return By.Id("divLongResponseTM_strikethrough"); } }
        private WebElementWrapper StrikethroughButton { get; set; }
        private By BySubscriptButton { get { return By.Id("divLongResponseTM_sub"); } }
        private WebElementWrapper SubscriptButton { get; set; }
        private By BySuperscriptButton { get { return By.Id("divLongResponseTM_sup"); } }
        private WebElementWrapper SuperscriptButton { get; set; }
        private By BySpecialCharactersButton { get { return By.Id("divLongResponseTM_SN_Charmap"); } }
        private WebElementWrapper SpecialCharactersButton { get; set; }

        /// <summary>
        /// click bold
        /// </summary>
        public void ClickBold()
        {
            BoldButton.Wait(3).Click();
        }
        /// <summary>
        /// click italic
        /// </summary>
        public void ClickItalic()
        {
            ItalicButton.Wait(3).Click();
        }
        /// <summary>
        /// click underline
        /// </summary>
        public void ClickUnderline()
        {
            UnderlineButton.Wait(3).Click();
        }
        /// <summary>
        /// click strikethrough
        /// </summary>
        public void ClickStrikethrough()
        {
            StrikethroughButton.Wait(3).Click();
        }
        /// <summary>
        /// click subscript
        /// </summary>
        public void ClickSubscript()
        {
            SubscriptButton.Wait(3).Click();
        }
        /// <summary>
        /// click superscript
        /// </summary>
        public void ClickSuperscript()
        {
            SuperscriptButton.Wait(3).Click();
        }
        /// <summary>
        /// click special character button
        /// </summary>
        public void ClickSpecialCharacters()
        {
            SpecialCharactersButton.Wait(3).Click();
            //wait a second for the special characters tool bar to render
            Thread.Sleep(TimeSpan.FromSeconds(2));
        }
    }
}
