using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidad;
using System.IO;
using CapaNegocios;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Threading;

namespace CapaPresentacion
{
    public partial class FormAdelantoDePagoImagenes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int Id = Convert.ToInt32(Request.QueryString["Id"]);
                EntImagenesAdelantoDePagos ObjImagen = new EntImagenesAdelantoDePagos();
                ObjImagen = NegImagenesAdelantoDepagos.ConsultaImagen(Id);
                if (ObjImagen != null)
                {
                    TextBoxAnticipo.Text = ObjImagen.Nombre;
                    string embed = "<object data=\"{0}{1}\" type=\"application/pdf\" width=\"500px\" height=\"600px\">";
                    embed += "If you are unable to view file, you can download from <a href = \"{0}{1}&download=1\">here</a>";
                    embed += " or download <a target = \"_blank\" href = \"http://get.adobe.com/reader/\">Adobe PDF Reader</a> to view the file.";
                    embed += "</object>";
                    ltEmbed.Text = String.Format(embed, ResolveUrl("~/AdelantosPagados.ashx?Id="), Id);
                }
            }
        }
    }
}