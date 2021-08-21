using StaffManager.Data.Entities;
using StaffManager.Infrastructure.Models;

namespace StaffManager.Core.Mappings
{
    /// <summary>
    /// Mappings for employee models.
    /// </summary>
    public static class EmployeeMapping
    {
        /// <summary>
        /// Map entity model to dto.
        /// </summary>
        /// <param name="entity">Entity.</param>
        /// <returns>Dto.</returns>
        public static EmployeeDto ToDto(this Employee entity) =>
            new EmployeeDto()
            {
                Id = entity.Id,
                Name = entity.Name,
                DepartmentId = entity.DepartmentId,
                Salary = entity.Salary
            };

        /// <summary>
        /// Map dto model to entity.
        /// </summary>
        /// <param name="dto">Dto.</param>
        /// <returns>Entity.</returns>
        public static Employee ToEntity(this EmployeeDto dto) =>
            new Employee()
            {
                Id = dto.Id,
                Name = dto.Name,
                Department = dto.Department,
                DepartmentId = dto.DepartmentId,
                Salary = dto.Salary
            };
    }
}