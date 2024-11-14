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
    public partial class FrmImagenesJoseluis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int CodigoEntidad;
                int PersonaId = Convert.ToInt32(Request.QueryString["Id"]);
                EntPersona objPropietario = new EntPersona();
                EntPersona objPersImg = new EntPersona();
                EntImagenes ObjImagen = new EntImagenes();

                objPropietario = NegPersona.BuscarTodo(PersonaId); //haber
                Session["CodigoEnte"] = Convert.ToInt32(objPropietario.Cod_Ente);
                CodigoEntidad = Convert.ToInt32(objPropietario.Cod_Ente);
                TextBoxCi.Text = objPropietario.CI;
                TextBoxPersona.Text = objPropietario.Nombres + " " + objPropietario.Apellidos;
                objPersImg = NegPersona.BuscarPersonaVigenciaPR(CodigoEntidad, 2004);
                ObjImagen = NegImagenes.ConsultaImagen(CodigoEntidad, 2004);
                double diasVigenciaCertMedico;
                if (objPersImg != null)
                {
                    diasVigenciaCertMedico = Convert.ToDouble(objPersImg.DiasVigenciaCI);
                    DateTime fec = Convert.ToDateTime(objPersImg.VigenciaCI);
                    TextCertMedico.Text = fec.ToShortDateString();

                }
                else
                {
                    diasVigenciaCertMedico = 0;
                    TextCertMedico.Text = "FECHA VENCIMIENTO NO REGISTRADA";
                }
                if (diasVigenciaCertMedico > 0 && diasVigenciaCertMedico <= 30)
                {
                    TextCertMedico.BackColor = Color.Orange;
                    LabelCertMedico.Text = "El documento se vence en menos de 30 dias";
                    string EMensaje = "El Certificado De Manejo defensivo del  transportista: " + " " + TextBoxPersona.Text + " esta proximo a vencerse, Verifique en Sistema";


                }
                if (diasVigenciaCertMedico <= 0)
                {
                    bool result = TextCertMedico.Text.Equals("FECHA VENCIMIENTO NO REGISTRADA");
                    if (result == true)
                    {
                        TextCertMedico.BackColor = Color.Blue;
                        LabelCertMedico.Text = "Documento Vacio o no registrado";
                        string EMensaje = "El Certificado Medico del transportista: " + " " + TextBoxPersona.Text + " esta Vacio o no registrado, Verifique en Sistema";
                        LabelCertMedico.BackColor = Color.Blue;
                    }
                    else
                    {
                        TextCertMedico.BackColor = Color.Red;
                        LabelCertMedico.Text = "Documento VENCIDO";
                        string EMensaje = "El Certificado Medico del transportista: " + " " + TextBoxPersona.Text + " esta VENCIDO o no Registrado, Verifique en Sistema";

                    }
                }
                EntUsuario us = (EntUsuario)Session["Usuario"];
                EntBitacora bit = new EntBitacora();
                bit.Usuario = us.Nombre + "" + us.Apellidos;
                bit.Accion = "El usuario esta intentando insertar imagenes";
                bit.IdUsuario = us.Id_Usuario;
                int bi = NegBitacora.GuardarBitacora(bit);
            }
        }
        protected void ImageCertMed_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarCertMedico.Visible)
            {
                CalendarCertMedico.Visible = false;
            }
            else
            {
                CalendarCertMedico.Visible = true;
            }
        }
        protected void CalendarCertMedico_SelectionChanged(object sender, EventArgs e)
        {
            if (CalendarCertMedico.SelectedDate != null)
            {
                TextCertMedico.Text = CalendarCertMedico.SelectedDate.ToString("d");
                CalendarCertMedico.Visible = false;
            }
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            EntImagenes CertMedico = new EntImagenes();

            try
            {
                CertMedico.Vigencia = Convert.ToDateTime(TextCertMedico.Text);
                int Date = DateTime.Compare(CertMedico.Vigencia, DateTime.Today);
                if (Date <= 0)
                {
                    lblError.Text = "La Fecha del certificado de manejo defensivo es menor a la actual";
                    lblError.Visible = true;
                    CertMedico.Vigencia = Convert.ToDateTime(DateTime.Now.ToString());
                }
                DateTime Fecha;
                if (DateTime.TryParseExact(TextCertMedico.Text, "dd/mm/yyyy", null, System.Globalization.DateTimeStyles.None, out Fecha))
                {

                }
                else
                {
                    lblError.Text = "La Fecha Del  Certificado de Manejo Defensivo no es Valida";
                    lblError.Visible = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "El Campo Certificado Medico no tiene el formato correcto";
                lblError.Visible = true;
                CertMedico.Vigencia = Convert.ToDateTime(DateTime.Now.ToString());
            }
            if (CertMedico.Vigencia != null)
            {
                CertMedico.Tipo_Imagen = 2002;
                CertMedico.Cod_Ente = Convert.ToInt32(Session["CodigoEnte"]);
                if (NegImagenes.InsertarImagen(CertMedico) == 1)
                {

                }
                else
                {
                    lblError.Text = "No se pudo Insertar el Registro Certificado Medico por algun motivo, Verifique e intente Nuevamente";
                    lblError.Visible = true;
                }
            }
            EntUsuario us = (EntUsuario)Session["Usuario"];
            EntBitacora bit = new EntBitacora();
            bit.Usuario = us.Nombre + "" + us.Apellidos;
            bit.Accion = "El usuario a logrado Insertar imagenes";
            bit.IdUsuario = us.Id_Usuario;
            int bi = NegBitacora.GuardarBitacora(bit);
            TextCertMedico.Text = "";
        }

    
    }
}