using IMDB.Interfaces;
using IMDB.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace IMDB.Controllers
{
    [Route("api/[controller]/{movieId}")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewServices _reviewServices;

        public ReviewsController(IReviewServices reviewServices)
        {
            _reviewServices = reviewServices;
        }
        [HttpGet]
        public IActionResult GetAll([FromRoute]int movieId)
        {

                var review = _reviewServices.GetAll(movieId);
                return Ok(review);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute]int movieId, [FromRoute] int id)
        {
                var review = _reviewServices.GetById(movieId, id);
                return Ok(review);
        }

        [HttpPost]
        public IActionResult Create([FromRoute]int movieId, [FromBody] ReviewRequest request)
        {
        
                var response = _reviewServices.Create(movieId, request);
                return Ok(response);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update([FromRoute]int movieId, [FromRoute] int id, [FromBody] ReviewRequest request)
        {
                _reviewServices.Update(movieId, id, request);
                return Ok();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute]int movieId,[FromRoute] int id)
        {
                _reviewServices.Delete(movieId, id);
                return Ok();
        }
    }
}
