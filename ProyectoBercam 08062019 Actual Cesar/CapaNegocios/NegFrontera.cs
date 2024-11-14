using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocios
{
    public class NegFrontera
    {
        public static EntFrontera BuscarFrontera(int IdDetalle)
        {
            return DAOFrontera.BuscarFrontera(IdDetalle);
        }
        public static EntFrontera BuscarFronteraNombre(string Nombre)
        {
            return DAOFrontera.BuscarFronteraPorNombre(Nombre);
        }
    }
}