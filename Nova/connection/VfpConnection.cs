using System;
using System.Data.OleDb;
using System.Data;
using Nova.dao;


namespace Nova.connection
{
    public class VfpConnection
    {
        private static VfpConnection _instance;
        private OleDbConnection _connection;
        public static string provider = "";
        public static string dataSource = "";

        private VfpConnection()
        {
            try
            {
                string _connectionString = @"Provider=" + provider + ";Data Source=" + dataSource + ";";
                _connection = new OleDbConnection(_connectionString);
            }
            catch (OleDbException err)
            {
                throw new RepoException("Error al hacer la conexion", err);
            }
        }

        public static VfpConnection Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new VfpConnection();
                }
                return _instance;
            }
        }

        // Método para abrir la conexión
        public void OpenConnection()
        {
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
        }

        // Método para cerrar la conexión
        public void CloseConnection()
        {
            if (_connection.State != ConnectionState.Closed)
            {
                _connection.Close();
            }
        }

        // Propiedad para exponer la conexión
        public OleDbConnection Connection
        {
            get { return _connection; }
        }

        public void ExecuteNonQuery(string query, OleDbParameter[] parameters)
        {
            try
            {
                OpenConnection();
                var command = _connection.CreateCommand();
                command.CommandText = query;
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }
                command.ExecuteNonQuery();
            }
            finally
            {
                CloseConnection();
            }
        }

        // Método para ejecutar un query que retorna un OleDbDataReader (como SELECT)
        public OleDbDataReader ExecuteReader(string query, OleDbParameter[] parameters)
        {
            try
            {
                OpenConnection();
                var command = _connection.CreateCommand();
                command.CommandText = query;
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }
                return command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            }
            catch
            {
                CloseConnection();
                throw;
            }
        }
    }


}
