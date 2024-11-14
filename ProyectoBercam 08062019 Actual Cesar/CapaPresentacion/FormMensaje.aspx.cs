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
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Threading;

namespace CapaPresentacion
{
    public partial class FormMensaje : System.Web.UI.Page
    {
        MailMessage msj = new MailMessage();
        SmtpClient smtp = new SmtpClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CargarMensaje();
            }

        }

        public void CargarMensaje()
        {
            ddlMensaje.Items.Clear();
            ddlMensaje.Items.Add(new ListItem("--Seleccione un Mensaje--", ""));
            ddlMensaje.AppendDataBoundItems = true;
            SqlCommand cmd = new SqlCommand();
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {
                string sql = "SELECT * FROM Persona";
                cmd.CommandText = sql;
                cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                dr = cmd.ExecuteReader();
                ddlMensaje.DataSource = dr;
                ddlMensaje.DataTextField = "Email";
                ddlMensaje.DataValueField = "Email";
                ddlMensaje.DataBind();
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

        public bool EnviarCorreos(string Mensaje)
        {
            try
            {
                string Correo = ddlMensaje.Text;
                msj.From = new MailAddress("transbercamcorreo@gmail.com");
                msj.To.Add(new MailAddress(Correo));
                msj.Body = Mensaje;
                msj.Subject = "El transportista tiene un documento vencido";
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                string fr = "transbercamcorreo@gmail.com";
                //string pass = "transbercam12345";
                string pass = "kcqbzupdtnioterv";
                smtp.Credentials = new NetworkCredential(fr, pass);
                smtp.EnableSsl = true;
                smtp.Send(msj);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }

        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = "Un documento ha vencido o estar por vencer,porfavor vaya a revisarlo";
            if (EnviarCorreos(mensaje) == true)
            {
                lblError.Text = "Mensaje enviado satisfactoriamente";
                lblError.Visible = true;
            }
            else
            {
                lblError.Text = "El Mensaje no se puedo enviar correctamente";
                lblError.Visible = true;
            }
        }

    }
}