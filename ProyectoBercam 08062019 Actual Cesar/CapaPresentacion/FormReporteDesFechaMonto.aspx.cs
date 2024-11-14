using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocios;
using CapaEntidad;
using System.Data;
using System.Data.SqlClient;

namespace CapaPresentacion
{
    public partial class FormReporteDesFechaMonto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        protected void ButtonReporte_Click(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }
            SqlDataReader d = NegPersona.BuscarPersona(TextoPlacasDescuenReportesFechaMonto.Text);
            d.Read();
            if (d.HasRows == true)
            {
                if (d != null)
                {
                    try
                    {
                        int IdTitular = int.Parse(d["Id_Persona"].ToString());
                        TextHid.Value = Convert.ToString(IdTitular);
                        ReportViewer1.LocalReport.Refresh();
                    }
                    catch (Exception er)
                    {


                    }
                }
            }
           
        }
    }
}