using SalesWebMvcNew.Data;
using SalesWebMvcNew.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SalesWebMvcNew.Services.Exceptions;
using System.Threading.Tasks;

namespace SalesWebMvcNew.Services
{
    public class SellerService
    {
        private readonly SalesWebMvcNewContext _context;

        public SellerService(SalesWebMvcNewContext context) // Construtor
        {
            _context = context;
        }

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }

        public async Task InsertAsync(Seller obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync(); 
        }

        public async Task<Seller> FindByIdAsync(int id) // Isso faz o join  das tabelas Sellers e Department buscando o id do department
        {
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }   

        public async Task RemoveAsync(int id)
        {
            try 
            {
                var obj = await _context.Seller.FindAsync(id);
                _context.Seller.Remove(obj);
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateException)
            {
                throw new IntegrityException("Can´t delete seller because he/she has sales");
            }
            
        }

        public async Task UpdateAsync(Seller obj)
        {
            var hasAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Seller.Update(obj);
                await _context.SaveChangesAsync();
            } 
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message); //Lança exceção da camada de serviço
            }
        }
    }
}
