using AccesoDatos.Context;
using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccesoDatos.Operaciones
{
    public class SolicitanteDAO
    {
        private SistemaTicketsContext contexto;

        public SolicitanteDAO()
        {
            contexto = new SistemaTicketsContext();
        }

        // Método para seleccionar todos los solicitantes
        public List<Solicitante> SeleccionarTodos()
        {
            return contexto.Solicitantes.ToList();
        }

        // Método para seleccionar un solicitante en específico por ID
        public Solicitante SeleccionarPorId(int id)
        {
            return contexto.Solicitantes.FirstOrDefault(s => s.IdSolicitante == id);
        }

        // Método para insertar un nuevo solicitante
        public bool Insertar(string nombreSolicitante, string correo, string tipoSolicitante, string area, string tipoFallo)
        {
            try
            {
                Solicitante nuevoSolicitante = new Solicitante
                {
                    NombreSolicitante = nombreSolicitante,
                    Correo = correo,
                    TipoSolicitante = tipoSolicitante,
                    Area = area,
                    TipoFallo = tipoFallo
                };

                contexto.Solicitantes.Add(nuevoSolicitante);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Manejar errores aquí
                return false;
            }
        }

        // Método para actualizar un solicitante existente
        public bool Actualizar(int id, string nuevoNombre, string nuevoCorreo, string nuevoTipoSolicitante, string nuevaArea, string nuevoTipoFallo)
        {
            try
            {
                var solicitante = contexto.Solicitantes.FirstOrDefault(s => s.IdSolicitante == id);
                if (solicitante != null)
                {
                    solicitante.NombreSolicitante = nuevoNombre;
                    solicitante.Correo = nuevoCorreo;
                    solicitante.TipoSolicitante = nuevoTipoSolicitante;
                    solicitante.Area = nuevaArea;
                    solicitante.TipoFallo = nuevoTipoFallo;

                    contexto.SaveChanges();
                    return true;
                }
                return false; // Solicitante no encontrado
            }
            catch (Exception ex)
            {
                // Manejar errores aquí
                return false;
            }
        }

        // Método para eliminar un solicitante
        public bool Eliminar(int id)
        {
            try
            {
                var solicitante = contexto.Solicitantes.FirstOrDefault(s => s.IdSolicitante == id);
                if (solicitante != null)
                {
                    contexto.Solicitantes.Remove(solicitante);
                    contexto.SaveChanges();
                    return true;
                }
                return false; // Solicitante no encontrado
            }
            catch (Exception ex)
            {
                // Manejar errores aquí
                return false;
            }
        }
    }
}
