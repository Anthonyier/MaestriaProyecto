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
    public class NegConciliacionPorPagar
    {
        public static EntConciliacionPorPagar BuscarConcPagar(int id)
        {
            return DAOConciliacionPorPagar.ConcPagar(id);
        }

        public static void Revisar(int id)
        {
             DAOConciliacionPorPagar.Revisar(id);
        }
        public static void Pagado(int id)
        {
            DAOConciliacionPorPagar.Pagado(id);
        }
        public static void PagadoSinFactura(int id)
        {
            DAOConciliacionPorPagar.PagadoSinFactura(id);
        }
        public static bool Mensaje(string Mensj)
        {
            return DAOConciliacionPorPagar.EnviarCorreo(Mensj);
        }
        public static void ActualizarConciliacionPorPagarIdPmm(int Id_Pmm, int Id)
        {
            DAOConciliacionPorPagar.ActualizarConciliacionPorPagarIdPmm(Id_Pmm, Id);
        }
        public static int InsertarPagoMasivoLiqui()
        {
            return DAOConciliacionPorPagar.InsertarPagoMasivoLiqui();
        }
        public static int VerificarYaPagadoLiquidacion(int Id)
        {
            return DAOConciliacionPorPagar.VerificarYaPagadoLiquidacion(Id);
        }
        public static int EncontrarIdPagoMasiv(int Id)
        {
            return DAOConciliacionPorPagar.EncontrarIdPagoMasiv(Id);
        }
    }
}