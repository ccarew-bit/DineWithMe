using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DineWithMe.Models;
using System.Net;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace DineWithMe.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
  public class AgreementController : ControllerBase
  {
    private readonly DatabaseContext _context;

    public AgreementController(DatabaseContext context)
    {
      _context = context;
    }

    // GET: api/Agreement
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Agreement>>> GetAgreements()
    {
      return await _context.Agreements.ToListAsync();
    }

    // GET: api/Agreement/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Agreement>> GetAgreement(int id)
    {
      var agreement = await _context.Agreements.FindAsync(id);

      if (agreement == null)
      {
        return NotFound();
      }

      return agreement;
    }

    // PUT: api/Agreement/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    // more details see https://aka.ms/RazorPagesCRUD.
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAgreement(int id, Agreement agreement)
    {
      if (id != agreement.Id)
      {
        return BadRequest();
      }

      _context.Entry(agreement).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!AgreementExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    // POST: api/Agreement
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    // more details see https://aka.ms/RazorPagesCRUD.
    [HttpPost]
    public async Task<ActionResult> PostAgreement(Agreement newAgreement)
    {
      //get current user id
      var userId = int.Parse(User.Claims.FirstOrDefault(f => f.Type == "id").Value);

      var request = await _context.Requests.FirstOrDefaultAsync(request => request.Id == newAgreement.RequestId);

      var existingAgreement = await _context.Agreements.FirstOrDefaultAsync(agreement => agreement.RequestId == newAgreement.RequestId && agreement.RestaurantId == newAgreement.RestaurantId);

      if (existingAgreement == null)
      {
        existingAgreement = new Agreement
        {
          RequestId = newAgreement.RequestId,
          RestaurantId = newAgreement.RestaurantId,
          RequestorId = newAgreement.RequestorId,
          FriendId = newAgreement.FriendId
        };
        _context.Agreements.Add(existingAgreement);
      }
      else
      {
        _context.Entry(existingAgreement).State = EntityState.Modified;
      }

      if (request.RequestorId == userId)
      {
        existingAgreement.RequestorApproved = true;
      }
      else
      {
        existingAgreement.FriendApproved = true;
      }

      if (existingAgreement.RequestorApproved == true && existingAgreement.FriendApproved == true)
      {
        existingAgreement.IsAgreementMade = true;
      }



      await _context.SaveChangesAsync();
      return Ok(existingAgreement);

    }

    [HttpGet("MutuallyAgreed")]

    public async Task<ActionResult> MutuallyAgreed()
    {

      // get teh current user
      var userId = int.Parse(User.Claims.FirstOrDefault(f => f.Type == "id").Value);
      var agreements = _context.Agreements.Include(i => i.Restaurant).Include(i => i.Requestor).Include(i => i.Friend).Where(w => w.FriendApproved == true && w.RequestorApproved == true);
      return Ok(agreements);
      // && (w.FriendId == userId || w.RequestorId == userId) && w.IsAgreementMade == true
    }
    //   // Get their requests where they are the friend
    //   var friendRequestIds = _context.Requests.Where(w => w.FriendId == userId && w.IsRequestAccepted).Select(s => s.Id);
    //   // get the agreemtns
    //   var agreements = _context.Agreements.Include(i => i.Restaurant).Include(i => i.Request).Where(w => friendRequestIds.Contains(w.RequestId) && w.Friend == true && w.Requestor == true);



    //   // get their request where they are teh requestor
    //   var requestorRequestIds = _context.Requests.Where(w => w.FriendId == userId && w.IsRequestAccepted).Select(s => s.Id);
    //   // get the agreemtns
    //   var agreementsTwo = _context.Agreements.Include(i => i.Restaurant).Include(i => i.Request).Where(w => requestorRequestIds.Contains(w.RequestId) && w.Friend == true && w.Requestor == true);
    // get the agreements
    // merge the agreements lists


    //using the request ids, we need to find the agreeemnts and slec the resturanrant 


    // return the agreements
    //  var agreements = await _context.Agreements.Where(agreement => agreement.RequestId == requestId && agreement.Friend == true && agreement.Requestor == true).Include(agreement => agreement.Restaurant).Select(s => s.Restaurant).ToListAsync();

    // Console.WriteLine($"########## {agreements}");
    //     return Ok(agreements);
    // }




    // DELETE: api/Agreement/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Agreement>> DeleteAgreement(int id)
    {
      var agreement = await _context.Agreements.FindAsync(id);
      if (agreement == null)
      {
        return NotFound();
      }

      _context.Agreements.Remove(agreement);
      await _context.SaveChangesAsync();

      return agreement;
    }

    private bool AgreementExists(int id)
    {
      return _context.Agreements.Any(e => e.Id == id);
    }
  }
}
