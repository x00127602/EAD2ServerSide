using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

//Rachel
namespace GameServerAPI.Models
{
    public class GameServerContext:DbContext
    {
        public GameServerContext(DbContextOptions<GameServerContext> options)
            : base(options)
        {
        }

        public DbSet<GameServerItem> GameServerItems { get; set; }
    }
}
