using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Core.Tools.WebDriver;
using Core.Views.Grids;
using UITests.Pages.Components;

namespace UITests.Pages.UserManagement.RolesHome
{
    /// <summary>
    /// RolesHome Grid on the RolesHome Page
    /// </summary>
    public class RolesHomeGrid : SNGrid
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="gridCssSelector">the grid CSS Selector</param>
        /// <param name="initializeGrid">initialize the grid?</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public RolesHomeGrid(string gridCssSelector, bool initializeGrid = false, string overrideControlPrefix = null)
            : base(gridCssSelector, false, overrideControlPrefix)//override initializeGrid = false in base constructor, so I can call it later in this constructor
        {
            //override the column selector
            ByColumns = By.CssSelector(gridCssSelector + " tr.DataGridHeader > td");
            InitializeGrid = initializeGrid;
            InitElements();
        }

        /// <summary>
        /// Gets the Dummy Column List
        /// </summary>
        /// <returns></returns>
        public override List<IWebElement> GetDummyElementsColumns()
        {
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                if (DummyElementColumnList == null)
                {
                    DummyWebElement dummy1 = new DummyWebElement();
                    dummy1.Text = "";
                    DummyWebElement dummy2 = new DummyWebElement();
                    dummy2.Text = "Role Name";
                    DummyWebElement dummy3 = new DummyWebElement();
                    dummy3.Text = "Description";
                    DummyWebElement dummy4 = new DummyWebElement();
                    dummy4.Text = "Operation Templates";
                    DummyElementColumnList = new List<IWebElement> { dummy1, dummy2, dummy3, dummy4 };
                }
            }
            return DummyElementColumnList;
        }

        /// <summary>
        /// Gets the List of Dummy Pagination Rows if any.
        /// </summary>
        /// <returns></returns>
        public override List<IWebElement> GetDummyElementsPaginationRows()
        {
            return DummyElementPaginationRowList;
        }

        /// <summary>
        /// Gets the Header Rows - Containing all the column names of the grid
        /// </summary>
        /// <returns></returns>
        public override List<IWebElement> GetDummyElementsHeaderRows()
        {
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                if (DummyElementHeaderRowList == null)
                {
                    DummyWebElement dummy1 = new DummyWebElement();
                    dummy1.Text = @"<td class='TableHead'>
                                      <a href='/Directory/EditRole.aspx?referrer=~%2FDirectory%2FRolesHome.aspx'>
                                      <img id='ctl00_MainContent_RoleManagerControl_DataGridRoles_ctl01_imgAddRole' title='Add New Role' src='/images/icon_add.gif' style='border-width:0px;'>
                                      </a>
                                    </td>
                                    <td class='TableHead'>Role Name</td>
                                    <td class='TableHead'>Description</td>
                                    <td class='TableHead last-child'>Operation Templates</td>";
                    DummyElementHeaderRowList = new List<IWebElement> { dummy1 };
                }
            }
            return DummyElementHeaderRowList;
        }

        /// <summary>
        /// Gets the Dummy Data Row List
        /// </summary>
        /// <returns></returns>
        public override List<IWebElement> GetDummyElementsDataRows()
        {
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                if (DummyElementDataRowList == null)
                {
                    DummyWebElement dummy1 = new DummyWebElement();
                    dummy1.Text = @"<td>
                                      <a id='ctl00_MainContent_RoleManagerControl_DataGridRoles_ctl02_HyperLink1' href='/Directory/EditRole.aspx'>
                                        <img id='ctl00_MainContent_RoleManagerControl_DataGridRoles_ctl02_imgEditRole' src='/images/icon_property.gif' title='Edit Role' />
                                      </a>
                                      <a id='ctl00_MainContent_RoleManagerControl_DataGridRoles_ctl02_Hyperlink2' href='/Directory/EditRoleMembership.aspx'>
                                        <img id='ctl00_MainContent_RoleManagerControl_DataGridRoles_ctl02_imgEditRoleMembership' src='/images/icon_property.gif' title='Edit Role Membership' />
                                      </a>
                                    </td>
                                    <td class='Normal'> 				Employee 			</td>
                                    <td class='Normal'> 				A person who is employed by the school district.   			</td>
                                    <td class='Normal last-child'> 				Test data.   			</td>";
                    DummyWebElement dummy2 = new DummyWebElement();
                    dummy2.Text = @"<td>
                                      <a id='ctl00_MainContent_RoleManagerControl_DataGridRoles_ctl02_HyperLink1' href='/Directory/EditRole.aspx'>
                                        <img id='ctl00_MainContent_RoleManagerControl_DataGridRoles_ctl02_imgEditRole' src='/images/icon_property.gif' title='Edit Role' />
                                      </a>
                                      <a id='ctl00_MainContent_RoleManagerControl_DataGridRoles_ctl02_Hyperlink2' href='/Directory/EditRoleMembership.aspx'>
                                        <img id='ctl00_MainContent_RoleManagerControl_DataGridRoles_ctl02_imgEditRoleMembership' src='/images/icon_property.gif' title='Edit Role Membership' />
                                      </a>
                                    </td>
                                    <td class='Normal'> 				Leadership 			</td>
                                    <td class='Normal'> 				A person who has administrative duties at the institutional level.   			</td>
                                    <td class='Normal last-child'> 				Test data.   			</td>";
                    DummyWebElement dummy3 = new DummyWebElement();
                    dummy3.Text = @"<td>
                                      <a id='ctl00_MainContent_RoleManagerControl_DataGridRoles_ctl02_HyperLink1' href='/Directory/EditRole.aspx'>
                                        <img id='ctl00_MainContent_RoleManagerControl_DataGridRoles_ctl02_imgEditRole' src='/images/icon_property.gif' title='Edit Role' />
                                      </a>
                                      <a id='ctl00_MainContent_RoleManagerControl_DataGridRoles_ctl02_Hyperlink2' href='/Directory/EditRoleMembership.aspx'>
                                        <img id='ctl00_MainContent_RoleManagerControl_DataGridRoles_ctl02_imgEditRoleMembership' src='/images/icon_property.gif' title='Edit Role Membership' />
                                      </a>
                                    </td>
                                    <td class='Normal'> 				Teacher 			</td>
                                    <td class='Normal'> 				A person employed by the school district to instruct students.   			</td>
                                    <td class='Normal last-child'> 				Test data.   			</td>";
                    DummyWebElement dummy4 = new DummyWebElement();
                    dummy4.Text = @"<td>
                                      <a id='ctl00_MainContent_RoleManagerControl_DataGridRoles_ctl02_HyperLink1' href='/Directory/EditRole.aspx'>
                                        <img id='ctl00_MainContent_RoleManagerControl_DataGridRoles_ctl02_imgEditRole' src='/images/icon_property.gif' title='Edit Role' />
                                      </a>
                                      <a id='ctl00_MainContent_RoleManagerControl_DataGridRoles_ctl02_Hyperlink2' href='/Directory/EditRoleMembership.aspx'>
                                        <img id='ctl00_MainContent_RoleManagerControl_DataGridRoles_ctl02_imgEditRoleMembership' src='/images/icon_property.gif' title='Edit Role Membership' />
                                      </a>
                                    </td>
                                    <td class='Normal'> 				Student 			</td>
                                    <td class='Normal'> 				A person who is enrolled in and attending school at the school district.   			</td>
                                    <td class='Normal last-child'> 				   			</td>";
                    DummyElementDataRowList = new List<IWebElement> { dummy1, dummy2, dummy3, dummy4 };
                }
            }
            return DummyElementDataRowList;
        }

        /// <summary>
        /// Sets the Columns List
        /// </summary>
        public override void SetColumnLists()
        {
            base.SetColumnLists();
            int columnIndex = 0;
            foreach (var webElement in WebElementColumns)
            {
                Report.Write("GridColumn by index: " + columnIndex);
                var lineItem = new RolesHomeColumn(gridCssSelector, webElement, columnIndex, ControlPrefix);
                ColumnList.Add(lineItem);
                columnIndex++;
            }
        }

        /// <summary>
        /// Sets the Rows List
        /// </summary>
        public override void SetRowLists()
        {
            base.SetRowLists();
            int rowIndex = 0;
            foreach (var webElement in WebElementRows)
            {
                Report.Write("GridRow by index: " + rowIndex);
                GridRowType rowType = GetGridRowType(rowIndex);
                Report.Write("GridRowType: " + rowType);
                var lineItem = new RolesHomeRow(gridCssSelector, webElement, rowIndex, rowType, ColumnList, ControlPrefix);
                RowList.Add(lineItem);
                rowIndex++;
            }
        }

        /// <summary>
        /// gets the first row containing the text to find from the row list
        /// </summary>
        /// <param name="columnName">the column name</param>
        /// <param name="textToFind">the text to find</param>
        /// <returns>RolesHomeRow</returns>
        public RolesHomeRow GetsFirstRowContainingTextToFindFromList(string columnName, string textToFind)
        {
            List<RolesHomeRow> list = GetsRowsContainingTextToFindFromList(columnName, textToFind);
            if (list.Count == 0)
            {
                Assert.Fail("No items were found in the list containing: '" + textToFind + "'.");
                return null;
            }
            else
            {
                return list[0];
            }
        }

        /// <summary>
        /// gets a list of rows containing the text to find from the row list
        /// </summary>
        /// <param name="columnName">the column name</param>
        /// <param name="textToFind">the text to find</param>
        /// <returns>list of RolesHomeRow</returns>
        public new List<RolesHomeRow> GetsRowsContainingTextToFindFromList(string columnName, string textToFind)
        {
            if (RowList.Count == 0)
            {
                Assert.Fail("No items were found in the grid column list.");
                return null;
            }
            else
            {
                List<RolesHomeRow> rowList = new List<RolesHomeRow>();
                string text = null;
                int index = 0;
                foreach (var row in RowList)
                {
                    RolesHomeRow configRow = (RolesHomeRow)row;
                    if (configRow.Type != GridRowType.Header && configRow.Type != GridRowType.Pagination)
                    {
                        //get the text by column name
                        if (columnName.Equals(RolesHomeColumnnNames.RoleName))
                        {
                            text = configRow.GetRoleName();
                        }
                        if (columnName.Equals(RolesHomeColumnnNames.Description))
                        {
                            text = configRow.GetDescription();
                        }
                        if (columnName.Equals(RolesHomeColumnnNames.OperationTemplates))
                        {
                            text = configRow.GetOperationTemplates();
                        }

                        //if the text is not null
                        if (text != null)
                        {
                            //if the text contains the text to find
                            if (text.Contains(textToFind))
                            {
                                rowList.Add(configRow);
                            }
                        }
                    }
                }
                //may return empty row list if text is not found
                return rowList;
            }
        }
    }
}
