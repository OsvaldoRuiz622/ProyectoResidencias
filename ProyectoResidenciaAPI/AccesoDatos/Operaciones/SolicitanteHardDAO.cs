using AccesoDatos.Context;
using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccesoDatos.Operaciones
{
    public class SolicitanteHardDAO
    {
        private SistemaTicketsVersionDosContext contexto;

        public SolicitanteHardDAO()
        {
            contexto = new SistemaTicketsVersionDosContext();
        }

        // Método para seleccionar todos los solicitantes de hardware
        public List<SolicitanteHard> SeleccionarTodos()
        {
            return contexto.SolicitanteHards.ToList();
        }

        // Método para seleccionar un solicitante de hardware en específico por ID
        public SolicitanteHard SeleccionarPorId(int id)
        {
            return contexto.SolicitanteHards.FirstOrDefault(s => s.IdSolicitanteHard == id);
        }

        // Método para insertar un nuevo solicitante de hardware
        public bool Insertar(string nombre, string correo, string tipoSolicitante, string area, string tipoFallo)
        {
            try
            {
                SolicitanteHard nuevoSolicitanteHard = new SolicitanteHard
                {
                    NombreSolicitanteHard = nombre,
                    CorreoHard = correo,
                    TipoSolicitanteHard = tipoSolicitante,
                    AreaHard = area,
                    TipoFalloHard = tipoFallo
                };

                contexto.SolicitanteHards.Add(nuevoSolicitanteHard);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Manejar errores aquí
                return false;
            }
        }

        // Método para actualizar un solicitante de hardware existente
        public bool Actualizar(int id, string nuevoNombre, string nuevoCorreo, string nuevoTipoSolicitante, string nuevaArea, string nuevoTipoFallo)
        {
            try
            {
                var solicitanteHard = contexto.SolicitanteHards.FirstOrDefault(s => s.IdSolicitanteHard == id);
                if (solicitanteHard != null)
                {
                    solicitanteHard.NombreSolicitanteHard = nuevoNombre;
                    solicitanteHard.CorreoHard = nuevoCorreo;
                    solicitanteHard.TipoSolicitanteHard = nuevoTipoSolicitante;
                    solicitanteHard.AreaHard = nuevaArea;
                    solicitanteHard.TipoFalloHard = nuevoTipoFallo;

                    contexto.SaveChanges();
                    return true;
                }
                return false; // Solicitante de hardware no encontrado
            }
            catch (Exception ex)
            {
                // Manejar errores aquí
                return false;
            }
        }

        // Método para eliminar un solicitante de hardware
        public bool Eliminar(int id)
        {
            try
            {
                var solicitanteHard = contexto.SolicitanteHards.FirstOrDefault(s => s.IdSolicitanteHard == id);
                if (solicitanteHard != null)
                {
                    contexto.SolicitanteHards.Remove(solicitanteHard);
                    contexto.SaveChanges();
                    return true;
                }
                return false; // Solicitante de hardware no encontrado
            }
            catch (Exception ex)
            {
                // Manejar errores aquí
                return false;
            }
        }
    }
}
