using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaNegocios;
using CapaDatos;
using System.Data.SqlClient;
using System.Data;

namespace CapaNegocios
{
    public class NegHorario
    {
        public static void InsertarHorario(EntHorario Hor,EntHorario Hor2,int IdPer)
        {
            DAOHorario.GuardarHorarios(Hor,Hor2,IdPer);
        }
    }
}