using AutoMapper;
using CasinoGame.DataAccess;
using CasinoGame.DataAccess.Entities;
using CasinoGame.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasinoGame.API.Controllers
{
    [ApiController]
    [Route("api/roulette/{rouletteId}/bets")]
    public class BetController : ControllerBase
    {
        private readonly ICasinoGameRepository _casinoRepository;
        private readonly IMapper _mapper;
        public BetController(ICasinoGameRepository casinoGameRepository, IMapper mapper)
        {
            _casinoRepository = casinoGameRepository;
            _mapper = mapper;
        }
        [HttpGet()]
        public ActionResult<IEnumerable<BetDto>> GetBetsForRoulette(Guid rouletteId)
        {
            if (!_casinoRepository.RouletteExists(rouletteId))
            { return NotFound(); }
            var betsFromRepo = _casinoRepository.GetBets(rouletteId);

            return Ok(_mapper.Map<IEnumerable<BetDto>>(betsFromRepo));
        }
        [HttpGet("{betId}", Name = "GetBetForRoulette")]
        public ActionResult<IEnumerable<BetDto>> GetBetForRoulette(Guid rouletteId, Guid betId)
        {
            //if (!_casinoRepository.RouletteExists(rouletteId))
            //{                return NotFound();            }
            var betFromRepo = _casinoRepository.GetBet(rouletteId, betId);
            //if (betId == null) { return NotFound(); }

            return Ok(betFromRepo);
        }
        [HttpPost]
        public ActionResult<BetDto> CreateBetForRoulette(
            Guid rouletteId, BetForCreation bet)
        {
            if (!_casinoRepository.RouletteExists(rouletteId))
            { return NotFound("La ruleta no existe"); }
            if (!_casinoRepository.RouletteIsOpen(rouletteId)) 
            { return BadRequest("La ruleta no se encuentra abierta"); }
            var betEntity = _mapper.Map<Bet>(bet);
            if (!_casinoRepository.UserExists(bet.UserId)) 
            { return NotFound("El usuario no existe"); }
            if (!_casinoRepository.IsBetValid(betEntity)) 
            { return BadRequest("Verifique los valores de la apuesta"); }            
            _casinoRepository.AddBet(rouletteId, betEntity);
            _casinoRepository.Save();

            return Ok("Se realizo la apuesta exitosamente");
        }
    }
}
