
using ChatSystem.Dto.Chat;
using ChatSystem.Dto.Client;
using ChatSystem.Services;
using Microsoft.AspNetCore.Mvc;
using ClientDto = ChatSystem.Dto.Chat.ClientDto;

namespace ChatSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        //1
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }
        //2
        [HttpGet]
        public ActionResult<List<ClientDto>> Get()
        {
            return Ok(_clientService.GetClients());
        }
        //3
        [HttpGet("{id}")]
        public ActionResult<ClientDto?> GetById(int id)
        {
            var  result = _clientService.GetById(id);
            return Ok(result);
        }
        //4
        [HttpPost]
        public ActionResult<ClientDto> Post(CreateClientDto createClientDto)
        {
            var result = _clientService.Post(createClientDto);
            return Ok(result);
        }
        //5
        [HttpPut("{id}")]
        public ActionResult<ClientDto> Put(int id, UpdateClientDto updateClientDto)
        {
            var result = _clientService.Put(id, updateClientDto);
            return Ok(result);
        }
        //6
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = _clientService.Delete(id);
            return Ok(result);
        }
    }
}
