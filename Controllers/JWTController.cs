using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using API_JWTAuthentication.Model;
using API_JWTAuthentication.Model.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace API_JWTAuthentication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JWTController : ControllerBase
    {
        private IConfiguration _config;

        public JWTController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet("Generate_Token")]
        public IActionResult GenerateJSONWebToken()
        {

            IActionResult response;
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


            var permClaims = new List<Claim>();
            permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                                             _config["Jwt:Issuer"],
                                             null,
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: credentials);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            response = Ok(new { Token = tokenString, Message = "Success" });
            return response;

        }

        [Authorize]        
        [HttpPost("GetData")]
        public JsonResult GetData([FromBody] SearchCriteria search)
        {
            Repository objRep = new Repository();
            return objRep.GetEmployeeDetails(search.FromDate, search.ToDate);
        }
        
    }
}
