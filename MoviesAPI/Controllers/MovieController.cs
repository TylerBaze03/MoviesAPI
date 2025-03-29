using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Models;
using MoviesAPI.Services;


namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly MovieService _movieService;

        public MovieController(MovieService movieService) => _movieService = movieService;

        [HttpGet]
        public async Task<List<Movie>> Get() => await _movieService.GetAsync();
        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Movie>> Get(string id)
        {
            var movie = await _movieService.GetAsync(id);

            if (movie == null)
            {
                return NotFound();
            }
            return movie;
        }
        [HttpPost]
        public async Task<IActionResult> Post(Movie newMovie)
        {
            await _movieService.CreateAsync(newMovie);

            return CreatedAtAction(nameof(Get), new { id = newMovie.Id }, newMovie);
        }
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Movie updatedMovie)
        {
            var movie = await _movieService.GetAsync(id);

            if (movie == null)
            {
                return NotFound();
            }
            updatedMovie.Id = movie.Id;

            await _movieService.UpdateAsync(id, updatedMovie);

            return NoContent();
        }
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var movie = await _movieService.GetAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            await _movieService.RemoveAsync(id);

            return NoContent();
        }

    }
}
