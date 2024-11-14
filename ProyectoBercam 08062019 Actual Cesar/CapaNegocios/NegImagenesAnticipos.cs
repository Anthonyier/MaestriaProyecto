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
    public class NegImagenesAnticipos
    {
        public static int InsertarImagen(EntImagenesAnticipos obj)
        {
            return DAOImagenesAnticipos.GuardarImagenes(obj);
        }
        public static void ModificarOrdenesPago(int IdImagAnt, int IdImgAdel)
        {
            DAOImagenesAnticipos.ModificarOrdenesPago(IdImagAnt, IdImgAdel);
        }
        public static void EliminarImagenAntic(int IdDetalle)
        {
            DAOImagenesAnticipos.EliminarAnticipo(IdDetalle);
        }
        public static EntImagenesAnticipos Download(int id)
        {
            return DAOImagenesAnticipos.Download(id);
        }
        public static bool Maestroproveedor(DateTime Fecha, int idPersona, int idUsuario, double monto, EntImagenesAnticipos Anticip, int idTipoPago, int IdPasivo, int IdModPago, string Modalidad,int IdCuenta)
        {
            return DAOImagenesAnticipos.DInsertar(Fecha, idPersona, idUsuario, monto, Anticip, idTipoPago, IdPasivo, IdModPago, Modalidad,IdCuenta);
        }
        public static bool MaestroProveedorCheqInter(DateTime Fecha, int IdPersona, int IdUsuario, double monto, EntImagenesAnticipos Anticip, int IdtipoPago, int IdPasivo, string NroDocBancario, int IdModPago, string Modalidad,int IdCuenta)
        {
            return DAOImagenesAnticipos.DInsertarCheqInter(Fecha, IdPersona, IdUsuario, monto, Anticip, IdtipoPago, IdPasivo, NroDocBancario,IdModPago,Modalidad,IdCuenta);
        }
        public static EntImagenesAnticipos TransImagen(int id)
        {
            return DAOImagenesAnticipos.TransImagen(id);
        }
        public static int ValorImagen(int Id)
        {
            return DAOImagenesAnticipos.ValorImagen(Id);
        }
        public static void EnvioConfirmado(int id, DateTime Fecha)
        {
            DOAAsignarRuta.EnvioConfirmado(id, Fecha);
        }
        public static void PagoSinFactura(int IdDetalle)
        {
            DOAAsignarRuta.PagoSinFactura(IdDetalle);
        }
        public static int ObtenerImagAntic(int IdDetalle)
        {
           return  DAOImagenesAnticipos.ObtenerIdImagen(IdDetalle);
        }
        public static void DeshabilitarAnticipo(int IdDetalle)
        {
            DAOImagenesAnticipos.DeshabilitarAnticipo(IdDetalle);
        }
        public static int ObtenerIdPago(int Id)
        {
            return DAOImagenesAnticipos.ObtenerIdPago(Id);
        }
        public static int ObtenerDetalleIdPago(int id)
        {
            return DAOImagenesAnticipos.ObtenerIdDetalleOrdenPago(id);
        }
        public static void DeshabilitarDetalleOrdenPago(int idDetalle,int Id)
        {
            DAOImagenesAnticipos.DeshabilitarDetalleOrdenPago(idDetalle);
            DAOImagenesAnticipos.DeshabilitarOrdenPago(Id);
        }
        public static void EliminarAnticipoRecp(int id)
        {
            DOAAsignarRuta.ElimiarFechaAnticipo(id);
        }
        public static EntImagenesAnticipos ConsultaImagenMod(int id)
        {
            return DAOImagenesAnticipos.ConsultaImagenMod(id);
        }
        public static EntImagenesAnticipos ConsultaImagen(int id)
        {
            return DAOImagenesAnticipos.ConsultaImagen(id);
        }
        public static void ModificarImagenAnticipo(int id, DateTime fecha)
        {
            DAOImagenesAnticipos.ModificarImagen(id, fecha);
        }
        public static void ModificarFechaAnticipo(int id, DateTime fecha)
        {
            DAOImagenesAnticipos.ModificarFechaAnticipo(id, fecha);
        }
       
    }
}