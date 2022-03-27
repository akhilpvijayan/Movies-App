using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesAppproject.Models;
using MoviesAppproject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAppproject.Controllers
{
    [Route("Movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        IMovieRepository movieRepository;
        public MoviesController(IMovieRepository _p)
        {
            movieRepository = _p;
        }

        #region get movies
        [HttpGet]
        [ProducesResponseType(typeof(Movies), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAllMovie()
        {
            var movies = await movieRepository.GetAllMovies();
            if (movies == null)
            {
                return NotFound();
            }
            return Ok(movies);
        }
        #endregion

        #region add movie
        [HttpPost]
        [ProducesResponseType(typeof(Movies), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddMovie([FromBody] Movies movie)
        {
            if (ModelState.IsValid)
            {
                var movieId = await movieRepository.AddMovie(movie);
                if (movieId != null)
                {
                    return Ok(movieId);
                }
                else
                {
                    return NotFound();
                }
            }
            return BadRequest();
        }
        #endregion

        #region update movie
        [HttpPut]
        [ProducesResponseType(typeof(Movies), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateMovie(Movies movie)
        {
            if (ModelState.IsValid)
            {
                await movieRepository.UpdateMovie(movie);
                return Ok(movie);
            }
            return BadRequest();
        }
        #endregion

        #region deletemovie
        [HttpDelete]
        [ProducesResponseType(typeof(Movies), 200)]
        [ProducesResponseType(404)]
        [Route("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var exp = await movieRepository.DeleteMovie(id);
            if (exp == null)
            {
                return NotFound();
            }
            return Ok(exp);
        }
        #endregion
    }
}
