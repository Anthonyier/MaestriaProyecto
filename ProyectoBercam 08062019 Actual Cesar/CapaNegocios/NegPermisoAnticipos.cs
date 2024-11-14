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
    public class NegPermisoAnticipos
    {
        public static int InsertarPermisos(EntPermisoAnticipos Obj)
        {
            return DAOPermisoAnticipos.GuardarPermiso(Obj);
        }
        public static void ModificarPermiso(EntPermisoAnticipos Obj)
        {
            DAOPermisoAnticipos.ModificarPermiso(Obj);
        }
        public static EntPermisoAnticipos BuscarPermiso(int id)
        {
             return DAOPermisoAnticipos.BuscarPermiso(id);
        }
    }
}