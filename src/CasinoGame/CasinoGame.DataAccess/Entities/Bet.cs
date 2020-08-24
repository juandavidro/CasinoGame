using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Text;

namespace CasinoGame.DataAccess.Entities
{
    public class Bet
    {
        [Key]
        public Guid BetId { get; set; }        
        public int BetNumber { get; set; }
        public string BetColor { get; set; }
        [Required]
        public int BetValue { get; set; }
        [Required]
        [ForeignKey("RouletteId")]
        public Roulette Roulette { get; set; }
        public Guid RouletteId { get; set; }
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        public User User { get; set; }
        [Required]
        public DateTimeOffset BetDate { get; set; }
    }
}
