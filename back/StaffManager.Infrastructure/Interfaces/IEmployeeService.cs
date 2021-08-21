//using StaffManager.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using StaffManager.Infrastructure.Models;

namespace StaffManager.Core.Services
{
    public interface IEmployeeService
    {
        /// <summary>
        /// Get all employees working in department.
        /// </summary>
        /// <param name="departmentId">Id of the deaprtment</param>
        /// <returns>Collection of employees.</returns>
        Task<IEnumerable<EmployeeDto>> GetByDepartmentId(int departmentId);

        /// <summary>
        /// Create Employee.
        /// </summary>
        /// <param name="EmployeeDto">EmployeeDto to create.</param>
        Task<EmployeeDto> CreateAsync(EmployeeDto employeeDto);

        /// <summary>
        /// Update Employee.
        /// </summary>
        /// <param name="EmployeeDto">EmployeeDto to create.</param>
        Task<EmployeeDto> DeleteAsync(EmployeeDto employeeDto);

        /// <summary>
        /// Delete Employee.
        /// </summary>
        /// <param name="EmployeeDto">EmployeeDto to create.</param>
        Task<EmployeeDto> UpdateAsync(EmployeeDto employeeDto);
    }
}