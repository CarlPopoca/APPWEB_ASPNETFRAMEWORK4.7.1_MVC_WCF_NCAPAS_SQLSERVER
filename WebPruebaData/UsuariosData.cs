using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPruebaEntities;

namespace WebPruebaData
{
    public class UsuariosData : EntityManager<Usuarios>
    {
        string connectionString;
        public UsuariosData()
        {
            connectionString = WebPruebaBDEntities.ConnectionStringName;
        }
        public Usuarios CrearUsuarios(Usuarios entity)
        {
            ConnectionStringName = connectionString;
            return CrearEntity(entity);
        }
        public bool EliminarUsuarios(int usuarioId)
        {
            ConnectionStringName = connectionString;
            return EliminarById(usuarioId);
        }
        public bool ActualizarUsuarios(Usuarios entity)
        {
            ConnectionStringName = connectionString;
            return ActualizarEntity(entity);
        }
    }
}
