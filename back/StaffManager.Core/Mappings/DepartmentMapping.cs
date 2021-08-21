using StaffManager.Data.Entities;
using StaffManager.Infrastructure.Models;

namespace StaffManager.Core.Mappings
{
    public static class DepartmentMapping
    {
        public static DepartmentDto ToDto(this Department entity) =>
            new DepartmentDto()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        
        public static Department ToEntity(this DepartmentDto dto) =>
            new Department()
            {
                Id = dto.Id,
                Name = dto.Name
            };
    }
}