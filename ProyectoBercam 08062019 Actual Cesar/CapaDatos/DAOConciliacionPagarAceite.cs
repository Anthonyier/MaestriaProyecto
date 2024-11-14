﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Threading;

namespace CapaDatos
{
    public class DAOConciliacionPagarAceite
    {


        public static void PagadoSinFactura(int id)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Update ConciliacionPagarAceite set SF1=1 where Id=@Id";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                myTrans.Rollback();
            }
            finally
            {
                myTrans.Commit();
                cmd.Connection.Close();
            }
        }
        public static void Pagado(int id)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Update ConciliacionPagarAceite set Solicitud=2 where Id=@Id";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                myTrans.Rollback();
            }
            finally
            {
                myTrans.Commit();
                cmd.Connection.Close();
            }
        }
        public static EntConciliacionPagarAceite ConcPagar(int id)
        {
            EntConciliacionPagarAceite obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("BuscarConcAsegAceite", cnx);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                obj = new EntConciliacionPagarAceite();
                dr.Read();

                obj.id = Convert.ToInt32(dr["id"].ToString());
                obj.FleteBruto = Convert.ToDouble(dr["FleteBruto"].ToString());
                obj.MultaMerma = Convert.ToDouble(dr["MultaMerma"].ToString());
                obj.Anticipos = Convert.ToDouble(dr["Anticipos"].ToString());
                obj.Servicios = Convert.ToDouble(dr["Servicios"].ToString());
                obj.TotalPagable = Convert.ToDouble(dr["TotalPagable"].ToString());
                obj.TotalFactura = Convert.ToDouble(dr["TotalFactura"].ToString());
                obj.TotalAdelantos = Convert.ToDouble(dr["TotalAdelantos"].ToString());
                obj.PorPagar = Convert.ToDouble(dr["PorPagar"].ToString());
                obj.IdTitular = Convert.ToInt32(dr["IdTitular"].ToString());
                obj.IdAño = Convert.ToInt32(dr["IdAño"].ToString());
                obj.IdFactura = Convert.ToInt32(dr["IdFactura"].ToString());

            }
            catch (Exception e)
            {
                obj = null;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return obj;
        }
        public static void ActualizarConciliacionPorPagarIdPmm(int Id_Pmm, int Id)
        {
            SqlCommand cmd = null;
            SqlConnection cnx = null;
            SqlTransaction myTrans = null;
            ClaseConexion Conexion = new ClaseConexion();

            try
            {
                cnx = new SqlConnection();
                cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "update ConciliacionPagarAceite set Id_Pmm=@Id_Pmm where Id=@Id";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Id_Pmm", Id_Pmm);
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                myTrans.Commit();
            }
            catch (Exception ex)
            {
                myTrans.Rollback();
            }
            finally
            {
                cmd.Connection.Close();
            }
        }
        public static int InsertarPagoMasivoLiqui()
        {
            SqlCommand cmd = null;
            SqlConnection cnx = null;
            SqlTransaction myTrans = null;
            ClaseConexion Conexion = new ClaseConexion();
            int IdPagoMasivo = 0;
            try
            {
                cnx = new SqlConnection();
                cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "insert into Pago_MasivoLiquiLog (Activo) values(1);SELECT Scope_Identity();";
                cmd = new SqlCommand(sql, cnx);
                cmd.Transaction = myTrans;
                IdPagoMasivo = Convert.ToInt32(cmd.ExecuteScalar());
                myTrans.Commit();
            }
            catch (Exception ex)
            {
                myTrans.Rollback();
                return 0;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return IdPagoMasivo;
        }
        public static int VerificarYaPagadoLiquidacion(int Id)
        {
            int IdPago = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("select Id_Pmm from ConciliacionPagarAceite where Id =@Id", cnx);
                cmd.Parameters.AddWithValue("@Id", Id);
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                IdPago = Convert.ToInt32(dr["Id_Pmm"].ToString());
                dr.Close();
            }
            catch (Exception e)
            {
                dr = null;
                return 0;
            }
            return IdPago;
        }
        public static int EncontrarIdPagoMasiv(int Id)
        {
            int IdPagoMasivo = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                string sql = "Select Id_Pmm from ConciliacionPagarAceite where id=@Id";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Id", Id);
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                IdPagoMasivo = Convert.ToInt32(dr["Id_Pmm"].ToString());
                dr.Close();
            }
            catch (Exception ex)
            {
                dr = null;
                return 0;
            }
            return IdPagoMasivo;
        }
    }

}