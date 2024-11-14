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
    public class NegMulta
    {
        public static int InsertarMulta(EntMulta Mu)
        {
            return DOAMulta.GuardarMulta(Mu);
        }

        public static int ActualizarMulta(EntMulta Mu)
        {
            return DOAMulta.ActualizarMulta(Mu);
        }

        public static EntMulta BuscarMulta(int id)
        {
            return DOAMulta.BuscarMulta(id);
        }

        public static int Deshabilitar(int id)
        {
            return DOAMulta.DeshabilitarMulta(id);
        }
    }
}