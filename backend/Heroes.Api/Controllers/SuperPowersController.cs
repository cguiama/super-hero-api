using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Heroes.Infrastructure.Data;
using Heroes.Domain.Entities;

namespace Heroes.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuperPowersController : ControllerBase
    {
        private readonly HeroesDbContext _context;

        public SuperPowersController(HeroesDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperPower>>> GetAll()
        {
            var powers = await _context.SuperPowers.ToListAsync();
            return Ok(powers);
        }
    }
}
