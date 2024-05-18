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

        [HttpGet("formulariossoftware")]
        public List<dynamic> GetFormulariosSoftware()
        {
            
            return formularioSoftwareDAO.SeleccionarTodos();
        }

        [HttpGet("formulariossoftware/{id}")]
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

        [HttpPost("formulariossoftware")]
        public IActionResult InsertarFormularioSoftware([FromBody] FormularioSoftware formularioSoftware)
        {
            try
            {
                if (formularioSoftwareDAO.Insertar(formularioSoftware.Descripcion, formularioSoftware.NombreArchivo, formularioSoftware.FileData, formularioSoftware.FechaPre, formularioSoftware.FechaPost, formularioSoftware.Estatus, formularioSoftware.IdSolicitanteSoft, formularioSoftware.IdOperador))
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

        [HttpPut("formulariossoftware/{id}")]
        public IActionResult ActualizarFormularioSoftware(int id, [FromBody] FormularioSoftware formularioSoftware)
        {
            try
            {
                if (formularioSoftwareDAO.Actualizar(id, formularioSoftware.Descripcion, formularioSoftware.NombreArchivo, formularioSoftware.FileData, formularioSoftware.FechaPre, formularioSoftware.FechaPost, formularioSoftware.Estatus, formularioSoftware.IdSolicitanteSoft, formularioSoftware.IdOperador))
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
        [HttpGet("formulariossoftware/nombrearchivo-filedata")]
        public IActionResult GetNombreArchivoYFileData()
        {
            var resultados = formularioSoftwareDAO.SeleccionarNombreArchivoYFileData();
            return Ok(resultados);
        }

        [HttpDelete("formulariossoftware/{id}")]
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
