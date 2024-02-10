using Library.Application.UseCases.Security;
using Library.Application.UseCases.ToDoList.Commands.AuthorToDoList;
using Library.Application.UseCases.ToDoList.Commands.StudentToDoList;
using Library.Application.UseCases.ToDoList.Queries.AuthorToDoList;
using Library.Application.UseCases.ToDoList.Queries.StudentToDoList;
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
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "AdminActions")]
    public class AuthorController : ApiController
    {
        public AuthorController(IMediator mediator) 
            : base(mediator)
        { }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] AuthorCreateCommand command)
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

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            try
            {
                return Ok(await _mediator.Send(new GetAuthorByIdQuery(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _mediator.Send(new GetAllAuthorsQuery()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
