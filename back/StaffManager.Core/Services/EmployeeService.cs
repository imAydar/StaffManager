using StaffManager.Data.Entities;
using StaffManager.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManager.Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        public async Task<IEnumerable<Employee>> GetByDepartmentId(int departmentId)
        {
            var result = (await employeeRepository.GetAllAsync())
                .Where(x => x.DepartmentId == departmentId);
            return result;
        }
        public async Task<Employee> UpdateAsync(Employee employee)
        {
            return await employeeRepository.UpdateAsync(employee);
        }

        public async Task<Employee> CreateAsync(Employee employee)
        {
            return await employeeRepository.CreateAsync(employee);
        }

        public async Task<Employee> DeleteAsync(Employee employee)
        {
            return await employeeRepository.DeleteAsync(employee);
        }
    }
}
