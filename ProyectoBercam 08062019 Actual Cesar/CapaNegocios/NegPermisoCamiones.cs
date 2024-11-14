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
    public class NegPermisoCamiones
    {
        public static int InsertarPermisos(EntPermisoCamiones obj)
        {
            return DOAPermisoCamiones.GuardarPermiso(obj);
        }
        public static EntPermisoCamiones BuscarPermiso(int Id)
        {
            return DOAPermisoCamiones.BuscarPermiso(Id);
        }
    }
}