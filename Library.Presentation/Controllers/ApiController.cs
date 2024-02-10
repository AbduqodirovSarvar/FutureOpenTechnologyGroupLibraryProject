using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
