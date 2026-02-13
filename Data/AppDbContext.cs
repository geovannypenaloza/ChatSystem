using ChatSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatSystem.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Chat> Chats => Set<Chat>();
    public DbSet<Client> Clients => Set<Client>();
    
}