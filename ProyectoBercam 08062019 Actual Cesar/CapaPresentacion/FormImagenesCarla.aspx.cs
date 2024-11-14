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
    public partial class FormImagenesCarla : System.Web.UI.Page
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

                objPersImg = NegCamiones.BuscarVigencia(CodigoCamion, 15);
                double diasVigenciaTarjetaOpTracto;
                if (objPersImg != null)
                {
                    diasVigenciaTarjetaOpTracto = Convert.ToDouble(objPersImg.DiasVigencia);
                    DateTime fec = Convert.ToDateTime(objPersImg.Fecha_Vencimiento);
                    txtVencimientoTarOpTracto.Text = fec.ToShortDateString();
                }
                else
                {
                    diasVigenciaTarjetaOpTracto = 0;
                    txtVencimientoTarOpTracto.Text = "FECHA DE VENCIMIENTO NO REGISTRADA";
                }
                if (diasVigenciaTarjetaOpTracto > 0 && diasVigenciaTarjetaOpTracto <= 30)
                {
                    txtVencimientoTarOpTracto.BackColor = Color.Orange;
                    lblVigenciaTarOpTracto.Text = "El documento se vence en menos de 30 dias";

                    string EMensaje = "La Tarjeta de Operacion Tracto: " + " " + TextBoxPlaca.Text + " esta proximo a vencerse, Verifique en Sistema";
                }
                if (diasVigenciaTarjetaOpTracto <= 0)
                {
                    txtVencimientoTarOpTracto.BackColor = Color.Red;
                    lblVigenciaTarOpTracto.Text = "Documento VENCIDO o NO REGISTRADO";

                    string EMensaje = "La Tarjeta de Operacion Tracto del Transportista: " + " " + TextBoxPlaca.Text + " esta VENCIDO o no Registrado, Verifique en Sistema";
                    
                }
                objPersImg = NegCamiones.BuscarVigencia(CodigoCamion, 16);
                double diasVigenciaTarjetaOpTanque;
                if (objPersImg != null)
                {
                    diasVigenciaTarjetaOpTanque = Convert.ToDouble(objPersImg.DiasVigencia);
                    DateTime fec = Convert.ToDateTime(objPersImg.Fecha_Vencimiento);
                    TextVencimientoTarOpTanque.Text = fec.ToShortDateString();

                }
                else
                {
                    diasVigenciaTarjetaOpTanque = 0;
                    TextVencimientoTarOpTanque.Text = "FECHA VENCIMIENTO NO REGISTRADA";
                }

             

                if (diasVigenciaTarjetaOpTanque > 0 && diasVigenciaTarjetaOpTanque  <= 30)
                {
                    TextVencimientoTarOpTanque.BackColor = Color.Orange;
                    LabelVigenciaTarOpTanque.Text = "El documento se vence en menos de 30 dias";

                    string EMensaje = "La Tarjeta De Operacion Del Tanque: " + " " + TextBoxPlaca.Text + " esta proximo a vencerse, Verifique en Sistema";
                   
                }
                if (diasVigenciaTarjetaOpTanque <= 0)
                {
                    TextVencimientoTarOpTanque.BackColor = Color.Red;
                    LabelVigenciaTarOpTanque.Text = "Documento VENCIDO o NO REGISTRADO";

                    string EMensaje = "La Tarjeta De Operacion Del Tanque Del Transportista: " + " " + TextBoxPlaca.Text + " esta VENCIDO o no Registrado, Verifique en Sistema";
                    
                }
                objPersImg = NegCamiones.BuscarVigencia(CodigoCamion, 17);
                double diasVigenciaCNRT;
                if (objPersImg != null)
                {
                    diasVigenciaCNRT = Convert.ToDouble(objPersImg.DiasVigencia);
                    DateTime fec = Convert.ToDateTime(objPersImg.Fecha_Vencimiento);
                    TextVencimientoCNRT.Text = fec.ToShortDateString();//Convert.ToString(objPersImg.VigenciaCI,"dd/MM/yyyy");

                }
                else
                {
                    diasVigenciaCNRT = 0;
                    TextVencimientoCNRT.Text = "FECHA VENCIMIENTO NO REGISTRADA";
                }

              

                if (diasVigenciaCNRT  > 0 && diasVigenciaCNRT <= 30)
                {
                    TextVencimientoCNRT.BackColor = Color.Orange;
                    LabelVigenciaCNRT.Text = "El documento se vence en menos de 30 dias";

                    string EMensaje = "EL CNRT: " + " " + TextBoxPlaca.Text + " esta proximo a vencerse, Verifique en Sistema";
                    
                }
                if (diasVigenciaCNRT <= 0)
                {
                    TextVencimientoCNRT.BackColor = Color.Red;
                    LabelVigenciaCNRT.Text = "Documento VENCIDO o NO REGISTRADO";

                    string EMensaje = "El CNRT Del Transportista: " + " " + TextBoxPlaca.Text + " esta VENCIDO o no Registrado, Verifique en Sistema";
                    
                }
                objPersImg = NegCamiones.BuscarVigencia(CodigoCamion, 18);
                double diasVigenciaDinatrans;
                if (objPersImg != null)
                {
                    diasVigenciaDinatrans = Convert.ToDouble(objPersImg.DiasVigencia);
                    DateTime fec = Convert.ToDateTime(objPersImg.Fecha_Vencimiento);
                    TextVencimientoDinatrans.Text = fec.ToShortDateString();

                }
                else
                {
                    diasVigenciaDinatrans = 0;
                    TextVencimientoDinatrans.Text = "FECHA VENCIMIENTO NO REGISTRADA";
                }

                if (diasVigenciaDinatrans > 0 && diasVigenciaDinatrans <= 30)
                {
                    TextVencimientoDinatrans.BackColor = Color.Orange;
                    LabelVigenciaDinatrans.Text = "El documento se vence en menos de 30 dias";

                    string EMensaje = "El Dinatrans del transportista: " + " " + TextBoxPlaca.Text + " esta proximo a vencerse, Verifique en Sistema";
                   
                }
                if (diasVigenciaDinatrans <= 0)
                {
                    TextVencimientoDinatrans.BackColor = Color.Red;
                    LabelVigenciaDinatrans.Text = "Documento VENCIDO o NO REGISTRADO";

                    string EMensaje = "El Dinatrans del transportista: " + " " + TextBoxPlaca.Text + " esta VENCIDO o no Registrado, Verifique en Sistema";
                   
                }
                 objPersImg = NegCamiones.BuscarVigencia(CodigoCamion, 19);
                double diasVigenciaSegCTI;
                if (objPersImg != null)
                {
                    diasVigenciaSegCTI = Convert.ToDouble(objPersImg.DiasVigencia);
                    DateTime fec = Convert.ToDateTime(objPersImg.Fecha_Vencimiento);
                    TextVencimientoSegCTI.Text = fec.ToShortDateString();//Convert.ToString(objPersImg.VigenciaCI,"dd/MM/yyyy");

                }
                else
                {
                    diasVigenciaSegCTI = 0;
                    TextVencimientoSegCTI .Text = "FECHA VENCIMIENTO NO REGISTRADA";
                }

                if (diasVigenciaSegCTI > 0 && diasVigenciaSegCTI <= 30)
                {
                    TextVencimientoSegCTI.BackColor = Color.Orange;
                    LabelSegCTI.Text = "El documento se vence en menos de 30 dias";

                    string EMensaje = "El SEGCTI del transportista: " + " " + TextBoxPlaca.Text + " esta proximo a vencerse, Verifique en Sistema";
                 
                }
                if (diasVigenciaSegCTI <= 0)
                {
                    TextVencimientoSegCTI.BackColor = Color.Red;
                    LabelSegCTI.Text = "Documento VENCIDO o NO REGISTRADO";

                    string EMensaje = "El SEGCTI del transportista: " + " " + TextBoxPlaca.Text + " esta VENCIDO o no Registrado, Verifique en Sistema";
                }
                objPersImg = NegCamiones.BuscarVigencia(CodigoCamion, 22);
                double diasVigenciaPermPeru;
                if (objPersImg != null)
                {
                    diasVigenciaPermPeru = Convert.ToDouble(objPersImg.DiasVigencia);
                    DateTime fec = Convert.ToDateTime(objPersImg.Fecha_Vencimiento);
                    TextVencimientoPermPeru.Text = fec.ToShortDateString();
                }
                else
                {
                    diasVigenciaPermPeru = 0;
                    TextVencimientoPermPeru.Text = "FECHA VENCIMIENTO NO REGISTRADA";
                }

                if (diasVigenciaPermPeru > 0 && diasVigenciaPermPeru <= 30)
                {
                    TextVencimientoPermPeru.BackColor = Color.Orange;
                    LblPermPeru.Text = "El documento se vence en menos de 30 dias";

                    string EMensaje = "El Permiso Del Peru del transportista: " + " " + TextBoxPlaca.Text + " esta proximo a vencerse, Verifique en Sistema";

                }
                if (diasVigenciaPermPeru <= 0)
                {
                    TextVencimientoPermPeru.BackColor = Color.Red;
                    LblPermPeru.Text = "Documento VENCIDO o NO REGISTRADO";

                    string EMensaje = "El Permiso Del Peru del transportista: " + " " + TextBoxPlaca.Text + " esta VENCIDO o no Registrado, Verifique en Sistema";
                }
                objPersImg = NegCamiones.BuscarVigencia(CodigoCamion, 23);
                double diasVigenciaPermBrasil;
                if (objPersImg != null)
                {
                    diasVigenciaPermBrasil = Convert.ToDouble(objPersImg.DiasVigencia);
                    DateTime fec = Convert.ToDateTime(objPersImg.Fecha_Vencimiento);
                    TextVencimientoPermBrasil.Text = fec.ToShortDateString();
                }
                else
                {
                    diasVigenciaPermBrasil = 0;
                    TextVencimientoPermBrasil.Text = "FECHA VENCIMIENTO NO REGISTRADA";
                }

                if (diasVigenciaPermBrasil > 0 && diasVigenciaPermBrasil <= 30)
                {
                    TextVencimientoPermBrasil.BackColor = Color.Orange;
                    LblPermBrasil.Text = "El documento se vence en menos de 30 dias";

                    string EMensaje = "El Permiso Del Brasil del transportista: " + " " + TextBoxPlaca.Text + " esta proximo a vencerse, Verifique en Sistema";

                }
                if (diasVigenciaPermBrasil <= 0)
                {
                    TextVencimientoPermBrasil.BackColor = Color.Red;
                    LblPermBrasil.Text = "Documento VENCIDO o NO REGISTRADO";

                    string EMensaje = "El Permiso Del Brasil del transportista: " + " " + TextBoxPlaca.Text + " esta VENCIDO o no Registrado, Verifique en Sistema";
                }
                EntUsuario us = (EntUsuario)Session["Usuario"];
                EntBitacora bit = new EntBitacora();
                bit.Usuario = us.Nombre + "" + us.Apellidos;
                bit.Accion = "El usuario esta intentando insertar imagenes de camiones";
                bit.IdUsuario = us.Id_Usuario;
                int bi = NegBitacora.GuardarBitacora(bit);
            }
        }

        protected void imgVencimientoTarOpTracto_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarVencimientoTarOpTracto.Visible)
            {
                CalendarVencimientoTarOpTracto.Visible = false;
            }
            else
            {
                CalendarVencimientoTarOpTracto.Visible = true;
            }
        }

        protected void ImageVencimientoTarOpTanque_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarVencimientoTarOpTanque.Visible)
            {
                CalendarVencimientoTarOpTanque.Visible = false;
            }
            else
            {
                CalendarVencimientoTarOpTanque.Visible = true;
            }
        }

        protected void ImageVencimientoCNRT_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarVigenciaCNRT.Visible)
            {
                CalendarVigenciaCNRT.Visible = false;
            }
            else
            {
                CalendarVigenciaCNRT.Visible = true;
            }
        }

        protected void ImageVencimientoDinatrans_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarVigenciaDinaTrans.Visible)
            {
                CalendarVigenciaDinaTrans.Visible = false;
            }
            else
            {
                CalendarVigenciaDinaTrans.Visible = true;
            }
        }

        protected void ImageSegCTI_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarVigenciaSegCTI.Visible)
            {
                CalendarVigenciaSegCTI.Visible = false;
            }
            else
            {
                CalendarVigenciaSegCTI.Visible = true;
            }
        }
        protected void CalendarVencimientoTarOpTracto_SelectionChanged(object sender, EventArgs e)
        {
            if (CalendarVencimientoTarOpTracto.SelectedDate != null)
            {
                txtVencimientoTarOpTracto.Text = CalendarVencimientoTarOpTracto.SelectedDate.ToString("d");
                CalendarVencimientoTarOpTracto.Visible = false;
            }
        }
        protected void CalendarVencimientoTarOpTanque_SelectionChanged(object sender, EventArgs e)
        {
            if (CalendarVencimientoTarOpTanque.SelectedDate != null)
            {
                TextVencimientoTarOpTanque.Text = CalendarVencimientoTarOpTanque.SelectedDate.ToString("d");
                CalendarVencimientoTarOpTanque.Visible = false;
            }
        }
        protected void CalendarVigenciaCNRT_SelectionChanged(object sender, EventArgs e)
        {
            if (CalendarVigenciaCNRT.SelectedDate != null)
            {
                TextVencimientoCNRT.Text = CalendarVigenciaCNRT.SelectedDate.ToString("d");
                CalendarVigenciaCNRT.Visible = false;
            }
        }
        protected void CalendarVigenciaDinaTrans_SelectionChanged(object sender, EventArgs e)
        {
            if (CalendarVigenciaDinaTrans.SelectedDate != null)
            {
                TextVencimientoDinatrans.Text = CalendarVigenciaDinaTrans.SelectedDate.ToString("d");
                CalendarVigenciaDinaTrans.Visible=false; 
            }
        }
        protected void CalendarVigenciaSegCTI_SelectionChanged(object sender, EventArgs e)
        {
            if (CalendarVigenciaSegCTI.SelectedDate != null)
            {
                TextVencimientoSegCTI.Text = CalendarVigenciaSegCTI.SelectedDate.ToString("d");
                CalendarVigenciaSegCTI.Visible = false;
            }
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            EntDetalle_Certificados TarOpTracto = new EntDetalle_Certificados();
            TarOpTracto.Id_Certificado = 15;
            EntDetalle_Certificados TarOpTanque = new EntDetalle_Certificados();
            TarOpTanque.Id_Certificado = 16;
            EntDetalle_Certificados VigCNRT = new EntDetalle_Certificados();
            VigCNRT.Id_Certificado = 17;
            EntDetalle_Certificados VigDinatrans = new EntDetalle_Certificados();
            VigDinatrans.Id_Certificado = 18;
            EntDetalle_Certificados SegCTI = new EntDetalle_Certificados();
            SegCTI.Id_Certificado = 19;
            EntDetalle_Certificados PermPeru = new EntDetalle_Certificados();
            PermPeru.Id_Certificado = 22;
            EntDetalle_Certificados PermBrasil = new EntDetalle_Certificados();
            PermBrasil.Id_Certificado = 23;
            try
            {
                TarOpTracto.Fecha_Vencimiento = Convert.ToDateTime(txtVencimientoTarOpTracto.Text);
                TarOpTracto.Id_Camion = Convert.ToInt32(Request.QueryString["Id"]);
                TarOpTracto.Aplica = 1;
            }
            catch (Exception ex)
            {
                lblError.Text = "El campo Vigencia Tarjeta de operacion Tracto no tiene el formato correcto";
                lblError.Visible = true;
                TarOpTracto.Fecha_Vencimiento = Convert.ToDateTime(DateTime.Now.ToString());
                TarOpTracto.Id_Camion = 0;
            }
            try
            {
                TarOpTanque.Fecha_Vencimiento = Convert.ToDateTime(TextVencimientoTarOpTanque.Text);
                TarOpTanque.Id_Camion = Convert.ToInt32(Request.QueryString["Id"]);
                TarOpTanque.Aplica = 1;
            }
            catch (Exception ex)
            {
                lblError.Text = "El Campo Vigencia Tarjeta de Operacion Tanque no tiene el formato Correcto";
                lblError.Visible = true;
                TarOpTanque.Fecha_Vencimiento=Convert.ToDateTime(DateTime.Now.ToString());
                TarOpTanque.Id_Camion = 0;
            }
            try
            {
                VigCNRT.Fecha_Vencimiento = Convert.ToDateTime(TextVencimientoCNRT.Text);
                VigCNRT.Id_Camion = Convert.ToInt32(Request.QueryString["Id"]);
                VigCNRT.Aplica = 1;
            }
            catch (Exception ex)
            {
                lblError.Text = "El Campo Vigencia CNRT no tiene el Formato Correcto";
                lblError.Visible = true;
                VigCNRT.Fecha_Vencimiento = Convert.ToDateTime(DateTime.Now.ToString());
                VigCNRT.Id_Camion = 0;
            }
            try
            {
                VigDinatrans.Fecha_Vencimiento = Convert.ToDateTime(TextVencimientoDinatrans.Text);
                VigDinatrans.Id_Camion = Convert.ToInt32(Request.QueryString["Id"]);
                VigDinatrans.Aplica = 1;
            }
            catch (Exception ex)
            {
                lblError.Text = "El Campo Vigencia Dinatrans no tiene el Formato Correcto";
                lblError.Visible = true;
                VigDinatrans.Fecha_Vencimiento = Convert.ToDateTime(DateTime.Now.ToString());
                VigDinatrans.Id_Camion = 0;
            }
            try
            {
                SegCTI.Fecha_Vencimiento = Convert.ToDateTime(TextVencimientoSegCTI.Text);
                SegCTI.Id_Camion = Convert.ToInt32(Request.QueryString["Id"]);
                SegCTI.Aplica = 1;
            }
            catch (Exception ex)
            {
                lblError.Text = "El Campo Vigencia Seguro CTI no tiene el Formato Correcto";
                lblError.Visible = true;
                SegCTI.Fecha_Vencimiento = Convert.ToDateTime(DateTime.Now.ToString());
                SegCTI.Id_Camion = 0;
            }
            try
            {
                PermPeru.Fecha_Vencimiento = Convert.ToDateTime(TextVencimientoPermPeru.Text);
                PermPeru.Id_Camion = Convert.ToInt32(Request.QueryString["Id"]);
                PermPeru.Aplica = 1;
            }
            catch (Exception ex)
            {
                lblError.Text = "El Campo Vigencia Permiso Peru no Tiene el Formato Correcto";
                lblError.Visible = true;
                PermPeru.Fecha_Vencimiento = Convert.ToDateTime(DateTime.Now.ToString());
                PermPeru.Id_Camion = 0;
            }
            try
            {
                PermBrasil.Fecha_Vencimiento = Convert.ToDateTime(TextVencimientoPermBrasil.Text);
                PermBrasil.Id_Camion = Convert.ToInt32(Request.QueryString["Id"]);
                PermBrasil.Aplica = 1;
            }
            catch (Exception ex)
            {
                lblError.Text = "El Campo Vigencia Permiso Brasil no Tiene el Formato Correcto";
                lblError.Visible = true;
                PermBrasil.Fecha_Vencimiento = Convert.ToDateTime(DateTime.Now.ToString());
                PermBrasil.Id_Camion =0;
            }
            if(TarOpTracto.Fecha_Vencimiento!=null)
            {
                if (NegImagCert.ObtenerFecha(TarOpTracto) != TarOpTracto.Fecha_Vencimiento && TarOpTracto.Id_Camion!=0)
                {
                    if (NegImagCert.InsertarImagen(TarOpTracto) == 1)
                    {

                    }
                    else
                    {
                
                    lblError.Text = "No se pudo Insertar la Tarjeta de operación Tracto por algun motivo, Verifique e intente nuevamente";
                    lblError.Visible = true;
                
                    }
                }  
            }
            if (TarOpTanque.Fecha_Vencimiento != null)
            {
                if (NegImagCert.ObtenerFecha(TarOpTanque) != TarOpTanque.Fecha_Vencimiento && TarOpTanque.Id_Camion !=0)
                {
                    if (NegImagCert.InsertarImagen(TarOpTanque) == 1)
                    {

                    }
                    else
                    {
                        lblError.Text = "No se pudo Insertar La Tarjeta de Operación Tanque por algun motivo, Verifique e intente nuevamente";
                        lblError.Visible = true;
                    }
                }
            }
            if (VigCNRT.Fecha_Vencimiento != null)
            {
                if (NegImagCert.ObtenerFecha(VigCNRT) != VigCNRT.Fecha_Vencimiento && VigCNRT.Id_Camion!=0)
                {
                    if (NegImagCert.InsertarImagen(VigCNRT) == 1)
                    {

                    }
                    else
                    {
                        lblError.Text = "No Se pudo Insertar El CNRT por algun motivo, verifique e intente nuevamente";
                        lblError.Visible = true;
                    }
                }
            }
            if (VigDinatrans.Fecha_Vencimiento != null)
            {
                if (NegImagCert.ObtenerFecha(VigDinatrans) != VigDinatrans.Fecha_Vencimiento && VigDinatrans.Id_Camion!=0)
                {
                    if (NegImagCert.InsertarImagen(VigDinatrans) == 1)
                    {

                    }
                    else
                    {
                        lblError.Text = "No Se Pudo Insertar el Dinatrans por algun motivo, verifique e intente nuevamente";
                        lblError.Visible = true;
                    } 
                }
               
            }
            if (SegCTI.Fecha_Vencimiento != null)
            {
                if (NegImagCert.ObtenerFecha(SegCTI) != SegCTI.Fecha_Vencimiento && SegCTI.Id_Camion!=0)
                {
                    if (NegImagCert.InsertarImagen(SegCTI) == 1)
                    {

                    }
                    else
                    {
                        lblError.Text = "No Se Pudo Insertar el Seguro de CTI por algun motivo, verifique e intente nuevamente";
                        lblError.Visible = true;
                    }
                }
            }
            if (PermPeru.Fecha_Vencimiento != null)
            {
                if (NegImagCert.ObtenerFecha(PermPeru) != PermPeru.Fecha_Vencimiento && PermPeru.Id_Camion!=0)
                {
                    if (NegImagCert.InsertarImagen(PermPeru) == 1)
                    {

                    }
                    else
                    {
                        lblError.Text = "No Se Pudo Insertar El Permiso De Peru Por algun motivo, verifique e intente nuevamente";
                        lblError.Visible = true;
                    }
                }
            }
            if (PermBrasil.Fecha_Vencimiento != null)
            {
                if (NegImagCert.ObtenerFecha(PermBrasil) != PermBrasil.Fecha_Vencimiento && PermBrasil.Id_Camion!=0)
                {
                    if (NegImagCert.InsertarImagen(PermBrasil) == 1)
                    {

                    }
                    else
                    {
                        lblError.Text = "No Se Pudo Insertar El Permiso De Brasil Por algun motivo, verifique e intente nuevamente";
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
            txtVencimientoTarOpTracto.Text = "";
            TextVencimientoTarOpTanque.Text = "";
            TextVencimientoCNRT.Text = "";
            TextVencimientoDinatrans.Text = "";
            TextVencimientoSegCTI.Text = "";
        }

        protected void ImagePermPeru_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarPermPeru.Visible)
            {
                CalendarPermPeru.Visible = false;
            }
            else
            {
                CalendarPermPeru.Visible = true;
            }
        }
        protected void CalendarVigenciaPermPeru_SelectionChanged(object sender, EventArgs e)
        {
            if (CalendarPermPeru.SelectedDate != null)
            {
                TextVencimientoPermPeru.Text = CalendarPermPeru .SelectedDate.ToString("d");
                CalendarPermPeru.Visible = false;
            }
        }

        protected void ImagePermBrasil_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarPermBrasil.Visible)
            {
                CalendarPermBrasil.Visible = false;
            }
            else
            {
                CalendarPermBrasil.Visible = true;
            }
        }
        protected void CalendarVigenciaPermBrasil_SelectionChanged(object sender, EventArgs e)
        {
            if (CalendarPermBrasil.SelectedDate != null)
            {
                TextVencimientoPermBrasil.Text = CalendarPermBrasil.SelectedDate.ToString("d");
                CalendarPermBrasil.Visible = false;
            }
        }
    }
}