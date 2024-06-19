using Nova.dao;
using Nova.entities;
using Nova.repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nova.services
{
    public class ServicioUsuario
    {
        private UsuarioDaoRepository _usuarioRepository;

        public ServicioUsuario()
        {
            VfpDaoManager daoManager = new VfpDaoManager();
            _usuarioRepository = daoManager.getUsuarioDaoRepository();
        }

        public void registrarNuevoUsuario(Usuario usuario)
        {
            _usuarioRepository.Add(usuario);
        }

        public DataTable buscarUsuarios()
        {
            return _usuarioRepository.obtenerDatos();
        }

        public Usuario getUsuarioById(long id)
        {
            return _usuarioRepository.GetById(id);
        }

    }
}
