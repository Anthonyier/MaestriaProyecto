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
    public class NegMaestroProveedor
    {
        public static int EncontrarIdProveedor(int IdTitular)
        {
            return DAOMaestroProveedor.EncontrarIdMaestro(IdTitular);
        }
        public static int EncontrarAnticipo(int Id)
        {
            return DAOMaestroProveedor.EncontrarIdAnticipo (Id);
        }
    }
}