using CleanArchitecture.Application.Features.Videos.Commands.Queries.GetVideosList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CleanArchitecture.API.Controllers
{
    //Este es un controller para consultar la lista de videos.
    [ApiController]
    [Route("api/v1/[controller]")]
    public class VideoController :ControllerBase
    {
        private readonly IMediator _mediator;

        public VideoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet("{username}",Name = "GetVideo")]
        [ProducesResponseType(typeof(IEnumerable<VideosVm>),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<VideosVm>>> GetVideosByUsername(string username)
        {
            var query = new GetVideosListQuery(username);
            var videos = await _mediator.Send(query);
            return Ok(videos);
        }
    }
}
