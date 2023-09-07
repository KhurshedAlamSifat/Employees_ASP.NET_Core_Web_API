using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> Employees { get; set;}
        public DbSet<EmployeeAttendance> EmployeesAttendances { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=ASUS-SIFAT;Initial Catalog=Ibos;Integrated Security=True;Persist Security Info=False;Trust Server Certificate=True");
            }
        }
    }
}
