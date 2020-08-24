using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CasinoGame.DataAccess.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTimeOffset LoginDate { get; set; }
        public bool Credit { get; set; }
        public ICollection<Bet> Bets { get; set; }
            = new List<Bet>();
    }
}
