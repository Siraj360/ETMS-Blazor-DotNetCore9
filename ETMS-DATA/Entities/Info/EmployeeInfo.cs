using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace ETMS.Data
{
    public class EmployeeInfo : Employee
    {



        public List<EmployeeCourse> EmployeeCourseList { get; set; }

        public List<Course> CourseList { get; set; }

        public int TotalCoursesAssined
        {
            get
            {
                return EmployeeCourseList.Count;
            }
        }

        public bool isAllCourseCompleted
        {
            get
            {
                return (TotalCoursesAssined >0) && (TotalCoursesAssined == TotalCoursesCompleted);
            }
        }

        public bool isAllCoursePending
        {
            get
            {
                return (TotalCoursesAssined > 0) && ( TotalCoursesCompleted ==0);
            }
        }

        public int TotalCoursesCompleted
        {
            get
            {
                return EmployeeCourseList.Where(e => e.isComplete == true).ToList().Count;
            }
        }




        public string PercentCourcesCompleted
        {
            get
            {
                String perStr = string.Empty;

                if (TotalCoursesCompleted > 0 && TotalCoursesAssined > 0)
                {
                    double per = TotalCoursesCompleted * 100 / TotalCoursesAssined;

                    perStr = (per / 100).ToString("p");
                }


                return perStr;
            }
        }

        public string cssStyle
        {
            get
            {
                string cssStyle = "";
                if (TotalCoursesCompleted == 0)
                {
                    cssStyle = "danger";
                }
                if (TotalCoursesAssined == TotalCoursesCompleted)
                {
                    cssStyle = "success";
                }
                if (TotalCoursesCompleted > 0 && TotalCoursesCompleted < TotalCoursesAssined)
                {
                    cssStyle = "warning";
                }

                return cssStyle;
            }
        }

    }
}
