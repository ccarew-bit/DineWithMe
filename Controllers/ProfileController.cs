using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using DineWithMe.Models;
using Microsoft.EntityFrameworkCore;

namespace DineWithMe.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
  public class ProfileController : ControllerBase
  {
    readonly private DatabaseContext _context;
    public ProfileController(DatabaseContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<ActionResult> GetCurrentUser()
    {
      var userId = int.Parse(User.Claims.FirstOrDefault(claim => claim.Type == "id").Value);

      // query the database for the user with that id
      var user = await _context.Users.FirstOrDefaultAsync(f => f.Id == userId);
      //return that user's profile
      // .ThenInclude(i => i.)
      return Ok(user);
    }

    [HttpGet("IncomingRequests")]
    public async Task<ActionResult> GetIncomingRequest()
    {
      var userId = int.Parse(User.Claims.FirstOrDefault(claim => claim.Type == "id").Value);

      var incomingRequests = await _context.Requests.Where(request => request.FriendId == userId && request.IsRequestAccepted == false && request.IsRequestDenied == false).Include(request => request.Requestor).ToListAsync();

      return Ok(incomingRequests);
    }

    [HttpGet("OutgoingRequests")]
    public async Task<ActionResult> GetOutgoingRequest()
    {
      var userId = int.Parse(User.Claims.FirstOrDefault(claim => claim.Type == "id").Value);

      var outgoingRequests = await _context.Requests.Where(request => request.RequestorId == userId && request.IsRequestAccepted == false).Include(request => request.Friend).ToListAsync();
      return Ok(outgoingRequests);

    }

    [HttpGet("AcceptedRequests")]
    public async Task<ActionResult> GetAcceptedRequest()
    {
      var userId = int.Parse(User.Claims.FirstOrDefault(claim => claim.Type == "id").Value);

      var acceptedRequests = await _context.Requests.Where(request => request.RequestorId == userId && request.IsRequestAccepted == true).Include(request => request.Friend).ToListAsync();

      return Ok(acceptedRequests);
    }


    [HttpGet("DeniedRequests")]
    public async Task<ActionResult> GetDeniedRequest()
    {
      var userId = int.Parse(User.Claims.FirstOrDefault(claim => claim.Type == "id").Value);

      var deniedRequests = await _context.Requests.Where(request => request.RequestorId == userId && request.IsRequestDenied == true).Include(request => request.Friend).ToListAsync();
      // if (IsRequestAccepted == true)
      return Ok(deniedRequests);
    }
  }
}

//   public class ProfileController : ControllerBase
//   {
//     [HttpGet]
//     public async Task<ActionResult> GetCurrentUser()
//     {
//       var userId = User.Claims.FirstOrDefault(claim => claim.Type == "id");
//       return Ok(userId);
//   }

