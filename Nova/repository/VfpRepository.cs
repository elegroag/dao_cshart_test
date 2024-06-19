using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System;
using Nova.connection;
using Nova.dao;

namespace Nova.repository
{
    public abstract class VfpRepository<T, K> 
    {
        protected VfpConnection vfpcon;
        protected string table;
        protected string primaryKey;
        protected string[] fillable;
        protected OleDbConnection _connection;

        public abstract T recordModel(DataRow rs);
        public abstract void prepareModel(OleDbParameterCollection stmt, T use);
        
        public List<T> find(string sql)
        {
            DataTable resultado = new DataTable();
            List<T> lista = new List<T>();
            vfpcon.OpenConnection();
            try
            {
                _connection = vfpcon.Connection;
                if (_connection.State == ConnectionState.Open)
                {
                    OleDbCommand comando = new OleDbCommand(sql, _connection);
                    OleDbDataAdapter adaptador = new OleDbDataAdapter();

                    adaptador.SelectCommand = comando;
                    adaptador.Fill(resultado);

                    foreach (DataRow row in resultado.Rows)
                    {
                        lista.Add(this.recordModel(row));
                    }
                }
                vfpcon.CloseConnection();
            }
            catch (OleDbException ex)
            {
                vfpcon.CloseConnection();
                throw new RepoException("Error al buscar por sql", ex);
           
            }
            finally
            {
                vfpcon.CloseConnection();
            }
            return lista;
        }

        public T findOne(string sql)
        {
            vfpcon.OpenConnection();
            DataTable resultado = new DataTable();
            T use = default(T);
            try
            {
                _connection = vfpcon.Connection;
                if (_connection.State == ConnectionState.Open)
                {
                    OleDbCommand comando = new OleDbCommand(sql, _connection);
                    OleDbDataAdapter adaptador = new OleDbDataAdapter();

                    adaptador.SelectCommand = comando;
                    adaptador.Fill(resultado);

                    if (resultado.Rows.Count > 1)
                    {
                        Console.WriteLine($"Alert: se ha retornado mas de un registro en un findone. {resultado.Rows.Count}");
                    }

                    use = recordModel(resultado.Rows[0]);
                }
                vfpcon.CloseConnection();
            }
            catch (OleDbException ex)
            {
                vfpcon.CloseConnection();
                throw new RepoException("Error en findOne", ex);
            }
            finally
            {
                vfpcon.CloseConnection();
            }
            return use;
        }

        public T findById(K id)
        {
            string fields = string.Join(",", fillable);
            return findOne($"SELECT {fields} FROM {table} WHERE {primaryKey} = {id}");
        }

        public T findFirst() 
        {
            string fields = string.Join(",", fillable);
            return findOne($"SELECT {fields} FROM {table} WHERE 1=1 ORDER BY {primaryKey} ASC LIMIT 1");
        }

        public T findLast() 
        {
            string fields = string.Join(",", fillable);
            return findOne($"SELECT {fields} FROM {table} WHERE 1=1 ORDER BY {primaryKey} DESC LIMIT 1");
        }

        public T insert(T use) 
        {
            vfpcon.OpenConnection();
            try
            {
                _connection = vfpcon.Connection;
                string fields = string.Join(",", fillable);
                if (_connection.State == ConnectionState.Open)
                {
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = _connection;
                    command.CommandType = CommandType.Text;

                    string items = "";
                    int contador = 0;
                    while (contador < fillable.Length)
                    {
                        items += "?,";
                        contador++;
                    }
                    items = items.Trim(',');
                    command.CommandText = $"INSERT INTO {this.table} ({fields}) VALUES ({items})";

                    this.prepareModel(command.Parameters, use);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Se ha agregado un elemento correctamente.");
                }
                vfpcon.CloseConnection();
            }
            catch (OleDbException ex)
            {
                vfpcon.CloseConnection();
                throw new RepoException("Error", ex);
            }
            finally
            {
                vfpcon.CloseConnection();
            }
            return use;
        }
    }
}