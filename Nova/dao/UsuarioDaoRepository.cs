using System;
using System.Collections.Generic;
using System.Linq;
using Nova.entities;
using Nova.connection;
using System.Data.Common;
using System.Data.OleDb;
using System.Data;

namespace Nova.dao
{
    public interface UsuarioDaoRepository : IRepository<Usuario, long>
    {
        public DataTable obtenerDatos();
    }
}
