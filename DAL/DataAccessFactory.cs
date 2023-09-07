using DAL.Interface;
using DAL.Model;
using DAL.Repository;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Employee, int, Employee> EmployeeData()
        {
            return new EmployeeRepo();
        }
        public static IRepo<EmployeeAttendance, int, EmployeeAttendance> EmployeeAttendanceData()
        {
            return new EmployeeAttendanceRepo();
        }
    }
}