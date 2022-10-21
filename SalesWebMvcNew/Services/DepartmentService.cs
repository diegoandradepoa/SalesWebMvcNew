using SalesWebMvcNew.Data;
using SalesWebMvcNew.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMvcNew.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMvcNewContext _context;

        public DepartmentService(SalesWebMvcNewContext context) // Construtor
        {
            _context = context;
        }

        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
