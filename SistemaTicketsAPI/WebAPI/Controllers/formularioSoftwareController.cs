using Microsoft.AspNetCore.Mvc;
using AccesoDatos.Models;
using AccesoDatos.Operaciones;
using System;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class FormularioSoftwareController : ControllerBase
    {
        private FormularioSoftwareDAO formularioSoftwareDAO = new FormularioSoftwareDAO();

        [HttpGet("formulariosoftware")]
        public List<dynamic> GetFormulariosSoftware()
        {
            var formulariosSoftware = new List<dynamic>();
            var formularioSoftwareList = formularioSoftwareDAO.SeleccionarTodos();

            foreach (var formularioSoftware in formularioSoftwareList)
            {
                var solicitante = formularioSoftwareDAO.ObtenerSolicitantePorId(formularioSoftware.IdSolicitante);
                var formularioSoftwareDTO = new
                {
                    formularioSoftware.IdFormularioSoftware,
                    formularioSoftware.Descripcion,
                    formularioSoftware.Imagen,
                    formularioSoftware.FechaPre,
                    formularioSoftware.FechaPost,
                    Solicitante = new
                    {
                        solicitante.NombreSolicitante,
                        solicitante.TipoSolicitante
                    }
                };
                formulariosSoftware.Add(formularioSoftwareDTO);
            }

            return formulariosSoftware;
        }


        [HttpGet("formulariosoftware/{id}")]
        public IActionResult GetFormularioSoftware(int id)
        {
            var formularioSoftware = formularioSoftwareDAO.SeleccionarPorId(id);
            if (formularioSoftware != null)
            {
                return Ok(formularioSoftware);
            }
            else
            {
                return NotFound("Formulario de software no encontrado.");
            }
        }

        [HttpPost("formulariosoftware")]
        public IActionResult InsertarFormularioSoftware([FromBody] FormularioSoftware formularioSoftware)
        {
            try
            {
                if (formularioSoftwareDAO.Insertar(formularioSoftware.Descripcion, formularioSoftware.Imagen, formularioSoftware.FechaPre, formularioSoftware.FechaPost, formularioSoftware.IdSolicitante, formularioSoftware.IdOperador))
                {
                    return Ok("Formulario de software insertado con éxito.");
                }
                else
                {
                    return BadRequest("Error al insertar el formulario de software.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }

        [HttpPut("formulariosoftware/{id}")]
        public IActionResult ActualizarFormularioSoftware(int id, [FromBody] FormularioSoftware formularioSoftware)
        {
            try
            {
                if (formularioSoftwareDAO.Actualizar(id, formularioSoftware.Descripcion, formularioSoftware.Imagen, formularioSoftware.FechaPre, formularioSoftware.FechaPost, formularioSoftware.IdSolicitante, formularioSoftware.IdOperador))
                {
                    return Ok("Formulario de software actualizado con éxito.");
                }
                else
                {
                    return NotFound("Formulario de software no encontrado.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }

        [HttpDelete("formulariosoftware/{id}")]
        public IActionResult EliminarFormularioSoftware(int id)
        {
            try
            {
                if (formularioSoftwareDAO.Eliminar(id))
                {
                    return Ok("Formulario de software eliminado con éxito.");
                }
                else
                {
                    return NotFound("Formulario de software no encontrado.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }
    }
}
