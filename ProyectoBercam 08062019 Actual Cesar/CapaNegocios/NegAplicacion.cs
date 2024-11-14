using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using CapaDatos;
using CapaEntidad;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaNegocios
{
    public class NegAplicacion
    {
        public static int InsertarAplicacion(EntAplicacion EntAplica)
        {
            return DAOAplicacion.InsertarAplicacion(EntAplica);
        }
        public static int EncontrarDimAplicado(int IdDim)
        {
            return DAOAplicacion.EncontrarDimAplicado(IdDim);
        }
    }
}