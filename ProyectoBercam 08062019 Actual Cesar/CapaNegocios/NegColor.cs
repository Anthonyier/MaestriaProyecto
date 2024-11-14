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
    public class NegColor
    {
        public static int InsertarColor(EntColor obj)
        {
            return DOAColor.GuardarColor(obj);//Nombres,Apellidos,CI,Direccion,Telefonos,TelfReferencia,Email,imgLicConducir,AntFelcn,AntRejap);
        }
        public static int ActualizarColor(EntColor prod)
        {
            return 1;
        }
        public static EntColor Repetidos(string color)
        {
            return DOAColor.ColorRepetidos(color);
        }
    }
}