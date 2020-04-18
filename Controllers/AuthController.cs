using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DineWithMe.Models;
using DineWithMe.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace DineWithMe.Controllers

{
  [Route("auth")]
  [ApiController]

  public class AuthController : ControllerBase

  {
    private DatabaseContext _context;


    // Dependency Injection
    public AuthController(DatabaseContext context)
    {
      _context = context;
    }

    [HttpPost("signup")]
    public async Task<ActionResult> SignUpUser(NewUser newUser)
    {
      if (newUser.Password.Length < 7)
      {
        return BadRequest("Password must be more than 7 characters");
      }
      var doesUserExist = await _context.Users.AnyAsync(user => user.PhoneNumber == newUser.PhoneNumber);
      if (doesUserExist)
      {
        return BadRequest("user already exists");
      }

      var user = new User
      {
        PhoneNumber = newUser.PhoneNumber,
        Name = newUser.Name,

      };

      var hashed = new PasswordHasher<User>().HashPassword(user, newUser.Password);
      user.HashedPassword = hashed;
      _context.Users.Add(user);
      await _context.SaveChangesAsync();

      var expirationTime = DateTime.UtcNow.AddHours(10);
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new[]
          {
            new Claim("id", user.Id.ToString()),
            new Claim("phonenumber", user.PhoneNumber),
            new Claim("name", user.Name)
          }),
        Expires = expirationTime,
        SigningCredentials = new SigningCredentials(
              new SymmetricSecurityKey(Encoding.ASCII.GetBytes("The same long string")),
              SecurityAlgorithms.HmacSha256Signature
          )
      };

      var tokenHandler = new JwtSecurityTokenHandler();
      var token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));


      user.HashedPassword = null;
      return Ok(new { Token = token, user = user });
    }
  }
}