using Nova.connection;
using Nova.dao;
using Nova.entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;


namespace Nova.repository
{
    public class VfpDetalleFactura : VfpRepository<DetalleFactura, long>, DetalleFacturaDaoRepository
    {
        VfpConnection vfpcon;

        public VfpDetalleFactura(VfpConnection vfpConnection)
        {
            this.vfpcon = vfpConnection;
            this.table = "detalle_factura";
            this.primaryKey = "id";
            this.fillable = new string[] {
                "doeiitem",
                "doeicodigo",
                "doeidescripcion",
                "doeimarca",
                "doeimodelo",
                "doeiobservacion",
                "doeidatosvendedor",
                "doeicantidad",
                "doeicantidadempaque",
                "doeiesobsequio",
                "doeipreciounitario",
                "doeiprecioreferencia",
                "doeivalor",
                "doeitotaldescuentos",
                "doeitotalcargos",
                "doeitotalimpuestos",
                "doeibase",
                "doeisubtotal",
                "ticpcodigo",
                "unimcodigo",
                "ctprcodigo",
                "doeinumeroradicadoremesa",
                "doeinumeroconsecutivoremesa",
                "doeivalorfleteremesa",
                "doeicantidadfleteremesa",
                "doeiunimcodigoremesa"
            };
        }

        public void Add(DetalleFactura item)
        {
            throw new NotImplementedException();
        }

        public void Delete(DetalleFactura item)
        {
            throw new NotImplementedException();
        }

        public List<DetalleFactura> GetAll()
        {
            throw new NotImplementedException();
        }

        public DetalleFactura GetById(long id)
        {
            throw new NotImplementedException();
        }

        public override void prepareModel(OleDbParameterCollection stmt, DetalleFactura use)
        {
            throw new NotImplementedException();
        }

        public override DetalleFactura recordModel(DataRow rs)
        {
            throw new NotImplementedException();
        }

        public void Update(DetalleFactura item)
        {
            throw new NotImplementedException();
        }
    }
}
