using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoadMapServer.Models;

namespace RoadMapServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoadMapsController : ControllerBase
    {
        private readonly RoadMapServerContext _context;

        public RoadMapsController(RoadMapServerContext context)
        {
            _context = context;
        }

        // GET: api/RoadMaps
        [HttpGet]
        public IEnumerable<RoadMap> GetRoadMap()
        {
            return _context.RoadMap.Include(s=>s.MileStones);
        }

        // GET: api/RoadMaps/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoadMap([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var roadMap = await _context.RoadMap.Include(s=>s.MileStones).Where(s=>s.GroupName==id).ToListAsync();

            if (roadMap == null)
            {
                return NotFound();
            }

            return Ok(roadMap);
        }

        // PUT: api/RoadMaps/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoadMap([FromRoute] string id, [FromBody] RoadMap roadMap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != roadMap.GroupName)
            {
                return BadRequest();
            }

            //_context.Entry(roadMap).State = EntityState.Modified;
            _context.RoadMap.Update(roadMap);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoadMapExists(id))
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

        // POST: api/RoadMaps
        [HttpPost]
        public async Task<IActionResult> PostRoadMap([FromBody] RoadMap roadMap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.RoadMap.Add(roadMap);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoadMap", new { id = roadMap.GroupName }, roadMap);
        }

        // DELETE: api/RoadMaps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoadMap([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var roadMap = await _context.RoadMap.FindAsync(id);
            if (roadMap == null)
            {
                return NotFound();
            }

            _context.RoadMap.Remove(roadMap);
            await _context.SaveChangesAsync();

            return Ok(roadMap);
        }

        private bool RoadMapExists(string id)
        {
            return _context.RoadMap.Any(e => e.GroupName == id);
        }
    }
}