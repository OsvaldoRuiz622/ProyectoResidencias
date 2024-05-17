﻿using Microsoft.AspNetCore.Mvc;
using AccesoDatos.Models;
using AccesoDatos.Operaciones;
using System;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class FormularioHardwareController : ControllerBase
    {
        private FormularioHardwareDAO formularioHardwareDAO = new FormularioHardwareDAO();

        [HttpGet("formularioshardware")]
        public List<dynamic> GetFormulariosHardware()
        {

            return formularioHardwareDAO.SeleccionarTodos();
        }

        [HttpGet("formularioshardware/{id}")]
        public IActionResult GetFormularioHardware(int id)
        {
            var formularioHardware = formularioHardwareDAO.SeleccionarPorId(id);
            if (formularioHardware != null)
            {
                return Ok(formularioHardware);
            }
            else
            {
                return NotFound("Formulario de hardware no encontrado.");
            }
        }

        [HttpPost("formularioshardware")]
        public IActionResult InsertarFormularioHardware([FromBody] FormularioHardware formularioHardware)
        {
            try
            {
                if (formularioHardwareDAO.Insertar(formularioHardware.Cantidad, formularioHardware.Marca, formularioHardware.NoSerie, formularioHardware.DescripcionHard, formularioHardware.Condicion, formularioHardware.ObservacionPre, formularioHardware.ObservacionPost, formularioHardware.FechaPreHard, formularioHardware.FechaPostHard, formularioHardware.EstatusHard, formularioHardware.IdSolicitanteHard, formularioHardware.IdOperador))
                {
                    return Ok("Formulario de hardware insertado con éxito.");
                }
                else
                {
                    return BadRequest("Error al insertar el formulario de hardware.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }

        [HttpPut("formularioshardware/{id}")]
        public IActionResult ActualizarFormularioHardware(int id, [FromBody] FormularioHardware formularioHardware)
        {
            try
            {
                if (formularioHardwareDAO.Actualizar(id, formularioHardware.Cantidad, formularioHardware.Marca, formularioHardware.NoSerie, formularioHardware.DescripcionHard, formularioHardware.Condicion, formularioHardware.ObservacionPre, formularioHardware.ObservacionPost, formularioHardware.FechaPreHard, formularioHardware.FechaPostHard, formularioHardware.EstatusHard, formularioHardware.IdSolicitanteHard, formularioHardware.IdOperador))
                {
                    return Ok("Formulario de hardware actualizado con éxito.");
                }
                else
                {
                    return NotFound("Formulario de hardware no encontrado.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }

        [HttpDelete("formularioshardware/{id}")]
        public IActionResult EliminarFormularioHardware(int id)
        {
            try
            {
                if (formularioHardwareDAO.Eliminar(id))
                {
                    return Ok("Formulario de hardware eliminado con éxito.");
                }
                else
                {
                    return NotFound("Formulario de hardware no encontrado.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }
    }
}
