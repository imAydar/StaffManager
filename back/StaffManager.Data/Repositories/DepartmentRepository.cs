using Microsoft.EntityFrameworkCore;
using StaffManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManager.Data.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDBContext context;

        public DepartmentRepository(ApplicationDBContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Department>> GetAllAsync() =>
         await context.Set<Department>().ToListAsync();

        public async Task<Department> GetByIdAsync(int id) =>
            await context.Set<Department>().FindAsync(id);

        public async Task<Department> CreateAsync(Department department)
        {
            await context.Set<Department>().AddAsync(department);
            await context.SaveChangesAsync();
            return department;
        }

        public async Task<Department> UpdateAsync(Department department)
        {
            context.Entry(department).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return department;
        }

        public async Task<Department> DeleteAsync(Department department)
        {
            context.Set<Department>().Remove(department);
            await context.SaveChangesAsync();
            return department;
        }
    }
}
