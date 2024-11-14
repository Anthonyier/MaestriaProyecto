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
    public class NegPermisosPagos
    {
        public static int InsertarPermisos(EntPermisosPagos Per)
        {
            return DOAPermisosPagos.GuardarPermiso(Per);
        }
        public static void ModificarPermisos(EntPermisosPagos Per)
        {
             DOAPermisosPagos.ModificarPermiso(Per);
        }

        public static EntPermisosPagos BuscarPermiso(int id)
        {
            return DOAPermisosPagos.BuscarPermiso(id);
        }
    }
}