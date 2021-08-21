using StaffManager.Data.Entities;
using StaffManager.Infrastructure.Models;

namespace StaffManager.Core.Mappings
{
    /// <summary>
    /// Mappings for deaprtment models.
    /// </summary>
    public static class DepartmentMapping
    {
        /// <summary>
        /// Map entity model to dto.
        /// </summary>
        /// <param name="entity">Entity.</param>
        /// <returns>Dto.</returns>
        public static DepartmentDto ToDto(this Department entity) =>
            new DepartmentDto()
            {
                Id = entity.Id,
                Name = entity.Name
            };

        /// <summary>
        /// Map dto model to entity.
        /// </summary>
        /// <param name="dto">Dto.</param>
        /// <returns>Entity.</returns>
        public static Department ToEntity(this DepartmentDto dto) =>
            new Department()
            {
                Id = dto.Id,
                Name = dto.Name
            };
    }
}