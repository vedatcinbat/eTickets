using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public class ActorsService : IActorsService
    {

        private readonly AppDbContext _context;

        public ActorsService(AppDbContext context)
        {
            _context = context;
        }


        public async Task AddAsync(Actor actor)
        {
            await _context.AllActors.AddAsync(actor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var actor = _context.AllActors.Find(id);
            if(actor != null)
            {
                _context.AllActors.Remove(actor);
                _context.SaveChanges(); 
            }
            
        }

        

        public async Task<IEnumerable<Actor>> GetAllAsync()
        {
            var result = await _context.AllActors.ToListAsync();
            return result;
        }

        public async Task<Actor> GetByIdAsync(int id)
        {
            var result = await _context.AllActors.FirstOrDefaultAsync(n => n.Id == id);
            return result;
        }

        public async Task<Actor> UpdateAsync(int id, Actor newActor)
        {
            _context.Update(newActor);
            await _context.SaveChangesAsync();
            return newActor;




        }
    }
}
