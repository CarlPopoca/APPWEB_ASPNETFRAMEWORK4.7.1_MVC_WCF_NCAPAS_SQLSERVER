using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WebPruebaEntities;
using WebPruebaBussinesRules;

namespace WebPruebaWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UsuariosService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UsuariosService.svc or UsuariosService.svc.cs at the Solution Explorer and start debugging.
    public class UsuariosService : IUsuariosService
    {
        public bool ActualizarUsuarios(Usuarios enitity)
        {
            return new UsuariosRules().ActualizarUsuarios(enitity);
        }

        public Usuarios CrearUsuarios(Usuarios entity)
        {
            return new UsuariosRules().CrearUsuarios(entity);
        }

        public bool EliminarUsuarios(int usuarioId)
        {
            return new UsuariosRules().EliminarUsuarios(usuarioId);
        }

        public List<Usuarios> ObtenerUsuarioById(int usuarioId)
        {
            return new UsuariosRules().ObtenerUsuarioById(usuarioId);
        }

        public List<Usuarios> ObtenerUsuarios()
        {
            return new UsuariosRules().ObtenerUsuarios();
        }
    }
}
