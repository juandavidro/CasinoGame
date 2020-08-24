using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CasinoGame.DataAccess.Entities
{
    public class Roulette
    {
        [Key]
        public Guid RouletteId { get; set; }
        public string State { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public DateTimeOffset OpenDate { get; set; }
        public DateTimeOffset CloseDate { get; set; }
        public ICollection<Bet> Bets { get; set; }
            = new List<Bet>();
    }
}
