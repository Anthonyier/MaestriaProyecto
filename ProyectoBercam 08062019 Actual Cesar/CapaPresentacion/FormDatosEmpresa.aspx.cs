using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidad;
using CapaDatos;
using System.Data;
using System.Data.SqlClient;
using CapaNegocios;
using System.IO;

namespace CapaPresentacion
{
    public partial class FormDatosEmpresa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" && txtRazonSocial.Text != "" && txtNit.Text != "")
            {
                EntDatosEmpresa obj = new EntDatosEmpresa();
                try
                {
                    obj.Nombre = txtNombre.Text;
                    obj.RazonSocial = txtRazonSocial.Text;
                    obj.Nit = int.Parse(txtNit.Text);
                }
                catch (Exception ex)
                {
                    lblError.Text = "Algunos de los campos no tiene el formato correcto";
                    lblError.Visible = true;
                    return;
                }

                obj.Direccion = txtDireccion.Text;
                obj.Email = txtEmail.Text;
                obj.Rubro = txtRubro.Text;
                obj.Telefono = int.Parse(txtTelefono.Text);
                obj.Whatsapp = txtWhatsapp.Text;
                obj.Facebook = txtFacebook.Text;
                obj.NombreContacto = txtNombreContacto.Text;
                obj.PaginaWeb = txtPaginaWeb.Text;
                obj.EmailEnvio = txtEmailEnvio.Text;
                if (Request.QueryString["Id"] != null)
                {

                }
                else
                {
                    if (NegDatosEmpresa.InsertarDatosEmpresa(obj) == 1)
                    {
                        lblError.Text = "Registro de datos de la empresa guardado satisfactoriamente";
                        lblError.Visible = true;
                        Response.Write("<script languaje =javascript>alert ('Registro de datos de la empresa guardado satisfactoriamente');</script>");
                       txtDireccion.Text="";
                       txtEmail.Text="";
                       txtRubro.Text="";
                       txtTelefono.Text="";
                       txtWhatsapp.Text="";
                       txtFacebook.Text="";
                       txtNombreContacto.Text="";
                       txtPaginaWeb.Text="";
                       txtNombre.Text="";
                       txtEmailEnvio.Text = "";
                       txtRazonSocial.Text="";
                       txtNit.Text="";
                    }
                }

            }
        }
    }
}