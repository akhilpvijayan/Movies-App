using MoviesAppproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAppproject.Repository
{
    public interface IMovieRepository
    {
        /// <summary>
        /// display Movies
        /// </summary>
        /// <returns></returns>
        Task<List<Movies>> GetAllMovies();
        /// <summary>
        /// insert Movie
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        Task<Movies> AddMovie(Movies movie);
        /// <summary>
        /// update Movie
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        Task<Movies> UpdateMovie(Movies movie);
        /// <summary>
        /// delete Movie
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Movies> DeleteMovie(int id);

    }
}
