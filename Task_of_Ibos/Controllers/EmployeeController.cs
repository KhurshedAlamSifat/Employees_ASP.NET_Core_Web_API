using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;

namespace Task_of_Ibos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            try
            {
                var data = EmployeeService.GetAll();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var data = EmployeeService.GetById(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //API01# Update an employee’s Employee Name and Code [Don't allow duplicate employee code]
        [HttpPost("UpdateEmployee/{employeeId}")]
        public IActionResult UpdateEmployee(EmployeeDTO employeeId)
        {
            try
            {
                var data = EmployeeService.Update(employeeId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //API02# Get employee who has 3rd highest salary
        [HttpGet("3rdHighestSalary")]
        public IActionResult EmployeeThirdHighestSalary()
        {
            try
            {
                var data = EmployeeService.ThirdHighestSalary();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //API03# Get all employee based on maximum to minimum salary who has not any absent record
        [HttpGet("presentemployeessalary")]
        public IActionResult Get_EmployeesBySalary()
        {
            try
            {
                var data = EmployeeService.GetEmployeesBySalary();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //API04# Get monthly attendance report of all employee
        [HttpGet("monthlyreport/{year}/{month}")]
        public IActionResult GetReport(int year, int month)
        {
            try
            {
                var employees = EmployeeService.GetAll().ToList();
                var attendances = EmployeeService.GetAllAttendance().ToList();
                var report = employees.Select(e => new
                    {
                        e.employeeName,
                        MonthName = new DateTime(year, month, 1).ToString("MMMM"),
                        e.employeeSalary,
                        TotalPresent = attendances.Count(a => a.employeeId == e.employeeId && a.attendanceDate.Year == year && a.attendanceDate.Month == month && a.IsPresent),
                        TotalAbsent = attendances.Count(a => a.employeeId == e.employeeId && a.attendanceDate.Year == year && a.attendanceDate.Month == month && a.IsAbsent),
                        TotalOffday = attendances.Count(a => a.employeeId == e.employeeId && a.attendanceDate.Year == year && a.attendanceDate.Month == month && a.IsOffday)
                    }).ToList();
                return Ok(report);
              
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getemployee/{id}")]
        public IActionResult GetEmployeesBySupervisor(int id)
        {
            try
            {
                var employees = EmployeeService.GetAll().Where(s=>s.supervisorId==id).Select(e=>e.employeeName).Distinct().ToList();
                return Ok(employees);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
