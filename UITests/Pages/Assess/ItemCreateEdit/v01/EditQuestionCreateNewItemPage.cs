using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages.Components;
using UITests.Pages.Assess.ItemCreateEdit.v01.Components;
using UITests.Pages.Assess.ItemCreateEdit.v01.ItemForms;
using UITests.Pages.Assess.ItemCreateEdit.v01.EditQuestion;

namespace UITests.Pages.Assess.ItemCreateEdit.v01
{
    /// <summary>
    /// The create new item type page inherited from the edit question page
    /// </summary>
    public class EditQuestionCreateNewItemPage : EditQuestionPage
    {
        /// <summary>
        /// the create new item page constructor
        /// </summary>
        /// <param name="itemTypeForm">item type form</param>
        public EditQuestionCreateNewItemPage(ItemTypeForm itemTypeForm)
            : base()
        {
            this._itemTypeForm = itemTypeForm;
            this._itemType = itemTypeForm.ItemType;
            this.Name = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            GetItemID();
            InitElements();
        }
        /// <summary>
        /// the create new item page constructor
        /// </summary>
        /// <param name="itemType">item type</param>
        public EditQuestionCreateNewItemPage(ItemType itemType)
            : base()
        {
            this._itemType = itemType;
            this._itemTypeForm = null;
            this.Name = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            GetItemID();
            InitElements();
        }
        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            Report.Write("Martin EditQuestionCreateNewItemPage.InitElements");
            base.InitElements();
            if (_itemTypeForm == null)
            {
                this.Form = new EditQuestionCreateNewItemForm(_itemType, ControlPrefix);
            }
            else
            {
                this.Form = new EditQuestionCreateNewItemForm(_itemTypeForm, ControlPrefix);
            }
            this.Form.Parent = this;
            this.Detail = new EditQuestionCreateNewItemDetail(ControlPrefix);
            this.Detail.Parent = this;
        }

        /// <summary>
        /// the form
        /// </summary>
        public new EditQuestionCreateNewItemForm Form { get; private set; }
        /// <summary>
        /// the detail
        /// </summary>
        public new EditQuestionCreateNewItemDetail Detail { get; private set; }

        /// <summary>
        /// the data
        /// </summary>
        /// <remarks>overrides EditPageData.Data</remarks>
        public EditPageData Data
        {
            get
            {
                return (EditPageData)base.Data;
            }
            set
            {
                Report.Write("Martin... in EditQuestionCreateNewItemPage.Data...");
                base.Data = value;
                this.Form.Data = value;
                this.Detail.Data = value;
            }
        }

        private ItemTypeForm _itemTypeForm;
        private ItemType _itemType;

        /// <summary>
        /// item ID
        /// </summary>
        public int ItemID { get; set; }
        private void GetItemID()
        {
            //TODO:
            //https://team-automation-st.sndev.net/Assess/Items/EditQuestion.aspx?test_id=54962&question_id=327291
            //https://team-automation-st.sndev.net/Assess/Items/EditQuestion.aspx?test_id=54962&question_id=327292&admin_id=0&referrer=~
            //https://team-automation-st.sndev.net/Assess/Items/EditQuestion.aspx?test_id=54963&question_id=327293
            //https://team-automation-st.sndev.net/Assess/Items/EditQuestion.aspx?test_id=54963&question_id=327294&admin_id=0&referrer=~
            try
            {
                //is this a mock driver for debugging?
                if (this.Driver.WrappedDriver.GetType() == typeof(DummyDriver))
                {
                    //stub the URL
                    this.Driver.Url = this.TestConfiguration.ApplicationPath + "/" + this.ExpectedUrl
                        + "?test_id=54962&question_id=" + DateTime.Now.ToString("MMssfff");
                }
                string actualUrl = this.Driver.Url;
                //Debug.WriteLine("actualUrl: " + actualUrl);
                int index = actualUrl.LastIndexOf("&question_id=");
                //Debug.WriteLine("question_id index: " + index);
                string temp = actualUrl.Substring(index + "&question_id=".Length);
                //Debug.WriteLine("temp: " + temp);
                index = temp.IndexOf("&");
                //Debug.WriteLine("& index: " + index);
                if (index == -1)
                {
                    temp = temp.Substring(0);
                }
                else
                {
                    temp = temp.Substring(0, index);
                }
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
