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
    /// Descripción breve de CargarImagenRuat
    /// </summary>
    public class CargarImagenRuat : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            EntDetalle_Certificados obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            int NC = Convert.ToInt32(context.Request.QueryString["Codigo"]);


            int tipimg = Convert.ToInt32(context.Request.QueryString["TipoImg"]);

            DOACamiones Ca = new DOACamiones();
            int num = Ca.valor(NC, tipimg);

            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            cmd = new SqlCommand("ProcImgCert", cnx);
            cmd.Parameters.AddWithValue("@Id", num);
            //cmd.Parameters.AddWithValue("@Cod_Ente", NC); //CodigoEntidad);
            //cmd.Parameters.AddWithValue("@Tipo_Imagen", tipimg);//1);
            cmd.CommandType = CommandType.StoredProcedure;
            cnx.Open();

            dr = cmd.ExecuteReader();
            obj = new EntDetalle_Certificados();// EntPropietario();
            dr.Read();

            try
            {
                obj.Imagen = (byte[])dr["Imagen"];
            }
            catch (Exception e)
            {
                obj.Imagen = null;
            }



            if (obj.Imagen != null)//(obj != null)
            {
                //context.Response.ContentType = "image/jpg";
                //context.Response.OutputStream.Write(obj.LicenciaConducir, 78, obj.LicenciaConducir.Length - 78);
                context.Response.BinaryWrite(obj.Imagen);
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