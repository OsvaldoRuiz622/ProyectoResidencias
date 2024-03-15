using Microsoft.AspNetCore.Mvc;
using AccesoDatos.Models;
using AccesoDatos.Operaciones;
using System;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class OperadorController : ControllerBase
    {
        private OperadorDAO operadorDAO = new OperadorDAO();

        [HttpGet("operadores")]
        public List<Operador> GetOperadores()
        {
            return operadorDAO.SeleccionarTodos();
        }

        [HttpGet("operador")]
        public IActionResult GetOperador(int id)
        {
            var operador = operadorDAO.SeleccionarPorId(id);
            if (operador != null)
            {
                return Ok(operador);
            }
            else
            {
                return NotFound("Operador no encontrado.");
            }
        }

        [HttpPost("operador")]
        public IActionResult InsertarOperador([FromBody] Operador operador)
        {
            try
            {
                if (operadorDAO.Insertar(operador.Usuario, operador.Contraseña, operador.Cargo))
                {
                    return Ok("Operador insertado con éxito.");
                }
                else
                {
                    return BadRequest("Error al insertar el operador.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }

        [HttpPut("operador/{id}")]
        public IActionResult ActualizarOperador(int id, [FromBody] Operador operador)
        {
            try
            {
                if (operadorDAO.Actualizar(id, operador.Usuario, operador.Contraseña, operador.Cargo))
                {
                    return Ok("Operador actualizado con éxito.");
                }
                else
                {
                    return NotFound("Operador no encontrado.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }

        [HttpDelete("operador/{id}")]
        public IActionResult EliminarOperador(int id)
        {
            try
            {
                if (operadorDAO.Eliminar(id))
                {
                    return Ok("Operador eliminado con éxito.");
                }
                else
                {
                    return NotFound("Operador no encontrado.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }
    }
}
