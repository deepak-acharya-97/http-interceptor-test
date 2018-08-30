using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GithubIntegrationServer.Models;

namespace GithubIntegrationServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignedTasksController : ControllerBase
    {
        private readonly GithubIntegrationServerContext _context;

        public AssignedTasksController(GithubIntegrationServerContext context)
        {
            _context = context;
        }

        // GET: api/AssignedTasks
        [HttpGet]
        public IEnumerable<AssignedTask> GetAssignedTask()
        {
            return _context.AssignedTask;
        }

        // GET: api/AssignedTasks/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAssignedTask([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var assignedTask = await _context.AssignedTask.FindAsync(id);

            if (assignedTask == null)
            {
                return NotFound();
            }

            return Ok(assignedTask);
        }

        // PUT: api/AssignedTasks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssignedTask([FromRoute] int id, [FromBody] AssignedTask assignedTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != assignedTask.TaskId)
            {
                return BadRequest();
            }

            _context.Entry(assignedTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssignedTaskExists(id))
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

        // POST: api/AssignedTasks
        [HttpPost]
        public async Task<IActionResult> PostAssignedTask([FromBody] AssignedTask assignedTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.AssignedTask.Add(assignedTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssignedTask", new { id = assignedTask.TaskId }, assignedTask);
        }

        // DELETE: api/AssignedTasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssignedTask([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var assignedTask = await _context.AssignedTask.FindAsync(id);
            if (assignedTask == null)
            {
                return NotFound();
            }

            _context.AssignedTask.Remove(assignedTask);
            await _context.SaveChangesAsync();

            return Ok(assignedTask);
        }

        private bool AssignedTaskExists(int id)
        {
            return _context.AssignedTask.Any(e => e.TaskId == id);
        }
    }
}