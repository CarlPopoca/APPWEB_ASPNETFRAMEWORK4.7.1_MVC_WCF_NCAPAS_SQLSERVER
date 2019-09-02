using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPruebaData;
using WebPruebaEntities;

namespace WebPruebaBussinesRules
{
    public class UsuariosRules
    {

        public List<Usuarios> ObtenerUsuarios()
        {
            return new UsuariosData().ObtenerTodos();
        }
        public Usuarios CrearUsuarios(Usuarios entity)
        {
            return new UsuariosData().CrearUsuarios(entity);
        }
        public bool ActualizarUsuarios(Usuarios enitity)
        {
            return new UsuariosData().ActualizarUsuarios(enitity);
        }
        public bool EliminarUsuarios(int usuId)
        {
            return new UsuariosData().EliminarUsuarios(usuId);
        }

        public List<Usuarios> ObtenerUsuarioById(int usuarioId)
        {
       
            return new UsuariosData().ObtenerTodos().Where(x => x.UsuId == usuarioId).ToList();
        }
    }
}
