using System.Collections.Generic;
using System.Threading.Tasks;
using StaffManager.Infrastructure.Models;

using StaffManager.Data.Entities;

namespace StaffManager.Infrastructure.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentDto>> GetAllAsync();
        Task<DepartmentDto> CreateAsync(DepartmentDto departmentDto);
        Task<DepartmentDto> DeleteAsync(DepartmentDto departmentDto);
        Task<DepartmentDto> UpdateAsync(DepartmentDto departmentDto);
    }
}