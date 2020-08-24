using System;
using System.Collections.Generic;
using System.Text;

namespace CasinoGame.Models
{
    public class RouletteDto
    {
        public Guid RouletteId { get; set; }
        public string State { get; set; }
        public DateTimeOffset CreationDate { get; set; }
    }
}
