using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using CapaDatos;


namespace CapaPresentacion
{
    /// <summary>
    /// Descripción breve de WebServiceTransbercam
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceTransbercam : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }
        [WebMethod]
        public DataSet GetData()
        {
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection Cnx = Conexion.conectar();
            Cnx.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Usuario", Cnx);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        [WebMethod]
        public DataSet GetViajes(int Mes, int Año,string Usuario,string Contraseña)
        {
            DataSet ds = new DataSet();
            if(Usuario=="UrQuiElva" && Contraseña=="2021WebService"){
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection Cnx = Conexion.conectar();
                Cnx.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * from VistaWebService where Mes=" + Mes + " and Año=" + Año, Cnx);

                da.Fill(ds);
            }
            return ds;
        }
    }
}
