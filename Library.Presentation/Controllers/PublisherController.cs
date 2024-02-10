using Library.Application.UseCases.Security;
using Library.Application.UseCases.ToDoList.Commands.PublisherToDoList;
using Library.Application.UseCases.ToDoList.Commands.StudentToDoList;
using Library.Application.UseCases.ToDoList.Queries.PublishertoDoList;
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
    public class PublisherController : ApiController
    {
        public PublisherController(IMediator mediator) 
            : base(mediator)
        { }

        [HttpPost]
        [Route("create-full")]
        public async Task<IActionResult> Create([FromBody] PublisherCreateCommand command)
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
                return Ok(await _mediator.Send(new GetPublisherByIdQuery(id)));
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
                return Ok(await _mediator.Send(new GetAllPublishersQuery()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
