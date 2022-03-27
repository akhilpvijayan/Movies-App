using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAppproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAppproject.Repository
{
    public class UserRepository : IUserRepository
    {

        MoviesAppContext _db;

        public UserRepository(MoviesAppContext db)
        {
            _db = db;
        }
        /*public TblUserRegistration GetUser(TblUserRegistration login)
        {
            if (_db != null)
            {
                TblUserRegistration dbuser = _db.TblUserRegistration.FirstOrDefault(em => em.Usename == login.Usename && em.Password == login.Password);
                if (dbuser != null)
                {
                    return dbuser;
                }
            }

            return null;
        }*/
        public Users ValidateUser(string userName, string password)
        {
            if (_db != null)
            {
                Users dbuser = _db.Users.FirstOrDefault(em => em.Username == userName && em.Userpassword == password);
                if (dbuser != null)
                {
                    return dbuser;
                }
            }

            return null;
        }

        public async Task<ActionResult<Users>> GetUserByPassword(string un, string pwd)
        {
            if (_db != null)
            {
                Users user = await _db.Users.FirstOrDefaultAsync(em => em.Username == un && em.Userpassword == pwd);
                return user;
            }
            return null;
        }
    }
}
