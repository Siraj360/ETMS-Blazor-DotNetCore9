using System;
using System.Collections.Generic;
using System.Text;

namespace ETMS.Data
{
    public class EmployeeCourseInfo : EmployeeCourse
    { 
        public EmployeeInfo EmployeeInfo { get; set; }
        
        public CourseInfo CourseInfo { get; set; }

        public int TotalEmployeeNotStarted
        {
            get
            {
                return EmployeeInfo.TotalCoursesAssined - EmployeeInfo.TotalCoursesCompleted;
            }
        }

        public int TotalEmployeeCompleted
        {
            get
            {
                return EmployeeInfo.TotalCoursesCompleted;
            }
        }


        public string PercentEmployeCompleted
        {
            get
            {


                String perStr = string.Empty;
                double total = TotalEmployeeCompleted + TotalEmployeeNotStarted;

                if (total > 0 && TotalEmployeeCompleted > 0)
                {

                    double per = TotalEmployeeCompleted * 100 / total;

                    perStr = (per / 100).ToString("p");
                }


                return perStr;
            }
        }


        public int TotalCourseNotStarted
        {
            get
            {
                return CourseInfo.TotalCoursesAssined - CourseInfo.TotalCoursesCompleted;
            }
        }

        public int TotalCourseCompleted
        {
            get
            {
                return CourseInfo.TotalCoursesCompleted;
            }
        }


        public string PercentCourcesCompleted
        {
            get
            {
                String perStr = string.Empty;
                double total = TotalCourseCompleted + TotalCourseNotStarted;

                if (total > 0 && TotalCourseCompleted > 0)
                {
                    total = TotalCourseCompleted + TotalCourseNotStarted;
                    double per = TotalCourseCompleted * 100 / total;

                    perStr = (per / 100).ToString("p");
                }


                return perStr;
            }
        }



        public string cellCSS
        {
            get
            {
                string cellCSS = "";
                if(TotalEmployeeCompleted == 0)
                {
                    cellCSS = "table-danger";
                }
                if (TotalEmployeeNotStarted == 0)
                {
                    cellCSS = "table-success";
                }
                if (TotalEmployeeNotStarted == 0 && TotalEmployeeCompleted == 0)
                {
                    cellCSS = "table-secondry";
                }

                return cellCSS;
            }
        }




    }
}
