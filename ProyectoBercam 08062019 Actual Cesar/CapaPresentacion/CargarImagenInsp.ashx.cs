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
    /// Descripción breve de CargarImagenInsp
    /// </summary>
    public class CargarImagenInsp : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            EntInspTecnica obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            int NC = Convert.ToInt32(context.Request.QueryString["Codigo"]);
            DOACamiones Ca = new DOACamiones();
            int num = Ca.ValorInsp(NC);

            //int tipimg = Convert.ToInt32(context.Request.QueryString["TipoImg"]);

            //DOACamiones Ca = new DOACamiones();
            //int num = Ca.valor(NC, tipimg);

            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            cmd = new SqlCommand("ProcImgInsp", cnx);
            cmd.Parameters.AddWithValue("@Id", num);
            //cmd.Parameters.AddWithValue("@Cod_Ente", NC); //CodigoEntidad);
            //cmd.Parameters.AddWithValue("@Tipo_Imagen", tipimg);//1);
            cmd.CommandType = CommandType.StoredProcedure;
            cnx.Open();

            dr = cmd.ExecuteReader();
            obj = new EntInspTecnica();// EntPropietario();
            dr.Read();

            try
            {
                obj.ImgIT = (byte[])dr["ImgIt"];
            }
            catch (Exception e)
            {
                obj.ImgIT = null;
            }



            if (obj.ImgIT != null)//(obj != null)
            {
                //context.Response.ContentType = "image/jpg";
                //context.Response.OutputStream.Write(obj.LicenciaConducir, 78, obj.LicenciaConducir.Length - 78);
                context.Response.BinaryWrite(obj.ImgIT);
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