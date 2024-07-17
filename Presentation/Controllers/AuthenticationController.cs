using Entities.DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    public class AuthenticationController:ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public AuthenticationController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterUser([FromBody]UserForRegistrationDto userForRegistrationDto)
        {
            var result= await _serviceManager
                .AuthenticationService
                .RegisterUser(userForRegistrationDto);
            if(!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            return StatusCode(201);
        }


        [HttpPost("login")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto userForAuthenticationDto)
        {
            if(! await _serviceManager.AuthenticationService.ValidateUser(userForAuthenticationDto))
                return Unauthorized();

            var tokenDto = await _serviceManager
                .AuthenticationService
                .CreateToken(populateExp:true);

            return Ok(tokenDto);
        }
        //        pm.test("Status code is 200", function()
        //        {
        //            pm.response.to.have.status(200);

        //            const response = pm.response.json();
        //            let token = response.token;
        //            pm.globals.set("accessToken", token)
        //});
        //access token on postman, We define a global variable called accessToken and set it to the token value returned by the server.
    }
}
