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
    public class NegPermisoPersona
    {
        public static int InsertarPermisos(EntPermisoPersona obj)
        {
            return DOAPermisoPersona.GuardarPermiso(obj);
        }
        public static void ModificarPermiso(EntPermisoPersona obj)
        {
            DOAPermisoPersona.ModificarPermiso(obj);
        }
        public static EntPermisoPersona BuscarPermiso(int Id)
        {
            return DOAPermisoPersona.BuscarPermiso(Id);
        }
    }
}