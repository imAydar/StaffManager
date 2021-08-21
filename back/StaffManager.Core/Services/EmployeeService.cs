using StaffManager.Data.Entities;
using StaffManager.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StaffManager.Core.Mappings;
using StaffManager.Infrastructure.Models;

namespace StaffManager.Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        /// <summary>
        /// Employee repo.
        /// </summary>
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        /// <summary>
        /// Get all employees working in department.
        /// </summary>
        /// <param name="departmentId">Id of the deaprtment</param>
        /// <returns>Collection of employees.</returns>
        public async Task<IEnumerable<EmployeeDto>> GetByDepartmentId(int departmentId) =>
            (await employeeRepository.AsQueryable()
                .Where(x => x.DepartmentId == departmentId).ToListAsync())
            .Select(x => x.ToDto());

        /// <summary>
        /// Create Employee.
        /// </summary>
        /// <param name="EmployeeDto">EmployeeDto to create.</param>
        public async Task<EmployeeDto> UpdateAsync(EmployeeDto employee) =>
            (await employeeRepository.UpdateAsync(employee.ToEntity())).ToDto();

        /// <summary>
        /// Update Employee.
        /// </summary>
        /// <param name="EmployeeDto">EmployeeDto to create.</param>
        public async Task<EmployeeDto> CreateAsync(EmployeeDto employee) =>
            (await employeeRepository.CreateAsync(employee.ToEntity())).ToDto();

        /// <summary>
        /// Delete Employee.
        /// </summary>
        /// <param name="EmployeeDto">EmployeeDto to create.</param>
        public async Task<EmployeeDto> DeleteAsync(EmployeeDto employee) =>
            (await employeeRepository.DeleteAsync(employee.ToEntity())).ToDto();
    }
}