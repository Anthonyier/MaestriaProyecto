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
    public partial class FormCambiarCam : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                ddlChofer.AppendDataBoundItems = true;
                CargarComboChofer();
            }

            EntUsuario us = (EntUsuario)Session["Usuario"];
            EntBitacora bit = new EntBitacora();
            bit.Usuario = us.Nombre + "" + us.Apellidos;
            bit.Accion = "El usuario esta intentando modificar el chofer";
            bit.IdUsuario = us.Id_Usuario;
            int bi = NegBitacora.GuardarBitacora(bit);
        }

        public void CargarComboChofer()
        {
            ddlChofer.Items.Clear();
            ddlChofer.Items.Add(new ListItem("--Selecciona una Persona--", ""));
            ddlChofer.AppendDataBoundItems = true;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            SqlCommand cmd = new SqlCommand();
            try
            {
                String sql = "Select * from View_Chofer";
                //cmd.Parameters.AddWithValue("@Id_Tipo_Prod1", cmbCategoria1.SelectedItem.Value);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                //cmd.Transaction = myTrans;
                dr = cmd.ExecuteReader();
                ddlChofer.DataSource = dr; //cmd.ExecuteReader();    
                ddlChofer.DataTextField = "CLIENTE";
                ddlChofer.DataValueField = "CI";
                ddlChofer.DataBind();
                dr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Connection.Dispose();
            }
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (txtPlaca.Text != "")
            {
                EntCamiones ObjCamion = new EntCamiones();
                try
                {
                    ObjCamion.Placa = txtPlaca.Text;
                    ObjCamion.IdChofer = ddlChofer.Text;

                }
                catch (Exception ex)
                {
                    return;
                }
                if (NegCamiones.ActualizarChofer(ObjCamion) == 1)
                {
                    txtPlaca.Text = "";
                    ddlChofer.Text = "";
                    lblError.Text = "Cambio de chofer exitoso";
                    lblError.Visible = true;
                    Response.Write("<script languaje =javascript>alert ('Cambio de chofer exitoso');</script>");
                    EntUsuario us = (EntUsuario)Session["Usuario"];
                    EntBitacora bit = new EntBitacora();
                    bit.Usuario = us.Nombre + "" + us.Apellidos;
                    bit.Accion = "El usuario a logrado modificar el chofer";
                    bit.IdUsuario = us.Id_Usuario;
                    int bi = NegBitacora.GuardarBitacora(bit);
                }
                else
                {
                    lblError.Text = "No se pudo ACTUALIZAR el Registro por algun motivo, Verifique e intente nuevamente";
                    lblError.Visible = true;
                }
            }
            else
            {
                lblError.Text = "Faltan datos";
                lblError.Visible = true;
            }
        }
    }
}