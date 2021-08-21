using System.Collections.Generic;
using System.Threading.Tasks;
using StaffManager.Infrastructure.Models;

//using StaffManager.Data.Entities;

namespace StaffManager.Infrastructure.Interfaces
{
    public interface IDepartmentService
    {
        Task<Department> CreateAsync(Department department);
        Task<Department> DeleteAsync(Department department);
        Task<IEnumerable<Department>> GetAllAsync();
        Task<Department> UpdateAsync(Department department);
    }
}