using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserDetailsDesktop.DTOs;
using UserDetailsDesktop.Models;
using UserDetailsDesktop.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserDetailsDesktop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDataController : ControllerBase
    {
        private IUserService _userService;

        public UserDataController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UserDataController>
        [HttpGet]
        public IEnumerable<User> Get()
        {

            return _userService.GetAll();
        }

        // GET api/<UserDataController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return 400 Bad Request with ModelState errors
            }

            var user = _userService.GetById(id);
            if (user == null)
            {
                ModelState.AddModelError("Id", "User not found"); // Add custom error message to ModelState
                return NotFound(ModelState); // Return 404 Not Found with ModelState errors
            }

            return Ok(user);

        }

        // POST api/<UserDataController>
        [HttpPost]
        public void Add([FromBody] UserDto user)
        {
            User newUser = new User()
            {
                UserName = user.UserName,
                DateOfBirth = user.DateOfBirth,
                Location = user.Location,
                IsActive = 1
            };
            _userService.Add(newUser);
        }

        // PUT api/<UserDataController>/5
        [HttpPut("{id}")]
        public void Update(int id, [FromBody] UserDto user)
        {
            var temp = _userService.GetById(id);
            if (temp != null)
            {
                temp.UserName = user.UserName;
                temp.Location = user.Location;
                temp.DateOfBirth = user.DateOfBirth;
                _userService.Update(temp);
            }
        }

        // DELETE api/<UserDataController>/5
        [HttpDelete("{id}")]
        public void SoftDelete(int id)
        {
            var temp = _userService.GetById(id);
            if (temp != null)
            {
                temp.IsActive = 0;
                _userService.Update(temp);
            }
        }
    }
}
