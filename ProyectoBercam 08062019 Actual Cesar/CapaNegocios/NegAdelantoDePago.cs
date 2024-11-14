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
    public class NegAdelantoDePago
    {
        public static int InsertarAdelantoDePagos(EntAdelantoDePago AdelPa)
        {
            return DAOAdelanteoDePago.Guardar(AdelPa);
        }
        public static int GuardarAdelantoDEPago(EntAdelantoDePago AdelPa)
        {
           return DAOAdelanteoDePago.TransformarAdelantoDePago(AdelPa);
        }
        public static int IdPersona(int id)
        {
            return DAOAdelanteoDePago.IdPersonaAdelanto(id);
        }
        public static double EncontrarMonto(int id)
        {
            return DAOAdelanteoDePago.EncontrarMonto(id);
        }
        public static bool Maestroproveedor(DateTime Fecha, int idPersona, int idUsuario, double monto, EntImagenesAdelantoDePagos Adelanto, int idTipoPago, int IdPasivo,int IdModPago,string Modalidad,int IdCuenta)
        {
            return DAOAdelanteoDePago.DInsertar(Fecha, idPersona, idUsuario, monto, Adelanto, idTipoPago, IdPasivo,IdModPago,Modalidad,IdCuenta);
        }
        public static bool Mensaje(string Mensj)
        {
            return DAOAdelanteoDePago.EnviarCorreo(Mensj);
        }
        public static int ObtenerImagen(int id)
        {
            return DAOAdelanteoDePago.ObtenerIdImagen(id); 
        }
        public static void Estado(int id)
        {
            DAOAdelanteoDePago.Estado(id);
        }
        public static void FechaPago(int id, DateTime FechaPago)
        {
            DAOAdelanteoDePago.FechaPago(id, FechaPago);
        }
        public static SqlDataReader ReaderAdelanto(int id)
        {
            return DAOAdelanteoDePago.ReaderAdelanto(id);
        }
        public static int NEncontrarAdelantoDePago(int IdFactura)
        {
            return DAOAdelanteoDePago.DEncontrarAdelantoDePago(IdFactura);
        }
        public static int NEncontrarAdelantoPagoRecibo(int IdConc)
        {
            return DAOAdelanteoDePago.DEnconAdelPagoRecibo(IdConc);

        }
        public static int NEncontrarAdelPagoReciboAceite(int IdConc)
        {
            return DAOAdelanteoDePago.DEnconAdelPagoReciboAceite(IdConc);
        }
        public static void ActualizarIdAdelantoDePago(int Id_Pmm, int Id)
        {
             DAOAdelanteoDePago.ActualizarAdelantoIdPago(Id_Pmm, Id);
        }
        public static int InsertarPagoMasivoAdel()
        {
            return DAOAdelanteoDePago.InsertarPagoMasivoAdel();
        }
        public static int VerificarYaPagadoAdel(int Id)
        {
            return DAOAdelanteoDePago.VerificarYaPagadoAdel(Id);
        }
        public static int EncontrarIdPagoMasiv(int Id)
        {
            return DAOAdelanteoDePago.EncontrarIdPagoMasiv(Id);
        }
    }
}