using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Core.Tools.WebDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UITests.Pages
{
    public class SNDriverCommands : DriverCommands
    {
        public SNDriverCommands()
            : base()
        {

        }

        public void WaitAndMeasurePageLoadTime()
        {
            WaitAndMeasurePageLoadTime(this.TestConfiguration.PageLoadTimeOut, 30);
        }

        public void WaitAndMeasurePageLoadTime(double pageTimeOut, double spinnerTimeOut)
        {
            //Stopwatch stopWatch = new Stopwatch();
            //stopWatch.Start();
            int pageLoadSeconds = WaitForPageToLoad(pageTimeOut);
            int spinnerSeconds = WaitForSpinnersToVanish(spinnerTimeOut);
            //stopWatch.Stop();
            //TimeSpan elapsedTotal = stopWatch.Elapsed;
            int elapsedSeconds = pageLoadSeconds + spinnerSeconds;
            this.Report.Write("Total page load time was: '" + elapsedSeconds + "'.");
            Thread.Sleep(TimeSpan.FromSeconds(1));
        }

        public int WaitForSpinnersToVanish(double timeout)
        {
            By bySpinner = By.CssSelector("img[src*='loading_rotation.gif']");
            this.Report.Write("Wait up to '" + timeout + "' seconds for the spinners to vanish.");
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            if (((DriverWrapper)Driver).WrappedDriver.GetType() != typeof(DummyDriver))
            {
                try
                {
                    var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
                    bool isFound = wait.Until((driver) =>
                    {
                        try
                        {
                            ReadOnlyCollection<IWebElement> webElements = driver.FindElements(bySpinner);
                            int count = webElements.Count;
                            this.Report.Write("Found '" + count + "' spinner elements by: '" + bySpinner.ToString() + "'.");
                            foreach (var webElement in webElements)
                            {
                                this.Report.Write("Spinner displayed state: " + webElement.Displayed);
                            }
                            bool found = !webElements.Any(element => element.Displayed);
                            return found;
                        }
                        catch (Exception exception)
                        {
                            throw new Exception(exception.Message, exception);
                        }
                    });
                }
                catch (Exception e)
                {
                    //do nothing if the spinner not found
                }
            }
            stopWatch.Stop();
            TimeSpan elapsedTotal = stopWatch.Elapsed;
            int elapsedSeconds;
            if (elapsedTotal.Seconds == TestConfiguration.ImplicitTimeOut)
            {
                elapsedSeconds = elapsedTotal.Seconds - TestConfiguration.ImplicitTimeOut;
            }
            else if (elapsedTotal.Seconds > TestConfiguration.ImplicitTimeOut)
            {
                elapsedSeconds = elapsedTotal.Seconds;
            }
            else
            {
                elapsedSeconds = elapsedTotal.Seconds;
            }
            this.Report.Write("Waited '" + elapsedSeconds + "' seconds for the spinners to vanish.");
            return elapsedSeconds;
        }

    }
}
