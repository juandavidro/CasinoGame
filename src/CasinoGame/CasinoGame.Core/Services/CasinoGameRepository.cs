using CasinoGame.DataAccess;
using CasinoGame.DataAccess.DbContexts;
using CasinoGame.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasinoGame.Core.Services
{
    public class CasinoGameRepository : ICasinoGameRepository, IDisposable
    {
        private readonly CasinoGameContext _context;
        public CasinoGameRepository(CasinoGameContext context)
        {
            _context = context;
        }
        public User GetUser(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(userId));
            }
            return _context.Users.FirstOrDefault(x => x.Id == userId);
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList<User>();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }
    }
}
