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
    public class NegAsignacionCamion
    {
        public static int InsertarAsignacion(EntAsignacionCamion Asc)
        {
            return DAOAsignacionCamiones.GuardarAsignacion(Asc);
        }

        public static int ActualizarAsignacion(EntAsignacionCamion Asc)
        {
            return 1;
        }
        public static void EliminarAsignacionCamionGuia(int id)
        {
            DAOAsignacionCamiones.EliminarAsignacion(id);
        }
        public static SqlDataReader Cantidad(int id, string Cli)
        {
            SqlDataReader dr = DAOAsignacionCamiones.Cantidad(id,Cli);
            return dr;
        }
    }
}