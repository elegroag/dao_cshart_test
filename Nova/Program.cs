using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Newtonsoft.Json;
using Nova.dao;
using Nova.entities;
using Nova.repository;
using Nova.services;


namespace Nova
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServicioUsuario _servicioUsuario = new ServicioUsuario();
            Usuario usuario = _servicioUsuario.getUsuarioById(1L);
            Console.WriteLine($"Nombre usuario: {usuario.Nombres} {usuario.Apellidos}");
            Console.ReadKey();
        }

        void buscarUsuarios()
        {
            ServicioUsuario _servicioUsuario = new ServicioUsuario();
            DataTable datos = _servicioUsuario.buscarUsuarios();
            foreach (DataRow fila in datos.Rows)
            {
                foreach (DataColumn column in datos.Columns)
                {
                    object cellValue = fila[column];
                    Console.WriteLine($"{column.ColumnName}: {cellValue}");
                }
            }
        }

        void buscarDatos()
        {
            VfpDaoManager daoManager = new VfpDaoManager();
            UsuarioDaoRepository usuarioRepository = daoManager.getUsuarioDaoRepository();
            var datos = usuarioRepository.obtenerDatos();
            string json = JsonConvert.SerializeObject(datos, Formatting.Indented);
            Console.WriteLine(json);

            foreach (DataRow fila in datos.Rows)
            {
                string nombre = fila["numero"].ToString();
                Console.WriteLine($"Nombre: {nombre}");
            }
        }

        void insertar()
        {
            VfpDaoManager daoManager = new VfpDaoManager();
            UsuarioDaoRepository usuarioRepository = daoManager.getUsuarioDaoRepository();
            Usuario usuario = new Usuario();
            usuario.Id = null;
            usuario.Nombres = "Edwin Andres";
            usuario.Email = "elegroag@ibero.edu.co";
            usuarioRepository.Add(usuario);
            Console.ReadKey();
        }
    }
}
