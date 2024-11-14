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
    public class NegTransaccion
    {
        public static int InsertarTransacccion(EntTransaccion obj)
        {
            return DAOTransaccion.GuardarTransaccion(obj);
        }

        public static int ActualizarTransaccion(EntTransaccion obj)
        {
            return DAOTransaccion.ActualizarTransaccion(obj);
        }

        public static EntTransaccion BuscarTransaccion(int tran)
        {
            return DAOTransaccion.ConsultaTransaccion(tran);
        }
    }
}