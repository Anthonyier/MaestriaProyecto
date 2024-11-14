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
    public class NegAdelanto
    {
        public static int InsertarAdelantos(EntAdelanto Adel)
        {
            return DAOAdelanto.Guardar(Adel);
        }
        public static int NEncontrarDescuento(int IdFactura)
        {
            return DAOAdelanto.DEncontrarDescuento(IdFactura);
        }
        public static int NEncontrarDescuentoRecibo(int IdConc)
        {
            return DAOAdelanto.DEnconDescRecibo(IdConc);
        }
        public static int NEncontrarDescuentoReciboAceite(int IdConc)
        {
            return DAOAdelanto.DEnconDescReciboAceite(IdConc);
        }
    }
}