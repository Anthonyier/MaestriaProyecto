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
    public class NegPermisosServicios
    {
        public static int InsertarPermisos(EntPermisosServicios Per)
        {
            return DOAPermisosServicios.GuardarPermisos(Per);
        }
        public static void ModificarPermisos(EntPermisosServicios Per)
        {
            DOAPermisosServicios.ModificarPermiso(Per);
        }
        public static EntPermisosServicios BuscarPermiso(int id)
        {
            return DOAPermisosServicios.BuscarPermiso(id);
        }
    }
}