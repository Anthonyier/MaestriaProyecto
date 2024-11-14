using CapaDatos;
using CapaNegocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class FormListaAsignacionCamiones : System.Web.UI.Page
    {
        public string ListClientes3 = "";
        public string ListPlantas = "";
        int IdPersona = 9;

        protected void Page_Load(object sender, EventArgs e)
        {
             if (!IsPostBack)
            {
                Ruta.AppendDataBoundItems = true;
                CargarCombo();
                //CargarCliente();
                CargarAsignacion();
                string queryString = "SELECT * FROM vi_Cliente  ORDER BY Cliente";

                using (SqlConnection connection = new SqlConnection(Properties.Resources.ConexionBercamPrin)) //ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString))
                {

                    using (SqlCommand command = new SqlCommand(queryString, connection))
                    {

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {

                                if (string.IsNullOrEmpty(ListClientes3))
                                {
                                    ListClientes3 += "\"" + reader["CLIENTE"].ToString() + "\"";
                                    //ListClientes += "\"" + reader["CLIENTE"].ToString() + "\"" + reader["CI"].ToString() + "\"";//"\"" + reader["CLIENTE"].ToString() + "\"";
                                }
                                else
                                {
                                    ListClientes3 += ", \"" + reader["CLIENTE"].ToString() + "\"";
                                    //ListClientes += ", \"" + reader["CLIENTE"].ToString() + "\"" + reader["CI"].ToString() + "\"";//"\"" + reader["CLIENTE"].ToString() + "\"";
                                }

                            }
                        }
                        connection.Close();
                    }

                }
            }
        }

        public void CargarPlantas()
        {
            string queryString = "SELECT * FROM Planta ORDER BY Descripcion";

                using (SqlConnection connection = new SqlConnection(Properties.Resources.ConexionBercamPrin))
                {
                    using (SqlCommand command = new SqlCommand(queryString, connection))
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                if (string.IsNullOrEmpty(ListPlantas))
                                {
                                    ListPlantas += "\"" + reader["Descripcion"].ToString() + "\"";
                                }
                                else
                                {
                                    ListPlantas += ", \"" + reader["Descripcion"].ToString() + "\"";
                                }
                            }
                        }
                        connection.Close();
                    }
                }
        }
        public void CargarAsignacion()
        {
            //Placa.Items.Clear();
            //Placa.Items.Add(new ListItem("--Selecciona una Placa--", ""));
            //Placa.AppendDataBoundItems = true;
            //SqlCommand cmd = new SqlCommand();
            //ClaseConexion Conexion = new ClaseConexion();
            //SqlConnection cnx = Conexion.conectar();

            //try
            //{

            //    //String sql = "Select Id_Ruta, Ruta, MontoAnticipo,Producto.Descripcion From Ruta,Producto where Ruta.Id_Producto=Producto.Id_Producto and Ruta.Id_Cliente=Persona.Id_Persona And Ruta.Id_Cliente";
            //    cmd = new SqlCommand("ProcAsig", cnx);
            //    cmd.Parameters.AddWithValue("@IdCliente", IdPersona);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    //cmd.CommandType = CommandType.Text;
            //    //cmd.CommandText = sql;
            //    //cmd.Connection = cnx;
            //    SqlDataReader dr = null;
            //    cnx.Open();
            //    //cmd.Transaction = myTrans;
            //    dr = cmd.ExecuteReader();
            //    Placa.DataSource = dr; //cmd.ExecuteReader();    
            //    Placa.DataTextField = "Placa";
            //    Placa.DataValueField = "Placa";
            //    Placa.DataBind();
            //    dr.Close();
            //}
            //catch (Exception ex)
            //{
            //    Placa.Text = "No se encontro camion asignado";
            //}
            //finally
            //{
            //    cmd.Connection.Close();
            //    cmd.Connection.Dispose();
            //}

        }
        protected void BtnBuscarNit_Click(object sender, EventArgs e)
        {
            int turn=2;
            if(chkActivo.Checked && chkInactivo.Checked==false ){
                turn = 0;
                SqlDataReader c = NegAsignacionCamion.Cantidad(turn,TextCliAsig.Text);
                c.Read();
                if (c.HasRows == true)
                {
                    lblCamiones.Text = c["Cantidad"].ToString();//.ToString();
                }
            }
            if (chkInactivo.Checked && chkActivo.Checked == false)
            {
                turn = 1;
                SqlDataReader c = NegAsignacionCamion.Cantidad(turn, TextCliAsig.Text);
                c.Read();
                if (c.HasRows == true)
                {
                    lblCamiones.Text = c["Cantidad"].ToString();//.ToString();
                }
            }

            if (turn != 2)
            {
                string queryString = "SELECT * FROM vi_ListaAsignacionPlacaPorCliente where Cliente = " + "'" + TextCliAsig.Text + "'" +" and Est = "+"'"+turn+"'"+" ORDER BY Placa";

                using (SqlConnection connection = new SqlConnection(Properties.Resources.ConexionBercamPrin))
                {
                    using (SqlCommand command = new SqlCommand(queryString, connection))
                    {
                        connection.Open();
                        SqlDataAdapter adap = new SqlDataAdapter(command);
                        DataTable dta = new DataTable();
                        adap.Fill(dta);
                        GridViewCamiones.DataSource = dta;
                        GridViewCamiones.DataBind();

                        connection.Close();
                    }
                }
            }

        }
        protected void Calendar_VigenciaOnSelectionChanged(object sender, EventArgs e)
        {
            if (CalendarVigencia.SelectedDate != null)
            {
                TextVigencia.Text = CalendarVigencia.SelectedDate.ToString("d");
                CalendarVigencia.Visible = false;
            }
        }
        protected void imgCalendarVigencia_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarVigencia.Visible)
            {
                CalendarVigencia.Visible = false;
            }
            else
            {
                CalendarVigencia.Visible = true;
            }
        }
        public void CargarCombo()
        {
            Ruta.Items.Clear();
            Ruta.Items.Add(new ListItem("--Selecciona una RUTA--", ""));
            Ruta.AppendDataBoundItems = true;
            SqlCommand cmd = new SqlCommand();
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {

                //String sql = "Select Id_Ruta, Ruta, MontoAnticipo,Producto.Descripcion From Ruta,Producto where Ruta.Id_Producto=Producto.Id_Producto and Ruta.Id_Cliente=Persona.Id_Persona And Ruta.Id_Cliente";
                cmd = new SqlCommand("ProcBuscarCliente", cnx);
                cmd.Parameters.AddWithValue("@IdPersona", IdPersona);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandType = CommandType.Text;
                //cmd.CommandText = sql;
                //cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                //cmd.Transaction = myTrans;
                dr = cmd.ExecuteReader();
                Ruta.DataSource = dr; //cmd.ExecuteReader();    
                Ruta.DataTextField = "Ruta";
                Ruta.DataValueField = "Id_Ruta";
                Ruta.DataBind();
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
        protected void Ruta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Ruta.Text != "")
            {
                SqlDataReader d = NegAsignacionRuta.BuscarRuta(Ruta.Text);
                //SqlDataReader r = NegAsignacionRuta.BuscarMonto(Ruta.Text);
                d.Read();
                //r.Read();
                if (d.HasRows == true) //&& r.HasRows==true)
                {
                    if (d != null)// && r!= null)
                    {
                        try
                        {
                            //TextProd.Text = d["Descripcion"].ToString();
                            TextAnticipo.Text = d["MontoAnticipo"].ToString();
                            TextOrigen.Text = d["Origen"].ToString();
                            TextUbicacion.Text = d["Destino"].ToString();
                        }
                        catch (Exception er)
                        {

                            //TextProd.Text = "";
                            TextAnticipo.Text = "";
                        }
                        finally
                        {

                        }
                    }
                    else
                    {
                        //TextProd.Text = "";
                    }
                }
                else
                {

                    //TextProd.Text = "";
                }
            }
            else
            {
                //TextProd.Text = "";
            }
        }
        protected void TextCliAsig_TextChanged(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }
            SqlDataReader d = NegPersona.BuscarPersona(TextCliAsig.Text);
            d.Read();
            if (d.HasRows == true)
            {
                if (d != null)
                {
                    try
                    {
                        IdPersona = int.Parse(d["Id_Persona"].ToString());
                        CargarCombo();
                        CargarAsignacion();
                    }
                    catch (Exception er)
                    {


                    }
                }
            }
        }

        private void GuardarPlanta()
        {

        }
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            GuardarPlanta();
        }

        protected void BtnRegNomina_Click(object sender, EventArgs e)
        {

        }

        public void GridViewCamiones_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            string queryString = "SELECT * FROM vi_ListaAsignacionPlacaPorCliente where Cliente = " + "'" + TextCliAsig.Text + "'" + " ORDER BY Placa";

            using (SqlConnection connection = new SqlConnection(Properties.Resources.ConexionBercamPrin))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    SqlDataAdapter adap = new SqlDataAdapter(command);
                    DataTable dta = new DataTable();
                    adap.Fill(dta);
                    GridViewCamiones.DataSource = dta;
                    GridViewCamiones.PageIndex = e.NewPageIndex;
                    GridViewCamiones.DataBind();

                    connection.Close();
                }
            }
            
        }

        protected void chkActivo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkInactivo.Checked == true)
            {
                chkInactivo.Checked = !chkInactivo.Checked;
            }
        }

        protected void chkInactivo_CheckedChanged(object sender, EventArgs e)
        {
            if(chkActivo.Checked==true)
             {
            chkActivo.Checked = !chkActivo.Checked;
            }
        }
    }
}