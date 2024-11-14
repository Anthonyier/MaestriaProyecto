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
    /// Descripción breve de CargarImagenSoat1
    /// </summary>
    public class CargarImagenSoat1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            EntSoat obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            int NC = Convert.ToInt32(context.Request.QueryString["Codigo"]);
            DOACamiones Ca = new DOACamiones();
            int num = Ca.ValorSoat(NC);

            //int tipimg = Convert.ToInt32(context.Request.QueryString["TipoImg"]);

            //DOACamiones Ca = new DOACamiones();
            //int num = Ca.valor(NC, tipimg);

            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            cmd = new SqlCommand("ProcImgSoat", cnx);
            cmd.Parameters.AddWithValue("@Id", num);
            //cmd.Parameters.AddWithValue("@Cod_Ente", NC); //CodigoEntidad);
            //cmd.Parameters.AddWithValue("@Tipo_Imagen", tipimg);//1);
            cmd.CommandType = CommandType.StoredProcedure;
            cnx.Open();

            dr = cmd.ExecuteReader();
            obj = new EntSoat();// EntPropietario();
            dr.Read();

            try
            {
                obj.ImgSoat = (byte[])dr["ImgSoat"];
            }
            catch (Exception e)
            {
                obj.ImgSoat = null;
            }



            if (obj.ImgSoat != null)//(obj != null)
            {
                //context.Response.ContentType = "image/jpg";
                //context.Response.OutputStream.Write(obj.LicenciaConducir, 78, obj.LicenciaConducir.Length - 78);
                context.Response.BinaryWrite(obj.ImgSoat);
            }


            cnx.Close();
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