using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocios;
using CapaEntidad;
using System.Data;
using System.Data.SqlClient;

namespace CapaPresentacion
{
    public partial class FormEnlazarUsuZkTeko : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public static int ObtenerPersona(string NombreUsu)
        {
            SqlDataReader dr = NegPersona.BuscarPersona(NombreUsu);
            int IdPersona = 0;
            dr.Read();
            if (dr.HasRows == true)
            {
                if (dr != null)
                {
                    try
                    {
                        IdPersona = int.Parse(dr["Id_Persona"].ToString());
                        return IdPersona;
                    }
                    catch (Exception E)
                    {
                        return 0;
                    }
                }
            }
            return IdPersona;
        }
        protected void ButtonZkUsuario_Click(object sender, EventArgs e)
        {
            EntPersonaZkTeko PerZk = new EntPersonaZkTeko();
            PerZk.IdPersona = ObtenerPersona(TextUsuarioZkteko.Text);
            PerZk.IdZkteko = int.Parse(TextNumeroZkTeko.Text);
            if (Request.QueryString["Id"] != null)
            {

            }
            else
            {
                if (NegZkteko.Insertar(PerZk) == 1)
                {
                    TextUsuarioZkteko.Text = "";
                    TextNumeroZkTeko.Text = "";
                }
            }

        }
    }
}