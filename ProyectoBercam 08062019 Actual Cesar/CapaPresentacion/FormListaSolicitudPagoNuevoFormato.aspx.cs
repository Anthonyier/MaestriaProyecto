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
    public partial class FormListaSolicitudPagoNuevoFormato : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarAño();
                CargarMes();
                cmAño.Text = DateTime.Now.Year.ToString();
            }
        }
        public void CargarAño()
        {
            cmAño.Items.Clear();
            cmAño.Items.Add(new ListItem("--Seleccione Año--", ""));
            cmAño.AppendDataBoundItems = true;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            SqlCommand cmd = new SqlCommand();
            try
            {
                string sql = "Select * From Año";
                cmd.CommandText = sql;
                cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                dr = cmd.ExecuteReader();
                cmAño.DataSource = dr;
                cmAño.DataTextField = "Descripcion";
                cmAño.DataValueField = "Descripcion";
                cmAño.DataBind();
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
        public void CargarMes()
        {
            cmMes.Items.Clear();
            cmMes.Items.Add(new ListItem("--Seleccione el Mes--", ""));
            cmMes.AppendDataBoundItems = true;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            SqlCommand cmd = new SqlCommand();
            try
            {
                string sql = "SELECT * FROM Mes";
                cmd.CommandText = sql;
                cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                //cmd.Transaction = myTrans;
                dr = cmd.ExecuteReader();
                cmMes.DataSource = dr; //cmd.ExecuteReader();    
                cmMes.DataTextField = "Descripcion";
                cmMes.DataValueField = "Id";
                cmMes.DataBind();
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
        protected void buttonCheck_Click(object sender, EventArgs e)
        {
            LblError.Visible = false;
            List<int> Lista = new List<int>();
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if ((GridView1.Rows[i].FindControl("Input") as CheckBox).Checked == true)
                {
                    Label LblNroCuenta = (GridView1.Rows[i].Cells[0].FindControl("Label3") as Label);
                    long NroCuenta = Convert.ToInt64(LblNroCuenta.Text);
                    string AbrevBanco = NegAsignacionRuta.EncontrarAbrevBanco(NroCuenta);
                    bool VerifBanco = NegAsignacionRuta.VerifBanco(AbrevBanco);
                    if (VerifBanco == false)
                    {
                        Response.Write("<script languaje =javascript>alert ('Mensaje De Validacion: Estimado Usuario no se pudo generar el permiso de pago para el banco BCP por el siguiente motivo: El Banco No Tiene Convenio Con el BCP Para Pagos Multiples ');</script>");
                        return;
                    }
                    else
                    {
                        Label Idtxt = GridView1.Rows[i].Cells[0].FindControl("Label1") as Label;
                        int Id = Convert.ToInt32(Idtxt.Text);
                        Lista.Add(Id);
                    }
                   
                }
            }
            if (Lista.Count() > 0)
            {
                if (VerificarYaPagado(Lista) == false)
                {
                    int Id_Pmm = NegConciliacionPorPagar.InsertarPagoMasivoLiqui();
                    for (int i = 0; i < Lista.Count(); i++)
                    {
                        int Id = Lista[i];
                        NegConciliacionPorPagar.ActualizarConciliacionPorPagarIdPmm(Id_Pmm, Id);
                    }
                    this.GridView1.DataBind();
                }
                else
                {
                    Response.Write("<script languaje =javascript>alert ('Uno De Estos Viajes Ya tiene asignado un Texto De Pago Masivo');</script>");
                    //LblError.Text = "Uno De Estos Viajes Ya tiene asignado un Texto De Pago Masivo";
                    //LblError.Visible = true;
                }
            }
        }
        protected static bool VerificarYaPagado(List<int> Lista)
        {
            bool YaPag = false;
            for (int i = 0; i < Lista.Count(); i++)
            {
                int Id = Lista[i];
                int Verif = NegConciliacionPorPagar.VerificarYaPagadoLiquidacion(Id);
                if (Verif != 0)
                {
                    YaPag = true;
                    return YaPag;
                }
            }
            return YaPag;
        }
        protected void DtgListaGridViewLiqPmm_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            EntUsuario us = (EntUsuario)Session["Usuario"];
            EntUsuario usuario = (EntUsuario)Session["Usuario"];
            EntPermisosPagos Permiso = NegPermisosPagos.BuscarPermiso(usuario.Id_Usuario);
            if (e.CommandName == "ModoTexto")
            {
                if (Permiso.ImagenesPagadas == 1)
                {
                    int Id = Convert.ToInt32(e.CommandArgument.ToString());
                    CrearTexto(Id);
                }
            }
            if (e.CommandName == "AgregarDocumento")
            {
                EntBitacora bit = new EntBitacora();
                bit.Usuario = us.Nombre + "" + us.Apellidos;
                bit.Accion = "El usuario va ingresar documentos ";
                bit.IdUsuario = us.Id_Usuario;
                int bi = NegBitacora.GuardarBitacora(bit);
                if (Permiso.ImagenesPagadas == 1)
                {
                    string ConciliacionId = e.CommandArgument.ToString();
                    Response.Redirect("FormImagenesPagadas.aspx?Id=" + ConciliacionId);
                }
            }
        }
        public string Reemplazar(double num)
        {
            string numero = Convert.ToString(num);
            numero = numero.Replace(",", ".");
            return numero;
        }
        protected void CrearTexto(int IdDetalle)
        {

            int IdPagoMasiv = NegConciliacionPorPagar.EncontrarIdPagoMasiv(IdDetalle);
            if (IdPagoMasiv == 0)
            {
                Response.Write("<script languaje =javascript>alert ('Este Viaje Aun No esta asignado a un pago por lo que aun no se puede generar su pago multiple ');</script>");
                return;
            }
            string textfile = string.Empty;
            int IdCont = 0;
            foreach (GridViewRow Rows in GridView1.Rows)
            {
                Label LblIdPago = (Rows.FindControl("Label11") as Label);
                int Idpmm = 0;

                if (String.IsNullOrEmpty(LblIdPago.Text))
                {
                    Idpmm = 0;
                }
                else
                {
                    Idpmm = Convert.ToInt32(LblIdPago.Text);
                }
                if (Idpmm == IdPagoMasiv && Idpmm != 0)
                {
                    Label LblNroCuenta = (Rows.FindControl("Label3") as Label);
                    long NroCuenta = Convert.ToInt64(LblNroCuenta.Text);
                    string AbrevBanco = NegAsignacionRuta.EncontrarAbrevBanco(NroCuenta);
                    string Tipo = "";
                    Label LblMontoLiquidacion = (Rows.FindControl("Label5") as Label);
                    double MontoLiquidacion = Convert.ToDouble(LblMontoLiquidacion.Text);
                    Label LblCi = (Rows.FindControl("Label9") as Label);
                    string Ci = LblCi.Text;
                    string Emision = NegPersona.EncontrarEmision(Ci);
                    bool VerifEmision = NegPersona.VerificarCodEmision(Emision);
                    Label LblPersona = (Rows.FindControl("Label2") as Label);
                    string NombrePersona = LblPersona.Text;
                    bool VerifBanco = NegAsignacionRuta.VerifBanco(AbrevBanco);
                    if (VerifEmision == false)
                    {
                        Response.Write("<script languaje =javascript>alert ('Mensaje De Validacion: Estimado Usuario no se pudo generar el archivo txt para el banco BCP por el siguiente motivo: La Sigla de Emision Del Carnet esta Mal Escrita ');</script>");
                        //LblError.Text = NombrePersona + "No tiene una sigla de Emision de CI O Su Sigla de Emision Esta Mal Escrita";
                        //LblError.Visible = true;
                        return;
                    }
                    if (VerifBanco == false)
                    {
                        Response.Write("<script languaje =javascript>alert ('Mensaje De Validacion: Estimado Usuario no se pudo generar el archivo txt para el banco BCP por el siguiente motivo: El Banco No Tiene Convenio Con el BCP Para Pagos Multiples ');</script>");
                        //LblError.Text = NombrePersona + "No tiene Una Sigla De Banco Que sea Reconocida Por El BCP Para Realizar El Pago";
                        //LblError.Visible = true;
                        return;
                    }
                    IdCont += 1;
                    if (AbrevBanco == "BCP")
                    {
                        Tipo = "HAB";
                        string Descripcion = "Pago De ADelanto De Pagos";
                        string ExtDoc = NegPersona.ExtDocumento(Emision);
                        textfile += Convert.ToString(IdCont) + "," + Tipo + "," + Convert.ToString(NroCuenta) + "," + Reemplazar(MontoLiquidacion) + "," + "," + Descripcion;
                        textfile += "," + "," + "Q" + "," + Ci + "," + ExtDoc + "," + "," + "," + "," + "," + "," + "," + "," + ",";
                    }
                    else
                    {
                        //int CodCiudad = NegPersona.EncontrarCodigoCiudad(Emision);
                        int CodCiudad = 701;
                        Tipo = "ACH";
                        textfile += Convert.ToString(IdCont) + "," + Tipo + "," + Convert.ToString(NroCuenta) + "," + Reemplazar(MontoLiquidacion) + "," + "," + "," + AbrevBanco;
                        textfile += "," + "," + "," + "," + "," + "," + NombrePersona + "," + "," + "," + "," + "," + Convert.ToString(CodCiudad) + ",";
                    }

                    textfile += "\r\n";
                }
            }


            //textfile += "Hola Mundo";
            //textfile += "\r\n";
            string FechaActual = DateTime.Now.ToString("yyyyMMddhhmmss");
            string Cadena = "PMM" + FechaActual + ".txt";
            Response.Clear();
            Response.Buffer = true;
            //Response.AddHeader("content-disposition", "attachment; filename=Pmm.txt");
            Response.AddHeader("content-disposition", "attachment; filename=" + Cadena);
            Response.Charset = "";
            Response.ContentType = "application/txt";
            Response.Output.Write(textfile);
            Response.Flush();
            Response.End();
        }
    }
}