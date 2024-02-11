using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.Presentation.Controllers
{
    public class ApiController : ControllerBase
    {
        protected readonly IMediator _mediator;
        public ApiController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
