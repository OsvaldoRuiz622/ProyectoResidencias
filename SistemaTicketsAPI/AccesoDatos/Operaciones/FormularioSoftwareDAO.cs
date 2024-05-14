using AccesoDatos.Context;
using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccesoDatos.Operaciones
{
    public class FormularioSoftwareDAO
    {
        private SistemaTicketsContext contexto;

        public FormularioSoftwareDAO()
        {
            contexto = new SistemaTicketsContext();
        }

        // Método para seleccionar todos los formularios de software
        public List<FormularioSoftware> SeleccionarTodos()
        {
            return contexto.FormularioSoftwares.ToList();
        }

        // Método para seleccionar un formulario de software en específico por ID
        public FormularioSoftware SeleccionarPorId(int id)
        {
            return contexto.FormularioSoftwares.FirstOrDefault(fs => fs.IdFormularioSoftware == id);
        }

        // Método para insertar un nuevo formulario de software
        public bool Insertar(string descripcion, string imagen, DateTime fechaPre, DateTime? fechaPost, int idSolicitante, int idOperador)
        {
            try
            {
                FormularioSoftware nuevoFormularioSoftware = new FormularioSoftware
                {
                    Descripcion = descripcion,
                    Imagen = imagen,
                    FechaPre = fechaPre,
                    FechaPost = (DateTime)fechaPost,
                    IdSolicitante = idSolicitante,
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
        public bool Actualizar(int id, string nuevaDescripcion, string nuevaImagen, DateTime nuevaFechaPre, DateTime? nuevaFechaPost, int nuevoIdSolicitante, int nuevoIdOperador)
        {
            try
            {
                var formularioSoftware = contexto.FormularioSoftwares.FirstOrDefault(fs => fs.IdFormularioSoftware == id);
                if (formularioSoftware != null)
                {
                    formularioSoftware.Descripcion = nuevaDescripcion;
                    formularioSoftware.Imagen = nuevaImagen;
                    formularioSoftware.FechaPre = nuevaFechaPre;
                    formularioSoftware.FechaPost = (DateTime)nuevaFechaPost;
                    formularioSoftware.IdSolicitante = nuevoIdSolicitante;
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
        public Solicitante ObtenerSolicitantePorId(int id)
        {
            return contexto.Solicitantes.FirstOrDefault(s => s.IdSolicitante == id);
        }
    }
}
