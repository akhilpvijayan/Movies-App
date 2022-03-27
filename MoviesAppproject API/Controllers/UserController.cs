using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MoviesAppproject.Models;
using MoviesAppproject.Repository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesAppproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IConfiguration _config;
        IUserRepository loginRepository;



        public UserController(IConfiguration config, IUserRepository _l)
        {
            _config = config;
            loginRepository = _l;
        }



        /* [AllowAnonymous]
         [Authorize(AuthenticationSchemes = "Bearer")]
         [HttpPost]
         //loginmethod--IActionResult
         public IActionResult Login([FromBody] TblUser user)
         {
             IActionResult response = Unauthorized();



             //Authenticate the user
             var dbuser = AuthenticateUser(user);



             if (dbuser != null)
             {
                 var tokenString = GenerateJSONWebToken(dbuser);
                 response = Ok(new { token = tokenString });
             }
             return response;
         }*/
        [AllowAnonymous]
        //[Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("{userName}/{password}")]
        //loginmethod--IActionResult
        public IActionResult Login(string userName, string password)
        {
            IActionResult response = Unauthorized();
            //Authenticate the user
            var dbuser = AuthenticateUser(userName, password);
            if (dbuser != null)
            {
                var tokenString = GenerateJSONWebToken(dbuser);
                response = Ok(new
                {
                    uname = dbuser.Username,
                    //usertype = dbuser.UserType,
                    token = tokenString
                });
            }
            return response;
        }

        private string GenerateJSONWebToken(Users user)
        {
            //security key
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));



            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);



            //generate token
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
            _config["Jwt:Issuer"], null, expires: DateTime.Now.AddMinutes(20), signingCredentials: credentials);



            return new JwtSecurityTokenHandler().WriteToken(token);
        }





        //AuthenticateUSer()
        private Users AuthenticateUser(string userName, string password)
        {

            //validate the user credentials
            //Retrieve data from the database


            Users dbuser = loginRepository.ValidateUser(userName, password);//checking whether validity of username

            if (dbuser != null)
            {


                return dbuser;

            }
            return null;
        }
        //GenerateJsonWebToken()




        // get user details with username and password
        #region User details 

        /* [HttpGet]
         [Route("Getuser")]
         public async Task<IActionResult> GetUser(TblUserRegistration user)
         {
             try
             {
                 var dbuser = loginRepository.GetUser(user);
                 if (dbuser == null)
                 {
                     return NotFound();
                 }
                 return Ok(dbuser);
             }
             catch (Exception)
             {
                 return BadRequest();
             }

         }*/
        #endregion

        //GET api/login/username/password
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("getuser/{userName}/{password}")]
        public async Task<ActionResult<Users>> GetUserByNamePassword(string userName, string password)
        {
            try
            {
                var users = await loginRepository.GetUserByPassword(userName, password);
                if (users == null)
                {
                    return NotFound();
                }
                return users;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}


