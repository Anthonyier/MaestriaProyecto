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
    public partial class FormConciliacionAsegurada : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int ConciliacionId = Convert.ToInt32(Request.QueryString["Id"]);
                CargarTabla(ConciliacionId);
                EntConciliacionPorPagar obj = null;
                obj = NegConciliacionPorPagar.BuscarConcPagar(ConciliacionId);
                TextFleteBruto.Text = Convert.ToString (obj.FleteBruto);
                TextMultaMerma.Text = Convert.ToString(obj.MultaMerma);
                TextSeguroProd.Text = Convert.ToString(obj.SeguroProducto);
                TextRespCivil.Text = Convert.ToString(obj.SeguroRespCivil);
                TextCarroGuia.Text = Convert.ToString(obj.CarroGuia);
                TextServicios.Text = Convert.ToString(obj.Servicios);
                TextAnticipos.Text = Convert.ToString(obj.Anticipos);
                TextAdelantos.Text = Convert.ToString(obj.TotalAdelantos);



            }
        }


        public DataTable GetConciliacion(int id)
        {
            DataTable dtConciliacion = new DataTable();
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            SqlDataReader dr = null;
            try
            {
                SqlCommand cmd = new SqlCommand("BuscarAsegurarConciliacion", cnx);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                dtConciliacion.Load(dr);
            }
            catch (Exception e)
            {
                dr = null;
                return dtConciliacion;
            }
            return dtConciliacion;
        }
        protected  void CargarTabla(int id)
        {
            DataTable tabla = new System.Data.DataTable();
            int Id = id;
            tabla = GetConciliacion(id); 
            GridView1.DataSource = tabla;
            GridView1.DataBind();
        }
    }
}