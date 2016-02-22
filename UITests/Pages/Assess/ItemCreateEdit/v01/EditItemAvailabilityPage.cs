using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Views;
using Core.Tools.WebDriver;
using UITests.Pages.Assess.ItemCreateEdit.v01.Components;
using UITests.Pages.Assess.ItemCreateEdit.v01.EditItemAvailability;

namespace UITests.Pages.Assess.ItemCreateEdit.v01
{
    /// <summary>
    /// The edit item availability page
    /// </summary>
    public class EditItemAvailabilityPage : SNWebPage
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public EditItemAvailabilityPage()
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            this.ExpectedUrl = "/Assess/EditItemAvailability.aspx";
            this.VerifyCurrentUrl();
            GetItemID();
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            this.Form = new EditItemAvailabilityForm();
            this.Form.Parent = this;
        }

        /// <summary>
        /// the form
        /// </summary>
        public new EditItemAvailabilityForm Form { get; set; }

        /// <summary>
        /// the data
        /// </summary>
        public new EditItemAvailabilityData Data
        {
            get
            {
                return (EditItemAvailabilityData)base.Data;
            }
            set
            {
                base.Data = value;
                this.Form.Data = value;
            }
        }
        /// <summary>
        /// intializes the data
        /// </summary>
        /// <returns>object data</returns>
        public EditItemAvailabilityData InitData()
        {
            base.InitData(new EditItemAvailabilityData());
            return (EditItemAvailabilityData)base.Data;
        }
        /// <summary>
        /// initializes the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>object data</returns>
        public EditItemAvailabilityData InitData(object data)
        {
            base.InitData(data);
            return (EditItemAvailabilityData)base.Data;
        }

        /// <summary>
        /// item ID
        /// </summary>
        public int ItemID { get; set; }
        private void GetItemID()
        {
            try
            {
                //is this a mock driver for debugging?
                if (this.Driver.WrappedDriver.GetType() == typeof(DummyDriver))
                {
                    //stub the URL
                    this.Driver.Url = this.TestConfiguration.ApplicationPath + "/" + this.ExpectedUrl
                        + "?test_item_id=" + DateTime.Now.ToString("MMssfff") + "&";
                }
                string actualUrl = this.Driver.Url;
                //Debug.WriteLine("actualUrl: " + actualUrl);
                int index = actualUrl.LastIndexOf("?test_item_id=");
                //Debug.WriteLine("test_item_id index: " + index);
                string temp = actualUrl.Substring(index + "?test_item_id=".Length);
                //Debug.WriteLine("temp: " + temp);
                index = temp.IndexOf("&");
                //Debug.WriteLine("& index: " + index);
                temp = temp.Substring(0, index);
                //Debug.WriteLine("temp: " + temp);
                ItemID = Int32.Parse(temp);
                Report.Write("ItemID: " + ItemID);
            }
            catch (Exception e)//(AssertFailedException e)
            {
                throw new Exception(e.Message, e);//AssertFailedException(e.Message, e);
            }
        }
    }
}
