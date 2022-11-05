using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mobpsycho.Models;

namespace mobpsycho.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbilitiesController : ControllerBase
    {
        private readonly MobpsychoDbContext _context;

        public AbilitiesController(MobpsychoDbContext context)
        {
            _context = context;
        }

        // GET: api/Abilities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Abilitie>>> GetAbilities()
        {
            return await _context.Abilities.ToListAsync();
        }

        // GET: api/Abilities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Abilitie>> GetAbilitie(int id)
        {
            var abilitie = await _context.Abilities.FindAsync(id);

            if (abilitie == null)
            {
                return NotFound();
            }

            return abilitie;
        }

        // PUT: api/Abilities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAbilitie(int id, Abilitie abilitie)
        {
            if (id != abilitie.IdAbilitie)
            {
                return BadRequest();
            }

            _context.Entry(abilitie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AbilitieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Abilities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Abilitie>> PostAbilitie(Abilitie abilitie)
        {
            _context.Abilities.Add(abilitie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAbilitie", new { id = abilitie.IdAbilitie }, abilitie);
        }

        // DELETE: api/Abilities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbilitie(int id)
        {
            var abilitie = await _context.Abilities.FindAsync(id);
            if (abilitie == null)
            {
                return NotFound();
            }

            _context.Abilities.Remove(abilitie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AbilitieExists(int id)
        {
            return _context.Abilities.Any(e => e.IdAbilitie == id);
        }
    }
}
