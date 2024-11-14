using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using System.Data;
using System.Data.SqlClient;
using CapaNegocios;
using CapaEntidad;

namespace CapaPresentacion
{
    public partial class FormConfirmarViajePlaca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }

        }
        public Boolean RepetidosPorConfirmar(int IdDetalle)
        {
            String Placa = NegAsignacionRuta.BuscarPlacaConfirmar(IdDetalle);
            DateTime Fecha = NegAsignacionRuta.BuscarFechaCargaConfirmar(IdDetalle);
            int Ruta = NegAsignacionRuta.BuscarRutaConfirmar(IdDetalle);
            SqlDataReader bd = NegAsignacionRuta.BuscarProgramacion(Placa, Ruta, Fecha);
            bd.Read();
            if (bd.HasRows == true)
            {
                if (bd != null)
                {
                    lblError.Text = "Esta Programacion ya ha sido metida";
                    lblError.Visible = true;
                    return true;
                }
            }
            return false;
        }
        protected void DtgListaConfirmarViajePlaca_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            EntUsuario usuario = (EntUsuario)Session["Usuario"];
            EntPermisoRutas Per = NegPermisoRutas.BuscarPermiso(usuario.Id_Usuario);
            if (e.CommandName == "Confirmar")
            {
                string RecepcionId = e.CommandArgument.ToString();
                int IdDetalle = int.Parse(RecepcionId);
                if (RepetidosPorConfirmar(IdDetalle) == false)
                {
                    NegAsignacionRuta.ConfirmarViaje(int.Parse(RecepcionId));
                    Response.Write("<script languaje =javascript>alert ('Se ha confirmado la Programacion');</script>");
                }

            }
            if (e.CommandName == "ConfirmarFecha")
            {
                if (Per.ConfirmarRuta == 1)
                {
                    string RecepcionId = e.CommandArgument.ToString();
                    int IdCliente = NegAsignacionRuta.IdDetalleCliente(Convert.ToInt32(RecepcionId));
                    if (IdCliente != 6730)
                    {
                        Response.Redirect("FormConfirmarProgramacionFecha.aspx?Id=" + RecepcionId + "&Modo=" + 2);
                    }
                    else
                    {
                        Response.Write("<script languaje =javascript>alert ('Este viaje es internacional tiene que ser confirmado por Mic');</script>");
                    }
                    
                }

            }
            if (e.CommandName == "NoDespachado")
            {
                if (Per.NoDespachado == 1)
                {
                    string RecepcionId = e.CommandArgument.ToString();
                    NegAsignacionRuta.NoDespachado(int.Parse(RecepcionId));
                    Response.Write("<script languaje =javascript>alert ('No se ha despachado la programacion');</script>");
                }

            }
        }
    }
}