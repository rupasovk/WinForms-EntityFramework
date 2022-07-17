using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;

namespace WinForms_EntityFramework
{
    public class DbRepository : DbContext
    {
        public DbRepository() : base("Server=(localdb)\\mssqllocaldb;Database=EFdbPlayers;Trusted_Connection=True;") { }

        public DbSet<Player> Players { get; set; }

    }
}
