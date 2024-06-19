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
    public class VfpDetalle : VfpRepository<Detalle, long>, DetalleDaoRepository
    {

        public VfpDetalle(VfpConnection _vfpcon) {
            this.vfpcon = _vfpcon;
        }

        public void Add(Detalle item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Detalle item)
        {
            throw new NotImplementedException();
        }

        public List<Detalle> GetAll()
        {
            throw new NotImplementedException();
        }

        public Detalle GetById(long id)
        {
            throw new NotImplementedException();
        }

        public override void prepareModel(OleDbParameterCollection stmt, Detalle use)
        {
            throw new NotImplementedException();
        }

        public override Detalle recordModel(DataRow rs)
        {
            throw new NotImplementedException();
        }

        public void Update(Detalle item)
        {
            throw new NotImplementedException();
        }
    }
}
