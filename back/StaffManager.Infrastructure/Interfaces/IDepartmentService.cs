using System.Collections.Generic;
using System.Threading.Tasks;
using StaffManager.Infrastructure.Models;

using StaffManager.Data.Entities;

namespace StaffManager.Infrastructure.Interfaces
{
    public interface IDepartmentService
    {
        /// <summary>
        /// Get all the departments.
        /// </summary>
        /// <returns>Collection of DepartmentDto.</returns>
        IAsyncEnumerable<DepartmentDto> GetAllAsync();

        /// <summary>
        /// Create Department.
        /// </summary>
        /// <param name="DepartmentDto">DepartmentDto to create.</param>
        /// <returns>Created DepartmentDto.</returns>
        Task<DepartmentDto> CreateAsync(DepartmentDto departmentDto);

        /// <summary>
        /// Update Department.
        /// </summary>
        /// <param name="DepartmentDto">DepartmentDto to update.</param>
        /// <returns>Updated DepartmentDto.</returns>
        Task<DepartmentDto> DeleteAsync(DepartmentDto departmentDto);

        /// <summary>
        /// Delete Department.
        /// </summary>
        /// <param name="DepartmentDto">DepartmentDto to delete.</param>
        /// <returns>Deleted DepartmentDto.</returns>
        Task<DepartmentDto> UpdateAsync(DepartmentDto departmentDto);
    }
}