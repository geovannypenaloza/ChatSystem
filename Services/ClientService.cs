using ChatSystem.Data;
using ChatSystem.Dto.Chat;
using ChatSystem.Dto.Client;
using ChatSystem.Models;
using ClientDto = ChatSystem.Dto.Client.ClientDto;

namespace ChatSystem.Services;

public interface IClientService
{
    public List<ClientDto> GetClients();
    public ClientDto? GetById(int id);
    public ClientDto Post(CreateClientDto createClientDto);
    public ClientDto? Put(int id, UpdateClientDto updateClientDto);
    public bool Delete(int id);
}

public class ClientService : IClientService
{
    private readonly AppDbContext _db;
    public ClientService(AppDbContext db)
    {
        _db = db;
    }

    public List<ClientDto> GetClients()
    {
        var clients = _db.Clients.Select(g => new ClientDto
        {
            Id = g.Id,
            Name = g.Name,
            Email = g.Email,
            Phone = g.Phone
        }).ToList();
        return clients;
    }

    public ClientDto? GetById(int id)
    {
        var client = _db.Clients.FirstOrDefault(c => c.Id == id);
        if (client == null)
        {
            return null;
        }
        var clientDto = new ClientDto
        {
            Id = client.Id,
            Name =client.Name,
            Email = client.Email,
            Phone = client.Phone
        };
        return clientDto;
    }

    public ClientDto Post(CreateClientDto createClientDto)
    {
        var newClient = new Client
        {
            Id = 0,
            Name = createClientDto.Name,
            Email = createClientDto.Email,
            Phone = createClientDto.Phone

        };
        _db.Clients.Add(newClient);
        _db.SaveChanges();
        var clientDto = new ClientDto
        {
            Id= newClient.Id,
            Name = newClient.Name,
            Email = newClient.Email,
            Phone = newClient.Phone
        };
        return clientDto;
    }

    public ClientDto? Put(int id, UpdateClientDto updateClientDto)
    {
        Client? client = _db.Clients.FirstOrDefault(c => c.Id == id);
        if (client == null)
        {
            return null;
        }
        client.Name = updateClientDto.Name;
        client.Email = updateClientDto.Email;
        client.Phone = updateClientDto.Phone;
        _db.SaveChanges();
        var result = new ClientDto()
        {
            Id = client.Id,
            Name = client.Name,
            Email = client.Email,
            Phone = client.Phone
        };
        return result;
    }

    public bool Delete(int id)
    {
        var client = _db.Clients.FirstOrDefault(c => c.Id == id);

        if (client == null)
        {
            return false;
        }
        _db.Clients.Remove(client);
        _db.SaveChanges();
        return true;
    }
}