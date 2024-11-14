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
    public class NegConciliacionPorCobrar
    {
        public static EntConciliacionPorCobrar BuscarConciliacion(int Id_Recepcion)
        {
            return DAOConciliacionPorCobrar.Consulta(Id_Recepcion);
        }
        public static EntConciliacionPorCobrar BuscarManual(int Id_Recepcion)
        {
            return DAOConciliacionPorCobrar.Manual(Id_Recepcion);
        }
        public static SqlDataReader BuscarRutas()
        {
            return DAOConciliacionPorCobrar.BuscarRuta();
        }
        public static bool ModificarNumeroConc(int id, string NumeroDeConciliacion)
        {
            return DAOConciliacionPorCobrar.ModificarNumeroConc(id, NumeroDeConciliacion);
        }
        public static bool Aprobar(int id)
        {
            return DAOConciliacionPorCobrar.Aprobar(id);
        }

        public static int EstaAprobado(int id)
        {
            return DAOConciliacionPorCobrar.EstaAprobado(id);
        }
    }
}