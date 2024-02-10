using Library.Application.UseCases.Security;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Presentation.Controllers
{
    [Route("api/[controller]/users")]
    [ApiController]
    public class AuthController : ApiController
    {
        public AuthController(IMediator mediator) 
            : base(mediator) { }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] AuthRegisterCommand command)
        {
            try
            {
                return Ok(await _mediator.Send(command));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        [Route("update-by-superadmin")]
        [Authorize(Policy = "SuperAdminActions")]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommand command)
        {
            try
            {
                return Ok(await _mediator.Send(command));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] AuthLoginCommand command)
        {
            try
            {
                return Ok(await _mediator.Send(command));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("reset-account-by-email")]
        [AllowAnonymous]
        public async Task<IActionResult> Reset([FromBody] AuthResetCommand command)
        {
            try
            {
                return Ok(await _mediator.Send(command));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("send-email-for-reset")]
        [AllowAnonymous]
        public async Task<IActionResult> SendEmailForReset([FromBody] AuthSendConfirmationEmailForResetCommand command)
        {
            try
            {
                await _mediator.Send(command);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
