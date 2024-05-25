using IMDB.Interfaces;
using IMDB.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace IMDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly IActorServices _actorServices;

        public ActorsController(IActorServices actorServices)
        {
            _actorServices = actorServices;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
                var actor = _actorServices.GetAll();
                return Ok(actor);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var actor = _actorServices.GetById(id);
            return Ok(actor);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ActorRequest request)
        {
                var response  = _actorServices.Create(request);
                return Ok(response);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update([FromRoute]int id, [FromBody] ActorRequest request)
        {
                _actorServices.Update(id, request);
                return Ok();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _actorServices.Delete(id);
            return Ok();
        }
    }
}
