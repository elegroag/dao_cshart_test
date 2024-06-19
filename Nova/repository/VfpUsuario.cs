using Nova.connection;
using Nova.dao;
using Nova.entities;
using System;
using System.Collections.Generic;
using System.Data;

using System.Data.OleDb;

namespace Nova.repository
{
    public class VfpUsuario : VfpRepository<Usuario, long>, UsuarioDaoRepository
    {
        const string INSERT = "INSERT INTO usuarios (cedula, tipdoc, nombres, apellidos, email, clave) VALUES (?, ?, ?, ?, ? ,?)";
        const string UPDATE = "UPDATE usuarios SET cedula=?, tipdoc=?, nombres=?, apellidos=?, email=?, clave=? WHERE id=? ";
        const string DELETE= "DELETE FROM usuarios WHERE id=? ";

        public VfpUsuario(VfpConnection vfpConnection) { 
            this.vfpcon = vfpConnection;
            this.table = "usuarios";
            this.primaryKey = "id";
            this.fillable = new string[] { 
                "id", 
                "cedula", 
                "tipdoc", 
                "nombres", 
                "apellidos", 
                "clave", 
                "email"
            };
        }

        public void Add(Usuario usuario)
        {
            vfpcon.OpenConnection();
            try
            {
                _connection = vfpcon.Connection;
                if (_connection != null)
                {
                    OleDbCommand command = _connection.CreateCommand();
                    command.CommandText = INSERT;
                    command.Parameters.AddWithValue("nombres", usuario.Nombres);
                    command.Parameters.AddWithValue("email", usuario.Email);
                    command.ExecuteNonQuery();
                }
            }
            catch (OleDbException ex)
            {
                vfpcon.CloseConnection();
                throw new RepoException("Error en la accion de add" ,ex);
            }
            finally
            {
                vfpcon.CloseConnection();
            }
        }

        public Usuario GetById(long id)
        {
            Usuario user = null;
            try
            {
                string query = "SELECT * FROM usuarios WHERE id = ?";
                var parameters = new OleDbParameter[]
                {
                    new OleDbParameter("id", Convert.ToInt32(id))
                };

                OleDbDataReader reader = vfpcon.ExecuteReader(query, parameters);

                if (reader.Read())
                {
                    user = new Usuario();
                    user.Id = reader.GetInt32(reader.GetOrdinal("id"));
                    user.Nombres = reader.GetString(reader.GetOrdinal("nombres")).Trim();
                    user.Apellidos = reader.GetString(reader.GetOrdinal("apellidos")).Trim();
                    user.Email = reader.GetString(reader.GetOrdinal("email")).Trim();
                }
                else
                {
                    Console.WriteLine("No hay datos en la consulta");
                }
                
            }
            catch (OleDbException ex) {
                throw new RepoException("Error al buscar usando Id", ex);
            }
            return user;
        }

        public List<Usuario> GetAll()
        {
            List<Usuario> lista = new List<Usuario>();
            try
            {
                vfpcon.OpenConnection();
                OleDbConnection _connection = vfpcon.Connection;
                DataTable dt = new DataTable();
                if (_connection.State == ConnectionState.Open)
                {
                    OleDbDataAdapter adaptador = new OleDbDataAdapter();
                    string consultaSQL = "SELECT * FROM usuarios";
                    OleDbCommand comando = new OleDbCommand(consultaSQL, _connection);
                    adaptador.SelectCommand = comando;
                    adaptador.Fill(dt);
                    foreach (DataRow registro in dt.Rows)
                    { 
                        lista.Add(recordModel(registro));
                    }
                }
                else
                {
                    Console.WriteLine("La conexión no se pudo abrir correctamente.");
                }
            }
            catch (Exception ex)
            {
                vfpcon.CloseConnection();
                throw new RepoException("Error al hacer la consulta de datos", ex);
            }
            finally
            {
                vfpcon.CloseConnection();
            }
            return lista;
        }

        public void Update(Usuario usuario)
        {
            try
            {
                var parameters = new OleDbParameter[]
                {
                    new OleDbParameter("nombres", usuario.Nombres),
                    new OleDbParameter("email", usuario.Email)
                };
                vfpcon.ExecuteNonQuery(UPDATE, parameters);
            }
            catch (OleDbException ex) {
                throw new RepoException("Error al actualizar el modelo", ex);
            }
        }

        public void Delete(Usuario usuario)
        {
            try
            {
                var parameters = new OleDbParameter[]{
                    new OleDbParameter("id", usuario.Id),
                };
                vfpcon.ExecuteNonQuery(DELETE, parameters);
            }
            catch (OleDbException ex)
            {
                throw new RepoException("Error al actualizar el modelo", ex);
            }
        }

        public DataTable obtenerDatos()
        {
            DataTable resultado = new DataTable();
            try
            {
                vfpcon.OpenConnection();
                OleDbConnection _connection = vfpcon.Connection;
                // Abre la conexión y, si se abre correctamente, intenta realizar una consulta
                if (_connection.State == ConnectionState.Open)
                {
                    OleDbDataAdapter adaptador = new OleDbDataAdapter();
                    string consultaSQL = "SELECT * FROM usuarios";
                    OleDbCommand comando = new OleDbCommand(consultaSQL, _connection);
                    adaptador.SelectCommand = comando;
                    adaptador.Fill(resultado);
                }
                else
                {
                    Console.WriteLine("La conexión no se pudo abrir correctamente.");
                }
            }
            catch (Exception ex)
            {
                vfpcon.CloseConnection();
                throw new RepoException("Error al hacer la consulta de datos", ex);
            }
            finally{
                vfpcon.CloseConnection();
            }
            return resultado;
        }

        public override void prepareModel(OleDbParameterCollection stmt, Usuario use)
        {
            if (stmt != null && use != null)
            {
                stmt.AddWithValue("@id", null);
                stmt.AddWithValue("@nombres", use.Nombres);
                stmt.AddWithValue("@apellidos", use.Apellidos);
                stmt.AddWithValue("@clave", use.Clave);
                stmt.AddWithValue("@cedula", use.Cedula);
                stmt.AddWithValue("@tipdoc", use.Tipdoc);
                stmt.AddWithValue("@email", use.Email);
            }
        }

        public override Usuario recordModel(DataRow rs)
        {
            Usuario usuario = new Usuario();
            usuario.Id = (long) rs["id"];
            usuario.Nombres = (string) rs["nombres"];
            usuario.Apellidos = (string) rs["apellidos"];
            usuario.Email = (string) rs["email"];
            usuario.Clave = (string) rs["clave"];
            usuario.Tipdoc = (string) rs["tipdoc"];
            usuario.Cedula = (int) rs["cedula"];
            return usuario;
        }
    
    }
}
