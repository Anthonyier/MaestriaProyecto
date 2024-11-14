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
    public class NegServicios
    {
        public static int InsertarServicios(EntServicios Ser)
        {
            return DOAServicios.GuardarServicios(Ser);
        }
    }
}