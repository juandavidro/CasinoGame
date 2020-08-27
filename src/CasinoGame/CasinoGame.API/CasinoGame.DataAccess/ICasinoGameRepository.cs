using CasinoGame.API.CasinoGame.DataAccess.Entities;
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
        bool UserExists(Guid userId);
        bool RouletteIsCreated(Guid rouletteId);
        bool RouletteIsOpen(Guid rouletteId);
        bool IsBetValid(Bet bet);
        void AddUser(User user);
        bool RouletteExists(Guid rouletteId);
        bool Save();
        IEnumerable<Roulette> GetRoulettes();
        Roulette GetRoulette(Guid rouletteId);
        Roulette AddRoulette(Roulette roulette);
        IEnumerable<Bet> GetBets(Guid rouletteId);
        Bet GetBet(Guid rouletteId, Guid betId);
        void AddBet(Guid rouletteId, Bet bet);
        void UpdateRoulette(Roulette roulette);
    }
}
