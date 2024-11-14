using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using CapaEntidad;
using CapaDatos;
using CapaNegocios;

namespace CapaPresentacion
{
    public partial class FormCuenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetTreeViews();
            }
        }

        private void GetTreeViews()
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            SqlDataReader dr = null;
              try{
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                SqlDataAdapter da = new SqlDataAdapter("TreeCuenta",cnx);
                DataSet ds = new DataSet();
                da.Fill(ds);
                ds.Relations.Add("ChildRows", ds.Tables[0].Columns["Id"], ds.Tables[0].Columns["IdPadre"]);
                foreach (DataRow Level1DataRow in ds.Tables[0].Rows)
                {
                    if (string.IsNullOrEmpty(Level1DataRow["IdPadre"].ToString()))
                    {
                        TreeNode parentTreeNode = new TreeNode();
                        parentTreeNode.Text = Level1DataRow["NombredelaAccion"].ToString();
                        String Id = Level1DataRow["Id"].ToString();
                        parentTreeNode.NavigateUrl = "FormCuentaContable.aspx?Id="+Id;

                        GetChildRows(Level1DataRow,parentTreeNode);
                        Treeview1.Nodes.Add(parentTreeNode);
                    }
                }
              }catch(Exception e){
                  
              }
        }

        private void GetChildRows(DataRow dataRow, TreeNode treeNode)
        {
            DataRow[] childRows = dataRow.GetChildRows("ChildRows");
            foreach(DataRow childRow in childRows)
            {
                TreeNode childTreeNode = new TreeNode();
                childTreeNode.Text = childRow["NombredelaAccion"].ToString();
                String Id = childRow["Id"].ToString();
                childTreeNode.NavigateUrl = "FormCuentaContable.aspx?Id="+Id;
                treeNode.ChildNodes.Add(childTreeNode);
                if (childRow.GetChildRows("ChildRows").Length > 0)
                {
                    GetChildRows(childRow, childTreeNode);
                }
            }

        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (TxtBuscar.Text != "")
            {
                SqlDataReader d = NegCuentaContable.BuscarNombre(TxtBuscar.Text);
                d.Read();
                if (d.HasRows == true)
                {
                    if (d != null)
                    {
                        try
                        {
                            TxtBuscar.Text = d["Id"].ToString();
                            Response.Redirect("FormModCuenta.aspx?Id=" + TxtBuscar.Text);
                        }
                        catch (Exception er)
                        {

                            TxtBuscar.Text = "No se encontro registro de cuenta, Registrelo e intente nuevamente";
                        }
                        finally
                        {

                        }
                    }
                    else
                    {

                        TxtBuscar.Text = "No se encontro registro de cuenta, Registrelo e intente nuevamente";
                    }
                }
                else
                {

                    TxtBuscar.Text = "No se encontro registro de cuenta, Registrelo e intente nuevamente";
                }
            }
            else
            {

                TxtBuscar.Text = "No se encontro registro de cuenta, Registrelo e intente nuevamente";
            }
        }
    }
}