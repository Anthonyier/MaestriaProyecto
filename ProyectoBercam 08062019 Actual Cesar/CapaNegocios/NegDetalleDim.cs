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
    public class NegDetalleDim
    {
        public static int InsertarDetalleDim(DateTime FechaPrm,string PrmNo,int IdDim,int IdDetalle)
        {
            return DAODetalleDim.InsertarDetalleDim(FechaPrm, PrmNo, IdDim, IdDetalle);
        }
        public static string insertAddDetalleDim(List<EntDetalleDim> Lista, int IdDim)
        {
            return DAODetalleDim.InserAddDetalleDim(Lista, IdDim);
        }
        public static bool NEditarDetalleDim(EntDetalleDim Obj)
        {
            return DAODetalleDim.EditarDetalleDim(Obj);
        }
        public static EntDetalleDim NobtenerDetalleDim(int id)
        {
            return DAODetalleDim.ObtenerDetalleDim(id);
        }
        public static int NObtenerIdDetalleRececpionDim(int Id)
        {
            return DAODetalleDim.ObtenerIdDetalleRecepcionDim(Id);
        }
        public static bool NEditarDetalleRecepcionDatosDim(EntDetalle_Recepcion Obj)
        {
            return DAODetalleDim.EditarDetalleRecepcionDatosDim(Obj);
        }
        public static EntDetalle_Recepcion NObtenervaloresDetRecpDim(int Id)
        {
            return DAODetalleDim.ObtenerValoresDetRecpDim(Id);
        }
        public static double NObtenerTotalVolPrmDim(int IdDim)
        {
            return DAODetalleDim.DObtenerTotalVolPrmDim(IdDim);
        }
    }
}