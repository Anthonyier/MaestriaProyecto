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
    public partial class FormColor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
             protected void BtnGuardar_Click(object sender, EventArgs e)
        {
             if (TextColor.Text != "")
            {
                EntColor ObjColor = new EntColor();
                ObjColor.Descripcion = TextColor.Text;
                EntColor obj = null;
                obj = NegColor.Repetidos(ObjColor.Descripcion);
                if (obj != null)
                {
                    lblError.Text = "No se permiten datos repetidos";
                    lblError.Visible = true;
                    return;
                }

                if (Request.QueryString["Id"] != null)
                {
                    //ActualizaRegistros
                    ObjColor.Id_Color = Convert.ToInt32(Request.QueryString["Id"]);
                    if (NegColor.ActualizarColor(ObjColor) == 1)
                    {
                        //Response.Redirect("frmPrincipal.aspx");
                        //lblError.Text = "Registro de Entidad ACTUALIZADO satisfactoriamente";
                        //lblError.Visible = true;
                        Response.Write("<script languaje =javascript>alert ('Registro de Entidad ACTUALIZADO satisfactoriamente');</script>");
                        //Response.Redirect("frmRegistrarPropietarios.aspx");
                        TextColor.Text = "";
                       
                    }
                    else
                    {
                        lblError.Text = "No se pudo ACTUALIZAR el Registro por algun motivo, Verifique e intente nuevamente";
                        lblError.Visible = true;
                    }
                }
                else
                {
                    if (NegColor.InsertarColor(ObjColor)== 1)
                    {
                        //Response.Redirect("frmPrincipal.aspx");
                        lblError.Text = "Registro de Marca guardado satisfactoriamente";
                        lblError.Visible = true;
                        Response.Write("<script languaje =javascript>alert ('Registro de Entidad guardado satisfactoriamente');</script>");
                        //Response.Redirect("frmRegistrarPropietarios.aspx");
                        TextColor.Text = "";
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