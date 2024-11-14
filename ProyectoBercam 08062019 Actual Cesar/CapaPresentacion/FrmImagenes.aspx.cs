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
    public partial class Imagenes : System.Web.UI.Page
    {
        MailMessage msj = new MailMessage();
        SmtpClient smtp = new SmtpClient();

        
        public bool EnviarCorreo(string Mensaje)
        {
            //Thread thread;// = new Thread(;
            try
            {
                msj.From = new MailAddress("transbercamcorreo@gmail.com");
                msj.To.Add(new MailAddress("anthonyriberas6v@gmail.com"));
                msj.Body = Mensaje;
                msj.Subject = "Transportista con Documento Vencido";
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                string fr = "transbercamcorreo@gmail.com";
                //string pass = "transbercam12345";
                string pass = "kcqbzupdtnioterv";
                smtp.Credentials = new NetworkCredential(fr, pass);
                smtp.EnableSsl = true;
                //thread = new Thread(smtp.Send(msj));
                smtp.Send(msj);
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
        }

        
        //protected void llamar(string s)
        //{
        //    EnviarCorreo(s);
        //}
      
        //public int CodigoEntidad;

        //Thread thread ;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["CodigoEnte"]
            if (!IsPostBack)
            {
                int CodigoEntidad;
                int PersonaId = Convert.ToInt32(Request.QueryString["Id"]);
                EntPersona objPropietario = new EntPersona();
                Thread[]array=new Thread[4];
                array[0] = null;
                array[1] = null;
                array[2] = null;
                array[3] = null;
                EntPersona objPersImg = new EntPersona();
                EntImagenes ObjImagen = new EntImagenes();
            
                objPropietario = NegPersona.BuscarTodo(PersonaId); //haber
                Session["CodigoEnte"] = Convert.ToInt32(objPropietario.Cod_Ente);
                CodigoEntidad = Convert.ToInt32(objPropietario.Cod_Ente);
                TextBoxCi.Text = objPropietario.CI;
                TextBoxPersona.Text = objPropietario.Nombres + " " + objPropietario.Apellidos;

         


                    objPersImg = NegPersona.BuscarPersonaVigenciaPR(CodigoEntidad, 1);
                    ObjImagen = NegImagenes.ConsultaImagen(CodigoEntidad, 1);
                    double diasVigenciaCI;
                    if (objPersImg != null)
                    {
                        diasVigenciaCI = Convert.ToDouble(objPersImg.DiasVigenciaCI);
                        DateTime fec = Convert.ToDateTime(objPersImg.VigenciaCI);
                        txtVencimientoCI.Text = fec.ToShortDateString();//Convert.ToString(objPersImg.VigenciaCI,"dd/MM/yyyy");
                       
                    }
                    else
                    {
                        diasVigenciaCI = 0;
                        txtVencimientoCI.Text = "FECHA VENCIMIENTO NO REGISTRADA";
                    }

                //double diasVigenciaCI = NegPersona.BuscarPersonaVigencia(CodigoEntidad, 1); //Convert.ToDouble(objPropietario.DiasVigenciaCI);
                //double diasVigenciaLic = NegPersona.BuscarPersonaVigencia(CodigoEntidad, 2); //Convert.ToDouble(objPropietario.DiasVigenciaLicencia);
                //double diasVigenciaFelcn = NegPersona.BuscarPersonaVigencia(CodigoEntidad, 3); //Convert.ToDouble(objPropietario.DiasVigenciaFelcn);
                //double diasVigenciaRejap = NegPersona.BuscarPersonaVigencia(CodigoEntidad, 4); //Convert.ToDouble(objPropietario.DiasVigenciaRejap);

                    if (diasVigenciaCI > 0 && diasVigenciaCI <= 30)
                    {
                        txtVencimientoCI.BackColor = Color.Orange;
                        lblVigenciaCI.Text = "El documento se vence en menos de 30 dias";

                        string EMensaje = "El CI del transportista: " + " " + TextBoxPersona.Text + " esta proximo a vencerse, Verifique en Sistema";
                        //thread = new Thread();
                        //Thread thread1 = new Thread(() => EnviarCorreo(EMensaje));
                        //thread1.Start();
                        //thread1.Join();
                        //EnviarCorreo(EMensaje);
                        //array[0] = new Thread(() => EnviarCorreo(EMensaje));
                        //array[0].Start();
                    }
                    if (diasVigenciaCI <= 0 )
                    {
                        bool result = txtVencimientoCI.Text.Equals("FECHA VENCIMIENTO NO REGISTRADA");
                        if (result==true)
                        {
                            txtVencimientoCI.BackColor = Color.Blue;
                            lblVigenciaCI.Text = "Documento Vacio o no Registrado";
                            string EMensaje = "El CI del transportista: " + " " + TextBoxPersona.Text + " esta vacio o no es valido, Verifique en Sistema";
                            lblVigenciaCI.BackColor = Color.Blue;
                        }
                        else
                        {
                            txtVencimientoCI.BackColor = Color.Red;
                            lblVigenciaCI.Text = "Documento VENCIDO";
                            string EMensaje = "El CI del transportista: " + " " + TextBoxPersona.Text + " esta VENCIDO o no Registrado, Verifique en Sistema";
                        }                     
                        //Thread thread = new Thread(() => EnviarCorreo(EMensaje));
                        //thread.Start();
                        //thread.Join();
                        //EnviarCorreo(EMensaje);
                        //array[0] = new Thread(() => EnviarCorreo(EMensaje));
                        //array[0].Start();
                    }


                //para licencia
                    objPersImg = NegPersona.BuscarPersonaVigenciaPR(CodigoEntidad, 2);
                    ObjImagen = NegImagenes.ConsultaImagen(CodigoEntidad, 2);
                    double diasVigenciaLic;
                    if (objPersImg != null)
                    {
                        diasVigenciaLic = Convert.ToDouble(objPersImg.DiasVigenciaCI);
                        DateTime fec = Convert.ToDateTime(objPersImg.VigenciaCI);
                        txtVigenciaLic.Text = fec.ToShortDateString();//Convert.ToString(objPersImg.VigenciaCI);
                       
                    }
                    else
                    {
                        diasVigenciaLic = 0;
                        txtVigenciaLic.Text = "FECHA VENCIMIENTO NO REGISTRADA";
                    }
                    if (diasVigenciaLic > 0 && diasVigenciaLic <= 30)
                    {
                        txtVigenciaLic.BackColor = Color.Orange;
                        lblVigenciaLic.Text = "El documento se vence en menos de 30 dias";
                        string EMensaje = "La LICENCIA del transportista: " + " " + TextBoxPersona.Text + " esta proxima a vencerse, Verifique en Sistema";
                        //Thread thread2 = new Thread(() => EnviarCorreo(EMensaje));
                        //thread2.Start();
                        //thread2.Join();
                        //EnviarCorreo(EMensaje);
                        //array[1] = new Thread(() => EnviarCorreo(EMensaje));
                        //array[1].Start();

                    }
                    if (diasVigenciaLic <= 0 )
                    {
                        bool result = txtVigenciaLic.Text.Equals("FECHA VENCIMIENTO NO REGISTRADA");
                        if (result==true)
                        {
                            txtVigenciaLic.BackColor = Color.Blue;
                            lblVigenciaLic.Text = "Documento Vacio o no registrado";
                            string EMensaje = "La LICENCIA del transportista: " + " " + TextBoxPersona.Text + " Esta vacio o no es valida, Verifique en Sistema";
                            lblVigenciaLic.BackColor = Color.Blue;
                        }
                        else
                        {
                            txtVigenciaLic.BackColor = Color.Red;
                            lblVigenciaLic.Text = "Documento VENCIDO";
                            string EMensaje = "La LICENCIA del transportista: " + " " + TextBoxPersona.Text + " esta VENCIDA o no Registrada, Verifique en Sistema";
                        }
                        //Thread thread = new Thread(() => EnviarCorreo(EMensaje));
                        //thread.Start();
                        //thread.Join();
                        //EnviarCorreo(EMensaje);
                        //array[1] = new Thread(() => EnviarCorreo(EMensaje));
                        //array[1].Start();
                    }
                //para felcn
                    objPersImg = NegPersona.BuscarPersonaVigenciaPR(CodigoEntidad, 3);
                    ObjImagen = NegImagenes.ConsultaImagen(CodigoEntidad, 3);
                    double diasVigenciaFelcn;
                    if (objPersImg != null)
                    { 
                        diasVigenciaFelcn = Convert.ToDouble(objPersImg.DiasVigenciaCI);
                        DateTime fec = Convert.ToDateTime(objPersImg.VigenciaCI);
                        txtVigenciaFelcn.Text = fec.ToShortDateString();
                        
                    }
                    else
                    {
                        diasVigenciaFelcn = 0;
                        txtVigenciaFelcn.Text = "FECHA VENCIMIENTO NO REGISTRADA";
                    }
                    if (diasVigenciaFelcn > 0 && diasVigenciaFelcn <= 30)
                    {
                        txtVigenciaFelcn.BackColor = Color.Orange;
                        lblVigenciaFelcn.Text = "El documento se vence en menos de 30 dias";
                        string EMensaje = "La FELCN del transportista: " + " " + TextBoxPersona.Text + " esta proxima a vencerse, Verifique en Sistema";
                        //Thread thread = new Thread(() => EnviarCorreo(EMensaje));
                        //thread.Start();
                        //thread.Join();
                        //EnviarCorreo(EMensaje);
                        //array[2] = new Thread(() => EnviarCorreo(EMensaje));
                        //array[2].Start();
                    }
                    if (diasVigenciaFelcn <= 0)
                    {
                        bool result = txtVigenciaFelcn.Text.Equals("FECHA VENCIMIENTO NO REGISTRADA");
                        if (result==true)
                        {
                            txtVigenciaFelcn.BackColor = Color.Blue;
                            lblVigenciaFelcn.Text = "Documento Vacio o no registrado";
                            string EMensaje = "La FELCN del transportista: " + " " + TextBoxPersona.Text + " esta Vacio o no registrado, Verifique en Sistema";
                            lblVigenciaFelcn.BackColor = Color.Blue;                      
                        }
                        else
                        {
                            txtVigenciaFelcn.BackColor = Color.Red;
                            lblVigenciaFelcn.Text = "Documento VENCIDO";
                            string EMensaje = "La FELCN del transportista: " + " " + TextBoxPersona.Text + " esta VENCIDA o no Registrada, Verifique en Sistema";
                        }
                        //Thread thread = new Thread(() => EnviarCorreo(EMensaje));
                        //thread.Start();
                        //thread.Join();
                        //EnviarCorreo(EMensaje);
                        //array[2] = new Thread(() => EnviarCorreo(EMensaje));
                        //array[2].Start();
                    }
                //para rejap
                    objPersImg = NegPersona.BuscarPersonaVigenciaPR(CodigoEntidad, 4);
                    ObjImagen = NegImagenes.ConsultaImagen(CodigoEntidad, 4);
                    double diasVigenciaRejap;
                    if (objPersImg != null)
                    {
                        diasVigenciaRejap = Convert.ToDouble(objPersImg.DiasVigenciaCI);
                        DateTime fec = Convert.ToDateTime(objPersImg.VigenciaCI);
                        txtVigenciaRejap.Text = fec.ToShortDateString();
                       
                    }
                    else
                    {
                        diasVigenciaRejap = 0;
                        txtVigenciaRejap.Text = "FECHA VENCIMIENTO NO REGISTRADA";
                    }
                    if (diasVigenciaRejap > 0 && diasVigenciaRejap <= 30)
                    {
                        txtVigenciaRejap.BackColor = Color.Orange;
                        lblVigenciaRejap.Text = "El documento se vence en menos de 30 dias";
                        string EMensaje = "El REJAP del transportista: " + " " + TextBoxPersona.Text + " esta proximo a vencerse, Verifique en Sistema";
                        //Thread thread = new Thread(() => EnviarCorreo(EMensaje));
                        //thread.Start();
                        //thread.Join();
                        //EnviarCorreo(EMensaje);
                        //array[3] = new Thread(() => EnviarCorreo(EMensaje));
                        //array[3].Start();

                    }
                    if (diasVigenciaRejap <= 0)
                    {
                        bool result = txtVigenciaRejap.Text.Equals("FECHA VENCIMIENTO NO REGISTRADA");
                        if (result == true)
                        {
                            txtVigenciaRejap.BackColor = Color.Blue;
                            lblVigenciaRejap.Text = "Documento Vacio o no registrado";
                            string EMensaje = "La FELCN del transportista: " + " " + TextBoxPersona.Text + " esta Vacio o no registrado, Verifique en Sistema";
                            lblVigenciaRejap.BackColor = Color.Blue;                        
                        }
                        else
                        {
                            txtVigenciaRejap.BackColor = Color.Red;
                            lblVigenciaRejap.Text = "Documento VENCIDO";
                            string EMensaje = "El REJAP del transportista: " + " " + TextBoxPersona.Text + " esta VENCIDO o no Registrado, Verifique en Sistema";
                            //Thread thread = new Thread(() => EnviarCorreo(EMensaje));
                            //thread.Start();
                            //thread.Join();
                            //EnviarCorreo(EMensaje);
                            //array[3] = new Thread(() => EnviarCorreo(EMensaje));
                            //array[3].Start();
                        }
                    }
                    objPersImg = NegPersona.BuscarPersonaVigenciaPR(CodigoEntidad, 1002);
                    ObjImagen = NegImagenes.ConsultaImagen(CodigoEntidad, 1002);
                    double diasVigenciaSegAcc;
                    if (objPersImg != null)
                    {
                        diasVigenciaSegAcc = Convert.ToDouble(objPersImg.DiasVigenciaCI);
                        DateTime fec = Convert.ToDateTime(objPersImg.VigenciaCI);
                        TextBoxSegAcc.Text = fec.ToShortDateString();
                       
                    }
                    else
                    {
                        diasVigenciaSegAcc = 0;
                        TextBoxSegAcc.Text = "FECHA VENCIMIENTO NO REGISTRADA";
                    }
                    if (diasVigenciaSegAcc > 0 && diasVigenciaSegAcc <= 30)
                    {
                        TextBoxSegAcc.BackColor = Color.Orange;
                        LabelSegAcc.Text = "El documento se vence en menos de 30 dias";
                        string EMensaje = "El seguro de accidente del transportista: " + " " + TextBoxPersona.Text + " esta proximo a vencerse, Verifique en Sistema";


                    }
                    if (diasVigenciaSegAcc <= 0)
                    {
                        bool result = TextBoxSegAcc.Text.Equals("FECHA VENCIMIENTO NO REGISTRADA");
                        if (result == true)
                        {
                            TextBoxSegAcc.BackColor = Color.Blue;
                            LabelSegAcc.Text = "Documento Vacio o no registrado";
                            string EMensaje = "La FELCN del transportista: " + " " + TextBoxPersona.Text + " esta Vacio o no registrado, Verifique en Sistema";
                            LabelSegAcc.BackColor = Color.Blue;
                        }
                        else
                        {
                            TextBoxSegAcc.BackColor = Color.Red;
                            LabelSegAcc.Text = "Documento VENCIDO";
                            string EMensaje = "El Seguro Accidente del transportista: " + " " + TextBoxPersona.Text + " esta VENCIDO o no Registrado, Verifique en Sistema";

                        }
                    }

                    objPersImg = NegPersona.BuscarPersonaVigenciaPR(CodigoEntidad, 1003);
                    ObjImagen = NegImagenes.ConsultaImagen(CodigoEntidad, 1003);
                    double diasVigenciaSegVid;
                    if (objPersImg != null)
                    {
                        diasVigenciaSegVid = Convert.ToDouble(objPersImg.DiasVigenciaCI);
                        DateTime fec = Convert.ToDateTime(objPersImg.VigenciaCI);
                        TextBoxSeguroVida.Text = fec.ToShortDateString();
                        
                    }
                    else
                    {
                        diasVigenciaSegVid = 0;
                        TextBoxSeguroVida.Text = "FECHA VENCIMIENTO NO REGISTRADA";
                    }
                    if (diasVigenciaSegVid > 0 && diasVigenciaSegVid <= 30)
                    {
                        TextBoxSeguroVida.BackColor = Color.Orange;
                        LabelSeguroVida.Text = "El documento se vence en menos de 30 dias";
                        string EMensaje = "El seguro de accidente del transportista: " + " " + TextBoxPersona.Text + " esta proximo a vencerse, Verifique en Sistema";


                    }
                    if (diasVigenciaSegVid <= 0)
                    {
                        bool result = TextBoxSeguroVida.Text.Equals("FECHA VENCIMIENTO NO REGISTRADA");
                        if (result == true)
                        {
                            TextBoxSeguroVida.BackColor = Color.Blue;
                            LabelSeguroVida.Text = "Documento Vacio o no registrado";
                            string EMensaje = "el seguro de vida del transportista: " + " " + TextBoxPersona.Text + " esta Vacio o no registrado, Verifique en Sistema";
                            LabelSeguroVida.BackColor = Color.Blue;
                        }
                        else
                        {
                            TextBoxSeguroVida.BackColor = Color.Red;
                            LabelSeguroVida.Text = "Documento VENCIDO";
                            string EMensaje = "El Seguro Vida del transportista: " + " " + TextBoxPersona.Text + " esta VENCIDO o no Registrado, Verifique en Sistema";

                        }
                    }

                    objPersImg = NegPersona.BuscarPersonaVigenciaPR(CodigoEntidad, 2004);
                    ObjImagen = NegImagenes.ConsultaImagen(CodigoEntidad, 2004);
                    double diasVigenciaManejDef;
                    if (objPersImg != null)
                    {
                        diasVigenciaManejDef = Convert.ToDouble(objPersImg.DiasVigenciaCI);
                        DateTime fec = Convert.ToDateTime(objPersImg.VigenciaCI);
                        TextManjeDef.Text = fec.ToShortDateString();

                    }
                    else
                    {
                        diasVigenciaManejDef = 0;
                        TextManjeDef .Text = "FECHA VENCIMIENTO NO REGISTRADA";
                    }
                    if (diasVigenciaManejDef > 0 && diasVigenciaManejDef <= 30)
                    {
                        TextManjeDef.BackColor = Color.Orange;
                        LabelCertManDef.Text = "El documento se vence en menos de 30 dias";
                        string EMensaje = "El Certificado De Manejo defensivo del  transportista: " + " " + TextBoxPersona.Text + " esta proximo a vencerse, Verifique en Sistema";


                    }
                    if (diasVigenciaManejDef <= 0)
                    {
                        bool result = TextManjeDef.Text.Equals("FECHA VENCIMIENTO NO REGISTRADA");
                        if (result == true)
                        {
                            TextManjeDef.BackColor = Color.Blue;
                            LabelCertManDef.Text = "Documento Vacio o no registrado";
                            string EMensaje = "El Certificado De Manejo defensivo del transportista: " + " " + TextBoxPersona.Text + " esta Vacio o no registrado, Verifique en Sistema";
                            LabelCertManDef.BackColor = Color.Blue;
                        }
                        else
                        {
                            TextManjeDef.BackColor = Color.Red;
                            LabelCertManDef.Text = "Documento VENCIDO";
                            string EMensaje = "El Certificado De Manejo defensivo del transportista: " + " " + TextBoxPersona.Text + " esta VENCIDO o no Registrado, Verifique en Sistema";

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

        protected void BtnVerLicencia_Click(object sender, EventArgs e)
        {

        }
        protected void CalendarLicencia_SelectionChanged(object sender, EventArgs e)
        {
            if (CalendarLicencia.SelectedDate != null)
            {
                txtVigenciaLic.Text = CalendarLicencia.SelectedDate.ToString("d");
                CalendarLicencia.Visible = false;
            }

        }

        protected void imgCalendarFelcn_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarFelcn.Visible)
            {
                CalendarFelcn.Visible = false;
            }
            else
            {
                CalendarFelcn.Visible = true;
            }
        }

        protected void CalendarFelcn_SelectionChanged(object sender, EventArgs e)
        {
            if (CalendarFelcn.SelectedDate != null)
            {
                txtVigenciaFelcn.Text = CalendarFelcn.SelectedDate.ToString("d");
                CalendarFelcn.Visible = false;
            }
        }

        protected void imgCalendarRejap_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarRejap.Visible)
            {
                CalendarRejap.Visible = false;
            }
            else
            {
                CalendarRejap.Visible = true;
            }
        }

        protected void CalendarRejap_SelectionChanged(object sender, EventArgs e)
        {
            if (CalendarRejap.SelectedDate != null)
            {
                txtVigenciaRejap.Text = CalendarRejap.SelectedDate.ToString("d");
                CalendarRejap.Visible = false;
            }
        }

        protected void imgCalendarLic_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarLicencia.Visible)
            {
                CalendarLicencia.Visible = false;
            }
            else
            {
                CalendarLicencia.Visible = true;
            }
        }

        protected void imgVencimientoCI_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarVencimientoCI.Visible)
            {
                CalendarVencimientoCI.Visible = false;
            }
            else
            {
                CalendarVencimientoCI.Visible = true;
            }
        }

        protected void CalendarVencimientoCI_SelectionChanged(object sender, EventArgs e)
        {
            if (CalendarVencimientoCI.SelectedDate != null)
            {
                txtVencimientoCI.Text = CalendarVencimientoCI.SelectedDate.ToString("d");
                CalendarVencimientoCI.Visible = false;
            }
        }

        protected void ImgCalendarSecAcc_Click(object sender, ImageClickEventArgs e)
        {

            if (CalendarSegAcc.Visible)
            {
                CalendarSegAcc.Visible = false;
            }
            else
            {
                CalendarSegAcc.Visible = true;
            }

        }

        protected void CalendarSegAcc_SelectionChanged(object sender, EventArgs e)
        {
            if (CalendarSegAcc.SelectedDate != null)
            {
                TextBoxSegAcc.Text = CalendarSegAcc.SelectedDate.ToString("d");
                CalendarSegAcc.Visible = false;
            }
        }

        protected void ImgCalenSegVi_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarSegVida.Visible)
            {
                CalendarSegVida.Visible = false;
            }
            else
            {
                CalendarSegVida.Visible = true;
            }

        }

        protected void CalendarSegVida_SelectionChanged(object sender, EventArgs e)
        {
            if (CalendarSegVida.SelectedDate != null)
            {
                TextBoxSeguroVida.Text = CalendarSegVida.SelectedDate.ToString("d");
                CalendarSegVida.Visible = false;
            }
        }
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            EntImagenes Ci = new EntImagenes();
            EntImagenes Licencia = new EntImagenes();
            EntImagenes Felcn = new EntImagenes();
            EntImagenes Rejap = new EntImagenes();
            EntImagenes SegAcc = new EntImagenes();
            EntImagenes SegVid = new EntImagenes();
            EntImagenes CertManejDef = new EntImagenes();
          
            try
            {
                Ci.Vigencia = Convert.ToDateTime(txtVencimientoCI.Text);
                int Date = DateTime.Compare(Ci.Vigencia,DateTime.Today);
                if (Date <= 0)
                {
                    lblError.Text = "La fecha Ci es menor a la fecha actual";
                    lblError.Visible = true;
                    return;
                }
                DateTime Fecha;
                if (DateTime.TryParseExact(txtVencimientoCI.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out Fecha))
                {

                }
                else
                {
                    lblError.Text = "La fecha CI no es valida";
                    lblError.Visible = true;
                    return;
                }

            }
            catch (Exception ex)
            {
                lblError.Text = "El campo CI no tiene el formato correcto";
                lblError.Visible = true;
                //return;
                Ci.Vigencia = Convert.ToDateTime(DateTime.Now.ToString());// string.Empty;

            }

            try
            {
                Licencia.Vigencia = Convert.ToDateTime(txtVigenciaLic.Text);
                int Date= DateTime.Compare(Licencia.Vigencia,DateTime.Today);
                if (Date<=0)
                {
                    lblError.Text = "La fecha Lic es menor a la fecha actual";
                    lblError.Visible = true;
                    Licencia.Vigencia = Convert.ToDateTime(DateTime.Now.ToString());
                }

                DateTime Fecha;
                if (DateTime.TryParseExact(txtVigenciaLic.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out Fecha))
                {
                 
                }
                else
                {
                    lblError.Text = "La fecha Lic no es valida";
                    lblError.Visible = true;
                    return;
                }

            }
            catch (Exception ex)
            {
                lblError.Text = "El campo Vigencia Licencia no tiene el formato correcto";
                lblError.Visible = true;
                Licencia.Vigencia = Convert.ToDateTime(DateTime.Now.ToString());

            }

            try
            {
                Felcn.Vigencia = Convert.ToDateTime(txtVigenciaFelcn.Text);
                int Date = DateTime.Compare(Felcn.Vigencia, DateTime.Today);
                if (Date <= 0)
                {
                    lblError.Text = "La fecha Felcn es menor a la fecha actual";
                    lblError.Visible = true;
                    Felcn.Vigencia = Convert.ToDateTime(DateTime.Now.ToString());
                }
                DateTime Fecha;
                if (DateTime.TryParseExact(txtVigenciaFelcn.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out Fecha))
                {

                }
                else
                {
                    lblError.Text = "La fecha Felcn no es valida";
                    lblError.Visible = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "El campo Vigencia FELCN no tiene el formato correcto";
                lblError.Visible = true;
                Felcn.Vigencia = Convert.ToDateTime(DateTime.Now.ToString());

            }

            try
            {
                Rejap.Vigencia = Convert.ToDateTime(txtVigenciaRejap.Text);
                int Date = DateTime.Compare(Rejap.Vigencia, DateTime.Today);
                if (Date <= 0)
                {
                    lblError.Text = "La fecha Rejap es menor a la fecha actual";
                    lblError.Visible = true;
                    Rejap.Vigencia = Convert.ToDateTime(DateTime.Now.ToString());
                }

                DateTime Fecha;
                if (DateTime.TryParseExact(txtVigenciaRejap.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out Fecha))
                {

                }
                else
                {
                    lblError.Text = "La fecha Rejap no es valida";
                    lblError.Visible = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "El campo Vigencia REJAP no tiene el formato correcto";
                lblError.Visible = true;
                Rejap.Vigencia = Convert.ToDateTime(DateTime.Now.ToString());
            }
            try
            {
                SegAcc.Vigencia = Convert.ToDateTime(TextBoxSegAcc.Text);
                int Date = DateTime.Compare(SegAcc.Vigencia, DateTime.Today);
                if (Date <= 0)
                {
                    lblError.Text = "La fecha SegAcc es menor a la fecha actual";
                    lblError.Visible = true;
                    SegAcc.Vigencia = Convert.ToDateTime(DateTime.Now.ToString());
                }

                DateTime Fecha;
                if (DateTime.TryParseExact(TextBoxSegAcc.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out Fecha))
                {

                }
                else
                {
                    lblError.Text = "La fecha SegAcc no es valida";
                    lblError.Visible = true;
                    return;
                }

            }
            catch (Exception ex)
            {
                lblError.Text = "El campo Vigencia seguro accidente no tiene el formato correcto";
                lblError.Visible = true;
                SegAcc.Vigencia = Convert.ToDateTime(DateTime.Now.ToString());

            }
            try
            {
                SegVid.Vigencia = Convert.ToDateTime(TextBoxSeguroVida.Text);
                int Date = DateTime.Compare(SegVid.Vigencia, DateTime.Today);
                if (Date <= 0)
                {
                    lblError.Text = "La fecha SegVid es menor a la fecha actual";
                    lblError.Visible = true;
                    SegVid.Vigencia = Convert.ToDateTime(DateTime.Now.ToString());
                }

                DateTime Fecha;
                if (DateTime.TryParseExact(TextBoxSeguroVida.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out Fecha))
                {

                }
                else
                {
                    lblError.Text = "La fecha SegVid no es valida";
                    lblError.Visible = true;
                    return;
                }

            }
            catch (Exception ex)
            {
                lblError.Text = "El campo Vigencia SegVid no tiene el formato correcto";
                lblError.Visible = true;
                SegVid.Vigencia = Convert.ToDateTime(DateTime.Now.ToString());

            }
            try
            {
                CertManejDef.Vigencia = Convert.ToDateTime(TextManjeDef.Text);
                int Date = DateTime.Compare(CertManejDef.Vigencia, DateTime.Today);
                if (Date <= 0)
                {
                    lblError.Text = "La Fecha del certificado de manejo defensivo es menor a la actual";
                    lblError.Visible = true;
                    CertManejDef.Vigencia = Convert.ToDateTime(DateTime.Now.ToString());
                }
                DateTime Fecha;
                if(DateTime.TryParseExact(TextManjeDef.Text,"dd/mm/yyyy",null,System.Globalization.DateTimeStyles.None,out Fecha))
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
                lblError.Text = "El Campo Certificado de Manejo Defensivo no tiene el formato correcto";
                lblError.Visible = true;
                CertManejDef.Vigencia = Convert.ToDateTime(DateTime.Now.ToString());
            }
            //aqui empiezo a pasar las imagenes
          
            //imagen C.I. y Vigencia CI
            if ((Ci.Vigencia != null))
            {
                Ci.Tipo_Imagen = 1;
                if (chkSiAplicaCI.Checked)
                {
                    Ci.Aplica = 1;
                }
                else
                {
                    Ci.Aplica = 0;
                }
                Ci.Cod_Ente = Convert.ToInt32(Session["CodigoEnte"]);//Convert.ToInt32(objPropietario.Cod_Ente);//CodigoEntidad;
                if (NegImagenes.InsertarImagen(Ci) == 1)
                {
                    //lblError.Text = "Registro de Imagen guardado satisfactoriamente";
                    //lblError.Visible = true;
                    //Response.Write("<script languaje =javascript>alert ('Registro de Entidad guardado satisfactoriamente');</script>");
                }
                else
                {
                    lblError.Text = "No se pudo Insertar el Registro CI por algun motivo, Verifique e intente nuevamente";
                    lblError.Visible = true;

                }


                //////if (NegPersona.ActualizarPropietario(objPropietario) == 1)
                //////   {
                //  cmd = new SqlCommand("Insert into Imagenes (Cod_Ente, Imagen, Vigencia) values (" + Cod_Ente + "," + "'" + Ci.Imagen + "'" + "," + "'" + Ci.Vigencia + "'"
                //+ ");SELECT  Scope_Identity();", cnx);
                //  cmd.Transaction = myTrans;
                //  int Id_ImgCI = Convert.ToInt32(cmd.ExecuteScalar());
                //  Id_ImagenCI = Id_ImgCI;

            }
            if ((Licencia.Vigencia != null))
            {
                Licencia.Tipo_Imagen = 2;
                if (CheckSiAplicaLic.Checked)
                {
                    Licencia.Aplica = 1;
                }
                else
                {
                    Licencia.Aplica = 0;
                }
                Licencia.Cod_Ente = Convert.ToInt32(Session["CodigoEnte"]);//CodigoEntidad;
                if (NegImagenes.InsertarImagen(Licencia) == 1)
                {
                    //lblError.Text = "Registro de Imagen guardado satisfactoriamente";
                    //lblError.Visible = true;
                    //Response.Write("<script languaje =javascript>alert ('Registro de Entidad guardado satisfactoriamente');</script>");
                }
                else
                {
                    lblError.Text = "No se pudo Insertar el Registro Licencia por algun motivo, Verifique e intente nuevamente";
                    lblError.Visible = true;

                }
            }
            if ((Felcn.Vigencia != null))
            {
                Felcn.Tipo_Imagen = 3;
                if (CheckSiAplicaFelcn.Checked )
                {
                    Felcn.Aplica = 1;
                }
                else
                {
                    Felcn.Aplica = 0;
                }
                Felcn.Cod_Ente = Convert.ToInt32(Session["CodigoEnte"]);//CodigoEntidad;
                if (NegImagenes.InsertarImagen(Felcn) == 1)
                {
                    //lblError.Text = "Registro de Imagen guardado satisfactoriamente";
                    //lblError.Visible = true;
                    //Response.Write("<script languaje =javascript>alert ('Registro de Entidad guardado satisfactoriamente');</script>");
                }
                else
                {
                    lblError.Text = "No se pudo Insertar el Registro Felcn por algun motivo, Verifique e intente nuevamente";
                    lblError.Visible = true;

                }
            }
            if ((Rejap.Vigencia != null))
            {
                Rejap.Tipo_Imagen = 4;
                if (CheckSiAplicaRejap.Checked)
                {
                    Rejap.Aplica = 1;
                }
                else
                {
                    Rejap.Aplica = 0;
                }
                Rejap.Cod_Ente = Convert.ToInt32(Session["CodigoEnte"]);//CodigoEntidad;
                if (NegImagenes.InsertarImagen(Rejap) == 1)
                {
                    //lblError.Text = "Registro de Imagen guardado satisfactoriamente";
                    //lblError.Visible = true;
                    //Response.Write("<script languaje =javascript>alert ('Registro de Entidad guardado satisfactoriamente');</script>");
                }
                else
                {
                    lblError.Text = "No se pudo Insertar el Registro Rejap por algun motivo, Verifique e intente nuevamente";
                    lblError.Visible = true;

                }
            }
            if ((SegAcc.Vigencia != null))
            {
                SegAcc.Tipo_Imagen = 1002;
                if (CheckSiAPlicaSegAcc.Checked)
                {
                    SegAcc.Aplica = 1;
                }
                else
                {
                    SegAcc.Aplica = 0;
                }
                SegAcc.Cod_Ente = Convert.ToInt32(Session["CodigoEnte"]);//CodigoEntidad;
                if (NegImagenes.InsertarImagen(SegAcc) == 1)
                {
                    //lblError.Text = "Registro de Imagen guardado satisfactoriamente";
                    //lblError.Visible = true;
                    //Response.Write("<script languaje =javascript>alert ('Registro de Entidad guardado satisfactoriamente');</script>");
                }
                else
                {
                    lblError.Text = "No se pudo Insertar el Registro SegAcc por algun motivo, Verifique e intente nuevamente";
                    lblError.Visible = true;

                }
            }
            if ((SegVid.Vigencia != null))
            {
                SegVid.Tipo_Imagen = 1003;
                if (CheckSiAplicaSegVida.Checked)
                {
                    SegVid.Aplica = 1;
                }
                else
                {
                    SegVid.Aplica = 0;
                }
                SegVid.Cod_Ente = Convert.ToInt32(Session["CodigoEnte"]);//CodigoEntidad;
                if (NegImagenes.InsertarImagen(SegVid) == 1)
                {
                    //lblError.Text = "Registro de Imagen guardado satisfactoriamente";
                    //lblError.Visible = true;
                    //Response.Write("<script languaje =javascript>alert ('Registro de Entidad guardado satisfactoriamente');</script>");
                }
                else
                {
                    lblError.Text = "No se pudo Insertar el Registro SegVid por algun motivo, Verifique e intente nuevamente";
                    lblError.Visible = true;

                }
            }
            
            if (CertManejDef.Vigencia != null)
            {
                CertManejDef.Tipo_Imagen = 2004;
                if (CheckSiAplicaManDef.Checked)
                {
                    CertManejDef.Aplica = 1;
                }
                else
                {
                    CertManejDef.Aplica = 0;
                }
                CertManejDef.Cod_Ente = Convert.ToInt32(Session["CodigoEnte"]);
                if (NegImagenes.InsertarImagen(CertManejDef) == 1)
                {

                }
                else
                {
                    lblError.Text = "No se pudo Insertar el Registro Certificado de Manejo Defensivo por algun motivo, Verifique e intente Nuevamente";
                    lblError.Visible = true;
                }
            }
            EntUsuario us = (EntUsuario)Session["Usuario"];
            EntBitacora bit = new EntBitacora();
            bit.Usuario = us.Nombre + "" + us.Apellidos;
            bit.Accion = "El usuario a logrado Insertar imagenes";
            bit.IdUsuario = us.Id_Usuario;
            int bi = NegBitacora.GuardarBitacora(bit);
            txtVigenciaFelcn.Text = "";
            txtVencimientoCI.Text = "";
            txtVigenciaLic.Text = "";
            txtVigenciaRejap.Text = "";
            TextBoxSegAcc.Text = "";
            TextBoxSeguroVida.Text = "";
        }

        protected void BtnCi_Click(object sender, EventArgs e)
        {
            int CodigoEntidad;
            int PersonaId = Convert.ToInt32(Request.QueryString["Id"]);
            EntPersona objPropietario = new EntPersona();
            objPropietario = NegPersona.BuscarTodo(PersonaId); //haber
            CodigoEntidad = Convert.ToInt32(objPropietario.Cod_Ente);
            EntImagenes Img = new EntImagenes();
            Img = NegImagenes.Download(CodigoEntidad, 1);
            if (Img == null)
            {
                lblError.Text = "No se pudo Descargar La Imagen";
                lblError.Visible = true;
                return;
            }
            byte[] Document = (byte[])Img.Imagen;
            Response.ClearContent();
            Response.ContentType = "application/octetstream";
            Response.AddHeader("Content-Disposition", string.Format("attachment;filenames={0}", Img.Nombre));
            Response.AddHeader("Content-Length", Document.Length.ToString());
            Response.BinaryWrite(Document);
            Response.Flush();
            Response.Close();
            
        }

        protected void BtnLicencia_Click(object sender, EventArgs e)
        {
            int CodigoEntidad;
            int PersonaId = Convert.ToInt32(Request.QueryString["Id"]);
            EntPersona objPropietario = new EntPersona();
            objPropietario = NegPersona.BuscarTodo(PersonaId); //haber
            CodigoEntidad = Convert.ToInt32(objPropietario.Cod_Ente);
            EntImagenes Img = new EntImagenes();
            Img = NegImagenes.Download(CodigoEntidad, 2);
            if (Img == null)
            {
                lblError.Text = "No se pudo Descargar La Imagen";
                lblError.Visible = true;
                return;
            }
            byte[] Document = (byte[])Img.Imagen;
            Response.ClearContent();
            Response.ContentType = "application/octetstream";
            Response.AddHeader("Content-Disposition", string.Format("attachment;filenames={0}", Img.Nombre));
            Response.AddHeader("Content-Length", Document.Length.ToString());
            Response.BinaryWrite(Document);
            Response.Flush();
            Response.Close();
        }

        protected void BtnFELCN_Click(object sender, EventArgs e)
        {
            int CodigoEntidad;
            int PersonaId = Convert.ToInt32(Request.QueryString["Id"]);
            EntPersona objPropietario = new EntPersona();
            objPropietario = NegPersona.BuscarTodo(PersonaId); //haber
            CodigoEntidad = Convert.ToInt32(objPropietario.Cod_Ente);
            EntImagenes Img = new EntImagenes();
            Img = NegImagenes.Download(CodigoEntidad, 3);
            if (Img == null)
            {
                lblError.Text = "No se pudo Descargar La Imagen";
                lblError.Visible = true;
                return;
            }
            byte[] Document = (byte[])Img.Imagen;
            Response.ClearContent();
            Response.ContentType = "application/octetstream";
            Response.AddHeader("Content-Disposition", string.Format("attachment;filenames={0}", Img.Nombre));
            Response.AddHeader("Content-Length", Document.Length.ToString());
            Response.BinaryWrite(Document);
            Response.Flush();
            Response.Close();
        }

        protected void BtnRejap_Click(object sender, EventArgs e)
        {
            int CodigoEntidad;
            int PersonaId = Convert.ToInt32(Request.QueryString["Id"]);
            EntPersona objPropietario = new EntPersona();
            objPropietario = NegPersona.BuscarTodo(PersonaId); //haber
            CodigoEntidad = Convert.ToInt32(objPropietario.Cod_Ente);
            EntImagenes Img = new EntImagenes();
            Img = NegImagenes.Download(CodigoEntidad, 4);
            if (Img == null)
            {
                lblError.Text = "No se pudo Descargar La Imagen";
                lblError.Visible = true;
                return;
            }
            byte[] Document = (byte[])Img.Imagen;
            Response.ClearContent();
            Response.ContentType = "application/octetstream";
            Response.AddHeader("Content-Disposition", string.Format("attachment;filenames={0}", Img.Nombre));
            Response.AddHeader("Content-Length", Document.Length.ToString());
            Response.BinaryWrite(Document);
            Response.Flush();
            Response.Close();
        }

        protected void BtnSegAcc_Click(object sender, EventArgs e)
        {
            int CodigoEntidad;
            int PersonaId = Convert.ToInt32(Request.QueryString["Id"]);
            EntPersona objPropietario = new EntPersona();
            objPropietario = NegPersona.BuscarTodo(PersonaId); //haber
            CodigoEntidad = Convert.ToInt32(objPropietario.Cod_Ente);
            EntImagenes Img = new EntImagenes();
            Img = NegImagenes.Download(CodigoEntidad, 1002);
            if (Img == null)
            {
                lblError.Text = "No se pudo Descargar La Imagen";
                lblError.Visible = true;
                return;
            }
            byte[] Document = (byte[])Img.Imagen;
            Response.ClearContent();
            Response.ContentType = "application/octetstream";
            Response.AddHeader("Content-Disposition", string.Format("attachment;filenames={0}", Img.Nombre));
            Response.AddHeader("Content-Length", Document.Length.ToString());
            Response.BinaryWrite(Document);
            Response.Flush();
            Response.Close();
        }

        protected void BtnSegVida_Click(object sender, EventArgs e)
        {
            int CodigoEntidad;
            int PersonaId = Convert.ToInt32(Request.QueryString["Id"]);
            EntPersona objPropietario = new EntPersona();
            objPropietario = NegPersona.BuscarTodo(PersonaId); //haber
            CodigoEntidad = Convert.ToInt32(objPropietario.Cod_Ente);
            EntImagenes Img = new EntImagenes();
            Img = NegImagenes.Download(CodigoEntidad, 1003);
            if (Img == null)
            {
                lblError.Text = "No se pudo Descargar La Imagen";
                lblError.Visible = true;
                return;
            }
            byte[] Document = (byte[])Img.Imagen;
            Response.ClearContent();
            Response.ContentType = "application/octetstream";
            Response.AddHeader("Content-Disposition", string.Format("attachment;filenames={0}", Img.Nombre));
            Response.AddHeader("Content-Length", Document.Length.ToString());
            Response.BinaryWrite(Document);
            Response.Flush();
            Response.Close();
        }

        protected void ImageMaDef_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarCertManDef.Visible)
            {
                CalendarCertManDef.Visible = false;
            }
            else
            {
                CalendarCertManDef.Visible = true;
            }
        }
        protected void CalendarCertManDef_SelectionChanged(object sender, EventArgs e)
        {
            if (CalendarCertManDef.SelectedDate != null)
            {
                TextManjeDef.Text = CalendarCertManDef.SelectedDate.ToString("d");
                CalendarCertManDef.Visible = false;
            }
        }

        protected void chkSi_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void chkSiAplicaCI_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSiAplicaCI.Checked)
            {
                chkNoAplicaCI.Checked = false;
            }
        }

        protected void chkNoAplicaCI_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNoAplicaCI.Checked)
            {
                chkSiAplicaCI.Checked = false;
            }
        }

        protected void CheckSiAplicaLic_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckSiAplicaLic.Checked)
            {
                CheckNoAplicaLic.Checked = false;
            }
        }

        protected void CheckNoAplicaLic_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckNoAplicaLic.Checked)
            {
                CheckSiAplicaLic.Checked = false;
            }
        }

        protected void CheckSiAplicaFelcn_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckSiAplicaFelcn.Checked)
            {
                CheckNoAplicaFelcn.Checked = false;
            }
        }

        protected void CheckNoAplicaFelcn_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckNoAplicaFelcn.Checked)
            {
                CheckSiAplicaFelcn.Checked = false;
            }
        }

        protected void CheckSiAplicaRejap_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckSiAplicaRejap.Checked)
            {
                CheckNoAplicaRejap.Checked = false;
            }
        }

        protected void CheckNoAplicaRejap_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckNoAplicaRejap.Checked)
            {
                CheckSiAplicaRejap.Checked = false;
            }
        }

        protected void CheckSiAPlicaSegAcc_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckSiAPlicaSegAcc.Checked)
            {
                CheckNoAplicaSegAcc.Checked = false;
            }
        }

        protected void CheckNoAplicaSegAcc_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckNoAplicaSegAcc.Checked)
            {
                CheckSiAPlicaSegAcc.Checked = false;
            }
        }

        protected void CheckSiAplicaSegVida_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckSiAplicaSegVida.Checked)
            {
                CheckNoAplicaSegVida.Checked = false;
            }
        }

        protected void CheckNoAplicaSegVida_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckNoAplicaSegVida.Checked)
            {
                CheckSiAplicaSegVida.Checked = false;
            }
        }

        protected void CheckSiAplicaManDef_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckSiAplicaManDef.Checked)
            {
                CheckNoAplicaManDef.Checked = false;
            }
        }

        protected void CheckNoAplicaManDef_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckNoAplicaManDef.Checked)
            {
                CheckSiAplicaManDef.Checked = false;
            }
        }
    }
}