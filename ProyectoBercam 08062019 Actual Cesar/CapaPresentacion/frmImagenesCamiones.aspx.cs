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
    public partial class frmImagenesCamiones : System.Web.UI.Page
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
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int CodigoCamion;
                int CamionId = Convert.ToInt32(Request.QueryString["Id"]);
                EntCamiones objPropietario = new EntCamiones();
                //Thread[] array = new Thread[4];
                //array[0] = null;
                //array[1] = null;
                //array[2] = null;
                //array[3] = null;
                EntDetalle_Certificados objPersImg = new EntDetalle_Certificados();
                EntSoat ObjSoat = new EntSoat();
                EntInspTecnica ObjIns = new EntInspTecnica();
                objPropietario = NegCamiones.BuscarCamiones(CamionId); //haber
                //Session["CodigoEnte"] = Convert.ToInt32(objPropietario.Cod_Ente);
                CodigoCamion = Convert.ToInt32(objPropietario.Id_Camion);
                TextBoxID.Text = Convert.ToString(objPropietario.Id_Camion);
                TextBoxPlaca.Text = objPropietario.Placa;

                //imgRUAT.ImageUrl = "CargaImagenRuat.ashx?Codigo=" + CodigoCamion;
                ////10/11/2017 aqui se debe cargar la fecha de vencimiento registrada anteriormente, sino hay datos que cargue 0 colocar un try catch
                ////ademas de estos datos que traiga los dias de vigencia de cada uno, de ci, de lic, de felcn, de rejap
                ////y que luego compare con la fecha actual y que muestre un mensaje en rojo y que coloque el control en color rojo de que el documento esta vencido, etc
                ////aqui deberia tambien dar la opcion de enviar un mensaje de correo del documento vencido actual

                //txtVencimientoRUAT.Text = Convert.ToString(objPropietario.VigenciaCI);
                //txtVigenciaSOAT.Text = Convert.ToString(objPropietario.VigenciaLicencia);
                //txtVigenciaFelcn.Text = Convert.ToString(objPropietario.VigenciaFelcn);
                //txtVigenciaRejap.Text = Convert.ToString(objPropietario.VigenciaRejap);


                objPersImg = NegCamiones.BuscarVigencia(CodigoCamion, 5);
                double diasVigenciaRUAT;
                if (objPersImg != null)
                {
                    diasVigenciaRUAT = Convert.ToDouble(objPersImg.DiasVigencia);
                    DateTime fec = Convert.ToDateTime(objPersImg.Fecha_Vencimiento);
                    txtVencimientoRUAT.Text = fec.ToShortDateString();//Convert.ToString(objPersImg.VigenciaCI,"dd/MM/yyyy");

                }
                else
                {
                    diasVigenciaRUAT = 0;
                    txtVencimientoRUAT.Text = "FECHA VENCIMIENTO NO REGISTRADA";
                }

                //double diasVigenciaCI = NegPersona.BuscarPersonaVigencia(CodigoEntidad, 1); //Convert.ToDouble(objPropietario.DiasVigenciaCI);
                //double diasVigenciaLic = NegPersona.BuscarPersonaVigencia(CodigoEntidad, 2); //Convert.ToDouble(objPropietario.DiasVigenciaLicencia);
                //double diasVigenciaFelcn = NegPersona.BuscarPersonaVigencia(CodigoEntidad, 3); //Convert.ToDouble(objPropietario.DiasVigenciaFelcn);
                //double diasVigenciaRejap = NegPersona.BuscarPersonaVigencia(CodigoEntidad, 4); //Convert.ToDouble(objPropietario.DiasVigenciaRejap);

                if (diasVigenciaRUAT > 0 && diasVigenciaRUAT <= 30)
                {
                    txtVencimientoRUAT.BackColor = Color.Orange;
                    lblVigenciaRUAT.Text = "El documento se vence en menos de 30 dias";

                    string EMensaje = "El CI del transportista: " + " " + TextBoxPlaca.Text + " esta proximo a vencerse, Verifique en Sistema";
                    //thread = new Thread();
                    //Thread thread1 = new Thread(() => EnviarCorreo(EMensaje));
                    //thread1.Start();
                    //thread1.Join();
                    //EnviarCorreo(EMensaje);
                    //array[0] = new Thread(() => EnviarCorreo(EMensaje));
                    //array[0].Start();
                }
                if (diasVigenciaRUAT <= 0)
                {
                    txtVencimientoRUAT.BackColor = Color.Red;
                    lblVigenciaRUAT.Text = "Documento VENCIDO o NO REGISTRADO";

                    string EMensaje = "El CI del transportista: " + " " + TextBoxPlaca.Text + " esta VENCIDO o no Registrado, Verifique en Sistema";
                    //Thread thread = new Thread(() => EnviarCorreo(EMensaje));
                    //thread.Start();
                    //thread.Join();
                    //EnviarCorreo(EMensaje);
                    //array[0] = new Thread(() => EnviarCorreo(EMensaje));
                    //array[0].Start();
                }


                //para licencia
                ObjSoat = NegSoat.BuscarVigencia(CodigoCamion);
                double diasVigenciaSOAT;
                if (ObjSoat != null)
                {
                    diasVigenciaSOAT = Convert.ToDouble(ObjSoat.DiasVigencia);
                    DateTime fec = Convert.ToDateTime(ObjSoat.F_Venc);
                    txtVigenciaSOAT.Text = fec.ToShortDateString();//Convert.ToString(objPersImg.VigenciaCI);

                }
                else
                {
                    diasVigenciaSOAT = 0;
                    txtVigenciaSOAT.Text = "FECHA VENCIMIENTO NO REGISTRADA";
                }
                if (diasVigenciaSOAT > 0 && diasVigenciaSOAT <= 30)
                {
                    txtVigenciaSOAT.BackColor = Color.Orange;
                    lblVigenciaSOAT.Text = "El documento se vence en menos de 30 dias";
                    string EMensaje = "La LICENCIA del transportista: " + " " + TextBoxPlaca.Text + " esta proxima a vencerse, Verifique en Sistema";
                    //Thread thread2 = new Thread(() => EnviarCorreo(EMensaje));
                    //thread2.Start();
                    //thread2.Join();
                    //EnviarCorreo(EMensaje);
                    //array[1] = new Thread(() => EnviarCorreo(EMensaje));
                    //array[1].Start();

                }
                if (diasVigenciaSOAT <= 0)
                {
                    txtVigenciaSOAT.BackColor = Color.Red;
                    lblVigenciaSOAT.Text = "Documento VENCIDO o NO REGISTRADO";
                    string EMensaje = "La LICENCIA del transportista: " + " " + TextBoxPlaca.Text + " esta VENCIDA o no Registrada, Verifique en Sistema";
                    //Thread thread = new Thread(() => EnviarCorreo(EMensaje));
                    //thread.Start();
                    //thread.Join();
                    //EnviarCorreo(EMensaje);
                    //array[1] = new Thread(() => EnviarCorreo(EMensaje));
                    //array[1].Start();
                }
                //para felcn
                ObjIns = NegInspeccTec.BuscarVigencia(CodigoCamion);
                double diasVigenciaInstec;
                if (ObjIns != null)
                {
                    diasVigenciaInstec = Convert.ToDouble(ObjIns.DiasVigencia);
                    DateTime fec = Convert.ToDateTime(ObjIns.F_Venc);
                    txtVigenciaINSTEC.Text = fec.ToShortDateString();

                }
                else
                {
                    diasVigenciaInstec = 0;
                    txtVigenciaINSTEC.Text = "FECHA VENCIMIENTO NO REGISTRADA";
                }
                if (diasVigenciaInstec > 0 && diasVigenciaInstec <= 30)
                {
                    txtVigenciaINSTEC.BackColor = Color.Orange;
                    lblVigenciaINSTEC.Text = "El documento se vence en menos de 30 dias";
                    string EMensaje = "La FELCN del transportista: " + " " + TextBoxPlaca.Text + " esta proxima a vencerse, Verifique en Sistema";
                    //Thread thread = new Thread(() => EnviarCorreo(EMensaje));
                    //thread.Start();
                    //thread.Join();
                    //EnviarCorreo(EMensaje);
                    //array[2] = new Thread(() => EnviarCorreo(EMensaje));
                    //array[2].Start();
                }
                if (diasVigenciaInstec <= 0)
                {
                    txtVigenciaINSTEC.BackColor = Color.Red;
                    lblVigenciaINSTEC.Text = "Documento VENCIDO o NO REGISTRADO";
                    string EMensaje = "La FELCN del transportista: " + " " + TextBoxPlaca.Text + " esta VENCIDA o no Registrada, Verifique en Sistema";
                    //Thread thread = new Thread(() => EnviarCorreo(EMensaje));
                    //thread.Start();
                    //thread.Join();
                    //EnviarCorreo(EMensaje);
                    //array[2] = new Thread(() => EnviarCorreo(EMensaje));
                    //array[2].Start();
                }
                //para rejap
                objPersImg = NegCamiones.BuscarVigencia(CodigoCamion, 1);
                double diasVigenciaMant;
                if (objPersImg != null)
                {
                    diasVigenciaMant = Convert.ToDouble(objPersImg.DiasVigencia);
                    DateTime fec = Convert.ToDateTime(objPersImg.Fecha_Vencimiento);
                    txtVigenciaMant.Text = fec.ToShortDateString();

                }
                else
                {
                    diasVigenciaMant = 0;
                    txtVigenciaMant.Text = "FECHA VENCIMIENTO NO REGISTRADA";
                }
                if (diasVigenciaMant > 0 && diasVigenciaMant <= 30)
                {
                    txtVigenciaMant.BackColor = Color.Orange;
                    lblVigenciaMant.Text = "El documento se vence en menos de 30 dias";
                    string EMensaje = "El REJAP del transportista: " + " " + TextBoxPlaca.Text + " esta proximo a vencerse, Verifique en Sistema";
                    //Thread thread = new Thread(() => EnviarCorreo(EMensaje));
                    //thread.Start();
                    //thread.Join();
                    //EnviarCorreo(EMensaje);
                    //array[3] = new Thread(() => EnviarCorreo(EMensaje));
                    //array[3].Start();

                }
                if (diasVigenciaMant <= 0)
                {
                    txtVigenciaMant.BackColor = Color.Red;
                    lblVigenciaMant.Text = "Documento VENCIDO o NO REGISTRADO";
                    string EMensaje = "El Mantenimiento del Camion: " + " " + TextBoxPlaca.Text + " esta VENCIDO o no Registrado, Verifique en Sistema";
                    //Thread thread = new Thread(() => EnviarCorreo(EMensaje));
                    //thread.Start();
                    //thread.Join();
                    //EnviarCorreo(EMensaje);
                    //array[3] = new Thread(() => EnviarCorreo(EMensaje));
                    //array[3].Start();
                }
                objPersImg = NegCamiones.BuscarVigencia(CodigoCamion, 2);
                double diasVigenciaTorn;
                if (objPersImg != null)
                {
                    diasVigenciaTorn = Convert.ToDouble(objPersImg.DiasVigencia);
                    DateTime fec = Convert.ToDateTime(objPersImg.Fecha_Vencimiento);
                    txtVigenciaINTT.Text = fec.ToShortDateString();

                }
                else
                {
                    diasVigenciaTorn = 0;
                    txtVigenciaINTT.Text = "FECHA VENCIMIENTO NO REGISTRADA";
                }
                if (diasVigenciaTorn > 0 && diasVigenciaTorn <= 30)
                {
                    txtVigenciaINTT.BackColor = Color.Orange;
                    LabelINTT.Text = "El documento se vence en menos de 30 dias";
                    string EMensaje = "El certificado tornamesa del camion: " + " " + TextBoxPlaca.Text + " esta proximo a vencerse, Verifique en Sistema";
                    //Thread thread = new Thread(() => EnviarCorreo(EMensaje));
                    //thread.Start();
                    //thread.Join();
                    //EnviarCorreo(EMensaje);
                    //array[3] = new Thread(() => EnviarCorreo(EMensaje));
                    //array[3].Start();

                }
                if (diasVigenciaTorn <= 0)
                {
                    txtVigenciaINTT.BackColor = Color.Red;
                    LabelINTT.Text = "Documento VENCIDO o NO REGISTRADO";
                    string EMensaje = "El  certificado tornamesa del camion: " + " " + TextBoxPlaca.Text + " esta VENCIDO o no Registrado, Verifique en Sistema";
                    //Thread thread = new Thread(() => EnviarCorreo(EMensaje));
                    //thread.Start();
                    //thread.Join();
                    //EnviarCorreo(EMensaje);
                    //array[3] = new Thread(() => EnviarCorreo(EMensaje));
                    //array[3].Start();
                }
                //for (int i = 0; i < array.Length; i++)
                //{
                //array[i].Start();
                //array[i].Join();
                //}
                objPersImg = NegCamiones.BuscarVigencia(CodigoCamion, 3);
                double diasVigenciaCis;
                if (objPersImg != null)
                {
                    diasVigenciaCis = Convert.ToDouble(objPersImg.DiasVigencia);
                    DateTime fec = Convert.ToDateTime(objPersImg.Fecha_Vencimiento);
                    txtVigenciaCisterna.Text = fec.ToShortDateString();

                }
                else
                {
                    diasVigenciaCis = 0;
                    txtVigenciaCisterna.Text = "FECHA VENCIMIENTO NO REGISTRADA";
                }
                if (diasVigenciaCis > 0 && diasVigenciaCis <= 30)
                {
                    txtVigenciaCisterna.BackColor = Color.Orange;
                    LabelCisterna.Text = "El documento se vence en menos de 30 dias";
                    string EMensaje = "La verificacion de cisterna del camion: " + " " + TextBoxPlaca.Text + " esta proximo a vencerse, Verifique en Sistema";
                    //Thread thread = new Thread(() => EnviarCorreo(EMensaje));
                    //thread.Start();
                    //thread.Join();
                    //EnviarCorreo(EMensaje);
                    //array[3] = new Thread(() => EnviarCorreo(EMensaje));
                    //array[3].Start();

                }
                if (diasVigenciaCis <= 0)
                {
                    txtVigenciaCisterna.BackColor = Color.Red;
                    LabelCisterna.Text = "Documento VENCIDO o NO REGISTRADO";
                    string EMensaje = "El  certificado tornamesa del camion: " + " " + TextBoxPlaca.Text + " esta VENCIDO o no Registrado, Verifique en Sistema";
                    //Thread thread = new Thread(() => EnviarCorreo(EMensaje));
                    //thread.Start();
                    //thread.Join();
                    //EnviarCorreo(EMensaje);
                    //array[3] = new Thread(() => EnviarCorreo(EMensaje));
                    //array[3].Start();
                }
                objPersImg = NegCamiones.BuscarVigencia(CodigoCamion, 4);
                double diasVigenciaEstan;
                if (objPersImg != null)
                {
                    diasVigenciaEstan = Convert.ToDouble(objPersImg.DiasVigencia);
                    DateTime fec = Convert.ToDateTime(objPersImg.Fecha_Vencimiento);
                    txtVencimientoEst.Text = fec.ToShortDateString();

                }
                else
                {
                    diasVigenciaEstan = 0;
                    txtVencimientoEst.Text = "FECHA VENCIMIENTO NO REGISTRADA";
                }
                if (diasVigenciaEstan > 0 && diasVigenciaEstan <= 30)
                {
                    txtVencimientoEst.BackColor = Color.Orange;
                    LabelEst.Text = "El documento se vence en menos de 30 dias";
                    string EMensaje = "La verificacion de cisterna del camion: " + " " + TextBoxPlaca.Text + " esta proximo a vencerse, Verifique en Sistema";
                    //Thread thread = new Thread(() => EnviarCorreo(EMensaje));
                    //thread.Start();
                    //thread.Join();
                    //EnviarCorreo(EMensaje);
                    //array[3] = new Thread(() => EnviarCorreo(EMensaje));
                    //array[3].Start();

                }
                if (diasVigenciaEstan <= 0)
                {
                    txtVencimientoEst.BackColor = Color.Red;
                    LabelEst.Text = "Documento VENCIDO o NO REGISTRADO";
                    string EMensaje = "El  certificado tornamesa del camion: " + " " + TextBoxPlaca.Text + " esta VENCIDO o no Registrado, Verifique en Sistema";
                    //Thread thread = new Thread(() => EnviarCorreo(EMensaje));
                    //thread.Start();
                    //thread.Join();
                    //EnviarCorreo(EMensaje);
                    //array[3] = new Thread(() => EnviarCorreo(EMensaje));
                    //array[3].Start();
                }
                objPersImg = NegCamiones.BuscarVigencia(CodigoCamion, 6);
                double diasVigenciaResProd;
                if (objPersImg != null)
                {
                    diasVigenciaResProd = Convert.ToDouble(objPersImg.DiasVigencia);
                    DateTime fec = Convert.ToDateTime(objPersImg.Fecha_Vencimiento);
                    txtRespCivProd.Text = fec.ToShortDateString();
                }
                else
                {
                    diasVigenciaResProd = 0;
                    txtRespCivProd.Text = "FECHA VENCIMIENTO NO REGISTRADA";
                }
                if (diasVigenciaResProd > 0 && diasVigenciaResProd <= 30)
                {
                    txtRespCivProd.BackColor = Color.Orange;
                    lblRespCivProd.Text = "El documento se vence en menos de 30 dias";
                    string EMensaje = "La verificacion de responsabilidad civil del producto: " + " " + TextBoxPlaca.Text + " esta proximo a vencerse, Verifique en Sistema";
                    //Thread thread = new Thread(() => EnviarCorreo(EMensaje));
                    //thread.Start();
                    //thread.Join();
                    //EnviarCorreo(EMensaje);
                    //array[3] = new Thread(() => EnviarCorreo(EMensaje));
                    //array[3].Start();

                }
                if (diasVigenciaResProd <= 0)
                {
                    txtRespCivProd.BackColor = Color.Red;
                    lblRespCivProd.Text = "Documento VENCIDO o NO REGISTRADO";
                    string EMensaje = "la responsabilidad civil del producto: " + " " + TextBoxPlaca.Text + " esta VENCIDO o no Registrado, Verifique en Sistema";
                    //Thread thread = new Thread(() => EnviarCorreo(EMensaje));
                    //thread.Start();
                    //thread.Join();
                    //EnviarCorreo(EMensaje);
                    //array[3] = new Thread(() => EnviarCorreo(EMensaje));
                    //array[3].Start();
                }
                objPersImg = NegCamiones.BuscarVigencia(CodigoCamion, 7);
                double diasVigenciaResTra;
                if (objPersImg != null)
                {
                    diasVigenciaResTra = Convert.ToDouble(objPersImg.DiasVigencia);
                    DateTime fec = Convert.ToDateTime(objPersImg.Fecha_Vencimiento);
                    txtRespCivTra.Text = fec.ToShortDateString();
                }
                else
                {
                    diasVigenciaResTra = 0;
                    txtRespCivTra.Text = "FECHA VENCIMIENTO NO REGISTRADA";
                }
                if (diasVigenciaResTra > 0 && diasVigenciaResTra <= 30)
                {
                    txtRespCivTra.BackColor = Color.Orange;
                    lblRespCivTra.Text = "El documento se vence en menos de 30 dias";
                    string EMensaje = "La verificacion de responsabilidad civil del Tracto: " + " " + TextBoxPlaca.Text + " esta proximo a vencerse, Verifique en Sistema";
                    //Thread thread = new Thread(() => EnviarCorreo(EMensaje));
                    //thread.Start();
                    //thread.Join();
                    //EnviarCorreo(EMensaje);
                    //array[3] = new Thread(() => EnviarCorreo(EMensaje));
                    //array[3].Start();

                }
                if (diasVigenciaResTra <= 0)
                {
                    txtRespCivTra.BackColor = Color.Red;
                    lblRespCivTra.Text = "Documento VENCIDO o NO REGISTRADO";
                    string EMensaje = "la responsabilidad civil del Tracto: " + " " + TextBoxPlaca.Text + " esta VENCIDO o no Registrado, Verifique en Sistema";
                    //Thread thread = new Thread(() => EnviarCorreo(EMensaje));
                    //thread.Start();
                    //thread.Join();
                    //EnviarCorreo(EMensaje);
                    //array[3] = new Thread(() => EnviarCorreo(EMensaje));
                    //array[3].Start();
                }
                objPersImg = NegCamiones.BuscarVigencia(CodigoCamion, 8);
                double diasVigenciaContra;
                if (objPersImg != null)
                {
                    diasVigenciaContra = Convert.ToDouble(objPersImg.DiasVigencia);
                    DateTime fec = Convert.ToDateTime(objPersImg.Fecha_Vencimiento);
                    txtContrato.Text = fec.ToShortDateString();
                }
                else
                {
                    diasVigenciaContra = 0;
                    txtContrato.Text = "FECHA VENCIMIENTO NO REGISTRADA";
                }
                if (diasVigenciaContra > 0 && diasVigenciaContra <= 30)
                {
                    txtContrato.BackColor = Color.Orange;
                    lblContrato.Text = "El documento se vence en menos de 30 dias";
                    string EMensaje = "El Contrato Co el Camion: " + " " + TextBoxPlaca.Text + " esta proximo a vencerse, Verifique en Sistema";
                   
                }
                if (diasVigenciaContra <= 0)
                {
                    txtContrato.BackColor = Color.Red;
                    lblContrato.Text = "Documento VENCIDO o NO REGISTRADO";
                    string EMensaje = "El Contrato: " + " " + TextBoxPlaca.Text + " esta VENCIDO o no Registrado, Verifique en Sistema";
                   
                }
                objPersImg = NegCamiones.BuscarVigencia(CodigoCamion, 9);
                double diasVigenciaPoliza;
                if(objPersImg !=null)
                {
                    diasVigenciaPoliza = Convert.ToDouble(objPersImg.DiasVigencia);
                    DateTime fec = Convert.ToDateTime(objPersImg.Fecha_Vencimiento);
                    txtPoliza.Text = fec.ToShortDateString();
                }
                else
                {
                    diasVigenciaPoliza = 0;
                    txtPoliza.Text = "FECHA VENCIMIENTO NO REGISTRADA";
                }
                if (diasVigenciaPoliza > 0 && diasVigenciaPoliza <= 30)
                {
                    txtPoliza.BackColor = Color.Orange;
                    LblPolizaAuto.Text = "El documento se vence en menos de 30 dias";
                    string EMensaje = "La Poliza del Camion: " + " " + TextBoxPlaca.Text + " esta proximo a vencerse, Verifique en Sistema";


                }
                if (diasVigenciaPoliza <= 0)
                {
                    txtPoliza.BackColor = Color.Red;
                    LblPolizaAuto.Text = "Documento VENCIDO o NO REGISTRADO";
                    string EMensaje = "La Poliza Automotor: " + " " + TextBoxPlaca.Text + " esta VENCIDO o no Registrado, Verifique en Sistema";
                }

                objPersImg = NegCamiones.BuscarVigencia(CodigoCamion, 20);
                double diasVigenciaRespCivilCombus;
                if (objPersImg != null)
                {
                    diasVigenciaRespCivilCombus = Convert.ToDouble(objPersImg.DiasVigencia);
                    DateTime fec = Convert.ToDateTime(objPersImg.Fecha_Vencimiento);
                    txtResCivilCombustible.Text = fec.ToShortDateString();
                }
                else
                {
                    diasVigenciaRespCivilCombus = 0;
                    txtResCivilCombustible.Text = "FECHA VENCIMIENTO NO REGISTRADA";
                }
                if (diasVigenciaRespCivilCombus > 0 && diasVigenciaRespCivilCombus <= 30)
                {
                    txtResCivilCombustible.BackColor = Color.Orange;
                    LblResCivilCombustible.Text = "El documento se vence en menos de 30 dias";
                    string EMensaje = "La Resp Civil del Combustible del Camion: " + " " + TextBoxPlaca.Text + " esta proximo a vencerse, Verifique en Sistema";


                }
                if (diasVigenciaRespCivilCombus <= 0)
                {
                    txtResCivilCombustible.BackColor = Color.Red;
                    LblResCivilCombustible.Text = "Documento VENCIDO o NO REGISTRADO";
                    string EMensaje = "LA RESP CIVIL DEL COMBUSTIBLE: " + " " + TextBoxPlaca.Text + " esta VENCIDO o no Registrado, Verifique en Sistema";
                }

                objPersImg = NegCamiones.BuscarVigencia(CodigoCamion, 12);
                double diasVigenciaCalibracion;
                if (objPersImg != null)
                {
                    diasVigenciaCalibracion = Convert.ToDouble(objPersImg.DiasVigencia);
                    DateTime fec = Convert.ToDateTime(objPersImg.Fecha_Vencimiento);
                    txtCalibracion.Text = fec.ToShortDateString();
                }
                else
                {
                    diasVigenciaCalibracion = 0;
                    txtCalibracion.Text = "FECHA VENCIMIENTO NO REGISTRADA";
                }
                if (diasVigenciaCalibracion > 0 && diasVigenciaCalibracion <= 30)
                {
                    txtCalibracion.BackColor = Color.Orange;
                    LblCalibracion.Text = "El documento se vence en menos de 30 dias";
                    string EMensaje = "La Calibracion del Camion: " + " " + TextBoxPlaca.Text + " esta proximo a vencerse, Verifique en Sistema";
                }
                if (diasVigenciaCalibracion <= 0)
                {
                    txtCalibracion.BackColor = Color.Red;
                    LblCalibracion.Text = "Documento VENCIDO o NO REGISTRADO";
                    string EMensaje = "LA Calibracion: " + " " + TextBoxPlaca.Text + " esta VENCIDO o no Registrado, Verifique en Sistema";
                }

                objPersImg = NegCamiones.BuscarVigencia(CodigoCamion, 14);
                double diasVigenciaInspecTanque;
                if (objPersImg != null)
                {
                    diasVigenciaInspecTanque = Convert.ToDouble(objPersImg.DiasVigencia);
                    DateTime fec = Convert.ToDateTime(objPersImg.Fecha_Vencimiento);
                    txtInspecTecTanque.Text = fec.ToShortDateString();
                }
                else
                {
                    diasVigenciaInspecTanque = 0;
                    txtInspecTecTanque.Text = "FECHA VENCIMIENTO NO REGISTRADA";
                }
                if (diasVigenciaInspecTanque > 0 && diasVigenciaInspecTanque <= 30)
                {
                    txtInspecTecTanque.BackColor = Color.Orange;
                    LblInspecTecTanque.Text = "El documento se vence en menos de 30 dias";
                    string EMensaje = "La Inspeccion Tecnica Del Tanque del Camion: " + " " + TextBoxPlaca.Text + " esta proximo a vencerse, Verifique en Sistema";


                }
                if (diasVigenciaInspecTanque <= 0)
                {
                    txtInspecTecTanque.BackColor = Color.Red;
                    LblInspecTecTanque.Text = "Documento VENCIDO o NO REGISTRADO";
                    string EMensaje = "La Inspecion Tecnica Del Tanque : " + " " + TextBoxPlaca.Text + " esta VENCIDO o no Registrado, Verifique en Sistema";
                }
                EntUsuario us = (EntUsuario)Session["Usuario"];
                EntBitacora bit = new EntBitacora();
                bit.Usuario = us.Nombre + "" + us.Apellidos;
                bit.Accion = "El usuario esta intentando insertar imagenes de camiones";
                bit.IdUsuario = us.Id_Usuario;
                int bi = NegBitacora.GuardarBitacora(bit);
            }

        }


        protected void CalendarSOAT_SelectionChanged(object sender, EventArgs e)
        {
            if (CalendarSOAT.SelectedDate != null)
            {
                txtVigenciaSOAT.Text = CalendarSOAT.SelectedDate.ToString("d");
                CalendarSOAT.Visible = false;
            }

        }

        protected void imgCalendarINSTEC_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarINSTEC.Visible)
            {
                CalendarINSTEC.Visible = false;
            }
            else
            {
                CalendarINSTEC.Visible = true;
            }
        }

        protected void CalendarINSTEC_SelectionChanged(object sender, EventArgs e)
        {
            if (CalendarINSTEC.SelectedDate != null)
            {
                txtVigenciaINSTEC.Text = CalendarINSTEC.SelectedDate.ToString("d");
                CalendarINSTEC.Visible = false;
            }
        }

        protected void imgCalendarMant_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarMant.Visible)
            {
                CalendarMant.Visible = false;
            }
            else
            {
                CalendarMant.Visible = true;
            }
        }

        protected void CalendarMant_SelectionChanged(object sender, EventArgs e)
        {
            if (CalendarMant.SelectedDate != null)
            {
                txtVigenciaMant.Text = CalendarMant.SelectedDate.ToString("d");
                CalendarMant.Visible = false;
            }
        }

        protected void imgCalendarSOAT_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarSOAT.Visible)
            {
                CalendarSOAT.Visible = false;
            }
            else
            {
                CalendarSOAT.Visible = true;
            }
        }

        protected void imgVencimientoRUAT_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarVencimientoRUAT.Visible)
            {
                CalendarVencimientoRUAT.Visible = false;
            }
            else
            {
                CalendarVencimientoRUAT.Visible = true;
            }
        }

        protected void CalendarVencimientoRUAT_SelectionChanged(object sender, EventArgs e)
        {
            if (CalendarVencimientoRUAT.SelectedDate != null)
            {
                txtVencimientoRUAT.Text = CalendarVencimientoRUAT.SelectedDate.ToString("d");
                CalendarVencimientoRUAT.Visible = false;
            }
        }
        protected void imgCalendarINTT_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarINTT.Visible)
            {
                CalendarINTT.Visible = false;
            }
            else
            {
                CalendarINTT.Visible = true;
            }
        }

        protected void CalendarINTT_SelectionChanged(object sender, EventArgs e)
        {
            if (CalendarINTT.SelectedDate != null)
            {
                txtVigenciaINTT.Text = CalendarINTT.SelectedDate.ToString("d");
                CalendarINTT.Visible = false;
            }
        }
        protected void imgCalendarCIS_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarCisterna.Visible)
            {
                CalendarCisterna.Visible = false;
            }
            else
            {
                CalendarCisterna.Visible = true;
            }
        }

        protected void CalendarCIS_SelectionChanged(object sender, EventArgs e)
        {
            if (CalendarCisterna.SelectedDate != null)
            {
                txtVigenciaCisterna.Text = CalendarCisterna.SelectedDate.ToString("d");
                CalendarCisterna.Visible = false;
            }
        }
        protected void imgCalendarEST_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarEst.Visible)
            {
                CalendarEst.Visible = false;
            }
            else
            {
                CalendarEst.Visible = true;
            }
        }

        protected void CalendarEST_SelectionChanged(object sender, EventArgs e)
        {
            if (CalendarEst.SelectedDate != null)
            {
                txtVencimientoEst.Text = CalendarEst.SelectedDate.ToString("d");
                CalendarEst.Visible = false;
            }
        }

        protected void CalendarRespCivProd_SelectionChanged(object sender, EventArgs e)
        {
            if (CalendarRespCivProd.SelectedDate != null)
            {
                txtRespCivProd.Text = CalendarRespCivProd.SelectedDate.ToString("d");
                CalendarRespCivProd.Visible = false;
            }
        }

        protected void CalendarRespCivTra_SelectionChanged(object sender, EventArgs e)
        {
            if (CalendarRespCivTra.SelectedDate != null)
            {
                txtRespCivTra.Text = CalendarRespCivTra.SelectedDate.ToString("d");
                CalendarRespCivTra.Visible = false;
            }
        }

        protected void ImageRespCivProd_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarRespCivProd.Visible)
            {
                CalendarRespCivProd.Visible = false;
            }
            else
            {
                CalendarRespCivProd.Visible = true;
            }
        }

        protected void ImageRespCivTra_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarRespCivTra.Visible)
            {
                CalendarRespCivTra.Visible = false;
            }
            else
            {
                CalendarRespCivTra.Visible = true;
            }
        }
        protected void ImageContra_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarContrato.Visible)
            {
                CalendarContrato.Visible = false;
            }
            else
            {
                CalendarContrato.Visible = true;
            }
        }
        protected void CalendarContrato_SelectionChanged(object sender, EventArgs e)
        {
            if (CalendarContrato.SelectedDate != null)
            {
                txtContrato.Text = CalendarContrato.SelectedDate.ToString("d");
                CalendarContrato.Visible = false;
            }
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            EntDetalle_Certificados RUAT = new EntDetalle_Certificados();
            RUAT.Id_Certificado = 5;
            EntInspTecnica Instec = new EntInspTecnica();
            EntSoat SOAT = new EntSoat();
            EntDetalle_Certificados Mant = new EntDetalle_Certificados();
            Mant.Id_Certificado = 1;
            EntDetalle_Certificados Intt = new EntDetalle_Certificados();
            Intt.Id_Certificado = 2;
            EntDetalle_Certificados Vefcis = new EntDetalle_Certificados();
            Vefcis.Id_Certificado = 3;
            EntDetalle_Certificados Estan = new EntDetalle_Certificados();
            Estan.Id_Certificado = 4;
            EntDetalle_Certificados CivProd = new EntDetalle_Certificados();
            CivProd.Id_Certificado = 6;
            EntDetalle_Certificados CivTra = new EntDetalle_Certificados();
            CivTra.Id_Certificado = 7;
            EntDetalle_Certificados Contra = new EntDetalle_Certificados();
            Contra.Id_Certificado = 8;
            EntDetalle_Certificados PolizaSegAuto = new EntDetalle_Certificados();
            PolizaSegAuto.Id_Certificado = 9;
            EntDetalle_Certificados Calibracion = new EntDetalle_Certificados();
            Calibracion.Id_Certificado = 12;
            EntDetalle_Certificados InspecTecniTanque = new EntDetalle_Certificados();
            InspecTecniTanque.Id_Certificado = 14;
            EntDetalle_Certificados RespCivilCombustible = new EntDetalle_Certificados();
            RespCivilCombustible.Id_Certificado = 20;
            
            try
            {
                RUAT.Fecha_Vencimiento = Convert.ToDateTime(txtVencimientoRUAT.Text);
                RUAT.Id_Camion = Convert.ToInt32(Request.QueryString["Id"]);
                RUAT.Aplica = 0;
            }
            catch (Exception ex)
            {
                lblError.Text = "El campo RUAT no tiene el formato correcto";
                lblError.Visible = true;
                RUAT.Fecha_Vencimiento = Convert.ToDateTime(DateTime.Now.ToString());
                RUAT.Id_Camion = 0;

            }

            try
            {
                SOAT.F_Venc = Convert.ToDateTime(txtVigenciaSOAT.Text);
                SOAT.Id_Camion = Convert.ToInt32(Request.QueryString["Id"]);
            }
            catch (Exception ex)
            {
                lblError.Text = "El campo Vigencia SOAT no tiene el formato correcto";
                lblError.Visible = true;
                SOAT.F_Venc = Convert.ToDateTime(DateTime.Now.ToString());
                SOAT.Id_Camion = 0;
            }

            try
            {
                Instec.F_Venc = Convert.ToDateTime(txtVigenciaINSTEC.Text);
                Instec.Id_Camion = Convert.ToInt32(Request.QueryString["Id"]);
            }
            catch (Exception ex)
            {
                lblError.Text = "El campo Vigencia Instec no tiene el formato correcto";
                lblError.Visible = true;
                Instec.F_Venc = Convert.ToDateTime(DateTime.Now.ToString());
                Instec.Id_Camion = 0;
            }
            try
            {
                Mant.Fecha_Vencimiento = Convert.ToDateTime(txtVigenciaMant.Text);
                Mant.Id_Camion = Convert.ToInt32(Request.QueryString["Id"]);
            }
            catch (Exception ex)
            {
                lblError.Text = "El campo Vigencia Mant no tiene el formato correcto";
                lblError.Visible = true;
                Mant.Fecha_Vencimiento = Convert.ToDateTime(DateTime.Now.ToString());
                Mant.Id_Camion = 0;
            }
            try
            {
                Intt.Fecha_Vencimiento = Convert.ToDateTime(txtVigenciaINTT.Text);
                Intt.Id_Camion = Convert.ToInt32(Request.QueryString["Id"]);
            }
            catch (Exception ex)
            {
                lblError.Text = "El campo Vigencia Intt no tiene el formato correcto";
                lblError.Visible = true;
                Intt.Fecha_Vencimiento = Convert.ToDateTime(DateTime.Now.ToString());
                Intt.Id_Camion = 0;
            }
            try
            {
                Vefcis.Fecha_Vencimiento = Convert.ToDateTime(txtVigenciaCisterna.Text);
                Vefcis.Id_Camion = Convert.ToInt32(Request.QueryString["Id"]);
            }
            catch (Exception ex)
            {
                lblError.Text = "El campo Vigencia Vefsis no tiene el formato correcto";
                lblError.Visible = true;
                Vefcis.Fecha_Vencimiento = Convert.ToDateTime(DateTime.Now.ToString());
                Vefcis.Id_Camion = 0;
            }
            try
            {
                Estan.Fecha_Vencimiento = Convert.ToDateTime(txtVencimientoEst.Text);
                Estan.Id_Camion = Convert.ToInt32(Request.QueryString["Id"]);
            }
            catch (Exception ex)
            {
                lblError.Text = "El campo Vigencia Estan no tiene el formato correcto";
                lblError.Visible = true;
                Estan.Fecha_Vencimiento = Convert.ToDateTime(DateTime.Now.ToString());
                Estan.Id_Camion = 0;
            }
            try
            {
                CivProd.Fecha_Vencimiento = Convert.ToDateTime(txtRespCivProd.Text);
                CivProd.Id_Camion = Convert.ToInt32(Request.QueryString["Id"]);
            }
            catch (Exception ex)
            {
                lblError.Text = "El campo Vigencia CivTra no tiene el formato correcto";
                lblError.Visible = true;
                CivProd.Fecha_Vencimiento = Convert.ToDateTime(DateTime.Now.ToString());
                CivProd.Id_Camion = 0;
            }
            try
            {
                CivTra.Fecha_Vencimiento = Convert.ToDateTime(txtRespCivTra.Text);
                CivTra.Id_Camion = Convert.ToInt32(Request.QueryString["Id"]);
            }
            catch (Exception ex)
            {
                lblError.Text = "El campo Vigencia Civprod no tiene el formato correcto";
                lblError.Visible = true;
                CivTra.Fecha_Vencimiento = Convert.ToDateTime(DateTime.Now.ToString());
                CivTra.Id_Camion = 0;
            }
            try
            {
                Contra.Fecha_Vencimiento = Convert.ToDateTime(txtContrato.Text);
                Contra.Id_Camion = Convert.ToInt32(Request.QueryString["Id"]);
            }
            catch (Exception ex)
            {
                lblError.Text = "El campo Vigencia Contrato no tiene el formato correcto";
                lblError.Visible = true;
                Contra.Fecha_Vencimiento = Convert.ToDateTime(DateTime.Now.ToString());
                Contra.Id_Camion = 0;
            }
            try
            {
                PolizaSegAuto.Fecha_Vencimiento = Convert.ToDateTime(txtPoliza.Text);
                PolizaSegAuto.Id_Camion = Convert.ToInt32(Request.QueryString["Id"]);
            }
            catch (Exception ex)
            {
                lblError.Text = "El Campo Vigencia Poliza Seguro Automotor no tiene el formato correcto";
                lblError.Visible = true;
                PolizaSegAuto.Fecha_Vencimiento = Convert.ToDateTime(DateTime.Now.ToString());
                PolizaSegAuto.Id_Camion = 0;
            }
            try
            {
                Calibracion.Fecha_Vencimiento = Convert.ToDateTime(txtCalibracion.Text);
                Calibracion.Id_Camion = Convert.ToInt32(Request.QueryString["Id"]);
            }
            catch (Exception ex)
            {
                lblError.Text = "El Campo Vigencia Calibracion no tiene el formato correcto";
                lblError.Visible = true;
                Calibracion.Fecha_Vencimiento = Convert.ToDateTime(DateTime.Now.ToString());
                Calibracion.Id_Camion = 0;
            }
            try
            {
                InspecTecniTanque.Fecha_Vencimiento = Convert.ToDateTime(txtInspecTecTanque.Text);
                InspecTecniTanque.Id_Camion = Convert.ToInt32(Request.QueryString["Id"]);
            }
            catch (Exception ex)
            {
                lblError.Text = "El Campo Vigencia Inspeccion Tecnico Tanque no tiene el formato correcto";
                lblError.Visible = true;
                InspecTecniTanque.Fecha_Vencimiento = Convert.ToDateTime(DateTime.Now.ToString());
                InspecTecniTanque.Id_Camion = 0;
            }
            try
            {
                RespCivilCombustible.Fecha_Vencimiento = Convert.ToDateTime(txtResCivilCombustible.Text);
                RespCivilCombustible.Id_Camion = Convert.ToInt32(Request.QueryString["Id"]);
            }
            catch (Exception ex)
            {
                lblError.Text = "El Campo Vigencia resp civil Combustible no tiene el formato correcto";
                lblError.Visible = true;
                RespCivilCombustible.Fecha_Vencimiento = Convert.ToDateTime(DateTime.Now.ToString());
                RespCivilCombustible.Id_Camion = 0;
            }
            //aqui empiezo a pasar las imagenes

            //imagen C.I. y Vigencia CI
            if ((RUAT.Fecha_Vencimiento != null) )
            {
              if(NegImagCert.ObtenerFecha(RUAT)!=RUAT.Fecha_Vencimiento && (RUAT.Id_Camion!=0))
              {
                  if (NegImagCert.InsertarImagen(RUAT) == 1)
                  {

                  }
                  else
                  {
                      lblError.Text = "No se pudo Insertar el Registro CI por algun motivo, Verifique e intente nuevamente";
                      lblError.Visible = true;

                  }
              }
                
            }
            if ((SOAT.F_Venc != null) )
            {
                if (NegSoat.ObtenerFecha(SOAT) != SOAT.F_Venc && (SOAT.Id_Camion!=0))
              {
                  if (NegSoat.InsertarImagen(SOAT) == 1)
                  {

                  }
                  else
                  {
                      lblError.Text = "No se pudo Insertar el Registro Licencia por algun motivo, Verifique e intente nuevamente";
                      lblError.Visible = true;

                  }
              }
                
            }
            if ((Instec.F_Venc != null) )
            {
                if(NegInspeccTec.ObtenerFecha(Instec)!=Instec.F_Venc && (Instec.Id_Camion!=0))
                {
                    if (NegInspeccTec.InsertarImagen(Instec) == 1)
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
                
            }
            if ((Mant.Fecha_Vencimiento != null) )
            {
                if(NegImagCert.ObtenerFecha(Mant)!=Mant.Fecha_Vencimiento && (Mant.Id_Camion!=0))
                {
                    if (chkSiAplicaMantenimiento.Checked)
                    {
                        Mant.Aplica = 1;
                    }
                    else
                    {
                        Mant.Aplica = 0;
                    }
                    if (NegImagCert.InsertarImagen(Mant) == 1)
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
               
            }
            if ((Intt.Fecha_Vencimiento != null))
            {
                if( NegImagCert.ObtenerFecha(Intt)!=Intt.Fecha_Vencimiento && (Intt.Id_Camion!=0))
                {
                    if (CheckSiAplicaTornamesa.Checked)
                    {
                        Intt.Aplica = 1;
                    }
                    else
                    {
                        Intt.Aplica = 0;
                    }
                    if (NegImagCert.InsertarImagen(Intt) == 1)
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
               
            }
            if ((Vefcis.Fecha_Vencimiento != null) )
            {
               if(NegImagCert.ObtenerFecha(Vefcis)!=Vefcis.Fecha_Vencimiento && (Vefcis.Id_Camion!=0))
               {
                   if (CheckSiAplicaCisterna.Checked)
                   {
                       Vefcis.Aplica = 1;
                   }
                   else
                   {
                       Vefcis.Aplica = 0;
                   }
                   if (NegImagCert.InsertarImagen(Vefcis) == 1)
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
               
            }
            if ((Estan.Fecha_Vencimiento != null) )
            {
                if(NegImagCert.ObtenerFecha(Estan)!=Estan.Fecha_Vencimiento && (Estan.Id_Camion!=0))
                {
                    if (CheckSiAplicaEstan.Checked)
                    {
                        Estan.Aplica = 1;
                    }
                    else
                    {
                        Estan.Aplica = 0;
                    }

                    if (NegImagCert.InsertarImagen(Estan) == 1)
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
                
            }
            if ((CivProd.Fecha_Vencimiento != null) )
            {
                if(NegImagCert.ObtenerFecha(CivProd)!=CivProd.Fecha_Vencimiento && (CivProd.Id_Camion!=0))
                {
                    if (CheckSiAplicaResCivProd.Checked)
                    {
                        CivProd.Aplica = 1;
                    }
                    else
                    {
                        CivProd.Aplica = 0;
                    }
                    if (NegImagCert.InsertarImagen(CivProd) == 1)
                    {
                        //lblError.Text = "Registro de Imagen guardado satisfactoriamente";
                        //lblError.Visible = true;
                        //Response.Write("<script languaje =javascript>alert ('Registro de Entidad guardado satisfactoriamente');</script>");
                    }
                    else
                    {
                        lblError.Text = "No se pudo Insertar el Registro CivProd por algun motivo, Verifique e intente nuevamente";
                        lblError.Visible = true;

                    }
                }
               
            }
            if ((CivTra.Fecha_Vencimiento != null) )
            {
               if(NegImagCert.ObtenerFecha(CivTra)!=CivTra.Fecha_Vencimiento && (CivTra.Id_Camion!=0))
               {
                   if (CheckSiAplicaRespCivTra.Checked)
                   {
                       CivTra.Aplica = 1;
                   }
                   else
                   {
                       CivTra.Aplica = 0;
                   }
                   if (NegImagCert.InsertarImagen(CivTra) == 1)
                   {
                       //lblError.Text = "Registro de Imagen guardado satisfactoriamente";
                       //lblError.Visible = true;
                       //Response.Write("<script languaje =javascript>alert ('Registro de Entidad guardado satisfactoriamente');</script>");
                   }
                   else
                   {
                       lblError.Text = "No se pudo Insertar el Registro CivTra por algun motivo, Verifique e intente nuevamente";
                       lblError.Visible = true;

                   }
               }
                
            }
            if ((Contra.Fecha_Vencimiento != null) )
            {
               if(NegImagCert.ObtenerFecha(Contra)!=Contra.Fecha_Vencimiento && (Contra.Id_Camion!=0))
               {
                   if (CheckSiAplicaContrato.Checked)
                   {
                       Contra.Aplica = 1;
                   }
                   else
                   {
                       Contra.Aplica = 0;
                   }
                   if (NegImagCert.InsertarImagen(Contra) == 1)
                   {

                   }
                   else
                   {
                       lblError.Text = "No se pudo Insertar el Contrato por algun motivo, Verifique e intente nuevamente";
                       lblError.Visible = true;
                   }
               }
               
            }
            if((PolizaSegAuto.Fecha_Vencimiento !=null) )
            {
                if(NegImagCert.ObtenerFecha(PolizaSegAuto)!=PolizaSegAuto.Fecha_Vencimiento && (PolizaSegAuto.Id_Camion!=0))
                {
                    if (CheckSiAplicaPoliza.Checked)
                    {
                        PolizaSegAuto.Aplica = 1;
                    }
                    else
                    {
                        PolizaSegAuto.Aplica = 0;
                    }
                    if (NegImagCert.InsertarImagen(PolizaSegAuto) == 1)
                    {

                    }
                    else
                    {
                        lblError.Text = "No se pudo Insertar La Poliza De Seguro por algun motivo, Verifique e intente nuevamente";
                        lblError.Visible = true;
                    }
                }
                
            } 
            if ((RespCivilCombustible.Fecha_Vencimiento != null) )
            {
                if( NegImagCert.ObtenerFecha(RespCivilCombustible)!=RespCivilCombustible.Fecha_Vencimiento && (RespCivilCombustible.Id_Camion!=0))
                {
                    if (CheckSiAplicaRespCivilCombustible.Checked)
                    {
                        RespCivilCombustible.Aplica = 1;
                    }
                    else
                    {
                        RespCivilCombustible.Aplica = 0;
                    }
                    if (NegImagCert.InsertarImagen(RespCivilCombustible) == 1)
                    {

                    }
                    else
                    {
                        lblError.Text = "No se pudo Insertar La Poliza De Seguro por algun motivo, Verifique e intente nuevamente";
                        lblError.Visible = true;
                    }
                }
               
            }
            if ((Calibracion.Fecha_Vencimiento != null) )
            {
                if( NegImagCert.ObtenerFecha(Calibracion)!=Calibracion.Fecha_Vencimiento && (Calibracion.Id_Camion!=0))
                {
                    if (CheckSiAplicaCalibracion.Checked)
                    {
                        Calibracion.Aplica = 1;
                    }
                    else
                    {
                        Calibracion.Aplica = 0;
                    }
                    if (NegImagCert.InsertarImagen(Calibracion) == 1)
                    {

                    }
                    else
                    {
                        lblError.Text = "No se pudo Insertar La Poliza De Seguro por algun motivo, Verifique e intente nuevamente";
                        lblError.Visible = true;
                    }
                }
                
            }
            if ((InspecTecniTanque.Fecha_Vencimiento != null) )
            {
               if( NegImagCert.ObtenerFecha(InspecTecniTanque)!=InspecTecniTanque.Fecha_Vencimiento && (InspecTecniTanque.Id_Camion!=0))
               {
                   if (CheckSiAplicaInspec.Checked)
                   {
                       InspecTecniTanque.Aplica = 1;
                   }
                   else
                   {
                       InspecTecniTanque.Aplica = 0;
                   }
                   if (NegImagCert.InsertarImagen(InspecTecniTanque) == 1)
                   {

                   }
                   else
                   {
                       lblError.Text = "No se pudo Insertar La Poliza De Seguro por algun motivo, Verifique e intente nuevamente";
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
            txtVencimientoRUAT.Text = "";
            txtVigenciaCisterna.Text = "";
            txtVigenciaMant.Text = "";
            txtVigenciaSOAT.Text = "";
            txtVigenciaINSTEC.Text = "";
            txtVigenciaINTT.Text = "";
            txtVencimientoEst.Text = "";
            txtRespCivProd.Text = "";
            txtRespCivTra.Text = "";
            txtContrato.Text = "";
        }

        protected void BtnDowRUAT_Click(object sender, EventArgs e)
        {

            int CamionId = Convert.ToInt32(Request.QueryString["Id"]);
            EntCamiones objCamion = new EntCamiones();
            objCamion = NegCamiones.BuscarCamiones(CamionId); //haber
            EntDetalle_Certificados Img = new EntDetalle_Certificados();
            Img = NegImagCert.Download(CamionId, 5);
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

        protected void BtnSoat_Click(object sender, EventArgs e)
        {
            int CodigoCamion;
            int CamionId = Convert.ToInt32(Request.QueryString["Id"]);
            EntCamiones objPropietario = new EntCamiones();
            objPropietario = NegCamiones.BuscarCamiones(CamionId);
            CodigoCamion = Convert.ToInt32(objPropietario.Id_Camion);
            EntSoat Img = new EntSoat();
            Img = NegSoat.Download(CodigoCamion);
            if (Img == null)
            {
                lblError.Text = "No se pudo Descargar La Imagen";
                lblError.Visible = true;
                return;
            }
            byte[] Document = (byte[])Img.ImgSoat;
            Response.ClearContent();
            Response.ContentType = "application/octetstream";
            Response.AddHeader("Content-Disposition", string.Format("attachment;filenames={0}", Img.DocumentNombre));
            Response.AddHeader("Content-Length", Document.Length.ToString());
            Response.BinaryWrite(Document);
            Response.Flush();
            Response.Close();
        }

        protected void BtnInst_Click(object sender, EventArgs e)
        {
            int CodigoCamion;
            int CamionId = Convert.ToInt32(Request.QueryString["Id"]);
            EntCamiones objPropietario = new EntCamiones();
            objPropietario = NegCamiones.BuscarCamiones(CamionId);
            CodigoCamion = Convert.ToInt32(objPropietario.Id_Camion);
            EntInspTecnica Img = new EntInspTecnica();
            Img = NegInspeccTec.Download(CodigoCamion);
            if (Img == null)
            {
                lblError.Text = "No se pudo Descargar La Imagen";
                lblError.Visible = true;
                return;
            }
            byte[] Document = (byte[])Img.ImgIT;
            Response.ClearContent();
            Response.ContentType = "application/octetstream";
            Response.AddHeader("Content-Disposition", string.Format("attachment;filenames={0}", Img.DocumentNombre));
            Response.AddHeader("Content-Length", Document.Length.ToString());
            Response.BinaryWrite(Document);
            Response.Flush();
            Response.Close();
        }

        protected void BtnMant_Click(object sender, EventArgs e)
        {
            int CamionId = Convert.ToInt32(Request.QueryString["Id"]);
            EntCamiones objCamion = new EntCamiones();
            objCamion = NegCamiones.BuscarCamiones(CamionId); //haber
            EntDetalle_Certificados Img = new EntDetalle_Certificados();
            Img = NegImagCert.Download(CamionId, 1);
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

        protected void BtnTorna_Click(object sender, EventArgs e)
        {
            int CamionId = Convert.ToInt32(Request.QueryString["Id"]);
            EntCamiones objCamion = new EntCamiones();
            objCamion = NegCamiones.BuscarCamiones(CamionId); //haber
            EntDetalle_Certificados Img = new EntDetalle_Certificados();
            Img = NegImagCert.Download(CamionId, 2);
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

        protected void BtnCist_Click(object sender, EventArgs e)
        {
            int CamionId = Convert.ToInt32(Request.QueryString["Id"]);
            EntCamiones objCamion = new EntCamiones();
            objCamion = NegCamiones.BuscarCamiones(CamionId); //haber
            EntDetalle_Certificados Img = new EntDetalle_Certificados();
            Img = NegImagCert.Download(CamionId, 3);
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

        protected void BtnEstan_Click(object sender, EventArgs e)
        {
            int CamionId = Convert.ToInt32(Request.QueryString["Id"]);
            EntCamiones objCamion = new EntCamiones();
            objCamion = NegCamiones.BuscarCamiones(CamionId); //haber
            EntDetalle_Certificados Img = new EntDetalle_Certificados();
            Img = NegImagCert.Download(CamionId, 4);
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

        protected void BtnResCivProd_Click(object sender, EventArgs e)
        {
            int CamionId = Convert.ToInt32(Request.QueryString["Id"]);
            EntCamiones objCamion = new EntCamiones();
            objCamion = NegCamiones.BuscarCamiones(CamionId); //haber
            EntDetalle_Certificados Img = new EntDetalle_Certificados();
            Img = NegImagCert.Download(CamionId, 6);
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

        protected void BtnResCivTra_Click(object sender, EventArgs e)
        {
            int CamionId = Convert.ToInt32(Request.QueryString["Id"]);
            EntCamiones objCamion = new EntCamiones();
            objCamion = NegCamiones.BuscarCamiones(CamionId); //haber
            EntDetalle_Certificados Img = new EntDetalle_Certificados();
            Img = NegImagCert.Download(CamionId, 7);
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

        protected void BtnContrato_Click(object sender, EventArgs e)
        {
            int CamionId = Convert.ToInt32(Request.QueryString["Id"]);
            EntCamiones objCamion = new EntCamiones();
            objCamion = NegCamiones.BuscarCamiones(CamionId); //haber
            EntDetalle_Certificados Img = new EntDetalle_Certificados();
            Img = NegImagCert.Download(CamionId, 8);
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

        protected void ImagePoliza_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarPolizaAuto.Visible)
            {
                CalendarPolizaAuto.Visible = false;
            }
            else
            {
                CalendarPolizaAuto.Visible = true;
            }
        }
        protected void CalendarPoliza_SelectionChanged(object sender, EventArgs e)
        {
            if (CalendarPolizaAuto.SelectedDate != null)
            {
                txtPoliza.Text = CalendarPolizaAuto.SelectedDate.ToString("d");
                CalendarPolizaAuto.Visible = false;
            }
        }

        protected void ImageRespCivCombustible_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarRespCivilCombustible.Visible)
            {
                CalendarRespCivilCombustible.Visible = false;
            }
            else
            {
                CalendarRespCivilCombustible.Visible = true;
            }
        }

        protected void CalendarRespCivilCombustible_SelectionChanged(object sender, EventArgs e)
        {
            if (CalendarRespCivilCombustible.SelectedDate != null)
            {
                txtResCivilCombustible.Text = CalendarRespCivilCombustible.SelectedDate.ToString("d");
                CalendarRespCivilCombustible.Visible = false;
            }
        }

        

        protected void ImgCalibracion_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarCalibracion.Visible)
            {
                CalendarCalibracion.Visible = false;
            }
            else
            {
                CalendarCalibracion.Visible = true;
            }
        }
        protected void CalendarCalibracion_SelectionChanged(object sender, EventArgs e)
        {
            if (CalendarCalibracion.SelectedDate != null)
            {
                txtCalibracion.Text = CalendarCalibracion.SelectedDate.ToString("d");
                CalendarCalibracion.Visible = false;
            }
        }

        protected void ImgTectanque_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarInspecTecTanque.Visible)
            {
                CalendarInspecTecTanque.Visible = false;
            }
            else
            {
                CalendarInspecTecTanque.Visible = true;
            }

        }
        protected void CalendarInspecTanque_SelectionChanged(object sender, EventArgs e)
        {
            if (CalendarInspecTecTanque.SelectedDate != null)
            {
                txtInspecTecTanque.Text = CalendarInspecTecTanque.SelectedDate.ToString("d");
                CalendarInspecTecTanque.Visible = false;
            }

        }

        protected void chkSiAplicaMantenimiento_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSiAplicaMantenimiento.Checked)
            {
                chkNoAplicaMantenimiento.Checked = false;
            }
        }

        protected void chkNoAplicaMantenimiento_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNoAplicaMantenimiento.Checked)
            {
                chkSiAplicaMantenimiento.Checked = false;
            }
        }

        protected void CheckSiAplicaTornamesa_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckSiAplicaTornamesa.Checked)
            {
                CheckNoAplicaTornamesa.Checked = false;
            }
        }

        protected void CheckNoAplicaTornamesa_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckNoAplicaTornamesa.Checked)
            {
                CheckSiAplicaTornamesa.Checked = false;
            }
        }

        protected void CheckSiAplicaCisterna_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckSiAplicaCisterna.Checked)
            {
                CheckNoAplicaCisterna.Checked = false;
            }
        }

        protected void CheckNoAplicaCisterna_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckNoAplicaCisterna.Checked)
            {
                CheckSiAplicaCisterna.Checked = false; 
            }
        }

        protected void CheckSiAplicaEstan_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckSiAplicaEstan.Checked)
            {
                CheckNoAplicaEstan.Checked = false;
            }
        }

        protected void CheckNoAplicaEstan_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckNoAplicaEstan.Checked)
            {
                CheckSiAplicaEstan.Checked = false;
            }
        }

        protected void CheckSiAplicaResCivProd_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckSiAplicaResCivProd.Checked)
            {
                CheckNoAplicaResCivProv.Checked = false;
            }
        }

        protected void CheckNoAplicaResCivProv_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckNoAplicaResCivProv.Checked)
            {
                CheckSiAplicaResCivProd.Checked = false;
            }
        }

        protected void CheckSiAplicaRespCivTra_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckSiAplicaRespCivTra.Checked)
            {
                CheckNoAplicaRespCivTra.Checked = false;
            }
        }

        protected void CheckSiAplicaInspec_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckSiAplicaInspec.Checked)
            {
                CheckNoAplicaInspec.Checked = false;
            }
        }

        protected void CheckNoAplicaInspec_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckNoAplicaInspec.Checked)
            {
                CheckSiAplicaInspec.Checked = false;
            }
        }

        protected void CheckNoAplicaRespCivTra_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckNoAplicaRespCivTra.Checked)
            {
                CheckSiAplicaRespCivTra.Checked = false;
            }
        }

        protected void CheckSiAplicaContrato_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckSiAplicaContrato.Checked)
            {
                CheckNoAplicaContrato.Checked = false;
            }
        }

        protected void CheckNoAplicaContrato_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckNoAplicaContrato.Checked)
            {
                CheckSiAplicaContrato.Checked = false;
            }
        }

        protected void CheckSiAplicaPoliza_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckSiAplicaPoliza.Checked)
            {
                CheckNoAplicaPoliza.Checked = false;
            }
        }

        protected void CheckNoAplicaPoliza_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckNoAplicaPoliza.Checked)
            {
                CheckSiAplicaPoliza.Checked = false;
            }
        }

        protected void CheckSiAplicaRespCivilCombustible_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckSiAplicaRespCivilCombustible.Checked)
            {
                CheckNoAplicaRespCivilCombustible.Checked = false;
            }
        }

        protected void CheckNoAplicaRespCivilCombustible_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckNoAplicaRespCivilCombustible.Checked)
            {
                CheckSiAplicaRespCivilCombustible.Checked = false;
            }
        }

        protected void CheckSiAplicaCalibracion_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckSiAplicaCalibracion.Checked)
            {
                CheckNoAplicaCalibracion.Checked = false;
            }
        }

        protected void CheckNoAplicaCalibracion_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckNoAplicaCalibracion.Checked)
            {
                CheckSiAplicaCalibracion.Checked = false;
            }
        }
    }
}