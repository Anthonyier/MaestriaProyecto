using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using CapaEntidad;
using CapaDatos;
using System.Data;
using System.Data.SqlClient;
using CapaNegocios;
using System.IO;

namespace CapaPresentacion
{
    public partial class FormRepConCorporacionFlet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EntUsuario us = (EntUsuario)Session["Usuario"];
            EntBitacora bit = new EntBitacora();
            bit.Usuario = us.Nombre + "" + us.Apellidos;
            bit.IdUsuario = us.Id_Usuario;
            TextBus.Text = Request.QueryString["Id"];
            if (!IsPostBack)
            {
                ReportParameter p = new ReportParameter("Id", TextBus.Text);
                ReportViewer1.LocalReport.SetParameters(p);
                ReportViewer1.LocalReport.Refresh();
            }
            if (Request.QueryString["Id"] != null)
            {

            }
            else
            {
                
                bit.Accion = "El usuario esta intentando Asegurar Las Conciliaciones A Pagar De Corporacion";
               
                int bi = NegBitacora.GuardarBitacora(bit);
            }
            
            EntPermisosConciliaciones Persona = NegPermisosConciliaciones.BuscarPermiso(us.Id_Usuario);

            if (Persona.AsegCorp!= 1 && Persona.AsegAlc!=1)
            {
                ButtonAnticip.Visible = false;
                ButtonAnticip.Enabled = false;
                ButtonPagar.Visible = false;
                ButtonPagar.Enabled = false;
                ButtonSolicitud.Visible = false;
                ButtonSolicitud.Enabled = false;

            }
        }

        protected void ButtonBus_Click(object sender, EventArgs e)
        {
            ReportParameter p = new ReportParameter("Id", TextBus.Text);
            ReportViewer1.LocalReport.SetParameters(p);
            ReportViewer1.LocalReport.Refresh();
        }

        protected void ButtonPagar_Click(object sender, EventArgs e)
        {
            EntFacturaTrans f = new EntFacturaTrans();
            double Monto = 0;
            int id = int.Parse(TextBus.Text);
            Monto = NegFacturaTrans.BuscarPorPagar(id);
            f.Monto = Monto;
            f.factura = TextBoxLiquido.Text;
            f.Descripcion = "Total Pagable";
            f.IdConciliacion = id;
            int i = NegFacturaTrans.InsertarFactura(f);
            Response.Write("<script languaje =javascript>alert ('La de Factura de total Pagable han sido creada');</script>");
        }

        protected void ButtonAnticip_Click(object sender, EventArgs e)
        {
            EntFacturaTrans f = new EntFacturaTrans();
            double Monto = 0;
            int id = int.Parse(TextBus.Text);
            Monto = NegFacturaTrans.BuscarAnticipo(id);
            f.Monto = Monto;
            f.factura = TextAnticip.Text;
            f.Descripcion = "Anticipos";
            f.IdConciliacion = id;
            int i = NegFacturaTrans.InsertarFactura(f);
            Response.Write("<script languaje =javascript>alert ('Factura de Anticipo creada');</script>");
        }

        protected void ButtonSolicitud_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TextBus.Text);
            NegFacturaTrans.Solicitud(id);
            DateTime Fecha = Convert.ToDateTime("01/01/2010");
            string Mensaje = "";
            SqlDataReader d = NegFacturaTrans.ReaderFechaSolicitud(id);
            if (d.HasRows == true)
            {
                while (d.Read())
                {
                    try
                    {
                        Fecha = Convert.ToDateTime(d["FechaSolicitud"].ToString());
                        Mensaje = Mensaje + "Se Necesita Pagar las Liquidaciones De La Fecha: " + " " + Fecha + " ";
                    }
                    catch (Exception er)
                    {

                    }
                }

                NegFacturaTrans.EnviarCorreo(Mensaje);
                Response.Write("<script languaje =javascript>alert ('Se Ha Mandado la Solicitud De Pago');</script>");
            }
        }
    }
}