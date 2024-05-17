using AccesoDatos.Context;
using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccesoDatos.Operaciones
{
    public class SolicitanteSoftDAO
    {
        private SistemaTicketsVersionDosContext contexto;

        public SolicitanteSoftDAO()
        {
            contexto = new SistemaTicketsVersionDosContext();
        }

        // Método para seleccionar todos los solicitantes de software
        public List<SolicitanteSoft> SeleccionarTodos()
        {
            return contexto.SolicitanteSofts.ToList();
        }

        // Método para seleccionar un solicitante de software en específico por ID
        public SolicitanteSoft SeleccionarPorId(int id)
        {
            return contexto.SolicitanteSofts.FirstOrDefault(s => s.IdSolicitanteSoft == id);
        }

        // Método para insertar un nuevo solicitante de software
        public bool Insertar(string nombre, string correo, string tipoSolicitante, string area, string tipoFallo)
        {
            try
            {
                SolicitanteSoft nuevoSolicitanteSoft = new SolicitanteSoft
                {
                    NombreSolicitanteSoft = nombre,
                    CorreoSoft = correo,
                    TipoSolicitanteSoft = tipoSolicitante,
                    AreaSoft = area,
                    TipoFalloSoft = tipoFallo
                };

                contexto.SolicitanteSofts.Add(nuevoSolicitanteSoft);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Manejar errores aquí
                return false;
            }
        }

        // Método para actualizar un solicitante de software existente
        public bool Actualizar(int id, string nuevoNombre, string nuevoCorreo, string nuevoTipoSolicitante, string nuevaArea, string nuevoTipoFallo)
        {
            try
            {
                var solicitanteSoft = contexto.SolicitanteSofts.FirstOrDefault(s => s.IdSolicitanteSoft == id);
                if (solicitanteSoft != null)
                {
                    solicitanteSoft.NombreSolicitanteSoft = nuevoNombre;
                    solicitanteSoft.CorreoSoft = nuevoCorreo;
                    solicitanteSoft.TipoSolicitanteSoft = nuevoTipoSolicitante;
                    solicitanteSoft.AreaSoft = nuevaArea;
                    solicitanteSoft.TipoFalloSoft = nuevoTipoFallo;

                    contexto.SaveChanges();
                    return true;
                }
                return false; // Solicitante de software no encontrado
            }
            catch (Exception ex)
            {
                // Manejar errores aquí
                return false;
            }
        }

        // Método para eliminar un solicitante de software
        public bool Eliminar(int id)
        {
            try
            {
                var solicitanteSoft = contexto.SolicitanteSofts.FirstOrDefault(s => s.IdSolicitanteSoft == id);
                if (solicitanteSoft != null)
                {
                    contexto.SolicitanteSofts.Remove(solicitanteSoft);
                    contexto.SaveChanges();
                    return true;
                }
                return false; // Solicitante de software no encontrado
            }
            catch (Exception ex)
            {
                // Manejar errores aquí
                return false;
            }

        }
    }
}
