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
    public partial class FormHorarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarUsuario();
            }
        }
        public void CargarUsuario()
        {
            ddlUsuario.Items.Clear();
            ddlUsuario.Items.Add(new ListItem("--Seleccione el Usuario--", ""));
            ddlUsuario.AppendDataBoundItems = true;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            SqlCommand cmd = new SqlCommand();
            try
            {
                string sql = "SELECT * FROM Vi_Usuario";
                cmd.CommandText = sql;
                cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                //cmd.Transaction = myTrans;
                dr = cmd.ExecuteReader();
                ddlUsuario.DataSource = dr; //cmd.ExecuteReader();    
                ddlUsuario.DataTextField = "NombreUsuario";
                ddlUsuario.DataValueField = "Id_Persona";
                ddlUsuario.DataBind();
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

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (TextEntraMaña.Text != "" && TextSalMaña.Text != "" && TextEntraTarde.Text != "" && TextSalTarde.Text != "")
            {
                EntHorario Hor = new EntHorario();
                string EntMa=TextEntraMaña.Text;
                string SalMa=TextSalMaña.Text;
                Hor.HoraEntrada = EntMa;
                Hor.HoraSalida = SalMa;
                Hor.IdTipoHorario = 1;
                double hourEntMan= TimeSpan.Parse(EntMa).TotalHours;
                double hourSalMan = TimeSpan.Parse(SalMa).TotalHours;
                double HourManTo = hourSalMan - hourEntMan;
                Hor.TotalHoras = TimeSpan.FromHours(HourManTo).ToString();
                EntHorario Hor2 = new EntHorario();
                string EntTard = TextEntraTarde.Text;
                string SalTard = TextSalTarde.Text;
                Hor2.HoraEntrada = EntTard;
                Hor2.HoraSalida = SalTard;
                Hor.IdTipoHorario = 2;
                double hourEntTar = TimeSpan.Parse(EntTard).TotalHours;
                double hourSalTar = TimeSpan.Parse(SalTard).TotalHours;
                double HourTarTo = hourSalTar - hourEntTar;
                Hor2.TotalHoras = TimeSpan.FromHours(HourTarTo).ToString();
                int IdUsu = Convert.ToInt32(ddlUsuario.Text);
                NegHorario.InsertarHorario(Hor,Hor2,IdUsu);
                TextTotMaña.Text = Convert.ToString(TimeSpan.FromHours(HourManTo).ToString());
                TextTotTarde.Text = Convert.ToString(TimeSpan.FromHours(HourTarTo).ToString());
                lblError.Text = "Horarios Metidos Satisfactoriamente";
                lblError.Visible = true;     
            }
        }

        protected void TextEntraMaña_TextChanged(object sender, EventArgs e)
        {

        }
    }
}