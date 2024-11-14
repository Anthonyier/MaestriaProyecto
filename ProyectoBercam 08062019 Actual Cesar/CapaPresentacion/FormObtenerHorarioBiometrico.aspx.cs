using System;
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

namespace CapaPresentacion
{
    public partial class FormObtenerHorarioBiometrico : System.Web.UI.Page
    {
        public ZkTekoHelper SDK = new ZkTekoHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            EntUsuario Usu = (EntUsuario)Session["Usuario"];
            if(Usu.Id_Usuario==1002 || Usu.Id_Usuario==1 || Usu.Id_Usuario==1009)
            {
                ButtCargar.Visible=true;
            }

        }
        protected void ButtonBuscarMañana_Click(object sender, EventArgs e)
        {
            string fromTime = TextMañana.Text;


            DataTable dt_periodLog = new DataTable("dt_periodLog");
            GridView1.AutoGenerateColumns = true;
            GridView1.Columns.Clear();
            dt_periodLog.Columns.Add("User ID", System.Type.GetType("System.String"));
            dt_periodLog.Columns.Add("Verify Date", System.Type.GetType("System.String"));
            dt_periodLog.Columns.Add("Verify Type", System.Type.GetType("System.Int32"));
            dt_periodLog.Columns.Add("Verify State", System.Type.GetType("System.Int32"));
            dt_periodLog.Columns.Add("WorkCode", System.Type.GetType("System.Int32"));
            GridView1.DataSource = dt_periodLog;
            //this.SDK.sta_readLogByPeriod 
        }

        public static int ObtenerPersona(string NombreUsu)
        {
            SqlDataReader dr = NegPersona.BuscarPersona(NombreUsu);
            int IdPersona = 0;
            dr.Read();
            if (dr.HasRows == true)
            {
                if (dr != null)
                {
                    try
                    {
                        IdPersona = int.Parse(dr["Id_Persona"].ToString());
                        return IdPersona;
                    }
                    catch (Exception E)
                    {
                        return 0;
                    }
                }
            }
            return IdPersona;
        }

        protected void ImagenMañana_Click(object sender, ImageClickEventArgs e)
        {

            if (CalendarMañana.Visible)
            {
                CalendarMañana.Visible = false;
            }
            else
            {
                CalendarMañana.Visible = true;
            }

        }
        protected void Calendar_MañanaOnSelectionChanged(object sender, EventArgs e)
        {
            if (CalendarMañana.SelectedDate != null)
            {
                TextMañana.Text = CalendarMañana.SelectedDate.ToString("d");
                CalendarMañana.Visible = false;
            }

        }




        protected void ButtCargar_Click(object sender, EventArgs e)
        {
            DateTime Date = Convert.ToDateTime(TextMañana.Text);
            int Year = Date.Year;
            int Month = Date.Month;
            int Day = Date.Day;
            DataTable dt_period = new System.Data.DataTable();
            GridView1.AutoGenerateColumns = true;
            GridView1.Columns.Clear();
            dt_period.Columns.Add("Nombre",System.Type.GetType("System.String"));
            dt_period.Columns.Add("User ID", System.Type.GetType("System.String"));
            dt_period.Columns.Add("Verify Date", System.Type.GetType("System.String"));
            //int IdPersona = ObtenerPersona(TextPersonaZkTeUsuario.Text);
            //int IdZkTeko = NegZkteko.ObtenerIdZk(IdPersona);
            //string IdZkt = Convert.ToString(IdZkTeko);
            int Connect = SDK.sta_ConnectTCP("192.168.1.211", "4370", "0");
            this.SDK.sta_ReadByDate(Day, Month, Year, dt_period);
            GridView1.DataSource = dt_period;
            GridView1.DataBind();
            GridView2.AutoGenerateColumns = true;
            GridView2.Columns.Clear();
            GrillaHora();
        }
        protected void GrillaHora()
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            ClaseConexion cn = new ClaseConexion();
            bool Sw1 = false;
            bool Sw2 = false;
            SqlConnection cnx = cn.conectar();
            DataTable dtHora = new System.Data.DataTable();
            dtHora.Columns.Add("Nombre", System.Type.GetType("System.String"));
            dtHora.Columns.Add("Inicio", System.Type.GetType("System.String"));
            dtHora.Columns.Add("Final", System.Type.GetType("System.String"));
            dtHora.Columns.Add("Horas", System.Type.GetType("System.String"));
            
            try
            {
                cmd = new SqlCommand("Select Persona.Nombre+' '+Persona.Apellidos as Nombres,PersonaZkTeko.IdZktekoReset,PersonaZkteko.Id,Persona.Id_Persona from"+
                    " Persona,PersonaZkTeko where Persona.Id_Persona=PersonaZkTeko.IdPersona and Persona.Estado=1",cnx);
                cnx.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        int Cont = 0;
                        int IdZkt = int.Parse(dr["IdZktekoReset"].ToString());
                        int IdRep = int.Parse(dr["Id"].ToString());
                        DateTime FechaMañanaIni = new DateTime(2001,1,1,0,0,0);
                        DateTime FechaMañanaFin = new DateTime(2001,1,1,0,0,0);
                        DateTime FechaTardeInic = new DateTime(2001,1,1,0,0,0);
                        DateTime FechaTardeFin = new DateTime(2001,1,1,0,0,0);
                        
                        foreach (GridViewRow row in GridView1.Rows)
                        {
                            int IdZk=Convert.ToInt32(row.Cells[1].Text );
                            if (IdZk==IdZkt)
                            {
                                switch (Cont)
                                {
                                    case 0:
                                        FechaMañanaIni = Convert.ToDateTime(row.Cells[2].Text);
                                        if (Convert.ToString(FechaMañanaIni ) == "1/1/0001 00:00:00")
                                        {
                                            Sw1 = true;
                                            FechaMañanaIni = new DateTime(2001, 1, 1, 0, 0, 0);
                                        }
                                    break;

                                    case 1:
                                        FechaMañanaFin = Convert.ToDateTime(row.Cells[2].Text);
                                        if (Convert.ToString(FechaMañanaFin) == "1/1/0001 00:00:00")
                                        {
                                            Sw1 = true;
                                            FechaMañanaFin = new DateTime(2001, 1, 1, 0, 0, 0);
                                        }
                                    break;

                                    case 2:
                                    FechaTardeInic = Convert.ToDateTime(row.Cells[2].Text);
                                    if (Convert.ToString(FechaTardeInic) == "1/1/0001 00:00:00")
                                    {
                                        
                                        Sw2 = true;
                                        FechaTardeInic = new DateTime(2001, 1, 1, 0, 0, 0);
                                    }
                                    break;

                                    case 3:
                                    FechaTardeFin = Convert.ToDateTime(row.Cells[2].Text);
                                    if (Convert.ToString(FechaTardeFin) == "1/1/0001 00:00:00")
                                    {
                                        
                                        Sw2 = true;
                                        FechaTardeFin = new DateTime(2001, 1, 1, 0, 0, 0);
                                    }
                                    break;

                                }
                                Cont++;
                            }
                        }
                        if (Convert.ToString(FechaMañanaIni) == "1/1/2001 00:00:00" | Convert.ToString(FechaMañanaFin)=="1/1/2001 00:00:00")
                        {
                            Sw1 = true;
                        }
                        else
                        {
                            Sw1=false;
                        }
                        if (Convert.ToString(FechaTardeInic) == "1/1/2001 00:00:00" | Convert.ToString(FechaTardeFin) == "1/1/2001 00:00:00")
                        {
                            Sw2 = true;
                        }
                        else
                        {
                            Sw2 = false;
                        }
                        DataRow Row = dtHora.NewRow();
                        Row["Nombre"] = dr["Nombres"].ToString();
                        Row["Inicio"] = FechaMañanaIni;
                        Row["Final"] = FechaMañanaFin;
                        string CalculoEntrMaHora = Convert.ToString(FechaMañanaIni.Hour);
                        string CalculoEntMaMin = Convert.ToString(FechaMañanaIni.Minute);
                        string CalculoEntrMaSeg = Convert.ToString(FechaMañanaIni.Second);
                        string MañanaInicio=CalculoEntrMaHora+":"+CalculoEntMaMin+":"+CalculoEntrMaSeg;
                        string CalculoSalMaHora = Convert.ToString(FechaMañanaFin.Hour);
                        string CalculoSalMaMin = Convert.ToString(FechaMañanaFin.Minute);
                        string CalculoSalManSeg = Convert.ToString(FechaMañanaFin.Second);
                        string MañanaFinal = CalculoSalMaHora + ":" + CalculoSalMaMin + ":" + CalculoSalManSeg; 
                        double HourEntMaña = TimeSpan.Parse(MañanaInicio).TotalHours;
                        HourEntMaña = Math.Round(HourEntMaña, 2);
                        double HourSalMaña = TimeSpan.Parse(MañanaFinal).TotalHours;
                        HourSalMaña = Math.Round(HourSalMaña, 2);
                        double HourTotalMaña = new double();
                        if (Sw1 == true)
                        {
                            HourTotalMaña=0;
                        }
                        else
                        {
                           HourTotalMaña = Math.Round(HourSalMaña - HourEntMaña, 2);
                        }
                        
                        TimeSpan HoraMañaTotal = TimeSpan.FromHours(HourTotalMaña);
                        Row["Horas"] = HoraMañaTotal;
                        //Row["Dia"] = FechaMañanaIni.DayOfWeek;
                        dtHora.Rows.Add(Row);
                        DataRow Fila = dtHora.NewRow();
                        Fila["Nombre"] = dr["Nombres"].ToString();
                        Fila["Inicio"] = FechaTardeInic;
                        Fila["Final"] = FechaTardeFin;
                        string CalculoEntrTarHora = Convert.ToString(FechaTardeInic.Hour);
                        string CalculoEntrTarMin = Convert.ToString(FechaTardeInic.Minute);
                        string CalculoEntrTarSeg = Convert.ToString(FechaTardeInic.Second);
                        string TardeInicio = CalculoEntrTarHora + ":" + CalculoEntrTarMin + ":" + CalculoEntrMaSeg;
                        double HourEntTard = TimeSpan.Parse(TardeInicio).TotalHours;
                        HourEntTard=Math.Round(HourEntTard,2);
                        string CalculoSalTarHora = Convert.ToString(FechaTardeFin.Hour);
                        string CalculoSalTarMin = Convert.ToString(FechaTardeFin.Minute);
                        string CalculoSalTarSeg = Convert.ToString(FechaTardeFin.Second);
                        string TardeSal = CalculoSalTarHora + ":" + CalculoSalTarMin + ":" + CalculoSalTarSeg;
                        double HourSalTard = TimeSpan.Parse(TardeSal).TotalHours;
                        HourSalTard = Math.Round(HourSalTard, 2);
                        double HourTotalTarde = new double();
                        if (Sw2 == true)
                        {
                            HourTotalTarde = 0;
                        }
                        else
                        {
                            HourTotalTarde = HourSalTard - HourEntTard;
                        }

                        TimeSpan HoraTardeTotal = TimeSpan.FromHours(HourTotalTarde);
                        Fila["Horas"] = HoraTardeTotal;
                        //Fila["Dia"] = FechaTardeInic.DayOfWeek;
                        dtHora.Rows.Add(Fila);
                        EntHorarioPersona Hp = new EntHorarioPersona();
                        Hp.IdPerZkt=int.Parse(dr["Id"].ToString());
                        if (Convert.ToString(FechaMañanaIni) == "1/1/0001 00:00:00")
                        {
                            Hp.Horario1 = Convert.ToDateTime("01/01/01");
                        }else
                        {
                             Hp.Horario1 = FechaMañanaIni;
                        }
                       if (Convert.ToString(FechaMañanaFin) == "1/1/0001 00:00:00")
                       {
                           Hp.Horario2 = Convert.ToDateTime("01/01/01");
                       }
                       else
                       {
                           Hp.Horario2 = FechaMañanaFin;
                       }
                       if (Convert.ToString(FechaTardeInic) == "1/1/0001 00:00:00")
                       {
                           Hp.Horario3 = Convert.ToDateTime("01/01/01");
                       }
                       else
                       {
                           Hp.Horario3 = FechaTardeInic;
                       }
                       if (Convert.ToString(FechaTardeFin) == "1/1/0001 00:00:00")
                       {
                           Hp.Horario4 = Convert.ToDateTime("01/01/01");
                       }
                       else
                       {
                           Hp.Horario4 = FechaTardeFin;
                       }
                        
                        double Total = Math.Round(HourTotalTarde + HourTotalMaña,0);


                        string Dias = Convert.ToString(FechaMañanaIni.DayOfWeek);
                        if (Dias != "Saturday")
                        {
                            if (HourTotalTarde == 0)
                            {
                                Total = 0;
                            }
                        }

                        int gen = NegUsuario.obtenerGenero(Convert.ToInt32(dr["Id_Persona"].ToString()));
                        string Dia = Convert.ToString(FechaMañanaIni.DayOfWeek);
                        double Restantes = 0;
                        if (Dia == "Saturday")
                        {
                            if (gen == 1)
                            {
                                Restantes = Total - 5;
                            }
                            else
                            {
                                Restantes =  Total - 4;
                            }
                        }
                        else
                        {
                            if (gen == 1)
                            {
                                if (Sw1 == true | Sw2 == true)
                                {
                                    Total = 4;

                                }
                                Restantes = Total - 8;
                            }
                            else
                            {
                                if (Sw1 == true)
                                {
                                    Total = 4;
                                }
                                else
                                {
                                    if (Sw2 == true)
                                    {
                                        Total = 3;
                                    }
                                }
                                Restantes =  Total - 7 ;
                            }
                           
                        }
                        Hp.TotalHora = Total;
                        Hp.HorasFaltantes = Restantes;
                        string DayRep = Convert.ToString(FechaMañanaIni.Day);
                        string MesRep = Convert.ToString(FechaMañanaIni.Month);
                        string AñoRep = Convert.ToString(FechaMañanaIni.Year);
                        string FechaRep = DayRep + "/" + MesRep + "/" + AñoRep;
                        DateTime Comp = Convert.ToDateTime(FechaRep);
                        EntHorarioPersona Repet = NegHorarioPersona.Repetidos(Comp, IdRep);
                        if (Repet == null)
                        {
                            NegHorarioPersona.GuardarHorarioPersona(Hp);
                        }
                       
                    }
                }
            }
            catch (Exception e)
            {

            }
            cnx.Close();
            GridView2.DataSource = dtHora;
            GridView2.DataBind();
            GuardarFaltantes();
        }

        protected void ButtReporte_Click(object sender, EventArgs e)
        {
            string FechaText = TextMañana.Text;
            Response.Redirect("FormReporteHorarioPersona.aspx?Fecha=" + FechaText );
        }

        protected void GuardarFaltantes()
        {
            SqlDataReader dr = NegHorarioFaltantes.ReaderHorarios(Convert.ToDateTime(TextMañana.Text));
            int IdPersonaZkTeko = 0;
            if (dr.HasRows == true)
            {
                while (dr.Read())
                {
                    try
                    {
                        IdPersonaZkTeko = int.Parse(dr["Id"].ToString());
                        NegHorarioFaltantes.GuardarHorariosFaltantes(Convert.ToDateTime(TextMañana.Text), IdPersonaZkTeko);
                    }
                    catch (Exception E)
                    {

                    }
                }
            }
        }

        protected void ButtLista_Click(object sender, EventArgs e)
        {
            DateTime Date = Convert.ToDateTime(TextMañana.Text);
            int Year = Date.Year;
            int Month = Date.Month;
            int Day = Date.Day;
            DataTable dt_period = new System.Data.DataTable();
            GridView1.AutoGenerateColumns = true;
            GridView1.Columns.Clear();
            dt_period.Columns.Add("Nombre", System.Type.GetType("System.String"));
            dt_period.Columns.Add("User ID", System.Type.GetType("System.String"));
            dt_period.Columns.Add("Verify Date", System.Type.GetType("System.String"));
            //int IdPersona = ObtenerPersona(TextPersonaZkTeUsuario.Text);
            //int IdZkTeko = NegZkteko.ObtenerIdZk(IdPersona);
            //string IdZkt = Convert.ToString(IdZkTeko);
            int Connect = SDK.sta_ConnectTCP("192.168.1.211", "4370", "0");
            this.SDK.sta_ReadByDate(Day, Month, Year, dt_period);
            GridView1.DataSource = dt_period;
            GridView1.DataBind();
            GridView2.AutoGenerateColumns = true;
            GridView2.Columns.Clear();
        }

       
    }
}