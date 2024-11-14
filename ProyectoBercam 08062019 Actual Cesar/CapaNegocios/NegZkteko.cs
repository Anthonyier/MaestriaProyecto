using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CapaEntidad;
using CapaDatos;
using System.Data.SqlClient;
using System.Data;


namespace CapaNegocios
{
    public class NegZkteko
    {

        public static int Insertar(EntPersonaZkTeko Zkt)
        {
            return DAOZkTeko.Guardar(Zkt);
        }

        public static int ObtenerIdZk(int IdPersona)
        {
            return DAOZkTeko.ObtenerIdZkteko(IdPersona);
        }
    }
}