namespace Nova.entities
{
    public class Usuario
    {
        private long id;
        private string nombre;
        private string apellidos;
        private string tipdoc;
        private string clave;
        private string email;
        private int cedula;
        private int telefono;

        public long? Id { get; set; }
        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public string Tipdoc { get; set; }

        public string Clave { get; set; }

        public int Cedula { get; set; }
        public string Email { get; set; }

        public int Telefono { get; set; }
    }
}
