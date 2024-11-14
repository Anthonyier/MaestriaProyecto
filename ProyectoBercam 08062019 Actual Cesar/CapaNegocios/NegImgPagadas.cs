using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocios
{
    public class NegImgPagadas
    {
        public static int InsertarImagen(EntImagenesPagadas obj)
        {
            return DAOImagenesPagadas.GuardarImagenes(obj);
        }
        public static bool MaestroProveedor(DateTime Fecha, int idPersona, int idUsuario, double monto, EntImagenesPagadas ImgPaga, int idTipoPago, int IdPasivo, int IdAdelanto, int IdDescuento, int IdFactura,int IdModPago,string Modalidad,int IdCuenta)
        {
            return DAOImagenesPagadas.DInsertar(Fecha,idPersona,idUsuario,monto,ImgPaga,idTipoPago,IdPasivo,IdAdelanto,IdDescuento,IdFactura,IdModPago,Modalidad,IdCuenta);
        }
        public static bool MaestroProveedorAceite(DateTime Fecha, int idPersona, int idUsuario, double monto, EntImagenesPagadas ImgPaga, int IdTipoPago, int IdPasivo,int IdAdelanto,int IdDescuento,int IdFactura,int IdModPago,string Modalidad,int IdCuenta)
        {
            return DAOImagenesPagadas.DInsertarAceite(Fecha, idPersona, idUsuario, monto, ImgPaga, IdTipoPago, IdPasivo,IdAdelanto,IdDescuento,IdFactura,IdModPago,Modalidad,IdCuenta);
        }
        public static bool MaestroProveedorRecibo(DateTime Fecha, int idPersona, int idUsuario, double monto, EntImagenesPagadas ImgPaga, int idTipoPago, int IdPasivo, int IdAdelanto, int IdDescuento,int IdModPago,string Modalidad,int IdCuenta)
        {
            return DAOImagenesPagadas.DReciboInsertar(Fecha, idPersona, idUsuario, monto, ImgPaga, idTipoPago, IdPasivo, IdAdelanto, IdDescuento,IdModPago,Modalidad,IdCuenta);
        }
        public static bool MaestroProveedorReciboAceite(DateTime Fecha, int idPersona, int idUsuario, double monto, EntImagenesPagadas ImgPaga, int idTipoPago, int IdPasivo, int IdAdelanto, int IdDescuento,int IdModPago,string Modalidad,int IdCuenta)
        {
            return DAOImagenesPagadas.DReciboInsertarAceite(Fecha, idPersona, idUsuario, monto, ImgPaga, idTipoPago, IdPasivo, IdAdelanto, IdDescuento,IdModPago,Modalidad,IdCuenta);
        }
        public static EntImagenesPagadas Download(int id)
        {
            return DAOImagenesPagadas.Download(id);
        }
        public static EntImagenesPagadas DownloadAceite(int id)
        {
            return DAOImagenesPagadas.DownloadAceite(id);
        }
        public static EntImagenesPagadas  ConsultaImagen(int id)
        {
            return DAOImagenesPagadas.ConsultaImagen(id);
        }

        public static EntImagenesPagadas ConsultaImagenAceite(int id)
        {
            return DAOImagenesPagadas.ConsultaImagenAceite(id);
        }
        public static int InsertarImagenAceites(EntImagenesPagadas ImgAceite)
        {
            return DAOImagenesPagadas.GuardarImagenAceite(ImgAceite);
        }

        public static int Verificar(int Id)
        {
            return DAOImagenesPagadas.ObtenerEstadoImagen(Id);
        }

        public static int VerificarAceite(int Id)
        {
            return DAOImagenesPagadas.ObtenerEstadoImagenAceite(Id);
        }

    }
}