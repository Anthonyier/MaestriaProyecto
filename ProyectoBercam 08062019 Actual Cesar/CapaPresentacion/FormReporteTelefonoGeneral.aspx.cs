﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using System.Data;
using System.Data.SqlClient;
using CapaNegocios;
using CapaEntidad;
using Microsoft.Reporting.WebForms;


namespace CapaPresentacion
{
    public partial class FormReporteTelefonoGeneral : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarMes();
                CargarAño();
                cmAño.Text = DateTime.Now.Year.ToString();
            }
        }
        public void CargarAño()
        {
            cmAño.Items.Clear();
            cmAño.Items.Add(new ListItem("--Seleccione Año--", ""));
            cmAño.AppendDataBoundItems = true;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            SqlCommand cmd = new SqlCommand();
            try
            {
                string sql = "Select * From Año";
                cmd.CommandText = sql;
                cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                dr = cmd.ExecuteReader();
                cmAño.DataSource = dr;
                cmAño.DataTextField = "Descripcion";
                cmAño.DataValueField = "Id";
                cmAño.DataBind();
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
        public void CargarMes()
        {
            cmMes.Items.Clear();
            cmMes.Items.Add(new ListItem("--Seleccione el Mes--", ""));
            cmMes.AppendDataBoundItems = true;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            SqlCommand cmd = new SqlCommand();
            try
            {
                string sql = "SELECT * FROM Mes";
                cmd.CommandText = sql;
                cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                //cmd.Transaction = myTrans;
                dr = cmd.ExecuteReader();
                cmMes.DataSource = dr; //cmd.ExecuteReader();    
                cmMes.DataTextField = "Descripcion";
                cmMes.DataValueField = "Id";
                cmMes.DataBind();
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

        protected void ButtonBus_Click(object sender, EventArgs e)
        {
            ReportViewer1.LocalReport.Refresh();
        }
    }
}