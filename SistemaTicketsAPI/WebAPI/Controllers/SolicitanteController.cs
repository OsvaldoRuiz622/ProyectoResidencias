using Microsoft.AspNetCore.Mvc;
using AccesoDatos.Models;
using AccesoDatos.Operaciones;
using System;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class SolicitanteController : ControllerBase
    {
        private SolicitanteDAO solicitanteDAO = new SolicitanteDAO();

        [HttpGet("solicitantes")]
        public List<Solicitante> GetSolicitantes()
        {
            return solicitanteDAO.SeleccionarTodos();
        }

        [HttpGet("solicitante")]
        public IActionResult GetSolicitante(int id)
        {
            var solicitante = solicitanteDAO.SeleccionarPorId(id);
            if (solicitante != null)
            {
                return Ok(solicitante);
            }
            else
            {
                return NotFound("Solicitante no encontrado.");
            }
        }

        [HttpPost("solicitante")]
        public IActionResult InsertarSolicitante([FromBody] Solicitante solicitante)
        {
            try
            {
                if (solicitanteDAO.Insertar(solicitante.NombreSolicitante, solicitante.Correo, solicitante.TipoSolicitante, solicitante.Area, solicitante.TipoFallo))
                {
                    return Ok("Solicitante insertado con éxito.");
                }
                else
                {
                    return BadRequest("Error al insertar el solicitante.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }

        [HttpPut("solicitante/{id}")]
        public IActionResult ActualizarSolicitante(int id, [FromBody] Solicitante solicitante)
        {
            try
            {
                if (solicitanteDAO.Actualizar(id, solicitante.NombreSolicitante, solicitante.Correo, solicitante.TipoSolicitante, solicitante.Area, solicitante.TipoFallo))
                {
                    return Ok("Solicitante actualizado con éxito.");
                }
                else
                {
                    return NotFound("Solicitante no encontrado.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }

        [HttpDelete("solicitante/{id}")]
        public IActionResult EliminarSolicitante(int id)
        {
            try
            {
                if (solicitanteDAO.Eliminar(id))
                {
                    return Ok("Solicitante eliminado con éxito.");
                }
                else
                {
                    return NotFound("Solicitante no encontrado.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }
    }
}
