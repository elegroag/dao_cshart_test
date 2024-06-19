namespace Nova.entities
{
    public class Factura
    {
        private long id;
        private string nombre_apellidos;
        private string codigo;
        private string puntos;
        private double subtotal;
        private string tipo_codigo;
        private string mone_codigo;

        private string doep_fecha_inicial;
        private string doep_fecha_final;
        private string doep_fecha_vencimiento;
        private string deri_total_iva;
        private string deri_total_consumo;
        private string deri_total_ica;

        private string doea_es_responsable;
        private string doea_es_nacional;
        private string doea_documento;
        private string doea_div;
        private string doea_razon_social;
        private string doea_nombre_ciudad;
        private string doea_nombre_departamento;
        private string doea_pais;
        private string doea_direccion;
        private string doea_obligaciones;
        private string doea_nombres;
        private string doea_apellidos;
        private string doea_otros_nombres;
        private string doea_correo;
        private string doea_telefono;
        private string doea_procedencia;

        private string doce_consecutivo;
        private string doce_referencia_pago;
        private string doce_prefijo;
        private string doce_fecha;
        private string doce_cantidad_items;

        private string demp_descripcion;
        private string demp_codigo;

        private double doet_subtotal;
        private string doet_base;
        private double doet_total_impuestos;
        private double doet_subtotal_mas_impuestos;
        private double doet_total_descuentos;
        private double doet_total_cargos;
        private double doet_total_anticipos;
        private double doet_ajuste_al_peso;
        private double doet_total_documento;


        public long Id { get; set; }
        public long Nombre_apellidos { get; set; }
        public string Valor { get; set; }


    }
}
