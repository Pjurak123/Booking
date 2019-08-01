using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingApp.DB;
using BookingApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Booking.Controllers
{
        
    [Route("api/trainers")]
    [ApiController]
    public class TrainersController : ControllerBase
    {
        private readonly BookingContext _context;

        public TrainersController(BookingContext context)
        {
            _context = context;

           
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trainer>>> GetTrainerItems()
        {
            return await _context.Trainers.ToListAsync();
        }


// GET: api/Todo/5
[HttpGet("{id}")]
public async Task<ActionResult<Trainer>> GetTrainerItem(int id)
{
    var todoItem = await _context.Trainers.FindAsync(id);

    if (todoItem == null)
    {
        return NotFound();
    }

    return todoItem;
}
[HttpPost]
public async Task<IActionResult> PostTodoItem(Trainer item)
{
    _context.Trainers.Add(item);
    await _context.SaveChangesAsync();
    return StatusCode(201);
}


        // [HttpPost]
        // public async Task<ActionResult<IEnumerable<String>>> PostBankItems()
        // {
        //     List<string> lista = new List<string> { "a", "b", "c"};
        //     return await lista.ToAsyncEnumerable<string>();
        // }
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTodoItem(long id, Trainer item)
    {
        if (id != item.Id)
        {
            return BadRequest();
        }

        _context.Entry(item).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();

    }
    [HttpDelete("(Id")]

    public async Task<IActionResult> DeleteToDoItem(long Id)
    {
        var ToDoItem = await _context.ClientAppointments.FindAsync(Id);
        if(ToDoItem == null)
        {
            return NotFound();
        }
        _context.ClientAppointments.Remove(ToDoItem);
        await _context.SaveChangesAsync();
        
        return NoContent();
        
    }
    }
}
