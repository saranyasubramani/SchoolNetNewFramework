using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;

namespace UITests.Pages.Components.Editors
{
    /// <summary>
    /// editor dialog form
    /// </summary>
    public class EditorDialogForm : SNForm
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="overrideControlPrefix"></param>
        public EditorDialogForm(string overrideControlPrefix = null)
            : base()
        {
            InitElements();
        }
        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            DialogDiv = new WebElementWrapper(ByDialogDiv);
            GetUniqueControlIdentifiers();
        }

        /// <summary>
        /// the unique ID to identified the dialog (ie mce_27, 27 is the unique id)
        /// </summary>
        public string UniqueId { get; set; }

        private By ByDialogDiv { get { return By.CssSelector("div.clearlooks2"); } }
        private WebElementWrapper DialogDiv { get; set; }

        private void GetUniqueControlIdentifiers()
        {
            //By dialogDiv = By.CssSelector("div.clearlooks2");
            //IWebElement webElement = Driver.FindElement(dialogDiv);
            //Debug.WriteLine("Found the element by: '" + dialogDiv.ToString() + "'.");

            string id = DialogDiv.GetAttribute("id");
            Report.Write("Got the attribute: 'id' = '" + id + "' of this element by: '" + ByDialogDiv.ToString() + "'.");
            int from = id.LastIndexOf("_");
            UniqueId = id.Substring(from + 1, 2);
        }
    }
}
