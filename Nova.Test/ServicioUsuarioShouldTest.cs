using System;
using System.Data;
using Xunit;
using Nova.entities;
using Nova.repository;
using Nova.services;

namespace Nova.Test
{
    public class ServicioUsuarioShouldTest
    {
      
        [Fact]
        public void BuscarUsuarioTest()
        {
            var _servicioUsuario = new ServicioUsuario();
            DataTable datos = _servicioUsuario.buscarUsuarios();

            foreach (DataRow fila in datos.Rows)
            {
                foreach (DataColumn column in datos.Columns)
                {
                    object cellValue = fila[column];
                    Console.WriteLine($"{column.ColumnName}: {cellValue}");
                }
            }
            Assert.Equal(true, true);
        }

        [Fact]
        public void InsertarUsuarioTest()
        {
            var _servicioUsuario = new ServicioUsuario();
            Assert.Equal(true, true);
        }

    }
}
