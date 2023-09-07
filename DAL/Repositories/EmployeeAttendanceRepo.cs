using DAL.Interface;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    internal class EmployeeAttendanceRepo : Repo, IRepo<EmployeeAttendance, int, EmployeeAttendance>
    {
        public EmployeeAttendance Create(EmployeeAttendance obj)
        {
            db.EmployeesAttendances.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            else return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.EmployeesAttendances.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<EmployeeAttendance> Read()
        {
            return db.EmployeesAttendances.ToList();
        }

        public EmployeeAttendance Read(int id)
        {
            return db.EmployeesAttendances.Find(id);
        }

        public EmployeeAttendance Update(EmployeeAttendance obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            else return null;
        }
    }
}
