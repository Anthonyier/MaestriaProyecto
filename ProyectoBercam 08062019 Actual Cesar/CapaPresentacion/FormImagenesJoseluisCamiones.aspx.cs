using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidad;
using System.IO;
using CapaNegocios;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Threading;

namespace CapaPresentacion
{
    public partial class FormImagenesJoseluisCamiones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int CodigoCamion;
                int CamionId = Convert.ToInt32(Request.QueryString["Id"]);
                EntCamiones objPropietario = new EntCamiones();
                EntDetalle_Certificados objPersImg = new EntDetalle_Certificados();
                objPropietario = NegCamiones.BuscarCamiones(CamionId);
                CodigoCamion = Convert.ToInt32(objPropietario.Id_Camion);
                TextBoxID.Text = Convert.ToString(objPropietario.Id_Camion);
                TextBoxPlaca.Text = objPropietario.Placa;

                objPersImg = NegCamiones.BuscarVigencia(CodigoCamion, 21);
                double diasVigenciaCertExt;
                if (objPersImg != null)
                {
                    diasVigenciaCertExt = Convert.ToDouble(objPersImg.DiasVigencia);
                    DateTime fec = Convert.ToDateTime(objPersImg.Fecha_Vencimiento);
                    TextCertExtintores.Text = fec.ToShortDateString();
                }
                else
                {
                    diasVigenciaCertExt = 0;
                    TextCertExtintores.Text = "FECHA DE VENCIMIENTO NO REGISTRADA";
                }
                if (diasVigenciaCertExt > 0 && diasVigenciaCertExt <= 30)
                {
                    TextCertExtintores.BackColor = Color.Orange;
                    LabelCertExtin.Text = "El documento se vence en menos de 30 dias";

                    string EMensaje = "El Certificado De Extintores: " + " " + TextBoxPlaca.Text + " esta proximo a vencerse, Verifique en Sistema";
                }
                if (diasVigenciaCertExt  <= 0)
                {
                    TextCertExtintores.BackColor = Color.Red;
                    LabelCertExtin.Text = "Documento VENCIDO o NO REGISTRADO";

                    string EMensaje = "El Certificado De Extintores: " + " " + TextBoxPlaca.Text + " esta VENCIDO o no Registrado, Verifique en Sistema";

                }

                objPersImg = NegCamiones.BuscarVigencia(CodigoCamion, 24);
                double diasVigenciaCheckList;
                if (objPersImg != null)
                {
                    diasVigenciaCheckList = Convert.ToDouble(objPersImg.DiasVigencia);
                    DateTime fec = Convert.ToDateTime(objPersImg.Fecha_Vencimiento);
                    TextCheckList.Text = fec.ToShortDateString();
                }
                else
                {
                    diasVigenciaCheckList = 0;
                    TextCheckList.Text = "FECHA DE VENCIMIENTO NO REGISTRADA";
                }
                if (diasVigenciaCheckList > 0 && diasVigenciaCheckList <= 15)
                {
                    TextCheckList.BackColor = Color.Orange;
                    Label1.Text = "El documento se vence en menos de 15 dias";
                    string EMensaje = "El Certificado De CheckList: " + " " + TextCheckList.Text + " esta proximo a vencerse, Verifique en Sistema";

                }
                if (diasVigenciaCheckList <= 0)
                {
                    TextCheckList.BackColor = Color.Red;
                    Label1.Text = "Documento VENCIDO O NO REGISTRADO";
                    string EMensaje = "El Certificado De CheckList: " + " " + TextCheckList.Text + " esta VENCIDO o no Registrado, Verifique en Sistema";
                }
            }

        }

        protected void ImageCertExtin_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarCertExtin.Visible)
            {
                CalendarCertExtin.Visible = false;
            }
            else
            {
                CalendarCertExtin.Visible = true;
            }
        }
        protected void CalendarCertExtin_selectionChanged(object sender, EventArgs e)
        {
            if (CalendarCertExtin.SelectedDate != null)
            {
                TextCertExtintores.Text = CalendarCertExtin.SelectedDate.ToString("d");
                CalendarCertExtin.Visible = false;
            }
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            EntDetalle_Certificados CertExt = new EntDetalle_Certificados();
            EntDetalle_Certificados CheckList= new EntDetalle_Certificados();
            CertExt.Id_Certificado = 21;
            CheckList.Id_Certificado = 24;
            try
            {
                CertExt.Fecha_Vencimiento = Convert.ToDateTime(TextCertExtintores.Text);
                CertExt.Id_Camion = Convert.ToInt32(Request.QueryString["Id"]);
                CertExt.Aplica = 1;
            }
            catch (Exception ex)
            {
                lblError.Text = "El Campo Vigencia De Certifiacdo De Extintores no tiene el formato correcto";
                lblError.Visible = true;
                CertExt.Fecha_Vencimiento = Convert.ToDateTime(DateTime.Now.ToString());
            }
            try
            {
                CheckList.Fecha_Vencimiento = Convert.ToDateTime(TextCheckList.Text);
                CheckList.Id_Camion = Convert.ToInt32(Request.QueryString["Id"]);
                CheckList.Aplica = 1;
            }
            catch (Exception ex)
            {
                lblError.Text = "El Campo Vigencia De Certifiacdo De CheckList no tiene el formato correcto";
                lblError.Visible = true;
                CheckList.Fecha_Vencimiento = Convert.ToDateTime(DateTime.Now.ToString());
            }
            if (CertExt.Fecha_Vencimiento != null)
            {
                if (NegImagCert.ObtenerFecha(CertExt) != CertExt.Fecha_Vencimiento)
                {
                    if (NegImagCert.InsertarImagen(CertExt) == 1)
                    {

                    }
                    else
                    {

                        lblError.Text = "No se pudo Insertar la Tarjeta de operación Tracto por algun motivo, Verifique e intente nuevamente";
                        lblError.Visible = true;

                    }
                }
            }
            if (CheckList.Fecha_Vencimiento != null)
            {
                if (NegImagCert.ObtenerFecha(CheckList) != CheckList.Fecha_Vencimiento)
                {
                    if (NegImagCert.InsertarImagen(CheckList) == 1)
                    {

                    }
                    else
                    {
                        lblError.Text = "No se pudo Insertar la Tarjeta de operación Tracto por algun motivo, Verifique e intente nuevamente";
                        lblError.Visible = true;
                    }
                }
            }
            EntUsuario us = (EntUsuario)Session["Usuario"];
            EntBitacora bit = new EntBitacora();
            bit.Usuario = us.Nombre + "" + us.Apellidos;
            bit.Accion = "El usuario a logrado Insertar imagenes de camiones";
            bit.IdUsuario = us.Id_Usuario;
            int bi = NegBitacora.GuardarBitacora(bit);
            TextCertExtintores.Text = "";
            TextCheckList.Text = "";
        }

        protected void BtnImagenesCarla_Click(object sender, EventArgs e)
        {
            int IdCamion = Convert.ToInt32(Request.QueryString["Id"]);
            Response.Redirect("FormImagenesCarla.aspx?Id=" + IdCamion );
        }

        protected void ImageCheckList_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarCheckList.Visible)
            {
                CalendarCheckList.Visible = false;
            }
            else
            {
                CalendarCheckList.Visible = true;
            }
        }
        protected void CalendarCheckList_selectionChanged(object sender, EventArgs e)
        {
            if (CalendarCheckList.SelectedDate != null)
            {
                TextCheckList.Text = CalendarCheckList.SelectedDate.ToString("d");
                CalendarCheckList.Visible = false;
            }
        }
    }
}