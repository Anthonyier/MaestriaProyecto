using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Data.SqlClient;
using System.Data;


namespace CapaDatos
{
    public class DAOConciliacionCarroGuia
    {
        public static int GuardarConciliacion(EntConciliacionCarroGuia Cam)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Insert into ConciliacionCarroGuia(it,Depositos,TotalPagable,Telefonia,Rastreo,Diferencias,Pagos,"+
                    "IdRastreo,IdTelefono1,IdTelefono2,IdPeriodo,IdAño,IdPersona)" +
                    "values (@it,@Depositos,@TotalPagable,@Telefonia,@Rastreo,@Diferencias,@Pagos,@IdRastreo,@IdTelefono1,@IdTelefono2,@IdPeriodo,@IdAño,@IdPersona);";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@it", Cam.it);
                cmd.Parameters.AddWithValue("@Depositos", Cam.Depositos);
                cmd.Parameters.AddWithValue("@TotalPagable", Cam.TotalPagable);
                cmd.Parameters.AddWithValue("@Telefonia", Cam.Telefonia);
                cmd.Parameters.AddWithValue("@Rastreo", Cam.Rastreo);
                cmd.Parameters.AddWithValue("@Diferencias", Cam.Diferencias);
                cmd.Parameters.AddWithValue("@Pagos", Cam.Pagos);
                cmd.Parameters.AddWithValue("@IdRastreo", Cam.IdRastreo);
                cmd.Parameters.AddWithValue("@IdTelefono1", Cam.IdTelefono1);
                cmd.Parameters.AddWithValue("@IdTelefono2", Cam.IdTelefono2);
                cmd.Parameters.AddWithValue("@IdPeriodo", Cam.IdPeriodo);
                cmd.Parameters.AddWithValue("@IdAño", Cam.IdAño);
                cmd.Parameters.AddWithValue("@IdPersona", Cam.IdPersona);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                myTrans.Rollback();
                return 0;
            }
            finally
            {
                myTrans.Commit();
                cmd.Connection.Close();
            }
            return 1;
        }
        public static int ObtenerMes(int Per)
        {
            int Mes = 0;
            if (Per == 2 || Per == 3)
            {
                Mes = 1;
                return Mes;
            }
            else
            {
                if (Per == 4 || Per == 5)
                {
                    Mes = 2;
                    return Mes;
                }
                else
                {
                    if (Per == 6 || Per == 7)
                    {
                        Mes = 3;
                        return Mes;
                    }
                    else
                    {
                        if (Per == 8 || Per == 9)
                        {
                            Mes = 4;
                            return Mes;
                        }
                        else
                        {
                            if (Per == 10 || Per == 11)
                            {
                                Mes = 5;
                                return Mes;
                            }
                            else
                            {
                                if (Per == 12 || Per == 13)
                                {
                                    Mes = 6;
                                    return Mes;
                                }
                                else
                                {
                                    if (Per == 14 || Per == 15)
                                    {
                                        Mes = 7;
                                        return Mes;
                                    }
                                    else
                                    {
                                        if (Per == 16 || Per == 17)
                                        {
                                            Mes = 8;
                                            return Mes;
                                        }
                                        else
                                        {
                                            if (Per == 18 || Per == 19)
                                            {
                                                Mes = 9;
                                                return Mes;
                                            }
                                            else
                                            {
                                                if (Per == 20 || Per == 21)
                                                {
                                                    Mes = 10;
                                                    return Mes;
                                                }
                                                else
                                                {
                                                    if (Per == 22 || Per == 23)
                                                    {
                                                        Mes = 11;
                                                        return Mes;
                                                    }
                                                    else
                                                    {
                                                        if (Per == 24 || Per == 25)
                                                        {
                                                            Mes = 12;
                                                            return Mes;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }

                                }
                            }
                        }
                    }
                }

            }
            return Mes;
        }
        public static double PrecioCamionGuia(int Periodo, int Año)
        {
            double obj = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();

            //double DiasVigenciaCI;
            try
            {

                cmd = new SqlCommand("EncontrarDetalleCarroGuia", cnx);
                cmd.Parameters.AddWithValue("@IdPeriodo", Periodo);
                cmd.Parameters.AddWithValue("@IdAño", Año);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();

                obj = Convert.ToDouble(dr["Suma"].ToString());


            }
            catch (Exception e)
            {
                obj = 0;
                //obj.DiasVigenciaCI = 0;
            }
            finally
            {
                cnx.Close();
                //cmd.Connection.Close();
            }
            return obj; //obj
        }
        public static int EncontrarId(int Per, int Año)
        {    
            int id=0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {
                cmd = new SqlCommand("BuscarConciliacionAprobadoCarroGuia", cnx);
                cmd.Parameters.AddWithValue("@IdPeriodo", Per);
                cmd.Parameters.AddWithValue("@IdAño", Año);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();

                id = Convert.ToInt32(dr["id"].ToString());
            }
            catch (Exception e)
            {
                id = 0;
            }
            finally
            {
                cnx.Close();
            }
            return id;
            
        }
        public static void PendientedeSolicitud(int id)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Update ConciliacionCarroGuia set Solicitud=2,FechaSolicitud=@FechaSolicitud where id=@id and Solicitud=1";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.Parameters.AddWithValue("@FechaSolicitud", Convert.ToDateTime(DateTime.Today));
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                myTrans.Rollback();
            }
            myTrans.Commit();
            cnx.Close();
        }

        public static void Pagado(int id)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Update ConciliacionCarroGuia set Solicitud=3 where id=@id and Solicitud=2";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                myTrans.Rollback();
            }
            myTrans.Commit();
            cnx.Close();
        }
        public static double EncontrarPorPagar(int Id)
        {
            double Pagos = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {
                cmd = new SqlCommand("Select * from ConciliacionCarroGuia where id=" +Id,cnx);
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                Pagos = Convert.ToDouble(dr["Pagos"].ToString());
            }
            catch (Exception e)
            {
                Pagos = 0;
            }
            finally
            {
                cnx.Close();
            }
            return Pagos;
        }
        public static EntConciliacionCarroGuia ObtenerConcCarroGuia(int id)
        {
            EntConciliacionCarroGuia  obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("BuscarConcAsegCarroGuia", cnx);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                obj = new EntConciliacionCarroGuia();
                dr.Read();

                obj.id = Convert.ToInt32(dr["id"].ToString());
                obj.Depositos = Convert.ToDouble(dr["Depositos"].ToString());
                obj.it = Convert.ToDouble(dr["it"].ToString());
                obj.TotalPagable = Convert.ToDouble(dr["TotalPagable"].ToString());
                obj.Telefonia = Convert.ToDouble(dr["Telefonia"].ToString());
                obj.Rastreo = Convert.ToDouble(dr["Rastreo"].ToString());
                obj.Diferencias = Convert.ToDouble(dr["Diferencias"].ToString());
                obj.Pagos = Convert.ToDouble(dr["Pagos"].ToString());
                obj.IdRastreo = Convert.ToInt32(dr["IdRastreo"].ToString());
                obj.IdTelefono1 = Convert.ToInt32(dr["IdTelefono1"].ToString());
                obj.IdTelefono2 = Convert.ToInt32(dr["IdTelefono2"].ToString());
                obj.IdPeriodo = Convert.ToInt32(dr["IdPeriodo"].ToString());
                obj.IdAño = Convert.ToInt32(dr["IdAño"].ToString());
                obj.Aprobado = Convert.ToInt32(dr["Aprobar"].ToString());
                obj.Solicitud = Convert.ToInt32(dr["Solicitud"].ToString());
                obj.IdPersona = Convert.ToInt32(dr["IdPersona"].ToString());
                obj.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"].ToString());
                obj.FechaSolicitud = Convert.ToDateTime(dr["FechaSolicitud"].ToString());

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
        public static int EncontrarIdConciliacion(int Id)
        {
            int IdConc = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {
                cmd = new SqlCommand("Select id from ConciliacionCarroGuia where id=" + Id, cnx);
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                IdConc = Convert.ToInt32(dr["id"].ToString());
            }
            catch (Exception e)
            {
                IdConc = 0;
            }
            finally
            {
                cnx.Close();
            }
            return IdConc;

        }
        public static double EncontrarMontoRastreo(int idCamion, int Per, int Año)
        {
            int Me = ObtenerMes(Per);
            double SumRastreo = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {
                cmd = new SqlCommand("EncontrarPrecioRastreo", cnx);
                cmd.Parameters.AddWithValue("@IdCamion", idCamion);
                cmd.Parameters.AddWithValue("@Mes", Me);
                cmd.Parameters.AddWithValue("@Año", Año);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();

                SumRastreo = Convert.ToDouble(dr["MontoPagar"].ToString());
            }
            catch (Exception e)
            {
                SumRastreo = 0;
            }
            finally
            {
                cnx.Close();
            }
            return SumRastreo;
        }

        public static void Aprobar(int Periodo, int Año)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Update ConciliacionCarroGuia set Aprobar= 0, Solicitud=1 where IdPeriodo= " + Periodo + "and IdAño= " + Año + "and Solicitud=0;";
                cmd = new SqlCommand(sql, cnx);
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
                cnx.Close();
            }
        }

        public void Solicitud(int id)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Update ConciliacionCarroGuia set, Solicitud=2 where Solicitud=1 and Id=" +id;
                cmd = new SqlCommand(sql, cnx);
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
                cnx.Close();
            }
        }
        public static EntConciliacionCarroGuia EncontrarConciliacionCarroGuia(int IdPeriodo,int IdAño)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            EntConciliacionCarroGuia ConcCarro = null;
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {
                cmd = new SqlCommand("Select * from ConciliacionCarroGuia where IdPeriodo=@IdPeriodo and IdAño=@IdAño", cnx);
                cmd.Parameters.AddWithValue("@IdPeriodo", IdPeriodo);
                cmd.Parameters.AddWithValue("@IdAño", IdAño);

                cnx.Open();
                dr = cmd.ExecuteReader();
                ConcCarro = new EntConciliacionCarroGuia();
                dr.Read();
                ConcCarro.id = Convert.ToInt32(dr["id"].ToString());
                ConcCarro.IdPeriodo = Convert.ToInt32(dr["IdPeriodo"].ToString());
                ConcCarro.IdAño = Convert.ToInt32(dr["IdAño"].ToString());
            }
            catch (Exception e)
            {
                ConcCarro = null;
            }
            finally
            {
                cnx.Close();
            }
            return ConcCarro;
        }
        public static double EncontrarNumeroTelefono(int IdNumero, int Per, int Año)
        {
            int Me = ObtenerMes(Per);
            double Suma = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {
                cmd = new SqlCommand("EncontrarPrecioTelefono", cnx);
                cmd.Parameters.AddWithValue("@Id", IdNumero);
                cmd.Parameters.AddWithValue("@Mes", Me);
                cmd.Parameters.AddWithValue("@Año", Año);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();

                Suma = Convert.ToInt32(dr["MontoCobrar"].ToString());
            }
            catch (Exception e)
            {
                Suma = 0;
            }
            finally
            {
                cnx.Close();
            }
            return Suma;
        }
       
        public static int Rastreo(int idCamion, int Per, int Año)
        {
            int Me = ObtenerMes(Per);
            int Rast = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {
                cmd = new SqlCommand("EncontrarPrecioRastreo", cnx);
                cmd.Parameters.AddWithValue("@IdCamion", idCamion);
                cmd.Parameters.AddWithValue("@Mes", Me);
                cmd.Parameters.AddWithValue("@Año", Año);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();

                Rast = Convert.ToInt32(dr["Id"].ToString());
            }
            catch (Exception e)
            {
                Rast = 0;
            }
            finally
            {
                cnx.Close();
            }
            return Rast;
        }
        public static int EncontrarIdCliente(string Nombre)
        {
            int obj = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();

            //double DiasVigenciaCI;
            try
            {

                cmd = new SqlCommand("BuscarPersona", cnx);
                cmd.Parameters.AddWithValue("@Cliente", Nombre);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();

                obj = Convert.ToInt32(dr["Id_Persona"].ToString());


            }
            catch (Exception e)
            {
                obj = 0;
                //obj.DiasVigenciaCI = 0;
            }
            finally
            {
                cnx.Close();
                //cmd.Connection.Close();
            }
            return obj; //obj
        } 
    }
}