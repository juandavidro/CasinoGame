using CasinoGame.DataAccess;
using CasinoGame.DataAccess.DbContexts;
using CasinoGame.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
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
        public Roulette GetRoulette(Guid rouletteId)
        {
            if (rouletteId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(rouletteId));
            }

            return _context.Roulettes
                .Where(x => x.RouletteId == rouletteId)
                .SingleOrDefault();
        }
        public Bet GetBet(Guid rouletteId, Guid betId)
        {
            if (rouletteId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(betId));
            }
            if (betId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(betId));
            }

            return _context.Bets
                .Where(b => b.RouletteId == rouletteId && b.BetId == betId).FirstOrDefault();
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList<User>();
        }

        public IEnumerable<Roulette> GetRoulettes()
        {
            return _context.Roulettes.ToList<Roulette>();
        }

        public IEnumerable<Bet> GetBets(Guid rouletteId)
        {
            if (rouletteId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(rouletteId));
            }
            return _context.Bets
                .Where(b => b.RouletteId == rouletteId).ToList();                
        }

        public bool UserExists(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            return _context.Users.Any(a => a.Id == userId);
        }

        public bool RouletteExists(Guid rouletteId)
        {
            if (rouletteId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(rouletteId));
            }

            return _context.Roulettes.Any(r => r.RouletteId == rouletteId);
        }

        public bool IsBetValid(Bet bet)
        {
            if (bet.BetNumber < 0 || bet.BetNumber > 36)
            {
                return false;
            }
            if (bet.BetValue < 0 || bet.BetValue > 10000)
            {
                return false;
            }
            if (bet.BetColor == "negro" || bet.BetColor == "rojo")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool RouletteIsCreated(Guid rouletteId)
        {
            if (rouletteId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(rouletteId));
            }
            var roulette = _context.Roulettes.FirstOrDefault(r => r.RouletteId == rouletteId);
            if(roulette.State == "created")
            { 
                return true; 
            }

            return false;
        }

        public bool RouletteIsOpen(Guid rouletteId)
        {
            if (rouletteId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(rouletteId));
            }
            var roulette = _context.Roulettes.FirstOrDefault(r => r.RouletteId == rouletteId);
            if (roulette.State == "open")
            { 
                return true; 
            }

            return false;
        }

        public void AddUser(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            user.Id = Guid.NewGuid();
            user.LoginDate = DateTimeOffset.Now;
            _context.Users.Add(user);
        }
        public Roulette AddRoulette(Roulette roulette)
        {
            roulette.RouletteId = Guid.NewGuid();
            roulette.CreationDate = DateTimeOffset.Now;
            roulette.State = "created";
            _context.Roulettes.Add(roulette);

            return roulette;
        }
        public void AddBet(Guid rouletteId, Bet bet)
        {
            if(rouletteId == null)
            {
                throw new ArgumentNullException(nameof(rouletteId));
            }
            if (bet == null)
            {
                throw new ArgumentNullException(nameof(bet));
            }
            bet.BetId = Guid.NewGuid();
            bet.RouletteId = rouletteId;
            bet.BetDate = DateTimeOffset.Now;
            _context.Bets.Add(bet);
        }
        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
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

        public void UpdateRoulette(Roulette roulette)
        {
            
        }
    }
}
