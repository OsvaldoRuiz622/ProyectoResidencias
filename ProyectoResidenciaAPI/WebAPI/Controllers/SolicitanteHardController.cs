using Microsoft.AspNetCore.Mvc;
using AccesoDatos.Models;
using AccesoDatos.Operaciones;
using System;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class SolicitanteHardController : ControllerBase
    {
        private SolicitanteHardDAO solicitanteHardDAO = new SolicitanteHardDAO();

        [HttpGet("solicitanteshard")]
        public List<SolicitanteHard> GetSolicitantesHard()
        {
            return solicitanteHardDAO.SeleccionarTodos();
        }

        [HttpGet("solicitanteshard/{id}")]
        public IActionResult GetSolicitanteHard(int id)
        {
            var solicitanteHard = solicitanteHardDAO.SeleccionarPorId(id);
            if (solicitanteHard != null)
            {
                return Ok(solicitanteHard);
            }
            else
            {
                return NotFound("Solicitante de hardware no encontrado.");
            }
        }

        [HttpPost("solicitanteshard")]
        public IActionResult InsertarSolicitanteHard([FromBody] SolicitanteHard solicitanteHard)
        {
            try
            {
                if (solicitanteHardDAO.Insertar(solicitanteHard.NombreSolicitanteHard, solicitanteHard.CorreoHard, solicitanteHard.TipoSolicitanteHard, solicitanteHard.AreaHard, solicitanteHard.TipoFalloHard))
                {
                    return Ok("Solicitante de hardware insertado con éxito.");
                }
                else
                {
                    return BadRequest("Error al insertar el solicitante de hardware.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }

        [HttpPut("solicitanteshard/{id}")]
        public IActionResult ActualizarSolicitanteHard(int id, [FromBody] SolicitanteHard solicitanteHard)
        {
            try
            {
                if (solicitanteHardDAO.Actualizar(id, solicitanteHard.NombreSolicitanteHard, solicitanteHard.CorreoHard, solicitanteHard.TipoSolicitanteHard, solicitanteHard.AreaHard, solicitanteHard.TipoFalloHard))
                {
                    return Ok("Solicitante de hardware actualizado con éxito.");
                }
                else
                {
                    return NotFound("Solicitante de hardware no encontrado.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }

        [HttpDelete("solicitanteshard/{id}")]
        public IActionResult EliminarSolicitanteHard(int id)
        {
            try
            {
                if (solicitanteHardDAO.Eliminar(id))
                {
                    return Ok("Solicitante de hardware eliminado con éxito.");
                }
                else
                {
                    return NotFound("Solicitante de hardware no encontrado.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }
    }
}
