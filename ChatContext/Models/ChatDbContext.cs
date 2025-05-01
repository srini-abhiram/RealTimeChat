using System.Data.Common;
using ChatDbContext.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatDbContext.Models
{
    public class ChatContext : DbContext
    {
        public ChatContext(DbContextOptions<ChatContext> options): base(options)
        {
        }

        public DbSet<Chats> Chats { get; set; }
    }
}
