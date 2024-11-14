﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidad;
using CapaDatos;
using System.Data;
using System.Data.SqlClient;
using CapaNegocios;
using System.IO;

namespace CapaPresentacion
{
    public partial class FormAnticipo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarAño();
                CargarPeriodo();
                CargarRegion();
            }

        }

        protected void Calendar_FechaOnSelectionChanged(object sender, EventArgs e)
        {
            if (CalendarFecha.SelectedDate != null)
            {
                TextFecha.Text = CalendarFecha.SelectedDate.ToString("d");
                CalendarFecha.Visible = false;
            }

        }
        protected void imgCalendarFecha_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarFecha.Visible)
            {
                CalendarFecha.Visible = false;
            }
            else
            {
                CalendarFecha.Visible = true;
            }
        }

        public void CargarAño()
        {
            DdlAño.Items.Clear();
            DdlAño.Items.Add(new ListItem("--Seleccione Año--", ""));
            DdlAño.AppendDataBoundItems = true;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            SqlCommand cmd = new SqlCommand();
            try
            {
                string sql = "SELECT * FROM Año";
                cmd.CommandText = sql;
                cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                //cmd.Transaction = myTrans;
                dr = cmd.ExecuteReader();
                DdlAño.DataSource = dr; //cmd.ExecuteReader();    
                DdlAño.DataTextField = "Descripcion";
                DdlAño.DataValueField = "Id";
                DdlAño.DataBind();
                dr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Connection.Dispose();
            }
        }

        public void CargarRegion()
        {
            DdlRegion.Items.Clear();
            DdlRegion.Items.Add(new ListItem("--Seleccione Region--", ""));
            DdlRegion.AppendDataBoundItems = true;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            SqlCommand cmd = new SqlCommand();
            try
            {
                string sql = "SELECT * FROM Region";
                cmd.CommandText = sql;
                cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                //cmd.Transaction = myTrans;
                dr = cmd.ExecuteReader();
                DdlRegion.DataSource = dr; //cmd.ExecuteReader();    
                DdlRegion.DataTextField = "Region";
                DdlRegion.DataValueField = "Id";
                DdlRegion.DataBind();
                dr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Connection.Dispose();
            }
        }
     
        public void CargarPeriodo()
        {
            DdlPeriodo.Items.Clear();
            DdlPeriodo.Items.Add(new ListItem("--Seleccione Periodo--", ""));
            DdlPeriodo.AppendDataBoundItems = true;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            SqlCommand cmd = new SqlCommand();
            try
            {
                string sql = "SELECT * FROM Periodo";
                cmd.CommandText = sql;
                cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                //cmd.Transaction = myTrans;
                dr = cmd.ExecuteReader();
                DdlPeriodo.DataSource = dr; //cmd.ExecuteReader();    
                DdlPeriodo.DataTextField = "Quincena";
                DdlPeriodo.DataValueField = "id";
                DdlPeriodo.DataBind();
                dr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Connection.Dispose();
            }
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (TextMonto.Text != "")
            {
                int idCamion = 0;
                SqlDataReader d = NegCamiones.BuscarCamion(TextoPlacasAnticipos.Text);
                d.Read();
                if (d.HasRows == true)
                {
                    if(d!=null)
                    {
                        try
                        {
                            idCamion = int.Parse(d["Id_Camion"].ToString());
                        }
                        catch (Exception er)
                        {

                        }
                    }
                }
                EntAnticipo  Ant= new EntAnticipo();
                Ant.IdCamion = idCamion;
                Ant.Monto = Convert.ToDouble(TextMonto.Text);
                Ant.fecha = Convert.ToDateTime(TextFecha.Text);
                Ant.Año = int.Parse(DdlAño.Text);
                Ant.Periodo = int.Parse(DdlPeriodo.Text);
                Ant.Region = Convert.ToInt32(DdlRegion.Text);
                if (Request.QueryString["Id"] != null)
                {
                    //Guia.Id_Guia = Convert.ToInt32(Request.QueryString["Id"]);
                    //if (NegCamionGuia.ActualizarCamionGuia(Guia) == 1)
                    //{
                    //    //Response.Redirect("frmPrincipal.aspx");
                    //    //lblError.Text = "Registro de Entidad ACTUALIZADO satisfactoriamente";
                    //    //lblError.Visible = true;
                    //    Response.Write("<script languaje =javascript>alert ('Registro de Camion Guia ACTUALIZADO satisfactoriamente');</script>");
                    //    //Response.Redirect("frmRegistrarPropietarios.aspx");

                    //}
                    //else
                    //{
                    //    lblError.Text = "No se pudo ACTUALIZAR el Camion Guia por algun motivo, Verifique e intente nuevamente";
                    //    lblError.Visible = true;
                    //}
                }
                else
                {
                    if (NegAnticipo.InsertarAnticipo(Ant)== 1)
                    {
                        Response.Write("<script languaje =javascript>alert ('Registro de Anticipo satisfactoriamente');</script>");
                        //Response.Redirect("frmRegistrarPropietarios.aspx");
                        TextMonto.Text = "";
                        DdlAño.Text = "";
                        DdlPeriodo.Text = "";
                        DdlRegion.Text = "";
                    }
                    else
                    {
                        lblError.Text = "No se pudo Insertar el Anticipo por algun motivo, Verifique e intente nuevamente";
                        lblError.Visible = true;
                    }
                }
            }
        }
    }
}