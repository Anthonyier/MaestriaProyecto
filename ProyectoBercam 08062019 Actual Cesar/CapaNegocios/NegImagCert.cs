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
    public class NegImagCert
    {
        public static int InsertarImagen(EntDetalle_Certificados obj)
        {
            return DOADetalleCert.GuardarImagenes(obj);
        }
        public static EntDetalle_Certificados Download(int CodEnte, int TipoImg)
        {
            return DOADetalleCert.Download(CodEnte, TipoImg);
        }
        public static SqlDataReader ObtenerListaCamiones()
        {
            return DOADetalleCert.ObtenerListaCamiones();
        }
        public static SqlDataReader ObtenerListaCamionesCarla()
        {
            return DOADetalleCert.ObtenerListaCamionesCarla();
        }
        public static SqlDataReader ObtenerListaCamionesAndres2()
        {
            return DOADetalleCert.ObtenerListaCamionesAndres2();
        }
        public static SqlDataReader ObtenerListaCamionesCheckList()
        {
            return DOADetalleCert.ObtenerListaCamionesCheckList();
        }
        public static SqlDataReader ObtenerListaCamionesAndres()
        {
            return DOADetalleCert.ObetenerListaCamionesAndres();
        }
        public static SqlDataReader ObtenerListaCamionesExtintores()
        {
            return DOADetalleCert.ObtenerListaCamionesExtintores();
        }
        public static bool EnviarMensaje(string Mensaje)
        {
            return DOADetalleCert.EnviarCorreo(Mensaje);
        }
        public static bool EnviarMensajeJefe(string Mensaje)
        {
            return DOADetalleCert.EnviarCorreoJefe(Mensaje);
        }
        public static bool EnviarMensajeCarla(String Mensaje)
        {
            return DOADetalleCert.EnviarCorreoCarla(Mensaje);
        }
        public static bool EnviarMensajeAndreSanabria(string Mensaje)
        {
            return DOADetalleCert.EnviarCorreoAndres(Mensaje);
        }
        public static DateTime ObtenerFecha(EntDetalle_Certificados obj)
        {
            return DOADetalleCert.ObtenerFecha(obj);
        }
    }
}