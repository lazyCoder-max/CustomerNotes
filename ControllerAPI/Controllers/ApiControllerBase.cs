using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ControllerAPI.Controllers
{
    public class ApiControllerBase: ControllerBase
    {
        private ISender? _sender;
        protected ISender Mediator => _sender ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}
