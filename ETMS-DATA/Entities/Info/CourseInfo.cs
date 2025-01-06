using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ETMS.Data
{
    public class CourseInfo:Course
    {

        public List<EmployeeCourse> EmployeeCourseList { get; set; }

        public List<Employee> EmployeeList { get; set; }

        public int TotalCoursesAssined
        {
            get
            {
                return EmployeeCourseList.Count;
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
        public int TotalCoursesCompleted
        {
            get
            {
                return EmployeeCourseList.Where(e => e.isComplete == true).ToList().Count;
            }
        }


        public bool isAllEmployeeCompleted
        {
            get
            {
                return (TotalCoursesAssined > 0) && (TotalCoursesAssined == TotalCoursesCompleted);
            }
        }

        public bool isAllEmployeePending
        {
            get
            {
                return (TotalCoursesAssined > 0) && (TotalCoursesCompleted == 0);
            }
        }

    }
}
