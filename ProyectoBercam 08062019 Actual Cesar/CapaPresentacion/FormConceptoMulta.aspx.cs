using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidad;
using CapaNegocios;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using CapaDatos;


namespace CapaPresentacion
{
    public partial class FormConceptoMulta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Id"] != null)
            {
                int idMulta = Convert.ToInt32(Request.QueryString["Id"]);
                SqlCommand cmd = null;
                SqlDataAdapter sda = new SqlDataAdapter();
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                try
                {

                    cmd = new SqlCommand("Select Concepto from Multa Where id=@id", cnx);
                    cmd.Parameters.AddWithValue("@id", idMulta);
                    cmd.Connection = cnx;
                    sda.SelectCommand = cmd;
                    cnx.Open();
                    ///////SqlDataReader lector = cmd.ExecuteReader(); //new SqlDataReader();
                    /////////int i = 0;
                    DataTable dt = new DataTable();
                    sda.Fill(dt);


                    ///// GridDetalleConciliacion.AutoGenerateColumns = false;
                    GridView1.DataSource = dt;////lista;
                    GridView1.DataBind();


                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}