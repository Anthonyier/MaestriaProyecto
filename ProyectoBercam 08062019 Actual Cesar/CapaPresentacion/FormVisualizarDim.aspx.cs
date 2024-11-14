using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace CapaPresentacion
{
    public partial class FormVisualizarDim : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] != null)
                {
                    int IdDim=Convert.ToInt32(Request.QueryString["Id"]);
                    TextIdDim.Text = Convert.ToString(IdDim);

                }
            }
        }
        protected void DtgGridViewListDim_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            if (e.CommandName == "EditarDetDim")
            {
                string Id = e.CommandArgument.ToString();
                Response.Redirect("FormModificarDetalleDim.aspx?Id=" + Id);
            }
        }
        protected void ButtonAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormCreacionDim.aspx");
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                Label LblVolumenMic = (GridView2.Rows[i].Cells[0].FindControl("Label8") as Label);
                double VolumenMic = Convert.ToDouble(LblVolumenMic.Text);
                Label LblPesoMic = (GridView2.Rows[i].Cells[0].FindControl("Label9") as Label);
                double PesoMic = Convert.ToDouble(LblPesoMic.Text);

                Label LblVolumenPRM = (GridView2.Rows[i].Cells[0].FindControl("Label12") as Label);
                double VolumenPRM = Convert.ToDouble(LblVolumenPRM.Text);
                Label LblPesoPRM = (GridView2.Rows[i].Cells[0].FindControl("Label13") as Label);
                double PesoPRM = Convert.ToDouble(LblPesoPRM.Text);

                double VolTotal = VolumenMic - VolumenPRM;
                double PesoTotal = PesoMic - PesoPRM;

                if (VolTotal != 0 && PesoTotal != 0)
                {
                    GridView2.Rows[i].BackColor = Color.Red;
                }
            }
        }
    }
}