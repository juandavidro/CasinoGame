using System;
using System.Collections.Generic;
using System.Text;

namespace CasinoGame.Models
{
    public class UserForCreationDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Credit { get; set; }
    }
}
