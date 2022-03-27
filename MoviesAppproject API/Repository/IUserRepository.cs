using Microsoft.AspNetCore.Mvc;
using MoviesAppproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAppproject.Repository
{
    public interface IUserRepository
    { //public TblLogin GetUser(TblLogin tblUser);

        Task<ActionResult<Users>> GetUserByPassword(string un, string pwd);
        public Users ValidateUser(string userName, string password);
    }
}
