using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace UITests.Pages.Components
{
    /// <summary>
    /// Wrapper for the Actions class.
    /// </summary>
    public class ActionsWrapper : SNComponent
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public ActionsWrapper()
            : base()
        {
        }

        /// <summary>
        /// Performs a drag-and-drop operation from one element to another.
        /// </summary>
        /// <param name="source">The element on which the drag operation is started.</param>
        /// <param name="target">The element on which the drop is performed.</param>
        /// <returns>A self-reference to this OpenQA.Selenium.Interactions.Actions.</returns>
        public Actions DragAndDrop(WebElementWrapper source, WebElementWrapper target)
        {
            Report.Write("Attempting to drag the source element found by: '" + source.By.ToString() + "', and drop it on the target element found by: '" + target.By.ToString() + "'.");
            Actions actions = new Actions(Driver.WrappedDriver).DragAndDrop(source.WrappedElement, target.WrappedElement);
            Report.Write("Dragged the source element found by: '" + source.By.ToString() + "', and dropped it on the target element found by: '" + target.By.ToString() + "'.");
            return actions;
        }
    }
}
