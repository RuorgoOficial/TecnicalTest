using CodereTecnicalTest.Api.Authentication;
using CodereTecnicalTest.Application.Events.Queries;
using CodereTecnicalTest.Domain.Abstractions;
using CodereTecnicalTest.Domain.DTOs;
using CodereTecnicalTest.Domain.Entities;
using CodereTecnicalTest.Domain.Mappers;
using CodereTecnicalTest.Infrastructure.Access;
using CodereTecnicalTest.Infrastructure.Context;
using CodereTecnicalTest.Infrastructure.Http;
using LanguageExt.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodereTecnicalTest.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShowController : ControllerBase
    {
        private readonly ILogger<ShowController> _logger;
        private readonly IRepository<Show> _showRepository;
        private readonly IMediator _mediator;


        public ShowController(
            ILogger<ShowController> logger,
            IRepository<Show> showRepository,
            IMediator mediator)
        {
            _logger = logger;
            _showRepository = showRepository;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<ShowDTO>> Get(CancellationToken cancelationToken)
        {
            var query = new Get<ShowDTO>();
            return await _mediator.Send(query, cancelationToken);
        }

        [HttpPost]
        [ServiceFilter(typeof(ApiKeyAuthFilter))]
        public async Task<IActionResult> Post(int id, CancellationToken cancellationToken)
        {
            var query = new ManageShowById(id);
            var response = await _mediator.Send(query, cancellationToken);

            return response.Match<IActionResult>(
                    r => Ok(r),
                    ex => BadRequest(ex.Message)
                );
        }
    }
}
