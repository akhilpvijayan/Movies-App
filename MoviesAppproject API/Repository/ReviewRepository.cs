using Microsoft.EntityFrameworkCore;
using MoviesAppproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAppproject.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        MoviesAppContext _db;
        public ReviewRepository(MoviesAppContext db)
        {
            _db = db;
        }

        //Get Reviews
        public async Task<List<Reviews>> GetAllReviews()
        {
            if (_db != null)
            {
                return await _db.Reviews.ToListAsync();
            }
            return null;
        }
        //Add Review

        public async Task<Reviews> AddReview(Reviews review)
        {
            //--- member function to add review ---//
            if (_db != null)
            {
                await _db.Reviews.AddAsync(review);
                await _db.SaveChangesAsync();
                return review;
            }
            return null;

        }
        //Update review
        public async Task<Reviews> UpdateReview(Reviews review)
        {
            //member function to update review
            if (_db != null)
            {
                _db.Reviews.Update(review);
                await _db.SaveChangesAsync();
                return review;
            }
            return null;
        }
    }
}
