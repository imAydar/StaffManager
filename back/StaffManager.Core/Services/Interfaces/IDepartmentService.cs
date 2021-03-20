using StaffManager.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StaffManager.Core.Services
{
    public interface IDepartmentService
    {
        Task<Department> CreateAsync(Department department);
        Task<Department> DeleteAsync(Department department);
        Task<IEnumerable<Department>> GetAllAsync();
        Task<Department> UpdateAsync(Department department);
    }
}