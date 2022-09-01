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

        [HttpGet]
        [Route("dto")]
        public IActionResult GetDTORegistradoAll()
        {
            return Ok(_getRegister.GetDTORegistradoAll);
        }


        [HttpGet]
        [Route("sp")]
        public IActionResult GetSPRegistradoDirecciones()
        {
            return Ok(_getRegister.GetSPRegistradoDirecciones);
        }

        [HttpGet]
        [Route("dni/{identificacion}")]
        public IActionResult GetSPRegistradoDireccion(string identificacion)
        {
            return Ok(_getRegister.GetSPRegistradoDireccion(identificacion));
        }

        [HttpGet]
        [Route("object1/{idregistrado}")]
        public IActionResult GetRegistradoObjectById(int idregistrado)
        {
            return Ok(_getRegister.GetRegistradoObjectById(idregistrado));
        }

        
        [HttpGet]
        [Route("object2/{identificacion}")]
        public IActionResult GetRegistradoObjetcByIdentificacion(string identificacion)
        {
            return Ok(_getRegister.GetRegistradoObjetcByIdentificacion(identificacion));
        }

        [HttpGet]
        [Route("{idregistrado}/{identificacion}")]
        public IActionResult GetRegistradoByIdIdentificacion(int idregistrado, string identificacion)
        {
            return Ok(_getRegister.GetregistradoAll);
        }

        [HttpGet]
        [Route("v2/{idregistrado}/{identificacion}")]
        public IActionResult GetRegistradoByIdIdentificacion2(int idregistrado, string identificacion)
        {
            return Ok(_getRegister.GetregistradoAll);
        }

        [HttpGet]
        [Route("v3/{idregistrado}/{identificacion}")]
        public IActionResult GetRegistradoByIdIdentificacion3(int idregistrado, string identificacion)
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

        [HttpPost]
        [Route("post/{identificacion}/{nombres}/{apellidos}")]
        public IActionResult PostSPRegistrado(string identificacion, string nombres, string apellidos)
        {
            return Ok(_postRegister.PostSPRegistrado(identificacion, nombres, apellidos));
        }

        [HttpPut]
        [Route("UpdateObject")]
        public IActionResult UpdateRegistradoObject([FromBody] Registrado item)
        {
            try
            {
                if (item == null || !ModelState.IsValid)
                {
                    return BadRequest("Error: Envio de datos");
                }

                //continuo con el update de datos

                _postRegister.UpdateRegistradoObject(item);

            }
            catch (Exception ex)
            {
                return BadRequest("Error:" + ex.Message);
            }

            return Ok(item);

        }

        [HttpPut]
        [Route("UpdateParam/{IdRegistrado}/{Identificacion}/{Nombres}/{Apellidos}")]
        public IActionResult UpdateRegistradoParam(int IdRegistrado, string Identificacion,
                string Nombres, string Apellidos)
        {
            try
            {
                //continuo con el update de datos

                _postRegister.UpdateRegistradoParam(IdRegistrado, Identificacion,
                 Nombres, Apellidos);

            }
            catch (Exception ex)
            {
                return BadRequest("Error:" + ex.Message);
            }

            return NoContent();

        }

        [HttpDelete]
        [Route("DeleteObject")]
        public IActionResult DeleteRegistradoObject([FromBody] Registrado item)
        {
            try
            {
                if (item == null || !ModelState.IsValid)
                {
                    return BadRequest("Error: Envio de datos");
                }

                //continuo con el borrado de datos

                _postRegister.DeleteRegistradoObject(item);

            }
            catch (Exception ex)
            {
                return BadRequest("Error:" + ex.Message);
            }

            return Ok(item);

        }

        [HttpDelete]
        [Route("DeleteParam/{IdRegistrado}")]
        public IActionResult DeleteRegistradoParam(int IdRegistrado)
        {
            try
            {
               
                //continuo con el borrado de datos

                _postRegister.DeleteRegistradoParam(IdRegistrado);

            }
            catch (Exception ex)
            {
                return BadRequest("Error:" + ex.Message);
            }

            return NoContent();

        }

    }
}
