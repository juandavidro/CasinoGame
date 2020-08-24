using CasinoGame.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasinoGame.DataAccess.DbContexts
{
    public class CasinoGameContext : DbContext
    {
         public CasinoGameContext(DbContextOptions<CasinoGameContext> options) 
            : base(options)
        {
        }

        public DbSet<Roulette> Roulettes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Bet> Bets { get; set; }
    }
}
