using Nova.connection;
using Nova.dao;
using Nova.entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nova.repository
{
    public class VfpCliente : VfpRepository<Cliente, long>, ClienteDaoRepository
    {

        VfpCliente(VfpConnection vfpConnection)
        {
            this.vfpcon = vfpConnection;
            this.table = "clientes";
            this.primaryKey = "id";
            this.fillable = new string[] {
                "id",
                "cedula",
                "tipdoc",
                "nombres",
                "apellidos",
                "direccion",
                "email",
                "telefono",
                "codciu",
                "coddep"
            };
        }
        public void Add(Cliente item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Cliente item)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> GetAll()
        {
            throw new NotImplementedException();
        }

        public Cliente GetById(long id)
        {
            throw new NotImplementedException();
        }

        public override void prepareModel(OleDbParameterCollection stmt, Cliente use)
        {
            throw new NotImplementedException();
        }


        public override Cliente recordModel(DataRow rs)
        {
            throw new NotImplementedException();
        }

        public void Update(Cliente item)
        {
            throw new NotImplementedException();
        }
    }
}
