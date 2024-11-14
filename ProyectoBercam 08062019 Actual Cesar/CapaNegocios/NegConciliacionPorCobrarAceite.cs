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

namespace CapaNegocios
{
    public class NegConciliacionPorCobrarAceite
    {
        public static bool ModificarNroContrato(int id,string NroContrato)
        {
            return DAOConciliacionPorCobrarAceite.ModificarNroContrato(id, NroContrato);
        }
        public static bool Aprobar(int id)
        {
            return DAOConciliacionPorCobrarAceite.Aprobar(id);
        }
        public static int EstaAprobado(int id)
        {
            return DAOConciliacionPorCobrarAceite.EstaAprobado(id);
        }
    }
}