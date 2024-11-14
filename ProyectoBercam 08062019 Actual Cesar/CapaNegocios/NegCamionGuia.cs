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
    public class NegCamionGuia
    {
        public static int InsertarCamionGuia(EntCamionGuia Cam)
        {
            return DAOCamionGuia.GuardarCamionGuia(Cam);
        }

        public static int MaximoCam()
        {
            return DAOCamionGuia.DetalleMax();
        }
        public static int ActualizarCamionGuia(EntCamionGuia  Cam)
        {
            return 0;
        }

        public static EntCamionGuia EncontrarRepetidoCamionGuia(int Periodo, int Año, int IdProveedor,int IdRegion)
        {
            return DAOCamionGuia.EncontrarRepetidoCarroGuia(Periodo, Año, IdProveedor, IdRegion);
        }
    }
}