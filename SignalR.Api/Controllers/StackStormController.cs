using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalR.Api.Hubs;
using SignalR.Api.Model;
using System.Threading.Tasks;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StackStormController : ControllerBase
    {
        private readonly IHubContext<StackstormHub> _hubContext;
        
        public StackStormController(IHubContext<StackstormHub> hubContext)
        {
            _hubContext = hubContext;
        }
        
        [HttpPost]
        public async Task<IActionResult> SendMessage(StackModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _hubContext.Clients.All.SendAsync("ReceiveMessage", model.User, model.Message);

            return Ok(model);
        }


    }
}