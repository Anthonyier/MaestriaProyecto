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
    public class NegKilometraje
    {
        public static int GuardarKilometraje(EntKilometraje Kilo)
        {
            return DAOKilometraje.GuardarKilometraje(Kilo);
        }

        public static EntKilometraje RepetidosKilometraje(int IdRuta)
        {
            EntKilometraje kilo=DAOKilometraje.RepetidosKilometrajes(IdRuta);
            return kilo;
        }
    }
}