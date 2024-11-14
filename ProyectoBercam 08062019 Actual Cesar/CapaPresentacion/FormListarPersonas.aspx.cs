using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocios;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;
using CapaDatos;

namespace CapaPresentacion
{
    public partial class FormListarPersonas : System.Web.UI.Page
    {
        public string SuggestionListPersonas = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            EntUsuario us = (EntUsuario)Session["Usuario"];
            EntBitacora bit = new EntBitacora();
            bit.Usuario = us.Nombre + "" + us.Apellidos;
            bit.Accion = "El usuario esta en la lista de personas ";
            bit.IdUsuario = us.Id_Usuario;
            int bi = NegBitacora.GuardarBitacora(bit);

            EntUsuario usuario = (EntUsuario)Session["Usuario"];
            EntPermisoPersona Persona = NegPermisoPersona.BuscarPermiso(usuario.Id_Usuario);
            if (Persona.ListaPersona != 1)
            {
                GridView1.Visible = false;
                TxtBuscar.Visible = false;
                BtnBuscar.Visible = false;
            }
            string queryString = "SELECT * FROM vi_listaPersonasCL  ORDER BY Cliente";

            using (SqlConnection connection = new SqlConnection(Properties.Resources.ConexionBercamPrin))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            if (string.IsNullOrEmpty(SuggestionListPersonas))
                            {
                                SuggestionListPersonas += "\"" + reader["CLIENTE"].ToString() + "\"";
                            }
                            else
                            {
                                SuggestionListPersonas += ", \"" + reader["CLIENTE"].ToString() + "\"";
                            }

                        }
                    }
                }
            }
        }
        protected void DtgListaPersonas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            EntUsuario us = (EntUsuario)Session["Usuario"];
            EntBitacora bit = new EntBitacora();
            bit.Usuario = us.Nombre + "" + us.Apellidos;
            bit.IdUsuario = us.Id_Usuario;
            EntPermisoPersona Persona = NegPermisoPersona.BuscarPermiso(us.Id_Usuario);
            if (e.CommandName == "EditarPersona")
            {
                
               
                bit.Accion = "El usuario va editar una persona ";
                
                  int bi = NegBitacora.GuardarBitacora(bit);
                  if (Persona.ModificarUsuario == 1)
                  {
                      string sPersonaId = e.CommandArgument.ToString();
                      Response.Redirect("FrmRegistrodeEntidades.aspx?Id=" + sPersonaId);
                  }
            }
            if (e.CommandName == "AgregarDocumentos")
            {
                
               
                bit.Accion = "El usuario va agreagar documentos ";
               
                int bi = NegBitacora.GuardarBitacora(bit);
                 if (Persona.AgregarDocumentos == 1)
                 {
                     if (us.Id_Usuario == 1010)
                     {
                         string sPersonaId = e.CommandArgument.ToString();
                         Response.Redirect("FrmImagenes.aspx?Id=" + sPersonaId);
                     }
                     if(us.Id_Usuario==1022)
                     {
                         string sPersonaId = e.CommandArgument.ToString();
                         Response.Redirect("FrmImagenesJoseluis.aspx?Id=" + sPersonaId);
                     }
                     
                 }
            }
            if (e.CommandName == "DeshabilitarPersona")
            {
                
                
                bit.Accion = "El usuario ha deshabilitado una persona ";
                
                int bi = NegBitacora.GuardarBitacora(bit);
                if (Persona.Deshabilitar == 1)
                {
                    string sPersonaId = e.CommandArgument.ToString();
                    NegPersona.EliminarPersona(int.Parse(sPersonaId));
                    int Prov= NegPersona.ObtenerProveedor(int.Parse(sPersonaId));
                    NegPersona.DesactivarMaestroProveedor(Prov);
                    Response.Write("<script languaje =javascript>alert ('Deshabilitado satisfactoriamente');</script>");
                }
            }
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
           
            if (TxtBuscar.Text != "")
            {
                SqlDataReader d = NegPersona.BuscarPersona(TxtBuscar.Text);
                d.Read();
                if (d.HasRows == true)
                {
                    if (d != null)
                    {
                        try
                        {
                            TxtBuscar.Text = d["Id_Persona"].ToString();
                            Response.Redirect("FrmRegistrodeEntidades.aspx?Id=" + TxtBuscar.Text);
                        }
                        catch (Exception er)
                        {
                            
                            TxtBuscar.Text = "No se encontro registro de la persona, Registrelo e intente nuevamente";
                        }
                        finally
                        {

                        }
                    }
                    else
                    {
                        
                        TxtBuscar.Text = "No se encontro registro de la persona, Registrelo e intente nuevamente";
                    }
                }
                else
                {
                    
                    TxtBuscar.Text = "No se encontro registro de la persona, Registrelo e intente nuevamente";
                }
            }
            else
            {
                
                TxtBuscar.Text = "No se encontro registro de la persona, Registrelo e intente nuevamente";
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}