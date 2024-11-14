using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocios
{
    public class NegImagenesAdelantoDepagos
    {
        public static int GuardarImagens(EntImagenesAdelantoDePagos Img)
        {
            return DAOImagenesAdelantoDePagos.GuardarImagenes(Img);
        }

        public static int TransImgAdel(EntImagenesAdelantoDePagos Img)
        {
           return  DAOImagenesAdelantoDePagos.GuardarAdelTans(Img);
        }
        public static EntImagenesAdelantoDePagos ConsultaImagen(int Id)
        {
            return DAOImagenesAdelantoDePagos.ConsultaImagen(Id);
        }

        //public static EntImagenesAdelantoDePagos (int IdAdelanto)
        //{
        //    return(IdAdelanto);
        //}
    }
}