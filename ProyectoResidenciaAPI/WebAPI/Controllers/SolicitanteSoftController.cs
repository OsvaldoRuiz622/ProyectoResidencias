using Microsoft.AspNetCore.Mvc;
using AccesoDatos.Models;
using AccesoDatos.Operaciones;
using System;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class SolicitanteSoftController : ControllerBase
    {
        private SolicitanteSoftDAO solicitanteSoftDAO = new SolicitanteSoftDAO();

        [HttpGet("solicitantessoft")]
        public List<SolicitanteSoft> GetSolicitantesSoft()
        {
            return solicitanteSoftDAO.SeleccionarTodos();
        }

        [HttpGet("solicitantessoft/{id}")]
        public IActionResult GetSolicitanteSoft(int id)
        {
            var solicitanteSoft = solicitanteSoftDAO.SeleccionarPorId(id);
            if (solicitanteSoft != null)
            {
                return Ok(solicitanteSoft);
            }
            else
            {
                return NotFound("Solicitante de software no encontrado.");
            }
        }

        [HttpPost("solicitantessoft")]
        public IActionResult InsertarSolicitanteSoft([FromBody] SolicitanteSoft solicitanteSoft)
        {
            try
            {
                if (solicitanteSoftDAO.Insertar(solicitanteSoft.NombreSolicitanteSoft, solicitanteSoft.CorreoSoft, solicitanteSoft.TipoSolicitanteSoft, solicitanteSoft.AreaSoft, solicitanteSoft.TipoFalloSoft))
                {
                    return Ok("Solicitante de software insertado con éxito.");
                }
                else
                {
                    return BadRequest("Error al insertar el solicitante de software.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }

        [HttpPut("solicitantessoft/{id}")]
        public IActionResult ActualizarSolicitanteSoft(int id, [FromBody] SolicitanteSoft solicitanteSoft)
        {
            try
            {
                if (solicitanteSoftDAO.Actualizar(id, solicitanteSoft.NombreSolicitanteSoft, solicitanteSoft.CorreoSoft, solicitanteSoft.TipoSolicitanteSoft, solicitanteSoft.AreaSoft, solicitanteSoft.TipoFalloSoft))
                {
                    return Ok("Solicitante de software actualizado con éxito.");
                }
                else
                {
                    return NotFound("Solicitante de software no encontrado.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }

        [HttpDelete("solicitantessoft/{id}")]
        public IActionResult EliminarSolicitanteSoft(int id)
        {
            try
            {
                if (solicitanteSoftDAO.Eliminar(id))
                {
                    return Ok("Solicitante de software eliminado con éxito.");
                }
                else
                {
                    return NotFound("Solicitante de software no encontrado.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }
    }
}
