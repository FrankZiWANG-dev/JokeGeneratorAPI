using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JokeGeneratorApi;
using JokeGeneratorApi.Models;

namespace JokeGeneratorApi.Controllers
{
    [Route("api/jokes")]
    [ApiController]
    public class JokesController : ControllerBase
    {
        private readonly JokeGeneratorContext _context;

        public JokesController(JokeGeneratorContext context)
        {
            _context = context;
        }

        // GET: api/Jokes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Joke>>> GetJokes()
        {
            return await _context.Jokes.ToListAsync();
        }

        // GET: api/Jokes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Joke>> GetJoke(int id)
        {
            var joke = await _context.Jokes.FindAsync(id);

            if (joke == null)
            {
                return NotFound();
            }

            return joke;
        }

        // PUT: api/Jokes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJoke(int id, Joke joke)
        {
            if (id != joke.id)
            {
                return BadRequest();
            }

            _context.Entry(joke).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JokeExists(id))
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

        // POST: api/Jokes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Joke>> PostJoke(Joke joke)
        {
            _context.Jokes.Add(joke);
            await _context.SaveChangesAsync();

            // return CreatedAtAction("GetJoke", new { id = joke.id }, joke);
            return CreatedAtAction(nameof(GetJoke), new { id = joke.id }, joke);
        }

        // DELETE: api/Jokes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJoke(int id)
        {
            var joke = await _context.Jokes.FindAsync(id);
            if (joke == null)
            {
                return NotFound();
            }

            _context.Jokes.Remove(joke);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JokeExists(int id)
        {
            return _context.Jokes.Any(e => e.id == id);
        }
    }
}
