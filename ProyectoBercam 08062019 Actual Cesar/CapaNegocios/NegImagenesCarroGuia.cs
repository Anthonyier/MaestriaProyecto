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
    public class NegImagenesCarroGuia
    {
        public static int InsertarImagen(EntImagenesCarroGuia obj)
        {
            return DAOImagenesCarroGuia.GuardarImagenes(obj);
        }
        public static EntImagenesCarroGuia Download(int id)
        {
            return DAOImagenesCarroGuia.Download(id);
        }
        public static bool MaestroProveedor(DateTime Fecha, int idPersona, int idUsuario, double monto, EntImagenesCarroGuia  ImgPaga, int idTipoPago, int IdPasivo)
        {
            return DAOImagenesCarroGuia.DInsertar(Fecha, idPersona, idUsuario, monto, ImgPaga, idTipoPago, IdPasivo);
        }
        public static EntImagenesCarroGuia ConsultaImagen(int id)
        {
            return DAOImagenesCarroGuia.ConsultaImagen(id);
        }
        
    }
}