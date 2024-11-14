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
    public class NegDetalleCarroGuia
    {
        public static int InsertarDetalleCamionGuia(EntDetalleCarroGuia Ent)
        {
            return DAODetalleCarroGuia.Guardar(Ent);
        }
        public static void AprobarCarroGuia(int Per,int Año)
        {
             DAODetalleCarroGuia.Aprobar(Per, Año);
        }
        public static EntDetalleCarroGuia EncontrarDetalleCarroGuia(int IdPeriodo,int IdAño,int IdPersona,int IdRegion)
        {
            return DAODetalleCarroGuia.EncontrarDetalleCarroGuia(IdPeriodo, IdAño, IdPersona,IdRegion);
        }
      
    }
}