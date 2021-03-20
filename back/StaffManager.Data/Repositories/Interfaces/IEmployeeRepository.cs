using StaffManager.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StaffManager.Data.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee> CreateAsync(Employee employee);
        Task<Employee> DeleteAsync(Employee employee);
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee> GetByIdAsync(int id);
        Task<Employee> UpdateAsync(Employee employee);
    }
}