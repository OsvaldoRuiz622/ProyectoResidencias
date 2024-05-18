using AccesoDatos.Context;
using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccesoDatos.Operaciones
{
    public class FormularioSoftwareDAO
    {
        private SistemaTicketsVersionDosContext contexto;

        public FormularioSoftwareDAO()
        {
            contexto = new SistemaTicketsVersionDosContext();
        }

        // Método para seleccionar todos los formularios de software
        public List<dynamic> SeleccionarTodos()
        {
            var formulariosSoftware = new List<dynamic>();
            var formularioSoftwareList = contexto.FormularioSoftwares.ToList();

            foreach (var formularioSoftware in formularioSoftwareList)
            {
                var solicitante = ObtenerSolicitantePorId(formularioSoftware.IdSolicitanteSoft);
                var formularioSoftwareDTO = new
                {
                    formularioSoftware.IdFormularioSoftware,
                    formularioSoftware.Descripcion,
                    formularioSoftware.NombreArchivo,
                    formularioSoftware.FechaPre,
                    formularioSoftware.FechaPost,
                    formularioSoftware.Estatus,
                    Solicitante = solicitante != null ? new
                    {
                        solicitante.NombreSolicitanteSoft,
                        solicitante.CorreoSoft,
                        solicitante.TipoSolicitanteSoft,
                        solicitante.AreaSoft,
                        solicitante.TipoFalloSoft
                    } : null
                };
                formulariosSoftware.Add(formularioSoftwareDTO);
            }

            return formulariosSoftware;
        }

        // Método para seleccionar un formulario de software en específico por ID
        public dynamic SeleccionarPorId(int id)
        {
            var formularioSoftware = contexto.FormularioSoftwares.FirstOrDefault(fs => fs.IdFormularioSoftware == id);
            if (formularioSoftware != null)
            {
                var solicitante = ObtenerSolicitantePorId(formularioSoftware.IdSolicitanteSoft);
                var formularioSoftwareDTO = new
                {
                    formularioSoftware.IdFormularioSoftware,
                    formularioSoftware.Descripcion,
                    formularioSoftware.NombreArchivo,
                    formularioSoftware.FechaPre,
                    formularioSoftware.FechaPost,
                    formularioSoftware.Estatus,
                    Solicitante = solicitante != null ? new
                    {
                        solicitante.CorreoSoft,
                        solicitante.TipoSolicitanteSoft,
                        solicitante.TipoFalloSoft
                    } : null
                };
                return formularioSoftwareDTO;
            }
            else
            {
                return null;
            }
        }

        // Método para seleccionar solo los campos NombreArchivo y FileData
        public List<dynamic> SeleccionarNombreArchivoYFileData()
        {
            var resultados = new List<dynamic>();

            try
            {
                var formulariosSoftware = contexto.FormularioSoftwares.ToList();

                foreach (var formularioSoftware in formulariosSoftware)
                {
                    var resultado = new
                    {
                        formularioSoftware.IdFormularioSoftware,
                        formularioSoftware.NombreArchivo,
                        formularioSoftware.FileData,
                        formularioSoftware.Estatus
                    };
                    resultados.Add(resultado);
                }
            }
            catch (Exception ex)
            {
                // Manejar errores aquí
            }

            return resultados;
        }


        // Método para insertar un nuevo formulario de software
        public bool Insertar(string descripcion, string nombreArchivo, byte[] fileData, DateTime? fechaPre, DateTime? fechaPost, bool? estatus, int idSolicitanteSoft, int idOperador)
        {
            try
            {
                FormularioSoftware nuevoFormularioSoftware = new FormularioSoftware
                {
                    Descripcion = descripcion,
                    NombreArchivo = nombreArchivo,
                    FileData = fileData,
                    FechaPre = fechaPre,
                    FechaPost = fechaPost,
                    Estatus = estatus,
                    IdSolicitanteSoft = idSolicitanteSoft,
                    IdOperador = idOperador
                };

                contexto.FormularioSoftwares.Add(nuevoFormularioSoftware);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Manejar errores aquí
                return false;
            }
        }

        // Método para actualizar un formulario de software existente
        public bool Actualizar(int id, string nuevaDescripcion, string nuevoNombreArchivo, byte[] nuevoFileData, DateTime? nuevaFechaPre, DateTime? nuevaFechaPost, bool? nuevoEstatus, int nuevoIdSolicitanteSoft, int nuevoIdOperador)
        {
            try
            {
                var formularioSoftware = contexto.FormularioSoftwares.FirstOrDefault(fs => fs.IdFormularioSoftware == id);
                if (formularioSoftware != null)
                {
                    formularioSoftware.Descripcion = nuevaDescripcion;
                    formularioSoftware.NombreArchivo = nuevoNombreArchivo;
                    formularioSoftware.FileData = nuevoFileData;
                    formularioSoftware.FechaPre = nuevaFechaPre;
                    formularioSoftware.FechaPost = nuevaFechaPost;
                    formularioSoftware.Estatus = nuevoEstatus;
                    formularioSoftware.IdSolicitanteSoft = nuevoIdSolicitanteSoft;
                    formularioSoftware.IdOperador = nuevoIdOperador;

                    contexto.SaveChanges();
                    return true;
                }
                return false; // Formulario de software no encontrado
            }
            catch (Exception ex)
            {
                // Manejar errores aquí
                return false;
            }
        }

        // Método para eliminar un formulario de software
        public bool Eliminar(int id)
        {
            try
            {
                var formularioSoftware = contexto.FormularioSoftwares.FirstOrDefault(fs => fs.IdFormularioSoftware == id);
                if (formularioSoftware != null)
                {
                    contexto.FormularioSoftwares.Remove(formularioSoftware);
                    contexto.SaveChanges();
                    return true;
                }
                return false; // Formulario de software no encontrado
            }
            catch (Exception ex)
            {
                // Manejar errores aquí
                return false;
            }
        }

        // Método para obtener un solicitante por su ID
        private SolicitanteSoft ObtenerSolicitantePorId(int id)
        {
            return contexto.SolicitanteSofts.FirstOrDefault(s => s.IdSolicitanteSoft == id);
        }

        public object ObtenerSolicitantePorId(dynamic idSolicitanteSoft)
        {
            throw new NotImplementedException();
        }
    }
}
