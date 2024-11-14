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
    public partial class FormDescargarCarroGuia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int ImagenId = Convert.ToInt32(Request.QueryString["Id"]);
                EntImagenesCarroGuia ObjImagen = new EntImagenesCarroGuia();
                ObjImagen = NegImagenesCarroGuia.ConsultaImagen(ImagenId);
                if (ObjImagen != null)
                {
                    TextPagado.Text = ObjImagen.NombreDoc;
                }

            }
        }

        protected void BtnPagado_Click(object sender, EventArgs e)
        {

            int PersonaId = Convert.ToInt32(Request.QueryString["Id"]);
            EntImagenesCarroGuia Img = new EntImagenesCarroGuia();
            Img = NegImagenesCarroGuia.Download(Convert.ToInt32(Request.QueryString["Id"]));
            if (Img == null)
            {
                lblError.Text = "No se pudo Descargar La Imagen";
                lblError.Visible = true;
                return;
            }
            byte[] Document = (byte[])Img.Imagen;
            Response.ClearContent();
            Response.ContentType = "application/octetstream";
            Response.AddHeader("Content-Disposition", string.Format("attachment;filenames={0}", Img.NombreDoc));
            Response.AddHeader("Content-Length", Document.Length.ToString());
            Response.BinaryWrite(Document);
            Response.Flush();
            Response.Close();
        }
    }
}