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
    public class VfpFactura : VfpRepository<Factura, long>, FacturaDaoRepository
    {

        public VfpFactura(VfpConnection vfpConnection) {
            this.vfpcon = vfpConnection;
            this.table = "factura";
            this.primaryKey = "id";
            this.fillable = new string[] {
                "deacnombre",
                "deactelefono",
                "deaccorreo",
                "deaccodigo",
                "docemanejaperiodos",
                "docereferenciapago",
                "doempcodigo",
                "nombreapellidos",
                "doepfechainicial",
                "doepfechafinal",
                "docelineaswhatsapp",
                "deritotaliva",
                "deritotalconsumo",
                "deritotalica",
                "calculardv",
                "doeaesresponsable",
                "doeaesnacional",
                "doeadocumento",
                "doeadiv",
                "doearazonsocial",
                "doeanombreciudad",
                "doeanombredepartamento",
                "doeapais",
                "doeadireccion",
                "doeaobligaciones",
                "doeanombres",
                "doeaapellidos",
                "doeaotrosnombres",
                "doeacorreo",
                "doeatelefono",
                "tiotcodigo",
                "copccodigo",
                "regcodigo",
                "tidtcodigo",
                "doeamanejoadjuntos",
                "doeaprocedencia",
                "doceconsecutivo",
                "doceprefijo",
                "docefecha",
                "docecantidaditems",
                "ambdcodigo",
                "tipocodigo",
                "doetcodigo",
                "monecodigo",
                "refvnumero",
                "enviarsetpruebas",
                "forpcodigo",
                "doepfechavencimiento",
                "dempdescripcion",
                "codigo",
                "puntos",
                "subtotal",
                "dempcodigo",
                "doetsubtotal",
                "doetbase",
                "doettotalimpuestos",
                "doetsubtotalmasimpuestos",
                "doettotaldescuentos",
                "doettotalcargos",
                "doettotalanticipos",
                "doetajustealpeso",
                "doettotaldocumento"
             };
        }

        public void Add(Factura item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Factura item)
        {
            throw new NotImplementedException();
        }

        public List<Factura> GetAll()
        {
            throw new NotImplementedException();
        }

        public Factura GetById(long id)
        {
            throw new NotImplementedException();
        }

        public override void prepareModel(OleDbParameterCollection stmt, Factura use)
        {
            throw new NotImplementedException();
        }

        public override Factura recordModel(DataRow rs)
        {
            throw new NotImplementedException();
        }

        public void Update(Factura item)
        {
            throw new NotImplementedException();
        }
    }
}
