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
    public class NegPermisosConciliaciones
    {
        public static int InsertarPermisos(EntPermisosConciliaciones Obj)
        {
            return DAOPermisosConciliaciones.GuardarPermiso(Obj);
        }
        public static EntPermisosConciliaciones BuscarPermiso(int Id)
        {
            return DAOPermisosConciliaciones.BuscarPermiso(Id);
        }
    }
}