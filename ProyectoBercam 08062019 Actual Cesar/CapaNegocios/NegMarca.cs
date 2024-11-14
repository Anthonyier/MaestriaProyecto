using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaNegocios;
using CapaDatos;

namespace CapaNegocios
{
    public class NegMarca
    {
        public static int InsertarMarca(EntMarca obj)
        {
            return DAOMarca.GuardarMarca(obj);//Nombres,Apellidos,CI,Direccion,Telefonos,TelfReferencia,Email,imgLicConducir,AntFelcn,AntRejap);
        }
        public static int ActualizarMarca(EntMarca prod)
        {
            return 1;
        }

        public static EntMarca Repetidos(string mar)
        {
            return DAOMarca.Repetidos(mar);
        }
    }
}