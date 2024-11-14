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
    public class NegDetalleRastreo
    {
        public static int InsertarRastreo(EntDetalleRastreo Dt)
        {
            return DAODetalleRastreo.Guardar(Dt);
        }
        public static int GuardarGrupoRastreo(int Mes, int año)
        {
            return DAODetalleRastreo.GuardarGrupoRastreo(Mes, año);
        }
        public static EntDetalleRastreo BuscarRastreo(int id)
        {
            return DAODetalleRastreo.ConsultaRastreo(id);
        }

        public static int Actualizar(EntDetalleRastreo Ras)
        {
            return DAODetalleRastreo.Actualizar(Ras);
        }
    }
}