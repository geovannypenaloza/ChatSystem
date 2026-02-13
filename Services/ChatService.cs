using ChatSystem.Data;
using ChatSystem.Dto.Chat;
using ChatSystem.Models;

namespace ChatSystem.Services;
//interface
public interface IChatService
{
    public List<ClientDto> GetChats();
    public ClientDto? GetById(int id);
    public ClientDto Post(CreateChatDto createChatDto);
    public ClientDto? Put(int id, UpdateChatDto updateChatDto);
    public bool Delete(int id);
}
//services
public class ChatService : IChatService
{
    private readonly AppDbContext _db;
    private readonly  ILogger<ChatService> _logger;
    public ChatService(AppDbContext db, ILogger<ChatService> logger)
    {
        _db = db;
        _logger= logger;
    }
    
    
    public List<ClientDto> GetChats()
    {
        var chats = _db.Chats.Select(g => new ClientDto
        {
            Id = g.Id,
            Name = g.Name,
            Description = g.Description
        }).ToList();
        return chats;
    }

    public ClientDto? GetById(int id)
    {
        var chat = _db.Chats.FirstOrDefault(c => c.Id == id);
        if (chat == null)
        {
            return null;
        }
        var chatDto = new ClientDto
        {
            Id = chat.Id,
            Name =chat.Name,
            Description = chat.Description
        };
        return chatDto;
    }

    public ClientDto Post(CreateChatDto createChatDto)
    {
        var newChat = new Chat
        {
            Id = 0,
            Name = createChatDto.Name,
            Description = createChatDto.Description

        };
        _db.Chats.Add(newChat);
        _db.SaveChanges();
        var chatDto = new ClientDto
        {
            Id= newChat.Id,
            Name = newChat.Name,
            Description = newChat.Description
        };
        return chatDto;
    }

    public ClientDto? Put(int id, UpdateChatDto updateChatDto)
    {
        Chat? chicken = _db.Chats.FirstOrDefault(c => c.Id == id);
        if (chicken == null)
        {
            return null;
        }
        chicken.Name = updateChatDto.Name;
        chicken.Description = updateChatDto.Description;
        _db.SaveChanges();
        var result = new ClientDto()
        {
            Id = chicken.Id,
            Name = chicken.Name,
            Description = chicken.Description
        };
        return result;
    }

    public bool Delete(int id)
    {
        var chat = _db.Chats.FirstOrDefault(c => c.Id == id);

        if (chat == null)
        {
            return false;
        }
        _db.Chats.Remove(chat);
        _db.SaveChanges();
        return true;
    }
}