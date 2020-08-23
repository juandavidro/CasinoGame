using CasinoGame.DataAccess;
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
        public UserController(ICasinoGameRepository casinoRepository)
        {
            _casinoRepository = casinoRepository;
        }
        [HttpGet()]
        public IActionResult GetUsers()
        {
            var users = _casinoRepository.GetUsers();
            return new JsonResult(users);
        }
    }
}
