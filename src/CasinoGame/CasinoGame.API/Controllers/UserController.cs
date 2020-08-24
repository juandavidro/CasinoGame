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
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly ICasinoGameRepository _casinoRepository;
        private readonly IMapper _mapper;
        public UserController(ICasinoGameRepository casinoRepository, IMapper mapper)
        {
            _casinoRepository = casinoRepository;
            _mapper = mapper;
        }
        [HttpGet()]
        public ActionResult<IEnumerable<UserDto>> GetUsers()
        {
            var usersFromRepos = _casinoRepository.GetUsers();
            return Ok(_mapper.Map<IEnumerable<UserDto>>(usersFromRepos));
        }
        [HttpGet("{userId}", Name = "GetUser")]
        public IActionResult GetUser(Guid userId)
        {
            var userFromRepo = _casinoRepository.GetUser(userId);
            if (userFromRepo == null){ return NotFound(); }
            
            return Ok(userFromRepo);
        }
        [HttpPost]
        public ActionResult<UserDto> CreateUser(UserForCreationDto user)
        {
            var userEntity = _mapper.Map<User>(user);
            _casinoRepository.AddUser(userEntity);
            _casinoRepository.Save();
            var userReturn = _mapper.Map<UserDto>(userEntity);

            return CreatedAtRoute("GetUser",
                new { userId = userReturn.Id}, 
                userReturn);
        }

    }
}
