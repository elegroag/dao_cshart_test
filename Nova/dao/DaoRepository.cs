using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nova.dao
{
    public interface DaoRepository
    {
        UsuarioDaoRepository getUsuarioDaoRepository();

        FacturaDaoRepository getFacturaDaoRepository();

        DetalleFacturaDaoRepository getDetalleFacturaDaoRepository();

        DetalleDaoRepository getDetalleDaoRepository();

    }
}
