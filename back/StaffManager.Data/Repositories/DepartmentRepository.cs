using Microsoft.EntityFrameworkCore;
using StaffManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManager.Data.Repositories
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        private readonly ApplicationDBContext context;

        public DepartmentRepository(ApplicationDBContext context):base(context)
        {
            this.context = context;
        }
    }
}
