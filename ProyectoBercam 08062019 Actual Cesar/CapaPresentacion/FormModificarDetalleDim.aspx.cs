using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocios;
using CapaEntidad;

namespace CapaPresentacion
{
    public partial class FormModificarDetalleDim : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] != null)
                {
                    int IdDetDim = Convert.ToInt32(Request.QueryString["Id"]);
                    TextDetalleIdDim.Text = Convert.ToString(IdDetDim);
                    int IdDetalleDim = Convert.ToInt32(TextDetalleIdDim.Text);
                    EntDetalleDim ObjDetDim = new EntDetalleDim();
                    ObjDetDim = NegDetalleDim.NobtenerDetalleDim(IdDetalleDim);
                    EntDetalle_Recepcion ObjDetalle = new EntDetalle_Recepcion();
                    ObjDetalle = NegDetalleDim.NObtenervaloresDetRecpDim(IdDetalleDim);
                    TextFechaPRM.Text = ObjDetDim.FechaPRM.ToString("yyyy-MM-dd");
                    TextPRMNo.Text = ObjDetDim.PRMno;
                    TextVolumenPRM.Text = Convert.ToString(ObjDetDim.VolumenPRM);
                    TextPesoPRM.Text = Convert.ToString(ObjDetDim.PesoPRM);

                    TextNroCrt.Text = Convert.ToString(ObjDetalle.NoCrt);
                    TextVolumenCrt.Text = Convert.ToString(ObjDetalle.VolumenCrt);
                    TextPesoCrt.Text = Convert.ToString(ObjDetalle.PesoCrt);
                    TextNroMic.Text = Convert.ToString(ObjDetalle.NoMic);
                    TextPesoMic.Text = Convert.ToString(ObjDetalle.PesoMic);
                    TextVolumenMic.Text = Convert.ToString(ObjDetalle.VolumenMic);

                    EntUsuario us = (EntUsuario)Session["Usuario"];
                    EntBitacora bit = new EntBitacora();
                    bit.Usuario = us.Nombre + "" + us.Apellidos;
                    bit.Accion = "El usuario esta intentando modificar DIMS";
                    bit.IdUsuario = us.Id_Usuario;
                    int bi = NegBitacora.GuardarBitacora(bit);

                }
            }
            EntUsuario usuario = (EntUsuario)Session["Usuario"];
            EntPermisoRutas PerRutas = NegPermisoRutas.BuscarPermiso(usuario.Id_Usuario);
            if (PerRutas.Dim != 1)
            {
                ButtonGuardar.Visible = false;
                ButtonGuardar.Enabled = false;
            }
        }

        protected void ButtonGuardar_Click(object sender, EventArgs e)
        {
            bool Resultado = false;
            if (TextFechaPRM.Text != "" && TextPesoPRM.Text != "" && TextPRMNo.Text != "" && TextVolumenPRM.Text != "")
            {
                DateTime Fecha = Convert.ToDateTime(TextFechaPRM.Text);
                double Peso = Convert.ToDouble(TextPesoPRM.Text);
                string PrmNo = TextPRMNo.Text;
                double VolumenPrm = Convert.ToDouble(TextVolumenPRM.Text);
                int IdDetalleDim = Convert.ToInt32(TextDetalleIdDim.Text);
                EntDetalleDim Obj= new EntDetalleDim ();
                Obj.Id = IdDetalleDim;
                Obj.FechaPRM=Convert.ToDateTime(Fecha);
                Obj.PesoPRM=Convert.ToDouble(Peso);
                Obj.PRMno=PrmNo;
                Obj.VolumenPRM=Convert.ToDouble(VolumenPrm);
                Resultado = NegDetalleDim.NEditarDetalleDim(Obj);
                int IdDetalleRecepcion = NegDetalleDim.NObtenerIdDetalleRececpionDim(IdDetalleDim);
                if (Resultado == true)
                {
                    EntDetalle_Recepcion ObjDet = new EntDetalle_Recepcion();
                    ObjDet.VolumenMic = Convert.ToDouble(TextVolumenMic.Text);
                    ObjDet.PesoMic = Convert.ToDouble(TextPesoMic.Text);
                    ObjDet.NoMic = TextNroMic.Text;
                    ObjDet.NoCrt = TextNroCrt.Text;
                    ObjDet.VolumenCrt = Convert.ToDouble(TextVolumenCrt.Text);
                    ObjDet.PesoCrt = Convert.ToDouble(TextPesoCrt.Text);
                    ObjDet.Id_Detalle = IdDetalleRecepcion;
                    Resultado = NegDetalleDim.NEditarDetalleRecepcionDatosDim(ObjDet);
                    if (Resultado == true)
                    {
                        //int id = Convert.ToInt32(Request.QueryString["Id"]);
                        //Response.Redirect("FormVisualizarDim.aspx?Id=" + id);
                        Response.Redirect("FormCreacionDim.aspx");
                    }
                    else
                    {
                        Response.Write("<script languaje=javascript>alert('No se pudo Modificar El Detalle De Recepcion');</script>");
                    }
                    
                }
                else
                {
                    Response.Write("<script languaje=javascript>alert('No se pudo Modificar El Detalle Dim');</script>");
                }
            }
        }

        protected void buttonAtras_Click(object sender, EventArgs e)
        {

        }
    }
}