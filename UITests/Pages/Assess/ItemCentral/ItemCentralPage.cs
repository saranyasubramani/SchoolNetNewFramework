using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Views;
using Core.Tools.WebDriver;
using UITests.Pages.Components;
using UITests.Pages.Assess.ItemCentral.ItemCentral;

namespace UITests.Pages.Assess.ItemCentral
{
    /// <summary>
    /// the item central page
    /// </summary>
    public class ItemCentralPage : SNWebPage
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="itemCentralType">item central type</param>
        public ItemCentralPage(ItemCentralType itemCentralType)
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            //Assess/ItemCentral.aspx
            //Assess/RubricCentral.aspx            
            ExpectedUrl = new List<string>() { "ItemCentral.aspx", "RubricCentral.aspx" };
            this.VerifyCurrentUrl();
            this.ItemCentralType = itemCentralType;
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            this.Detail = new ItemCentralDetail(ItemCentralType, ControlPrefix);
            this.Detail.Parent = this;
            this.Detail.ItemCentralType = this.ItemCentralType;
            this.Form = new ItemCentralForm(ItemCentralType, ControlPrefix);
            this.Form.Parent = this;
            this.Form.ItemCentralType = this.ItemCentralType;
        }

        /// <summary>
        /// the detail
        /// </summary>
        public new ItemCentralDetail Detail { get; private set; }
        /// <summary>
        /// the form
        /// </summary>
        public new ItemCentralForm Form { get; private set; }

        /// <summary>
        /// the data
        /// </summary>
        public new ItemCentralData Data
        {
            get
            {
                return (ItemCentralData)base.Data;
            }
            set
            {
                base.Data = value;
                this.Detail.Data = value;
                this.Form.Data = value;
            }
        }
        /// <summary>
        /// intializes the data
        /// </summary>
        /// <returns>object data</returns>
        public ItemCentralData InitData()
        {
            base.InitData(new ItemCentralData());
            return (ItemCentralData)base.Data;
        }
        /// <summary>
        /// initializes the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>object data</returns>
        public ItemCentralData InitData(object data)
        {
            base.InitData(data);
            return (ItemCentralData)base.Data;
        }

        private List<string> ExpectedUrl;
        /// <summary>
        /// the item central type
        /// </summary>
        public ItemCentralType ItemCentralType { get; set; }

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
                }//this is a real driver
                else
                {
                }
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
                        Report.Write("Verified the actual URL: '" + actualUrl + "' contains the expected URL: '" + ExpectedUrl[foundIndex].ToLower() + "'.");

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
