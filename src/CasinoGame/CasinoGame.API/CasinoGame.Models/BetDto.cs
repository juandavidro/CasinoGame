using CasinoGame.API.CasinoGame.DataAccess.Entities;
using CasinoGame.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasinoGame.Models
{
    public class BetDto
    {
        public Guid BetId { get; set; }
        public int BetNumber { get; set; }
        public string BetColor { get; set; }
        public int BetValue { get; set; }
        public Roulette Roulette { get; set; }
        public User User { get; set; }
    }
}
