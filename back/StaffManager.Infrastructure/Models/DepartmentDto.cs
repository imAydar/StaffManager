using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StaffManager.Infrastructure.Models
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public decimal Salary { get; set; }
        
        public int EmployeesCount { get; set; }

        [JsonIgnore]
        public virtual ICollection<EmployeeDto> Employees { get; set; }
    }
}