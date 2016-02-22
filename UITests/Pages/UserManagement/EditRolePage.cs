using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Views;
using UITests.Pages.Login.Components;
using UITests.Pages.UserManagement.EditRole;

namespace UITests.Pages.UserManagement
{
    /// <summary>
    /// Edit Role page
    /// </summary>
    public class EditRolePage : SNWebPage
    {
        /// <summary>
        /// constructor
        /// </summary>
        public EditRolePage()
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            this.ExpectedUrl = "/Directory/EditRole.aspx";
            this.VerifyCurrentUrl();
            InitElements();
        }
        /// <summary>
        /// intialize elements
        /// </summary>
        public override void InitElements()
        {
            Form = new EditRoleForm();
            this.Form.Parent = this;
        }
        /// <summary>
        /// the form
        /// </summary>
        public new EditRoleForm Form { get; set; }

        /// <summary>
        /// the data
        /// </summary>
        public new EditRoleData Data
        {
            get
            {
                return (EditRoleData)base.Data;
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
        public new EditRoleData InitData()
        {
            base.InitData(new EditRoleData());
            return (EditRoleData)base.Data;
        }
        /// <summary>
        /// initializes the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>object data</returns>
        public EditRoleData InitData(object data)
        {
            base.InitData(data);
            return (EditRoleData)base.Data;
        }
    }
}
