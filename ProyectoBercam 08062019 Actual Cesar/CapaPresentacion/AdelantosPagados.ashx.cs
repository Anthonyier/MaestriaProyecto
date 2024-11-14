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
    /// Descripción breve de AdelantosPagados
    /// </summary>
    public class AdelantosPagados : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            EntImagenesAdelantoDePagos Adel = null;
            Adel = new EntImagenesAdelantoDePagos();// EntPropietario();
            Adel.IdAdelanto = Convert.ToInt32(context.Request.QueryString["Id"]);
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            cmd = new SqlCommand("ProcMostrarImgAdelanto", cnx);
            cmd.Parameters.AddWithValue("@Id", Adel.IdAdelanto); //CodigoEntidad);
            //cmd.Parameters.AddWithValue("@Tipo_Imagen", 4);
            cmd.CommandType = CommandType.StoredProcedure;
            cnx.Open();

            dr = cmd.ExecuteReader();
            dr.Read();

            try
            {
                Adel.Imagen = (byte[])dr["Imagen"];
                Adel.Nombre = Convert.ToString(dr["Nombre"]);

            }
            catch (Exception e)
            {
                Adel.Imagen = null;

            }


            cnx.Close();
            if (Adel.Imagen != null)//(obj != null)
            {
                context.Response.Buffer = true;
                context.Response.Charset = "";
                if (context.Request.QueryString["download"] == "1")
                {
                    context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + Adel.Nombre);
                }
                context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                context.Response.ContentType = "application/pdf";
                context.Response.BinaryWrite(Adel.Imagen);
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