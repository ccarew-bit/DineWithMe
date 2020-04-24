using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DineWithMe.Models;

namespace DineWithMe.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
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
    public async Task<ActionResult> PostAgreement(Agreement agreement)
    {
      //get current user id
      var userId = int.Parse(User.Claims.FirstOrDefault(f => f.Type == "id").Value);
      //get Restaurant id
      var restaurantId = (await _context.Restaurants.FirstOrDefaultAsync(f => f.Name == agreement.Restaurant.Name)).Id;
      //get friend id
      var friendId = (await _context.Users.FirstOrDefaultAsync(f => f.Name == agreement.Friend.Name)).Id;
      agreement.RequestorId = userId;
      agreement.FriendId = friendId;
      agreement.RestaurantId = restaurantId;

      //pass token
      agreement.Friend = null;
      _context.Agreements.Add(agreement);
      await _context.SaveChangesAsync();
      return Ok(new { agreement, friendId, userId, restaurantId });
      //return CreatedAtAction("GetRequest", new { id = request.Id }, request);
    }




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
