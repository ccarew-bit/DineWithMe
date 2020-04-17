using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DineWithMe.Models;
using DineWithMe.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

      return Ok(user);
    }
  }
}