﻿using StaffManager.Data.Entities;
using StaffManager.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            var result = await departmentRepository.GetAllAsync();
            var employees = await employeeRepository.GetAllAsync();
            foreach (var department in result)
            {
                department.EmployeesCount = employees.Where(x => x.DepartmentId == department.Id).Count();
                if (department.EmployeesCount == 0)
                    continue;
                decimal salarySumm = employees.Where(x => x.DepartmentId == department.Id).Sum(x => x.Salary);
                decimal averageSalary = salarySumm / department.EmployeesCount;
                department.Salary = averageSalary;
            }
            return result;
        }
        public async Task<Department> UpdateAsync(Department department)
        {
            return await departmentRepository.UpdateAsync(department);
        }

        public async Task<Department> CreateAsync(Department department)
        {
            return await departmentRepository.CreateAsync(department);
        }

        public async Task<Department> DeleteAsync(Department department)
        {
            return await departmentRepository.DeleteAsync(department);
        }
    }
}