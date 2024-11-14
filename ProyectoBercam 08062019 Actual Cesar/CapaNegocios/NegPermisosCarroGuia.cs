using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaNegocios;
using CapaDatos;
using System.Data.SqlClient;
using System.Data;

namespace CapaNegocios
{
    public class NegPermisosCarroGuia
    {
        public static int InsertarPermisos(EntPermisosCarroGuias Obj)
        {
            return DAOPermisoCarroGuia .GuardarPermiso(Obj);
        }

        public static EntPermisosCarroGuias BuscarPermiso(int Id)
        {
            return DAOPermisoCarroGuia.BuscarPermiso(Id);
        }
        public static void ModificarPermiso(EntPermisosCarroGuias Obj)
        {
            DAOPermisoCarroGuia.ModificarPermiso(Obj);
        }
    }
}