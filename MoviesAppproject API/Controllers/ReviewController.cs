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
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        IReviewRepository reviewRepository;
        public ReviewController(IReviewRepository _p)
        {
            reviewRepository = _p;
        }

        #region get reviews
        [HttpGet]
        [ProducesResponseType(typeof(Reviews), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAllReviews()
        {
            var reviews = await reviewRepository.GetAllReviews();
            if (reviews == null)
            {
                return NotFound();
            }
            return Ok(reviews);
        }
        #endregion

        #region add review
        [HttpPost]
        [ProducesResponseType(typeof(Reviews), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddReview([FromBody] Reviews review)
        {
            if (ModelState.IsValid)
            {
                var reviewId = await reviewRepository.AddReview(review);
                if (reviewId != null)
                {
                    return Ok(reviewId);
                }
                else
                {
                    return NotFound();
                }
            }
            return BadRequest();
        }
        #endregion

        #region update review
        [HttpPut]
        [ProducesResponseType(typeof(Reviews), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateMovie(Reviews review)
        {
            if (ModelState.IsValid)
            {
                await reviewRepository.UpdateReview(review);
                return Ok(review);
            }
            return BadRequest();
        }
        #endregion
    }
}

