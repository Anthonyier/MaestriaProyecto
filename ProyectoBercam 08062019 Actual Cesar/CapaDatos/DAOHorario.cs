using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Data.SqlClient;
using System.Data;
using System.Transactions;

namespace CapaDatos
{
    public class DAOHorario
    {
        public static void GuardarHorarios(EntHorario Hora,EntHorario Hora2, int IdPersona)
        {
            SqlCommand cmd = null;
            SqlConnection Cnx = null;
            string resp="";
            int IdHor = 0;
            int IdHor2=0;
            try
            {
                
                using (TransactionScope scope = new TransactionScope()){
                ClaseConexion Conexion = new ClaseConexion();
                 Cnx = Conexion.conectar();
                Cnx.Open();
            
                cmd = new SqlCommand("ProcInserHorario", Cnx);
                cmd.CommandType = CommandType.StoredProcedure; 
                SqlParameter IdHor1 = new SqlParameter("@id", SqlDbType.Int);
                IdHor1.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(IdHor1);
                cmd.Parameters.AddWithValue("@HoraEntrada", TimeSpan.Parse(Hora.HoraEntrada).ToString());
                cmd.Parameters.AddWithValue("@HoraSalida",TimeSpan.Parse(Hora.HoraSalida).ToString());
                cmd.Parameters.AddWithValue("@TotalHoras",TimeSpan.Parse(Hora.TotalHoras).ToString());
                cmd.Parameters.AddWithValue("@IdTipoHorario", Hora.IdTipoHorario);
                cmd.ExecuteNonQuery();
                cmd=new SqlCommand("ProcInserHorario",Cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter IdHor22 = new SqlParameter("@id", SqlDbType.Int);
                IdHor22.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(IdHor22);
                cmd.Parameters.AddWithValue("@HoraEntrada",TimeSpan.Parse(Hora2.HoraEntrada).ToString());
                cmd.Parameters.AddWithValue("@HoraSalida",TimeSpan.Parse(Hora2.HoraSalida).ToString());
                cmd.Parameters.AddWithValue("@TotalHoras", TimeSpan.Parse(Hora2.TotalHoras).ToString());
                cmd.Parameters.AddWithValue("@IdTipoHorario", Hora.IdTipoHorario);
                cmd.ExecuteNonQuery();
                IdHor = Convert.ToInt32(IdHor1.Value);
                IdHor2 = Convert.ToInt32(IdHor22.Value);
                double TotalHora = TimeSpan.Parse(Hora.TotalHoras).TotalHours + TimeSpan.Parse(Hora2.TotalHoras).TotalHours;
                EntDetalleHorario DetHor = new EntDetalleHorario();
                DetHor.IdHorarioMañana = IdHor;
                DetHor.IdHorarioTarde = IdHor2;
                DetHor.HorasTotal = TimeSpan.FromHours(TotalHora).ToString();
                DetHor.IdPersona = IdPersona;

                bool DetHora= DAODetalleHorario.GuardarDetallehorario(ref Cnx, DetHor);
                  if (DetHora==true)
                  {
                      scope.Complete(); 
                  }

              }
           }
            catch (Exception e)
            {
                resp = e.Message;
               
            }
            finally
            {
                Cnx.Close();
            }
        }
    }
}