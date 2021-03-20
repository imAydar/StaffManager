using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StaffManager.Data.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [NotMapped]
        public virtual decimal Salary { get; set; }

        [NotMapped]
        public virtual int EmployeesCount { get; set; }

        [JsonIgnore]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
