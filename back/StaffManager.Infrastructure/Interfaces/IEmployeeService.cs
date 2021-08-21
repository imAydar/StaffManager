//using StaffManager.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using StaffManager.Infrastructure.Models;

namespace StaffManager.Core.Services
{
    public interface IEmployeeService
    {
        Task<EmployeeDto> CreateAsync(EmployeeDto employeeDto);
        Task<EmployeeDto> DeleteAsync(EmployeeDto employeeDto);
        Task<IEnumerable<EmployeeDto>> GetByDepartmentId(int departmentId);
        Task<EmployeeDto> UpdateAsync(EmployeeDto employeeDto);
    }
}