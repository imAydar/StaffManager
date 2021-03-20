using StaffManager.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StaffManager.Data.Repositories
{
    public interface IDepartmentRepository
    {
        Task<Department> CreateAsync(Department department);
        Task<Department> DeleteAsync(Department department);
        Task<IEnumerable<Department>> GetAllAsync();
        Task<Department> GetByIdAsync(int id);
        Task<Department> UpdateAsync(Department department);
    }
}