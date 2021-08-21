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
        /// <summary>
        /// Department repo.
        /// </summary>
        private readonly IDepartmentRepository departmentRepository;

        /// <summary>
        /// Employee repo.
        /// </summary>
        private readonly IEmployeeRepository employeeRepository;

        public DepartmentService(IDepartmentRepository departmentRepository, IEmployeeRepository employeeRepository)
        {
            this.departmentRepository = departmentRepository;
            this.employeeRepository = employeeRepository;
        }

        ///<inheritdoc/>
        public async IAsyncEnumerable<DepartmentDto> GetAllAsync()
        {
            var departments = (await departmentRepository.GetAllAsync())
                .Select(x => x.ToDto());

            foreach (var department in departments)
            {
                var employees = await employeeRepository.GetAsync(x => x.DepartmentId == department.Id);

                department.Salary = employees.Sum(x => x.Salary) / employees.Count();
                department.EmployeesCount = employees.Count();
                yield return department;
            }
        }

        ///<inheritdoc/>
        public async Task<DepartmentDto> UpdateAsync(DepartmentDto department) =>
            (await departmentRepository.UpdateAsync(department.ToEntity())).ToDto();


        ///<inheritdoc/>
        public async Task<DepartmentDto> CreateAsync(DepartmentDto department) =>
            (await departmentRepository.CreateAsync(department.ToEntity())).ToDto();


        ///<inheritdoc/>
        public async Task<DepartmentDto> DeleteAsync(DepartmentDto department) =>
            (await departmentRepository.DeleteAsync(department.ToEntity())).ToDto();
    }
}