using AutoMapper;
using BLL.DTOs;
using DAL.Model;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class EmployeeAttendanceService
    {
        public static List<EmployeeAttendanceDTO> GetAll()
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

        public static EmployeeAttendanceDTO GetById(int id)
        {
            var data = DataAccessFactory.EmployeeAttendanceData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<EmployeeAttendance, EmployeeAttendanceDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<EmployeeAttendanceDTO>(data);
            return mapped;
        }

        public static EmployeeAttendanceDTO Insert(EmployeeAttendanceDTO employeeAttendance)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<EmployeeAttendanceDTO, EmployeeAttendance>();
            });
            var mapper = new Mapper(cfg);
            var employeeAttendances = mapper.Map<EmployeeAttendance>(employeeAttendance);
            DataAccessFactory.EmployeeAttendanceData().Create(employeeAttendances);
            return employeeAttendance;
        }

        public static EmployeeAttendanceDTO Update(EmployeeAttendanceDTO employeeAttendance)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<EmployeeAttendanceDTO, EmployeeAttendance>();
            });
            var mapper = new Mapper(cfg);
            var employeeAttendances = mapper.Map<EmployeeAttendance>(employeeAttendance);
            DataAccessFactory.EmployeeAttendanceData().Update(employeeAttendances);
            return employeeAttendance;
        }

        public static bool Delete(int id)
        {
            var data = DataAccessFactory.EmployeeAttendanceData().Delete(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<EmployeeAttendance, EmployeeAttendanceDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<bool>(data);
            return mapped;
        }
    }
}
