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
    public class NegCuentaContable
    {
        public static int InsertarCuenta(EntCuentaContable obj)
        {
            return DAOCuentaContable.GuardarCuenta(obj);
        }
        public static EntCuentaContable BuscarCuenta(int id)
        {
            return DAOCuentaContable.BuscarCuenta(id);

        }

        public static SqlDataReader BuscarNombre(string nombre)
        {
            return DAOCuentaContable.BuscarNombre(nombre);
        }

        public static int cant(int id) {
            return DAOCuentaContable.cant(id);
        }
        public static SqlDataReader Nivel(int id)
        {
            return DAOCuentaContable.Niveles(id);
        }
        public static EntCuentaContable BuscarMod(int id)
        {
            return DAOCuentaContable.ModCuenta(id);
        }

        public static int ActualizarCuenta(EntCuentaContable obj)
        {
            return DAOCuentaContable.ActualizarCuenta(obj);
        }
    }
}