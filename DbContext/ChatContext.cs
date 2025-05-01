using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatContext.Models;
using Npgsql.EntityFrameworkCore.PostgreSQL;

public class ChatContext : DbC
{
    public DbSet<Chats> Chats { get; set; }
}