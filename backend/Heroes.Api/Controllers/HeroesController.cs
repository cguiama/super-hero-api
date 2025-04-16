using Heroes.Application.Features.Heroes.Commands.CreateHero;
using Heroes.Application.Features.Heroes.Dtos;
using Heroes.Application.Features.Heroes.Queries.GetHeroById;
using Heroes.Application.Features.Heroes.Queries.ListHeroes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Heroes.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HeroesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HeroesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHeroById(Guid id)
        {
            var result = await _mediator.Send(new GetHeroByIdQuery(id));

            if (result == null)
                return NotFound("Herói não encontrado.");

            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] HeroCreateDto dto)
        {
            var result = await _mediator.Send(new CreateHeroCommand(dto));
            return CreatedAtAction(nameof(GetHeroById), new { id = result.Id }, result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new ListHeroesQuery());
            return Ok(result);
        }
    }
}
