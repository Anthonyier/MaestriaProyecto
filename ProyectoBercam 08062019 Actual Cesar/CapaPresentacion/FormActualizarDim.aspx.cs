using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CapaDatos;
using System.Data.SqlClient;
using CapaNegocios;
using CapaEntidad;
using System.Drawing;

namespace CapaPresentacion
{
    public partial class FormActualizarDim : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDim();
            }
             EntUsuario usuario = (EntUsuario)Session["Usuario"];
            EntPermisoRutas PerRutas = NegPermisoRutas.BuscarPermiso(usuario.Id_Usuario);
            if (PerRutas.Dim != 1)
            {
                GridView1.Visible = false;
                GridView1.Enabled = false;
                Button1.Visible = false;
                Button1.Enabled = false;
            }
        }
        public void CargarDim()
        {
            DdlDim.Items.Clear();
            DdlDim.Items.Add(new ListItem("--Seleccione Un Dim--", ""));
            DdlDim.AppendDataBoundItems = true;
            SqlCommand cmd = new SqlCommand();
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {
                cmd = new SqlCommand("ProcListaDimNoCerrados", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandType = CommandType.Text;
                //cmd.CommandText = sql;
                //cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                //cmd.Transaction = myTrans;
                dr = cmd.ExecuteReader();
                DdlDim.DataSource = dr; //cmd.ExecuteReader();    
                DdlDim.DataTextField = "Dim";
                DdlDim.DataValueField = "Id";
                DdlDim.DataBind();
                dr.Close();
            }
            catch (Exception e)
            {

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Panel2.Visible = true;
            Panel1.Visible = false;
            TexboxDim.Text = DdlDim.Text;

            DataTable dt = new DataTable();
            dt.Columns.Add("Id_Detalle");
            dt.Columns.Add("FechaCarga");
            dt.Columns.Add("Placa_Camion");
            dt.Columns.Add("NoCrt");
            dt.Columns.Add("VolumenCrt");
            dt.Columns.Add("PesoCrt");
            dt.Columns.Add("VolumenMic");
            dt.Columns.Add("PesoMic");
            dt.Columns.Add("NoMic");

            foreach (GridViewRow Rows in GridView1.Rows)
            {
                var CheckBox = Rows.FindControl("Input") as CheckBox;
                if (CheckBox.Checked)
                {
                    string Id_Detalle = (Rows.FindControl("Label1") as Label).Text;
                    string FechaCarga = (Rows.FindControl("Label2") as Label).Text;
                    string Placa_Camion = (Rows.FindControl("Label3") as Label).Text;
                    string NoCrt = (Rows.FindControl("Label4") as Label).Text;
                    string VolumenCrt = (Rows.FindControl("Label5") as Label).Text;
                    string PesoCrt = (Rows.FindControl("Label6") as Label).Text;
                    string VolumenMic = (Rows.FindControl("Label7") as Label).Text;
                    string PesoMic = (Rows.FindControl("Label8") as Label).Text;
                    string NoMic = (Rows.FindControl("Label9") as Label).Text;
                    dt.Rows.Add(Id_Detalle, FechaCarga, Placa_Camion, NoCrt, VolumenCrt, PesoCrt, VolumenMic, PesoMic, NoMic);
                }
                GridView2.DataSource = dt;
                GridView2.DataBind();
            }
            RellenarPrm();
        }
        protected void RellenarPrm()
        {
            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                Label LabelIdDetalle = (GridView2.Rows[i].Cells[0].FindControl("Label1") as Label);
                int IdDetalle = Convert.ToInt32(LabelIdDetalle.Text);
                EntFrontera Fronter = NegFrontera.BuscarFrontera(IdDetalle);
                string NoPrm = Fronter.NroPrm;
                string NoDim = Convert.ToString(Fronter.NroDim);
                this.GridView2.Rows[i].Cells[10].Text = NoPrm + "-" + NoDim + "-";
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Panel2.Visible = false;
            Panel1.Visible = true;

            GridView2.DataSource = null;
            GridView2.DataBind();
        }

        protected void ButtonGuardar_Click(object sender, EventArgs e)
        {
            string Resultado = "";
            bool verif = DatosCorrectos();
            List<EntDetalleDim> Lista = new List<EntDetalleDim>();
            int IdDim=Convert.ToInt32(TexboxDim.Text);
            if (verif == true)
            {
                for (int i = 0; i < GridView2.Rows.Count; i++)
                {
                    Label labelIdDetalle = (GridView2.Rows[i].Cells[0].FindControl("Label1") as Label);
                    int IdDetalle = Convert.ToInt32(labelIdDetalle.Text);
                    TextBox TextFechaPrm = (GridView2.Rows[i].Cells[0].FindControl("FechaPrm") as TextBox);
                    DateTime FechaPrm = Convert.ToDateTime(TextFechaPrm.Text);
                    TextBox TextPrmNro=(GridView2.Rows[i].Cells[0].FindControl("TextPRM") as TextBox);
                    //Label  Text2PrmNro = (GridView2.Rows[i].Cells[0].FindControl("TextFormatPRM") as Label);
                    string PrmNro1 = this.GridView2.Rows[i].Cells[10].Text;
                    string PrmNro2 = TextPrmNro.Text;
                    string PrmNro = PrmNro1 + PrmNro2;
                    TextBox TextVolumenPRM = (GridView2.Rows[i].Cells[0].FindControl("TextVolumenPRM") as TextBox);
                    double VolumenPRM = Convert.ToDouble(TextVolumenPRM.Text);
                    TextBox TextPesoPRM = (GridView2.Rows[i].Cells[0].FindControl("TextPesoPRM") as TextBox);
                    double PesoPRM = Convert.ToDouble(TextPesoPRM.Text);
                    EntDetalleDim DetDim = new EntDetalleDim();
                    DetDim.IdDetalle = IdDetalle;
                    DetDim.FechaPRM = FechaPrm;
                    DetDim.PRMno = PrmNro;
                    DetDim.VolumenPRM = VolumenPRM;
                    DetDim.PesoPRM = PesoPRM;
                    Lista.Add(DetDim);

                }
                Resultado = NegDetalleDim.insertAddDetalleDim(Lista, IdDim);
                if (Resultado == "OK")
                {
                    Response.Write("<script languaje=javaScript>alert('Registro de Detalle de Dim creado satisfactoriamente');</script>");
                    Response.Redirect("FormActualizarDim.aspx");
                }
            }
        }
        protected bool DatosCorrectos()
        {
            bool Ver = true;
            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                TextBox TextFechaPrm = (GridView2.Rows[i].FindControl("FechaPRM") as TextBox);
                DateTime FechaPrm = Convert.ToDateTime(TextFechaPrm.Text);
                TextBox TextPrmNo = (GridView2.Rows[i].FindControl("TextPRM") as TextBox);
                string PrmNo = TextPrmNo.Text;
                if (FechaPrm == null || PrmNo == "")
                {
                    Ver = false;
                    return Ver;
                }
            }
            return Ver;
        }

        protected void ButtonComprar_Click(object sender, EventArgs e)
        {
            int ContVerif = 0;
            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                Label LblVolumenMic = (GridView2.Rows[i].Cells[0].FindControl("Label7") as Label);
                double VolumenMic = Convert.ToDouble(LblVolumenMic.Text);
                Label LblPesoMic = (GridView2.Rows[i].Cells[0].FindControl("Label8") as Label);
                double PesoMic = Convert.ToDouble(LblPesoMic.Text);
                TextBox TextVolumenPrm = (GridView2.Rows[i].Cells[0].FindControl("TextVolumenPRM") as TextBox);
                double VolumenPrm = Convert.ToDouble(TextVolumenPrm.Text);
                TextBox TextPesoPrm = (GridView2.Rows[i].Cells[0].FindControl("TextPesoPRM") as TextBox);
                double PesoPrm = Convert.ToDouble(TextPesoPrm.Text);
                double TotalVol = VolumenMic - VolumenPrm;
                this.GridView2.Rows[i].Cells[14].Text = Convert.ToString(TotalVol);
                double TotalPeso = PesoMic - PesoPrm;
                this.GridView2.Rows[i].Cells[15].Text = Convert.ToString(TotalPeso);
                if (TotalPeso != 0 || TotalVol != 0)
                {
                    GridView2.Rows[i].BackColor = Color.Red;
                    //Response.Write("<script languaje=javaScript>alert('El MIC y el PRM No Coinciden,Verifique Porfavor.');</script>");
                    ContVerif++;
                }
                else
                {
                    if (TotalPeso == 0 && TotalVol == 0)
                    {
                        GridView2.Rows[i].BackColor = Color.Green;
                    }
                }
                if (ContVerif != 0)
                {
                    Label1.Visible = true;
                    string Aviso = "El Mic y el PRM No Coinciden, Verifiquen Por Favor, en Total Son :" + Convert.ToString(ContVerif);
                    Label1.Text = Aviso;

                }
                else
                {
                    Label1.Visible = false;
                }
            }
        }
    }
}