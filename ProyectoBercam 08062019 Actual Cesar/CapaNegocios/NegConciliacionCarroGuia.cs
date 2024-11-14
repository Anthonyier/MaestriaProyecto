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
    public class NegConciliacionCarroGuia
    {
        public static int Guardar(EntConciliacionCarroGuia CoCar)
        {
            return DAOConciliacionCarroGuia.GuardarConciliacion(CoCar);
        }
        public static double PrecioCamionGuia(int Periodo, int Año)
        {
            return DAOConciliacionCarroGuia.PrecioCamionGuia(Periodo, Año);
        }

        public static int EncontrarIdCliente(string Nombre)
        {
            return DAOConciliacionCarroGuia.EncontrarIdCliente(Nombre);
        }

        public static double EncontrarNumeroTelefono(int IdNumero, int Mes, int Año)
        {
            return DAOConciliacionCarroGuia.EncontrarNumeroTelefono(IdNumero, Mes, Año);
        }
        public static EntConciliacionCarroGuia EncontrarConciliacionCarroGuia(int IdPeriodo,int IdAño)
        {
            return DAOConciliacionCarroGuia.EncontrarConciliacionCarroGuia(IdPeriodo, IdAño);
        }
        public static int ObtenerMes(int Per)
        {
            return DAOConciliacionCarroGuia.ObtenerMes(Per);
        }

        public static void Aprobar(int Per,int Año)
        {
            DAOConciliacionCarroGuia.Aprobar(Per,Año);
        }
        public static int EncontrarId(int Per, int Año)
        {
            return DAOConciliacionCarroGuia.EncontrarId(Per, Año);
        }
        public static double EncontrarNumeroRastreo(int IdCamion, int Mes, int Año)
        {
            return DAOConciliacionCarroGuia.EncontrarMontoRastreo(IdCamion, Mes, Año);
        }
        public static int EncontrarId(int Id)
        {
            return DAOConciliacionCarroGuia.EncontrarIdConciliacion(Id);
        }
        public static EntConciliacionCarroGuia ObtenerConcCarroGuia(int Id)
        {
            return DAOConciliacionCarroGuia.ObtenerConcCarroGuia(Id);
        }
        public static int EncontrarRastreo(int idCamion, int Per, int Año)
        {
            return DAOConciliacionCarroGuia.Rastreo(idCamion, Per, Año);
        }
        public static double EncontrarPorPagar(int Id)
        {
            return DAOConciliacionCarroGuia.EncontrarPorPagar(Id);
        }
        public static void PendienteSolicitud(int id)
        {
             DAOConciliacionCarroGuia.PendientedeSolicitud(id);
        }
        public static void Pagado(int id)
        {
            DAOConciliacionCarroGuia.Pagado(id);
        }
    }
}