namespace Nova.entities
{
    public class Cliente
    {
        private long id;
        private string nombres;
        private string apellidos;
        private string email;
        private string tipdoc;
        private int cedula;
        private string  direccion;
        private int codciu;
        private int coddep;
        private int telefono;

        public long? Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Tipdoc { get; set; }
        public int Cedula { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public int Codciu { get; set; }
        public int Coddep { get; set; }

    }
}
