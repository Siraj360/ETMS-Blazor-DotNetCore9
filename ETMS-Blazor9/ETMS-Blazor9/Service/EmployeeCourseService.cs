using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ETMS.Data.Service;
using ETMS.Data;
using System.Linq;
using System.Runtime.InteropServices;


namespace ETMS.Data.Service
{
    public class EmployeeCourseService : IEmployeeCourseService
    {

        private readonly ETMSContext _dbContext;
        private StatusInfo _status = new StatusInfo();
        private List<Employee> _employeeList;
        private List<Course> _courseList;
        private List<EmployeeCourse> _employeeCourseList;
        private List<EmployeeCourseInfo> _employeeCourseInfoList;

        public EmployeeCourseService(ETMSContext dbContext)
        {
            _dbContext = dbContext;
        }


        public StatusInfo GetStatus()
        {
            return _status;
        }

        //_status.EmployeeAllComplterd = _employeeAllCompleted/4;
        //    _status.EmployeeAllNotStarted = _employeeAllPending/4;
        //    _status.TotalCourses = _courseList.Count;
        //    _status.TotalEmployees = _employeeList.Count;
        //    _status.TotalEmployeeCourses = _employeeCourseList.Count;
        //    _status.EmployeeCoursesComplted = employeeCourseListCompleted.Count;

        public async Task<List<CourseInfo>> GetCourseInfoList()
        {
            List<Course> courses = await _dbContext.Course.ToListAsync();

            List<CourseInfo> courseInfoList = new List<CourseInfo>();

            courseInfoList = await GetCourseInfoList(courses);

            return courseInfoList;
        }

        public async Task<List<CourseInfo>> GetCourseInfoList(List<Course> courses)
        {
            List<CourseInfo> courseInfoList = new List<CourseInfo>();

            foreach (Course course in courses)
            {
                CourseInfo courseInfo = await GetCourseInfo(course);

                courseInfoList.Add(courseInfo);
            }

            return courseInfoList;
        }

        public async Task<CourseInfo> GetCourseInfo(int courseID)
        {

            CourseInfo courseInfo = new CourseInfo();

            Course course = new Course();

            if (courseID > 0)
            {

                courseInfo = courseInfo as CourseInfo;

                course = await _dbContext.Course.FindAsync(courseID);

                courseInfo = await GetCourseInfo(course);
            }


            return courseInfo;

        }

        public async Task<CourseInfo> GetCourseInfo(Course course)
        {
            CourseInfo courseInfo = new CourseInfo();

            courseInfo.CourseID = course.CourseID;
            courseInfo.RowId = course.RowId;
            courseInfo.Name = course.Name;
            courseInfo.Description = course.Description;
            courseInfo.Code = course.Code;
        
           
            List<EmployeeCourse> employeeCourseList = new List<EmployeeCourse>();
            List<Employee> employeeList = new List<Employee>();
            Employee employee = new Employee();

            employeeCourseList = await _dbContext.EmployeeCourse.Where(e => e.CourseID == course.CourseID).ToListAsync();

            foreach (var ec in employeeCourseList)
            {
                employee = await _dbContext.Employee.FirstAsync(e => e.EmployeeID == ec.EmployeeID);
                employeeList.Add(employee);
            }

            courseInfo.EmployeeList = employeeList;
            courseInfo.EmployeeCourseList = employeeCourseList;

            return courseInfo;
        }


        public async Task<List<EmployeeInfo>> GetEmployeeInfoList()
        {
            List<Employee> employees = await _dbContext.Employee.ToListAsync();

            List<EmployeeInfo> employeeInfoList = new List<EmployeeInfo>();

            employeeInfoList = await GetEmployeeInfoList(employees);

            return employeeInfoList;
        }

        public async Task<List<EmployeeInfo>> GetEmployeeInfoList(List<Employee> employees)
        {
            List<EmployeeInfo> employeeInfoList = new List<EmployeeInfo>();

            foreach (Employee employee in employees)
            {
                EmployeeInfo employeeInfo = await GetEmployeeInfo(employee);

                employeeInfoList.Add(employeeInfo);
            }

            return employeeInfoList;
        }

        public async Task<EmployeeInfo> GetEmployeeInfo(int emploayeeID)
        { 
            
            EmployeeInfo employeeInfo = new EmployeeInfo();

            Employee employee = new Employee();

            if (emploayeeID > 0)
            {
                employee =  await _dbContext.Employee.FindAsync(emploayeeID);

                employeeInfo = await GetEmployeeInfo(employee);
            }


            return employeeInfo;

        }

        public async Task<EmployeeInfo> GetEmployeeInfo(Employee employee)
        {
            EmployeeInfo employeeInfo = new EmployeeInfo();

            employeeInfo.EmployeeID =  employee.EmployeeID;
            employeeInfo.RowId = employee.RowId;
            employeeInfo.Name = employee.Name;
            employeeInfo.HireDate = employee.HireDate;

            List<EmployeeCourse> employeeCourseList = new List<EmployeeCourse>();
            List<Course> courseList = new List<Course>();
            Course course = new Course();
          
            employeeCourseList = await _dbContext.EmployeeCourse.Where(e => e.EmployeeID == employee.EmployeeID).ToListAsync();

            foreach (var ec in employeeCourseList)
            {
                course = await _dbContext.Course.FirstAsync(e=> e.CourseID == ec.CourseID);
                courseList.Add(course);
            }

            employeeInfo.CourseList = courseList;
            employeeInfo.EmployeeCourseList = employeeCourseList;

      

            return employeeInfo;
        }




        public async Task<List<EmployeeCourseInfo>> GetEmployeeCourseInfoList()
        {
            List<EmployeeCourse> employeecources = await _dbContext.EmployeeCourse.ToListAsync();

            List<EmployeeCourseInfo> employeeCourseInfoList = new List<EmployeeCourseInfo>();

            employeeCourseInfoList = await GetEmployeeCourseInfoList(employeecources);

            return employeeCourseInfoList;
        }

        public async Task<List<EmployeeCourseInfo>> GetEmployeeCourseInfoList(List<EmployeeCourse> employeecources)
        {
            List<EmployeeCourseInfo> employeeCourseInfoList = new List<EmployeeCourseInfo>();

            foreach (EmployeeCourse employeecource in employeecources)
            {
                EmployeeCourseInfo employeeCourseInfo = await GetEmployeeCourseInfo(employeecource);

                employeeCourseInfoList.Add(employeeCourseInfo);
            }

            _employeeCourseInfoList = employeeCourseInfoList;

            return employeeCourseInfoList;
        }

        public async Task<EmployeeCourseInfo> GetEmployeeCourseInfo(int employeecourceID)
        {

            EmployeeCourseInfo employeeCourseInfo = new EmployeeCourseInfo();

            EmployeeCourse employeecource = new EmployeeCourse();

            if (employeecourceID > 0)
            {
                employeecource = await _dbContext.EmployeeCourse.FindAsync(employeecourceID);

                employeeCourseInfo = await GetEmployeeCourseInfo(employeecource);
            }


            return employeeCourseInfo;

        }

        public async Task<EmployeeCourseInfo> GetEmployeeCourseInfo(EmployeeCourse employeecourse)
        {
            EmployeeCourseInfo employeeCourseInfo = new EmployeeCourseInfo();

    
            employeeCourseInfo.CourseID = employeecourse.CourseID;
            employeeCourseInfo.EmployeeID = employeecourse.EmployeeID;
            employeeCourseInfo.EmployeeCourseID = employeecourse.EmployeeCourseID;
            employeeCourseInfo.isComplete = employeecourse.isComplete;
            employeeCourseInfo.CompletedOn = employeecourse.CompletedOn;
            employeeCourseInfo.AssignedOn = employeecourse.AssignedOn;
            employeeCourseInfo.UpdatedOn = employeecourse.UpdatedOn;

            employeeCourseInfo.EmployeeInfo = await GetEmployeeInfo(employeecourse.EmployeeID);

            employeeCourseInfo.CourseInfo = await GetCourseInfo(employeecourse.CourseID);


            return employeeCourseInfo;
        }











        public async Task<List<EmployeeCourseInfo>> GetEmployeeCourses()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ChangeCompleteStatus(int id)
        {
            var employeeCourse = await _dbContext.EmployeeCourse.FindAsync(id);
            if (employeeCourse == null)
            {
                return false;
            }

            employeeCourse.UpdatedOn = DateTime.Now;
            employeeCourse.isComplete = !employeeCourse.isComplete;
            if (employeeCourse.isComplete)
            {
                employeeCourse.CompletedOn = DateTime.Now;
            }
            //else
            //{
            //    employeeCourse.CompletedOn = null;
            //}

            _dbContext.Entry(employeeCourse).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return true;
        }


        public async Task<bool> CreateEmployeeCource(EmployeeCourse employeecource)
        {
           // employeecource.RowId = Guid.NewGuid().ToString();
            _dbContext.Add(employeecource);
            try
            {
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }

        }

        public Task<bool> CreateEmployeeCourse(EmployeeCourse employeecourse)
        {
            throw new NotImplementedException();
        }

        
    }
}
