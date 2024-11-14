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
    public class NegInspeccTec
    {
        public static int InsertarImagen(EntInspTecnica obj)
        {
            return DOAInspeccionTecnica.GuardarImagenes(obj);
        }

        public static EntInspTecnica BuscarVigencia(int id)
        {
            return DOAInspeccionTecnica.ConsultaVigencia(id);

        }
        public static EntInspTecnica Download(int Cod)
        {
            return DOAInspeccionTecnica.Download(Cod);
        }
        public static SqlDataReader BuscarListaInspeccionTecnica()
        {
            return DOAInspeccionTecnica.ObtenerListaInspeccionTecnica();
        }
        public static DateTime ObtenerFecha(EntInspTecnica Obj)
        {
            return DOAInspeccionTecnica.ObtenerFecha(Obj);
        }
    }
}