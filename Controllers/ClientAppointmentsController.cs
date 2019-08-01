using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingApp.DB;
using BookingApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Booking.Controllers
{
        
    [Route("api/ClientAppointments")]
    [ApiController]
    public class ClientAppointmentsController : ControllerBase
    {
        private readonly BookingContext _context;

        public ClientAppointmentsController(BookingContext context)
        {
            _context = context;

       
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientAppointment>>> GetClientAppointmentItems()
        {
            return await _context.ClientAppointments.ToListAsync();
        }


// GET: api/Todo/5
[HttpGet("{id}")]
public async Task<ActionResult<ClientAppointment>> GetClientAppointmentItem(int id)
{
    var todoItem = await _context.ClientAppointments.FindAsync(id);

    if (todoItem == null)
    {
        return NotFound();
    }

    return todoItem;
}
[HttpPost]
public async Task<IActionResult> PostTodoItem(ClientAppointment item)
{
    _context.ClientAppointments.Add(item);
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
    public async Task<IActionResult> PutTodoItem(long id, ClientAppointment item)
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
