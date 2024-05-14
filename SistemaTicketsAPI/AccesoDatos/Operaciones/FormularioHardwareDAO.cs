using AccesoDatos.Context;
using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccesoDatos.Operaciones
{
    public class FormularioHardwareDAO
    {
        private SistemaTicketsContext contexto;

        public FormularioHardwareDAO()
        {
            contexto = new SistemaTicketsContext();
        }

        // Método para seleccionar todos los formularios de hardware
        public List<dynamic> SeleccionarTodos()
        {
            var formulariosHardware = new List<dynamic>();
            var formularioHardwareList = contexto.FormularioHardwares.ToList();

            foreach (var formularioHardware in formularioHardwareList)
            {
                var solicitante = ObtenerSolicitantePorId(formularioHardware.IdSolicitante);
                var formularioHardwareDTO = new
                {
                    formularioHardware.IdFormularioHardware,
                    formularioHardware.Cantidad,
                    formularioHardware.Marca,
                    formularioHardware.NoSerie,
                    formularioHardware.Descripcion,
                    formularioHardware.Condicion,
                    formularioHardware.ObservacionPre,
                    formularioHardware.ObservacionPost,
                    formularioHardware.FechaPre,
                    formularioHardware.FechaPost,
                    Solicitante = new
                    {
                        solicitante.NombreSolicitante,
                        solicitante.TipoSolicitante
                    }
                };
                formulariosHardware.Add(formularioHardwareDTO);
            }

            return formulariosHardware;
        }

        // Método para seleccionar un formulario de hardware en específico por ID
        public dynamic SeleccionarPorId(int id)
        {
            var formularioHardware = contexto.FormularioHardwares.FirstOrDefault(fh => fh.IdFormularioHardware == id);
            if (formularioHardware != null)
            {
                var solicitante = ObtenerSolicitantePorId(formularioHardware.IdSolicitante);
                var formularioHardwareDTO = new
                {
                    formularioHardware.IdFormularioHardware,
                    formularioHardware.Cantidad,
                    formularioHardware.Marca,
                    formularioHardware.NoSerie,
                    formularioHardware.Descripcion,
                    formularioHardware.Condicion,
                    formularioHardware.ObservacionPre,
                    formularioHardware.ObservacionPost,
                    formularioHardware.FechaPre,
                    formularioHardware.FechaPost,
                    Solicitante = new
                    {
                        solicitante.NombreSolicitante,
                        solicitante.TipoSolicitante
                    }
                };
                return formularioHardwareDTO;
            }
            else
            {
                return null;
            }
        }

        // Método para insertar un nuevo formulario de hardware
        public bool Insertar(string cantidad, string marca, string noSerie, string descripcion, string condicion, string observacionPre, string observacionPost, DateTime fechaPre, DateTime? fechaPost, int idSolicitante, int idOperador)
        {
            try
            {
                FormularioHardware nuevoFormularioHardware = new FormularioHardware
                {
                    Cantidad = cantidad,
                    Marca = marca,
                    NoSerie = noSerie,
                    Descripcion = descripcion,
                    Condicion = condicion,
                    ObservacionPre = observacionPre,
                    ObservacionPost = observacionPost,
                    FechaPre = fechaPre,
                    FechaPost = (DateTime)fechaPost,
                    IdSolicitante = idSolicitante,
                    IdOperador = idOperador
                };

                contexto.FormularioHardwares.Add(nuevoFormularioHardware);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Manejar errores aquí
                return false;
            }
        }

        // Método para actualizar un formulario de hardware existente
        public bool Actualizar(int id, string nuevaCantidad, string nuevaMarca, string nuevoNoSerie, string nuevaDescripcion, string nuevaCondicion, string nuevaObservacionPre, string nuevaObservacionPost, DateTime nuevaFechaPre, DateTime? nuevaFechaPost, int nuevoIdSolicitante, int nuevoIdOperador)
        {
            try
            {
                var formularioHardware = contexto.FormularioHardwares.FirstOrDefault(fh => fh.IdFormularioHardware == id);
                if (formularioHardware != null)
                {
                    formularioHardware.Cantidad = nuevaCantidad;
                    formularioHardware.Marca = nuevaMarca;
                    formularioHardware.NoSerie = nuevoNoSerie;
                    formularioHardware.Descripcion = nuevaDescripcion;
                    formularioHardware.Condicion = nuevaCondicion;
                    formularioHardware.ObservacionPre = nuevaObservacionPre;
                    formularioHardware.ObservacionPost = nuevaObservacionPost;
                    formularioHardware.FechaPre = nuevaFechaPre;
                    formularioHardware.FechaPost = (DateTime)nuevaFechaPost;
                    formularioHardware.IdSolicitante = nuevoIdSolicitante;
                    formularioHardware.IdOperador = nuevoIdOperador;

                    contexto.SaveChanges();
                    return true;
                }
                return false; // Formulario de hardware no encontrado
            }
            catch (Exception ex)
            {
                // Manejar errores aquí
                return false;
            }
        }

        // Método para eliminar un formulario de hardware
        public bool Eliminar(int id)
        {
            try
            {
                var formularioHardware = contexto.FormularioHardwares.FirstOrDefault(fh => fh.IdFormularioHardware == id);
                if (formularioHardware != null)
                {
                    contexto.FormularioHardwares.Remove(formularioHardware);
                    contexto.SaveChanges();
                    return true;
                }
                return false; // Formulario de hardware no encontrado
            }
            catch (Exception ex)
            {
                // Manejar errores aquí
                return false;
            }
        }

        // Método para obtener un solicitante por su ID
        private Solicitante ObtenerSolicitantePorId(int id)
        {
            return contexto.Solicitantes.FirstOrDefault(s => s.IdSolicitante == id);
        }
    }
}
