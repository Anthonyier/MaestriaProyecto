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
    public class NegConciliacionPagarAceite
    {
        public static void PagadoAceite(int id)
        {
            DAOConciliacionPagarAceite.Pagado(id);
        }
        public static void PagadoSinFactura(int id)
        {
            DAOConciliacionPagarAceite.PagadoSinFactura(id);
        }
        public static EntConciliacionPagarAceite BuscarConcPagar(int id)
        {
            return DAOConciliacionPagarAceite.ConcPagar(id);
        }
        public static void ActualizarConciliacionPorPagarIdPmm(int Id_Pmm, int Id)
        {
            DAOConciliacionPagarAceite.ActualizarConciliacionPorPagarIdPmm(Id_Pmm, Id);
        }
        public static int InsertarPagoMasivoLiqui()
        {
            return DAOConciliacionPagarAceite.InsertarPagoMasivoLiqui();
        }
        public static int VerificarYaPagadoLiquidacion(int Id)
        {
            return DAOConciliacionPagarAceite.VerificarYaPagadoLiquidacion(Id);
        }
        public static int EncontrarIdPagoMasiv(int Id)
        {
            return DAOConciliacionPagarAceite.EncontrarIdPagoMasiv(Id);
        }
    }
}