using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBAPI_Cliente.Modelo.DTO;
using WEBAPI_Cliente.Repository;

namespace WEBAPI_Cliente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        protected ResponseDto _response;
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _response = new ResponseDto();
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(UserDto user)
        {
            var respuesta = await _userRepository.Register(
                    new Modelo.User
                    {
                        UserName = user.Username
                    }, user.Password);
            if (respuesta == -1)
            {
                _response.IsSucces = false;
                _response.DisplayMessage = "Usuario ya existe";
                return BadRequest(_response);
            }
            if (respuesta == -500)
            {
                _response.IsSucces = false;
                _response.DisplayMessage = "Error al crear el usuario";
                return BadRequest(_response);
            }
            _response.DisplayMessage = "Usuario Creado con Exito";
            _response.Result = respuesta;
            return Ok(_response);
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(UserDto user)
        {
            var respuesta = await _userRepository.Login(user.Username, user.Password);

            if (respuesta == "Nouser")
            {
                _response.IsSucces = false;
                _response.DisplayMessage = "Usuario no existe";
                return BadRequest(_response);
            }
            if (respuesta == "Wrongpassword")
            {
                _response.IsSucces = false;
                _response.DisplayMessage = "Password Incorrecta";
                return BadRequest(_response);
            }

            return Ok("Usuario Conectado");
        }
    }
}
