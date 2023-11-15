using System;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using Microsoft.AspNetCore.Hosting;
using WebAPI.Repository;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        private readonly IUsersRepository _Users;

        public UsersController(IWebHostEnvironment env, IUsersRepository Users)
        {
            _env = env;
            _Users = Users ?? throw new ArgumentNullException(nameof(Users));
        }

        [HttpGet]
        [Route("GetUsers")]
        public async Task<ActionResult<IEnumerable<Users>>>Get()
        {
            return Ok(await _Users.GetUsers());
        }

        [HttpGet("{id:int}")]
        [Route("GetUsersByID/{Id}")]
        public async Task<ActionResult<Users>> GetUsersByID(int Id)
        {
            return Ok(await _Users.GetUsersByID(Id));
        }

        [HttpPost]
        [Route("AddUsers")]
        public async Task<IActionResult> Post(Users emp)
        {

            var result = await _Users.InsertUsers(emp);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok("Added Successfully");
        }


        [HttpPut]
        [Route("UpdateUsers")]
        public async Task<IActionResult> Put(Users emp)
        {
            var result = await _Users.UpdateUsers(emp);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok("Updated Successfully");
        }

        [HttpDelete("{id:int}")]
        [Route("DeleteUser/{id}")]
        public JsonResult Delete(int id)
        {
            var result = _Users.DeleteUsers(id);
            return new JsonResult("Deleted Successfully");
        }


    }
}
