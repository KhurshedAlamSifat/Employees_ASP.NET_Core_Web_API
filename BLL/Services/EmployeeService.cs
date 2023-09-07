using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class EmployeeService
    {
        public static List<EmployeeDTO> GetAll()
        {
            var data = DataAccessFactory.EmployeeData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Employee, EmployeeDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<EmployeeDTO>>(data);   
            return mapped;
        }

        public static EmployeeDTO GetById(int id)
        {
            var data = DataAccessFactory.EmployeeData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Employee, EmployeeDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<EmployeeDTO>(data);
            return mapped;
        }

        public static EmployeeDTO Insert(EmployeeDTO employee)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<EmployeeDTO, Employee>();
            });
            var mapper = new Mapper(cfg);
            var employees = mapper.Map<Employee>(employee);
            DataAccessFactory.EmployeeData().Create(employees);
            return employee;
        }

        public static EmployeeDTO Update(EmployeeDTO employee)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<EmployeeDTO, Employee>();
            });
            var mapper = new Mapper(cfg);
            var employees = mapper.Map<Employee>(employee);
            DataAccessFactory.EmployeeData().Update(employees);
            return employee;
        }

        public static EmployeeDTO ThirdHighestSalary()
        {
            var thirdHighestEmployee = GetAll()
                .OrderByDescending(e => e.employeeSalary)
                .Skip(2) 
                .FirstOrDefault();

            if (thirdHighestEmployee == null)
            {
                return null;
            }
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Employee, EmployeeDTO>();
            });
            var mapper = new Mapper(cfg);
            var employeeDto = mapper.Map<EmployeeDTO>(thirdHighestEmployee);

            return employeeDto;
        }

        public static bool Delete(int id)
        {
            var data = DataAccessFactory.EmployeeData().Delete(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Employee, EmployeeDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<bool>(data);
            return mapped;
        }

        public static List<EmployeeAttendanceDTO> GetAllAttendance()
        {
            var data = DataAccessFactory.EmployeeAttendanceData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<EmployeeAttendance, EmployeeAttendanceDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<EmployeeAttendanceDTO>>(data);
            return mapped;

        }
        public static List<EmployeeDTO> GetEmployeesBySalary()
        {
            var presentemployees = GetAllAttendance().Where(e => e.IsPresent == true)
                .Select(a => a.employeeId).Distinct().ToList();
            var maxToMinSalaryEmployees = GetAll()
                .Where(e => presentemployees.Contains(e.employeeId))
                .OrderByDescending(e => e.employeeSalary)
                .ToList();
            return maxToMinSalaryEmployees;
        }
    }
}
