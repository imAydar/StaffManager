using StaffManager.Data.Entities;
using StaffManager.Infrastructure.Models;

namespace StaffManager.Core.Mappings
{
    public static class EmployeeMapping
    {
        public static EmployeeDto ToDto(this Employee entity) =>
            new EmployeeDto()
            {
                Id = entity.Id,
                Name = entity.Name
            };

        public static Employee ToEntity(this EmployeeDto dto) =>
            new Employee()
            {
                Id = dto.Id,
                Name = dto.Name
            };
    }
}