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
    public partial class FormMarcas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
             if (TextMarca.Text != "")
            {
                EntMarca ObjMarc = new EntMarca();
                ObjMarc.Descripcion = TextMarca.Text;
                EntMarca mar = null;
                mar = NegMarca.Repetidos(ObjMarc.Descripcion);
                if (mar != null)
                {
                    lblError.Text = "No se permiten datos repetidos";
                    lblError.Visible = true;
                    return;
                }
                if (Request.QueryString["Id"] != null)
                {
                    //ActualizaRegistros
                    ObjMarc.Id_Marca = Convert.ToInt32(Request.QueryString["Id"]);
                    if (NegMarca.ActualizarMarca(ObjMarc) == 1)
                    {
                        //Response.Redirect("frmPrincipal.aspx");
                        //lblError.Text = "Registro de Entidad ACTUALIZADO satisfactoriamente";
                        //lblError.Visible = true;
                        Response.Write("<script languaje =javascript>alert ('Registro de Entidad ACTUALIZADO satisfactoriamente');</script>");
                        //Response.Redirect("frmRegistrarPropietarios.aspx");
                        TextMarca.Text = "";
                       
                    }
                    else
                    {
                        lblError.Text = "No se pudo ACTUALIZAR el Registro por algun motivo, Verifique e intente nuevamente";
                        lblError.Visible = true;
                    }
                }
                else
                {
                    if (NegMarca.InsertarMarca(ObjMarc)== 1)
                    {
                        //Response.Redirect("frmPrincipal.aspx");
                        lblError.Text = "Registro de Marca guardado satisfactoriamente";
                        lblError.Visible = true;
                        Response.Write("<script languaje =javascript>alert ('Registro de Marca guardado satisfactoriamente');</script>");
                        //Response.Redirect("frmRegistrarPropietarios.aspx");
                        TextMarca.Text = "";
                        

                    }
                    else
                    {
                        lblError.Text = "No se pudo Insertar el Registro por algun motivo, Verifique e intente nuevamente";
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