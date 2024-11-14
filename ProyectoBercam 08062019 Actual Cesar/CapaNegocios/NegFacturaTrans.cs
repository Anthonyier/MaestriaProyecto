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
    public class NegFacturaTrans
    {
        public static int InsertarFactura(EntFacturaTrans Fact)
        {
            return DOAFacturaTrans.GuardarFacturaTransp(Fact);
        }
        public static int InsertarFacturaAceite(EntFacturaTrans Fact)
        {
            return DOAFacturaTrans.GuardarFacturaTransAceite(Fact);
        }
        public static double BuscarAnticipoAceite(int id)
        {
            return DOAFacturaTrans.FacturaAnticipoAceite(id);
        }
        public static double BuscarAnticipo(int id)
        {
            return DOAFacturaTrans.FacturaAnticipo(id);
        }
        public static double BuscarPorPagarAceite(int id)
        {
            return DOAFacturaTrans.PesoAPagable(id);
        }
        public static double BuscarPorPagar(int id)
        {
            return DOAFacturaTrans.LiquidoAPagar(id);
        }
        public static int Solicitud(int id)
        {
            return DOAFacturaTrans.PendientedeSolicitud(id);
        }
        public static bool EnviarCorreo(string Mensaje)
        {
            return DOAFacturaTrans.EnviarCorreo(Mensaje);
        }
        public static SqlDataReader ReaderFechaSolicitudAceite(int id)
        {
            return DOAFacturaTrans.ReaderFechaSolicitudAceite(id);
        }
        public static SqlDataReader ReaderFechaSolicitud(int id)
        {
            return DOAFacturaTrans.ReaderFechaSolicitud(id);
        }
        public static int SolicitudAceite(int id)
        {
            return DOAFacturaTrans.PendienteSolicitudAceite(id);
        }
        public static void CambiarSolicitud(int Periodo, int año)
        {
            DOAFacturaTrans.CambiarEstadoSolicitudes(Periodo, año);
        }
        public static void CambiarSolicitudes(int Mes, int Año)
        {
            DOAFacturaTrans.CambiarSolicitud(Mes, Año);
        }
    }
}