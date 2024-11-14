using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidad;
using CapaDatos;
using CapaNegocios;
namespace LogisticaBercam
{
    public partial class frmLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                Response.Redirect("frmPrincipal.aspx");
            }
        }

        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            lblNombreUser.Text = "";
            if (txtUsuario.Text != "" && txtContraseña.Text != "")
            {
                EntUsuario obj = NegUsuario.Login(txtUsuario.Text, txtContraseña.Text);
                if (obj!=null)
                {
                    Session["Usuario"] = obj;
                    lblNombreUser.Text = obj.Nombre.ToString() + " " + obj.Apellidos.ToString();
                    lblNombreUser.Visible = true;
                    Response.Redirect("frmPrincipal.aspx");
                }
                else
                {
                    lblError.Text = "Usuario o Contraseña invalidos";
                    lblError.Visible = true;
                }
            }
            else
            {
                lblError.Text = "Falta ingresar campos";
                lblError.Visible = true;
            }
        }
    }
}