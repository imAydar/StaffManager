using StaffManager.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StaffManager.Core.Services
{
    public interface IEmployeeService
    {
        Task<Employee> CreateAsync(Employee employee);
        Task<Employee> DeleteAsync(Employee employee);
        Task<IEnumerable<Employee>> GetByDepartmentId(int departmentId);
        Task<Employee> UpdateAsync(Employee employee);
    }
}