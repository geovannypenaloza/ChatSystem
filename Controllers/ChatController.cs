using ChatSystem.Dto.Chat;
using ChatSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChatSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatController : ControllerBase
    {
        //1
        private readonly IChatService _chatService;
        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }
        //2
        [HttpGet]
        public ActionResult<List<ClientDto>> Get()
        {
            return Ok(_chatService.GetChats());
        }
        //3
        [HttpGet("{id}")]
        public ActionResult<ClientDto?> GetById(int id)
        {
            var  result = _chatService.GetById(id);
            return Ok(result);
        }
        //4
        [HttpPost]
        public ActionResult<ClientDto> Post(CreateChatDto createChatDto)
        {
            var result = _chatService.Post(createChatDto);
            return Ok(result);
        }
        //5
        [HttpPut("{id}")]
        public ActionResult<ClientDto> Put(int id, UpdateChatDto updateChatDto)
        {
            var result = _chatService.Put(id, updateChatDto);
            return Ok(result);
        }
        //6
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = _chatService.Delete(id);
            return Ok(result);
        }
    }
}
