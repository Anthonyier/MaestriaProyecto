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
using System.IO;
using CapaDatos;

namespace CapaPresentacion
{
    public partial class ConciliacionPorCobrar : System.Web.UI.Page
    {
        private static DataTable dtRutas = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarRutas();
                CargarGrilla(10);
            }


            if (Request.QueryString["Id"] != null)
            {

                int RecepcionId = Convert.ToInt32(Request.QueryString["Id"]);
                TextRecepcion.Text = Convert.ToString(RecepcionId);
                EntConciliacionPorCobrar objConciliacion = new EntConciliacionPorCobrar();
                EntConciliacionPorCobrar obj = new EntConciliacionPorCobrar();
                obj = NegConciliacionPorCobrar.BuscarManual(RecepcionId);
                objConciliacion = NegConciliacionPorCobrar.BuscarConciliacion(RecepcionId); //haber
                TextCliente.Text = objConciliacion.Cliente;//aqui el error del 13-09-17
                TextRuta.Text = objConciliacion.Ruta;
                TextRecepcionManual.Text = Convert.ToString(obj.recepcionManual);
                TextProducto.Text = objConciliacion.Producto;
                cargar(RecepcionId);
                CargarGrillaMain(RecepcionId, 20);


            }
        }

        public void CargarRutas()
        {
            SqlCommand cmd = new SqlCommand();
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {
                cmd = new SqlCommand("BuscarRutas", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = null;
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();

                dtRutas = new DataTable();
                dtRutas.Load(dr);
                //dr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnx.Close();// cmd.Connection.Close();
                cnx.Dispose();// cmd.Connection.Dispose();
            }



            //////////SqlDataReader dr = NegConciliacionPorCobrar.BuscarRutas();
            ////////try
            ////////{
            ////////    cnx = Conexion.conectar();
            ////////    cmd = new SqlCommand("BuscarRutas", cnx);
            ////////    cmd.CommandType = CommandType.StoredProcedure;
            ////////    SqlDataReader drA = null;
            ////////    cnx.Open();
            ////////    drA = cmd.ExecuteReader();
            ////////    drA.Read();


            ////////    //dr.Close();
            ////////}
            ////////catch (Exception ex)
            ////////{
            ////////    throw ex;
            ////////}
            ////////finally
            ////////{
            ////////    cnx.Close();// cmd.Connection.Close();
            ////////    cnx.Dispose();// cmd.Connection.Dispose();
            ////////}

        }
        //}
        public void CargarGrilla(int Cantidad)
        {
            //List<EntDetalleConciliacionPorCobrar> lista = new List<EntDetalleConciliacionPorCobrar>();
            List<EntDetalleConciliacionPorCobrar> lista = new List<EntDetalleConciliacionPorCobrar>();
            for (int i = 0; i < Cantidad; i++)
            {
                EntDetalleConciliacionPorCobrar conciliacion = new EntDetalleConciliacionPorCobrar();

                lista.Add(conciliacion);
            }
            GridDetalleConciliacion.AutoGenerateColumns = false;
            GridDetalleConciliacion.DataSource = lista;
            GridDetalleConciliacion.DataBind();
        }

        public void CargarGrillaMain(int Id_Re, int Cantidad)
        {
            ////////List<EntDetalleConciliacionPorCobrar> lista = new List<EntDetalleConciliacionPorCobrar>();
            SqlCommand cmd = null;
            SqlDataAdapter sda = new SqlDataAdapter();
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {

                cmd = new SqlCommand("[SeleccionDetalleConciliacion]", cnx);
                cmd.Parameters.AddWithValue("@Id_Re", Id_Re);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnx;
                sda.SelectCommand = cmd;
                cnx.Open();
                ///////SqlDataReader lector = cmd.ExecuteReader(); //new SqlDataReader();
                /////////int i = 0;
                DataTable dt = new DataTable();
                sda.Fill(dt);


                ///// GridDetalleConciliacion.AutoGenerateColumns = false;
                GridDetalleConciliacion.DataSource = dt;////lista;
                GridDetalleConciliacion.DataBind();

                //while (lector.Read())
                //{

                //    EntDetalleConciliacionPorCobrar Conciliacion = new EntDetalleConciliacionPorCobrar();
                //    Conciliacion.Placa = lector[0].ToString();
                //    Conciliacion.Conductor = lector[3].ToString();
                //    Conciliacion.FechaCarga = Convert.ToDateTime(lector[1].ToString());
                //    Conciliacion.FechaDescarga = Convert.ToDateTime(lector[2].ToString());
                //    lista.Add(Conciliacion);
                //}
            }
            catch (Exception e)
            {

            }
            //for (int i = 0; i < Cantidad; i++)
            //{
            //    EntDetalleConciliacionPorCobrar conciliacion = new EntDetalleConciliacionPorCobrar();

            //    lista.Add(conciliacion);
            //}
        }
        public void cargar(int Id_Re)
        {
            SqlCommand cmd = null;
            SqlDataAdapter sda = new SqlDataAdapter();

            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {

                cmd = new SqlCommand("[SelecionDetalle]", cnx);
                cmd.Parameters.AddWithValue("@Id_Re", Id_Re);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnx;
                sda.SelectCommand = cmd;
                cnx.Open();
                DataTable dt = new DataTable();
                sda.Fill(dt);


                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            catch (Exception e)
            {

            }
        }

        protected void GridDetalleConciliacion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //SqlCommand cmd = null;
                //SqlDataAdapter sda = new SqlDataAdapter();



                //ClaseConexion cn = new ClaseConexion();
                //SqlConnection cnx = cn.conectar();


                //    cmd = new SqlCommand("[SeleccionDetalleConciliacion]", cnx);
                //    cmd.Parameters.AddWithValue("@Id_Re", 7);
                //    cmd.CommandType = CommandType.StoredProcedure;
                //    cmd.Connection = cnx;
                //    cnx.Open();
                //    SqlDataReader lector = cmd.ExecuteReader(); //new SqlDataReader();
                //    int i = 0;

                //((TextBox)e.Row.FindControl("txtPlaca")).Text = lector[0].ToString();

                ((DropDownList)e.Row.FindControl("cmbPlantaOrigen")).DataValueField = "Id_Ruta";
                ((DropDownList)e.Row.FindControl("cmbPlantaOrigen")).DataTextField = "Ruta";
                ((DropDownList)e.Row.FindControl("cmbPlantaOrigen")).DataSource = dtRutas;

                ((DropDownList)e.Row.FindControl("cmbPlantaOrigen")).DataBind();

                ((DropDownList)e.Row.FindControl("cmbPlantaDestino")).DataTextField = "Ruta";
                ((DropDownList)e.Row.FindControl("cmbPlantaDestino")).DataValueField = "Id_Ruta";
                ((DropDownList)e.Row.FindControl("cmbPlantaDestino")).DataSource = dtRutas;
                ((DropDownList)e.Row.FindControl("cmbPlantaDestino")).DataBind();

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}