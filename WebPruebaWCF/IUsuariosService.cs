using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WebPruebaBussinesRules;
using WebPruebaEntities;

namespace WebPruebaWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUsuariosService" in both code and config file together.
    [ServiceContract]
    public interface IUsuariosService
    {
        [OperationContract]
        List<Usuarios> ObtenerUsuarios();

        [OperationContract]
        Usuarios CrearUsuarios(Usuarios entity);

        [OperationContract]
        bool ActualizarUsuarios(Usuarios enitity);

        [OperationContract]
        bool EliminarUsuarios(int usuarioId);

        [OperationContract]
        List<Usuarios> ObtenerUsuarioById(int usuarioId);
    }
}
