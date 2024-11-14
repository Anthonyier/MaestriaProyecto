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
    public partial class FormProveedores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }

        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombres.Text != "" && txtCI.Text != "")
            {
                EntProveedores Prov = new EntProveedores();

                try
                {
                    Prov.CI = txtCI.Text;
                }
                catch (Exception ex)
                {
                    lblError.Text = "El campo CI no tiene el formato correcto";
                    lblError.Visible = true;
                    return;
                }
                Prov.Nombre = txtNombres.Text;
                Prov.Apellidos = txtApellidos.Text;
                Prov.Direccion = txtDireccion.Text;
                Prov.Emision = txtEmision.Text;
                Prov.Telefono = txtTelefono.Text;
                Prov.TelfReferencia = txtTelfReferencia.Text;
                Prov.Email = txtEmail.Text;
                if (Request.QueryString["Id"] != null)
                {

                }
                else
                {
                    if (NegProveedores.InsertarProveedores(Prov) == 1)
                    {
                        lblError.Text = "Registro de Entidad guardado satisfactoriamente";
                        lblError.Visible = true;
                        Response.Write("<script languaje =javascript>alert ('Registro de Entidad guardado satisfactoriamente');</script>");
                        //Response.Redirect("frmRegistrarPropietarios.aspx");
                        txtCI.Text = "";
                        txtNombres.Text = "";
                        txtApellidos.Text = "";
                        txtEmision.Text = "";
                        txtDireccion.Text = "";
                        txtTelefono.Text = "";
                        txtTelfReferencia.Text = "";
                        txtEmail.Text = "";
                    }
                    else
                    {
                        lblError.Text = "No se pudo Insertar el Proveedor por algun motivo, Verifique e intente nuevamente";
                        lblError.Visible = true;

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