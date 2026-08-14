using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using TaskBoard.Data;
using TaskBoard.Models;

namespace TaskBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TaskController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetTask()
        {
            return Ok(await _context.Tasks.ToListAsync());
          
        }
        [HttpPost]
        public async Task<IActionResult> AddTask(TaskItem newTask)
        {
            var addingTask = await _context.Tasks.AddAsync(newTask);
            await _context.SaveChangesAsync();
            return Ok(newTask);
        }
    }
}
