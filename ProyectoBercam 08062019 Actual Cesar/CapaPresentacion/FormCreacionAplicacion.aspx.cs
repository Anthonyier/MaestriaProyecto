using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidad;
using CapaNegocios;
using System.Data.SqlClient;
using System.Data;

namespace CapaPresentacion
{
    public partial class FormCreacionAplicacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] != null)
                {
                    int idDim = Convert.ToInt32(Request.QueryString["Id"]);
                    EntDim ObjDim = new EntDim();
                    ObjDim = NegDim.BuscarDim(idDim);
                    double TotalPrm = NegDetalleDim.NObtenerTotalVolPrmDim(idDim);
                    TotalPrm = TotalPrm / 1000;
                    TextVolTrans.Text = Convert.ToString(TotalPrm);
                    TextProdAseg.Text = ObjDim.Producto;
                    TextNumeroDim.Text = ObjDim.Dim;
                    TextFronteraIngreso.Text = ObjDim.AduanaFrontera + " -ESTADO PLURINACIONAL DE BOLIVIA";
                    TextAsegurado.Text="TRANS BERCAM S.R.L.";
                    TextAseguradoAdicional.Text="Yacimientos Petrolíferos Fiscales Bolivianos";
                    TextMeTrans.Text = "terrestre en camiones cisterna";
                    TextLimiteMaximo.Text = Convert.ToString(90000);
                    TextCoberturas.Text = "TODO RIESGO, según cláusula \"A\" del Instituto de Londres para carga, incluyendo huelgas, Conmoción civil"+
                     " y Daño malicioso, según cláusula de Riesgos políticos";
                    TextDeducible.Text = "3% sobre el valor del embarque mínimo $us. 5000,00.- por todo y cada evento";
                    TextFormaDePago.Text = "Al contado";

                    EntUsuario us = (EntUsuario)Session["Usuario"];
                    EntBitacora bit = new EntBitacora();
                    bit.Usuario = us.Nombre + "" + us.Apellidos;
                    bit.Accion = "El Usuario esta intentando crear una Aplicacion";
                    bit.IdUsuario = us.Id_Usuario;
                    int bi = NegBitacora.GuardarBitacora(bit);
                }
            }
            EntUsuario usuario = (EntUsuario)Session["Usuario"];
            EntPermisoRutas PerRutas = NegPermisoRutas.BuscarPermiso(usuario.Id_Usuario);
            if (PerRutas.Aplicacion != 1)
            {
                ButtonGuardar.Visible = false;
                ButtonGuardar.Enabled = false;
            }
        }

        protected void ButtonAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormAgregarAplicacion.aspx");
        }

        protected void ButtonGuardar_Click(object sender, EventArgs e)
        {
            int res = 0;
            if (TextProdAseg.Text != "" && TextVolTrans.Text != "" && TextValAseg.Text != "" && TextNumeroDim.Text != "" && TextFronteraIngreso.Text != "" && TextPeriodoCargaDesde.Text != "" && TextPeriodoCargaHasta.Text != "" && TextPrimaTotal.Text!="")
            {
                EntAplicacion ObjAplicacion = new EntAplicacion();
                ObjAplicacion.Asegurado = TextAsegurado.Text;
                ObjAplicacion.Asegurado_Adicional = TextAseguradoAdicional.Text;
                ObjAplicacion.Producto_Asegurado = TextProdAseg.Text;
                ObjAplicacion.Volumen_Transportado = Convert.ToDouble(TextVolTrans.Text);
                ObjAplicacion.Valor_Asegurado = Convert.ToDouble(TextValAseg.Text);
                ObjAplicacion.NumeroDim = TextNumeroDim.Text;
                ObjAplicacion.MedioDeTransporte = TextMeTrans.Text;
                ObjAplicacion.LimiteMaximoEmbarque = Convert.ToDouble(TextLimiteMaximo.Text);
                ObjAplicacion.Travesia = TextTravesia.Text;
                ObjAplicacion.FronteraDeIngreso = TextFronteraIngreso.Text;
                ObjAplicacion.Coberturas = TextCoberturas.Text;
                ObjAplicacion.PeriodoCargaDesde = Convert.ToDateTime(TextPeriodoCargaDesde.Text);
                ObjAplicacion.PeriodoCargaHasta = Convert.ToDateTime(TextPeriodoCargaHasta.Text);
                ObjAplicacion.Deducible = TextDeducible.Text;
                ObjAplicacion.PrimaTotal = Convert.ToDouble(TextPrimaTotal.Text);
                ObjAplicacion.FormaDePago = TextFormaDePago.Text;
                ObjAplicacion.IdDim = Convert.ToInt32(Request.QueryString["Id"]);
                ObjAplicacion.PrecioPromedio = Convert.ToDouble(TextPrecPromed.Text);
                int EncontrarDim = NegAplicacion.EncontrarDimAplicado(ObjAplicacion.IdDim);
                if (EncontrarDim == 0)
                {
                    res = NegAplicacion.InsertarAplicacion(ObjAplicacion);
                }
                else
                {
                    Response.Write("<script languaje=javascript>alert('Este dim ya ha sido usado en otra aplicación');</script>");
                }
               
                if (res == 1)
                {
                    Response.Redirect("FormAgregarAplicacion.aspx");
                }
                else
                {
                    Response.Write("<script languaje=javascript>alert('No se pudo Guardar la Aplicacion debido a un problema');</script>");
                }
          }
        }

        protected void ButtonCalcular_Click(object sender, EventArgs e)
        {
            double Voltransporte = Convert.ToDouble(TextVolTrans.Text);
            double PrecioPromedio = Convert.ToDouble(TextPrecPromed.Text);
            //double ValorAsegurado = Math.Round((Voltransporte * PrecioPromedio) / 1000, 2);
            double ValorAsegurado = Math.Round((Voltransporte * PrecioPromedio), 2);
            TextValAseg.Text = Convert.ToString(ValorAsegurado);
        }
    }
}