using AccesoDatos.Context;
using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccesoDatos.Operaciones
{
    public class FormularioHardwareDAO
    {
        private SistemaTicketsVersionDosContext contexto;

        public FormularioHardwareDAO()
        {
            contexto = new SistemaTicketsVersionDosContext();
        }

        // Método para seleccionar todos los formularios de hardware
        public List<dynamic> SeleccionarTodos()
        {
            var formulariosHardware = new List<dynamic>();
            var formularioHardwareList = contexto.FormularioHardwares.ToList();

            foreach (var formulario in formularioHardwareList)
            {
                    var solicitante = ObtenerSolicitantePorId(formulario.IdSolicitanteHard);
                    var formularioHardwareDTO = new
                    {
                        formulario.IdFormularioHardware,
                        formulario.Cantidad,
                        formulario.Marca,
                        formulario.NoSerie,
                        formulario.DescripcionHard,
                        formulario.Condicion,
                        formulario.ObservacionPre,
                        formulario.ObservacionPost,
                        formulario.FechaPreHard,
                        formulario.FechaPostHard,
                        formulario.EstatusHard,
                        Solicitante = new
                        {
                            solicitante.NombreSolicitanteHard,
                            solicitante.CorreoHard,
                            solicitante.TipoSolicitanteHard,
                            solicitante.AreaHard,
                            solicitante.TipoFalloHard
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
                var solicitante = ObtenerSolicitantePorId(formularioHardware.IdSolicitanteHard);
                var formularioHardwareDTO = new
                {
                    formularioHardware.IdFormularioHardware,
                    formularioHardware.Cantidad,
                    formularioHardware.Marca,
                    formularioHardware.NoSerie,
                    formularioHardware.DescripcionHard,
                    formularioHardware.Condicion,
                    formularioHardware.ObservacionPre,
                    formularioHardware.ObservacionPost,
                    formularioHardware.FechaPreHard,
                    formularioHardware.FechaPostHard,
                    formularioHardware.EstatusHard,
                    Solicitante = solicitante != null ? new
                    {
                        solicitante.NombreSolicitanteHard,
                        solicitante.TipoSolicitanteHard
                    } : null
                };
                return formularioHardwareDTO;
            }
            else
            {
                return null;
            }
        }

        // Método para insertar un nuevo formulario de hardware
        public bool Insertar(string cantidad, string marca, string noSerie, string descripcion, string condicion, string observacionPre, string observacionPost, DateTime? fechaPre, DateTime? fechaPost, bool? estatusHard, int idSolicitanteHard, int idOperador)
        {
            try
            {
                FormularioHardware nuevoFormularioHardware = new FormularioHardware
                {
                    Cantidad = cantidad,
                    Marca = marca,
                    NoSerie = noSerie,
                    DescripcionHard = descripcion,
                    Condicion = condicion,
                    ObservacionPre = observacionPre,
                    ObservacionPost = observacionPost,
                    FechaPreHard = fechaPre,
                    FechaPostHard = fechaPost,
                    EstatusHard = estatusHard,
                    IdSolicitanteHard = idSolicitanteHard,
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
        public bool Actualizar(int id, string nuevaCantidad, string nuevaMarca, string nuevoNoSerie, string nuevaDescripcion, string nuevaCondicion, string nuevaObservacionPre, string nuevaObservacionPost, DateTime? nuevaFechaPre, DateTime? nuevaFechaPost, bool? nuevoEstatusHard, int nuevoIdSolicitanteHard, int nuevoIdOperador)
        {
            try
            {
                var formularioHardware = contexto.FormularioHardwares.FirstOrDefault(fh => fh.IdFormularioHardware == id);
                if (formularioHardware != null)
                {
                    formularioHardware.Cantidad = nuevaCantidad;
                    formularioHardware.Marca = nuevaMarca;
                    formularioHardware.NoSerie = nuevoNoSerie;
                    formularioHardware.DescripcionHard = nuevaDescripcion;
                    formularioHardware.Condicion = nuevaCondicion;
                    formularioHardware.ObservacionPre = nuevaObservacionPre;
                    formularioHardware.ObservacionPost = nuevaObservacionPost;
                    formularioHardware.FechaPreHard = nuevaFechaPre;
                    formularioHardware.FechaPostHard = nuevaFechaPost;
                    formularioHardware.EstatusHard = nuevoEstatusHard;
                    formularioHardware.IdSolicitanteHard = nuevoIdSolicitanteHard;
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
        public SolicitanteHard ObtenerSolicitantePorId(int id)
        {
            return contexto.SolicitanteHards.FirstOrDefault(s => s.IdSolicitanteHard == id);
        }


    }
}
