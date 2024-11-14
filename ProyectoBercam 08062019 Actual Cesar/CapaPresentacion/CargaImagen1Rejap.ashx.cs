using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CapaEntidad;
using CapaDatos;
using System.Data;
using System.Data.SqlClient;
namespace CapaPresentacion
{
    /// <summary>
    /// Descripción breve de CargaImagen1
    /// </summary>
    public class CargaImagen1Rejap : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            EntPersona obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            int NC = Convert.ToInt32(context.Request.QueryString["Rejap"]);
            DAOPersona Per= new DAOPersona();
            int num = Per.valor(NC, 4);

            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            cmd = new SqlCommand("ProcImagenes", cnx);
            cmd.Parameters.AddWithValue("@Id", num); //CodigoEntidad);
            //cmd.Parameters.AddWithValue("@Tipo_Imagen", 4);
            cmd.CommandType = CommandType.StoredProcedure;
            cnx.Open();

            dr = cmd.ExecuteReader();
            obj = new EntPersona();// EntPropietario();
            dr.Read();

            try
            {
                obj.AntPenal = (byte[])dr["ImagenP"];
            }
            catch (Exception e)
            {
                obj.AntPenal = null;
            }



            if (obj.AntPenal != null)//(obj != null)
            {
                //context.Response.ContentType = "image/jpg";
                //context.Response.OutputStream.Write(obj.LicenciaConducir, 78, obj.LicenciaConducir.Length - 78);
                context.Response.BinaryWrite(obj.AntPenal);
            }

            //byte[] byteImage = (byte[])cmd.ExecuteScalar(); 31/10/2017


             
            //////if (byteImage != null)
            //////{
            //////    Response.ContentType = "image/jpg";
            //////    Response.Expires = 0;
            //////    Response.Buffer = true;
            //////    Response.Clear();
            //////    Response.BinaryWrite(byteImage);
            //////    Response.End();
            //////}
            cnx.Close();

            //string strBase64 = Convert.ToBase64String(byteImage);



            //if (byteImage != null)
            //{
            //    context.Response.ContentType = "image/jpg";
            //    context.Response.Expires = 0;
            //    context.Response.Buffer = true;
            //    context.Response.Clear();
            //    context.Response.BinaryWrite(byteImage);
            //    context.Response.End();
            //}

            //context.Response.ContentType = "image/jpeg";
            //context.Response.OutputStream.Write(byteImage, 78, byteImage.Length -78);
            //context.Response.BinaryWrite(byteImage);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}