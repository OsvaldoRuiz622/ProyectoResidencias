﻿using AccesoDatos.Context;
using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccesoDatos.Operaciones
{
    public class OperadorDAO
    {
        private SistemaTicketsVersionDosContext contexto;

        public OperadorDAO()
        {
            contexto = new SistemaTicketsVersionDosContext();
        }

        // Método para seleccionar todos los operadores
        public List<Operador> SeleccionarTodos()
        {
            return contexto.Operadors.ToList();
        }

        // Método para seleccionar un operador en específico por ID
        public Operador SeleccionarPorId(int id)
        {
            return contexto.Operadors.FirstOrDefault(o => o.IdOperador == id);
        }

        // Método para insertar un nuevo operador
        public bool Insertar(string usuario, string contrasena, string cargo)
        {
            try
            {
                Operador nuevoOperador = new Operador
                {
                    Usuario = usuario,
                    Contrasena = contrasena,
                    Cargo = cargo
                };

                contexto.Operadors.Add(nuevoOperador);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Manejar errores aquí
                return false;
            }
        }

        // Método para actualizar un operador existente
        public bool Actualizar(int id, string nuevoUsuario, string nuevaContrasena, string nuevoCargo)
        {
            try
            {
                var operador = contexto.Operadors.FirstOrDefault(o => o.IdOperador == id);
                if (operador != null)
                {
                    operador.Usuario = nuevoUsuario;
                    operador.Contrasena = nuevaContrasena;
                    operador.Cargo = nuevoCargo;

                    contexto.SaveChanges();
                    return true;
                }
                return false; // Operador no encontrado
            }
            catch (Exception ex)
            {
                // Manejar errores aquí
                return false;
            }
        }

        // Método para eliminar un operador
        public bool Eliminar(int id)
        {
            try
            {
                var operador = contexto.Operadors.FirstOrDefault(o => o.IdOperador == id);
                if (operador != null)
                {
                    contexto.Operadors.Remove(operador);
                    contexto.SaveChanges();
                    return true;
                }
                return false; // Operador no encontrado
            }
            catch (Exception ex)
            {
                // Manejar errores aquí
                return false;
            }
        }
    }
}
