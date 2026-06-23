using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaksList.Data;
using TaksList.Models.Classes;
using TaksList.Models.Requests;

namespace TaksList.Controllers
{
    [ApiController]
    [Route("users")]

    public class UserController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IValidator<UserRequest> _validator;

        public UserController(AppDbContext db, IValidator<UserRequest> validator)
        {
            _db = db;
            _validator = validator;
        }

        [HttpPost]

        public IActionResult CreateUser([FromBody] UserRequest request)
        {
            var result = _validator.Validate(request);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors.Select(e => e.ErrorMessage));
            }
            var _user = new User
            {
                Name = request.Name,
                PhoneNumber = request.PhoneNumber
            };
            _db.Users.Add(_user);
            _db.SaveChanges();
            return Ok("usuario criado");
        }

        [HttpGet]

        public IActionResult GetUsers()
        {
            var users = _db.Users.ToList();
            return Ok(users);
        }

        [HttpGet("{Id}")]
        public IActionResult GetUser(int id)
        {
            var user = _db.Users
                .Include(u => u.RecurringTasks)
                .Include(u => u.ScheduledTasks)
                .FirstOrDefault(u => u.Id == id);
            if (user == null) return NotFound("Usuario não encontrado.");
            return Ok(user);
        }

        [HttpPut("{Id}")]
        public IActionResult UpdateUser(int id, [FromBody] UserRequest request)
        {
            var user = _db.Users.Find(id);
            if (user == null) return NotFound("Usuario não encontrado.");
            user.Name = request.Name;
            user.PhoneNumber = request.PhoneNumber;
            
            _db.SaveChanges();
            return Ok("Usuario atualizado.");
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _db.Users.Find(id);
            if (user == null) return NotFound("Usuario não encontrado.");
            _db.Users.Remove(user);
            _db.SaveChanges();
            return Ok("Usuario deletado.");
        }

    }
}
