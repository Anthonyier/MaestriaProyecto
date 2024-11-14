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
    public class NegDetalleTelefono
    {
        public static int GuardarTelefono(EntDetalleTelefono Telf)
        {
            return DAODetalleTelefono.Guardar(Telf);
        }
        public static EntDetalleTelefono BuscarTodo(int id)
        {
            return DAODetalleTelefono.ConsultaTodo(id);
        }

        public static int GuardarGrupoTelefono(int Mes, int año)
        {
            return DAODetalleTelefono.GuardarGrupoTelefono(Mes, año);
        }

        public static int Actualizar(EntDetalleTelefono Telf)
        {
            return DAODetalleTelefono.Actualizar(Telf);
        }
        public static void EliminarTelefono(int id)
        {
            DAODetalleTelefono.EliminarTelefono(id);
        }
    }
}