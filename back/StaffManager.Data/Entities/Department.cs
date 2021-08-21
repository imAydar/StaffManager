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

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
