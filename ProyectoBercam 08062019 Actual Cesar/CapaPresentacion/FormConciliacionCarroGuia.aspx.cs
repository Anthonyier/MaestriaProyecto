using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidad;
using CapaDatos;
using System.Data;
using System.Data.SqlClient;
using CapaNegocios;
using System.IO;

namespace CapaPresentacion
{
    public partial class FormConciliacionCarroGuia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CargarPeriodo();
                CargarAño();
            }
            if (Request.QueryString["Id"] != null)
            {

            }
            else
            {
                EntUsuario us = (EntUsuario)Session["Usuario"];
                EntBitacora bit = new EntBitacora();
                bit.Usuario = us.Nombre + "" + us.Apellidos;
                bit.Accion = "El usuario esta intentando Crear Conciliacion De Carros Guias";
                bit.IdUsuario = us.Id_Usuario;
                int bi = NegBitacora.GuardarBitacora(bit);
            }
            EntUsuario usuario = (EntUsuario)Session["Usuario"];
            EntPermisosCarroGuias Persona = NegPermisosCarroGuia.BuscarPermiso(usuario.Id_Usuario);
            if (Persona.CrearConcCarGuia!= 1)
            {
                BtnGuardar.Visible = false;
                BtnGuardar.Enabled = false;
            }
        }

        
        public void CargarTelefono(int Per,int año, string numero)
        {
            DDLTelefonoCarroGuia.Items.Clear();
            DDLTelefonoCarroGuia.AppendDataBoundItems = true;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            SqlCommand cmd = new SqlCommand();
            int MesPer = NegConciliacionCarroGuia.ObtenerMes(Per);
            try
            {
                string sql = "Select * From DetalleTelefono where Personal='DIEGO ENRIQUE ROCHA'and IdMes=" + MesPer + " and IdAño=" +  año  +" and Numero=" + numero;
                cmd.CommandText = sql;
                cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                dr = cmd.ExecuteReader();
                DDLTelefonoCarroGuia.DataSource = dr;
                DDLTelefonoCarroGuia.DataTextField = "Numero";
                DDLTelefonoCarroGuia.DataValueField = "Id";
                DDLTelefonoCarroGuia.DataBind();
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

        public void CargarTelefono2(int Periodo,int año,string Numero)
        {
            DDLTelefonoCarroGuia2.Items.Clear();
            DDLTelefonoCarroGuia2.AppendDataBoundItems = true;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            SqlCommand cmd = new SqlCommand();
            int MesPer = NegConciliacionCarroGuia.ObtenerMes(Periodo);
            try
            {
                string sql = "Select * From DetalleTelefono where Personal='DIEGO ENRIQUE ROCHA' and IdMes=" + MesPer + " and IdAño=" +  año+ "and Numero="+Numero ;
                cmd.CommandText = sql;
                cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                dr = cmd.ExecuteReader();
                DDLTelefonoCarroGuia2.DataSource = dr;
                DDLTelefonoCarroGuia2.DataTextField = "Numero";
                DDLTelefonoCarroGuia2.DataValueField = "Id";
                DDLTelefonoCarroGuia2.DataBind();
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

        public void CargarCamion(int IdCamion)
        {
            DDLCamionCarroGuia.Items.Clear();
            DDLCamionCarroGuia.AppendDataBoundItems = true;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            SqlCommand cmd = new SqlCommand();
            try
            {
                string sql = "select * from Camiones where Id_Camion=" + IdCamion;
                cmd.CommandText = sql;
                cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                //cmd.Transaction = myTrans;
                dr = cmd.ExecuteReader();
                DDLCamionCarroGuia.DataSource = dr; //cmd.ExecuteReader();    
                DDLCamionCarroGuia.DataTextField = "Placa";
                DDLCamionCarroGuia.DataValueField = "Id_Camion";
                DDLCamionCarroGuia.DataBind();
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
        public void CargarPeriodo()
        {
            DdlPeriodo.Items.Clear();
            DdlPeriodo.Items.Add(new ListItem("--Seleccione Periodo--", ""));
            DdlPeriodo.AppendDataBoundItems = true;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            SqlCommand cmd = new SqlCommand();
            try
            {
                string sql = "SELECT * FROM Periodo";
                cmd.CommandText = sql;
                cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                //cmd.Transaction = myTrans;
                dr = cmd.ExecuteReader();
                DdlPeriodo.DataSource = dr; //cmd.ExecuteReader();    
                DdlPeriodo.DataTextField = "Quincena";
                DdlPeriodo.DataValueField = "id";
                DdlPeriodo.DataBind();
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

       
        public void CargarAño()
        {
            DdlAño.Items.Clear();
            DdlAño.Items.Add(new ListItem("--Seleccione Año--", ""));
            DdlAño.AppendDataBoundItems = true;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            SqlCommand cmd = new SqlCommand();
            try
            {
                string sql = "SELECT * FROM Año";
                cmd.CommandText = sql;
                cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                //cmd.Transaction = myTrans;
                dr = cmd.ExecuteReader();
                DdlAño.DataSource = dr; //cmd.ExecuteReader();    
                DdlAño.DataTextField = "Descripcion";
                DdlAño.DataValueField = "Id";
                DdlAño.DataBind();
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

        protected void DdlAño_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Per = Convert.ToInt32(DdlPeriodo.Text);
            int Cam = 3162;
            int Cam2 = 3163;
            string Numero1= "69189107";
            string Numero2 = "69189108";
            string Numero3 = "69189109";
            string Numero4 = "69189110";
            if (Per % 2 == 0)
            {
                CargarTelefono(Convert.ToInt32(DdlPeriodo.Text), Convert.ToInt32(DdlAño.Text),Numero1);
                CargarTelefono2(Convert.ToInt32(DdlPeriodo.Text), Convert.ToInt32(DdlAño.Text),Numero2);
                CargarCamion(Cam);
            }
            else
            {
                CargarTelefono(Convert.ToInt32(DdlPeriodo.Text), Convert.ToInt32(DdlAño.Text),Numero3);
                CargarTelefono2(Convert.ToInt32(DdlPeriodo.Text), Convert.ToInt32(DdlAño.Text),Numero4);
                CargarCamion(Cam2);
            }
            try
            {
                double Rastreo = NegConciliacionCarroGuia.EncontrarNumeroRastreo(int.Parse(DDLCamionCarroGuia.Text), int.Parse(DdlPeriodo.Text), int.Parse(DdlAño.Text));
                TextBoxCalculoRastreo.Text = Convert.ToString(Rastreo);
                double Telf1 = NegConciliacionCarroGuia.EncontrarNumeroTelefono(int.Parse(DDLTelefonoCarroGuia.Text), int.Parse(DdlPeriodo.Text), int.Parse(DdlAño.Text));
                double Telf2 = NegConciliacionCarroGuia.EncontrarNumeroTelefono(int.Parse(DDLTelefonoCarroGuia2.Text), int.Parse(DdlPeriodo.Text), int.Parse(DdlAño.Text));
                double SumaTelf = Telf1 + Telf2;
                TextBoxCalculoTelefono.Text = Convert.ToString(SumaTelf);
                double d = NegConciliacionCarroGuia.PrecioCamionGuia(Convert.ToInt32(DdlPeriodo.Text), Convert.ToInt32(DdlAño.Text));
                TextBoxMontoDeposito.Text = Convert.ToString(d);
                double DiferPorc = Math.Round(d * 0.03, 2);
                TextBoxDiferenciasCarroGuia.Text = Convert.ToString(DiferPorc);
                double TotalPagable = Convert.ToDouble(TextBoxMontoDeposito.Text) - DiferPorc;
                TextBoxTotalPagable.Text = Convert.ToString(TotalPagable);
                double PagoDiffe = Convert.ToDouble(TextBoxDiferenciasCarroGuia.Text) + Convert.ToDouble(TextBoxCalculoRastreo.Text) + Convert.ToDouble(TextBoxCalculoTelefono.Text);
                TextBoxDiferenciaTotal.Text = Convert.ToString(PagoDiffe);
                double total = Convert.ToDouble(TextBoxTotalPagable.Text) - Convert.ToDouble(TextBoxCalculoRastreo.Text) -Convert.ToDouble(TextBoxCalculoTelefono.Text);
                TextBoxPagos.Text = Convert.ToString(total);
                lblError.Visible = true;
                lblError.Text = "Calculo de Carro Guia";
            }
            catch (Exception ex)
            {
                lblError.Visible=true;
                lblError.Text = "Error de Calculo";
            }
       
        }

       


        protected void DDLCamionCarroGuia_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            EntConciliacionCarroGuia CarroGuia = new EntConciliacionCarroGuia();
            if ( DdlPeriodo.Text != "" && DdlAño.Text!="")
            {
                EntConciliacionCarroGuia Repetido=new EntConciliacionCarroGuia();
                Repetido = NegConciliacionCarroGuia.EncontrarConciliacionCarroGuia(Convert.ToInt32(DdlPeriodo.Text), Convert.ToInt32(DdlAño.Text));
                if (Repetido != null)
                {
                    lblError.Text = "Esta Conciliacion Ya Ha Sido Metida En El Sistema";
                    lblError.Visible = true;
                    return;
                }
                else
                {

                    CarroGuia.it = double.Parse(TextBoxDiferenciasCarroGuia.Text);
                    CarroGuia.Telefonia = Convert.ToDouble(TextBoxCalculoTelefono.Text);
                    CarroGuia.Depositos = Convert.ToDouble(TextBoxMontoDeposito.Text);
                    CarroGuia.TotalPagable = Convert.ToDouble(TextBoxTotalPagable.Text);
                    CarroGuia.Diferencias = Convert.ToDouble(TextBoxDiferenciaTotal.Text);
                    CarroGuia.Rastreo = Convert.ToDouble(TextBoxCalculoRastreo.Text);
                    CarroGuia.Pagos = double.Parse(TextBoxPagos.Text);
                    int IdRastreo = NegConciliacionCarroGuia.EncontrarRastreo(Convert.ToInt32(DDLCamionCarroGuia.Text), Convert.ToInt32(DdlPeriodo.Text), Convert.ToInt32(DdlAño.Text));
                    CarroGuia.IdRastreo = IdRastreo;
                    CarroGuia.IdTelefono1 = int.Parse(DDLTelefonoCarroGuia.Text);
                    CarroGuia.IdTelefono2 = int.Parse(DDLTelefonoCarroGuia2.Text);
                    CarroGuia.IdPeriodo = Convert.ToInt32(DdlPeriodo.Text);
                    CarroGuia.IdAño = Convert.ToInt32(DdlAño.Text);
                    CarroGuia.IdPersona = 4443;
                    if (Request.QueryString["Id"] != null)
                    {

                    }
                    else
                    {
                        if (NegConciliacionCarroGuia.Guardar(CarroGuia) == 1)
                        {
                            lblError.Text = "Conciliaicon De Carro Guia satisfactoriamente";
                            lblError.Visible = true;
                            Response.Write("<script languaje =javascript>alert ('Detalle De Carro Guia registrada satisfactoriamente');</script>");
                            //Response.Redirect("frmRegistrarPropietarios.aspx");
                            //Cliente.Text = "";

                            TextBoxMontoDeposito.Text = "";
                            TextBoxDiferenciasCarroGuia.Text = "";
                            TextBoxCalculoRastreo.Text = "";
                            TextBoxCalculoTelefono.Text = "";
                            TextBoxDiferenciaTotal.Text = "";
                            TextBoxPagos.Text = "";
                        }
                    }
                }
            }
        }
    }
}