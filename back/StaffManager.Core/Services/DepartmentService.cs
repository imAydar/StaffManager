using StaffManager.Data.Entities;
using StaffManager.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StaffManager.Core.Mappings;
using StaffManager.Infrastructure.Interfaces;
using StaffManager.Infrastructure.Models;

namespace StaffManager.Core.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository departmentRepository;
        private readonly IEmployeeRepository employeeRepository;

        public DepartmentService(IDepartmentRepository departmentRepository, IEmployeeRepository employeeRepository)
        {
            this.departmentRepository = departmentRepository;
            this.employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<DepartmentDto>> GetAllAsync()
        {
            var result = new List<DepartmentDto>();
            var departments =  (await departmentRepository.GetAllAsync())
                .Select(x => x.ToDto());
            var employeesQuery = employeeRepository.AsQueryable();

            foreach (var department in departments)
            {
                var employees = await employeesQuery.Where(x => x.DepartmentId == department.Id)
                    .ToListAsync();

                department.Salary = employees.Sum(x => x.Salary) / employees.Count;
                department.EmployeesCount = employees.Count;
                result.Add(department);
            }

            return result;
        }

        public async Task<DepartmentDto> UpdateAsync(DepartmentDto department) =>
            (await departmentRepository.UpdateAsync(department.ToEntity())).ToDto();

        public async Task<DepartmentDto> CreateAsync(DepartmentDto department) =>
            (await departmentRepository.CreateAsync(department.ToEntity())).ToDto();

        public async Task<DepartmentDto> DeleteAsync(DepartmentDto department) =>
            (await departmentRepository.DeleteAsync(department.ToEntity())).ToDto();
    }
}