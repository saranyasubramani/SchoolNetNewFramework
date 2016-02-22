using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Framework;
using Core.Views;
using Core.Tools.WebDriver;
using OpenQA.Selenium;
using UITests.Pages.Components;
using UITests.Pages.Components.Editors;

namespace UITests.Pages
{
    public class SNGlobalUtilities : BaseApplication
    {
        public SNGlobalUtilities()
            : base()
        {

        }

        protected By ByGlobalAppHeader { get { return By.ClassName("GlobalAppHeader"); } }
        protected WebElementWrapper GlobalAppHeader { get; set; }
        protected By ByGlobalNav { get { return By.ClassName("GlobalNav"); } }
        protected WebElementWrapper GlobalNav { get; set; }
        protected By ByMainContentArea { get { return By.ClassName("MainContentArea"); } }
        protected WebElementWrapper MainContentArea { get; set; }
        protected By ByAppTitle { get { return By.ClassName("AppTitle"); } }
        protected WebElementWrapper AppTitle { get; set; }

        /// <summary>
        /// focus on main content area, to stop hover over menu
        /// </summary>
        public void FocusOnMainContentArea()
        {
            try
            {
                Point dummyPoint = new Point(0, 0);
                Point point;

                GlobalAppHeader = new WebElementWrapper(ByGlobalAppHeader);
                GlobalNav = new WebElementWrapper(ByGlobalNav);
                MainContentArea = new WebElementWrapper(ByMainContentArea);
                AppTitle = new WebElementWrapper(ByAppTitle);

                //new DriverCommands(Driver).GetScreenshotAndPageSource();
                //move to the header
                GlobalAppHeader.Wait(3);
                GlobalAppHeader.LocationOnScreenOnceScrolledIntoView = dummyPoint;
                point = GlobalAppHeader.LocationOnScreenOnceScrolledIntoView;
                GlobalAppHeader.Location = dummyPoint;
                point = GlobalAppHeader.Location;
                if (this.TestConfiguration.BrowserName != BrowserType.SAFARI)
                {
                    GlobalAppHeader.MoveToElement();
                }

                //new DriverCommands(Driver).GetScreenshotAndPageSource();
                //move to the global nav
                GlobalNav.Wait(3);
                GlobalNav.LocationOnScreenOnceScrolledIntoView = dummyPoint;
                point = GlobalNav.LocationOnScreenOnceScrolledIntoView;
                GlobalNav.Location = dummyPoint;
                point = GlobalNav.Location;
                if (this.TestConfiguration.BrowserName != BrowserType.SAFARI)
                {
                    GlobalNav.MoveToElement();
                }

                //new DriverCommands(Driver).GetScreenshotAndPageSource();
                //move to the main content area
                MainContentArea.Wait(3);
                MainContentArea.LocationOnScreenOnceScrolledIntoView = dummyPoint;
                point = MainContentArea.LocationOnScreenOnceScrolledIntoView;
                MainContentArea.Location = dummyPoint;
                point = MainContentArea.Location;
                if (this.TestConfiguration.BrowserName != BrowserType.SAFARI)
                {
                    MainContentArea.MoveToElement();
                }

                try
                {
                    AppTitle.Wait(3);
                    if (this.TestConfiguration.BrowserName != BrowserType.SAFARI)
                    {
                        AppTitle.MoveToElement();
                    }
                    AppTitle.Click();
                }
                catch (Exception ex)
                {
                    //new DriverCommands(Driver).GetScreenshotAndPageSource();
                    //click on main content area
                    MainContentArea.Click();
                }
            }
            catch (Exception e)
            {
                throw new Exception("\nInnerException:\n" + e.InnerException + "\nStackTrace:\n" + e.StackTrace, e);
            }
        }

        public string GetInvisibleErrorMessage(string element)
        {
            string pre = "Expected the element: '";
            string post = "' to be visible, but it is not visible.";
            return pre + element + post;
        }


        #region File Uploads

        /// <summary>
        /// Uploads the required file inside the Editor
        /// </summary>
        /// <param name="editor">Instance of SeleniumUITests.Main.Library.Assess.Components.Editor</param>
        /// <param name="autoItData">Instance of the AutoIt Data Object</param>
        /// <param name="fileUploadTree">Dictionary containing the File Upload Details for the Scenario. Inner Dictionary Uses Question Content, Answer Content, Teacher or Student Explanation as Key. 
        /// Inner Dictionary uses Image File Name to be uploaded as the Value.  Outer Dictionary Uses True or False (boolean) as Key to indicate WithFileUpload or WithoutFileUpload.</param>
        /// <param name="fieldToUploadTheFileTo">string value of the Field on the form concerned to which the file needs to be uploaded</param>
        public void DoFileUpload(Editor editor, AutoItData autoItData, Dictionary<bool, Dictionary<string, string>> fileUploadTree, string fieldToUploadTheFileTo)
        {
            if (fileUploadTree != null && fileUploadTree.ContainsKey(true))
            {
                var fileNameDictionary = new Dictionary<string, string>();
                fileUploadTree.TryGetValue(true, out fileNameDictionary);
                if (fileNameDictionary != null && fileNameDictionary.ContainsKey(fieldToUploadTheFileTo))
                {
                    editor.DoFileUpload = true;
                    autoItData.FileNameToBeUploaded = fileNameDictionary[fieldToUploadTheFileTo];
                    editor.Data = autoItData;
                }

                else
                {
                    editor.DoFileUpload = false;
                }
            }

            else
            {
                editor.DoFileUpload = false;
            }
        }

        /// <summary>
        /// Uploads the required file inside the Editor
        /// </summary>
        /// <param name="editor">Instance of SeleniumUITests.Main.Library.Assess.Components.TeacherInstructionEditor</param>
        /// <param name="autoItData">Instance of the AutoIt Data Object</param>
        /// <param name="fileUploadTree">Dictionary containing the File Upload Details for the Scenario. Inner Dictionary Uses Question Content, Answer Content, Teacher or Student Explanation as Key. 
        /// Inner Dictionary uses Image File Name to be uploaded as the Value.  Outer Dictionary Uses True or False (boolean) as Key to indicate WithFileUpload or WithoutFileUpload.</param>
        /// <param name="fieldToUploadTheFileTo">string value of the Field on the form concerned to which the file needs to be uploaded</param>
        public void DoFileUpload(TeacherInstructionEditor editor, AutoItData autoItData, Dictionary<bool, Dictionary<string, string>> fileUploadTree, string fieldToUploadTheFileTo)
        {
            if (fileUploadTree != null && fileUploadTree.ContainsKey(true))
            {
                var fileNameDictionary = new Dictionary<string, string>();
                fileUploadTree.TryGetValue(true, out fileNameDictionary);
                if (fileNameDictionary != null && fileNameDictionary.ContainsKey(fieldToUploadTheFileTo))
                {
                    editor.Form.DoFileUpload = true;
                    autoItData.FileNameToBeUploaded = fileNameDictionary[fieldToUploadTheFileTo];
                    editor.Data = autoItData;
                }

                else
                {
                    editor.Form.DoFileUpload = false;
                }
            }

            else
            {
                editor.Form.DoFileUpload = false;
            }
        }

        /// <summary>
        /// Upload File using AutoIt (Old Framework Method adapted to New Framework)
        /// </summary>
        /// <param name="autoItData">AutoIt Data Object Instance</param>
        /// <param name="uploadButtonOrLink">Upload button or Link which when clicked gives the File Upload dialog</param>
        public void UploadFile(AutoItData autoItData, WebElementWrapper uploadButtonOrLink)
        {
            //var autoItExecutablePath = combinePathAndVerify(TestDeploymentDir, "AutoIt3.exe");
            var autoItExecutablePath = CombinePathAndVerifyFileExists(autoItData.DeploymentDirectory, autoItData.AutoItExecutableName);

            var autoItScriptPath = "";

            if(this.TestConfiguration.BrowserName == BrowserType.INTERNET_EXPLORER)
            {
                autoItScriptPath = CombinePathAndVerifyFileExists(autoItData.DeploymentDirectory, autoItData.UploadImageInIEScriptName);
            }

            else if (this.TestConfiguration.BrowserName == BrowserType.CHROME)
            {
                autoItScriptPath = CombinePathAndVerifyFileExists(autoItData.DeploymentDirectory, autoItData.UploadImageInChromeScriptName);
            }

            else
            {
                autoItScriptPath = CombinePathAndVerifyFileExists(autoItData.DeploymentDirectory, autoItData.UploadImageScriptName);
            }

            var pathofFileToBeUploaded = CombinePathAndVerifyFileExists(autoItData.DeploymentDirectory, autoItData.FileNameToBeUploaded);

            Action doBeforeUpload = () =>
            {
                System.Threading.Thread.Sleep(1000);
                uploadButtonOrLink.Wait(1).Click();
            };

            var processStartInfo = new ProcessStartInfo() { FileName = autoItExecutablePath, WorkingDirectory = autoItData.DeploymentDirectory, Arguments = string.Format("{0} {1}", autoItScriptPath, pathofFileToBeUploaded) };
            RunAutoItProcess(processStartInfo, doBeforeUpload, "Auto it upload file script failed to terminate within 30 seconds");
        }

        /// <summary>
        /// Combines the Path components (both arguments) to get the Fully Qualified Path for the File.
        /// Also verfies the existence of the file at the location indicated by the Full path.
        /// </summary>
        /// <param name="directory">Directory in which the File exists</param>
        /// <param name="fileName">Name of the File to get the Path for</param>
        /// <returns></returns>
        public string CombinePathAndVerifyFileExists(string directory, string fileName)
        {
            var retval = Path.Combine(directory, fileName);

            if (!File.Exists(retval))
            {
                Assert.Fail(string.Format("file {0} missing from {1}", fileName, directory));
            }

            if (retval.Contains(" "))
            {
                return "\"" + retval + "\"";
            }

            return retval;
        }

        /// <summary>
        /// runs the provided process, then call the doBeforeUpload action if there is one, 
        /// then block until process completes. This is necessary, since auto it script will 
        /// be manpulating operating systems dialogs (like save dialos), and if you do a 
        /// web driver action that produces one of these dialogs, Web driver will block, 
        /// and your autoit script will not get executed.
        /// </summary>
        /// <param name="processStartInfo">process (probably autoit process) to execute</param>
        /// <param name="doBeforeUpload">action (probably a webdiver click that causes some operating system stuff)</param>
        /// <param name="errorMessage">text to return in the event of an error</param>
        public void RunAutoItProcess(ProcessStartInfo processStartInfo, Action doBeforeUpload = null, string errorMessage = null)
        {
            processStartInfo.UseShellExecute = false;

            using (Process autoItProcess = Process.Start(processStartInfo))
            {
                string processName = autoItProcess.ProcessName;

                Exception ex = null;
                try
                {
                    if (!processStartInfo.WorkingDirectory.Equals(Directory.GetCurrentDirectory()))
                        Directory.SetCurrentDirectory(processStartInfo.WorkingDirectory);

                    if (!Process.GetProcessesByName(processName).Any())
                        autoItProcess.Start();

                    DoAction(doBeforeUpload);
                }
                catch (Exception e)
                {
                    ex = e;
                }
                if (ex != null)
                {
                    autoItProcess.Close();
                }

                if (!autoItProcess.WaitForExit(8000))
                {
                    autoItProcess.Close();
                }

            }
        }

        /// <summary>
        /// Does the Action Specified
        /// </summary>
        /// <param name="thingToDo">Action to Perform</param>
        private void DoAction(Action thingToDo)
        {
            if (thingToDo != null)
            {
                Exception last = null;
                var tries = 0;
                do
                {
                    try
                    {
                        thingToDo();
                    }
                    catch (Exception e)
                    {
                        last = e;
                        tries++;
                        System.Threading.Thread.Sleep(200);
                    }
                } while (last != null && tries < 5);

                if (last != null)
                    throw last;
            }
        }

        #endregion
    }
}
