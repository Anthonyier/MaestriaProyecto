using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class DAOFacturaCamionGuia
    {
        public static void GuardarFacturaCarroGuia(EntFacturaCarroGuia Fact)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Insert Into FacturaCarroGuia(Factura,Descripcion,Monto,IdConciliacion) values (@Factura,@Descripcion,@Monto,@IdConciliacion);SELECT Scope_Identity();";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Factura", Fact.factura);
                cmd.Parameters.AddWithValue("@Descripcion", Fact.Descripcion);
                cmd.Parameters.AddWithValue("@Monto", Fact.Monto);
                cmd.Parameters.AddWithValue("@IdConciliacion", Fact.IdConciliacion);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                myTrans.Rollback();
                
            }
            myTrans.Commit();
            cnx.Close();
            
        }
    }
}