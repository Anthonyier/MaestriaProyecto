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
    /// Descripción breve de AnticiposPagados
    /// </summary>
    public class AnticiposPagados : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "texto/normal";
            //context.Response.Write("Hola a todos");
            EntImagenesAnticipos Ant = null;
            Ant = new EntImagenesAnticipos();// EntPropietario();
            Ant.IdDetalle = Convert.ToInt32(context.Request.QueryString["IdDetalle"]);
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            cmd = new SqlCommand("ProcMostrarImgAnticipo", cnx);
            cmd.Parameters.AddWithValue("@IdDetalle",Ant.IdDetalle); //CodigoEntidad);
            //cmd.Parameters.AddWithValue("@Tipo_Imagen", 4);
            cmd.CommandType = CommandType.StoredProcedure;
            cnx.Open();

            dr = cmd.ExecuteReader();
            dr.Read();

            try
            {
                Ant.Imagen = (byte[])dr["Imagen"];
                Ant.NombreDoc = Convert.ToString(dr["NombreDoc"]);
               
            }
            catch (Exception e)
            {
                Ant.Imagen = null;
                
            }


            cnx.Close();
            if (Ant.Imagen != null)//(obj != null)
            {
                context.Response.Buffer = true;
                context.Response.Charset = "";
                if (context.Request.QueryString["download"] == "1")
                {
                    context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + Ant.NombreDoc );
                }
                context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                context.Response.ContentType = "application/pdf";
                context.Response.BinaryWrite(Ant.Imagen);
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