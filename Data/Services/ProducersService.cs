using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public class ProducersService : IProducersService
    {
        private readonly AppDbContext _context;

        public ProducersService(AppDbContext context)
        {
            _context = context;
        }


        public async Task AddAsync(Producer producer)
        {
            await _context.AllProducers.AddAsync(producer);
            await _context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }



        public async Task<IEnumerable<Producer>> GetAllAsync()
        {
            var result = await _context.AllProducers.ToListAsync();
            return result;
        }

        public async Task<Producer> GetByIdAsync(int id)
        {
            var result = await _context.AllProducers.FirstOrDefaultAsync(n => n.Id == id);
            return result;
        }

        public async Task<Producer> UpdateAsync(int id, Producer newProducer)
        {
            _context.Update(newProducer);
            await _context.SaveChangesAsync();
            return newProducer;

        }
        public void DeleteProducer(int userId)
        {
            var producer = _context.AllProducers.Find(userId);
            if (producer != null)
            {
                _context.AllProducers.Remove(producer);
                _context.SaveChanges();
            }

        }
    }
}
