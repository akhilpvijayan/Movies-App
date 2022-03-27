using Microsoft.EntityFrameworkCore;
using MoviesAppproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAppproject.Repository
{
    public class MovieRepository : IMovieRepository
    {
        MoviesAppContext _db;
        public MovieRepository(MoviesAppContext db)
        {
            _db = db;
        }

        //Get Movies
        public async Task<List<Movies>> GetAllMovies()
        {
            if (_db != null)
            {
                return await _db.Movies.ToListAsync();
            }
            return null;
        }
            //Add movie

        public async Task<Movies> AddMovie(Movies movie)
        {
            //--- member function to add movie ---//
            if (_db != null)
            {
                await _db.Movies.AddAsync(movie);
                await _db.SaveChangesAsync();
                return movie;
            }
            return null;

        }
        //Update movie
        public async Task<Movies> UpdateMovie(Movies movie)
        {
            //member function to update movie
            if (_db != null)
            {
                _db.Movies.Update(movie);
                await _db.SaveChangesAsync();
                return movie;
            }
            return null;
        }
        //Delete movie
        public async Task<Movies> DeleteMovie(int id)
        {
            //member function to delete movie
            if (_db != null)
            {
                Movies movie = await _db.Movies.FirstOrDefaultAsync(em => em.MovieId == id);
                movie.Isactive = false;
                _db.Movies.Update(movie);
                await _db.SaveChangesAsync();
                return movie;
            }
            return null;
        }

    }
}
