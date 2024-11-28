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
    public partial class FormHabDeshab : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                CargarEstado();
            }
          
        }
        public void CargarEstado()
        {
            ddlEstado.Items.Clear();
            ddlEstado.Items.Add(new ListItem("--Seleccione un estado--", ""));
            ddlEstado.AppendDataBoundItems = true;
            SqlCommand cmd = new SqlCommand();
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {
                string sql = "select * from Estado where Id=1 or Id=2";
                cmd.CommandText = sql;
                cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                dr = cmd.ExecuteReader();
                ddlEstado.DataSource = dr;
                ddlEstado.DataTextField = "Desccripcion";
                ddlEstado.DataValueField = "Id";
                ddlEstado.DataBind();
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

        protected void BtnPlaca_Click(object sender, EventArgs e)
        {
            if (TxtPlacaHabDeshab.Text != "")
            {
                SqlDataReader d = NegAsignacionRuta.BuscarChofer(TxtPlacaHabDeshab.Text);
                d.Read();
                if (d.HasRows == true)
                {
                    if (d != null)
                    {
                        try
                        {
                            txtChofer.Text = d["Chofer"].ToString();
                        }
                        catch (Exception er)
                        {
                            TxtPlacaHabDeshab.Text = "no existe el camion";
                        }
                    }
                    else
                    {
                        TxtPlacaHabDeshab.Text = "no existe el camion";
                    }
                }
                else
                {
                    TxtPlacaHabDeshab.Text = "no existe el camion";
                }
            }
            else
            {
                TxtPlacaHabDeshab.Text = "no existe el camion";
            }
        }
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (TxtPlacaHabDeshab.Text != "" && txtChofer.Text != "")
            {
                string placa = TxtPlacaHabDeshab.Text;
                int es = int.Parse(ddlEstado.Text);
                string obs = txtOBS.Text;
                int chofer = 0;
                SqlDataReader d = NegAsignacionRuta.BuscarChofer(TxtPlacaHabDeshab.Text);
                d.Read();
                if (d.HasRows == true)
                {
                    if (d != null)
                    {
                        try
                        {
                            chofer = int.Parse(d["CI"].ToString());
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
                int Guarestado = NegCamiones.CambioEstado(es, placa, obs, chofer);
                if (Guarestado == 1)
                {
                    if (es == 1)// Preguntamos si estamos habilitando o deshabilitando
                    {
                        NegCamiones.Deshabilitar(placa);
                    }
                    else
                    {
                        NegCamiones.Habilitar(placa);
                    }
                    txtChofer.Text = "";
                    lblError.Text = "Modificacion de placa realizado satisfactoriamente";
                    lblError.Visible = true;
                    Response.Write("<script languaje =javascript>alert ('Modificacion de Placa realizado satisfactoriamente');</script>");
                }
                else
                {
                    lblError.Text = "No se pudo modificar el estado por algun motivo, Verifique e intente nuevamente";
                    lblError.Visible = true;
                }
            }
        }
    }
}