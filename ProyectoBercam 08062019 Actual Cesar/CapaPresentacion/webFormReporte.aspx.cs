using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using CapaEntidad;
using System.Data;
using CapaDatos;
namespace CapaPresentacion
{
    public partial class webFormReporte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlCommand cmd = null;
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                string sql= "Select * from Transaccion";
                SqlDataAdapter da = new SqlDataAdapter();
            }
        }
    }
}