using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using UITests.Pages.Home.Components;

namespace UITests.Pages.Home
{
    /// <summary>
    /// the student home page
    /// </summary>
    public class StudentHomePage : HomePage
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public StudentHomePage()
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            //https://qa-154st.sndev.net/myschoolnet/?pg=Student&pi=Abraham%20Lincoln%20High
            //https://qa-154st.sndev.net/main.aspx?pg=Student&pi=Abraham%20Lincoln%20High&app_tab_id=a6015ee5-0e5b-47c6-bac6-bc89ca5fe144
            //https://qa-154st.sndev.net/main.aspx?
            ExpectedUrl = new List<string>() { "pg=Student&pi", "main.aspx" };
            this.VerifyCurrentUrl();
            InitElements();
        }
        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            StudentHomeTakeATestForm = new StudentHomeTakeATestForm();
            StudentHomeTakeATestForm.Parent = this;
            StudentHomeReviewATestForm = new StudentHomeReviewATestForm();
            StudentHomeReviewATestForm.Parent = this;
        }

        /// <summary>
        /// the take a test form
        /// </summary>
        public StudentHomeTakeATestForm StudentHomeTakeATestForm { get; set; }
        /// <summary>
        /// the review a test form
        /// </summary>
        public StudentHomeReviewATestForm StudentHomeReviewATestForm { get; set; }

        /// <summary>
        /// the data
        /// </summary>
        public new StudentHomeData Data
        {
            get
            {
                return (StudentHomeData)base.Data;
            }
            set
            {
                base.Data = value;
                this.StudentHomeReviewATestForm.Data = value;
                this.StudentHomeTakeATestForm.Data = value;
            }
        }
        /// <summary>
        /// intializes the data
        /// </summary>
        /// <returns>object data</returns>
        public StudentHomeData InitData()
        {
            base.InitData(new StudentHomeData());
            return (StudentHomeData)base.Data;
        }
        /// <summary>
        /// initializes the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>object data</returns>
        public StudentHomeData InitData(object data)
        {
            base.InitData(data);
            return (StudentHomeData)base.Data;
        }

        private List<string> ExpectedUrl;

        /// <summary>
        /// This page has multiple expected urls. This function make sure the actual url is one of the expected urls. 
        /// </summary>
        public void VerifyCurrentUrl()
        {
            try
            {
                //is this a mock driver for debugging?
                if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
                {
                    //stub the URL
                    this.Driver.Url = this.TestConfiguration.ApplicationPath + "/" + this.ExpectedUrl[0];
                }//else this is a real driver

                string actualUrl = this.Driver.Url;
                int foundIndex = -1;
                int i = 0;

                do
                {
                    Report.Write("Verifying the actual URL: '" + actualUrl + "' contains the expected URL: '" + ExpectedUrl[i] + "'.");
                    if (actualUrl.ToLower().Contains(ExpectedUrl[i].ToLower()))
                    {
                        //An expected url is found
                        foundIndex = i;
                        Report.Write("Verified the actual URL: '" + actualUrl + "' contains the expected URL: '" + ExpectedUrl[foundIndex] + "'.");

                        return;
                    }
                    i++;
                } while (foundIndex == -1 && i < ExpectedUrl.Count);


                //Expected url not found
                Assert.IsTrue(false, "The actual page URL: '" + actualUrl + "' does not contain the list of expected page URLs");
            }
            catch (Exception e)//(AssertFailedException e)
            {
                throw new Exception(e.Message, e);//AssertFailedException(e.Message, e);
            }
        }
    }
}
