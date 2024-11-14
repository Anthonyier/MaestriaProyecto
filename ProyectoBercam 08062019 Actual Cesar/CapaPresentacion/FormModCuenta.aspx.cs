using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using CapaEntidad;
using CapaDatos;
using CapaNegocios;

namespace CapaPresentacion
{
    public partial class FormModCuenta : System.Web.UI.Page
    {
        string num = "";
        string nom = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Id"] != null)
            {
              num = TextNumeroOrden.Text;
              nom = TextNombredelaAccion.Text;
              int id=Convert.ToInt32(Request.QueryString["Id"]);
              EntCuentaContable obj= NegCuentaContable.BuscarMod(id);
              TextId.Text = Convert.ToString(obj.Id);
              TextNumeroOrden.Text = obj.NumerodeOrden;
              TextNombredelaAccion.Text = obj.NombredelaAccion;
              TextIdPadre.Text = Convert.ToString(obj.Idpadre);
               

            }
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (TextId.Text != "" && TextNumeroOrden.Text != "")
            {
                if (Request.QueryString["Id"] != null)
                {
                    EntCuentaContable obj = new EntCuentaContable();
                    obj.Id = Convert.ToInt32(TextId.Text);
                    obj.NumerodeOrden = num;
                    obj.NombredelaAccion = nom;
                    obj.Idpadre = Convert.ToInt32(TextIdPadre.Text);
                    if (NegCuentaContable.ActualizarCuenta(obj) == 1)
                    {
                        lblError.Text = "Cuenta Contable ACTUALIZADA satisfactoriamente";
                        lblError.Visible = true;
                        Response.Write("<script languaje =javascript>alert ('Cuenta Contable ACTUALIZADA satisfactoriamente');</script>");
                        TextId.Text = "";
                        TextNumeroOrden.Text = "";
                        TextNombredelaAccion.Text = "";
                        TextIdPadre.Text = "";
                    }
                }
            }
            else
            {
                lblError.Text = "Faltan Ingresar campos Obligatorios";
                lblError.Visible = true;
            }
        }
    }
}