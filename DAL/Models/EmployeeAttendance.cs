using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class EmployeeAttendance
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("EmployeeId")]
        public int employeeId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime attendanceDate { get; set; }

        [Required]
        public bool IsPresent { get; set; }

        [Required]
        public bool IsAbsent { get; set; }

        [Required]
        public bool IsOffday { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
