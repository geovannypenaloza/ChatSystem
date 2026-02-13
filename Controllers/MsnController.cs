using ChatSystem.Dto.Msn;
using ChatSystem.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ChatSystem.Controllers;

[ApiController]
[Route("[controller]")]
public class MsnController : ControllerBase
{
    private readonly IHubContext<ChatHub> _hubContext;

    public
        MsnController(
            IHubContext<ChatHub> hubContext) //constructor siempre publico, debe tener el mismo nombre de la clase
    {
        _hubContext = hubContext;
    }

    [HttpPost]
    public ActionResult Post(GpsDataDto gpsDataDto)
    {
        _hubContext.Clients.All.SendAsync("GpsData", gpsDataDto);
        
        return Ok();
    }
}