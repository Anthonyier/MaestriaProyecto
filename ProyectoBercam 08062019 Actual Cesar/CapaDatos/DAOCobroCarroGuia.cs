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
    public class DAOCobroCarroGuia
    {
        public static int GuardarCobroGuia(EntCobroCarroGuia CobroGuia)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Insert Into CobroCarroGuia(id,Monto,Placa,fecha,IdCarroGuia) values (@id,@Monto,@Placa,@fecha,@IdCarroGuia);SELECT Scope_Identity();";
                cmd = new SqlCommand(sql, cnx);
            }
            catch (Exception e)
            {

            }

            return 1;
        }
    }
}