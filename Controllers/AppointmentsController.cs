using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingApp.DB;
using BookingApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Booking.Controllers
{
        
    [Route("api/appointments")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly BookingContext _context;

        public AppointmentsController(BookingContext context)
        {
            _context = context;

         
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments()
        {
            return await _context.Appointments.ToListAsync();
        }


// GET: api/Todo/5
[HttpGet("{id}")]
public async Task<ActionResult<Appointment>> GetAppointment(int id)
{
    var appointment = await _context.Appointments.FindAsync(id);

    if (appointment == null)
    {
        return NotFound();
    }

    return appointment;
}
[HttpPost]
public async Task<IActionResult> PostTodoItem(Appointment appointment)
{
    _context.Appointments.Add(appointment);
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
    public async Task<IActionResult> PutTodoItem(long id, Appointment appointment)
    {
        if (id != appointment.Id)
        {
            return BadRequest();
        }

        _context.Entry(appointment).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();

    }
    [HttpDelete("(Id")]

    public async Task<IActionResult> DeleteToDoItem(long Id)
    {
        var ToDoItem = await _context.Appointments.FindAsync(Id);
        if(ToDoItem == null)
        {
            return NotFound();
        }
        _context.Appointments.Remove(ToDoItem);
        await _context.SaveChangesAsync();
        
        return NoContent();

    }
    }
}
