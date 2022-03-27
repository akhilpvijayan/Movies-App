using MoviesAppproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAppproject.Repository
{
    public interface IReviewRepository
    {
        /// <summary>
        /// display Reviews
        /// </summary>
        /// <returns></returns>
        Task<List<Reviews>> GetAllReviews();
        /// <summary>
        /// insert Review
        /// </summary>
        /// <param name="review"></param>
        /// <returns></returns>
        Task<Reviews> AddReview(Reviews review);
        /// <summary>
        /// update Review
        /// </summary>
        /// <param name="review"></param>
        /// <returns></returns>
        Task<Reviews> UpdateReview(Reviews review);
    }
}
