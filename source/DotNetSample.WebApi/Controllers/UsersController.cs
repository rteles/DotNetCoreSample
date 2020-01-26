using System.Collections.Generic;
using System.Linq;
using System.Net;
using DotNetSample.Application.DataTypes.Request;
using DotNetSample.Application.DataTypes.Result;
using DotNetSample.Application.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DotNetSample.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private IUserAppService _userAppService;

        public UsersController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        // GET: api/<controller>/true
        [HttpGet("{onlyActives:bool}")]
        [ProducesResponseType(typeof(IEnumerable<UserResult>), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(OperationResultList<UserResult>), (int) HttpStatusCode.BadRequest)]
        public IActionResult Get(bool onlyActives)
        {
            var usersResult = _userAppService.GetUsers(onlyActives);

            if (!usersResult.Success)
                return BadRequest(usersResult);

            if (usersResult.Data != null && usersResult.Data.Any())
                return Ok(usersResult.Data);

            return NotFound();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserResult), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(OperationResult<UserResult>), (int) HttpStatusCode.BadRequest)]
        public IActionResult Get(int id)
        {
            var usersResult = _userAppService.GetUser(id);
            if (!usersResult.Success)
                return BadRequest(usersResult);

            if (usersResult.Data != null)
                return Ok(usersResult.Data);

            return NotFound();
        }

        // POST api/<controller>
        [HttpPost]
        [ProducesResponseType(typeof(OperationResult), (int) HttpStatusCode.BadRequest)]
        public IActionResult Post([FromBody] AddUserRequest request)
        {
            var result = _userAppService.AddUser(request);
            if (result.Success)
                return Ok();

            return BadRequest(result);
        }

        // PUT api/<controller>
        [HttpPut]
        [ProducesResponseType(typeof(OperationResult), (int) HttpStatusCode.BadRequest)]
        public IActionResult Put([FromBody] UpdateUserRequest request)
        {
            var result = _userAppService.UpdateUser(request);
            if (result.Success)
                return Ok();

            return BadRequest(result);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(OperationResult), (int) HttpStatusCode.BadRequest)]
        public IActionResult Delete(int id)
        {
            var result = _userAppService.DeleteUser(id);
            if (result.Success)
                return Ok();

            return BadRequest(result);
        }
    }
}