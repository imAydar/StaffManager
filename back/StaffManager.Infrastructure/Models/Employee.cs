using System.Text.Json.Serialization;

namespace StaffManager.Infrastructure.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Salary { get; set; }

        public int DepartmentId { get; set; }

        [JsonIgnore]
        public Data.Entities.Department Department { get; set; }
    }
}