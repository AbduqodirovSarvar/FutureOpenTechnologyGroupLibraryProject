using Library.Application.UseCases.Security;
using Library.Application.UseCases.ToDoList.Commands.BookToDoList;
using Library.Application.UseCases.ToDoList.Commands.StudentToDoList;
using Library.Application.UseCases.ToDoList.Queries.BookToDoList;
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
    public class BookController : ApiController
    {
        public BookController(IMediator mediator) 
            : base(mediator)
        { }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] BookCreateCommand command)
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
        [Route("genre/create")]
        public async Task<IActionResult> CreateGenre([FromBody] GenreCreateCommand command)
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
        [Route("author/create")]
        public async Task<IActionResult> CreateBookAuthor([FromBody] BookAuthorCreateCommand command)
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
        [AllowAnonymous]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            try
            {
                return Ok(await _mediator.Send(new GetBookByIdQuery(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("all")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _mediator.Send(new GetAllBookQuery()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
