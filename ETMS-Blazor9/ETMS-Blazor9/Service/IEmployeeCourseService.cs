using System.Collections.Generic;
using System.Threading.Tasks;


namespace ETMS.Data.Service
{
    public interface IEmployeeCourseService
    {

        StatusInfo GetStatus();
        Task<bool> ChangeCompleteStatus(int id);

        Task<List<EmployeeCourseInfo>> GetEmployeeCourses();


        Task<List<EmployeeCourseInfo>> GetEmployeeCourseInfoList();

        Task<List<EmployeeCourseInfo>> GetEmployeeCourseInfoList(List<EmployeeCourse> employeecourses);

        Task<EmployeeCourseInfo> GetEmployeeCourseInfo(int employeecourseID);

        Task<EmployeeCourseInfo> GetEmployeeCourseInfo(EmployeeCourse employeecourse);



        Task<List<CourseInfo>> GetCourseInfoList();

        Task<List<CourseInfo>> GetCourseInfoList(List<Course> courses);

        Task<CourseInfo> GetCourseInfo(int CourseID);

        Task<CourseInfo> GetCourseInfo(Course course);



        Task<List<EmployeeInfo>> GetEmployeeInfoList();

        Task<List<EmployeeInfo>> GetEmployeeInfoList(List<Employee> employees);

        Task<EmployeeInfo> GetEmployeeInfo(int emploayeeID);

        Task<EmployeeInfo> GetEmployeeInfo(Employee employee);



        Task<bool> CreateEmployeeCourse(EmployeeCourse employeecourse);

    }
}
