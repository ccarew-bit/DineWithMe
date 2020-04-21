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
  [Route("Request")]
  [ApiController]
  public class RequestController : ControllerBase
  {
    private readonly DatabaseContext _context;

    public RequestController(DatabaseContext context)
    {
      _context = context;
    }

    // GET: api/Request
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Request>>> GetRequests()
    {
      return await _context.Requests.ToListAsync();
    }

    // GET: api/Request/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Request>> GetRequest(int id)
    {
      var request = await _context.Requests.FindAsync(id);

      if (request == null)
      {
        return NotFound();
      }

      return request;
    }

    // PUT: api/Request/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    // more details see https://aka.ms/RazorPagesCRUD.
    [HttpPut("{id}")]
    public async Task<IActionResult> PutRequest(int id, Request request)
    {
      if (id != request.Id)
      {
        return BadRequest();
      }

      _context.Entry(request).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!RequestExists(id))
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

    // POST: api/Request
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    // more details see https://aka.ms/RazorPagesCRUD.
    [HttpPost]
    public async Task<ActionResult<Request>> PostRequest(Request request)
    {
      _context.Requests.Add(request);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetRequest", new { id = request.Id }, request);
    }

    // DELETE: api/Request/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Request>> DeleteRequest(int id)
    {
      var request = await _context.Requests.FindAsync(id);
      if (request == null)
      {
        return NotFound();
      }

      _context.Requests.Remove(request);
      await _context.SaveChangesAsync();

      return request;
    }

    private bool RequestExists(int id)
    {
      return _context.Requests.Any(e => e.Id == id);
    }
  }
}
