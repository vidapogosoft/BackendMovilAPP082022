using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Backend.App.Interface;
using Model.APP.Models.Database;

namespace Backend.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistradosController : ControllerBase
    {
        private readonly IGetRegistrados _getRegister;
        private readonly IPostRegistrados _postRegister;

        public RegistradosController(IGetRegistrados getRegister, IPostRegistrados postRegister)
        {
            _getRegister = getRegister;
            _postRegister = postRegister;
        }

        [HttpGet]
        public IActionResult GetregistradoAll()
        {
            return Ok(_getRegister.GetregistradoAll);
        }

        [HttpPost]
        public IActionResult PostRegistrado([FromBody] Registrado item)
        {
            try
            {
                if (item == null || !ModelState.IsValid)
                {
                    return BadRequest("Error: Envio de datos");
                }

                //continuo con el registro de datos

                _postRegister.PostRegistrado(item);

            }
            catch (Exception ex)
            {
                return BadRequest("Error:" + ex.Message);
            }

            return Ok(item);

        }

    }
}
