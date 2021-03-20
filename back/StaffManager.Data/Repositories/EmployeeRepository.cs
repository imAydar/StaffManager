using Microsoft.EntityFrameworkCore;
using StaffManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManager.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDBContext context;

        public EmployeeRepository(ApplicationDBContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Employee>> GetAllAsync() =>
         await context.Set<Employee>().ToListAsync();

        public async Task<Employee> GetByIdAsync(int id) =>
            await context.Set<Employee>().FindAsync(id);

        public async Task<Employee> CreateAsync(Employee employee)
        {
            await context.Set<Employee>().AddAsync(employee);
            await context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> UpdateAsync(Employee employee)
        {
            context.Entry(employee).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> DeleteAsync(Employee employee)
        {
            context.Set<Employee>().Remove(employee);
            await context.SaveChangesAsync();
            return employee;
        }
    }
}
