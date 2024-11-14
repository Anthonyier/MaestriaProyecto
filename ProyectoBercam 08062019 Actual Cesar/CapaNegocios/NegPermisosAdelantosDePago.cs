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
    public class NegPermisosAdelantosDePago
    {
        public static int InsertarPermisos(EntPermisosAdelantosDePago obj)
        {
            return DOAPermisoAdelantosDePago.GuardarPermiso(obj);
        }
        public static void ModificarPermiso(EntPermisosAdelantosDePago obj)
        {
            DOAPermisoAdelantosDePago.ModificarPermiso(obj);
        }
        public static EntPermisosAdelantosDePago BuscarPermiso(int Id)
        {
            return DOAPermisoAdelantosDePago.BuscarPermiso(Id);
        }
    }
}