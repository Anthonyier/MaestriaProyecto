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
    public class NegFacturaCamionGuia
    {
        public static void InsertarFactura(EntFacturaCarroGuia Fact)
        {
            DAOFacturaCamionGuia.GuardarFacturaCarroGuia(Fact);
        }
    }
}