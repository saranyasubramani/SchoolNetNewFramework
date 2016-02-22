using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITests.Pages.Components;

namespace UITests.Pages.Assess.Dashboard.ViewPortalResults.RecommendedTests
{
    /// <summary>
    /// Class for the View Portal Recommended Test Results Grid Column Names
    /// </summary>
    public class ViewPortalRecommendedTestResultsColumnNames : SNGridColumnNames
    {
        public static string TestCategory = "Test Category";
        public static string Subject = "Subject";
        public static string GradeLevel = "Grade Level";
        public static string StartDate = "Start Date";
        public static string EndDate = "End Date";
        public static string ScoresDueDate = "Scores Due Date";
        public static string AssignmentStatus = "Assignment Status";
    }
}
