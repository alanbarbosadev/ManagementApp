using ManagementApp.Domain.Models;
using ManagementApp.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace ManagementApp.Infrastructure.Repositories
{
    public class EmployeeRepository
    {
        private readonly ManagementAppContext _context;

        public EmployeeRepository(ManagementAppContext context)
        {
            _context = context;
        }

        public async Task<Employee> GetEmployeeById(Guid id)
        {
            return await _context.Employees.AsNoTracking().Include(x => x.Department).Include(x => x.Position).FirstOrDefaultAsync(x => x.Id.Equals(id));
        }
    }
}
