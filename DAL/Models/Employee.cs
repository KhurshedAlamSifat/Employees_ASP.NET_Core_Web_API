using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    [Index(nameof(Employee.employeeCode), IsUnique = true)]
    public class Employee
    {
        [Key]
        public int employeeId { get; set; }

        [Required]
        [MaxLength(50)]
        public string employeeName { get; set; }

        [Required]
        [MaxLength(10)]
        public string employeeCode { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive value.")]
        public decimal employeeSalary { get; set; }

        public int? supervisorId { get; set; }

        public virtual ICollection<EmployeeAttendance> EmployeeAttendances { get; set; }

        public Employee()
        {
            EmployeeAttendances = new List<EmployeeAttendance>();
        }
    }
}
