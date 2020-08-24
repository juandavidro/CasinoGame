using CasinoGame.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasinoGame.Models
{
    public class BetForCreation
    {
        public int BetNumber { get; set; }
        public string BetColor { get; set; }
        public int BetValue { get; set; }
        public Guid UserId { get; set; }
    }
}
