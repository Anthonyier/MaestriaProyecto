using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;
using System.Data.SqlClient;
using System.Data;

namespace CapaNegocios
{
    public class NegSoat
    {
        public static int InsertarImagen(EntSoat obj)
        {
            return DOASoat.GuardarImagenes(obj);
        }

        public static EntSoat BuscarVigencia(int id)
        {
            return DOASoat.ConsultaVigencia(id);

        }
        public static SqlDataReader BuscarListaSoat()
        {
            return DOASoat.ObtenerListaSOAT();
        }

        public static EntSoat Download(int Cod)
        {
            return DOASoat.Download(Cod);
        }
        public static DateTime ObtenerFecha(EntSoat obj)
        {
            return DOASoat.ObtenerFecha(obj);
        }
    }
}