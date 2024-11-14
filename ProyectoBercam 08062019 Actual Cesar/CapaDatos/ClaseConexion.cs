using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class ClaseConexion
    {
        public SqlConnection conectar()
        {
            SqlConnection Conexion = new SqlConnection(Properties.Resources.ConexionBercam);
            return Conexion;
        }
    }
}