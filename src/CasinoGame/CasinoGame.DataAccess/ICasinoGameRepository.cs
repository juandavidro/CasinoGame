using CasinoGame.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasinoGame.DataAccess
{
    public interface ICasinoGameRepository
    {
        IEnumerable<User> GetUsers();
        User GetUser(Guid userId);

    }
}
