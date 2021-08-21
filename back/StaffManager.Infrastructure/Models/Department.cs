using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StaffManager.Infrastructure.Models
{
    public class Department
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public virtual decimal Salary { get; set; }
        
        public virtual int EmployeesCount { get; set; }

        [JsonIgnore]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}