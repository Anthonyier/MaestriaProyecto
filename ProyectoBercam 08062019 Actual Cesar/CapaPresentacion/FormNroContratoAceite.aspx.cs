using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using System.Data;
using System.Data.SqlClient;
using CapaNegocios;
using CapaEntidad;

namespace CapaPresentacion
{
    public partial class FormNroContratoAceite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (TextNumeroContrato.Text != null)
            {
                int id = Convert.ToInt32(Request.QueryString["Id"]);
                bool Valor = NegConciliacionPorCobrarAceite.ModificarNroContrato(id, TextNumeroContrato.Text);
                if (Valor == true)
                {
                    lblError.Text = "Se Logro Agregar Numero De Contrato";
                    lblError.Visible = true;

                }
                else
                {
                    lblError.Text = "No Se Logro Agregar Numero De Contrato";
                    lblError.Visible = true;
                }
            }
        }
    }
}