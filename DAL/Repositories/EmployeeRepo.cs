using DAL.Interface;
using DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    internal class EmployeeRepo : Repo, IRepo<Employee, int, Employee>
    {
        public Employee Create(Employee obj)
        {
            db.Employees.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            else return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Employees.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Employee> Read()
        {
            return db.Employees.ToList();
        }

        public Employee Read(int id)
        {
            return db.Employees.Find(id);
        }

        public Employee Update(Employee obj)
        {
            var ex = Read(obj.employeeId);
            /*var isEmployeeCodeUnique = db.Employees.AnyAsync(e =>
            e.employeeCode==obj.employeeCode && e.employeeId == obj.employeeId
            );
            ex.employeeName=obj.employeeName;
            ex.employeeCode = obj.employeeCode;*/
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            else return null;
        }
    }
}
