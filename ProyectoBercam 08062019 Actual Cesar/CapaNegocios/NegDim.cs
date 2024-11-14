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
    public class NegDim
    {
        public static int InsertarDim(string Dim,string Producto,string Proveedor,string AduanaFrontera,List<EntDetalleDim>Lista)
        {
            return DAODim.InsertarDim(Dim, Producto, Proveedor, AduanaFrontera,Lista);
        }
        public static int AddDim(string Dim, string producto, string proveedor, string AduanaFrontera)
        {
            return DAODim.AddDim(Dim, producto, proveedor, AduanaFrontera);
        }
        public static bool CerrarDim(int Dim)
        {
            return DAODim.CerrarDim(Dim);
        }
        public static int EncontrarEstadoDim(int Dim)
        {
            return DAODim.EncontrarDimCerrado(Dim);
        }
        public static int ModificarDim(int Id, string Dim, string Producto, string Proveedor, string AduanFrontera)
        {
            return DAODim.ModificarDim(Id, Dim, Producto, Proveedor, AduanFrontera);
        }
        public static int DesactivarDim(int Id)
        {
            return DAODim.DesactivarDim(Id);
        }
        public static EntDim BuscarDim(int Id)
        {
            return DAODim.BuscarDim(Id);
        }
        public static int BuscarDimExistente(string Dim)
        {
            return DAODim.BuscarDimExistente(Dim);
        }
    }
}