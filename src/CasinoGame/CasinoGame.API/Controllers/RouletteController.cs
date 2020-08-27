using AutoMapper;
using CasinoGame.API.CasinoGame.DataAccess.Entities;
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
    [Route("api/roulette")]
    public class RouletteController : ControllerBase
    {
        private readonly ICasinoGameRepository _casinoRepository;
        private IMapper _mapper;
        public RouletteController(ICasinoGameRepository casinoGameRepository, IMapper mapper)
        {
            _casinoRepository = casinoGameRepository;
            _mapper = mapper;
        }
        [HttpGet()]
        public ActionResult<IEnumerable<RouletteDto>> GetRoulettes()
        {
            var roulettesFromRepo = _casinoRepository.GetRoulettes();

            return Ok(_mapper.Map<IEnumerable<RouletteDto>>(roulettesFromRepo));
        }
        [HttpGet("{rouletteId}", Name = "GetRoulette")]
        public IActionResult GetRoulette(Guid rouletteId)
        {
            var rouletteFromRepo = _casinoRepository.GetRoulette(rouletteId);
            if(rouletteFromRepo == null) { return NotFound(); }

            return Ok(_mapper.Map<RouletteDto>(rouletteFromRepo));
        }
        [HttpPost]
        public ActionResult<RouletteDto> CreateRoulette()
        {
            var rouletteEntity = new Roulette();
            var rouletteRepo = _casinoRepository.AddRoulette(rouletteEntity);
            _casinoRepository.Save();
            var rouletteReturn = _mapper.Map<RouletteDto>(rouletteRepo);

            return CreatedAtRoute("GetRoulette",
                new { rouletteId = rouletteReturn.RouletteId },
                rouletteReturn);
        }

        [HttpPut("{rouletteId}/open")]
        public ActionResult OpenRoulette(Guid rouletteId)
        {
            if (!_casinoRepository.RouletteExists(rouletteId))
            { 
                return NotFound(); 
            }
            var rouletteFromRepo = _casinoRepository.GetRoulette(rouletteId);
            if(rouletteFromRepo == null)
            { 
                return NotFound(); 
            }
            if (!_casinoRepository.RouletteIsCreated(rouletteId)) 
            { 
                return BadRequest("La ruleta ya esta abierta o ya se ha cerrado"); 
            }
            var rouletteToUpdate = new RouletteToUpdate();
            rouletteToUpdate.State = "open";
            _mapper.Map(rouletteToUpdate, rouletteFromRepo);
            _casinoRepository.UpdateRoulette(rouletteFromRepo);
            _casinoRepository.Save();

            return Ok("Se abrio la ruleta exitosamente");
        }
        [HttpPut("{rouletteId}/close")]
        public ActionResult<IEnumerable<BetDto>> CloseRoulette(Guid rouletteId)
        {
            if (!_casinoRepository.RouletteExists(rouletteId))
            {
                return NotFound("El ID de ruleta no existe");
            }
            var rouletteFromRepo = _casinoRepository.GetRoulette(rouletteId);
            if (rouletteFromRepo == null)
            {
                return NotFound("No se encontro la ruleta");
            }
            if (_casinoRepository.RouletteIsCreated(rouletteId))
            {
                return BadRequest("La ruleta no esta abierta");
            }
            var rouletteToUpdate = new RouletteToUpdate();
            rouletteToUpdate.State = "close";
            _mapper.Map(rouletteToUpdate, rouletteFromRepo);
            _casinoRepository.UpdateRoulette(rouletteFromRepo);
            _casinoRepository.Save();

            return Ok("La ruleta esta cerrada, consulte: GET Bets By RouletteId");
        }
    }
}
