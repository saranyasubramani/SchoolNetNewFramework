using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITests.Pages.Assess.Schedule.ViewAssignmentSummary
{
    /// <summary>
    /// View Assignment Summary type
    /// </summary>
    public class ViewAssignmentSummaryType
    {
        //The row in which the grid locator is located would change depending on which 
        //page that user was previously on. If user come from EditAssignmentCourse.aspx page, it is
        //3rd row to grab the grid. If user come from EditAssignmentSchool.aspx page, it is the 
        //4th row to grab the grid. 

        public static string AssignToStudents = "3";
        public static string RecommendToTeachers = "3";
        public static string RecommendToSchools = "4";
    }
}
