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
    /// Descripción breve de HandlerLiquidaciones
    /// </summary>
    public class HandlerLiquidaciones : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            EntImagenesPagadas Pag = null;
            Pag = new EntImagenesPagadas();// EntPropietario();
            Pag.IdConciliacion = Convert.ToInt32(context.Request.QueryString["Id"]);
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            cmd = new SqlCommand("ProcMostrarImgLiqui", cnx);
            cmd.Parameters.AddWithValue("@Id", Pag.IdConciliacion); //CodigoEntidad);
            //cmd.Parameters.AddWithValue("@Tipo_Imagen", 4);
            cmd.CommandType = CommandType.StoredProcedure;
            cnx.Open();

            dr = cmd.ExecuteReader();
            dr.Read();

            try
            {
                Pag.Imagen = (byte[])dr["Imagen"];
                Pag.Nombre= Convert.ToString(dr["nombre"]);

            }
            catch (Exception e)
            {
                Pag.Imagen = null;

            }


            cnx.Close();
            if (Pag.Imagen != null)//(obj != null)
            {
                context.Response.Buffer = true;
                context.Response.Charset = "";
                if (context.Request.QueryString["download"] == "1")
                {
                    context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + Pag.Nombre);
                }
                context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                context.Response.ContentType = "application/pdf";
                context.Response.BinaryWrite(Pag.Imagen);
                context.Response.Flush();
                context.Response.End();
                //context.Response.ContentType = "image/jpg";
                //context.Response.OutputStream.Write(obj.LicenciaConducir, 78, obj.LicenciaConducir.Length - 78);
                //string fileName = Ant.NombreDoc;
                //context.Response.Clear();
                //// Need to return appropriate ContentType for different type of file.
                //context.Response.ContentType = "application/pdf";
                //context.Response.AddHeader("Content-Disposition",
                //   "attachment; filename=" + fileName);
                //context.Response.AddHeader("Content-Length", Ant.Imagen.Length.ToString());
                //context.Response.Write(Ant.Imagen);
                //context.Response.End();


            }
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