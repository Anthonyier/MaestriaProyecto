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
    public class NegBitacora
    {
        public static int GuardarBitacora(EntBitacora bit)
        {
            return DAOBitacora.GuardarBitacora(bit);

        }

        public static int ObtenerId(string nombre, string apellido)
        {
            return DAOBitacora.NumeroDeUsuario(nombre, apellido);
        }

        public static int NumeroDeEntrada(int Dia,int Mes,int Año, int IdUsuario)
        {
            return DAOBitacora.NumeroDeEntrada(Dia, Mes, Año, IdUsuario); 
        }
    }
}