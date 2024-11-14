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
    public class NegAnticipo
    {
        public static int InsertarAnticipo(EntAnticipo Ant)
        {
            return DAOAnticipo.GuardarAnticipo(Ant);
        }

        public static bool Mensaje(string Mensj)
        {
            return DAOAnticipo.EnviarCorreo(Mensj);
        }
        public static EntAnticipo ObtenerAnticipo(int id)
        {
            return DAOAnticipo.ObtenerAnticipos(id);
        }

        public static SqlDataReader ReaderAnticipo(int id)
        {
            return DAOAnticipo.ReaderAnticipo(id);
        }
        public static int Confirmar(int Id)
        {
            return DAOAnticipo.Confirmar(Id);
        }
        public static void Enviado(int id)
        {
            DAOAnticipo.Enviado(id);
        }
    }
}