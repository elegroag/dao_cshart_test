using Nova.connection;
using Nova.dao;
using System.Xml.Linq;


namespace Nova.repository
{
    public class VfpDaoManager: DaoRepository
    {
        private UsuarioDaoRepository usuarios = null;
        private FacturaDaoRepository factura = null;
        private DetalleDaoRepository detalle = null;
        private DetalleFacturaDaoRepository detalleFactura = null;

        private VfpConnection vfpConnection;
        public VfpDaoManager() {
            XElement config = XElement.Load(@"C:\opt\configuracion.xml");
            VfpConnection.provider = config.Element("conexionDB").Element("provider").Value; 
            VfpConnection.dataSource = config.Element("conexionDB").Element("dataSource").Value;
            vfpConnection = VfpConnection.Instance;
        }

        public DetalleDaoRepository getDetalleDaoRepository()
        {
            if(detalle == null)
            {
                detalle = new VfpDetalle(vfpConnection);
            }
            return detalle;
        }

        public DetalleFacturaDaoRepository getDetalleFacturaDaoRepository()
        {
            if (detalleFactura == null)
            {
                detalleFactura = new VfpDetalleFactura(vfpConnection);
            }
            return detalleFactura;
        }

        public FacturaDaoRepository getFacturaDaoRepository()
        {
            if (factura == null)
            {
                factura = new VfpFactura(vfpConnection);
            }
            return factura;
        }

        public UsuarioDaoRepository getUsuarioDaoRepository()
        {
            if (usuarios == null)
            {
                usuarios = new VfpUsuario(vfpConnection);
            }
            return usuarios;
        }
    }
}
